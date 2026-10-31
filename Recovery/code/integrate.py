import pathlib,json,re,shutil,hashlib
root=pathlib.Path(r'D:\Games\CartoonRacerRecon'); code=root/'Recovery/code'; assets=root/'Assets'; logs=[]
for asm,base in [('Assembly-CSharp','Scripts'),('Assembly-UnityScript','Scripts'),('Assembly-UnityScript-firstpass','Plugins'),('Assembly-CSharp-firstpass','Plugins')]:
 for src in (code/'repaired'/asm).rglob('*.cs'):
  rel=src.relative_to(code/'repaired'/asm); dst=assets/base/asm/pathlib.Path(*[part for folder in rel.parent.parts for part in folder.split('.')])/rel.name
  dst.parent.mkdir(parents=True,exist_ok=True)
  if dst.exists():
   logs.append(dict(path=str(dst.relative_to(root)),operation='replace_source_preserve_meta',before=hashlib.sha256(dst.read_bytes()).hexdigest(),after=hashlib.sha256(src.read_bytes()).hexdigest()))
  shutil.copy2(src,dst)
 if asm not in ['Assembly-CSharp','Assembly-CSharp-firstpass']:
  cfg=dict(name=asm,references=[],allowUnsafeCode=True,autoReferenced=True)
  (assets/base/asm/(asm+'.asmdef')).write_text(json.dumps(cfg,indent=2))
for asm in ['ES2','MoodkieSecurity','Tayx.Graphy','ch.sycoforge.Combine','ch.sycoforge.Unity.Runtime']:
 src=code/'compiled'/(asm+'.dll'); dst=assets/'Plugins'/(asm+'.dll')
 shutil.copy2(src,dst);logs.append(dict(path=str(dst.relative_to(root)),operation='target_recompiled_plugin_preserve_meta',sha256=hashlib.sha256(src.read_bytes()).hexdigest()))
original=pathlib.Path(r'C:\Program Files (x86)\GameTop.com\Cartoon Hot Racer 3D\Cartoon Hot Racer 3D_Data\Managed')
shutil.copy2(original/'Boo.Lang.dll',assets/'Plugins/Boo.Lang.dll')
# Backup all unused copied platform/framework DLLs rather than deleting source evidence.
for asm in ['UnityEngine.Analytics','UnityEngine.Purchasing','UnityEngine.StandardEvents','System.Runtime.InteropServices','System.Runtime.CompilerServices.Unsafe']:
 p=assets/'Plugins'/(asm+'.dll');meta=p.with_suffix('.dll.meta');guid=re.search(r'^guid: (\w+)',meta.read_text(),re.M).group(1)
 hits=[]
 for pattern in ['*.unity','*.prefab','*.asset']:
  for asset in assets.rglob(pattern):
   if guid in asset.read_text(errors='ignore'):hits.append(str(asset))
 assert not hits,(asm,hits)
 backup=code/'excluded_export_plugins';backup.mkdir(exist_ok=True)
 shutil.move(str(p),str(backup/p.name));shutil.move(str(meta),str(backup/meta.name))
 logs.append(dict(path=str(p.relative_to(root)),operation='excluded_unused_exported_framework_or_platform_binary',reference_count=0))
(code/'integration.json').write_text(json.dumps(logs,indent=2))
print('Merged scripts and plugin binaries; retained existing script and DLL GUIDs. Integration rows:',len(logs))

