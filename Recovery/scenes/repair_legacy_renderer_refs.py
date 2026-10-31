import collections,json,pathlib,re
root=pathlib.Path(r"D:\Games\CartoonRacerRecon");rec=root/"Recovery/scenes";template=(rec/"LegacyParticleNativeTemplate.prefab").read_text(encoding="utf-8-sig")
nativePS=re.search(r"^--- !u!198 &\d+\n.*?(?=^--- !u!|\Z)",template,re.M|re.S)[0]
nativeRenderer=re.search(r"^--- !u!199 &\d+\n.*?(?=^--- !u!|\Z)",template,re.M|re.S)[0]
existing=rec/"legacy-renderer-reference-repair.json"
if existing.exists():
 previous=json.loads(existing.read_text())
 if previous.get("count")==195 and all(re.search(r"^--- !u!199 &"+re.escape(row["native_renderer_id"])+r"$",(root/row["asset"]).read_text(encoding="utf-8-sig"),re.M) for row in previous["changes"]):
  print("Native renderer references already repaired; retaining prior ledger");raise SystemExit(0)
 raise RuntimeError("Existing renderer repair ledger does not match project; inspect before mutation")
changes=[]
for path in (root/"Assets").rglob("*"):
 if path.suffix not in (".unity",".prefab",".asset") or path.name=="LegacyParticleNativeTemplate.prefab":continue
 try:text=path.read_text(encoding="utf-8-sig")
 except UnicodeDecodeError:continue
 if "0a9e7a2f58124371a20101b721cc026a" not in text:continue
 docs={m[2]:(int(m[1]),m[0]) for m in re.finditer(r"^--- !u!(\d+) &(-?\d+)\n(.*?)(?=^--- !u!|\Z)",text,re.M|re.S)};nextID=max(abs(int(x)) for x in docs)+1;append=[]
 for oldID,(cid,doc) in list(docs.items()):
  if cid!=114 or "guid: 0a9e7a2f58124371a20101b721cc026a" not in doc:continue
  go=re.search(r"m_GameObject: \{fileID: (-?\d+)\}",doc)[1];goDoc=docs[go][1]
  oldPS=[k for k in re.findall(r"component: \{fileID: (-?\d+)\}",goDoc) if docs.get(k,(0,None))[0]==198]
  if oldPS:raise RuntimeError("Existing modern system must be handled explicitly: "+str(path)+" GO"+go)
  dataID=str(nextID);psID=str(nextID+1);nextID+=2
  config=json.loads(json.loads(re.search(r"^  configJson: (.*)$",doc,re.M)[1]))
  mats=re.search(r"^  materials:\n((?:  - .*\n)*)",doc,re.M);mats=mats[1] if mats else ""
  native=nativeRenderer
  native=re.sub(r"^--- !u!199 &\d+","--- !u!199 &"+oldID,native,flags=re.M)
  native=re.sub(r"m_GameObject: \{fileID: \d+\}","m_GameObject: {fileID: "+go+"}",native)
  native=re.sub(r"^  m_Materials:\n(?:  - .*\n)*","  m_Materials:\n"+mats,native,flags=re.M)
  for key,value in (("m_Enabled",int(config["enabled"])),("m_SortingLayerID",config["sortingLayerId"]),("m_SortingOrder",config["sortingOrder"])):
   native=re.sub(r"^  "+key+r": .*","  "+key+": "+str(value),native,flags=re.M)
  ps=re.sub(r"^--- !u!198 &\d+","--- !u!198 &"+psID,nativePS,flags=re.M)
  ps=re.sub(r"m_GameObject: \{fileID: \d+\}","m_GameObject: {fileID: "+go+"}",ps)
  bridge=re.sub(r"^--- !u!114 &-?\d+","--- !u!114 &"+dataID,doc,flags=re.M)
  text=text.replace(doc,native);append.extend([bridge,ps])
  updated=goDoc.replace("  m_Layer:","  - component: {fileID: "+dataID+"}\n  - component: {fileID: "+psID+"}\n  m_Layer:")
  text=text.replace(goDoc,updated);docs[go]=(1,updated)
  emit=[(k,v[1]) for k,v in docs.items() if v[0]==114 and "guid: 0a9e7a2f58124371a20101b721cc015a" in v[1] and re.search(r"m_GameObject: \{fileID: "+re.escape(go)+r"\}",v[1])]
  if len(emit)!=1:raise RuntimeError("Expected exactly one emitter")
  emitterID,emitter=emit[0];text=text.replace(emitter,emitter+"  serializedParticleSystem: {fileID: "+psID+"}\n")
  changes.append({"asset":str(path.relative_to(root)),"gameobject_id":go,"original_renderer_id":oldID,"native_renderer_id":oldID,"data_component_id":dataID,"native_particlesystem_id":psID,"emitter_id":emitterID,"reason":"Preserve Renderer-typed PPtrs such as LODGroup m_Renderers"})
 text+="".join(append);path.write_text(text,encoding="utf-8",newline="\n")
(rec/"legacy-renderer-reference-repair.json").write_text(json.dumps({"count":len(changes),"changes":changes,"template":"Unity2023.2.22f1 editor-generated native component YAML","provenance":"evidence-based particle approximation preserving native renderer identity"},indent=2))
for file in [rec/"LegacyParticles/LegacyParticleEmitterRecovery.cs",root/"Assets/Recovery/LegacyParticles/LegacyParticleEmitterRecovery.cs"]:
 s=file.read_text(encoding="utf-8-sig").replace("ParticleSystem recovered;bool initialized;","public ParticleSystem serializedParticleSystem;\n ParticleSystem recovered;bool initialized;")
 s=s.replace("if(GetComponent<ParticleSystem>()!=null)","if(serializedParticleSystem==null&&GetComponent<ParticleSystem>()!=null)")
 s=s.replace("recovered=gameObject.AddComponent<ParticleSystem>();","recovered=serializedParticleSystem!=null?serializedParticleSystem:gameObject.AddComponent<ParticleSystem>();")
 file.write_text(s,encoding="utf-8")
telemetry=root/"Assets/Recovery/RecoveryRuntimeEvidence.cs";s=telemetry.read_text(encoding="utf-8-sig").replace('var go=new GameObject("Recovery runtime evidence (opt-in)");','Application.runInBackground=true;\n  var go=new GameObject("Recovery runtime evidence (opt-in)");');telemetry.write_text(s,encoding="utf-8")
for name in ("LegacyParticleNativeTemplate.prefab","LegacyParticleNativeTemplate.prefab.meta"):
 p=root/"Assets/Recovery"/name
 if p.exists():p.rename(rec/("template-"+name))
print(json.dumps({"native_renderers_restored":len(changes),"native_particle_systems_added":len(changes)}))

