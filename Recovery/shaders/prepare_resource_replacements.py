import pathlib,json
root=pathlib.Path(__file__).parent
out=root/'resource-replacements';out.mkdir(exist_ok=True)
template='''// Reconstructed from original D3D11 instructions; see Recovery/shaders.
Shader "NAME" {
 Properties { _MainTex ("Base (RGB)",2D)="white"{} }
 SubShader { Cull Off ZWrite Off ZTest Always Pass { CGPROGRAM
 #pragma vertex vert_img
 #pragma fragment frag
 #include "UnityCG.cginc"
 sampler2D _MainTex;float4 _MainTex_ST,_ScreenResolution;float _Amount,_Value,_Value2,_Value3;
 float4 frag(v2f_img i):SV_Target {float2 uv=i.uv*_MainTex_ST.xy+_MainTex_ST.zw;BODY}
 ENDCG
 }}
}'''
files={
'camerafilterpack_blur_blurry.shader':template.replace('NAME','CameraFilterPack/Blur_Blurry').replace('BODY','float2 stepUV=.5*_Amount/_ScreenResolution.xy;float3 sum=0;[unroll]for(int x=-1;x<=1;x++){[unroll]for(int y=-1;y<=1;y++){float w=(x==0?2:1)*(y==0?2:1);sum+=tex2D(_MainTex,uv+float2(x,y)*stepUV).rgb*w;}}return float4(sum/16,1);'),
'camerafilterpack_blur_radial_fast.shader':template.replace('NAME','CameraFilterPack/Blur_Radial_Fast').replace('BODY','float2 center=float2(_Value2,_Value3);float2 d=uv-center;return (tex2D(_MainTex,uv)+tex2D(_MainTex,center+d*(1+_Value*.2))+tex2D(_MainTex,center+d*(1+_Value*.4))+tex2D(_MainTex,center+d*(1+_Value*.8)))*.25;')}
for name,text in files.items():(out/name).write_text(text+'\n',encoding='utf-8')
(root/'resource-replacement-status.json').write_text(json.dumps({'status':'evidence-based reconstruction, target validation pending','files':list(files),'evidence':'original DXBC + m_NameIndices/constant buffers; Blurry 3x3 [1,2,1] Gaussian; Radial four samples scales 1,1+.2v,1+.4v,1+.8v'},indent=2),encoding='utf-8')
print(list(files))
