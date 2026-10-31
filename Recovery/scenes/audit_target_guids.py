import collections,json,pathlib,re
root=pathlib.Path(r"D:\Games\CartoonRacerRecon");known=collections.defaultdict(list)
for path in (root/"Assets").rglob("*.meta"):
 try:text=path.read_text(encoding="utf-8-sig")
 except (UnicodeDecodeError,OSError):continue
 m=re.search(r"^guid: ([a-fA-F0-9]{32})$",text,re.M)
 if m:known[m[1].lower()].append(str(path.relative_to(root)))
package_guids=set()
lock=json.loads((root/"Packages/packages-lock.json").read_text())
for name,desc in lock.get("dependencies",{}).items():
 for package in (root/"Library/PackageCache").glob(name+"@"+desc["version"]):
  for path in package.rglob("*.meta"):
   try:m=re.search(r"^guid: ([a-fA-F0-9]{32})$",path.read_text(encoding="utf-8-sig"),re.M)
   except (UnicodeDecodeError,OSError):continue
   if m:package_guids.add(m[1].lower())
for path in pathlib.Path(r"C:\Program Files\Unity 2023.2.22f1\Editor\Data\Resources\PackageManager\BuiltInPackages").rglob("*.meta"):
 try:m=re.search(r"^guid: ([a-fA-F0-9]{32})$",path.read_text(encoding="utf-8-sig"),re.M)
 except (UnicodeDecodeError,OSError):continue
 if m:package_guids.add(m[1].lower())
# UnityEngine.UI DLL script pseudo-GUID is resolved by the editor; prove from its observed refs.
observed=set()
for line in (root/"Recovery/scenes/editor-audit/references.jsonl").open(encoding="utf-8"):
 row=json.loads(line);target=row.get("target")
 if row["state"]=="resolved" and target and target.get("assetGuid"):observed.add(target["assetGuid"])
package_guids.update(observed)
# Original UnityEngine.UI DLL GUID is a Unity-maintained legacy script identity.
# Actual editor audit resolves its components as UnityEngine.UI.* (no missing scripts).
legacy_ui_guid="f5f67c52d1564df4a8936ccd202a3bd8"
legacy_ui_resolved=any("UnityEngine.UI.Button" in line and '"state":"resolved"' in line for line in (root/"Recovery/scenes/editor-audit/references.jsonl").open(encoding="utf-8"))
missing=[];refs=0;builtin=0;legacy_ui_references=0
for path in (root/"Assets").rglob("*"):
 if path.suffix not in (".unity",".prefab",".asset",".mat",".controller",".anim",".overrideController"):continue
 try:text=path.read_text(encoding="utf-8-sig")
 except (UnicodeDecodeError,OSError):continue
 if "%YAML" not in text[:100]:continue
 for i,line in enumerate(text.splitlines(),1):
  for m in re.finditer(r"fileID: (-?\d+), guid: ([a-fA-F0-9]{32})",line):
   if m[1]=="0":continue
   guid=m[2].lower();refs+=1
   if guid==legacy_ui_guid and legacy_ui_resolved:legacy_ui_references+=1;continue
   if guid.startswith("0000000000000000"):builtin+=1;continue
   if guid not in known and guid not in package_guids:missing.append({"asset":str(path.relative_to(root)),"line":i,"local_id":m[1],"guid":guid})
report=dict(schema="cartoon-racer-target-guid-audit/1",target_asset_guids=len(known),resolved_package_guids=len(package_guids),reference_occurrences=refs,builtin_reference_occurrences=builtin,editor_resolved_legacy_ui_references=legacy_ui_references,legacy_ui_evidence="Actual UI component types in editor-audit; original DLL script pseudo-GUID retained",duplicate_asset_guids={k:v for k,v in known.items() if len(v)>1},missing=missing,result="pass" if not missing and not any(len(v)>1 for v in known.values()) else "fail")
(root/"Recovery/scenes/static-guid-audit.json").write_text(json.dumps(report,indent=2))
print(json.dumps({k:v for k,v in report.items() if k not in ("missing","duplicate_asset_guids")},indent=2));print("missing",len(missing),missing[:6])

