using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class AI_Traffic_Car_PRO : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024NORMAL_MODE_CAR_00248 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal AI_Traffic_Car_PRO _0024self__00249;

			public _0024(AI_Traffic_Car_PRO self_)
			{
				_0024self__00249 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__00249.COLLISION_LIGHTS.SetActive(value: true);
					_0024self__00249.BreakeLight.SetActive(value: true);
					_0024self__00249.F_L_Wheel.brakeTorque = 1E+14f;
					_0024self__00249.F_R_Wheel.brakeTorque = 1E+14f;
					_0024self__00249.B_L_Wheel.brakeTorque = 1E+14f;
					_0024self__00249.B_R_Wheel.brakeTorque = 1E+14f;
					_0024self__00249.enabled = false;
					result = (Yield(2, new WaitForSeconds(16f)) ? 1 : 0);
					break;
				case 2:
					_0024self__00249.STATUS = 0;
					_0024self__00249.COLLISION_LIGHTS.SetActive(value: false);
					_0024self__00249.CarStatus = "Drive";
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal AI_Traffic_Car_PRO _0024self__002410;

		public _0024NORMAL_MODE_CAR_00248(AI_Traffic_Car_PRO self_)
		{
			_0024self__002410 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__002410);
		}
	}

	public WheelCollider F_L_Wheel;

	public WheelCollider F_R_Wheel;

	public WheelCollider B_L_Wheel;

	public WheelCollider B_R_Wheel;

	private int SteeringWheel;

	public GameObject BreakeLight;

	public GameObject waypoint;

	public GameObject COLLISION_LIGHTS;

	public float EngineMoment;

	public float Speed;

	public float MaxSpeed;

	public CMode Mode;

	public WAYPOINTS_S WAYPOINTS_;

	public CType2 CarType;

	private float vehicleCenterOfMass;

	private float side_ray;

	private float breake_far;

	private int currentGear;

	private float EngineRPM;

	private UnityScript.Lang.Array waypoints;

	public int currentWaypoint;

	public int BrakeForce;

	private float inputSteer;

	private float inputTorque;

	private float TIMER;

	private int RayDistance;

	private float MaxEngineRPM;

	private float MinEngineRPM;

	public string CarStatus;

	private int STATUS;

	public AI_Traffic_Car_PRO()
	{
		SteeringWheel = 12;
		EngineMoment = 100f;
		MaxSpeed = 100f;
		Mode = CMode.Advanced;
		WAYPOINTS_ = WAYPOINTS_S.FORWARD_1;
		CarType = CType2.NORMCAR;
		side_ray = 12f;
		breake_far = 10f;
		BrakeForce = 100000;
		RayDistance = 5;
		MaxEngineRPM = 3000f;
		MinEngineRPM = 1000f;
		CarStatus = "Drive";
	}

	public virtual void Start()
	{
		if (WAYPOINTS_ == WAYPOINTS_S.FORWARD_1)
		{
			waypoint = GameObject.Find("Waypoints Container");
		}
		if (WAYPOINTS_ == WAYPOINTS_S.BACKWARD_1)
		{
			waypoint = GameObject.Find("Waypoints Container2");
		}
		GetComponent<Rigidbody>().mass = 600f;
		GetComponent<Rigidbody>().interpolation = RigidbodyInterpolation.Extrapolate;
		GetComponent<Rigidbody>().centerOfMass = new Vector3(0f, 2f, 0f);
		int num = -2;
		Vector3 centerOfMass = GetComponent<Rigidbody>().centerOfMass;
		float num2 = (centerOfMass.y = num);
		Vector3 vector2 = (GetComponent<Rigidbody>().centerOfMass = centerOfMass);
		BreakeLight.SetActive(value: false);
		EngineMoment = 5000f;
		currentWaypoint++;
	}

	public virtual void OnCollisionEnter(Collision collision)
	{
		int i = 0;
		ContactPoint[] contacts = collision.contacts;
		for (int length = contacts.Length; i < length; i++)
		{
			if (contacts[i].otherCollider.tag == "Player")
			{
				StartCoroutine(NORMAL_MODE_CAR());
				STATUS = 1;
			}
		}
	}

	public virtual IEnumerator NORMAL_MODE_CAR()
	{
		return new _0024NORMAL_MODE_CAR_00248(this).GetEnumerator();
	}

	public virtual void Update()
	{
		GetComponent<Rigidbody>().velocity = Vector3.ClampMagnitude(GetComponent<Rigidbody>().velocity * 1.02f, MaxSpeed);
		Speed = Mathf.Round(GetComponent<Rigidbody>().velocity.magnitude);
		if (STATUS == 1)
		{
			BreakeLight.SetActive(value: false);
			CarStatus = "Stop";
		}
		breake_far = Speed / 2f + 8f;
		side_ray = Speed / 2f;
		if (CarStatus == "Stop")
		{
			BreakeLight.SetActive(value: true);
			EngineMoment = 0f;
			F_L_Wheel.brakeTorque = 1E+14f;
			F_R_Wheel.brakeTorque = 1E+14f;
			B_L_Wheel.brakeTorque = 1E+14f;
			B_R_Wheel.brakeTorque = 1E+14f;
		}
		if (CarStatus == "Drive")
		{
			B_L_Wheel.brakeTorque = 0f;
			B_R_Wheel.brakeTorque = 0f;
			BreakeLight.SetActive(value: false);
			F_L_Wheel.brakeTorque = 0f;
			F_R_Wheel.brakeTorque = 0f;
		}
		if (CarType == CType2.NORMCAR)
		{
			BrakeForce = 250000;
			EngineMoment = 700f;
			SteeringWheel = 0;
			MaxSpeed = 11f;
		}
		F_L_Wheel.motorTorque = EngineMoment;
		F_R_Wheel.motorTorque = EngineMoment;
		F_L_Wheel.steerAngle = 50f * inputSteer;
		F_R_Wheel.steerAngle = 50f * inputSteer;
		if (Time.frameCount % 2 == 0)
		{
			Adv();
		}
	}

	public virtual void Adv()
	{
		Vector3 vector = transform.TransformDirection(Vector3.forward) * side_ray;
		Vector3 vector2 = transform.TransformDirection(Vector3.forward) * breake_far;
		Debug.DrawRay(transform.position, Quaternion.AngleAxis(9f, transform.up) * vector2 * 2f, Color.yellow);
		if (Physics.Raycast(transform.position, Quaternion.AngleAxis(9f, transform.up) * vector2 * 2f, breake_far))
		{
			Debug.DrawRay(transform.position, Quaternion.AngleAxis(9f, transform.up) * vector2 * 2f, Color.red);
			CarStatus = "Stop";
			F_L_Wheel.brakeTorque = 1E+14f;
			F_R_Wheel.brakeTorque = 1E+14f;
			B_L_Wheel.brakeTorque = 1E+14f;
			B_R_Wheel.brakeTorque = 1E+14f;
		}
		Debug.DrawRay(transform.position, Quaternion.AngleAxis(-9f, transform.up) * vector2 * 2f, Color.yellow);
		if (Physics.Raycast(transform.position, Quaternion.AngleAxis(-9f, transform.up) * vector2 * 2f, breake_far))
		{
			Debug.DrawRay(transform.position, Quaternion.AngleAxis(-9f, transform.up) * vector2 * 2f, Color.red);
			CarStatus = "Stop";
			F_L_Wheel.brakeTorque = 1E+14f;
			F_R_Wheel.brakeTorque = 1E+14f;
			B_L_Wheel.brakeTorque = 1E+14f;
			B_R_Wheel.brakeTorque = 1E+14f;
		}
		Debug.DrawRay(transform.position, vector2 * 2f, Color.yellow);
		if (Physics.Raycast(transform.position, vector2 * 2f, breake_far))
		{
			Debug.DrawRay(transform.position, vector2 * 2f, Color.red);
			F_L_Wheel.brakeTorque = 1E+14f;
			F_R_Wheel.brakeTorque = 1E+14f;
			B_L_Wheel.brakeTorque = 1E+14f;
			B_R_Wheel.brakeTorque = 1E+14f;
			CarStatus = "Stop";
		}
		else
		{
			CarStatus = "Drive";
			Navigate_to_waypoint();
		}
	}

	public virtual void Navigate_to_waypoint()
	{
		if (!(CarStatus == "Drive"))
		{
			return;
		}
		Transform[] array = null;
		GameObject gameObject = null;
		float num = float.PositiveInfinity;
		array = waypoint.GetComponentsInChildren<Transform>();
		Vector3 vector = transform.InverseTransformPoint(new Vector3(array[currentWaypoint].position.x, transform.position.y, array[currentWaypoint].position.z));
		float sqrMagnitude = (transform.position - waypoint.transform.position).sqrMagnitude;
		if (!(sqrMagnitude >= num))
		{
			num = sqrMagnitude;
			gameObject = waypoint;
		}
		inputSteer = vector.x / vector.magnitude;
		if (!(Mathf.Abs(inputSteer) >= 1.1f))
		{
			inputTorque = vector.z / vector.magnitude - Mathf.Abs(inputSteer * 4f);
		}
		else
		{
			inputTorque = 0f;
		}
		if (!(vector.magnitude >= 4f))
		{
			F_L_Wheel.brakeTorque = 40000f;
			F_R_Wheel.brakeTorque = 40000f;
			currentWaypoint++;
			if (currentWaypoint >= Extensions.get_length((System.Array)array))
			{
				F_L_Wheel.brakeTorque = 150000f;
				F_R_Wheel.brakeTorque = 150000f;
				currentWaypoint = 1;
			}
		}
	}

	public virtual void Main()
	{
	}
}
