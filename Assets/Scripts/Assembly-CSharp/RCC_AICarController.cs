using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[AddComponentMenu("BoneCracker Games/Realistic Car Controller/AI/RCC AI Car Controller")]
public class RCC_AICarController : MonoBehaviour
{
	public enum AIType
	{
		FollowWaypoints,
		ChaseTarget
	}

	public delegate void onRCCAISpawned(RCC_AICarController RCCAI);

	public delegate void onRCCAIDestroyed(RCC_AICarController RCCAI);

	internal RCC_CarControllerV3 carController;

	private Rigidbody rigid;

	public RCC_AIWaypointsContainer waypointsContainer;

	public int currentWaypoint;

	public Transform targetChase;

	public string targetTag = "Player";

	public AIType _AIType;

	public int wideRayLength = 20;

	public int tightRayLength = 20;

	public int sideRayLength = 3;

	public LayerMask obstacleLayers = -1;

	private float rayInput;

	private bool raycasting;

	private float resetTime;

	private float steerInput;

	private float gasInput;

	private float brakeInput;

	public bool limitSpeed;

	public float maximumSpeed = 100f;

	public bool smoothedSteer = true;

	private float maximumSpeedInBrakeZone;

	private bool inBrakeZone;

	public int lap;

	public int totalWaypointPassed;

	public int nextWaypointPassRadius = 40;

	public bool ignoreWaypointNow;

	private NavMeshAgent navigator;

	private GameObject detector;

	public float detectorRadius = 100f;

	public List<RCC_CarControllerV3> targetsInZone = new List<RCC_CarControllerV3>();

	private float TRIGGER_SPEED;

	private float NEED_SPEED;

	private float REAL_SPEED;

	private float SUPER_REAL_SPEED;

	private float SLOW_REAL_SPEED;

	private float SUPER_REAL_SPEED2;

	private float NITRO_SPEED;

	private float SUPER_SPEED;

	private GameObject PLAYER;

	private float distance;

	private float NOS_Time;

	public int REAL_SPD;

	public static event onRCCAISpawned OnRCCAISpawned;

	public static event onRCCAIDestroyed OnRCCAIDestroyed;

	private void Start()
	{
		PLAYER = GameObject.FindGameObjectWithTag("Player");
		TRIGGER_SPEED = GAME_MANAGER.PLAYER_MAXIMUM_SPEED / 5f;
		NEED_SPEED = GAME_MANAGER.PLAYER_MAXIMUM_SPEED - 40f;
		SUPER_SPEED = GAME_MANAGER.PLAYER_MAXIMUM_SPEED + 10f;
		REAL_SPEED = GAME_MANAGER.PLAYER_MAXIMUM_SPEED + (float)REAL_SPD;
		SUPER_REAL_SPEED = GAME_MANAGER.PLAYER_MAXIMUM_SPEED + 5f;
		SUPER_REAL_SPEED2 = GAME_MANAGER.PLAYER_MAXIMUM_SPEED + 20f;
		SLOW_REAL_SPEED = GAME_MANAGER.PLAYER_MAXIMUM_SPEED - 20f;
		carController = GetComponent<RCC_CarControllerV3>();
		carController.externalController = true;
		rigid = GetComponent<Rigidbody>();
		if (GAME_MANAGER.IN_RACE)
		{
			if (base.gameObject.name == "AI_RACE_CAR(Clone)")
			{
				waypointsContainer = GameObject.FindGameObjectWithTag("WAY_RIGHT").GetComponent<RCC_AIWaypointsContainer>();
			}
			if (base.gameObject.name == "AI_RACE_CAR2(Clone)")
			{
				waypointsContainer = GameObject.FindGameObjectWithTag("WAY_LEFT").GetComponent<RCC_AIWaypointsContainer>();
			}
			if (base.gameObject.name == "AI_RACE_CAR3(Clone)")
			{
				waypointsContainer = GameObject.FindGameObjectWithTag("WAY_RIGHT").GetComponent<RCC_AIWaypointsContainer>();
			}
		}
		if (!waypointsContainer)
		{
			waypointsContainer = Object.FindObjectOfType(typeof(RCC_AIWaypointsContainer)) as RCC_AIWaypointsContainer;
		}
		GameObject gameObject = new GameObject("Navigator");
		gameObject.transform.SetParent(base.transform, worldPositionStays: false);
		navigator = gameObject.AddComponent<NavMeshAgent>();
		navigator.radius = 1f;
		navigator.speed = 1f;
		navigator.angularSpeed = 100000f;
		navigator.acceleration = 100000f;
		navigator.height = 1f;
		navigator.avoidancePriority = 99;
		navigator.obstacleAvoidanceType = ObstacleAvoidanceType.LowQualityObstacleAvoidance;
		detector = new GameObject("Detector");
		detector.transform.SetParent(base.transform, worldPositionStays: false);
		detector.gameObject.AddComponent<SphereCollider>();
		detector.GetComponent<SphereCollider>().isTrigger = true;
		detector.GetComponent<SphereCollider>().radius = detectorRadius;
	}

	private void OnEnable()
	{
		distance = 100f;
		if (RCC_AICarController.OnRCCAISpawned != null)
		{
			RCC_AICarController.OnRCCAISpawned(this);
		}
	}

	private void Update()
	{
		if (!GAME_MANAGER.IN_RACE)
		{
			if (Time.frameCount % 50 == 0)
			{
				if (COP_MANAGER.PASSENGER_COMFORT_ < 0.6f)
				{
					SMOKE_.SMOKE_INT = 1;
				}
				if (COP_MANAGER.PASSENGER_COMFORT_ < 0.3f)
				{
					SMOKE_.SMOKE_INT = 2;
				}
				if (COP_MANAGER.PASSENGER_COMFORT_ > 0.6f)
				{
					SMOKE_.SMOKE_INT = 0;
				}
				distance = Vector3.Distance(base.gameObject.transform.position, PLAYER.transform.position);
			}
			if (COP_MANAGER.PASSENGER_COMPLETE)
			{
				carController.canControl = false;
				carController.brakeInput = 1f;
				carController.handbrakeInput = 1f;
			}
			if (COP_MANAGER.PASSENGER_PICKUP & !COP_MANAGER.PASSENGER_FAIL)
			{
				if (distance > 400f)
				{
					if (COP_MANAGER.GPS_DIST > 0f)
					{
						COP_MANAGER.GPS_DIST -= Time.deltaTime / 35f;
					}
				}
				else if (COP_MANAGER.GPS_DIST < 1f)
				{
					COP_MANAGER.GPS_DIST += Time.deltaTime / 10f;
				}
				if (distance > 110f)
				{
					maximumSpeed = GAME_MANAGER.PLAYER_MAXIMUM_SPEED - 50f;
					COP_MANAGER.NEAR = false;
				}
				else
				{
					maximumSpeed = GAME_MANAGER.PLAYER_MAXIMUM_SPEED - 25f;
					COP_MANAGER.NEAR = true;
				}
				if (distance < 50f)
				{
					maximumSpeed = GAME_MANAGER.PLAYER_MAXIMUM_SPEED + 10f;
				}
			}
		}
		else
		{
			if (Time.frameCount % 50 == 0)
			{
				distance = Vector3.Distance(base.gameObject.transform.position, Camera.main.transform.position);
			}
			if (carController.boostInput == 110f)
			{
				maximumSpeed = NITRO_SPEED;
			}
			else
			{
				maximumSpeed = REAL_SPEED;
			}
			if (distance < 40f || RACE_MANAGER.CURRENT_PLACE == 1)
			{
				if (RACE_MANAGER.CURRENT_PLACE == 1)
				{
					maximumSpeed = SUPER_REAL_SPEED2;
				}
				else
				{
					maximumSpeed = SUPER_REAL_SPEED;
				}
				if (carController.speed > 60f)
				{
					NOS_Time += Time.deltaTime;
					if ((NOS_Time > 2f) & (carController.NoS > 10f))
					{
						if (RACE_MANAGER.CURRENT_PLACE == 1)
						{
							carController.boostInput = 120f;
						}
						else
						{
							carController.boostInput = 110f;
						}
					}
					else
					{
						carController.boostInput = 1f;
					}
				}
			}
			if (RACE_MANAGER.CURRENT_PLACE == 1)
			{
				if (distance > 200f)
				{
					maximumSpeed = 40f;
					carController.boostInput = 1f;
				}
			}
			else if (distance > 240f)
			{
				maximumSpeed = 90f;
				carController.boostInput = 1f;
			}
			if (carController.NoS < 10f)
			{
				NOS_Time = -8f;
			}
			if (RACE_MANAGER.return_timer > 0f)
			{
				maximumSpeed = 20f;
			}
			if ((carController.boostInput > 100f) & (GAME_MANAGER.PLAYER_MAXIMUM_SPEED > 90f))
			{
				limitSpeed = false;
			}
			else
			{
				limitSpeed = true;
			}
		}
		if (!carController.canControl)
		{
			return;
		}
		navigator.transform.position = base.transform.position;
		navigator.transform.position += base.transform.forward * carController.FrontLeftWheelCollider.transform.localPosition.z;
		for (int i = 0; i < targetsInZone.Count; i++)
		{
			if (targetsInZone[i] == null)
			{
				targetsInZone.RemoveAt(i);
			}
			if (!targetsInZone[i].gameObject.activeInHierarchy)
			{
				targetsInZone.RemoveAt(i);
			}
			else if (Vector3.Distance(base.transform.position, targetsInZone[i].transform.position) > detectorRadius * 1.25f)
			{
				targetsInZone.RemoveAt(i);
			}
		}
		if (targetsInZone.Count > 0)
		{
			targetChase = GetClosestEnemy(targetsInZone.ToArray());
		}
		else
		{
			targetChase = null;
		}
	}

	private void FixedUpdate()
	{
		if (carController.canControl)
		{
			Navigation();
			if (Time.frameCount % 3 == 0)
			{
				FixedRaycasts();
			}
			FeedRCC();
			Resetting();
			if (carController.speed > maximumSpeed)
			{
				carController.brakeInput = 1f;
			}
		}
	}

	private void Navigation()
	{
		float num = Mathf.Clamp(base.transform.InverseTransformDirection(navigator.desiredVelocity).x * 1.5f, -1f, 1f);
		switch (_AIType)
		{
		case AIType.FollowWaypoints:
		{
			if (!waypointsContainer)
			{
				Debug.LogError("Waypoints Container Couldn't Found!");
				Stop();
				return;
			}
			if ((bool)waypointsContainer && waypointsContainer.waypoints.Count < 1)
			{
				Debug.LogError("Waypoints Container Doesn't Have Any Waypoints!");
				Stop();
				return;
			}
			Vector3 vector = base.transform.InverseTransformPoint(new Vector3(waypointsContainer.waypoints[currentWaypoint].position.x, base.transform.position.y, waypointsContainer.waypoints[currentWaypoint].position.z));
			if (navigator.isOnNavMesh)
			{
				navigator.SetDestination(waypointsContainer.waypoints[currentWaypoint].position);
			}
			if (vector.magnitude < (float)nextWaypointPassRadius)
			{
				currentWaypoint++;
				totalWaypointPassed++;
				if (currentWaypoint >= waypointsContainer.waypoints.Count)
				{
					currentWaypoint = 0;
					lap++;
				}
			}
			break;
		}
		case AIType.ChaseTarget:
			if (!targetChase)
			{
				Stop();
				return;
			}
			if (navigator.isOnNavMesh)
			{
				navigator.SetDestination(targetChase.position);
			}
			break;
		}
		if (!inBrakeZone)
		{
			if (carController.speed >= 10f)
			{
				if (!carController.changingGear)
				{
					if (carController.speed < maximumSpeed)
					{
						gasInput = Mathf.Clamp(1f - (Mathf.Abs(num / 10f) - Mathf.Abs(rayInput / 10f)), 0.75f, 1f);
					}
				}
				else
				{
					gasInput = 0f;
				}
			}
			else if (!carController.changingGear)
			{
				if (carController.speed < maximumSpeed)
				{
					gasInput = Mathf.Clamp(1f - (Mathf.Abs(num / 10f) - Mathf.Abs(rayInput / 10f)), 0.75f, 1f);
				}
			}
			else
			{
				gasInput = 0f;
			}
		}
		steerInput = Mathf.Clamp((!ignoreWaypointNow) ? (num + rayInput) : rayInput, -1f, 1f) * (float)carController.direction;
		if (!inBrakeZone)
		{
			if (carController.speed >= 25f)
			{
				brakeInput = Mathf.Lerp(0f, 0.25f, Mathf.Abs(steerInput));
			}
			else
			{
				brakeInput = 0f;
			}
		}
		else
		{
			brakeInput = Mathf.Lerp(0f, 1f, (carController.speed - maximumSpeedInBrakeZone) / maximumSpeedInBrakeZone);
		}
	}

	private void Resetting()
	{
		if (!RACE_MANAGER.START_RACE)
		{
			if (carController.speed <= 5f && base.transform.InverseTransformDirection(rigid.velocity).z < 1f)
			{
				resetTime += Time.deltaTime;
			}
			if (resetTime >= 2f)
			{
				carController.direction = -1;
			}
			if (resetTime >= 4f || carController.speed >= 40f)
			{
				carController.direction = 1;
				resetTime = 0f;
			}
		}
	}

	private void FixedRaycasts()
	{
		Vector3 position = base.transform.position;
		position += base.transform.forward * carController.FrontLeftWheelCollider.transform.localPosition.z;
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		bool flag4 = false;
		bool flag5 = false;
		bool flag6 = false;
		float num = 0f;
		float num2 = 0f;
		float num3 = 0f;
		float num4 = 0f;
		float num5 = 0f;
		float num6 = 0f;
		Debug.DrawRay(position, Quaternion.AngleAxis(25f, base.transform.up) * base.transform.forward * wideRayLength, Color.white);
		Debug.DrawRay(position, Quaternion.AngleAxis(-25f, base.transform.up) * base.transform.forward * wideRayLength, Color.white);
		Debug.DrawRay(position, Quaternion.AngleAxis(7f, base.transform.up) * base.transform.forward * tightRayLength, Color.white);
		Debug.DrawRay(position, Quaternion.AngleAxis(-7f, base.transform.up) * base.transform.forward * tightRayLength, Color.white);
		Debug.DrawRay(position, Quaternion.AngleAxis(90f, base.transform.up) * base.transform.forward * sideRayLength, Color.white);
		Debug.DrawRay(position, Quaternion.AngleAxis(-90f, base.transform.up) * base.transform.forward * sideRayLength, Color.white);
		if (Physics.Raycast(position, Quaternion.AngleAxis(25f, base.transform.up) * base.transform.forward, out var hitInfo, wideRayLength, obstacleLayers) && !hitInfo.collider.isTrigger && hitInfo.transform.root != base.transform)
		{
			Debug.DrawRay(position, Quaternion.AngleAxis(25f, base.transform.up) * base.transform.forward * wideRayLength, Color.red);
			num = Mathf.Lerp(-0.5f, 0f, hitInfo.distance / (float)wideRayLength);
			flag2 = true;
		}
		else
		{
			num = 0f;
			flag2 = false;
		}
		if (Physics.Raycast(position, Quaternion.AngleAxis(-25f, base.transform.up) * base.transform.forward, out hitInfo, wideRayLength, obstacleLayers) && !hitInfo.collider.isTrigger && hitInfo.transform.root != base.transform)
		{
			Debug.DrawRay(position, Quaternion.AngleAxis(-25f, base.transform.up) * base.transform.forward * wideRayLength, Color.red);
			num4 = Mathf.Lerp(0.5f, 0f, hitInfo.distance / (float)wideRayLength);
			flag5 = true;
		}
		else
		{
			num4 = 0f;
			flag5 = false;
		}
		if (Physics.Raycast(position, Quaternion.AngleAxis(7f, base.transform.up) * base.transform.forward, out hitInfo, tightRayLength, obstacleLayers) && !hitInfo.collider.isTrigger && hitInfo.transform.root != base.transform)
		{
			Debug.DrawRay(position, Quaternion.AngleAxis(7f, base.transform.up) * base.transform.forward * tightRayLength, Color.red);
			num3 = Mathf.Lerp(-2f, 0f, hitInfo.distance / (float)tightRayLength);
			flag = true;
		}
		else
		{
			num3 = 0f;
			flag = false;
		}
		if (Physics.Raycast(position, Quaternion.AngleAxis(-7f, base.transform.up) * base.transform.forward, out hitInfo, tightRayLength, obstacleLayers) && !hitInfo.collider.isTrigger && hitInfo.transform.root != base.transform)
		{
			Debug.DrawRay(position, Quaternion.AngleAxis(-7f, base.transform.up) * base.transform.forward * tightRayLength, Color.red);
			num2 = Mathf.Lerp(2f, 0f, hitInfo.distance / (float)tightRayLength);
			flag4 = true;
		}
		else
		{
			num2 = 0f;
			flag4 = false;
		}
		if (Physics.Raycast(position, Quaternion.AngleAxis(90f, base.transform.up) * base.transform.forward, out hitInfo, sideRayLength, obstacleLayers) && !hitInfo.collider.isTrigger && hitInfo.transform.root != base.transform)
		{
			Debug.DrawRay(position, Quaternion.AngleAxis(90f, base.transform.up) * base.transform.forward * sideRayLength, Color.red);
			num5 = Mathf.Lerp(-1f, 0f, hitInfo.distance / (float)sideRayLength);
			flag3 = true;
		}
		else
		{
			num5 = 0f;
			flag3 = false;
		}
		if (Physics.Raycast(position, Quaternion.AngleAxis(-90f, base.transform.up) * base.transform.forward, out hitInfo, sideRayLength, obstacleLayers) && !hitInfo.collider.isTrigger && hitInfo.transform.root != base.transform)
		{
			Debug.DrawRay(position, Quaternion.AngleAxis(-90f, base.transform.up) * base.transform.forward * sideRayLength, Color.red);
			num6 = Mathf.Lerp(1f, 0f, hitInfo.distance / (float)sideRayLength);
			flag6 = true;
		}
		else
		{
			num6 = 0f;
			flag6 = false;
		}
		if (flag2 || flag5 || flag || flag4 || flag3 || flag6)
		{
			raycasting = true;
		}
		else
		{
			raycasting = false;
		}
		if (raycasting)
		{
			rayInput = num + num2 + num3 + num4 + num5 + num6;
		}
		else
		{
			rayInput = 0f;
		}
		if (raycasting && Mathf.Abs(rayInput) > 0.5f)
		{
			ignoreWaypointNow = true;
		}
		else
		{
			ignoreWaypointNow = false;
		}
	}

	private void FeedRCC()
	{
		if (RACE_MANAGER.START_RACE && !RACE_MANAGER.FINISH_RACE)
		{
			return;
		}
		if (carController.direction == 1)
		{
			if (!limitSpeed)
			{
				carController.gasInput = gasInput;
			}
			else if (carController.speed < maximumSpeed)
			{
				carController.gasInput = gasInput;
			}
		}
		else
		{
			carController.gasInput = 0f;
		}
		if (smoothedSteer)
		{
			carController.steerInput = Mathf.Lerp(carController.steerInput, steerInput, Time.deltaTime * 20f);
		}
		else
		{
			carController.steerInput = steerInput;
		}
		if (carController.direction == 1)
		{
			carController.brakeInput = brakeInput;
		}
		else
		{
			carController.brakeInput = gasInput;
		}
	}

	private void Stop()
	{
		gasInput = 0f;
		steerInput = 0f;
		brakeInput = 1f;
	}

	private void OnTriggerEnter(Collider col)
	{
		if ((bool)col.gameObject.GetComponent<RCC_AIBrakeZone>())
		{
			inBrakeZone = true;
			maximumSpeedInBrakeZone = col.gameObject.GetComponent<RCC_AIBrakeZone>().targetSpeed;
		}
		if (col.attachedRigidbody != null && (bool)col.gameObject.GetComponentInParent<RCC_CarControllerV3>() && col.gameObject.GetComponentInParent<RCC_CarControllerV3>().transform.CompareTag(targetTag) && !targetsInZone.Contains(col.gameObject.GetComponentInParent<RCC_CarControllerV3>()))
		{
			targetsInZone.Add(col.gameObject.GetComponentInParent<RCC_CarControllerV3>());
		}
	}

	private void OnTriggerExit(Collider col)
	{
		if ((bool)col.gameObject.GetComponent<RCC_AIBrakeZone>())
		{
			inBrakeZone = false;
			maximumSpeedInBrakeZone = 0f;
		}
	}

	private Transform GetClosestEnemy(RCC_CarControllerV3[] enemies)
	{
		Transform result = null;
		float num = float.PositiveInfinity;
		Vector3 position = base.transform.position;
		foreach (RCC_CarControllerV3 rCC_CarControllerV in enemies)
		{
			float sqrMagnitude = (rCC_CarControllerV.transform.position - position).sqrMagnitude;
			if (sqrMagnitude < num)
			{
				num = sqrMagnitude;
				result = rCC_CarControllerV.transform;
			}
		}
		return result;
	}

	private void OnDestroy()
	{
		if (RCC_AICarController.OnRCCAIDestroyed != null)
		{
			RCC_AICarController.OnRCCAIDestroyed(this);
		}
	}
}
