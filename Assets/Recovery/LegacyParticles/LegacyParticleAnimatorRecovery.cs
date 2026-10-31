using UnityEngine;
namespace CartoonRacerRecovery {
[DisallowMultipleComponent]
public sealed class LegacyParticleAnimatorRecovery : MonoBehaviour {
 [HideInInspector] public string sourceYamlBase64;
 [TextArea] public string configJson;
 [System.Serializable] public class Settings { public bool animateColor,autoDestroy,stopSimulation;public uint[] colors;public Vector3 worldRotationAxis,localRotationAxis,rndForce,force;public float sizeGrow,damping; }
 public Settings Read(){return JsonUtility.FromJson<Settings>(configJson);}
}}
