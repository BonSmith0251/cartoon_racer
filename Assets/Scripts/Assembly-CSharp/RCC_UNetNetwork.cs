#if CARTOON_RECON_LEGACY_UNET
using System.Collections;
using Unity;
using UnityEngine;
using UnityEngine.Networking;

[AddComponentMenu("BoneCracker Games/Realistic Car Controller/Network/UNet/RCC UNet Network")]
[RequireComponent(typeof(NetworkIdentity))]
public class RCC_UNetNetwork : NetworkBehaviour
{
	public struct VehicleTransform
	{
		public Vector3 position;

		public Quaternion rotation;

		public Vector3 rigidLinearVelocity;

		public Vector3 rigidAngularVelocity;
	}

	public class SyncListVehicleTransform : SyncListStruct<VehicleTransform>
	{
		public override void SerializeItem(NetworkWriter writer, VehicleTransform item)
		{
			writer.Write(item.position);
			writer.Write(item.rotation);
			writer.Write(item.rigidLinearVelocity);
			writer.Write(item.rigidAngularVelocity);
		}

		public override VehicleTransform DeserializeItem(NetworkReader reader)
		{
			VehicleTransform result = default(VehicleTransform);
			result.position = reader.ReadVector3();
			result.rotation = reader.ReadQuaternion();
			result.rigidLinearVelocity = reader.ReadVector3();
			result.rigidAngularVelocity = reader.ReadVector3();
			return result;
		}
	}

	public struct VehicleInput
	{
		public float gasInput;

		public float brakeInput;

		public float steerInput;

		public float handbrakeInput;

		public float boostInput;

		public float clutchInput;

		public float idleInput;

		public int gear;

		public int direction;

		public bool changingGear;

		public float fuelInput;

		public bool engineRunning;

		public bool canGoReverseNow;
	}

	public class SyncListVehicleInput : SyncListStruct<VehicleInput>
	{
		public override void SerializeItem(NetworkWriter writer, VehicleInput item)
		{
			writer.Write(item.gasInput);
			writer.Write(item.brakeInput);
			writer.Write(item.steerInput);
			writer.Write(item.handbrakeInput);
			writer.Write(item.boostInput);
			writer.Write(item.clutchInput);
			writer.Write(item.idleInput);
			writer.WritePackedUInt32((uint)item.gear);
			writer.WritePackedUInt32((uint)item.direction);
			writer.Write(item.changingGear);
			writer.Write(item.fuelInput);
			writer.Write(item.engineRunning);
			writer.Write(item.canGoReverseNow);
		}

		public override VehicleInput DeserializeItem(NetworkReader reader)
		{
			VehicleInput result = default(VehicleInput);
			result.gasInput = reader.ReadSingle();
			result.brakeInput = reader.ReadSingle();
			result.steerInput = reader.ReadSingle();
			result.handbrakeInput = reader.ReadSingle();
			result.boostInput = reader.ReadSingle();
			result.clutchInput = reader.ReadSingle();
			result.idleInput = reader.ReadSingle();
			result.gear = (int)reader.ReadPackedUInt32();
			result.direction = (int)reader.ReadPackedUInt32();
			result.changingGear = reader.ReadBoolean();
			result.fuelInput = reader.ReadSingle();
			result.engineRunning = reader.ReadBoolean();
			result.canGoReverseNow = reader.ReadBoolean();
			return result;
		}
	}

	public struct VehicleConfigurations
	{
		public int gear;

		public int direction;

		public bool changingGear;

		public bool semiAutomaticGear;

		public float fuelInput;

		public bool engineRunning;

		public float[] cambers;

		public bool applyEngineTorqueToExtraRearWheelColliders;

		public RCC_CarControllerV3.WheelType wheelTypeChoise;

		public float biasedWheelTorque;

		public bool canGoReverseNow;

		public float engineTorque;

		public float brakeTorque;

		public float minEngineRPM;

		public float maxEngineRPM;

		public float engineInertia;

		public bool useRevLimiter;

		public bool useExhaustFlame;

		public bool useClutchMarginAtFirstGear;

		public float highspeedsteerAngle;

		public float highspeedsteerAngleAtspeed;

		public float antiRollFrontHorizontal;

		public float antiRollRearHorizontal;

		public float antiRollVertical;

		public float maxspeed;

		public float engineHeat;

		public float engineHeatMultiplier;

		public int totalGears;

		public float gearShiftingDelay;

		public float gearShiftingThreshold;

		public float clutchInertia;

		public bool NGear;

		public float launched;

		public bool ABS;

		public bool TCS;

		public bool ESP;

		public bool steeringHelper;

		public bool tractionHelper;

		public bool applyCounterSteering;

		public bool useNOS;

		public bool useTurbo;
	}

	public class SyncListVehicleConfigurations : SyncListStruct<VehicleConfigurations>
	{
		public override void SerializeItem(NetworkWriter writer, VehicleConfigurations item)
		{
			writer.WritePackedUInt32((uint)item.gear);
			writer.WritePackedUInt32((uint)item.direction);
			writer.Write(item.changingGear);
			writer.Write(item.semiAutomaticGear);
			writer.Write(item.fuelInput);
			writer.Write(item.engineRunning);
			GeneratedNetworkCode._WriteArraySingle_None(writer, item.cambers);
			writer.Write(item.applyEngineTorqueToExtraRearWheelColliders);
			writer.Write((int)item.wheelTypeChoise);
			writer.Write(item.biasedWheelTorque);
			writer.Write(item.canGoReverseNow);
			writer.Write(item.engineTorque);
			writer.Write(item.brakeTorque);
			writer.Write(item.minEngineRPM);
			writer.Write(item.maxEngineRPM);
			writer.Write(item.engineInertia);
			writer.Write(item.useRevLimiter);
			writer.Write(item.useExhaustFlame);
			writer.Write(item.useClutchMarginAtFirstGear);
			writer.Write(item.highspeedsteerAngle);
			writer.Write(item.highspeedsteerAngleAtspeed);
			writer.Write(item.antiRollFrontHorizontal);
			writer.Write(item.antiRollRearHorizontal);
			writer.Write(item.antiRollVertical);
			writer.Write(item.maxspeed);
			writer.Write(item.engineHeat);
			writer.Write(item.engineHeatMultiplier);
			writer.WritePackedUInt32((uint)item.totalGears);
			writer.Write(item.gearShiftingDelay);
			writer.Write(item.gearShiftingThreshold);
			writer.Write(item.clutchInertia);
			writer.Write(item.NGear);
			writer.Write(item.launched);
			writer.Write(item.ABS);
			writer.Write(item.TCS);
			writer.Write(item.ESP);
			writer.Write(item.steeringHelper);
			writer.Write(item.tractionHelper);
			writer.Write(item.applyCounterSteering);
			writer.Write(item.useNOS);
			writer.Write(item.useTurbo);
		}

		public override VehicleConfigurations DeserializeItem(NetworkReader reader)
		{
			VehicleConfigurations result = default(VehicleConfigurations);
			result.gear = (int)reader.ReadPackedUInt32();
			result.direction = (int)reader.ReadPackedUInt32();
			result.changingGear = reader.ReadBoolean();
			result.semiAutomaticGear = reader.ReadBoolean();
			result.fuelInput = reader.ReadSingle();
			result.engineRunning = reader.ReadBoolean();
			result.cambers = GeneratedNetworkCode._ReadArraySingle_None(reader);
			result.applyEngineTorqueToExtraRearWheelColliders = reader.ReadBoolean();
			result.wheelTypeChoise = (RCC_CarControllerV3.WheelType)reader.ReadInt32();
			result.biasedWheelTorque = reader.ReadSingle();
			result.canGoReverseNow = reader.ReadBoolean();
			result.engineTorque = reader.ReadSingle();
			result.brakeTorque = reader.ReadSingle();
			result.minEngineRPM = reader.ReadSingle();
			result.maxEngineRPM = reader.ReadSingle();
			result.engineInertia = reader.ReadSingle();
			result.useRevLimiter = reader.ReadBoolean();
			result.useExhaustFlame = reader.ReadBoolean();
			result.useClutchMarginAtFirstGear = reader.ReadBoolean();
			result.highspeedsteerAngle = reader.ReadSingle();
			result.highspeedsteerAngleAtspeed = reader.ReadSingle();
			result.antiRollFrontHorizontal = reader.ReadSingle();
			result.antiRollRearHorizontal = reader.ReadSingle();
			result.antiRollVertical = reader.ReadSingle();
			result.maxspeed = reader.ReadSingle();
			result.engineHeat = reader.ReadSingle();
			result.engineHeatMultiplier = reader.ReadSingle();
			result.totalGears = (int)reader.ReadPackedUInt32();
			result.gearShiftingDelay = reader.ReadSingle();
			result.gearShiftingThreshold = reader.ReadSingle();
			result.clutchInertia = reader.ReadSingle();
			result.NGear = reader.ReadBoolean();
			result.launched = reader.ReadSingle();
			result.ABS = reader.ReadBoolean();
			result.TCS = reader.ReadBoolean();
			result.ESP = reader.ReadBoolean();
			result.steeringHelper = reader.ReadBoolean();
			result.tractionHelper = reader.ReadBoolean();
			result.applyCounterSteering = reader.ReadBoolean();
			result.useNOS = reader.ReadBoolean();
			result.useTurbo = reader.ReadBoolean();
			return result;
		}
	}

	public struct VehicleLights
	{
		public bool lowBeamHeadLightsOn;

		public bool highBeamHeadLightsOn;

		public RCC_CarControllerV3.IndicatorsOn indicatorsOn;
	}

	public class SyncListVehicleLights : SyncListStruct<VehicleLights>
	{
		public override void SerializeItem(NetworkWriter writer, VehicleLights item)
		{
			writer.Write(item.lowBeamHeadLightsOn);
			writer.Write(item.highBeamHeadLightsOn);
			writer.Write((int)item.indicatorsOn);
		}

		public override VehicleLights DeserializeItem(NetworkReader reader)
		{
			VehicleLights result = default(VehicleLights);
			result.lowBeamHeadLightsOn = reader.ReadBoolean();
			result.highBeamHeadLightsOn = reader.ReadBoolean();
			result.indicatorsOn = (RCC_CarControllerV3.IndicatorsOn)reader.ReadInt32();
			return result;
		}
	}

	private NetworkIdentity networkID;

	private RCC_CarControllerV3 carController;

	private RCC_WheelCollider[] wheelColliders;

	private Rigidbody rigid;

	public SyncListVehicleTransform m_Transform = new SyncListVehicleTransform();

	public SyncListVehicleInput m_Inputs = new SyncListVehicleInput();

	public SyncListVehicleConfigurations m_Configurations = new SyncListVehicleConfigurations();

	public SyncListVehicleLights m_Lights = new SyncListVehicleLights();

	private float updateTime;

	private VehicleInput currentVehicleInputs = default(VehicleInput);

	private VehicleTransform currentVehicleTransform = default(VehicleTransform);

	private VehicleLights currentVehicleLights = default(VehicleLights);

	private bool CB_running;

	private static int kListm_Transform;

	private static int kListm_Inputs;

	private static int kListm_Configurations;

	private static int kListm_Lights;

	private static int kCmdCmdVehicleInputs;

	private static int kCmdCmdVehicleLights;

	private static int kCmdCmdVehicleTransform;

	private static int kCmdCmdVehicleConfigurations;

	private void Start()
	{
		carController = GetComponent<RCC_CarControllerV3>();
		wheelColliders = GetComponentsInChildren<RCC_WheelCollider>();
		rigid = GetComponent<Rigidbody>();
		networkID = GetComponent<NetworkIdentity>();
		if (base.isLocalPlayer)
		{
			carController.externalController = false;
			carController.SetCanControl(state: true);
		}
		else
		{
			carController.externalController = true;
			carController.SetCanControl(state: false);
		}
		base.gameObject.name = base.gameObject.name + networkID.netId;
		currentVehicleTransform = default(VehicleTransform);
	}

	private void FixedUpdate()
	{
		carController.externalController = !base.isLocalPlayer;
		carController.SetCanControl(base.isLocalPlayer);
		if (base.isLocalPlayer)
		{
			if (!CB_running)
			{
				StartCoroutine(VehicleIsMein());
			}
		}
		else
		{
			VehicleIsClient();
		}
	}

	private IEnumerator VehicleIsMein()
	{
		CB_running = true;
		currentVehicleInputs.gasInput = carController.gasInput;
		currentVehicleInputs.brakeInput = carController.brakeInput;
		currentVehicleInputs.steerInput = carController.steerInput;
		currentVehicleInputs.handbrakeInput = carController.handbrakeInput;
		currentVehicleInputs.boostInput = carController.boostInput;
		currentVehicleInputs.clutchInput = carController.clutchInput;
		currentVehicleInputs.idleInput = carController.idleInput;
		currentVehicleInputs.gear = carController.currentGear;
		currentVehicleInputs.direction = carController.direction;
		currentVehicleInputs.changingGear = carController.changingGear;
		currentVehicleInputs.fuelInput = carController.fuelInput;
		currentVehicleInputs.engineRunning = carController.engineRunning;
		currentVehicleInputs.canGoReverseNow = carController.canGoReverseNow;
		CallCmdVehicleInputs(currentVehicleInputs);
		yield return new WaitForSeconds(0.02f);
		currentVehicleLights.lowBeamHeadLightsOn = carController.lowBeamHeadLightsOn;
		currentVehicleLights.highBeamHeadLightsOn = carController.highBeamHeadLightsOn;
		currentVehicleLights.indicatorsOn = carController.indicatorsOn;
		CallCmdVehicleLights(currentVehicleLights);
		yield return new WaitForSeconds(0.02f);
		currentVehicleTransform.position = base.transform.position;
		currentVehicleTransform.rotation = base.transform.rotation;
		currentVehicleTransform.rigidLinearVelocity = rigid.velocity;
		currentVehicleTransform.rigidAngularVelocity = rigid.angularVelocity;
		CallCmdVehicleTransform(currentVehicleTransform);
		yield return new WaitForSeconds(0.02f);
		CB_running = false;
	}

	private void VehicleIsClient()
	{
		if (m_Inputs != null && m_Inputs.Count >= 1)
		{
			carController.gasInput = m_Inputs[0].gasInput;
			carController.brakeInput = m_Inputs[0].brakeInput;
			carController.steerInput = m_Inputs[0].steerInput;
			carController.handbrakeInput = m_Inputs[0].handbrakeInput;
			carController.boostInput = m_Inputs[0].boostInput;
			carController.clutchInput = m_Inputs[0].clutchInput;
			carController.idleInput = m_Inputs[0].idleInput;
			carController.currentGear = m_Inputs[0].gear;
			carController.direction = m_Inputs[0].direction;
			carController.changingGear = m_Inputs[0].changingGear;
			carController.fuelInput = m_Inputs[0].fuelInput;
			carController.engineRunning = m_Inputs[0].engineRunning;
			carController.canGoReverseNow = m_Inputs[0].canGoReverseNow;
		}
		if (m_Lights != null && m_Lights.Count >= 1)
		{
			carController.lowBeamHeadLightsOn = m_Lights[0].lowBeamHeadLightsOn;
			carController.highBeamHeadLightsOn = m_Lights[0].highBeamHeadLightsOn;
			carController.indicatorsOn = m_Lights[0].indicatorsOn;
		}
		if (m_Transform != null && m_Transform.Count >= 1)
		{
			Vector3 b = m_Transform[0].position + m_Transform[0].rigidLinearVelocity * (Time.time - updateTime);
			if (Vector3.Distance(base.transform.position, m_Transform[0].position) < 15f)
			{
				base.transform.position = Vector3.Lerp(base.transform.position, b, Time.deltaTime * 5f);
				base.transform.rotation = Quaternion.Lerp(base.transform.rotation, m_Transform[0].rotation, Time.deltaTime * 5f);
			}
			else
			{
				base.transform.position = m_Transform[0].position;
				base.transform.rotation = m_Transform[0].rotation;
			}
		}
		updateTime = Time.time;
	}

	[Command]
	public void CmdVehicleInputs(VehicleInput _input)
	{
		m_Inputs.Insert(0, _input);
	}

	[Command]
	public void CmdVehicleLights(VehicleLights _input)
	{
		m_Lights.Insert(0, _input);
	}

	[Command]
	public void CmdVehicleTransform(VehicleTransform _input)
	{
		m_Transform.Insert(0, _input);
	}

	[Command]
	public void CmdVehicleConfigurations(VehicleConfigurations _input)
	{
		m_Configurations.Insert(0, _input);
	}

	private void UNetVersion()
	{
	}

	protected static void InvokeSyncListm_Transform(NetworkBehaviour obj, NetworkReader reader)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("SyncList m_Transform called on server.");
		}
		else
		{
			((RCC_UNetNetwork)obj).m_Transform.HandleMsg(reader);
		}
	}

	protected static void InvokeSyncListm_Inputs(NetworkBehaviour obj, NetworkReader reader)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("SyncList m_Inputs called on server.");
		}
		else
		{
			((RCC_UNetNetwork)obj).m_Inputs.HandleMsg(reader);
		}
	}

	protected static void InvokeSyncListm_Configurations(NetworkBehaviour obj, NetworkReader reader)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("SyncList m_Configurations called on server.");
		}
		else
		{
			((RCC_UNetNetwork)obj).m_Configurations.HandleMsg(reader);
		}
	}

	protected static void InvokeSyncListm_Lights(NetworkBehaviour obj, NetworkReader reader)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("SyncList m_Lights called on server.");
		}
		else
		{
			((RCC_UNetNetwork)obj).m_Lights.HandleMsg(reader);
		}
	}

	protected static void InvokeCmdCmdVehicleInputs(NetworkBehaviour obj, NetworkReader reader)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdVehicleInputs called on client.");
		}
		else
		{
			((RCC_UNetNetwork)obj).CmdVehicleInputs(GeneratedNetworkCode._ReadVehicleInput_RCC_UNetNetwork(reader));
		}
	}

	protected static void InvokeCmdCmdVehicleLights(NetworkBehaviour obj, NetworkReader reader)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdVehicleLights called on client.");
		}
		else
		{
			((RCC_UNetNetwork)obj).CmdVehicleLights(GeneratedNetworkCode._ReadVehicleLights_RCC_UNetNetwork(reader));
		}
	}

	protected static void InvokeCmdCmdVehicleTransform(NetworkBehaviour obj, NetworkReader reader)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdVehicleTransform called on client.");
		}
		else
		{
			((RCC_UNetNetwork)obj).CmdVehicleTransform(GeneratedNetworkCode._ReadVehicleTransform_RCC_UNetNetwork(reader));
		}
	}

	protected static void InvokeCmdCmdVehicleConfigurations(NetworkBehaviour obj, NetworkReader reader)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdVehicleConfigurations called on client.");
		}
		else
		{
			((RCC_UNetNetwork)obj).CmdVehicleConfigurations(GeneratedNetworkCode._ReadVehicleConfigurations_RCC_UNetNetwork(reader));
		}
	}

	public void CallCmdVehicleInputs(VehicleInput _input)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("Command function CmdVehicleInputs called on server.");
			return;
		}
		if (base.isServer)
		{
			CmdVehicleInputs(_input);
			return;
		}
		NetworkWriter networkWriter = new NetworkWriter();
		networkWriter.Write((short)0);
		networkWriter.Write((short)5);
		networkWriter.WritePackedUInt32((uint)kCmdCmdVehicleInputs);
		networkWriter.Write(GetComponent<NetworkIdentity>().netId);
		GeneratedNetworkCode._WriteVehicleInput_RCC_UNetNetwork(networkWriter, _input);
		SendCommandInternal(networkWriter, 0, "CmdVehicleInputs");
	}

	public void CallCmdVehicleLights(VehicleLights _input)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("Command function CmdVehicleLights called on server.");
			return;
		}
		if (base.isServer)
		{
			CmdVehicleLights(_input);
			return;
		}
		NetworkWriter networkWriter = new NetworkWriter();
		networkWriter.Write((short)0);
		networkWriter.Write((short)5);
		networkWriter.WritePackedUInt32((uint)kCmdCmdVehicleLights);
		networkWriter.Write(GetComponent<NetworkIdentity>().netId);
		GeneratedNetworkCode._WriteVehicleLights_RCC_UNetNetwork(networkWriter, _input);
		SendCommandInternal(networkWriter, 0, "CmdVehicleLights");
	}

	public void CallCmdVehicleTransform(VehicleTransform _input)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("Command function CmdVehicleTransform called on server.");
			return;
		}
		if (base.isServer)
		{
			CmdVehicleTransform(_input);
			return;
		}
		NetworkWriter networkWriter = new NetworkWriter();
		networkWriter.Write((short)0);
		networkWriter.Write((short)5);
		networkWriter.WritePackedUInt32((uint)kCmdCmdVehicleTransform);
		networkWriter.Write(GetComponent<NetworkIdentity>().netId);
		GeneratedNetworkCode._WriteVehicleTransform_RCC_UNetNetwork(networkWriter, _input);
		SendCommandInternal(networkWriter, 0, "CmdVehicleTransform");
	}

	public void CallCmdVehicleConfigurations(VehicleConfigurations _input)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("Command function CmdVehicleConfigurations called on server.");
			return;
		}
		if (base.isServer)
		{
			CmdVehicleConfigurations(_input);
			return;
		}
		NetworkWriter networkWriter = new NetworkWriter();
		networkWriter.Write((short)0);
		networkWriter.Write((short)5);
		networkWriter.WritePackedUInt32((uint)kCmdCmdVehicleConfigurations);
		networkWriter.Write(GetComponent<NetworkIdentity>().netId);
		GeneratedNetworkCode._WriteVehicleConfigurations_RCC_UNetNetwork(networkWriter, _input);
		SendCommandInternal(networkWriter, 0, "CmdVehicleConfigurations");
	}

	static RCC_UNetNetwork()
	{
		kCmdCmdVehicleInputs = 1063622908;
		NetworkBehaviour.RegisterCommandDelegate(typeof(RCC_UNetNetwork), kCmdCmdVehicleInputs, InvokeCmdCmdVehicleInputs);
		kCmdCmdVehicleLights = 1144612144;
		NetworkBehaviour.RegisterCommandDelegate(typeof(RCC_UNetNetwork), kCmdCmdVehicleLights, InvokeCmdCmdVehicleLights);
		kCmdCmdVehicleTransform = 1761195897;
		NetworkBehaviour.RegisterCommandDelegate(typeof(RCC_UNetNetwork), kCmdCmdVehicleTransform, InvokeCmdCmdVehicleTransform);
		kCmdCmdVehicleConfigurations = -1134666160;
		NetworkBehaviour.RegisterCommandDelegate(typeof(RCC_UNetNetwork), kCmdCmdVehicleConfigurations, InvokeCmdCmdVehicleConfigurations);
		kListm_Transform = -695215329;
		NetworkBehaviour.RegisterSyncListDelegate(typeof(RCC_UNetNetwork), kListm_Transform, InvokeSyncListm_Transform);
		kListm_Inputs = 1280083734;
		NetworkBehaviour.RegisterSyncListDelegate(typeof(RCC_UNetNetwork), kListm_Inputs, InvokeSyncListm_Inputs);
		kListm_Configurations = 829067882;
		NetworkBehaviour.RegisterSyncListDelegate(typeof(RCC_UNetNetwork), kListm_Configurations, InvokeSyncListm_Configurations);
		kListm_Lights = 1361072970;
		NetworkBehaviour.RegisterSyncListDelegate(typeof(RCC_UNetNetwork), kListm_Lights, InvokeSyncListm_Lights);
		NetworkCRC.RegisterBehaviour("RCC_UNetNetwork", 0);
	}

	private void Awake()
	{
		m_Transform.InitializeBehaviour(this, kListm_Transform);
		m_Inputs.InitializeBehaviour(this, kListm_Inputs);
		m_Configurations.InitializeBehaviour(this, kListm_Configurations);
		m_Lights.InitializeBehaviour(this, kListm_Lights);
	}

	public override bool OnSerialize(NetworkWriter writer, bool forceAll)
	{
		if (forceAll)
		{
			GeneratedNetworkCode._WriteStructSyncListVehicleTransform_RCC_UNetNetwork(writer, m_Transform);
			GeneratedNetworkCode._WriteStructSyncListVehicleInput_RCC_UNetNetwork(writer, m_Inputs);
			GeneratedNetworkCode._WriteStructSyncListVehicleConfigurations_RCC_UNetNetwork(writer, m_Configurations);
			GeneratedNetworkCode._WriteStructSyncListVehicleLights_RCC_UNetNetwork(writer, m_Lights);
			return true;
		}
		bool flag = false;
		if ((base.syncVarDirtyBits & (true ? 1u : 0u)) != 0)
		{
			if (!flag)
			{
				writer.WritePackedUInt32(base.syncVarDirtyBits);
				flag = true;
			}
			GeneratedNetworkCode._WriteStructSyncListVehicleTransform_RCC_UNetNetwork(writer, m_Transform);
		}
		if ((base.syncVarDirtyBits & 2u) != 0)
		{
			if (!flag)
			{
				writer.WritePackedUInt32(base.syncVarDirtyBits);
				flag = true;
			}
			GeneratedNetworkCode._WriteStructSyncListVehicleInput_RCC_UNetNetwork(writer, m_Inputs);
		}
		if ((base.syncVarDirtyBits & 4u) != 0)
		{
			if (!flag)
			{
				writer.WritePackedUInt32(base.syncVarDirtyBits);
				flag = true;
			}
			GeneratedNetworkCode._WriteStructSyncListVehicleConfigurations_RCC_UNetNetwork(writer, m_Configurations);
		}
		if ((base.syncVarDirtyBits & 8u) != 0)
		{
			if (!flag)
			{
				writer.WritePackedUInt32(base.syncVarDirtyBits);
				flag = true;
			}
			GeneratedNetworkCode._WriteStructSyncListVehicleLights_RCC_UNetNetwork(writer, m_Lights);
		}
		if (!flag)
		{
			writer.WritePackedUInt32(base.syncVarDirtyBits);
		}
		return flag;
	}

	public override void OnDeserialize(NetworkReader reader, bool initialState)
	{
		if (initialState)
		{
			GeneratedNetworkCode._ReadStructSyncListVehicleTransform_RCC_UNetNetwork(reader, m_Transform);
			GeneratedNetworkCode._ReadStructSyncListVehicleInput_RCC_UNetNetwork(reader, m_Inputs);
			GeneratedNetworkCode._ReadStructSyncListVehicleConfigurations_RCC_UNetNetwork(reader, m_Configurations);
			GeneratedNetworkCode._ReadStructSyncListVehicleLights_RCC_UNetNetwork(reader, m_Lights);
			return;
		}
		int num = (int)reader.ReadPackedUInt32();
		if (((uint)num & (true ? 1u : 0u)) != 0)
		{
			GeneratedNetworkCode._ReadStructSyncListVehicleTransform_RCC_UNetNetwork(reader, m_Transform);
		}
		if (((uint)num & 2u) != 0)
		{
			GeneratedNetworkCode._ReadStructSyncListVehicleInput_RCC_UNetNetwork(reader, m_Inputs);
		}
		if (((uint)num & 4u) != 0)
		{
			GeneratedNetworkCode._ReadStructSyncListVehicleConfigurations_RCC_UNetNetwork(reader, m_Configurations);
		}
		if (((uint)num & 8u) != 0)
		{
			GeneratedNetworkCode._ReadStructSyncListVehicleLights_RCC_UNetNetwork(reader, m_Lights);
		}
	}
}

#endif
