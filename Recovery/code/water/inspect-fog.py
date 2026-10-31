import json,pathlib,re,ast
root=pathlib.Path(r'D:\Games\CartoonRacerRecon');out=root/'Recovery/code/water'
d=json.loads((root/'Recovery/shaders/LowPolyWater_Advanced.parsed.json').read_text());p=d['m_SubShaders'][0]['m_Passes'][0];names={idx:n for n,idx in p['m_NameIndices']}
txt=(root/'Recovery/shaders/LowPolyWater_Advanced.compiled.txt').read_text();blocks=re.findall(r'SubProgram "[^"\n]+" \{\s*/\* Keywords (.*?) \*/(.*?)\x00\s*\}',txt,re.S)
for stage in ['progVertex','progFragment']:
 for i,sp in enumerate(p[stage]['m_SubPrograms']):
  kw=[names[x] for x in sp['m_KeywordIndices']]
  if set(kw)==set(['DIRECTIONAL','FOG_LINEAR','LPW_FOAM','WATER_REFLECTIVE','_CUSTOM_SHAPE','_DISTORT_ON','_LIGHTABS_ON','_SHADING_PIXELLIT','_WAVES_OFF']):
   asm=blocks[i+(72 if stage=='progFragment' else 0)][1];(out/('high-fog-'+stage+'.asm.txt')).write_text(asm);print(stage,i,asm[-1900:])
