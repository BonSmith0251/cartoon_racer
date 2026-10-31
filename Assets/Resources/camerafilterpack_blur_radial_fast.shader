// Reconstructed from original D3D11 instructions; see Recovery/shaders.
Shader "CameraFilterPack/Blur_Radial_Fast" {
 Properties { _MainTex ("Base (RGB)",2D)="white"{} }
 SubShader { Cull Off ZWrite Off ZTest Always Pass { CGPROGRAM
 #pragma vertex vert_img
 #pragma fragment frag
 #include "UnityCG.cginc"
 sampler2D _MainTex;float4 _MainTex_ST,_ScreenResolution;float _Amount,_Value,_Value2,_Value3;
 float4 frag(v2f_img i):SV_Target {float2 uv=i.uv*_MainTex_ST.xy+_MainTex_ST.zw;float2 center=float2(_Value2,_Value3);float2 d=uv-center;return (tex2D(_MainTex,uv)+tex2D(_MainTex,center+d*(1+_Value*.2))+tex2D(_MainTex,center+d*(1+_Value*.4))+tex2D(_MainTex,center+d*(1+_Value*.8)))*.25;}
 ENDCG
 }}
}
