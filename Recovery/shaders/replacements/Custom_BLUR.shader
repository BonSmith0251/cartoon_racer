// Evidence-based reconstruction; original DXBC and render states in Recovery/shaders.
Shader "Custom/BLUR" {
 Properties { _Color ("Main Color",Color)=(1,1,1,1) _BumpAmt ("Distortion",Range(0,128))=10 _MainTex ("Tint Color (RGB)",2D)="white"{} _BumpMap ("Normalmap",2D)="bump"{} _Size ("Size",Range(0,2000))=1 }
 SubShader { Tags {"Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Opaque"}
 CGINCLUDE
 #include "UnityCG.cginc"
 sampler2D _GrabTexture,_MainTex,_BumpMap;float4 _GrabTexture_TexelSize,_MainTex_ST,_BumpMap_ST,_Color;float _Size,_BumpAmt;
 struct app {float4 vertex:POSITION;float2 uv:TEXCOORD0;};
 struct v2f {float4 pos:SV_POSITION;float4 grab:TEXCOORD0;float2 bump:TEXCOORD1;float2 uv:TEXCOORD2;};
 v2f vert(app v){v2f o;o.pos=UnityObjectToClipPos(v.vertex);o.grab=ComputeGrabScreenPos(o.pos);o.bump=TRANSFORM_TEX(v.uv,_BumpMap);o.uv=TRANSFORM_TEX(v.uv,_MainTex);return o;}
 float4 blur(v2f i,float2 axis){float2 uv=i.grab.xy/i.grab.w;float2 d=axis*_GrabTexture_TexelSize.xy*_Size/i.grab.w;return tex2D(_GrabTexture,uv-4*d)*.05+tex2D(_GrabTexture,uv-3*d)*.09+tex2D(_GrabTexture,uv-2*d)*.12+tex2D(_GrabTexture,uv-d)*.15+tex2D(_GrabTexture,uv)*.18+tex2D(_GrabTexture,uv+d)*.15+tex2D(_GrabTexture,uv+2*d)*.12+tex2D(_GrabTexture,uv+3*d)*.09+tex2D(_GrabTexture,uv+4*d)*.05;}
 float4 fragH(v2f i):SV_Target{return blur(i,float2(1,0));}
 float4 fragV(v2f i):SV_Target{return blur(i,float2(0,1));}
 float4 fragTint(v2f i):SV_Target{float2 n=UnpackNormal(tex2D(_BumpMap,i.bump)).xy;i.grab.xy+=n*_BumpAmt*_GrabTexture_TexelSize.xy*i.grab.z;return tex2Dproj(_GrabTexture,UNITY_PROJ_COORD(i.grab))*tex2D(_MainTex,i.uv)*_Color;}
 ENDCG
 GrabPass {}
 Pass {Tags {"LightMode"="Always"} CGPROGRAM
 #pragma vertex vert
 #pragma fragment fragH
 ENDCG }
 GrabPass {}
 Pass {Tags {"LightMode"="Always"} CGPROGRAM
 #pragma vertex vert
 #pragma fragment fragV
 ENDCG }
 GrabPass {}
 Pass {Tags {"LightMode"="Always"} CGPROGRAM
 #pragma vertex vert
 #pragma fragment fragTint
 ENDCG }
 }
}
