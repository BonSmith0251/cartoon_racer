// Recovered from original D3D11 material variants. See water-recovery-report.md for exact scope.
Shader "LowPolyWater/Advanced" {
Properties {

_Shadow ("Shadow Bias", Range(0, 1)) = 0.699999988079071

_Color ("Color", Color) = (0,0.5,0.7,1)

_Opacity ("Opacity", Range(0, 1)) = 0.699999988079071

_Specular ("Specular", Range(1, 300)) = 70.0

_SpecColor ("Sun Color", Color) = (0.703,0.676,0.438,1)

_Diffuse ("Diffuse", Range(0, 1)) = 0.5

[Toggle] _PointLights ("Enable Point Lights", Float) = 0.0

[KeywordEnum(Flat, VertexLit, PixelLit)] _Shading ("Shading", Float) = 0.0

_FresnelTex ("Fresnel (A) ", 2D) = "" { }

_FresPower ("Fresnel Exponent", Range(0, 2)) = 1.5

_FresColor ("Fresnel Color", Color) = (0.305,0.371,0.395,1)

_Reflection ("Reflection", Range(0, 2)) = 1.2000000476837158

_Refraction ("Refractive Distortion", Float) = 2.0

_NormalOffset ("Normal Offset", Range(0, 5)) = 1.0

[Toggle] _Distort ("Enable Distortion", Float) = 0.0

_Distortion ("Reflective Distortion", Float) = 1.0

_BumpTex ("Distortion Map", 2D) = "" { }

_BumpScale ("Distortion Scale", Float) = 35.0

_BumpSpeed ("Distortion Speed", Float) = 0.20000000298023224

[KeywordEnum(Off, LowQuality, HighQuality)] _Waves ("Enable Waves", Float) = 2.0

_Length ("Wave Length", Float) = 4.0

_Stretch ("Wave Stretch", Float) = 10.0

_Speed ("Wave Speed", Float) = 0.5

_Height ("Wave Height", Float) = 0.5

_Steepness ("Wave Steepness", Range(0, 1)) = 0.20000000298023224

_Direction ("Wave Direction", Range(0, 360)) = 180.0

_RSpeed ("Ripple Speed", Float) = 1.0

_RHeight ("Ripple Height", Float) = 0.25

[Toggle] _EdgeBlend ("Enable Foam", Float) = 0.0

_ShoreColor ("Foam Color", Color) = (1,1,1,1)

_ShoreIntensity ("Foam Intensity", Range(-1, 1)) = 1.0

_ShoreDistance ("Foam Distance", Float) = 0.5

[Toggle] _HQFoam ("Enable HQ Foam", Float) = 0.0

_FoamScale ("Foam Scale", Float) = 20.0

_FoamSpeed ("Foam Speed", Float) = 0.30000001192092896

_FoamSpread ("Foam Spread", Float) = 1.0

[Toggle] _LightAbs ("Enable Light Absorption", Float) = 0.0

_Absorption ("Depth Transparency", Float) = 5.0

_DeepColor ("Deep Water Color", Color) = (0,0.1,0.2,1)

_Scale ("Global Scale", Float) = 1.0

_NoiseTex ("Noise Texture (A)", 2D) = "" { }

[Toggle] _Cull ("Show Surface Underwater", Float) = 0.0

[Toggle] _ZWrite ("Write to Depth Buffer", Float) = 0.0

_TransformScale_ ("_TransformScale_", Float) = 1.0

_Scale_ ("_Scale_", Float) = 1.0

_BumpScale_ ("_BumpScale_", Float) = 1.0

_Cull_ ("_Cull_", Float) = 2.0

_Direction_ ("_Direction_", Vector) = (0,0,0,0)

_RHeight_ ("_RHeight_", Float) = 0.20000000298023224

_RSpeed_ ("_RSpeed_", Float) = 0.20000000298023224

_TexSize_ ("_TexSize_", Float) = 64.0

_Speed_ ("_Speed_", Float) = 0.0

_Height_ ("_Height_", Float) = 0.0

_ReflectionTex ("_ReflectionTex", 2D) = "" { }

_RefractionTex ("_RefractionTex", 2D) = "" { }

_Time_ ("_Time_", Float) = 0.0

_EnableShadows ("_EnableShadows", Float) = 0.0

_Sun ("_Sun", Vector) = (0,0,0,0)

_SunColor ("_SunColor", Color) = (1,1,1,1)

}
SubShader
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
