// Evidence-based reconstruction; original DXBC and render states in Recovery/shaders.
Shader "Sprites/Default with Fog" {
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

 #include "UnitySprites.cginc"
 struct output {v2f sprite;float fog:TEXCOORD2;};
 output vert(appdata_t v){output o;o.sprite=SpriteVert(v);o.fog=RecoveryFog(v.vertex);return o;}
 fixed4 frag(output i):SV_Target{fixed4 c=SampleSpriteTexture(i.sprite.texcoord)*i.sprite.color;c.rgb=lerp(unity_FogColor.rgb,c.rgb,saturate(i.fog));c.rgb*=c.a;return c;}
 ENDCG
 }}
}
