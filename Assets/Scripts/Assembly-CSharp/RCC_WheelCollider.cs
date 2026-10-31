using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[AddComponentMenu("BoneCracker Games/Realistic Car Controller/Main/RCC Wheel Collider")]
[RequireComponent(typeof(WheelCollider))]
public class RCC_WheelCollider : MonoBehaviour
{
	public bool AI;

	public AudioSource GRASS_SKID;

	public AudioSource ASPHALT_SKID;

	private RCC_Settings RCCSettingsInstance;

	private RCC_GroundMaterials RCCGroundMaterialsInstance;

	private WheelCollider _wheelCollider;

	private RCC_CarControllerV3 carController;

	private Rigidbody rigid;

	private List<RCC_WheelCollider> allWheelColliders = new List<RCC_WheelCollider>();

	public Transform wheelModel;

	private float wheelRotation;

	public float camber;

	internal float wheelRPMToSpeed;

	public RCC_Skidmarks skidmarks;

	public RCC_Skidmarks skidmarks2;

	private float startSlipValue = 0.25f;

	private int lastSkidmark1 = -1;

	private int lastSkidmark2 = -1;

	private float wheelSlipAmountForward;

	private float wheelSlipAmountSideways;

	internal float totalSlip;

	public WheelFrictionCurve forwardFrictionCurve;

	public WheelFrictionCurve sidewaysFrictionCurve;

	private AudioSource audioSource;

	private AudioClip audioClip;

	internal List<ParticleSystem> allWheelParticles = new List<ParticleSystem>();

	internal ParticleSystem.EmissionModule emission;

	internal float tractionHelpedSidewaysStiffness = 1f;

	private float minForwardStiffness = 0.75f;

	private float maxForwardStiffness = 1f;

	private float minSidewaysStiffness = 0.75f;

	private float maxSidewaysStiffness = 1f;

	private TerrainData mTerrainData;

	private int alphamapWidth;

	private int alphamapHeight;

	private float[,,] mSplatmapData;

	private float mNumTextures;

	private RCC_Settings RCCSettings
	{
		get
		{
			if (RCCSettingsInstance == null)
			{
				RCCSettingsInstance = RCC_Settings.Instance;
			}
			return RCCSettingsInstance;
		}
	}

	private RCC_GroundMaterials RCCGroundMaterials
	{
		get
		{
			if (RCCGroundMaterialsInstance == null)
			{
				RCCGroundMaterialsInstance = RCC_GroundMaterials.Instance;
			}
			return RCCGroundMaterialsInstance;
		}
	}

	public WheelCollider wheelCollider
	{
		get
		{
			if (_wheelCollider == null)
			{
				_wheelCollider = GetComponent<WheelCollider>();
			}
			return _wheelCollider;
		}
	}

	private RCC_GroundMaterials physicsMaterials => RCCGroundMaterials;

	private RCC_GroundMaterials.GroundMaterialFrictions[] physicsFrictions => RCCGroundMaterials.frictions;

	private void Start()
	{
		if (Application.loadedLevel != 0)
		{
			skidmarks = GameObject.Find("SkidmarksManager_GRASS").GetComponent<RCC_Skidmarks>();
			skidmarks2 = GameObject.Find("SkidmarksManager_ASPHALT").GetComponent<RCC_Skidmarks>();
		}
		carController = GetComponentInParent<RCC_CarControllerV3>();
		rigid = carController.GetComponent<Rigidbody>();
		allWheelColliders = carController.GetComponentsInChildren<RCC_WheelCollider>().ToList();
		wheelCollider.mass = 100f;
		forwardFrictionCurve = wheelCollider.forwardFriction;
		sidewaysFrictionCurve = wheelCollider.sidewaysFriction;
		JointSpring suspensionSpring = wheelCollider.GetComponent<WheelCollider>().suspensionSpring;
		if (AI)
		{
			suspensionSpring.spring = 2500f;
			suspensionSpring.damper = 35000f;
		}
		else
		{
			suspensionSpring.spring = 2500f;
			suspensionSpring.damper = GAME_MANAGER.PLAYER_CONTROL_SUSPENSION;
		}
		wheelCollider.suspensionSpring = suspensionSpring;
		forwardFrictionCurve = SetFrictionCurves(forwardFrictionCurve, 0.2f, 1f, 0.8f, 2f);
		sidewaysFrictionCurve = SetFrictionCurves(sidewaysFrictionCurve, 0.3f, 1f, 0.25f, 2f);
		wheelCollider.forceAppPointDistance = 0f;
		wheelCollider.forwardFriction = forwardFrictionCurve;
		wheelCollider.sidewaysFriction = sidewaysFrictionCurve;
		if (AI)
		{
			return;
		}
		if (!RCCSettings.dontUseAnyParticleEffects)
		{
			for (int i = 0; i < 2; i++)
			{
				GameObject gameObject = Object.Instantiate(RCCGroundMaterials.frictions[i].groundParticles, base.transform.position, base.transform.rotation);
				emission = gameObject.GetComponent<ParticleSystem>().emission;
				emission.enabled = false;
				gameObject.transform.SetParent(base.transform, worldPositionStays: false);
				gameObject.transform.localPosition = Vector3.zero;
				gameObject.transform.localRotation = Quaternion.identity;
				allWheelParticles.Add(gameObject.GetComponent<ParticleSystem>());
			}
		}
		GameObject gameObject2 = new GameObject("Pivot_" + wheelModel.transform.name);
		gameObject2.transform.position = RCC_GetBounds.GetBoundsCenter(wheelModel.transform);
		gameObject2.transform.rotation = base.transform.rotation;
		gameObject2.transform.SetParent(wheelModel.transform.parent, worldPositionStays: true);
		wheelModel.SetParent(gameObject2.transform, worldPositionStays: true);
		wheelModel = gameObject2.transform;
	}

	private void Update()
	{
		WheelAlign();
		if (!carController.isSleeping)
		{
		}
	}

	private void FixedUpdate()
	{
		if (carController.isSleeping)
		{
			return;
		}
		wheelRPMToSpeed = wheelCollider.rpm * wheelCollider.radius / 2.9f * rigid.transform.lossyScale.y;
		switch (carController._wheelTypeChoise)
		{
		case RCC_CarControllerV3.WheelType.FWD:
			if (this == carController.FrontLeftWheelCollider || this == carController.FrontRightWheelCollider)
			{
				ApplyMotorTorque(carController.engineTorque);
			}
			break;
		case RCC_CarControllerV3.WheelType.RWD:
			if (this == carController.RearLeftWheelCollider || this == carController.RearRightWheelCollider)
			{
				ApplyMotorTorque(carController.engineTorque);
			}
			break;
		case RCC_CarControllerV3.WheelType.AWD:
			ApplyMotorTorque(carController.engineTorque);
			break;
		case RCC_CarControllerV3.WheelType.BIASED:
			if (this == carController.FrontLeftWheelCollider || this == carController.FrontRightWheelCollider)
			{
				ApplyMotorTorque(carController.engineTorque * (100f - carController.biasedWheelTorque) / 100f);
			}
			if (this == carController.RearLeftWheelCollider || this == carController.RearRightWheelCollider)
			{
				ApplyMotorTorque(carController.engineTorque * carController.biasedWheelTorque / 100f);
			}
			break;
		}
		if (carController.ExtraRearWheelsCollider.Length > 0 && carController.applyEngineTorqueToExtraRearWheelColliders)
		{
			for (int i = 0; i < carController.ExtraRearWheelsCollider.Length; i++)
			{
				if (this == carController.ExtraRearWheelsCollider[i])
				{
					ApplyMotorTorque(carController.engineTorque);
				}
			}
		}
		if (this == carController.FrontLeftWheelCollider || this == carController.FrontRightWheelCollider)
		{
			ApplySteering();
		}
		if (carController.handbrakeInput > 0.5f)
		{
			if (this == carController.RearLeftWheelCollider || this == carController.RearRightWheelCollider)
			{
				ApplyBrakeTorque(carController.brakeTorque * 1f * carController.handbrakeInput);
			}
		}
		else if (this == carController.FrontLeftWheelCollider || this == carController.FrontRightWheelCollider)
		{
			ApplyBrakeTorque(carController.brakeTorque * Mathf.Clamp(carController._brakeInput, 0f, 1f));
		}
		else
		{
			ApplyBrakeTorque(carController.brakeTorque * (Mathf.Clamp(carController._brakeInput, 0f, 1f) / 2f));
		}
		if (carController.ESP && carController.handbrakeInput < 0.5f)
		{
			if (carController.underSteering)
			{
				if (this == carController.FrontLeftWheelCollider)
				{
					ApplyBrakeTorque(carController.brakeTorque * carController.ESPStrength * Mathf.Clamp(0f - carController.rearSlip, 0f, float.PositiveInfinity));
				}
				if (this == carController.FrontRightWheelCollider)
				{
					ApplyBrakeTorque(carController.brakeTorque * carController.ESPStrength * Mathf.Clamp(carController.rearSlip, 0f, float.PositiveInfinity));
				}
			}
			if (carController.overSteering)
			{
				if (this == carController.RearLeftWheelCollider)
				{
					ApplyBrakeTorque(carController.brakeTorque * carController.ESPStrength * Mathf.Clamp(0f - carController.frontSlip, 0f, float.PositiveInfinity));
				}
				if (this == carController.RearRightWheelCollider)
				{
					ApplyBrakeTorque(carController.brakeTorque * carController.ESPStrength * Mathf.Clamp(carController.frontSlip, 0f, float.PositiveInfinity));
				}
			}
		}
		if (!carController.isSleeping & !AI & !carController.externalController)
		{
			if (Time.frameCount % 15 == 0)
			{
				Frictions();
			}
			if (base.gameObject.transform.position.y < 25.9f)
			{
				GAME_MANAGER.IN_DEEP_WATER = true;
			}
			else
			{
				GAME_MANAGER.IN_DEEP_WATER = false;
			}
			if ((base.gameObject.transform.position.y > 28.3f) & (Application.loadedLevel != 0))
			{
				Audio();
				SkidMarks();
				GAME_MANAGER.IN_WATER = false;
			}
			else
			{
				GAME_MANAGER.IN_WATER = true;
			}
		}
	}

	public void WheelAlign()
	{
		if (!wheelModel)
		{
			Debug.LogError(base.transform.name + " wheel of the " + carController.transform.name + " is missing wheel model. This wheel is disabled");
			base.enabled = false;
			return;
		}
		wheelModel.position = base.transform.position;
		wheelModel.position += base.transform.up * wheelCollider.suspensionDistance;
		wheelRotation += wheelCollider.rpm * 6f * Time.deltaTime;
		wheelModel.rotation = base.transform.rotation * Quaternion.Euler(wheelRotation, wheelCollider.steerAngle, base.transform.rotation.z);
		if (base.transform.localPosition.x > 0f)
		{
			base.transform.localRotation = Quaternion.identity * Quaternion.AngleAxis(camber, Vector3.forward);
		}
		else
		{
			base.transform.localRotation = Quaternion.identity * Quaternion.AngleAxis(0f - camber, Vector3.forward);
		}
	}

	private void SkidMarks()
	{
		wheelCollider.GetGroundHit(out var hit);
		wheelSlipAmountForward = Mathf.Abs(hit.forwardSlip);
		wheelSlipAmountSideways = Mathf.Abs(hit.sidewaysSlip);
		totalSlip = Mathf.Lerp(totalSlip, wheelSlipAmountSideways + wheelSlipAmountForward, Time.fixedDeltaTime * 3f) / 1f;
		if (wheelSlipAmountSideways + wheelSlipAmountForward > startSlipValue)
		{
			Vector3 pos = hit.point + 2f * rigid.velocity * Time.deltaTime;
			if ((rigid.velocity.magnitude > 0.5f) & (RCC_CarControllerV3.SPEED > 20f))
			{
				if (hit.collider.material.name == "RCCAsphaltPhysics (Instance)")
				{
					lastSkidmark2 = skidmarks2.AddSkidMark(pos, hit.normal, totalSlip, lastSkidmark2);
					ASPHALT_SKID.mute = false;
				}
				else
				{
					lastSkidmark1 = skidmarks.AddSkidMark(pos, hit.normal, totalSlip, lastSkidmark1);
					GRASS_SKID.mute = false;
				}
			}
			else
			{
				lastSkidmark1 = -1;
				lastSkidmark2 = -1;
			}
		}
		else
		{
			lastSkidmark1 = -1;
			lastSkidmark2 = -1;
		}
	}

	private void Frictions()
	{
		int num = 1;
		wheelCollider.GetGroundHit(out var hit);
		if (hit.collider != null)
		{
			if (Application.loadedLevel == 5 && ((hit.collider.material.name == "RCCTerrainPhysics (Instance)") & !SCHOOL_MANAGER.SHTRAF))
			{
				SCHOOL_MANAGER.SHTRAF = true;
			}
			if (hit.collider.material.name == "RCCAsphaltPhysics (Instance)")
			{
				num = 0;
			}
		}
		wheelCollider.GetGroundHit(out var _);
		float handbrakeInput = carController.handbrakeInput;
		handbrakeInput = (((!(this == carController.RearLeftWheelCollider) && !(this == carController.RearRightWheelCollider)) || !(handbrakeInput > 0.75f)) ? 1f : 0.75f);
		forwardFrictionCurve.stiffness = physicsFrictions[num].forwardStiffness;
		sidewaysFrictionCurve.stiffness = physicsFrictions[num].sidewaysStiffness * handbrakeInput * tractionHelpedSidewaysStiffness;
		wheelCollider.forwardFriction = forwardFrictionCurve;
		wheelCollider.sidewaysFriction = sidewaysFrictionCurve;
		wheelCollider.wheelDampingRate = physicsFrictions[num].damp;
		if (RCCSettings.dontUseAnyParticleEffects)
		{
			return;
		}
		for (int i = 0; i < allWheelParticles.Count; i++)
		{
			if (totalSlip > physicsFrictions[num].slip)
			{
				if (i != num)
				{
					ParticleSystem.EmissionModule emissionModule = allWheelParticles[i].emission;
					emissionModule.enabled = false;
				}
				else
				{
					ParticleSystem.EmissionModule emissionModule2 = allWheelParticles[i].emission;
					emissionModule2.enabled = true;
				}
			}
			else
			{
				ParticleSystem.EmissionModule emissionModule3 = allWheelParticles[i].emission;
				emissionModule3.enabled = false;
			}
			if (carController.speed < 10f || base.gameObject.transform.position.y < 28.8f)
			{
				ParticleSystem.EmissionModule emissionModule4 = allWheelParticles[i].emission;
				emissionModule4.enabled = false;
			}
		}
	}

	private void Drift()
	{
		wheelCollider.GetGroundHit(out var hit);
		Vector3 vector = base.transform.InverseTransformDirection(rigid.velocity);
		float num = vector.x * vector.x / 10f;
		num += Mathf.Abs(hit.forwardSlip * hit.forwardSlip) * 0.5f;
		if (wheelCollider == carController.FrontLeftWheelCollider.wheelCollider || wheelCollider == carController.FrontRightWheelCollider.wheelCollider)
		{
			forwardFrictionCurve.extremumValue = Mathf.Clamp(1f - num, 0.1f, maxForwardStiffness);
			forwardFrictionCurve.asymptoteValue = Mathf.Clamp(0.75f - num / 2f, 0.1f, minForwardStiffness);
		}
		else
		{
			forwardFrictionCurve.extremumValue = Mathf.Clamp(1f - num, 1f, maxForwardStiffness);
			forwardFrictionCurve.asymptoteValue = Mathf.Clamp(0.75f - num / 2f, 1.2f, minForwardStiffness);
		}
		if (wheelCollider == carController.FrontLeftWheelCollider.wheelCollider || wheelCollider == carController.FrontRightWheelCollider.wheelCollider)
		{
			sidewaysFrictionCurve.extremumValue = Mathf.Clamp(1f - num / 1f, 0.5f, maxSidewaysStiffness);
			sidewaysFrictionCurve.asymptoteValue = Mathf.Clamp(0.75f - num / 2f, 0.5f, minSidewaysStiffness);
		}
		else
		{
			sidewaysFrictionCurve.extremumValue = Mathf.Clamp(1f - num, 0.5f, maxSidewaysStiffness);
			sidewaysFrictionCurve.asymptoteValue = Mathf.Clamp(0.75f - num / 2f, 0.5f, minSidewaysStiffness);
		}
	}

	private void Audio()
	{
		if (totalSlip < startSlipValue - 0.05f)
		{
			GRASS_SKID.mute = true;
			ASPHALT_SKID.mute = true;
		}
		if (RCC_CarControllerV3.SPEED < 5f)
		{
			GRASS_SKID.mute = true;
			ASPHALT_SKID.mute = true;
		}
	}

	private bool isSkidding()
	{
		for (int i = 0; i < allWheelColliders.Count; i++)
		{
			if (allWheelColliders[i].totalSlip > startSlipValue)
			{
				return true;
			}
		}
		return false;
	}

	private void ApplyMotorTorque(float torque)
	{
		if (carController.TCS)
		{
			wheelCollider.GetGroundHit(out var hit);
			if (Mathf.Abs(wheelCollider.rpm) >= 100f)
			{
				if (hit.forwardSlip > startSlipValue)
				{
					carController.TCSAct = true;
					torque -= Mathf.Clamp(torque * hit.forwardSlip * carController.TCSStrength, 0f, carController.engineTorque);
				}
				else
				{
					carController.TCSAct = false;
					torque += Mathf.Clamp(torque * hit.forwardSlip * carController.TCSStrength, 0f - carController.engineTorque, 0f);
				}
			}
			else
			{
				carController.TCSAct = false;
			}
		}
		if (OverTorque())
		{
			torque = 0f;
		}
		wheelCollider.motorTorque = torque * (1f - carController.clutchInput) * carController._boostInput * 2f * carController._gasInput * (carController.engineTorqueCurve[carController.currentGear].Evaluate(wheelRPMToSpeed * (float)carController.direction) * (float)carController.direction);
	}

	public void ApplySteering()
	{
		wheelCollider.steerAngle = Mathf.Clamp(carController.steerAngle * carController._steerInput, 0f - carController.steerAngle, carController.steerAngle);
	}

	private void ApplyBrakeTorque(float brake)
	{
		if (carController.ABS && carController.handbrakeInput <= 0.1f)
		{
			wheelCollider.GetGroundHit(out var hit);
			if (Mathf.Abs(hit.forwardSlip) * Mathf.Clamp01(brake) >= carController.ABSThreshold)
			{
				carController.ABSAct = true;
				brake = 0f;
			}
			else
			{
				carController.ABSAct = false;
			}
		}
		wheelCollider.brakeTorque = brake;
	}

	private bool OverTorque()
	{
		if (carController.speed > carController.maxspeed || !carController.engineRunning)
		{
			return true;
		}
		return false;
	}

	private void GetTerrainData()
	{
	}

	private int GetGroundMaterialIndex()
	{
		bool flag = false;
		wheelCollider.GetGroundHit(out var hit);
		if (hit.point == Vector3.zero)
		{
			return 0;
		}
		int result = 0;
		for (int i = 0; i < physicsFrictions.Length; i++)
		{
			if (hit.collider.sharedMaterial == physicsFrictions[i].groundMaterial)
			{
				flag = true;
				result = i;
			}
		}
		return result;
	}

	public WheelFrictionCurve SetFrictionCurves(WheelFrictionCurve curve, float extremumSlip, float extremumValue, float asymptoteSlip, float asymptoteValue)
	{
		WheelFrictionCurve result = curve;
		result.extremumSlip = extremumSlip;
		result.extremumValue = extremumValue;
		result.asymptoteSlip = asymptoteSlip;
		result.asymptoteValue = asymptoteValue;
		return result;
	}
}
