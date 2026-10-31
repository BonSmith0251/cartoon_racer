import hashlib,json,pathlib,re
root=pathlib.Path(r"D:\Games\CartoonRacerRecon");folder=root/"Assets/GameObject";moves=[];blocked=[]
for path in list(folder.glob("*.prefab")):
 text=path.read_text(encoding="utf-8-sig");rootid=re.search(r"m_RootGameObject: \{fileID: (-?\d+)\}",text)
 if not rootid:continue
 doc=re.search(r"^--- !u!1 &"+rootid[1]+r"\n(.*?)(?=^--- !u!|\Z)",text,re.M|re.S)
 name=re.search(r"^  m_Name: (.+)$",doc[1],re.M)[1]
 if name.startswith("'"):name=name[1:-1].replace("''","'")
 if name.startswith('"'):name=json.loads(name)
 if name==path.stem:continue
 if any(c in name for c in r'<>:"/\|?*') or name.rstrip()!=name:blocked.append((str(path),name));continue
 destination=folder/path.stem/(name+".prefab")
 if destination.exists():raise RuntimeError("Destination exists: "+str(destination))
 # Check literal loader/object-name references before moving a non-Resources asset.
 hits=[]
 for code in (root/"Assets/Scripts").rglob("*.cs"):
  codeText=code.read_text(encoding="utf-8-sig")
  if '"'+path.stem+'"' in codeText or str(path.relative_to(root)).replace("\\","/") in codeText:hits.append(str(code.relative_to(root)))
 if hits:raise RuntimeError("Path/name-addressed code references need review: "+str(hits))
 meta=path.with_suffix(".prefab.meta");before=hashlib.sha256(path.read_bytes()).hexdigest();guid=re.search(r"^guid: (\w+)",meta.read_text(),re.M)[1]
 destination.parent.mkdir(parents=True)
 if root.resolve() not in destination.resolve().parents:raise RuntimeError("Outside project")
 path.rename(destination);meta.rename(destination.with_suffix(".prefab.meta"))
 if hashlib.sha256(destination.read_bytes()).hexdigest()!=before:raise RuntimeError("Payload changed")
 moves.append({"previous_asset":str(path.relative_to(root)),"asset":str(destination.relative_to(root)),"source_root_name":name,"root_local_id":rootid[1],"guid":guid,"sha256_unchanged":before,"literal_loader_or_name_references":[]})
if blocked:raise RuntimeError("Unexpected names: "+str(blocked))
rec=root/"Recovery/scenes"
if not moves and (rec/"prefab-root-name-moves.json").exists():
 print("Prefab root names already preserved; retaining prior move ledger");raise SystemExit(0)
(rec/"prefab-root-name-moves.json").write_text(json.dumps({"count":len(moves),"moves":moves,"policy":"Only non-Resources prefab file and .meta moved; content/GUID/localIDs unchanged; original rootname now matches file basename","checks":"No exact filename-stem string or old fullpath references in recovered script source"},indent=2))
for ledgername in ("legacy-renderer-reference-repair.json",):
 p=rec/ledgername;ledger=json.loads(p.read_text());mapping={m["previous_asset"]:m["asset"] for m in moves}
 for row in ledger["changes"]:
  if row["asset"] in mapping:row["previous_asset"]=row["asset"];row["asset"]=mapping[row["asset"]]
 p.write_text(json.dumps(ledger,indent=2))
print(json.dumps({"prefabs_moved":len(moves),"blocked":blocked}))

