// Evidence-based reconstruction; original DXBC and render states in Recovery/shaders.
Shader "RCCSkidmarks" {
 Properties { _MainTex ("Base (RGB) Trans (A)",2D)="white"{} _Color ("Main Color",Color)=(1,1,1,1) }
 SubShader { Tags {"Queue"="Transparent" "RenderType"="Transparent" "IgnoreProjector"="True"}
 Pass { Blend SrcAlpha OneMinusSrcAlpha ZWrite Off Cull Back Offset -4,-4
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

 float4 _Color;sampler2D _MainTex;float4 _MainTex_ST;
 struct app {float4 vertex:POSITION;float4 color:COLOR;float2 uv:TEXCOORD0;};
 struct v2f {float4 pos:SV_POSITION;float4 color:COLOR;float2 uv:TEXCOORD0;float fog:TEXCOORD1;};
 v2f vert(app v){v2f o;o.pos=UnityObjectToClipPos(v.vertex);o.color=saturate(v.color);o.uv=TRANSFORM_TEX(v.uv,_MainTex);o.fog=RecoveryFog(v.vertex);return o;}
 float4 frag(v2f i):SV_Target {float4 c=tex2D(_MainTex,i.uv)*_Color;c.a*=i.color.a;if(c.a<=0)discard;c.rgb*=saturate(i.fog);return c;}
 ENDCG
 }}
}
