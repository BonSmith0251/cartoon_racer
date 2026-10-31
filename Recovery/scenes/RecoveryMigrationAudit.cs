using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
namespace CartoonRacerRecovery {
public static class RecoveryMigrationAudit {
 [Serializable] class Repair {public string asset,gameobject_id,original_renderer_id,data_component_id,native_particlesystem_id,emitter_id;}
 [Serializable] class Ledger {public Repair[] changes;}
 [Serializable] class NameMove {public string asset,source_root_name,root_local_id;}
 [Serializable] class NameLedger {public NameMove[] moves;}
 [Serializable] class Finding {public string asset,rendererId,result,issue;}
 [Serializable] class Report {public string unityVersion,utc,result;public int checkedRenderers,checkedPrefabNames,failed;public Finding[] renderers,prefabNames;}
 static string LocalId(UnityEngine.Object obj){return GlobalObjectId.GetGlobalObjectIdSlow(obj).targetObjectId.ToString();}
 public static void Run(){
  int code=1;var rows=new List<Finding>();
  try{
   string root=Path.GetFullPath(Application.dataPath+"/..");var ledger=JsonUtility.FromJson<Ledger>(File.ReadAllText(Path.Combine(root,"Recovery/scenes/legacy-renderer-reference-repair.json")));
   foreach(var group in ledger.changes.GroupBy(r=>r.asset.Replace('\\','/'))){
    string path=group.Key;GameObject prefab=null;GameObject[] roots=null;
    try{
     if(path.EndsWith(".unity"))roots=EditorSceneManager.OpenScene(path,OpenSceneMode.Single).GetRootGameObjects();
     else{prefab=PrefabUtility.LoadPrefabContents(path);roots=new[]{prefab};}
     var components=roots.SelectMany(r=>r.GetComponentsInChildren<Component>(true)).Where(c=>c!=null&&LocalId(c)!="0").ToDictionary(c=>LocalId(c),c=>c);
     foreach(var item in group){
      var row=new Finding{asset=path,rendererId=item.original_renderer_id,result="pass"};rows.Add(row);
      try{
       var renderer=components[item.original_renderer_id] as ParticleSystemRenderer;
       var emitter=components[item.emitter_id] as LegacyParticleEmitterRecovery;
       var data=components[item.data_component_id] as LegacyParticleRendererRecovery;
       var particles=components[item.native_particlesystem_id] as ParticleSystem;
       if(renderer==null||emitter==null||data==null||particles==null)throw new InvalidOperationException("Expected native/compatibility component type not resolved");
       if(renderer.gameObject!=emitter.gameObject||data.gameObject!=emitter.gameObject||particles.gameObject!=emitter.gameObject)throw new InvalidOperationException("Component owner mismatch");
       if(emitter.serializedParticleSystem!=particles||particles.GetComponent<ParticleSystemRenderer>()!=renderer)throw new InvalidOperationException("Serialized native renderer/system link mismatch");
       if(string.IsNullOrEmpty(data.sourceYamlBase64)||Convert.FromBase64String(data.sourceYamlBase64).Length<1)throw new InvalidOperationException("Original renderer payload absent");
      }catch(Exception ex){row.result="fail";row.issue=ex.Message;}
     }
    }catch(Exception ex){foreach(var item in group)rows.Add(new Finding{asset=path,rendererId=item.original_renderer_id,result="fail",issue=ex.ToString()});}
    finally{if(prefab!=null)PrefabUtility.UnloadPrefabContents(prefab);}
   }
   var nameRows=new List<Finding>();var names=JsonUtility.FromJson<NameLedger>(File.ReadAllText(Path.Combine(root,"Recovery/scenes/prefab-root-name-moves.json")));
   foreach(var item in names.moves){var row=new Finding{asset=item.asset,rendererId=item.root_local_id,result="pass"};nameRows.Add(row);try{var asset=AssetDatabase.LoadAssetAtPath<GameObject>(item.asset.Replace('\\','/'));if(asset==null||asset.name!=item.source_root_name||LocalId(asset)!=item.root_local_id)throw new InvalidOperationException("Original prefab root name/localID not retained");}catch(Exception ex){row.result="fail";row.issue=ex.Message;}}
   var report=new Report{unityVersion=Application.unityVersion,utc=DateTime.UtcNow.ToString("o"),checkedRenderers=rows.Count,checkedPrefabNames=nameRows.Count,failed=rows.Count(r=>r.result!="pass")+nameRows.Count(r=>r.result!="pass"),renderers=rows.ToArray(),prefabNames=nameRows.ToArray()};report.result=report.failed==0&&report.checkedRenderers==195&&report.checkedPrefabNames==32?"pass":"fail";File.WriteAllText(Path.Combine(root,"Recovery/scenes/native-renderer-audit.json"),JsonUtility.ToJson(report,true));code=report.result=="pass"?0:2;code=Math.Max(code,RecoveryShaderAudit.Collect(Path.Combine(root,"Recovery/scenes/shader-audit")));Debug.Log("RECOVERY_MIGRATION_AUDIT_COMPLETE "+report.result+" checked="+rows.Count+" failed="+report.failed);
  }catch(Exception ex){Debug.LogException(ex);}finally{if(Application.isBatchMode)EditorApplication.Exit(code);}
 }
}}

