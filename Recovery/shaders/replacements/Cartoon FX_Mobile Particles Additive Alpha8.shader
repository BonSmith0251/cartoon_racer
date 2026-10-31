// Evidence-based reconstruction; original DXBC and render states in Recovery/shaders.
Shader "Cartoon FX/Mobile Particles Additive Alpha8" {
 Properties { _MainTex ("Particle Texture (Alpha8)",2D)="white"{} }
 SubShader { Tags {"Queue"="Transparent" "RenderType"="Transparent" "IgnoreProjector"="True"}
 Pass { Blend SrcAlpha One ZWrite Off Cull Off
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

 sampler2D _MainTex;float4 _MainTex_ST;
 struct app {float4 vertex:POSITION;float4 color:COLOR;float2 uv:TEXCOORD0;};
 struct v2f {float4 pos:SV_POSITION;float4 color:COLOR;float2 uv:TEXCOORD0;float fog:TEXCOORD1;};
 v2f vert(app v){v2f o;o.pos=UnityObjectToClipPos(v.vertex);o.color=saturate(v.color);o.uv=TRANSFORM_TEX(v.uv,_MainTex);o.fog=RecoveryFog(v.vertex);return o;}
 float4 frag(v2f i):SV_Target {return float4(i.color.rgb*saturate(i.fog),i.color.a*tex2D(_MainTex,i.uv).a);}
 ENDCG
 }}
}
