import UnityPy,json,hashlib,pathlib
root=pathlib.Path(r'D:\Games\CartoonRacerRecon'); out=root/'Recovery/terrain-check'
e=UnityPy.load(r'C:\Program Files (x86)\GameTop.com\Cartoon Hot Racer 3D\Cartoon Hot Racer 3D_Data\data.unity3d'); objects=list(e.objects); files={o.assets_file.name:o.assets_file for o in objects}
audit=json.loads((out/'editor-terrain-audit.json').read_text()); rows=[]
def resolve(owner,p):
 f=owner.assets_file if p['m_FileID']==0 else files[owner.assets_file.externals[p['m_FileID']-1].path.split('/')[-1]]
 return f.objects[p['m_PathID']]
def img(o):
 im=o.read().image.convert('RGBA');return {'size':list(im.size),'sha256':hashlib.sha256(im.tobytes()).hexdigest()}
for o in objects:
 if o.type.name!='TerrainData':continue
 t=o.read_typetree(); name=t['m_Name'];s=t['m_SplatDatabase'];current=next(x for x in audit['terrains'] if x['name']==name); diffs=[]
 for i,(src,dst) in enumerate(zip(s['m_Splats'],current['layerData'])):
  tex=resolve(o,src['texture']).read().m_Name
  if pathlib.Path(dst['diffuse']).stem!=tex:diffs.append({'layer':i,'textureSource':tex,'target':dst['diffuse']})
  for k in ('tileSize','tileOffset','smoothness'):
   if src[k]!=dst[k]:diffs.append({'layer':i,'field':k,'source':src[k],'target':dst[k]})
  if src['normalMap']['m_PathID']!=0 or dst['normal'] or any(src['specularMetallic'].values()) or dst['metallic'] or any(dst['specular'].values()):diffs.append({'layer':i,'otherParameters':'requires inspection'})
 env=UnityPy.load(str(root/current['path']));td=next(x for x in env.objects if x.type.name=='TerrainData'); target=td.read_typetree()['m_SplatDatabase']['m_AlphaTextures'];maps=[]
 for i,p in enumerate(s['m_AlphaTextures']):
  a=img(resolve(o,p));q=td.assets_file.objects.get(target[i]['m_PathID']);b=img(q) if q else None
  maps.append({'index':i,'sourceIdentity':o.assets_file.name+':'+str(p['m_PathID']),'source':a,'target':b,'equal':a==b})
 rows.append({'terrain':name,'sourceIdentity':o.assets_file.name+':'+str(o.path_id),'sourceLayerCount':len(s['m_Splats']),'targetLayerCount':current['layers'],'layerDifferences':diffs,'paintMaps':maps})
(out/'source-comparison.json').write_text(json.dumps(rows,indent=2));print(json.dumps([{'terrain':r['terrain'],'layerDifferences':r['layerDifferences'],'paintMapsEqual':[x['equal'] for x in r['paintMaps']]} for r in rows],indent=2))
