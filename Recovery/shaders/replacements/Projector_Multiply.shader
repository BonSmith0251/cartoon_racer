// Evidence-based reconstruction; original DXBC and render states in Recovery/shaders.
Shader "Projector/Multiply" {
 Properties { _Color ("Main Color",Color)=(1,1,1,1) _ShadowTex ("Cookie",2D)="gray"{} _FalloffTex ("FallOff",2D)="white"{} }
 SubShader {Tags {"Queue"="Transparent"} Pass {
 ZWrite Off ColorMask RGB Offset -1,-1 Blend DstColor Zero
 CGPROGRAM
 #pragma vertex vert
 #pragma fragment frag
 #pragma multi_compile_fog
 #include "UnityCG.cginc"
float RecoveryFog(float4 vertex) {
 float d=length(UnityObjectToViewPos(vertex));
 #if defined(FOG_LINEAR)
 return saturate(d*unity_FogParams.z+unity_FogParams.w);
 #elif defined(FOG_EXP)
 return saturate(exp2(-unity_FogParams.y*d));
 #elif defined(FOG_EXP2)
 return saturate(exp2(-pow(unity_FogParams.x*d,2)));
 #else
 return 1;
 #endif
}

 float4x4 unity_Projector,unity_ProjectorClip;sampler2D _ShadowTex,_FalloffTex;float4 _Color;
 struct v2f{float4 pos:SV_POSITION;float4 uv:TEXCOORD0;float4 falloff:TEXCOORD1;float fog:TEXCOORD2;};
 v2f vert(float4 vertex:POSITION){v2f o;o.pos=UnityObjectToClipPos(vertex);o.uv=mul(unity_Projector,vertex);o.falloff=mul(unity_ProjectorClip,vertex);o.fog=RecoveryFog(vertex);return o;}
 float4 frag(v2f i):SV_Target{float4 t=tex2Dproj(_ShadowTex,UNITY_PROJ_COORD(i.uv));float f=tex2Dproj(_FalloffTex,UNITY_PROJ_COORD(i.falloff)).a;return float4(lerp(float3(1,1,1),t.rgb,f*saturate(i.fog)),(1-t.a)*f);}
 ENDCG
 }}
}
