// Evidence-based reconstruction from the original two unique D3D11 fragment programs.
Shader "Water/Water 2D Waves" {
 Properties { _TopTex ("Top Texture",2D)="white"{} _MainTex ("Main Texture",2D)="white"{} _Color ("Color",Color)=(1,1,1,.5) _Current ("Current Speed",Float)=-.25 _Wave ("Wave",Vector)=(1,.2,.5,.7) _Level ("Level",Range(0,1))=.5 _Trim ("Surface Trim",Range(0,1))=.9 }
 SubShader { Tags {"Queue"="Transparent" "IgnoreProjector"="True" "PreviewType"="Plane" "RenderType"="Transparent"}
 GrabPass {}
 Pass { Cull Off ZWrite Off Blend One OneMinusSrcAlpha
 CGPROGRAM
 #pragma vertex vert
 #pragma fragment frag
 #pragma multi_compile _ DISABLE_WAVES
 #pragma multi_compile _ DISABLE_REFRACTION
 #include "UnityCG.cginc"
 sampler2D _TopTex,_MainTex;float4 _MainTex_ST,_Color,_Wave;float _Current,_Level,_Trim;
 struct v2f{float4 pos:SV_POSITION;float2 uv:TEXCOORD0;};
 v2f vert(appdata_base v){v2f o;o.pos=UnityObjectToClipPos(v.vertex);o.uv=v.texcoord;return o;}
 float4 frag(v2f i):SV_Target{
 float x=i.uv.x+_Current*_Time.y;float y=i.uv.y;
 #if !defined(DISABLE_WAVES)
 float h=saturate((y-_Level)/(1-_Level));float wave=(sin((_Wave.x*x+_Wave.z*_Time.y)*6.28318)+1)*.5;
 if(_Wave.w>0&&_Wave.w<1)wave=pow(wave,_Wave.w);
 y+=h*h*wave*_Wave.y;
 #endif
 float2 uv=float2(x*_MainTex_ST.x*_MainTex_ST.y,y*_MainTex_ST.x-_MainTex_ST.x+1);
 float4 c;
 if(y>1-1/_MainTex_ST.x)c=uv.y>_Trim?float4(0,0,0,0):tex2D(_TopTex,uv);else c=tex2D(_MainTex,uv);
 c*=_Color;c.rgb*=c.a;return c;
 }
 ENDCG
 }}
}
