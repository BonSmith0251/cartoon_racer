import pathlib,shutil,json
root=pathlib.Path(r'D:\Games\CartoonRacerRecon');code=root/'Recovery/code';assets=root/'Assets';changes=[]
for asm,base in [('Assembly-CSharp','Scripts'),('Assembly-UnityScript','Scripts'),('Assembly-UnityScript-firstpass','Plugins'),('Assembly-CSharp-firstpass','Plugins')]:
 for src in (code/'repaired'/asm).rglob('*.cs'):
  rel=src.relative_to(code/'repaired'/asm);parent=pathlib.Path(*[part for folder in rel.parent.parts for part in folder.split('.')]);dst=assets/base/asm/parent/rel.name
  if src.parent.name=='Properties':continue
  dst.parent.mkdir(parents=True,exist_ok=True);shutil.copy2(src,dst)
  if rel.parent!=parent:changes.append(dict(old_path=str(assets/base/asm/rel),exporter_path=str(dst),operation='copied_recovered_source_to_original_exporter_namespace_path_preserve_meta'))
 for folder in (assets/base/asm).iterdir():
  if folder.is_dir() and '.' in folder.name:
   assert folder.resolve().is_relative_to(root.resolve())
   backup=code/'duplicate_source_paths'/asm/folder.name;backup.parent.mkdir(parents=True,exist_ok=True)
   assert not backup.exists(),backup
   shutil.move(str(folder),str(backup))
   meta=folder.with_name(folder.name+'.meta')
   if meta.exists():shutil.move(str(meta),str(backup.with_name(backup.name+'.meta')))
(code/'namespace-path-repairs.json').write_text(json.dumps(changes,indent=2))
print('Mapped namespace source paths:',len(changes))
