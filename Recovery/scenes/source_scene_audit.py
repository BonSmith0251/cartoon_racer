"""Read-only build evidence audit. Requires UnityPy; writes only to --output."""
import argparse,collections,datetime,hashlib,json,pathlib
import UnityPy
def dump(path,obj):
 path.write_text(json.dumps(obj,indent=2,ensure_ascii=False,default=str),encoding="utf-8")
def pointer(p):
 if not isinstance(p,dict): return p
 return {"file_id":p.get("m_FileID",0),"path_id":str(p.get("m_PathID",0))}
def scrub(value):
 if isinstance(value,dict): return {k:("<redacted build metadata>" if any(x in k.lower() for x in ("authtoken","password","secret")) else scrub(v)) for k,v in value.items()}
 if isinstance(value,list): return [scrub(v) for v in value]
 return value
def main():
 ap=argparse.ArgumentParser();ap.add_argument("--source",required=True);ap.add_argument("--output",required=True);args=ap.parse_args()
 source=pathlib.Path(args.source);out=pathlib.Path(args.output);out.mkdir(parents=True,exist_ok=True)
 env=UnityPy.load(str(source));objects=list(env.objects);files={};issues=[];settings=[];scripts=[];scene_stats={};counts=collections.Counter()
 for o in objects:
  fn=o.assets_file.name;counts[o.type.name]+=1
  if fn not in files: files[fn]={"version":str(o.assets_file.unity_version),"objects":0,"types":collections.Counter(),"externals":[str(getattr(x,"path","")) for x in o.assets_file.externals]}
  files[fn]["objects"]+=1;files[fn]["types"][o.type.name]+=1
  if fn.startswith("level") and fn not in scene_stats:scene_stats[fn]={"objects":0,"game_objects":0,"inactive":0,"roots":0,"components":collections.Counter()}
  if fn in scene_stats:scene_stats[fn]["objects"]+=1;scene_stats[fn]["components"][o.type.name]+=1
  if fn=="globalgamemanagers" or o.type.name in ("RenderSettings","LightmapSettings","NavMeshSettings"):
   try: settings.append({"file":fn,"path_id":str(o.path_id),"type":o.type.name,"data":scrub(o.read_typetree())})
   except Exception as ex:issues.append({"file":fn,"path_id":str(o.path_id),"type":o.type.name,"failure":str(ex)})
  if o.type.name=="MonoScript":
   try:scripts.append({"file":fn,"path_id":str(o.path_id),"data":o.read_typetree()})
   except Exception as ex:issues.append({"file":fn,"path_id":str(o.path_id),"failure":str(ex)})
 with (out/"source-hierarchy.jsonl").open("w",encoding="utf-8") as f:
  for o in objects:
   typ=o.type.name
   if typ not in ("GameObject","Transform","RectTransform"):continue
   fn=o.assets_file.name
   try:
    d=o.read_typetree();row={"source_file":fn,"path_id":str(o.path_id),"type":typ}
    if typ=="GameObject":
     row.update(name=d.get("m_Name"),active=d.get("m_IsActive"),layer=d.get("m_Layer"),tag=d.get("m_Tag"),static_flags=d.get("m_StaticEditorFlags"),components=[pointer(x.get("component",x)) for x in d.get("m_Component",[])])
     if fn in scene_stats:scene_stats[fn]["game_objects"]+=1;scene_stats[fn]["inactive"]+=not bool(d.get("m_IsActive",1))
    else:
     row.update(game_object=pointer(d.get("m_GameObject")),parent=pointer(d.get("m_Father")),children=[pointer(x) for x in d.get("m_Children",[])],root_order=d.get("m_RootOrder"),local_position=d.get("m_LocalPosition"),local_rotation=d.get("m_LocalRotation"),local_scale=d.get("m_LocalScale"))
     if typ=="RectTransform":row["rect"]={k:v for k,v in d.items() if k in ("m_AnchorMin","m_AnchorMax","m_AnchoredPosition","m_SizeDelta","m_Pivot")}
     if fn in scene_stats and d.get("m_Father",{}).get("m_PathID")==0:scene_stats[fn]["roots"]+=1
    f.write(json.dumps(row,separators=(",",":"),ensure_ascii=False)+"\n")
   except Exception as ex:issues.append({"file":fn,"path_id":str(o.path_id),"type":typ,"failure":str(ex)})
 with (out/"legacy-particles.jsonl").open("w",encoding="utf-8") as f:
  for o in objects:
   if o.type.name not in ("ParticleAnimator","EllipsoidParticleEmitter","ParticleRenderer"):continue
   try:f.write(json.dumps({"source_file":o.assets_file.name,"path_id":str(o.path_id),"type":o.type.name,"data":o.read_typetree()},separators=(",",":"),default=str)+"\n")
   except Exception as ex:issues.append({"file":o.assets_file.name,"path_id":str(o.path_id),"type":o.type.name,"failure":str(ex)})
 build=next((s["data"] for s in settings if s["type"]=="BuildSettings"),{})
 scene_paths=build.get("scenes",[])
 for i,path in enumerate(scene_paths):
  if "level"+str(i) in scene_stats:scene_stats["level"+str(i)]["build_index"]=i;scene_stats["level"+str(i)]["source_path"]=path
 dump(out/"source-settings.json",settings);dump(out/"source-scripts.json",scripts);dump(out/"source-issues.json",issues)
 dump(out/"source-summary.json",{"schema":"cartoon-racer-source-scenes/1","created_utc":datetime.datetime.now(datetime.timezone.utc).isoformat(),"source":str(source.resolve()),"source_sha256":hashlib.file_digest(source.open("rb"),"sha256").hexdigest(),"unitypy":UnityPy.__version__,"object_total":len(objects),"types":counts,"files":files,"scenes":scene_stats,"build_scenes":scene_paths,"issues":len(issues),"validation":{"source_read":"complete","editor_import":"unattempted","structure_comparison":"unattempted","visual":"unattempted","behavior":"unattempted","player":"unattempted"}})
 print(json.dumps({"objects":len(objects),"scenes":scene_stats,"issues":len(issues)},default=str))
if __name__=="__main__":main()

