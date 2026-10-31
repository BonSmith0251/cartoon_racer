using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
namespace CartoonRacerRecovery {
public static class RecoveryShaderAudit {
 [Serializable] class Message {public string message,details,platform,severity;public int line;}
 [Serializable] class Row {public string path,name;public bool hasError,supported;public Message[] messages;}
 [Serializable] class Report {public string unityVersion,utc,graphics;public int shaders,errors;public Row[] results;}
 public static int Collect(string output) {
  var rows=new List<Row>();foreach(string guid in AssetDatabase.FindAssets("t:Shader")){string path=AssetDatabase.GUIDToAssetPath(guid);if(!path.StartsWith("Assets/"))continue;var shader=AssetDatabase.LoadAssetAtPath<Shader>(path);if(shader==null)continue;
   var messages=ShaderUtil.GetShaderMessages(shader).Select(m=>new Message{message=m.message,details=m.messageDetails,platform=m.platform.ToString(),severity=m.severity.ToString(),line=m.line}).ToArray();
   rows.Add(new Row{path=path,name=shader.name,hasError=ShaderUtil.ShaderHasError(shader),supported=shader.isSupported,messages=messages});
  }
  Directory.CreateDirectory(output);
  var report=new Report{unityVersion=Application.unityVersion,utc=DateTime.UtcNow.ToString("o"),graphics=SystemInfo.graphicsDeviceType.ToString(),shaders=rows.Count,errors=rows.Count(r=>r.hasError),results=rows.ToArray()};File.WriteAllText(Path.Combine(output,"shader-report.json"),JsonUtility.ToJson(report,true));Debug.Log("RECOVERY_SHADER_AUDIT_COMPLETE errors="+report.errors);return report.errors==0?0:2;
 }
 public static void Run(){
  int code=1;try{string[] args=Environment.GetCommandLineArgs();int i=Array.IndexOf(args,"-recoveryReport");string output=i>=0&&i+1<args.Length?args[i+1]:Path.GetFullPath(Application.dataPath+"/../Recovery/scenes/shader-audit");code=Collect(output);}catch(Exception ex){Debug.LogException(ex);}finally{if(Application.isBatchMode)EditorApplication.Exit(code);}
 }
}}

