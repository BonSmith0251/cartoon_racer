// Install in Assets/Editor only after source/export GUIDs are stable.
// Read-only scene/prefab audit: does not save or repair source assets.
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEditor.Build.Reporting;
using UnityEngine.SceneManagement;
namespace CartoonRacerRecovery
{
    public static class ReconstructionAudit
    {
        static StreamWriter graph, references, issues;
        static int missingScripts, missingReferences, invalidEvents, failedAssets;
        static long objectCount, componentCount;
        static bool fullValues;
        [Serializable] class RefId { public string assetGuid, localId, globalId, name, type; }
        [Serializable] class ComponentRow { public string owner, type, id, values; public int order; public bool enabled; }
        [Serializable] class ObjectRow { public string scope, name, id, parent, tag; public int sibling, layer, staticFlags; public bool active; public Vector3 position, scale; public Quaternion rotation; public bool isRectTransform; public Vector2 anchorMin, anchorMax, anchoredPosition, sizeDelta, pivot; }
        [Serializable] class RefRow { public string scope, owner, component, property, state; public RefId target; }
        [Serializable] class Issue { public string scope, owner, type, message; }
        [Serializable] class Scope { public string path, kind; public long objects, components; public int missingScripts, missingReferences, invalidEvents; }
        [Serializable] class Report { public string schema = "cartoon-racer-editor-audit/1", unityVersion, project, utc, result; public long objects, components; public int missingScripts, missingReferenceCandidates, invalidUnityEvents, failedAssets; public bool fullValues; public Scope[] scopes; public string[] buildScenes; }
        static string Arg(string name, string fallback) { var args=Environment.GetCommandLineArgs(); int i=Array.IndexOf(args,name); return i>=0 && i+1<args.Length?args[i+1]:fallback; }
        static string Id(UnityEngine.Object obj) { return obj == null ? null : GlobalObjectId.GetGlobalObjectIdSlow(obj).ToString(); }
        static RefId Identify(UnityEngine.Object obj) {
            if(obj==null)return null;
            string guid;long local;AssetDatabase.TryGetGUIDAndLocalFileIdentifier(obj,out guid,out local);
            return new RefId { assetGuid=guid,localId=local.ToString(System.Globalization.CultureInfo.InvariantCulture),globalId=Id(obj),name=obj.name,type=obj.GetType().AssemblyQualifiedName };
        }
        static void Write(StreamWriter w, object row) { w.WriteLine(JsonUtility.ToJson(row)); }
        static void Problem(string scope,string owner,string type,string message) { Write(issues,new Issue{scope=scope,owner=owner,type=type,message=message}); }
        static void Inspect(GameObject go,string scope) {
            objectCount++;Transform t=go.transform;RectTransform rt=t as RectTransform;
            var row=new ObjectRow{scope=scope,name=go.name,id=Id(go),parent=Id(t.parent? t.parent.gameObject:null),sibling=t.GetSiblingIndex(),layer=go.layer,tag=go.tag,active=go.activeSelf,staticFlags=(int)GameObjectUtility.GetStaticEditorFlags(go),position=t.localPosition,rotation=t.localRotation,scale=t.localScale,isRectTransform=rt!=null};
            if(rt!=null){row.anchorMin=rt.anchorMin;row.anchorMax=rt.anchorMax;row.anchoredPosition=rt.anchoredPosition;row.sizeDelta=rt.sizeDelta;row.pivot=rt.pivot;}
            Write(graph,row);Component[] cs=go.GetComponents<Component>();
            for(int order=0;order<cs.Length;order++){
                Component c=cs[order];componentCount++;
                if(c==null){missingScripts++;Problem(scope,row.id,"missing-script","Null component in slot "+order);continue;}
                try{
                    Behaviour behavior=c as Behaviour;Renderer renderer=c as Renderer;Collider collider=c as Collider;
                    Write(graph,new ComponentRow{owner=row.id,type=c.GetType().AssemblyQualifiedName,id=Id(c),order=order,enabled=behavior!=null?behavior.enabled:renderer!=null?renderer.enabled:collider==null||collider.enabled,values=fullValues?EditorJsonUtility.ToJson(c):null});
                    using(var serialized=new SerializedObject(c)){
                        SerializedProperty p=serialized.GetIterator();
                        while(p.Next(true)){
                            if(p.propertyType==SerializedPropertyType.ObjectReference){
                                var target=p.objectReferenceValue;
                                string state=target!=null?"resolved":p.objectReferenceInstanceIDValue!=0?"missing-candidate":"null-or-source-unresolved";
                                if(state=="missing-candidate"){missingReferences++;Problem(scope,row.id,"missing-reference-candidate",c.GetType().FullName+"."+p.propertyPath);}
                                Write(references,new RefRow{scope=scope,owner=row.id,component=Id(c),property=p.propertyPath,state=state,target=Identify(target)});
                            }
                            if(p.isArray && p.propertyPath.EndsWith(".m_PersistentCalls.m_Calls",StringComparison.Ordinal)){
                                for(int n=0;n<p.arraySize;n++){
                                    var call=p.GetArrayElementAtIndex(n);var method=call.FindPropertyRelative("m_MethodName");var target=call.FindPropertyRelative("m_Target");var callState=call.FindPropertyRelative("m_CallState");
                                    if(method==null||target==null||string.IsNullOrEmpty(method.stringValue)||(callState!=null&&callState.intValue==0))continue;
                                    var obj=target.objectReferenceValue;
                                    if(obj==null || !obj.GetType().GetMethods(BindingFlags.Instance|BindingFlags.Public|BindingFlags.NonPublic).Any(m=>m.Name==method.stringValue)){
                                        invalidEvents++;Problem(scope,row.id,"invalid-unityevent",p.propertyPath+"["+n+"] target/method missing: "+method.stringValue);
                                    }
                                }
                            }
                        }
                    }
                }catch(Exception ex){failedAssets++;Problem(scope,row.id,"component-audit-failure",c.GetType().FullName+": "+ex);}
            }
            for(int i=0;i<t.childCount;i++)Inspect(t.GetChild(i).gameObject,scope);
        }
        static Scope Start(string path,string kind){return new Scope{path=path,kind=kind,objects=-objectCount,components=-componentCount,missingScripts=-missingScripts,missingReferences=-missingReferences,invalidEvents=-invalidEvents};}
        static void Finish(Scope s){s.objects+=objectCount;s.components+=componentCount;s.missingScripts+=missingScripts;s.missingReferences+=missingReferences;s.invalidEvents+=invalidEvents;}
        public static void Run() {
            int exitCode=1;string output=Path.GetFullPath(Arg("-recoveryReport",Path.Combine(Application.dataPath,"../RecoveryReports")));
            Directory.CreateDirectory(output);fullValues=Environment.GetCommandLineArgs().Contains("-recoveryFullValues");
            var scopes=new List<Scope>();SceneSetup[] setup=EditorSceneManager.GetSceneManagerSetup();
            try{
                using(graph=new StreamWriter(Path.Combine(output,"structure.jsonl")))
                using(references=new StreamWriter(Path.Combine(output,"references.jsonl")))
                using(issues=new StreamWriter(Path.Combine(output,"issues.jsonl"))){
                    var scenes=AssetDatabase.FindAssets("t:Scene").Select(AssetDatabase.GUIDToAssetPath).Where(p=>p.StartsWith("Assets/",StringComparison.Ordinal)).OrderBy(p=>p);
                    foreach(string path in scenes){var s=Start(path,"scene");scopes.Add(s);try{var scene=EditorSceneManager.OpenScene(path,OpenSceneMode.Single);foreach(var root in scene.GetRootGameObjects())Inspect(root,path);}catch(Exception ex){failedAssets++;Problem(path,null,"scene-load-failure",ex.ToString());}Finish(s);}
                    foreach(string guid in AssetDatabase.FindAssets("t:Prefab")){string path=AssetDatabase.GUIDToAssetPath(guid);if(!path.StartsWith("Assets/",StringComparison.Ordinal))continue;var s=Start(path,"prefab");scopes.Add(s);GameObject root=null;try{root=PrefabUtility.LoadPrefabContents(path);Inspect(root,path);}catch(Exception ex){failedAssets++;Problem(path,null,"prefab-load-failure",ex.ToString());}finally{if(root!=null)PrefabUtility.UnloadPrefabContents(root);}Finish(s);}
                }
                var report=new Report{unityVersion=Application.unityVersion,project=Path.GetFullPath(Application.dataPath+"/.."),utc=DateTime.UtcNow.ToString("o"),objects=objectCount,components=componentCount,missingScripts=missingScripts,missingReferenceCandidates=missingReferences,invalidUnityEvents=invalidEvents,failedAssets=failedAssets,fullValues=fullValues,scopes=scopes.ToArray(),buildScenes=EditorBuildSettings.scenes.Where(s=>s.enabled).Select(s=>s.path).ToArray()};
                report.result=(missingScripts+missingReferences+invalidEvents+failedAssets)==0?"pass-structural-audit-only":"fail";
                File.WriteAllText(Path.Combine(output,"report.json"),JsonUtility.ToJson(report,true));
                exitCode=report.result=="pass-structural-audit-only"?0:2;
                Debug.Log("RECOVERY_AUDIT_COMPLETE "+report.result+" objects="+objectCount+" components="+componentCount);
            }catch(Exception ex){Debug.LogException(ex);}
            finally{if(!Application.isBatchMode && setup.Length>0)EditorSceneManager.RestoreSceneManagerSetup(setup);if(Application.isBatchMode)EditorApplication.Exit(exitCode);}
        }
        public static void BuildWindows() {
            int code=1;
            try{
                if(PlayerSettings.companyName!="CartoonRacerRecovery" || PlayerSettings.productName!="CartoonRacerRecon Validation")throw new InvalidOperationException("Refusing build until isolated company/product settings are configured to protect original saves.");
                string output=Path.GetFullPath(Arg("-recoveryBuild",Path.Combine(Application.dataPath,"../Build/CartoonRacerRecon.exe")));
                Directory.CreateDirectory(Path.GetDirectoryName(output));
                string[] scenes=EditorBuildSettings.scenes.Where(s=>s.enabled).Select(s=>s.path).ToArray();
                if(scenes.Length!=8 || Path.GetFileNameWithoutExtension(scenes[0])!="MENU")throw new InvalidOperationException("Expected all eight source scenes with MENU as entry.");
                BuildReport report=BuildPipeline.BuildPlayer(new BuildPlayerOptions{scenes=scenes,locationPathName=output,target=BuildTarget.StandaloneWindows64,options=BuildOptions.Development});
                File.WriteAllText(output+".build-result.json",JsonUtility.ToJson(new BuildResult{result=report.summary.result.ToString(),errors=report.summary.totalErrors,warnings=report.summary.totalWarnings,bytes=report.summary.totalSize.ToString(),output=output},true));
                code=report.summary.result==BuildResultEnum()?0:2;
                Debug.Log("RECOVERY_BUILD_COMPLETE "+report.summary.result);
            }catch(Exception ex){Debug.LogException(ex);}finally{if(Application.isBatchMode)EditorApplication.Exit(code);}
        }
        static UnityEditor.Build.Reporting.BuildResult BuildResultEnum(){return UnityEditor.Build.Reporting.BuildResult.Succeeded;}
        [Serializable] class BuildResult { public string result,bytes,output;public int errors,warnings; }
    }
}

