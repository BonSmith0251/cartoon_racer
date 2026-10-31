import pathlib,json,re,ast
root=pathlib.Path(r'D:\Games\CartoonRacerRecon'); out=root/'Recovery/code/water'; d=json.loads((root/'Recovery/shaders/LowPolyWater_Advanced.parsed.json').read_text());txt=(root/'Recovery/shaders/LowPolyWater_Advanced.compiled.txt').read_text()
blocks=re.findall(r'SubProgram "[^"\n]+" \{\s*/\* Keywords (.*?) \*/(.*?)\x00\s*\}',txt,re.S)
print('Blocks',len(blocks));position=0;selected=[];allrows=[]
for si,sub in enumerate(d['m_SubShaders'][:1]):
 for pi,p in enumerate(sub['m_Passes'][:1]):
  names={idx:name for name,idx in p['m_NameIndices']}
  print('pass',si,pi,p['m_Name'],p['m_Tags'],[(s,len(p[s]['m_SubPrograms'])) for s in ['progVertex','progFragment']])
  for stage in ['progVertex','progFragment']:
   for i,sp in enumerate(p[stage]['m_SubPrograms']):
    kw=[names[x] for x in sp['m_KeywordIndices']];bk,assembly=blocks[position];position+=1
    assert set(kw)==set(ast.literal_eval(bk)),(position,kw,bk)
    buffers=[]
    for j,cb in enumerate(sp['m_ConstantBuffers']):
     params=[]
     for param in cb['m_VectorParams']+cb['m_MatrixParams']:
      offset=param['m_Index'];params.append(dict(name=names[param['m_NameIndex']],offset=offset,register=f'cb{j}[{offset//16}]'+'.xyzw'[(offset%16)//4+1:] if False else f'cb{j}[{offset//16}].'+ 'xyzw'[(offset%16)//4],detail=param))
     buffers.append(dict(slot=j,name=names[cb['m_NameIndex']],params=params))
    row=dict(subshader=si,pass_index=pi,stage=stage,index=i,blob_index=sp['m_BlobIndex'],keywords=kw,constant_buffers=buffers,textures=[dict(name=names[x['m_NameIndex']],slot=x['m_Index'],sampler=x['m_SamplerIndex']) for x in sp['m_TextureParams']])
    allrows.append(row)
    if si==0 and pi==0 and set(kw)&{'LIGHTPROBE_SH','SHADOWS_SCREEN','FOG_LINEAR'}==set() and '_CUSTOM_SHAPE' in kw:
     label=('max' if '_WAVES_HIGHQUALITY' in kw else 'high' if '_SHADING_PIXELLIT' in kw else 'med' if '_DISTORT_ON' in kw else 'low')
     if 'WATER_REFLECTIVE' not in kw:continue
     base=label+'-'+stage
     (out/(base+'.asm.txt')).write_text(assembly,encoding='utf-8');(out/(base+'.bindings.json')).write_text(json.dumps(row,indent=2));selected.append(base)
(out/'variant-inventory.json').write_text(json.dumps(allrows,indent=2));print('Selected',selected)


