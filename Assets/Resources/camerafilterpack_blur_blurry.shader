// Reconstructed from original D3D11 instructions; see Recovery/shaders.
Shader "CameraFilterPack/Blur_Blurry" {
 Properties { _MainTex ("Base (RGB)",2D)="white"{} }
 SubShader { Cull Off ZWrite Off ZTest Always Pass { CGPROGRAM
 #pragma vertex vert_img
 #pragma fragment frag
 #include "UnityCG.cginc"
 sampler2D _MainTex;float4 _MainTex_ST,_ScreenResolution;float _Amount,_Value,_Value2,_Value3;
 float4 frag(v2f_img i):SV_Target {float2 uv=i.uv*_MainTex_ST.xy+_MainTex_ST.zw;float2 stepUV=.5*_Amount/_ScreenResolution.xy;float3 sum=0;[unroll]for(int x=-1;x<=1;x++){[unroll]for(int y=-1;y<=1;y++){float w=(x==0?2:1)*(y==0?2:1);sum+=tex2D(_MainTex,uv+float2(x,y)*stepUV).rgb*w;}}return float4(sum/16,1);}
 ENDCG
 }}
}
