import json,pathlib
r=pathlib.Path(r"D:\Games\CartoonRacerRecon\Recovery\scenes");s=json.loads((r/"source/source-summary.json").read_text());t=s["types"]
groups={
"scene_graph":["GameObject","Transform","RectTransform"],
"models_and_skinning":["Mesh","MeshRenderer","SkinnedMeshRenderer","LODGroup","Avatar"],
"textures_materials_shaders":["Texture2D","Cubemap","Material","Shader"],
"animation":["AnimationClip","AnimatorController","Animator","Animation"],
"cameras":["Camera","FlareLayer","GUILayer","LensFlare","Projector"],
"lighting":["Light","RenderSettings","LightmapSettings"],
"audio":["AudioClip","AudioSource","AudioListener"],
"physics":["Rigidbody","BoxCollider","MeshCollider","WheelCollider","CapsuleCollider","TerrainCollider","SphereCollider","ConfigurableJoint","PhysicMaterial"],
"ui_input":["Canvas","CanvasGroup","CanvasRenderer","RectTransform","Font","InputManager"],
"particles":["ParticleSystem","ParticleSystemRenderer","ParticleAnimator","EllipsoidParticleEmitter","ParticleRenderer","TrailRenderer"],
"terrain_navigation":["Terrain","TerrainData","NavMeshData","NavMeshSettings"],
"scripts_streaming":["MonoScript","MonoBehaviour","ResourceManager","TextAsset"],
"settings":["PlayerSettings","BuildSettings","TagManager","GraphicsSettings","QualitySettings","TimeManager","PhysicsManager","Physics2DSettings","AudioManager"]}
rows=[]
for name,types in groups.items():
 rows.append(dict(system=name,source_object_counts={k:t[k] for k in types if k in t},source_read="pass",export="recovered with exporter limitations",editor_import="in progress",structural_verification="pass for scene graph core only" if name=="scene_graph" else "pending",visual_verification="unattempted",behavior_verification="unattempted",player_verification="unattempted",notes=[]))
for row in rows:
 if row["system"]=="particles":row["notes"]=["585 obsolete native components translated to 585 compatibility components at preserved local IDs; original YAML retained; particle dynamics approximated; no recovered gameplay calls to legacy particle APIs"]
 if row["system"]=="textures_materials_shaders":row["notes"]=["303 shaders initially exported as flat dummy stubs; preserved compiled originals independent of reconstruction; selected custom shaders reconstructed from source DXBC evidence; 11 TMP shaders replaced with genuine target package equivalents; remaining shader stubs require explicit review"]
 if row["system"]=="scripts_streaming":row["notes"]=["Source executable logic decompiled separately; classes retain exporter GUIDs. GAME creates runtime terrain prefab and loads FARM_STATIC or CITY_STATIC additively; do not bake runtime snapshot into scene."]
 if row["system"]=="settings":row["notes"]=["2023.2.22f1 explicitly approved by user. Source serialized settings preserved; company/product intentionally changed to CartoonRacerRecovery / CartoonRacerRecon Validation to isolate ES2 save path."]
(r/"engine-feature-matrix.json").write_text(json.dumps(dict(schema="cartoon-racer-engine-features/1",source_version="2018.2.20f1",target_version="2023.2.22f1",source_objects=s["object_total"],source_scene_gameobjects=sum(x["game_objects"] for x in s["scenes"].values()),features=rows),indent=2))
print("feature matrix saved")

