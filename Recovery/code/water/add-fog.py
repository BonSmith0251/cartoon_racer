import pathlib
p=pathlib.Path(r'D:\Games\CartoonRacerRecon\Recovery\code\water\make-wrapper.py')
s=p.read_text(encoding='utf-8-sig').replace('#pragma target 4.0','#pragma target 4.0\n  #pragma multi_compile __ FOG_LINEAR')
s=s.replace('float4 litFresnel:TEXCOORD3; float4 ambientSpecular:TEXCOORD4;','float4 litFresnel:TEXCOORD3; float4 ambientSpecular:TEXCOORD4; float fogClipZ:TEXCOORD5;')
s=s.replace('    return o;','    o.fogClipZ=o.pos.z;\n    return o;')
s=s.replace('return LPWRecoveredVertexLitFragment(i.world,i.normal,i.projected,i.litFresnel,i.ambientSpecular,distort);','float4 result=LPWRecoveredVertexLitFragment(i.world,i.normal,i.projected,i.litFresnel,i.ambientSpecular,distort);')
s=s.replace('return LPWRecoveredHighFragment(i.world,i.normal,i.projected);','float4 result=LPWRecoveredHighFragment(i.world,i.normal,i.projected);')
s=s.replace('    #endif\n  }\n  ENDCG','    #endif\n    #if defined(FOG_LINEAR)\n    float fogDistance=max((1.0-i.fogClipZ/_ProjectionParams.y)*_ProjectionParams.z,0.0);\n    float fogFactor=saturate(fogDistance*unity_FogParams.z+unity_FogParams.w);\n    result.rgb=lerp(unity_FogColor.rgb,result.rgb,fogFactor);\n    #endif\n    return result;\n  }\n  ENDCG')
p.write_text(s,encoding='utf-8')
