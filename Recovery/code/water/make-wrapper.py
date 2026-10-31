import pathlib
root=pathlib.Path(r'D:\Games\CartoonRacerRecon');out=root/'Recovery/code/water'
s=(root/'Recovery/shaders/LowPolyWater_Advanced.compiled.txt').read_text();header=s[s.index('Shader "LowPolyWater/Advanced"'):s.index('SubShader {')]
body='''SubShader
{
 LOD 200
 Tags { "IgnoreProjector"="true" "Queue"="AlphaTest+51" "RenderType"="Transparent" }
 Pass
 {
  Tags { "LightMode"="ForwardBase" }
  Blend SrcAlpha OneMinusSrcAlpha
  ZWrite [_ZWrite]
  Cull [_Cull_]
  CGPROGRAM
  #pragma target 4.0
  #pragma multi_compile __ FOG_LINEAR
  #pragma vertex vert
  #pragma fragment frag
  #pragma shader_feature _SHADING_VERTEXLIT _SHADING_PIXELLIT
  #pragma shader_feature _WAVES_OFF _WAVES_HIGHQUALITY
  #pragma shader_feature __ _DISTORT_ON
  #include "UnityCG.cginc"
  sampler2D _NoiseTex, _BumpTex, _ReflectionTex, _CameraDepthTexture, _FresnelTex;
  float _Scale_,_TexSize_,_RSpeed_,_RHeight_,_Height_,_Length,_Stretch,_Speed_;
  float4 _Direction_;
  float _BumpScale_,_BumpSpeed,_Distortion,_NormalOffset,_Reflection;
  float _Absorption,_Opacity,_Diffuse,_FresPower,_Specular,_ShoreDistance,_ShoreIntensity;
  float3 _Sun;
  float4 _Color,_DeepColor,_FresColor,_SunColor,_SpecColor,_ShoreColor;
  #include "LowPolyWaterHighRecovered.cginc"
  struct appdata { float4 vertex:POSITION; float3 normal:NORMAL; float4 uv:TEXCOORD0; float2 uv2:TEXCOORD1; };
  struct v2f {
    float4 pos:SV_POSITION; float3 world:TEXCOORD0; float3 normal:TEXCOORD1; float4 projected:TEXCOORD2;
    float4 litFresnel:TEXCOORD3; float4 ambientSpecular:TEXCOORD4; float fogClipZ:TEXCOORD5;
  };
  v2f vert(appdata v)
  {
    v2f o;
    #if defined(_WAVES_HIGHQUALITY)
    const bool highQualityWaves=true;
    #else
    const bool highQualityWaves=false;
    #endif
    LPWRecoveredCustomVertex(v.vertex.xyz,v.normal,v.uv,v.uv2,highQualityWaves,o.world,o.normal,o.pos,o.projected);
    #if defined(_SHADING_VERTEXLIT)
    LPWRecoveredVertexLighting(o.world,o.normal,o.litFresnel,o.ambientSpecular);
    #else
    o.litFresnel=0;o.ambientSpecular=0;
    #endif
    o.fogClipZ=o.pos.z;
    return o;
  }
  float4 frag(v2f i):SV_Target
  {
    #if defined(_SHADING_VERTEXLIT)
      #if defined(_DISTORT_ON)
      const bool distort=true;
      #else
      const bool distort=false;
      #endif
      float4 result=LPWRecoveredVertexLitFragment(i.world,i.normal,i.projected,i.litFresnel,i.ambientSpecular,distort);
    #else
      float4 result=LPWRecoveredHighFragment(i.world,i.normal,i.projected);
    #endif
    #if defined(FOG_LINEAR)
    float fogDistance=max((1.0-i.fogClipZ/_ProjectionParams.y)*_ProjectionParams.z,0.0);
    float fogFactor=saturate(fogDistance*unity_FogParams.z+unity_FogParams.w);
    result.rgb=lerp(unity_FogColor.rgb,result.rgb,fogFactor);
    #endif
    return result;
  }
  ENDCG
 }
}
Fallback Off
}
'''
(out/'LowPolyWaterAdvancedRecovered.shader').write_text('// Recovered from original D3D11 material variants. See water-recovery-report.md for exact scope.\n'+header+body)
print('Wrapper ready',out/'LowPolyWaterAdvancedRecovered.shader')
