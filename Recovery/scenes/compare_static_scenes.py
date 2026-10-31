"""Compare preserved source scene identities to exported/migrated Unity YAML without Unity."""
import collections,json,pathlib,re
root=pathlib.Path(r"D:\Games\CartoonRacerRecon");evidence=root/"Recovery/scenes";summary=json.loads((evidence/"source/source-summary.json").read_text())
rows=collections.defaultdict(dict)
for line in (evidence/"source/source-hierarchy.jsonl").open(encoding="utf-8"):
 row=json.loads(line)
 if row["source_file"].startswith("level"):rows[row["source_file"]][row["path_id"]]=row
settings=json.loads((evidence/"source/source-settings.json").read_text());tags=next(x["data"]["tags"] for x in settings if x["type"]=="TagManager")
repairs=json.loads((evidence/"legacy-renderer-reference-repair.json").read_text())["changes"];extra_components={r["asset"].replace("\\","/")+":"+r["gameobject_id"]:{r["data_component_id"],r["native_particlesystem_id"]} for r in repairs}
issues=[];scenes=[];mapping=[]
for source,scene in summary["scenes"].items():
 path=root/scene["source_path"];text=path.read_text(encoding="utf-8-sig");docs={}
 guid=re.search(r"^guid: (\w+)",path.with_suffix(".unity.meta").read_text(),re.M)[1]
 for m in re.finditer(r"^--- !u!(\d+) &(-?\d+)\n(.*?)(?=^--- !u!|\Z)",text,re.M|re.S):docs[m[2]]=(int(m[1]),m[3])
 compared=0
 for local,sourceobj in rows[source].items():
  if local not in docs:issues.append({"scene":scene["source_path"],"source_id":local,"failure":"missing destination localID"});continue
  cls,body=docs[local];typ=sourceobj["type"]
  mapping.append({"source_file":source,"source_path_id":local,"destination_asset":scene["source_path"],"destination_guid":guid,"destination_local_id":local,"class":typ,"mapping_evidence":"scene localID and type/structural fields"})
  def field(name):
   m=re.search(r"^  "+re.escape(name)+r": (.+)$",body,re.M);return m[1] if m else None
  if typ=="GameObject":
   name=field("m_Name")
   # Unity YAML quotes special names. Decode JSON-compatible double quoted names.
   if name and name.startswith("'"):name=name[1:-1].replace("''","'")
   if name and name.startswith('"'):
    try:name=json.loads(name)
    except ValueError:pass
   tests={"class":(cls,1),"name":(name,sourceobj["name"]),"active":(field("m_IsActive"),str(int(sourceobj["active"]))),"layer":(field("m_Layer"),str(sourceobj["layer"]))}
   comp=re.search(r"^  m_Component:\n((?:  - component:.*\n)*)",body,re.M)
   destcomps=re.findall(r"fileID: (-?\d+)",comp[1]) if comp else []
   extras=extra_components.get(scene["source_path"]+":"+local,set());tests["ordered_components"]=([x for x in destcomps if x not in extras],[p["path_id"] for p in sourceobj["components"]])
   tag=sourceobj["tag"];tagname=tags[tag-20000] if tag>=20000 else {0:"Untagged",1:"Respawn",2:"Finish",3:"EditorOnly",5:"MainCamera",6:"Player",7:"GameController"}.get(tag,"UNKNOWN")
   tests["tag"]=(field("m_TagString"),tagname)
  else:
   parent=field("m_Father");parentid=re.search(r"fileID: (-?\d+)",parent)[1] if parent else None
   tests={"class":(cls,224 if typ=="RectTransform" else 4),"parent":(parentid,sourceobj["parent"]["path_id"])}
   for name,key,axes in (("m_LocalPosition","local_position","xyz"),("m_LocalScale","local_scale","xyz"),("m_LocalRotation","local_rotation","xyzw")):
    raw=field(name)
    vals=dict((k,float(v)) for k,v in re.findall(r"([xyzw]): ([^,}]+)",raw or ""))
    expected=sourceobj[key]
    tests[key]=(all(abs(vals.get(k,1e100)-expected[k])<1e-5*max(1,abs(expected[k])) for k in axes),True)
   childblock=re.search(r"^  m_Children:\n((?:  - .*\n)*)",body,re.M)
   children=re.findall(r"fileID: (-?\d+)",childblock[1]) if childblock else []
   tests["ordered_children"]=(children,[c["path_id"] for c in sourceobj["children"]])
   if typ=="RectTransform":
    for prop,expected in sourceobj["rect"].items():
     values=dict((k,float(v)) for k,v in re.findall(r"([xy]): ([^,}]+)",field(prop) or ""))
     tests[prop]=(all(abs(values.get(k,1e100)-v)<1e-5*max(1,abs(v)) for k,v in expected.items()),True)
  for key,(actual,expected) in tests.items():
   if actual!=expected:issues.append({"scene":scene["source_path"],"source_id":local,"field":key,"actual":actual,"expected":expected})
  compared+=1
 scenes.append({"source":source,"path":scene["source_path"],"source_gameobjects":scene["game_objects"],"source_roots":scene["roots"],"source_inactive":scene["inactive"],"source_hierarchy_records":len(rows[source]),"compared":compared,"exported_yaml_documents":len(docs),"issues":sum(x["scene"]==scene["source_path"] for x in issues)})
with (evidence/"scene-source-destination-map.jsonl").open("w",encoding="utf-8") as f:
 for row in mapping:f.write(json.dumps(row,separators=(",",":"))+"\n")
(evidence/"static-scene-comparison.json").write_text(json.dumps({"schema":"source-scene-structure-comparison/1","scenes":scenes,"issues":issues,"result":"pass" if not issues else "fail","scope":"GameObject names/active/layer/tag/ordered component IDs and Transform class/parent/ordered children/local pose plus RectTransform anchors/offset/size/pivot; reference/visual/runtime not asserted"},indent=2),encoding="utf-8")
print(json.dumps({"scenes":len(scenes),"mapped_hierarchy_records":len(mapping),"issues":len(issues),"sample":issues[:5]}))

