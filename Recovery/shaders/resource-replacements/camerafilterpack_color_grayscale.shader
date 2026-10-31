// Reconstructed from original DXBC: dot RGB with (.222,.707,.071), lerp by _Fade, output alpha1.
Shader "CameraFilterPack/Color_GrayScale" {
 Properties { _MainTex ("Base (RGB)",2D)="white"{} }
 SubShader { Cull Off ZWrite Off ZTest Always Pass {
 CGPROGRAM
 #pragma vertex vert_img
 #pragma fragment frag
 #include "UnityCG.cginc"
 sampler2D _MainTex;float4 _MainTex_ST;float _Fade;
 float4 frag(v2f_img i):SV_Target {float3 c=tex2D(_MainTex,i.uv*_MainTex_ST.xy+_MainTex_ST.zw).rgb;float gray=dot(c,float3(.222,.707,.071));return float4(lerp(c,float3(gray,gray,gray),_Fade),1);}
 ENDCG
 }}
}
