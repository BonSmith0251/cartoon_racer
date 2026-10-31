import json,pathlib,re,tarfile
root=pathlib.Path(r"D:\Games\CartoonRacerRecon");package=root/"Library/PackageCache/com.unity.ugui@2.0.0/Package Resources/TMP Essential Resources.unitypackage";changes=[]
with tarfile.open(package,"r:gz") as tar:
 members={m.name:m for m in tar.getmembers()};assets={}
 for name,member in members.items():
  if not name.endswith("/pathname"):continue
  path=tar.extractfile(member).read().decode("utf-8").strip();asset=name[:-8]+"asset"
  if "/Shaders/" in path and path.endswith((".shader",".cginc")) and asset in members:assets[path]=tar.extractfile(members[asset]).read()
 exported={}
 for path in (root/"Assets").rglob("*.shader"):
  text=path.read_text(encoding="utf-8-sig");m=re.search(r'Shader\s+"([^"]+)"',text)
  if m:exported[m[1]]=path
 for source,content in assets.items():
  if source.endswith(".cginc"):
   dest=root/"Assets/Shader"/pathlib.Path(source).name;dest.write_bytes(content);changes.append({"package_path":source,"destination":str(dest.relative_to(root)),"type":"include"});continue
  m=re.search(rb'Shader\s+"([^"]+)"',content)
  if m and m[1].decode() in exported:
   dest=exported[m[1].decode()];dest.write_bytes(content);changes.append({"package_path":source,"destination":str(dest.relative_to(root)),"type":"genuine package shader, target-compatible reconstruction"})
(root/"Recovery/scenes/tmp-shader-replacement.json").write_text(json.dumps(changes,indent=2))
print(json.dumps(changes))

