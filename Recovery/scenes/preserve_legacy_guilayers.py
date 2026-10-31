import base64,json,pathlib,re
root=pathlib.Path(r"D:\Games\CartoonRacerRecon");folder=root/"Assets/Recovery/LegacyParticles";guid="0a9e7a2f58124371a20101b721cc092a"
(folder/"LegacyGUILayerRecovery.cs").write_text('''using UnityEngine;
namespace CartoonRacerRecovery {
// Source had four legacy GUILayers but zero native GUIText/GUITexture objects.
// Unity2023 no longer needs that camera component for OnGUI/Canvas rendering.
public sealed class LegacyGUILayerRecovery : MonoBehaviour {
 [HideInInspector] public string sourceYamlBase64;
}
}
''')
(folder/"LegacyGUILayerRecovery.cs.meta").write_text("fileFormatVersion: 2\nguid: "+guid+"\nMonoImporter:\n  externalObjects: {}\n  serializedVersion: 2\n  defaultReferences: []\n  executionOrder: 0\n")
changes=[]
for path in (root/"Assets").rglob("*"):
 if path.suffix not in (".unity",".prefab",".asset"):continue
 try:s=path.read_text(encoding="utf-8-sig")
 except UnicodeDecodeError:continue
 if not re.search(r"^--- !u!92 &",s,re.M):continue
 def replace(m):
  id=m[1];body=m[2];go=re.search(r"m_GameObject: (\{fileID: -?\d+\})",body)[1]
  enabled=re.search(r"m_Enabled: (\d+)",body)
  changes.append({"asset":str(path.relative_to(root)),"original_local_id":id,"replacement_guid":guid,"original_class":"GUILayer","source_payload":base64.b64encode(m[0].encode()).decode(),"provenance":"preserved obsolete legacy engine system; source has zero GUIText/GUITexture native objects"})
  return "--- !u!114 &"+id+"\nMonoBehaviour:\n  m_ObjectHideFlags: 0\n  m_CorrespondingSourceObject: {fileID: 0}\n  m_PrefabInstance: {fileID: 0}\n  m_PrefabAsset: {fileID: 0}\n  m_GameObject: "+go+"\n  m_Enabled: "+(enabled[1] if enabled else "1")+"\n  m_EditorHideFlags: 0\n  m_Script: {fileID: 11500000, guid: "+guid+", type: 3}\n  m_Name:\n  m_EditorClassIdentifier:\n  sourceYamlBase64: "+base64.b64encode(m[0].encode()).decode()+"\n"
 s=re.sub(r"^--- !u!92 &(-?\d+)\n(.*?)(?=^--- !u!|\Z)",replace,s,flags=re.M|re.S);path.write_text(s,encoding="utf-8",newline="\n")
if not changes and (root/"Recovery/scenes/legacy-guilayer-migration.json").exists():
 print("Legacy GUILayers already preserved; retaining prior ledger");raise SystemExit(0)
(root/"Recovery/scenes/legacy-guilayer-migration.json").write_text(json.dumps({"count":len(changes),"components":changes},indent=2))
print(json.dumps({"preserved_guilayer_components":len(changes)}))

