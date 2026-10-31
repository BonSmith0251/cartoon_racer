using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
namespace CartoonRacerRecovery {
public static class TerrainMaterialAudit {
 [Serializable] public class Layer {public string name,path,diffuse,normal;public Vector2 tileSize,tileOffset;public float metallic,smoothness;public Color specular;}
 [Serializable] public class Data {public string name,path;public int layers,alphaResolution,baseResolution;public string[] alphaTextures;public Layer[] layerData;}
 [Serializable] public class Binding {public string asset,objectName,dataPath,material,materialPath,shader;public bool shaderSupported;public Color specular;public float shininess;}
 [Serializable] public class Report {public string unity;public List<Data> terrains=new List<Data>();public List<Binding> bindings=new List<Binding>();public List<string> errors=new List<string>();}
 static Report r=new Report();
 static void Read(Terrain t,string asset){var m=t.materialTemplate;r.bindings.Add(new Binding{asset=asset,objectName=t.name,dataPath=AssetDatabase.GetAssetPath(t.terrainData),material=m?m.name:"<null>",materialPath=AssetDatabase.GetAssetPath(m),shader=m&&m.shader?m.shader.name:"<default>",shaderSupported=m&&m.shader&&m.shader.isSupported,specular=m&&m.HasProperty("_SpecColor")?m.GetColor("_SpecColor"):Color.clear,shininess=m&&m.HasProperty("_Shininess")?m.GetFloat("_Shininess"):-1});}
 public static void Run(){int result=1;try{r.unity=Application.unityVersion;foreach(string g in AssetDatabase.FindAssets("t:TerrainData",new[]{"Assets/TerrainData"})){string p=AssetDatabase.GUIDToAssetPath(g);var d=AssetDatabase.LoadAssetAtPath<TerrainData>(p);var row=new Data{name=d.name,path=p,layers=d.terrainLayers.Length,alphaResolution=d.alphamapResolution,baseResolution=d.baseMapResolution};try{row.alphaTextures=d.alphamapTextures.Select(t=>t?t.name+":"+t.width+"x"+t.height:"<missing>").ToArray();}catch(Exception e){r.errors.Add(p+": "+e.Message);}row.layerData=d.terrainLayers.Select(l=>l?new Layer{name=l.name,path=AssetDatabase.GetAssetPath(l),diffuse=AssetDatabase.GetAssetPath(l.diffuseTexture),normal=AssetDatabase.GetAssetPath(l.normalMapTexture),tileSize=l.tileSize,tileOffset=l.tileOffset,metallic=l.metallic,smoothness=l.smoothness,specular=l.specular}:new Layer{name="<missing>"}).ToArray();r.terrains.Add(row);}
 foreach(string p in new[]{"Assets/MENU.unity","Assets/BENCHMARK.unity","Assets/SCHOOL.unity"}){var s=EditorSceneManager.OpenScene(p,OpenSceneMode.Single);foreach(var go in s.GetRootGameObjects())foreach(var t in go.GetComponentsInChildren<Terrain>(true))Read(t,p);}
 foreach(string p in new[]{"Assets/GameObject/CITY_TERRAIN.prefab","Assets/GameObject/FARM_TERRAIN.prefab"}){var go=PrefabUtility.LoadPrefabContents(p);try{foreach(var t in go.GetComponentsInChildren<Terrain>(true))Read(t,p);}finally{PrefabUtility.UnloadPrefabContents(go);}}
 File.WriteAllText("Recovery/terrain-check/editor-terrain-audit.json",JsonUtility.ToJson(r,true));Debug.Log("TERRAIN_AUDIT_COMPLETE terrains="+r.terrains.Count+" bindings="+r.bindings.Count);result=0;
 }catch(Exception e){Debug.LogException(e);}finally{EditorApplication.Exit(result);}}
}}
