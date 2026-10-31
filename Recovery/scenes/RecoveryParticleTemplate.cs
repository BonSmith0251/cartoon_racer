using System;
using System.IO;
using UnityEngine;
using UnityEditor;
namespace CartoonRacerRecovery {
public static class RecoveryParticleTemplate {
 public static void Generate(){
  int code=1;GameObject go=null;
  try{
   go=new GameObject("Legacy modern particle template");var ps=go.AddComponent<ParticleSystem>();ps.Stop(true,ParticleSystemStopBehavior.StopEmittingAndClear);var main=ps.main;main.playOnAwake=false;main.loop=true;main.startSpeed=0;
   const string asset="Assets/Recovery/LegacyParticleNativeTemplate.prefab";PrefabUtility.SaveAsPrefabAsset(go,asset);AssetDatabase.SaveAssets();File.Copy(asset,Path.GetFullPath("Recovery/scenes/LegacyParticleNativeTemplate.prefab"),true);code=0;Debug.Log("RECOVERY_PARTICLE_TEMPLATE_COMPLETE");
  }catch(Exception ex){Debug.LogException(ex);}finally{if(go!=null)UnityEngine.Object.DestroyImmediate(go);if(Application.isBatchMode)EditorApplication.Exit(code);}
 }
}}

