import collections, gzip, hashlib, json, pathlib, shutil, time, UnityPy
SRC=pathlib.Path(r'C:\Program Files (x86)\GameTop.com\Cartoon Hot Racer 3D')
OUT=pathlib.Path(r'D:\Games\CartoonRacerRecon\Recovery\extraction')
RAW=OUT/'raw-source'; SERIAL=OUT/'serialized'; SERIAL.mkdir(exist_ok=True)
shutil.copytree(SRC,RAW,dirs_exist_ok=True)
env=UnityPy.load(str(SRC/'Cartoon Hot Racer 3D_Data'/'data.unity3d'),str(SRC/'Cartoon Hot Racer 3D_Data'/'Resources'/'unity default resources'))
assets=env.assets
lookup=collections.defaultdict(list)
for f in assets: lookup[f.name.lower()].append(f)
counts=collections.Counter(); decoded=collections.Counter(); issues=[]; files=[]; refs=collections.Counter(); streams=[]
def write(h,x): h.write(json.dumps(x,separators=(',',':'),ensure_ascii=False,default=str)+'\n')
def walk(x,path=''):
 if isinstance(x,dict):
  if 'm_FileID' in x and 'm_PathID' in x: yield path,x
  else:
   for k,v in x.items(): yield from walk(v,path+'.'+k)
 elif isinstance(x,list):
  for i,v in enumerate(x): yield from walk(v,path+'['+str(i)+']')
with gzip.open(OUT/'objects.jsonl.gz','wt',encoding='utf-8') as oh,gzip.open(OUT/'references.jsonl.gz','wt',encoding='utf-8') as rh,gzip.open(OUT/'typetrees.jsonl.gz','wt',encoding='utf-8') as th:
 for f in assets:
  raw=f.reader.bytes
  dest=SERIAL/f.name; dest.write_bytes(raw)
  externals=[str(z.path) for z in f.externals]
  frec={'source':f.name,'version':str(f.unity_version),'objects':len(f.objects),'bytes':len(raw),'sha256':hashlib.sha256(raw).hexdigest(),'externals':externals,'raw':str(dest)}; files.append(frec)
  for o in f.objects.values():
   ident=f.name+':'+str(o.path_id); counts[o.type.name]+=1
   rec={'id':ident,'source':f.name,'path_id':str(o.path_id),'class_id':o.class_id,'type':o.type.name,'offset':o.byte_start,'size':o.byte_size,'raw':str(dest),'read':'unattempted','export_mapping':'AuxiliaryFiles/path_id_map.json'}
   try:
    tree=o.read_typetree(); rec['read']='pass'; rec['name']=tree.get('m_Name','');decoded[o.type.name]+=1
    write(th,{'id':ident,'tree':tree})
    for prop,p in walk(tree):
     fid=int(p['m_FileID']);pid=int(p['m_PathID']);r={'owner':ident,'property':prop,'file_id':fid,'path_id':str(pid)}
     if pid==0:r['outcome']='original-null'
     else:
      candidates=[f] if fid==0 else lookup.get(pathlib.PurePosixPath(externals[fid-1].replace('\\','/')).name.lower(),[]) if 0<fid<=len(externals) else []
      targets=[z for z in candidates if pid in z.objects]
      if len(targets)==1:r['outcome']='resolved';r['target']=targets[0].name+':'+str(pid)
      elif len(targets)>1:r['outcome']='ambiguous'
      else:r['outcome']='missing';r['external']=externals[fid-1] if 0<fid<=len(externals) else None
     refs[r['outcome']]+=1;write(rh,r)
    if o.type.name in ('Texture2D','AudioClip','Mesh'):
     for key in ('m_StreamData','m_Resource'):
      sd=tree.get(key)
      if isinstance(sd,dict):
       sp=sd.get('path',sd.get('m_Source',''));sz=sd.get('size',sd.get('m_Size',0));off=sd.get('offset',sd.get('m_Offset',0))
       if sp and sz: streams.append({'owner':ident,'path':sp,'offset':off,'size':sz})
   except Exception as ex:
    rec['read']='fail';rec['error']=str(ex);issues.append({'id':ident,'stage':'typetree','error':str(ex)})
   write(oh,rec)
  print('finished',f.name,len(f.objects),flush=True)
summary={'tool':'UnityPy','version':UnityPy.__version__,'source':str(SRC),'source_files':198,'source_bytes':127251656,'source_unchanged':'read-only source access; copied raw source','objects':sum(counts.values()),'types':dict(counts),'typetree_decoded':dict(decoded),'references':dict(refs),'serialized_files':files,'issues':issues,'streams':streams,'export':'pristine-export/ExportedProject','mapping':'pristine-export/AuxiliaryFiles/path_id_map.json','shader_provenance':'AssetRipper dummy shaders are approximate; compiled original bytes preserved','import_status':'not evaluated by extraction'}
(OUT/'coverage.json').write_text(json.dumps(summary,indent=2),encoding='utf-8')
print(json.dumps({'objects':sum(counts.values()),'types':len(counts),'failures':len(issues),'references':dict(refs),'streams':len(streams)}),flush=True)
