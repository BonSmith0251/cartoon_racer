// Opt-in standalone smoke evidence; inactive unless -recoverySmoke <directory>.
using System;
using System.IO;
using System.Collections;
using System.Linq;
using System.Reflection;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace CartoonRacerRecovery {
public sealed class RecoveryRuntimeEvidence : MonoBehaviour {
 string output;StreamWriter writer;int errors;bool ending;float started;
 [Serializable] class Event {public string kind,utc,scene,message;public float time;public int sceneCount,objects,cameras,audioSources,rigidbodies,errors;public Vector3[] carPositions;public float[] carSpeeds;}
 [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
 static void Boot(){
  string[] args=Environment.GetCommandLineArgs();int index=Array.IndexOf(args,"-recoverySmoke");if(index<0||index+1>=args.Length)return;
  if(Application.companyName!="CartoonRacerRecovery"||Application.productName!="CartoonRacerRecon Validation"){Debug.LogError("Recovery smoke refused: original save identity");return;}
  Application.runInBackground=true;
  var go=new GameObject("Recovery runtime evidence (opt-in)");DontDestroyOnLoad(go);var self=go.AddComponent<RecoveryRuntimeEvidence>();self.output=Path.GetFullPath(args[index+1]);Directory.CreateDirectory(self.output);self.writer=new StreamWriter(Path.Combine(self.output,"runtime.jsonl")){AutoFlush=true};self.started=Time.realtimeSinceStartup;Application.logMessageReceived+=self.OnLog;SceneManager.sceneLoaded+=self.OnScene;
  self.Record("startup","persistentDataPath="+Application.persistentDataPath);self.StartCoroutine(self.Smoke());
 }
 void OnLog(string condition,string stack,LogType type){if(type==LogType.Error||type==LogType.Exception||type==LogType.Assert){errors++;Record("error",condition+"\n"+stack);}}
 void OnScene(Scene scene,LoadSceneMode mode){Record("scene-loaded",scene.path+" "+mode);StartCoroutine(CaptureAfter(scene.name));}
 void Record(string kind,string message){
  if(writer==null)return;
  var bodies=FindObjectsByType<Rigidbody>(FindObjectsInactive.Include,FindObjectsSortMode.None).Where(b=>b.gameObject.layer==8||b.gameObject.layer==12).Take(100).ToArray();
  var row=new Event{kind=kind,utc=DateTime.UtcNow.ToString("o"),scene=SceneManager.GetActiveScene().name,message=message,time=Time.realtimeSinceStartup-started,sceneCount=SceneManager.sceneCount,objects=FindObjectsByType<Transform>(FindObjectsInactive.Include,FindObjectsSortMode.None).Length,cameras=Camera.allCamerasCount,audioSources=FindObjectsByType<AudioSource>(FindObjectsInactive.Include,FindObjectsSortMode.None).Length,rigidbodies=bodies.Length,carPositions=bodies.Select(b=>b.position).ToArray(),carSpeeds=bodies.Select(b=>b.velocity.magnitude).ToArray(),errors=errors};
  writer.WriteLine(JsonUtility.ToJson(row));
 }
 IEnumerator CaptureAfter(string label){yield return new WaitForSecondsRealtime(3);yield return new WaitForEndOfFrame();if(SystemInfo.graphicsDeviceType!=UnityEngine.Rendering.GraphicsDeviceType.Null)ScreenCapture.CaptureScreenshot(Path.Combine(output,Mathf.RoundToInt(Time.realtimeSinceStartup-started)+"-"+label+".png"));Record("snapshot",label);}
 MonoBehaviour FindMenu(){return FindObjectsByType<MonoBehaviour>(FindObjectsInactive.Include,FindObjectsSortMode.None).FirstOrDefault(b=>b!=null&&b.GetType().FullName=="MENU_MANAGER");}
 bool Invoke(MonoBehaviour target,string method){try{if(target==null)throw new InvalidOperationException("MENU_MANAGER missing");var m=target.GetType().GetMethod(method,BindingFlags.Public|BindingFlags.Instance);if(m==null)throw new MissingMethodException(method);m.Invoke(target,null);Record("action",method);return true;}catch(Exception ex){errors++;Record("action-failed",method+": "+ex);return false;}}
 IEnumerator Smoke(){
  yield return new WaitForSecondsRealtime(4);yield return StartCoroutine(CaptureAfter("initial-menu"));
  var menu=FindMenu();
  if(menu!=null&&!menu.enabled){if(Invoke(menu,"SELECT_ENG_"))Invoke(menu,"CONTINUE");yield return new WaitForSecondsRealtime(5);menu=FindMenu();}
  Record("menu-initialized",menu?"MENU_MANAGER enabled="+menu.enabled:"MENU_MANAGER absent");
  yield return StartCoroutine(CaptureAfter("menu-ready"));
  if(Invoke(menu,"PLAY_BUTTON")){yield return new WaitForSecondsRealtime(12);yield return StartCoroutine(CaptureAfter("gameplay"));for(int i=0;i<5;i++){Record("gameplay-sample","No artificial driving input applied");yield return new WaitForSecondsRealtime(1);}}
  Record("complete","Startup/menu/action/additive scene smoke only; no assertion of whole-game fidelity");
  ending=true;writer.Dispose();writer=null;Application.Quit(errors==0?0:2);
 }
 void OnDestroy(){Application.logMessageReceived-=OnLog;SceneManager.sceneLoaded-=OnScene;if(writer!=null){if(!ending)Record("interrupted","Destroyed before smoke completion");writer.Dispose();writer=null;}}
}}

