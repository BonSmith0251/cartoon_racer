import pathlib,json
root=pathlib.Path(__file__).parent
out=root/'replacements';out.mkdir(exist_ok=True)
common='''#include "UnityCG.cginc"
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
'''
particle='''Shader "Cartoon FX/Mobile Particles Additive Alpha8" {
 Properties { _MainTex ("Particle Texture (Alpha8)",2D)="white"{} }
 SubShader { Tags {"Queue"="Transparent" "RenderType"="Transparent" "IgnoreProjector"="True"}
 Pass { Blend SrcAlpha One ZWrite Off Cull Off
 CGPROGRAM
 #pragma vertex vert
 #pragma fragment frag
 #pragma multi_compile_fog
 COMMON
 sampler2D _MainTex;float4 _MainTex_ST;
 struct app {float4 vertex:POSITION;float4 color:COLOR;float2 uv:TEXCOORD0;};
 struct v2f {float4 pos:SV_POSITION;float4 color:COLOR;float2 uv:TEXCOORD0;float fog:TEXCOORD1;};
 v2f vert(app v){v2f o;o.pos=UnityObjectToClipPos(v.vertex);o.color=saturate(v.color);o.uv=TRANSFORM_TEX(v.uv,_MainTex);o.fog=RecoveryFog(v.vertex);return o;}
 float4 frag(v2f i):SV_Target {return float4(i.color.rgb*saturate(i.fog),i.color.a*tex2D(_MainTex,i.uv).a);}
 ENDCG
 }}
}'''.replace('COMMON',common)
skid=particle.replace('Cartoon FX/Mobile Particles Additive Alpha8','RCCSkidmarks').replace('_MainTex ("Particle Texture (Alpha8)",2D)="white"{}','_MainTex ("Base (RGB) Trans (A)",2D)="white"{} _Color ("Main Color",Color)=(1,1,1,1)').replace('Blend SrcAlpha One ZWrite Off Cull Off','Blend SrcAlpha OneMinusSrcAlpha ZWrite Off Cull Back Offset -4,-4').replace('sampler2D _MainTex;','float4 _Color;sampler2D _MainTex;').replace('return float4(i.color.rgb*saturate(i.fog),i.color.a*tex2D(_MainTex,i.uv).a);','float4 c=tex2D(_MainTex,i.uv)*_Color;c.a*=i.color.a;if(c.a<=0)discard;c.rgb*=saturate(i.fog);return c;')
projector='''Shader "Projector/NAME" {
 Properties { _Color ("Main Color",Color)=(1,1,1,1) _ShadowTex ("Cookie",2D)="gray"{} _FalloffTex ("FallOff",2D)="white"{} }
 SubShader {Tags {"Queue"="Transparent"} Pass {
 ZWrite Off ColorMask RGB Offset -1,-1 Blend DstColor DEST
 CGPROGRAM
 #pragma vertex vert
 #pragma fragment frag
 #pragma multi_compile_fog
 COMMON
 float4x4 unity_Projector,unity_ProjectorClip;sampler2D _ShadowTex,_FalloffTex;float4 _Color;
 struct v2f{float4 pos:SV_POSITION;float4 uv:TEXCOORD0;float4 falloff:TEXCOORD1;float fog:TEXCOORD2;};
 v2f vert(float4 vertex:POSITION){v2f o;o.pos=UnityObjectToClipPos(vertex);o.uv=mul(unity_Projector,vertex);o.falloff=mul(unity_ProjectorClip,vertex);o.fog=RecoveryFog(vertex);return o;}
 float4 frag(v2f i):SV_Target{float4 t=tex2Dproj(_ShadowTex,UNITY_PROJ_COORD(i.uv));float f=tex2Dproj(_FalloffTex,UNITY_PROJ_COORD(i.falloff)).a;BODY}
 ENDCG
 }}
}'''.replace('COMMON',common)
sprite='''Shader "Sprites/Default with Fog" {
 Properties { [PerRendererData] _MainTex ("Sprite Texture",2D)="white"{} _Color ("Tint",Color)=(1,1,1,1) [MaterialToggle] PixelSnap ("Pixel snap",Float)=0 [HideInInspector] _RendererColor ("RendererColor",Color)=(1,1,1,1) [HideInInspector] _Flip ("Flip",Vector)=(1,1,1,1) [PerRendererData] _AlphaTex ("External Alpha",2D)="white"{} [PerRendererData] _EnableExternalAlpha ("Enable External Alpha",Float)=0 }
 SubShader {Tags {"Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent" "PreviewType"="Plane" "CanUseSpriteAtlas"="True"}
 Cull Off Lighting Off ZWrite Off Blend One OneMinusSrcAlpha
 Pass { CGPROGRAM
 #pragma vertex vert
 #pragma fragment frag
 #pragma multi_compile_fog
 #pragma multi_compile _ PIXELSNAP_ON
 #pragma multi_compile _ ETC1_EXTERNAL_ALPHA
 #pragma multi_compile_instancing
 COMMON
 #include "UnitySprites.cginc"
 struct output {v2f sprite;float fog:TEXCOORD2;};
 output vert(appdata_t v){output o;o.sprite=SpriteVert(v);o.fog=RecoveryFog(v.vertex);return o;}
 fixed4 frag(output i):SV_Target{fixed4 c=SampleSpriteTexture(i.sprite.texcoord)*i.sprite.color;c.rgb=lerp(unity_FogColor.rgb,c.rgb,saturate(i.fog));c.rgb*=c.a;return c;}
 ENDCG
 }}
}'''.replace('COMMON',common)
blur='''Shader "Custom/BLUR" {
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
}'''
files={'Cartoon FX_Mobile Particles Additive Alpha8.shader':particle,'RCCSkidmarks.shader':skid,'Projector_Light.shader':projector.replace('NAME','Light').replace('DEST','One').replace('BODY','return float4(t.rgb*_Color.rgb*f*saturate(i.fog),(1-t.a)*f);'),'Projector_Multiply.shader':projector.replace('NAME','Multiply').replace('DEST','Zero').replace('BODY','return float4(lerp(float3(1,1,1),t.rgb,f*saturate(i.fog)),(1-t.a)*f);'),'Sprites_Default with Fog.shader':sprite,'Custom_BLUR.shader':blur}
for name,text in files.items():(out/name).write_text('// Evidence-based reconstruction; original DXBC and render states in Recovery/shaders.\n'+text+'\n',encoding='utf-8')
(root/'replacement-status.json').write_text(json.dumps({'status':'evidence-based reconstruction, pending Unity compilation and visual comparison','files':list(files),'evidence':'DXBC disassembly and serialized rtBlend0/depth/cull/tags from original source shader objects','boundaries':['Fog uses source radial eye distance; target compiler produces new variants.','Sprites use target UnitySprites helper for platform/instancing handling.','Source authoring shader text not recovered.','Remaining exported custom shaders still dummy until separately repaired.']},indent=2),encoding='utf-8')
print('Prepared '+str(len(files))+' shader replacements')
