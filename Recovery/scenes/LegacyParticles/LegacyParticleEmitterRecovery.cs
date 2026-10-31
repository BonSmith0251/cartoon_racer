// Evidence-based translation from Unity 2018 legacy emitter fields.
// Raw source YAML remains serialized. Modern particle behavior is approximate.
using UnityEngine;
namespace CartoonRacerRecovery {
[DisallowMultipleComponent]
public sealed class LegacyParticleEmitterRecovery : MonoBehaviour {
 [HideInInspector] public string sourceYamlBase64;
 [TextArea] public string configJson;
 [System.Serializable] public class Settings { public bool emit,oneShot,worldSpace,randomRotation;public float minSize,maxSize,minEnergy,maxEnergy,minEmission,maxEmission,emitterVelocityScale,angularVelocity,randomAngularVelocity,minEmitterRange;public Vector3 worldVelocity,localVelocity,randomVelocity,tangentVelocity,ellipsoid; }
 public ParticleSystem serializedParticleSystem;
 ParticleSystem recovered;bool initialized;
 void Start(){Initialize();}
 void OnEnable(){if(initialized&&recovered!=null)recovered.Play(true);}
 void OnDisable(){if(recovered!=null)recovered.Stop(true,ParticleSystemStopBehavior.StopEmitting);}
 void Initialize(){
  if(initialized)return;initialized=true;
  if(serializedParticleSystem==null&&GetComponent<ParticleSystem>()!=null){Debug.LogWarning("RECOVERY_LEGACY_PARTICLE_SKIPPED: modern ParticleSystem already present",this);return;}
  var s=JsonUtility.FromJson<Settings>(configJson);
  var animator=GetComponent<LegacyParticleAnimatorRecovery>();var a=animator?animator.Read():null;
  var rendererData=GetComponent<LegacyParticleRendererRecovery>();var r=rendererData?rendererData.Read():null;
  recovered=serializedParticleSystem!=null?serializedParticleSystem:gameObject.AddComponent<ParticleSystem>();recovered.Stop(true,ParticleSystemStopBehavior.StopEmittingAndClear);
  var main=recovered.main;main.playOnAwake=false;main.loop=!s.oneShot;main.duration=Mathf.Max(0.05f,s.maxEnergy);main.startLifetime=new ParticleSystem.MinMaxCurve(s.minEnergy,s.maxEnergy);main.startSize=new ParticleSystem.MinMaxCurve(s.minSize,s.maxSize);main.startSpeed=0;main.maxParticles=Mathf.Max(100,Mathf.CeilToInt(s.maxEmission*s.maxEnergy*2));main.simulationSpace=s.worldSpace?ParticleSystemSimulationSpace.World:ParticleSystemSimulationSpace.Local;main.scalingMode=ParticleSystemScalingMode.Hierarchy;
  if(s.randomRotation)main.startRotation=new ParticleSystem.MinMaxCurve(0,Mathf.PI*2);
  if(a!=null&&a.autoDestroy)main.stopAction=ParticleSystemStopAction.Destroy;
  var shape=recovered.shape;shape.enabled=s.ellipsoid.sqrMagnitude>0;shape.shapeType=ParticleSystemShapeType.Sphere;shape.radius=1;shape.scale=s.ellipsoid;shape.radiusThickness=Mathf.Clamp01(1-s.minEmitterRange);
  var emission=recovered.emission;emission.enabled=s.emit;emission.rateOverTime=s.oneShot?0:new ParticleSystem.MinMaxCurve(s.minEmission,s.maxEmission);
  if(s.oneShot)emission.SetBursts(new[]{new ParticleSystem.Burst(0,(short)Mathf.Clamp(Mathf.RoundToInt(s.minEmission),0,32767),(short)Mathf.Clamp(Mathf.RoundToInt(s.maxEmission),0,32767))});
  var velocity=recovered.velocityOverLifetime;velocity.enabled=true;velocity.space=s.worldSpace?ParticleSystemSimulationSpace.World:ParticleSystemSimulationSpace.Local;
  Vector3 v=s.worldSpace?s.worldVelocity+transform.TransformDirection(s.localVelocity):s.localVelocity+transform.InverseTransformDirection(s.worldVelocity);
  Vector3 rv=s.randomVelocity;velocity.x=new ParticleSystem.MinMaxCurve(v.x-Mathf.Abs(rv.x),v.x+Mathf.Abs(rv.x));velocity.y=new ParticleSystem.MinMaxCurve(v.y-Mathf.Abs(rv.y),v.y+Mathf.Abs(rv.y));velocity.z=new ParticleSystem.MinMaxCurve(v.z-Mathf.Abs(rv.z),v.z+Mathf.Abs(rv.z));
  var inherit=recovered.inheritVelocity;inherit.enabled=s.emitterVelocityScale!=0;inherit.mode=ParticleSystemInheritVelocityMode.Initial;inherit.curve=s.emitterVelocityScale;
  if(s.angularVelocity!=0||s.randomAngularVelocity!=0){var spin=recovered.rotationOverLifetime;spin.enabled=true;spin.z=new ParticleSystem.MinMaxCurve((s.angularVelocity-s.randomAngularVelocity)*Mathf.Deg2Rad,(s.angularVelocity+s.randomAngularVelocity)*Mathf.Deg2Rad);}
  if(a!=null){
   if(a.animateColor&&a.colors!=null&&a.colors.Length>0){
    var keys=new GradientColorKey[a.colors.Length];var alpha=new GradientAlphaKey[a.colors.Length];
    for(int i=0;i<keys.Length;i++){uint q=a.colors[i];var c=new Color32((byte)q,(byte)(q>>8),(byte)(q>>16),(byte)(q>>24));float t=keys.Length<2?0:(float)i/(keys.Length-1);keys[i]=new GradientColorKey(c,t);alpha[i]=new GradientAlphaKey(c.a/255f,t);}
    var gradient=new Gradient();gradient.SetKeys(keys,alpha);var color=recovered.colorOverLifetime;color.enabled=true;color.color=gradient;
   }
   if(a.sizeGrow!=0){float factor=1+a.sizeGrow*(s.minEnergy+s.maxEnergy)/Mathf.Max(.001f,s.minSize+s.maxSize);var size=recovered.sizeOverLifetime;size.enabled=true;size.size=new ParticleSystem.MinMaxCurve(1,AnimationCurve.Linear(0,1,1,Mathf.Max(0,factor)));}
   if(a.force.sqrMagnitude+a.rndForce.sqrMagnitude>0){var force=recovered.forceOverLifetime;force.enabled=true;force.space=ParticleSystemSimulationSpace.World;force.x=new ParticleSystem.MinMaxCurve(a.force.x-Mathf.Abs(a.rndForce.x),a.force.x+Mathf.Abs(a.rndForce.x));force.y=new ParticleSystem.MinMaxCurve(a.force.y-Mathf.Abs(a.rndForce.y),a.force.y+Mathf.Abs(a.rndForce.y));force.z=new ParticleSystem.MinMaxCurve(a.force.z-Mathf.Abs(a.rndForce.z),a.force.z+Mathf.Abs(a.rndForce.z));}
  }
  var target=recovered.GetComponent<ParticleSystemRenderer>();
  if(r!=null){target.enabled=r.enabled;target.sharedMaterials=rendererData.materials;target.sortingLayerID=r.sortingLayerId;target.sortingOrder=r.sortingOrder;target.maxParticleSize=r.maxParticleSize;target.renderMode=r.stretch==4?ParticleSystemRenderMode.HorizontalBillboard:ParticleSystemRenderMode.Billboard;target.sortMode=r.stretch==2?ParticleSystemSortMode.Distance:ParticleSystemSortMode.None;target.lengthScale=r.lengthScale;target.velocityScale=r.velocityScale;
   if(r.xTile>1||r.yTile>1){var uv=recovered.textureSheetAnimation;uv.enabled=true;uv.numTilesX=Mathf.Max(1,r.xTile);uv.numTilesY=Mathf.Max(1,r.yTile);uv.cycleCount=Mathf.Max(1,Mathf.RoundToInt(r.cycles));}
  }
  if(s.emit&&(a==null||!a.stopSimulation))recovered.Play(true);
 }
}}
