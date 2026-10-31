#if CARTOON_RECON_LEGACY_UNET
using System.Runtime.InteropServices;
using UnityEngine.Networking;

namespace Unity
{
	[StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
	public class GeneratedNetworkCode
	{
		public static void _ReadStructSyncListVehicleTransform_RCC_UNetNetwork(NetworkReader reader, RCC_UNetNetwork.SyncListVehicleTransform instance)
		{
			ushort num = reader.ReadUInt16();
			instance.Clear();
			for (ushort num2 = 0; num2 < num; num2++)
			{
				instance.AddInternal(instance.DeserializeItem(reader));
			}
		}

		public static void _WriteStructSyncListVehicleTransform_RCC_UNetNetwork(NetworkWriter writer, RCC_UNetNetwork.SyncListVehicleTransform value)
		{
			ushort count = value.Count;
			writer.Write(count);
			for (ushort num = 0; num < count; num++)
			{
				value.SerializeItem(writer, value.GetItem(num));
			}
		}

		public static void _ReadStructSyncListVehicleInput_RCC_UNetNetwork(NetworkReader reader, RCC_UNetNetwork.SyncListVehicleInput instance)
		{
			ushort num = reader.ReadUInt16();
			instance.Clear();
			for (ushort num2 = 0; num2 < num; num2++)
			{
				instance.AddInternal(instance.DeserializeItem(reader));
			}
		}

		public static void _WriteStructSyncListVehicleInput_RCC_UNetNetwork(NetworkWriter writer, RCC_UNetNetwork.SyncListVehicleInput value)
		{
			ushort count = value.Count;
			writer.Write(count);
			for (ushort num = 0; num < count; num++)
			{
				value.SerializeItem(writer, value.GetItem(num));
			}
		}

		public static void _WriteArraySingle_None(NetworkWriter writer, float[] value)
		{
			if (value == null)
			{
				writer.Write((ushort)0);
				return;
			}
			ushort value2 = (ushort)value.Length;
			writer.Write(value2);
			for (ushort num = 0; num < value.Length; num++)
			{
				writer.Write(value[num]);
			}
		}

		public static float[] _ReadArraySingle_None(NetworkReader reader)
		{
			int num = reader.ReadUInt16();
			if (num == 0)
			{
				return new float[0];
			}
			float[] array = new float[num];
			for (int i = 0; i < num; i++)
			{
				ref float reference = ref array[i];
				reference = reader.ReadSingle();
			}
			return array;
		}

		public static void _ReadStructSyncListVehicleConfigurations_RCC_UNetNetwork(NetworkReader reader, RCC_UNetNetwork.SyncListVehicleConfigurations instance)
		{
			ushort num = reader.ReadUInt16();
			instance.Clear();
			for (ushort num2 = 0; num2 < num; num2++)
			{
				instance.AddInternal(instance.DeserializeItem(reader));
			}
		}

		public static void _WriteStructSyncListVehicleConfigurations_RCC_UNetNetwork(NetworkWriter writer, RCC_UNetNetwork.SyncListVehicleConfigurations value)
		{
			ushort count = value.Count;
			writer.Write(count);
			for (ushort num = 0; num < count; num++)
			{
				value.SerializeItem(writer, value.GetItem(num));
			}
		}

		public static void _ReadStructSyncListVehicleLights_RCC_UNetNetwork(NetworkReader reader, RCC_UNetNetwork.SyncListVehicleLights instance)
		{
			ushort num = reader.ReadUInt16();
			instance.Clear();
			for (ushort num2 = 0; num2 < num; num2++)
			{
				instance.AddInternal(instance.DeserializeItem(reader));
			}
		}

		public static void _WriteStructSyncListVehicleLights_RCC_UNetNetwork(NetworkWriter writer, RCC_UNetNetwork.SyncListVehicleLights value)
		{
			ushort count = value.Count;
			writer.Write(count);
			for (ushort num = 0; num < count; num++)
			{
				value.SerializeItem(writer, value.GetItem(num));
			}
		}

		public static RCC_UNetNetwork.VehicleInput _ReadVehicleInput_RCC_UNetNetwork(NetworkReader reader)
		{
			RCC_UNetNetwork.VehicleInput result = default(RCC_UNetNetwork.VehicleInput);
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

		public static void _WriteVehicleInput_RCC_UNetNetwork(NetworkWriter writer, RCC_UNetNetwork.VehicleInput value)
		{
			writer.Write(value.gasInput);
			writer.Write(value.brakeInput);
			writer.Write(value.steerInput);
			writer.Write(value.handbrakeInput);
			writer.Write(value.boostInput);
			writer.Write(value.clutchInput);
			writer.Write(value.idleInput);
			writer.WritePackedUInt32((uint)value.gear);
			writer.WritePackedUInt32((uint)value.direction);
			writer.Write(value.changingGear);
			writer.Write(value.fuelInput);
			writer.Write(value.engineRunning);
			writer.Write(value.canGoReverseNow);
		}

		public static RCC_UNetNetwork.VehicleLights _ReadVehicleLights_RCC_UNetNetwork(NetworkReader reader)
		{
			RCC_UNetNetwork.VehicleLights result = default(RCC_UNetNetwork.VehicleLights);
			result.lowBeamHeadLightsOn = reader.ReadBoolean();
			result.highBeamHeadLightsOn = reader.ReadBoolean();
			result.indicatorsOn = (RCC_CarControllerV3.IndicatorsOn)reader.ReadInt32();
			return result;
		}

		public static void _WriteVehicleLights_RCC_UNetNetwork(NetworkWriter writer, RCC_UNetNetwork.VehicleLights value)
		{
			writer.Write(value.lowBeamHeadLightsOn);
			writer.Write(value.highBeamHeadLightsOn);
			writer.Write((int)value.indicatorsOn);
		}

		public static RCC_UNetNetwork.VehicleTransform _ReadVehicleTransform_RCC_UNetNetwork(NetworkReader reader)
		{
			RCC_UNetNetwork.VehicleTransform result = default(RCC_UNetNetwork.VehicleTransform);
			result.position = reader.ReadVector3();
			result.rotation = reader.ReadQuaternion();
			result.rigidLinearVelocity = reader.ReadVector3();
			result.rigidAngularVelocity = reader.ReadVector3();
			return result;
		}

		public static void _WriteVehicleTransform_RCC_UNetNetwork(NetworkWriter writer, RCC_UNetNetwork.VehicleTransform value)
		{
			writer.Write(value.position);
			writer.Write(value.rotation);
			writer.Write(value.rigidLinearVelocity);
			writer.Write(value.rigidAngularVelocity);
		}

		public static RCC_UNetNetwork.VehicleConfigurations _ReadVehicleConfigurations_RCC_UNetNetwork(NetworkReader reader)
		{
			RCC_UNetNetwork.VehicleConfigurations result = default(RCC_UNetNetwork.VehicleConfigurations);
			result.gear = (int)reader.ReadPackedUInt32();
			result.direction = (int)reader.ReadPackedUInt32();
			result.changingGear = reader.ReadBoolean();
			result.semiAutomaticGear = reader.ReadBoolean();
			result.fuelInput = reader.ReadSingle();
			result.engineRunning = reader.ReadBoolean();
			result.cambers = _ReadArraySingle_None(reader);
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

		public static void _WriteArraySingle_None(NetworkWriter writer, float[] value)
		{
			if (value == null)
			{
				writer.Write((ushort)0);
				return;
			}
			ushort value2 = (ushort)value.Length;
			writer.Write(value2);
			for (ushort num = 0; num < value.Length; num++)
			{
				writer.Write(value[num]);
			}
		}

		public static void _WriteVehicleConfigurations_RCC_UNetNetwork(NetworkWriter writer, RCC_UNetNetwork.VehicleConfigurations value)
		{
			writer.WritePackedUInt32((uint)value.gear);
			writer.WritePackedUInt32((uint)value.direction);
			writer.Write(value.changingGear);
			writer.Write(value.semiAutomaticGear);
			writer.Write(value.fuelInput);
			writer.Write(value.engineRunning);
			GeneratedNetworkCode._WriteArraySingle_None(writer, value.cambers);
			writer.Write(value.applyEngineTorqueToExtraRearWheelColliders);
			writer.Write((int)value.wheelTypeChoise);
			writer.Write(value.biasedWheelTorque);
			writer.Write(value.canGoReverseNow);
			writer.Write(value.engineTorque);
			writer.Write(value.brakeTorque);
			writer.Write(value.minEngineRPM);
			writer.Write(value.maxEngineRPM);
			writer.Write(value.engineInertia);
			writer.Write(value.useRevLimiter);
			writer.Write(value.useExhaustFlame);
			writer.Write(value.useClutchMarginAtFirstGear);
			writer.Write(value.highspeedsteerAngle);
			writer.Write(value.highspeedsteerAngleAtspeed);
			writer.Write(value.antiRollFrontHorizontal);
			writer.Write(value.antiRollRearHorizontal);
			writer.Write(value.antiRollVertical);
			writer.Write(value.maxspeed);
			writer.Write(value.engineHeat);
			writer.Write(value.engineHeatMultiplier);
			writer.WritePackedUInt32((uint)value.totalGears);
			writer.Write(value.gearShiftingDelay);
			writer.Write(value.gearShiftingThreshold);
			writer.Write(value.clutchInertia);
			writer.Write(value.NGear);
			writer.Write(value.launched);
			writer.Write(value.ABS);
			writer.Write(value.TCS);
			writer.Write(value.ESP);
			writer.Write(value.steeringHelper);
			writer.Write(value.tractionHelper);
			writer.Write(value.applyCounterSteering);
			writer.Write(value.useNOS);
			writer.Write(value.useTurbo);
		}
	}
}

#endif
