import pathlib,json,re,collections
root=pathlib.Path(r'D:\Games\CartoonRacerRecon');p=root/'Recovery/code/unityevent-source-classification.json';rows=json.loads(p.read_text());cache={}
for r in rows:
 scope=r['scope']
 if scope not in cache:
  s=(root/'Recovery/extraction/pristine-export/ExportedProject'/scope).read_text(encoding='utf-8-sig');c=(root/scope).read_text(encoding='utf-8-sig')
  cache[scope]=[{m.group(1):m.group(2) for m in re.finditer(r'^--- !u!\d+ &(\d+)\n(.*?)(?=^---|\Z)',txt,re.M|re.S)} for txt in [s,c]]
 old,new=cache[scope];r['pristine_export_component_unchanged']=old[r['component']]==new[r['component']]
 assert r['pristine_export_component_unchanged'],r
 if r['export_target']=='0':r['classification']='original_null_target_preserved'
 elif r['target_type'] is None and 'm_Script: {fileID: 0}' in old.get(r['export_target'],''):r['classification']='original_null_script_target_preserved'
 elif not r['original_method_exists']:r['classification']='original_method_absent_from_managed_build_preserved'
 else:r['classification']='unclassified'
p.write_text(json.dumps(rows,indent=2));print(collections.Counter(x['classification'] for x in rows))
