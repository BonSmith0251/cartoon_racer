using System.Collections;
using UnityEngine;

public class RACE_TRIGGER : MonoBehaviour
{
	public int INDEX;

	public static int _INDEX;

	[Header("ТИП ГОНОК")]
	public bool AI_RACE;

	public bool SPEED_RACE;

	public bool TIME_RACE;

	public bool TRAFFIC_RACE;

	public int TRAFFIC_DISTANCE;

	public static bool _AI_RACE;

	public static bool _SPEED_RACE;

	public static bool _TIME_RACE;

	public static bool _TRAFFIC_RACE;

	public static int _TRAFFIC_DISTANCE;

	[Header("НАГРАДЫ")]
	public int _1ST_AWARD;

	public int _2ST_AWARD;

	public int _3ST_AWARD;

	public static int _1ST_AWARD_;

	public static int _2ST_AWARD_;

	public static int _3ST_AWARD_;

	[Header("НАСТРОЙКА ГОНКИ С ИИ")]
	public bool RACE_CIRCUIT;

	public int RACE_CIRCUIT_LAPS;

	public bool RACE_SPRINT;

	public static bool _RACE_CIRCUIT;

	public static int _RACE_CIRCUIT_LAPS;

	public static bool _RACE_SPRINT;

	public Vector3 PLAYER_POSITION;

	public Vector3 AI1_POSITION;

	public Vector3 AI2_POSITION;

	public Vector3 AI3_POSITION;

	[Header("ПОЗИЦИИ")]
	public static Vector3 _PLAYER_POSITION;

	public static Vector3 _AI1_POSITION;

	public static Vector3 _AI2_POSITION;

	public static Vector3 _AI3_POSITION;

	private bool ENTER;

	private void OnEnable()
	{
		if (GAME_MANAGER.START_RACE_FROM_MENU)
		{
			if (GAME_MANAGER.NEED_INDEX == INDEX)
			{
				if (TRAFFIC_RACE & GAME_MANAGER.RACE_TYPE)
				{
					GAME_MANAGER.PL_X = base.gameObject.transform.position.x;
					GAME_MANAGER.PL_Y = base.gameObject.transform.position.y + 1f;
					GAME_MANAGER.PL_Z = base.gameObject.transform.position.z;
					GAME_MANAGER.PL_ROT = base.gameObject.transform.eulerAngles.y;
				}
				else if (!TRAFFIC_RACE & !GAME_MANAGER.RACE_TYPE)
				{
					GAME_MANAGER.PL_X = base.gameObject.transform.position.x;
					GAME_MANAGER.PL_Y = base.gameObject.transform.position.y + 1f;
					GAME_MANAGER.PL_Z = base.gameObject.transform.position.z;
					GAME_MANAGER.PL_ROT = base.gameObject.transform.eulerAngles.y;
				}
			}
		}
		else if (TRAFFIC_RACE)
		{
			if (ES2.Load<int>("RACE_TRAFFIC" + INDEX) == 1)
			{
				base.gameObject.SetActive(value: false);
			}
		}
		else if (ES2.Load<int>("RACE_" + INDEX) == 1)
		{
			base.gameObject.SetActive(value: false);
		}
	}

	private void OnTriggerStay(Collider car2)
	{
		if (!((car2.tag == "Player") & !GAME_MANAGER.IN_MISSION & (RCC_CarControllerV3.SPEED < 15f) & (GAME_MANAGER.IN_RACE_POINT == 0) & !ENTER & !GAME_MANAGER.TAXI_DRIVER & !GAME_MANAGER.MEDIC_DRIVER & !GAME_MANAGER.COP_DRIVER & !GAME_MANAGER.CAR_WATER_ & (GAME_MANAGER.PLAYER_FUEL > 0.1f)))
		{
			return;
		}
		_AI_RACE = false;
		_SPEED_RACE = false;
		_TIME_RACE = false;
		_TRAFFIC_RACE = false;
		if (AI_RACE)
		{
			GAME_MANAGER.IN_RACE_POINT = 1;
		}
		if (SPEED_RACE)
		{
			GAME_MANAGER.IN_RACE_POINT = 2;
		}
		if (TIME_RACE)
		{
			GAME_MANAGER.IN_RACE_POINT = 3;
		}
		if (TRAFFIC_RACE)
		{
			GAME_MANAGER.IN_RACE_POINT = 4;
			_TRAFFIC_DISTANCE = TRAFFIC_DISTANCE - 500;
		}
		_INDEX = INDEX;
		if (TRAFFIC_RACE)
		{
			if (ES2.Load<int>("RACE_TRAFFIC" + INDEX) == 1)
			{
				_1ST_AWARD /= 2;
			}
		}
		else
		{
			if (ES2.Load<int>("RACE_" + INDEX) == 1)
			{
				_1ST_AWARD /= 2;
				_2ST_AWARD /= 2;
				_3ST_AWARD /= 2;
			}
			if (ES2.Load<int>("RACE_" + INDEX) == 2)
			{
				_2ST_AWARD /= 2;
				_3ST_AWARD /= 2;
			}
			if (ES2.Load<int>("RACE_" + INDEX) == 3)
			{
				_3ST_AWARD /= 2;
			}
		}
		_1ST_AWARD_ = _1ST_AWARD;
		_2ST_AWARD_ = _2ST_AWARD;
		_3ST_AWARD_ = _3ST_AWARD;
		_PLAYER_POSITION = PLAYER_POSITION;
		_AI1_POSITION = AI1_POSITION;
		_AI2_POSITION = AI2_POSITION;
		_AI3_POSITION = AI3_POSITION;
		_RACE_CIRCUIT = RACE_CIRCUIT;
		_RACE_CIRCUIT_LAPS = RACE_CIRCUIT_LAPS;
		_RACE_SPRINT = RACE_SPRINT;
		_AI_RACE = AI_RACE;
		_SPEED_RACE = SPEED_RACE;
		_TIME_RACE = TIME_RACE;
		_TRAFFIC_RACE = TRAFFIC_RACE;
		GAME_MANAGER.PL_X = base.gameObject.transform.position.x;
		GAME_MANAGER.PL_Y = base.gameObject.transform.position.y + 0.1f;
		GAME_MANAGER.PL_Z = base.gameObject.transform.position.z;
		GAME_MANAGER.PL_ROT = base.gameObject.transform.eulerAngles.y;
		ENTER = true;
		StartCoroutine(DELAY());
	}

	private IEnumerator DELAY()
	{
		yield return new WaitForSecondsRealtime(10f);
		ENTER = false;
	}

	private void OnTriggerExit(Collider car2)
	{
		if (car2.tag == "Player")
		{
			ENTER = false;
			GAME_MANAGER.IN_RACE_POINT = 0;
		}
	}
}
