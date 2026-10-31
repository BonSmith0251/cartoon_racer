import pathlib,json,re,collections,struct,UnityPy
root=pathlib.Path(r'D:\Games\CartoonRacerRecon');assets=root/'Assets';out=root/'Recovery/code'
issues=[json.loads(l) for l in (root/'Recovery/scenes/editor-audit/issues.jsonl').read_text(encoding='utf-8-sig').splitlines()];methods=json.loads((out/'method-status.json').read_text(encoding='utf-8-sig'))
original=pathlib.Path(r'C:\Program Files (x86)\GameTop.com\Cartoon Hot Racer 3D\Cartoon Hot Racer 3D_Data\data.unity3d');env=UnityPy.load(str(original));obj={(o.assets_file.name,str(o.path_id)):o for o in env.objects}
scenes={'MENU':'level0','SCHOOL':'level5'};rows=[];parsed={};guidtypes={}
for meta in (assets/'Scripts').rglob('*.cs.meta'):
 guid=re.search(r'^guid: (\w+)',meta.read_text(encoding='utf-8-sig'),re.M)
 if guid:guidtypes[guid.group(1)]=meta.name[:-8]
for issue in issues:
 if issue['type']!='invalid-unityevent':continue
 scope=issue['scope'];goid=issue['owner'].split('-')[-2];expected=issue['message'].split('missing: ',1)[1];idx=int(re.search(r'm_Calls\[(\d+)\]',issue['message']).group(1))
 if scope not in parsed:
  text=(root/scope).read_text(encoding='utf-8-sig');parsed[scope]={m.group(2):m.group(3) for m in re.finditer(r'^--- !u!(\d+) &(\d+)\n(.*?)(?=^---|\Z)',text,re.M|re.S)}
 blocks=parsed[scope];go=blocks[goid];components=re.findall(r'component: \{fileID: (\d+)',go);match=None
 for compid in components:
  b=blocks.get(compid,'');calls=list(re.finditer(r'- m_Target: \{fileID: (-?\d+)\}\n\s+m_MethodName: ([^\n]*)',b))
  for j,c in enumerate(calls):
   if c.group(2)==expected and j==idx:match=(compid,b,c);break
  if match:break
 assert match,(scope,goid,expected)
 compid,b,c=match;target=c.group(1);targetblock=blocks.get(target,'');guidmatch=re.search(r'm_Script: .*guid: (\w+)',targetblock);targettype=guidtypes.get(guidmatch.group(1)) if guidmatch else None
 original_has_method=any(x['type']==targettype and ('::'+expected+'(') in x['signature'] for x in methods)
 row=dict(scope=scope,owner=goid,component=compid,method=expected,export_target=target,target_type=targettype,original_method_exists=original_has_method)
 scene=scenes.get(pathlib.Path(scope).stem)
 if scene:
  raw=obj[(scene,compid)].get_raw_data();needle=struct.pack('<i',len(expected.encode('utf-8')))+expected.encode('utf-8');offset=raw.index(needle);fid,pid=struct.unpack_from('<iq',raw,offset-12);call={'m_Target':{'m_FileID':fid,'m_PathID':pid},'m_MethodName':expected};row['source_binary_method_offset']=offset;row['source_evidence']='original PPtr immediately before length-prefixed method name in UnityEvent payload'
  row['source_target']=call['m_Target'];row['source_method']=call['m_MethodName'];assert row['source_method']==expected
  if call['m_Target']['m_PathID']==0 and target=='0':row['classification']='original_null_target_preserved'
  elif not original_has_method:row['classification']='original_method_missing_from_managed_build'
  else:row['classification']='requires_further_reference_review'
 else:
  row['classification']='original_method_missing_from_managed_build' if not original_has_method else 'requires_prefab_source_mapping'
 rows.append(row)
(out/'unityevent-source-classification.json').write_text(json.dumps(rows,indent=2))
print('Counts',dict(collections.Counter(x['classification'] for x in rows)))
print('By scope',dict(collections.Counter(x['scope'] for x in rows)))
for r in rows:
 if r['classification'] not in ['original_null_target_preserved','original_method_missing_from_managed_build']:print(r)

