// Evidence-based HLSL proposal, not integrated or render-validated.
// Exact source variants: first subshader/pass, DIRECTIONAL, _CUSTOM_SHAPE,
// WATER_REFLECTIVE, _DISTORT_ON, _LIGHTABS_ON, _SHADING_PIXELLIT, LPW_FOAM,
// and _WAVES_OFF (HIGH) / _WAVES_HIGHQUALITY (MAX).
// Excludes fog/shadow variants. Include UnityCG.cginc before this file.
// Declare all original uniforms and samplers in caller. Do not normalize
// interpolated normal in fragment: original DXBC does not do so.
float LPWRecoveredHash(float x) { return frac(sin(x) * 43758.546875); }
float LPWRecoveredNoise(float2 uv)
{
    float2 cell = floor(uv), f = frac(uv);
    f = f*f*(3.0-2.0*f);
    float n = cell.x*57.0+cell.y;
    return lerp(lerp(LPWRecoveredHash(n), LPWRecoveredHash(n+1), f.y),
                lerp(LPWRecoveredHash(n+57), LPWRecoveredHash(n+58), f.y),f.x)-0.5;
}
float3 LPWRecoveredDisplace(float3 objectPosition, float3 objectNormal, bool highQualityWaves)
{
    float3 p = mul(unity_ObjectToWorld,float4(objectPosition,1)).xyz;
    float2 rippleUV = float2(p.x+p.y*57.299999,p.z+_Time.y*_RSpeed_)/_TexSize_;
    p += objectNormal * ((tex2Dlod(_NoiseTex,float4(rippleUV,0,0)).a-0.5)*_RHeight_);
    if(highQualityWaves)
    {
        float2 waveUV=float2((p.x*_Direction_.x-p.z*_Direction_.y)/_Stretch,
                            (p.z*_Direction_.x+p.x*_Direction_.y)/_Length+_Time.y*_Speed_)/_Scale_;
        float wave=LPWRecoveredNoise(waveUV);
        p += wave * float3(-_Direction_.w,_Height_,-_Direction_.z);
    }
    return p;
}
void LPWRecoveredCustomVertex(float3 objectPosition,float3 objectNormal,float4 uv0,float2 uv1,
                              bool highQualityWaves,out float3 worldPos,out float3 faceNormal,
                              out float4 clipPosition,out float4 projected)
{
    worldPos=LPWRecoveredDisplace(objectPosition,objectNormal,highQualityWaves);
    float3 p1=LPWRecoveredDisplace(objectPosition-float3(uv0.xy,uv1.x),objectNormal,highQualityWaves);
    float3 p2=LPWRecoveredDisplace(objectPosition-float3(uv0.zw,uv1.y),objectNormal,highQualityWaves);
    faceNormal=normalize(cross(p1-worldPos,p2-worldPos));
    clipPosition=mul(UNITY_MATRIX_VP,float4(worldPos,1));
    projected.xy=0.5*(float2(clipPosition.x,clipPosition.y*_ProjectionParams.x)+clipPosition.w);
    projected.z=lerp(clipPosition.w,mul(UNITY_MATRIX_V,float4(worldPos,1)).z,unity_OrthoParams.w);
    projected.w=clipPosition.w;
}
float3 LPWRecoveredAmbient(float3 n)
{
    float4 quadratic=n.yzzx*n.xyzz;
    float3 sh=float3(dot(unity_SHAr,float4(n,1)),dot(unity_SHAg,float4(n,1)),dot(unity_SHAb,float4(n,1)));
    sh+=float3(dot(unity_SHBr,quadratic),dot(unity_SHBg,quadratic),dot(unity_SHBb,quadratic));
    sh+=unity_SHC.rgb*(n.x*n.x-n.y*n.y);
    // Source gamma-space variant explicitly includes this conversion.
    return max(1.055*pow(max(sh,0),0.416667)-0.055,0);
}
float4 LPWRecoveredHighFragment(float3 worldPos,float3 n,float4 projected)
{
    float2 uv=worldPos.xz/_BumpScale_;
    float4 a=tex2D(_BumpTex,uv+_BumpSpeed*_Time.x);
    float4 b=tex2D(_BumpTex,uv+_BumpSpeed*float2(1-_Time.x,-_Time.x));
    float2 distortion=((float2(a.x*a.a,a.y)*2-1)+(float2(b.x*b.a,b.y)*2-1))*0.5;
    float ortho=unity_OrthoParams.w;
    float offsetScale=lerp(1.0,1.0/unity_OrthoParams.x,ortho);
    distortion*=lerp(projected.w*0.1,1.0,ortho)*_Distortion;
    float2 reflectUV=(projected.xy+(distortion+n.xz*_NormalOffset)*offsetScale)/projected.w;
    float3 reflected=tex2D(_ReflectionTex,reflectUV).rgb;
    float3 ambient=LPWRecoveredAmbient(n);
    float3 fresnelReflection=lerp(ambient,reflected,saturate(_Reflection))+_FresColor.rgb*ambient;
    float rawDepth=tex2D(_CameraDepthTexture,projected.xy/projected.w).r;
    float eyeDepth=1.0/(_ZBufferParams.z*rawDepth+_ZBufferParams.w);
    float orthoDepth=(1.0-rawDepth)*(_ProjectionParams.y-_ProjectionParams.z)-_ProjectionParams.y;
    float thickness=(lerp(eyeDepth,orthoDepth,ortho)-projected.z)*(1.0-2.0*ortho);
    float4 absorptionColor=lerp(float4(_Color.rgb,_Opacity),_DeepColor,saturate(thickness/_Absorption));
    float3 water=lerp(absorptionColor.rgb,reflected,saturate(_Reflection-1.0));
    float diffuse=0.5+_Diffuse*(max(dot(n,_Sun),0.0)-0.5);
    float3 lit=water*(ambient+diffuse*_SunColor.rgb);
    float3 view=normalize(_WorldSpaceCameraPos-worldPos);
    float fresnel=pow(tex2Dlod(_FresnelTex,float4(saturate(dot(view,n)),0.5,0,0)).a,_FresPower);
    float3 rgb=lerp(lit,fresnelReflection,fresnel);
    float specular=pow(max(dot(n,normalize(view+_Sun)),0.0),_Specular);
    rgb+=_SpecColor.rgb*specular;
    float alpha=saturate(fresnel+absorptionColor.a+specular);
    float foamT=saturate((thickness/_ShoreDistance-_ShoreIntensity)/(1.0-_ShoreIntensity));
    foamT=foamT*foamT*(3.0-2.0*foamT);
    rgb=lerp(lerp(rgb,_ShoreColor.rgb,_ShoreColor.a),rgb,foamT);
    alpha=lerp(max(alpha,_ShoreColor.a),alpha,foamT);
    return float4(rgb,alpha);
}

// LOW and MED recover their original vertex-lit path. LOW has no distortion;
// MED adds exactly the same two-sample distortion as HIGH. Neither has LPW_FOAM.
void LPWRecoveredVertexLighting(float3 worldPos,float3 n,out float4 litFresnel,out float4 ambientSpecular)
{
    float3 ambient=LPWRecoveredAmbient(n);
    litFresnel.rgb=ambient+(0.5+_Diffuse*(max(dot(n,_Sun),0)-0.5))*_SunColor.rgb;
    float3 view=normalize(_WorldSpaceCameraPos-worldPos);
    litFresnel.a=pow(tex2Dlod(_FresnelTex,float4(saturate(dot(view,n)),0.5,0,0)).a,_FresPower);
    ambientSpecular.rgb=ambient;
    ambientSpecular.a=pow(max(dot(n,normalize(view+_Sun)),0),_Specular);
}
float4 LPWRecoveredVertexLitFragment(float3 worldPos,float3 n,float4 projected,
                                    float4 litFresnel,float4 ambientSpecular,bool distortionEnabled)
{
    float2 distortion=0;
    if(distortionEnabled)
    {
        float2 uv=worldPos.xz/_BumpScale_;
        float4 a=tex2D(_BumpTex,uv+_BumpSpeed*_Time.x);
        float4 b=tex2D(_BumpTex,uv+_BumpSpeed*float2(1-_Time.x,-_Time.x));
        distortion=((float2(a.x*a.a,a.y)*2-1)+(float2(b.x*b.a,b.y)*2-1))*0.5;
        distortion*=lerp(projected.w*0.1,1.0,unity_OrthoParams.w)*_Distortion;
    }
    float offsetScale=lerp(1.0,1.0/unity_OrthoParams.x,unity_OrthoParams.w);
    float2 reflectUV=(projected.xy+(distortion+n.xz*_NormalOffset)*offsetScale)/projected.w;
    float3 reflected=tex2D(_ReflectionTex,reflectUV).rgb;
    float rawDepth=tex2D(_CameraDepthTexture,projected.xy/projected.w).r;
    float eyeDepth=1.0/(_ZBufferParams.z*rawDepth+_ZBufferParams.w);
    float orthoDepth=(1.0-rawDepth)*(_ProjectionParams.y-_ProjectionParams.z)-_ProjectionParams.y;
    float thickness=(lerp(eyeDepth,orthoDepth,unity_OrthoParams.w)-projected.z)*(1.0-2.0*unity_OrthoParams.w);
    float4 water=lerp(float4(_Color.rgb,_Opacity),_DeepColor,saturate(thickness/_Absorption));
    water.rgb=lerp(water.rgb,reflected,saturate(_Reflection-1.0));
    float3 fresnelReflection=lerp(ambientSpecular.rgb,reflected,saturate(_Reflection))+_FresColor.rgb*ambientSpecular.rgb;
    return float4(lerp(water.rgb*litFresnel.rgb,fresnelReflection,litFresnel.a)+_SpecColor.rgb*ambientSpecular.a,
                  saturate(water.a+litFresnel.a+ambientSpecular.a));
}
