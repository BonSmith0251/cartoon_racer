import argparse,base64,collections,hashlib,json,pathlib,re
CLASSES={12:("LegacyParticleAnimatorRecovery","0a9e7a2f58124371a20101b721cc012a"),15:("LegacyParticleEmitterRecovery","0a9e7a2f58124371a20101b721cc015a"),26:("LegacyParticleRendererRecovery","0a9e7a2f58124371a20101b721cc026a")}
def scalar(body,name,default=0):
 m=re.search(r"^  "+re.escape(name)+r": (.+)$",body,re.M)
 if not m:return default
 try:return float(m[1]) if "." in m[1] or "e" in m[1].lower() else int(m[1])
 except ValueError:return m[1]
def vec(body,name):
 m=re.search(r"^  "+re.escape(name)+r": \{x: ([^,]+), y: ([^,]+), z: ([^}]+)\}",body,re.M)
 return dict(zip("xyz",map(float,m.groups()))) if m else dict(x=0,y=0,z=0)
def config(cid,b):
 if cid==15:
  d={n:scalar(b,n) for n in ("minSize","maxSize","minEnergy","maxEnergy","minEmission","maxEmission","emitterVelocityScale","angularVelocity")}
  d.update({n:vec(b,n) for n in ("worldVelocity","localVelocity","tangentVelocity")})
  d.update(emit=bool(scalar(b,"m_Emit")),oneShot=bool(scalar(b,"m_OneShot")),worldSpace=bool(scalar(b,"Simulate in Worldspace?")),randomRotation=bool(scalar(b,"rndRotation")),randomAngularVelocity=scalar(b,"rndAngularVelocity"),minEmitterRange=scalar(b,"m_MinEmitterRange"),randomVelocity=vec(b,"rndVelocity"),ellipsoid=vec(b,"m_Ellipsoid"));return d
 if cid==12:
  colors=[int(x) for x in re.findall(r"^    rgba: (\d+)",b,re.M)]
  return dict(animateColor=bool(scalar(b,"Does Animate Color?")),autoDestroy=bool(scalar(b,"autodestruct")),stopSimulation=bool(scalar(b,"stopSimulation")),colors=colors,sizeGrow=scalar(b,"sizeGrow"),damping=scalar(b,"damping"),**{n:vec(b,n) for n in ("worldRotationAxis","localRotationAxis","rndForce","force")})
 return dict(enabled=bool(scalar(b,"m_Enabled",1)),stretch=scalar(b,"m_StretchParticles"),sortingOrder=scalar(b,"m_SortingOrder"),sortingLayerId=scalar(b,"m_SortingLayerID"),lengthScale=scalar(b,"m_LengthScale",1),velocityScale=scalar(b,"m_VelocityScale"),maxParticleSize=scalar(b,"m_MaxParticleSize",1),xTile=scalar(b,"x Tile",1),yTile=scalar(b,"y Tile",1),cycles=scalar(b,"cycles",1))
def main():
 p=argparse.ArgumentParser();p.add_argument("--project",required=True);a=p.parse_args();root=pathlib.Path(a.project);recovery=root/"Recovery/scenes";scripts=root/"Assets/Recovery/LegacyParticles";scripts.mkdir(parents=True,exist_ok=True)
 for cid,(name,guid) in CLASSES.items():
  (scripts/(name+".cs")).write_bytes((recovery/"LegacyParticles"/(name+".cs")).read_bytes())
  (scripts/(name+".cs.meta")).write_text("fileFormatVersion: 2\nguid: "+guid+"\nMonoImporter:\n  externalObjects: {}\n  serializedVersion: 2\n  defaultReferences: []\n  executionOrder: 0\n  icon: {instanceID: 0}\n  userData:\n  assetBundleName:\n  assetBundleVariant:\n")
 changes=[]
 for path in root.joinpath("Assets").rglob("*"):
  if path.suffix not in (".unity",".prefab",".asset"):continue
  try:text=path.read_text(encoding="utf-8-sig")
  except UnicodeDecodeError:continue
  if not re.search(r"^--- !u!(12|15|26) &",text,re.M):continue
  def replace(m):
   cid=int(m[1]);local=m[2];body=m[3];name,guid=CLASSES[cid];enabled=int(scalar(body,"m_Enabled",1));game=re.search(r"^  m_GameObject: (.+)$",body,re.M)[1]
   extra=""
   if cid==26:
    materials=re.search(r"^  m_Materials:\n((?:  - .*\n)*)",body,re.M)
    extra="  materials:\n"+(materials[1] if materials else "")
   changes.append({"asset":str(path.relative_to(root)),"local_id":local,"original_class_id":cid,"replacement":name,"script_guid":guid,"original_yaml_sha256":hashlib.sha256(m[0].encode()).hexdigest(),"provenance":"evidence-based approximation","raw_preserved":"sourceYamlBase64"})
   return "--- !u!114 &"+local+"\nMonoBehaviour:\n  m_ObjectHideFlags: 0\n  m_CorrespondingSourceObject: {fileID: 0}\n  m_PrefabInstance: {fileID: 0}\n  m_PrefabAsset: {fileID: 0}\n  m_GameObject: "+game+"\n  m_Enabled: "+str(enabled)+"\n  m_EditorHideFlags: 0\n  m_Script: {fileID: 11500000, guid: "+guid+", type: 3}\n  m_Name:\n  m_EditorClassIdentifier:\n  sourceYamlBase64: "+base64.b64encode(m[0].encode()).decode()+"\n  configJson: "+json.dumps(json.dumps(config(cid,body),separators=(",",":")))+"\n"+extra
  text=re.sub(r"^--- !u!(12|15|26) &(-?\d+)\n(.*?)(?=^--- !u!|\Z)",replace,text,flags=re.M|re.S)
  path.write_text(text,encoding="utf-8",newline="\n")
 if not changes and (recovery/"legacy-particle-migration.json").exists():
  print("Legacy particles already migrated; retaining prior ledger");return
 (recovery/"legacy-particle-migration.json").write_text(json.dumps({"schema":"legacy-particle-migration/1","components":changes,"count":len(changes),"limitations":["Dynamics are an approximation; original damping, rotation axes and tangent velocity preserved as data but not implemented","Source raw YAML preserved inside each compatibility component plus pristine export","Renderer mode 4 translated to horizontal billboard; mode 2 billboard sorted by distance; visual validation pending","Generated modern particle system is runtime-only and never duplicates a preexisting modern ParticleSystem"]},indent=2))
 print(json.dumps({"converted_components":len(changes),"by_original_class":dict(collections.Counter(r["original_class_id"] for r in changes))}))
if __name__=="__main__":main()

