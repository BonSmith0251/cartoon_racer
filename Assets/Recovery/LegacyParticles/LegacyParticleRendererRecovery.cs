using UnityEngine;
namespace CartoonRacerRecovery {
[DisallowMultipleComponent]
public sealed class LegacyParticleRendererRecovery : MonoBehaviour {
 [HideInInspector] public string sourceYamlBase64;
 [TextArea] public string configJson;
 public Material[] materials;
 [System.Serializable] public class Settings {public bool enabled;public int stretch,sortingOrder,sortingLayerId,xTile,yTile;public float lengthScale,velocityScale,maxParticleSize,cycles;}
 public Settings Read(){return JsonUtility.FromJson<Settings>(configJson);}
}}
