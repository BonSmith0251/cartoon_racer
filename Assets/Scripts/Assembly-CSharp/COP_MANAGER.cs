using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class COP_MANAGER : MonoBehaviour
{
	public AudioClip NEGATIVE;

	public GameObject WORD_DAY;

	public GameObject STOP_;

	public GameObject STOP2_;

	public GameObject AUDIO_OBJ;

	public AudioClip VOICE_ZADANIE;

	public AudioClip[] VOICE_COMPLETE;

	public AudioClip[] VOICE_FAIL;

	private bool BLACK_;

	public GameObject NEAR_SND;

	public static bool NEAR;

	public Button COMPLETE_BUTTON;

	public GameObject[] PASSENGER_PREFAB;

	public GameObject COP_UI_NEW_CLIENT;

	public GameObject COP_UI_START;

	public GameObject COP_UI_NEW_LEVEl;

	public GameObject COP_UI_COMPLETE;

	public GameObject COP_UI_CONTROL;

	public GameObject COP_UI_FAIL;

	public GameObject COP_UI_CONTROL_2;

	public Text LEVELUP_LEVEL_TXT;

	public Text COMPLETE_LEVEL_TXT;

	public Text COMPLETE_MONEY_TXT;

	public Text CONTROL_FILL_TEXT;

	public Text START_UI_LEVEL_TXT_DESCR;

	public Text START_UI_LEVEL_TXT;

	public Text START_UI_LEVEL_TXT2;

	public Image LEVELUP_LEVEL_IMG;

	public Image COMPLETE_LEVEL_IMG;

	public Image CONTROL_FILL_IMG;

	public Image CONTROL_FILL_IMG2;

	public Image BUTTON_;

	public Image BUTTON_ICON;

	public Image START_UI_LEVEL_FILL;

	public Sprite BUTTON_OFF;

	public Sprite BUTTON_ON;

	public AudioClip CALL_SND;

	public AudioClip MONEY_SND;

	public AudioClip UI_CLICK;

	public AudioClip[] WOMAN_HIT_SND;

	public AudioClip[] MAN_HIT_SND;

	public static bool PASSENGER_GENDER;

	public static bool PASSENGER_PICKUP;

	public static bool PASSENGER_COMPLETE;

	public static bool PASSENGER_HIT;

	public static bool PASSENGER_FAIL;

	private bool air_snd;

	public static float PASSENGER_COMFORT_;

	public static float GPS_DIST;

	private int SND_RND;

	private float TIMER_MONEY;

	private float TIMER_MONEY_ACS;

	private float PASSENGER_TIMER;

	private int PASSENGER_RND;

	private bool PASSENGER_CREATE;

	private bool NEW_LEVEL_;

	private int POSITION_RND;

	private int ALL_MONEY;

	private int ADD_MONEY;

	public Vector3[] PASSENGER_POSITION;

	public int[] PASSENGER_WAYPOINT;

	public Vector3[] PASSENGER_POSITION2;

	public int[] PASSENGER_WAYPOINT2;

	public GameObject COP_LIGHT;

	private int LICENSE;

	private void Start()
	{
		LICENSE = ES2.Load<int>("COP_LICENSE");
		BLACK_ = false;
		GAME_MANAGER.MEDIC_DRIVER = false;
		GAME_MANAGER.TAXI_DRIVER = false;
		GAME_MANAGER.COP_DRIVER = false;
	}

	private void START_INFO()
	{
		if (GAME_MANAGER.COP_DRIVER_LEVEL < 10)
		{
			if (MENU_MANAGER.LANGUAGE == 0)
			{
				START_UI_LEVEL_TXT.text = "LEVEL " + GAME_MANAGER.COP_DRIVER_LEVEL;
			}
			else
			{
				START_UI_LEVEL_TXT.text = "УРОВЕНЬ " + GAME_MANAGER.COP_DRIVER_LEVEL;
			}
			START_UI_LEVEL_FILL.fillAmount = (float)GAME_MANAGER.COP_DRIVER_LEVEL / 10f;
			START_UI_LEVEL_TXT2.text = Mathf.Round(GAME_MANAGER.COP_DRIVER_LEVEL * 10000 / 1000) + " %";
		}
		else
		{
			START_UI_LEVEL_TXT2.text = "100 %";
			if (MENU_MANAGER.LANGUAGE == 0)
			{
				START_UI_LEVEL_TXT.text = "LEVEL 10";
			}
			else
			{
				START_UI_LEVEL_TXT.text = "УРОВЕНЬ 10";
			}
			START_UI_LEVEL_FILL.fillAmount = 1f;
		}
		if (MENU_MANAGER.LANGUAGE == 0)
		{
			if (GAME_MANAGER.COP_DRIVER_LEVEL == 0)
			{
				START_UI_LEVEL_TXT_DESCR.text = "BEGINNER";
			}
			if (GAME_MANAGER.COP_DRIVER_LEVEL == 1)
			{
				START_UI_LEVEL_TXT_DESCR.text = "ROOKIE";
			}
			if (GAME_MANAGER.COP_DRIVER_LEVEL == 2)
			{
				START_UI_LEVEL_TXT_DESCR.text = "STUDENT";
			}
			if (GAME_MANAGER.COP_DRIVER_LEVEL == 3)
			{
				START_UI_LEVEL_TXT_DESCR.text = "REGULAR";
			}
			if (GAME_MANAGER.COP_DRIVER_LEVEL == 4)
			{
				START_UI_LEVEL_TXT_DESCR.text = "STRONG";
			}
			if (GAME_MANAGER.COP_DRIVER_LEVEL == 5)
			{
				START_UI_LEVEL_TXT_DESCR.text = "RACER";
			}
			if (GAME_MANAGER.COP_DRIVER_LEVEL == 6)
			{
				START_UI_LEVEL_TXT_DESCR.text = "MASTER";
			}
			if (GAME_MANAGER.COP_DRIVER_LEVEL == 7)
			{
				START_UI_LEVEL_TXT_DESCR.text = "EXPERT";
			}
			if (GAME_MANAGER.COP_DRIVER_LEVEL == 8)
			{
				START_UI_LEVEL_TXT_DESCR.text = "PROFESSIONAL";
			}
			if (GAME_MANAGER.COP_DRIVER_LEVEL == 9)
			{
				START_UI_LEVEL_TXT_DESCR.text = "ELITE";
			}
			if (GAME_MANAGER.COP_DRIVER_LEVEL == 10)
			{
				START_UI_LEVEL_TXT_DESCR.text = "LEGEND";
			}
		}
		else
		{
			if (GAME_MANAGER.COP_DRIVER_LEVEL == 0)
			{
				START_UI_LEVEL_TXT_DESCR.text = "ЧАЙНИК";
			}
			if (GAME_MANAGER.COP_DRIVER_LEVEL == 1)
			{
				START_UI_LEVEL_TXT_DESCR.text = "НОВИЧОК";
			}
			if (GAME_MANAGER.COP_DRIVER_LEVEL == 2)
			{
				START_UI_LEVEL_TXT_DESCR.text = "СТУДЕНТ";
			}
			if (GAME_MANAGER.COP_DRIVER_LEVEL == 3)
			{
				START_UI_LEVEL_TXT_DESCR.text = "ОБЫЧНЫЙ";
			}
			if (GAME_MANAGER.COP_DRIVER_LEVEL == 4)
			{
				START_UI_LEVEL_TXT_DESCR.text = "УВЕРЕННЫЙ";
			}
			if (GAME_MANAGER.COP_DRIVER_LEVEL == 5)
			{
				START_UI_LEVEL_TXT_DESCR.text = "ГОНЩИК";
			}
			if (GAME_MANAGER.COP_DRIVER_LEVEL == 6)
			{
				START_UI_LEVEL_TXT_DESCR.text = "МАСТЕР";
			}
			if (GAME_MANAGER.COP_DRIVER_LEVEL == 7)
			{
				START_UI_LEVEL_TXT_DESCR.text = "ЭКСПЕРТ";
			}
			if (GAME_MANAGER.COP_DRIVER_LEVEL == 8)
			{
				START_UI_LEVEL_TXT_DESCR.text = "ПРОФЕССИОНАЛ";
			}
			if (GAME_MANAGER.COP_DRIVER_LEVEL == 9)
			{
				START_UI_LEVEL_TXT_DESCR.text = "ЭЛИТА";
			}
			if (GAME_MANAGER.COP_DRIVER_LEVEL == 10)
			{
				START_UI_LEVEL_TXT_DESCR.text = "ЛЕГЕНДА";
			}
		}
	}

	public void SWITCH_()
	{
		if (!GAME_MANAGER.IN_RACE & (LICENSE == 1) & !GAME_MANAGER.IN_MISSION)
		{
			if (!GAME_MANAGER.COP_DRIVER)
			{
				AudioSource.PlayClipAtPoint(UI_CLICK, Camera.main.transform.position);
				GAME_MANAGER.COP_DRIVER = true;
				WORD_DAY.SetActive(value: false);
				if (COP_LIGHT == null)
				{
					COP_LIGHT = Object.FindObjectOfType<RCC_CarControllerV3>().GetComponent<TRAIL_CONTROLLER>().COP_LIGHT;
				}
			}
			else if (!PASSENGER_PICKUP)
			{
				base.gameObject.GetComponent<GAME_MANAGER>().SHOW_3D_ICONS();
				AudioSource.PlayClipAtPoint(UI_CLICK, Camera.main.transform.position);
				GAME_MANAGER.COP_DRIVER = !GAME_MANAGER.COP_DRIVER;
				if (PASSENGER_CREATE)
				{
					GameObject[] array = GameObject.FindGameObjectsWithTag("PASSENGER_PREFAB");
					GameObject[] array2 = array;
					foreach (GameObject obj in array2)
					{
						Object.Destroy(obj);
					}
					PASSENGER_CREATE = false;
				}
			}
			if (GAME_MANAGER.COP_DRIVER & !PASSENGER_PICKUP)
			{
				if (ES2.Exists("COP_DRIVER_LEVEL"))
				{
					GAME_MANAGER.COP_DRIVER_LEVEL = ES2.Load<int>("COP_DRIVER_LEVEL");
				}
				if (ES2.Exists("COP_DRIVER_PROGRESS"))
				{
					GAME_MANAGER.COP_DRIVER_PROGRESS = ES2.Load<float>("COP_DRIVER_PROGRESS");
				}
				START_INFO();
				PASSENGER_TIMER = Random.Range(5, 10);
				COP_UI_START.SetActive(value: true);
				BUTTON_.sprite = BUTTON_ON;
				BUTTON_ICON.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
			}
			if (!GAME_MANAGER.COP_DRIVER)
			{
				COP_UI_START.SetActive(value: false);
				BUTTON_.sprite = BUTTON_OFF;
				BUTTON_ICON.GetComponent<Image>().color = new Color(0f, 0f, 0f, 0.5f);
			}
		}
		else
		{
			AudioSource.PlayClipAtPoint(NEGATIVE, Camera.main.transform.position);
		}
	}

	private IEnumerator FAIL_VOICE()
	{
		yield return new WaitForSecondsRealtime(1f);
		if (MENU_MANAGER.LANGUAGE == 1)
		{
			AUDIO_OBJ.GetComponent<AudioSource>().clip = VOICE_FAIL[Random.Range(0, VOICE_FAIL.Length)];
			AUDIO_OBJ.GetComponent<AudioSource>().Play();
		}
	}

	private void Update()
	{
		if (!GAME_MANAGER.COP_DRIVER)
		{
			return;
		}
		if ((PASSENGER_TIMER > 0f) & !PASSENGER_CREATE & GAME_MANAGER.COP_DRIVER)
		{
			STOP_.SetActive(value: true);
			STOP2_.SetActive(value: true);
			PASSENGER_TIMER -= Time.deltaTime / 2f;
			if (PASSENGER_TIMER < 1f)
			{
				COP_UI_START.SetActive(value: false);
				PASSENGER_RND = Random.Range(0, PASSENGER_PREFAB.Length);
				if (MENU_MANAGER.LOADING_LEVEL == 0)
				{
					POSITION_RND = Random.Range(0, PASSENGER_POSITION.Length);
					GameObject gameObject = Object.Instantiate(PASSENGER_PREFAB[PASSENGER_RND], new Vector3(PASSENGER_POSITION[POSITION_RND].x, 32f, PASSENGER_POSITION[POSITION_RND].z), base.transform.rotation);
					gameObject.transform.eulerAngles = new Vector3(0f, PASSENGER_POSITION[POSITION_RND].y, 0f);
					gameObject.GetComponent<RCC_AICarController>().currentWaypoint = PASSENGER_WAYPOINT[POSITION_RND];
				}
				else
				{
					POSITION_RND = Random.Range(0, PASSENGER_POSITION2.Length);
					GameObject gameObject2 = Object.Instantiate(PASSENGER_PREFAB[PASSENGER_RND], new Vector3(PASSENGER_POSITION2[POSITION_RND].x, 32f, PASSENGER_POSITION2[POSITION_RND].z), base.transform.rotation);
					gameObject2.transform.eulerAngles = new Vector3(0f, PASSENGER_POSITION2[POSITION_RND].y, 0f);
					gameObject2.GetComponent<RCC_AICarController>().currentWaypoint = PASSENGER_WAYPOINT2[POSITION_RND];
				}
				PASSENGER_CREATE = true;
				PASSENGER_PICKUP = true;
				if (COP_LIGHT == null)
				{
					COP_LIGHT.SetActive(value: false);
				}
				NEAR_SND.SetActive(value: false);
				AudioSource.PlayClipAtPoint(CALL_SND, Camera.main.transform.position);
				PASSENGER_COMFORT_ = 1f;
				if (MENU_MANAGER.LANGUAGE == 1)
				{
					AUDIO_OBJ.GetComponent<AudioSource>().clip = VOICE_ZADANIE;
					AUDIO_OBJ.GetComponent<AudioSource>().Play();
				}
				base.gameObject.GetComponent<GAME_MANAGER>().HIDE_3D_ICONS();
				COP_UI_NEW_CLIENT.SetActive(value: true);
				StartCoroutine(NEW_CLIENT());
				ALL_MONEY = 0;
				ADD_MONEY = 0;
				PASSENGER_FAIL = false;
				PASSENGER_HIT = false;
				GPS_DIST = 1f;
				CONTROL_FILL_IMG2.fillAmount = 1f;
				CONTROL_FILL_IMG.fillAmount = PASSENGER_COMFORT_;
				CONTROL_FILL_TEXT.text = Mathf.Round(PASSENGER_COMFORT_ * 10000f / 100f) + " %";
			}
		}
		if (PASSENGER_PICKUP & !PASSENGER_COMPLETE & !PASSENGER_FAIL)
		{
			if (NEAR)
			{
				COP_LIGHT.SetActive(value: true);
				NEAR_SND.SetActive(value: true);
			}
			else
			{
				COP_LIGHT.SetActive(value: false);
				NEAR_SND.SetActive(value: false);
			}
			CONTROL_FILL_IMG2.fillAmount = GPS_DIST;
			if ((GPS_DIST < 0.01f) & !PASSENGER_FAIL)
			{
				StartCoroutine(FAIL_VOICE());
				PASSENGER_FAIL = true;
			}
		}
		if (PASSENGER_HIT & !PASSENGER_FAIL & !PASSENGER_COMPLETE)
		{
			if (!PASSENGER_GENDER)
			{
				SND_RND = Random.Range(0, WOMAN_HIT_SND.Length);
				AudioSource.PlayClipAtPoint(WOMAN_HIT_SND[SND_RND], Camera.main.transform.position);
			}
			else
			{
				SND_RND = Random.Range(0, MAN_HIT_SND.Length);
				AudioSource.PlayClipAtPoint(MAN_HIT_SND[SND_RND], Camera.main.transform.position);
			}
			if (PASSENGER_COMFORT_ > 0f)
			{
				PASSENGER_COMFORT_ -= RCC_CarControllerV3.SPEED / (float)Random.Range(400, 600);
			}
			if ((PASSENGER_COMFORT_ < 0.01f) & !PASSENGER_COMPLETE)
			{
				PASSENGER_COMPLETE = true;
				PASSENGER_COMFORT_ = 0f;
			}
			CONTROL_FILL_IMG.fillAmount = PASSENGER_COMFORT_;
			CONTROL_FILL_TEXT.text = Mathf.Round(PASSENGER_COMFORT_ * 10000f / 100f) + " %";
			PASSENGER_HIT = false;
		}
		if (PASSENGER_COMPLETE & PASSENGER_PICKUP)
		{
			NEAR_SND.SetActive(value: false);
			STOP_.SetActive(value: false);
			STOP2_.SetActive(value: false);
			COMPLETE_BUTTON.interactable = false;
			if (GAME_MANAGER.COP_DRIVER_LEVEL == 0)
			{
				ALL_MONEY = Random.Range(30, 50) + 10;
			}
			else
			{
				ALL_MONEY = Random.Range(30, 50) + 10 * GAME_MANAGER.COP_DRIVER_LEVEL;
			}
			if (GAME_MANAGER.COP_DRIVER_LEVEL < 10)
			{
				if (GAME_MANAGER.COP_DRIVER_LEVEL > 0)
				{
					PASSENGER_COMFORT_ = 1f;
					int num = GAME_MANAGER.COP_DRIVER_LEVEL + 3;
					float num2 = PASSENGER_COMFORT_ / (float)num;
					GAME_MANAGER.COP_DRIVER_PROGRESS += num2;
				}
				else
				{
					GAME_MANAGER.COP_DRIVER_PROGRESS += 0.5f;
				}
				if (GAME_MANAGER.COP_DRIVER_PROGRESS > 0.99f)
				{
					GAME_MANAGER.COP_DRIVER_PROGRESS = 1f;
					NEW_LEVEL_ = true;
				}
				COMPLETE_LEVEL_TXT.text = Mathf.Round(GAME_MANAGER.COP_DRIVER_PROGRESS * 10000f / 100f) + " %";
				COMPLETE_LEVEL_IMG.fillAmount = GAME_MANAGER.COP_DRIVER_PROGRESS;
			}
			else
			{
				COMPLETE_LEVEL_TXT.text = "100 %";
				COMPLETE_LEVEL_IMG.fillAmount = 1f;
			}
			COP_LIGHT.SetActive(value: false);
			NEAR_SND.SetActive(value: false);
			NEAR = false;
			COP_UI_COMPLETE.SetActive(value: true);
			COP_UI_CONTROL.SetActive(value: false);
			COP_UI_CONTROL_2.SetActive(value: false);
			PASSENGER_PICKUP = false;
			return;
		}
		if (ADD_MONEY == ALL_MONEY)
		{
			COMPLETE_BUTTON.interactable = true;
		}
		if ((ADD_MONEY < ALL_MONEY) & PASSENGER_COMPLETE)
		{
			TIMER_MONEY += Time.deltaTime * 5f + TIMER_MONEY_ACS;
			TIMER_MONEY_ACS += Time.deltaTime / 10f;
			if (TIMER_MONEY > 1f)
			{
				ADD_MONEY++;
				GAME_MANAGER.PLAYER_MONEY++;
				TIMER_MONEY = 0f;
				AudioSource.PlayClipAtPoint(MONEY_SND, Camera.main.transform.position);
			}
			COMPLETE_MONEY_TXT.text = "+ " + ADD_MONEY;
		}
		if (NEW_LEVEL_ & !COP_UI_COMPLETE.activeInHierarchy)
		{
			COP_UI_NEW_LEVEl.SetActive(value: true);
			GAME_MANAGER.COP_DRIVER_PROGRESS = 0f;
			GAME_MANAGER.COP_DRIVER_LEVEL++;
			if (GAME_MANAGER.COP_DRIVER_LEVEL > 9)
			{
				LEVELUP_LEVEL_IMG.fillAmount = 1f;
				LEVELUP_LEVEL_TXT.text = "100 %";
			}
			else
			{
				LEVELUP_LEVEL_IMG.fillAmount = (float)GAME_MANAGER.COP_DRIVER_LEVEL / 10f;
				LEVELUP_LEVEL_TXT.text = Mathf.Round(GAME_MANAGER.COP_DRIVER_LEVEL * 10000 / 1000) + " %";
			}
			ES2.Save(GAME_MANAGER.COP_DRIVER_LEVEL, "COP_DRIVER_LEVEL");
			ES2.Save(GAME_MANAGER.COP_DRIVER_PROGRESS, "COP_DRIVER_PROGRESS");
			StartCoroutine(NEW_LEVEL());
			NEW_LEVEL_ = false;
		}
		if (PASSENGER_FAIL & PASSENGER_PICKUP)
		{
			NEAR_SND.SetActive(value: false);
			STOP_.SetActive(value: false);
			STOP2_.SetActive(value: false);
			PASSENGER_PICKUP = false;
			COP_UI_CONTROL.SetActive(value: false);
			COP_UI_CONTROL_2.SetActive(value: false);
			COP_UI_FAIL.SetActive(value: true);
			PASSENGER_FAIL = true;
			CONTROL_FILL_IMG.fillAmount = 0f;
			CONTROL_FILL_TEXT.text = "0 %";
		}
	}

	public void END_FUEL()
	{
		base.gameObject.GetComponent<GAME_MANAGER>().SHOW_3D_ICONS();
		COP_UI_CONTROL.SetActive(value: false);
		GameObject[] array = GameObject.FindGameObjectsWithTag("PASSENGER_PREFAB");
		GameObject[] array2 = array;
		foreach (GameObject obj in array2)
		{
			Object.Destroy(obj);
		}
		GameObject[] array3 = GameObject.FindGameObjectsWithTag("PASSENGER_TARGET");
		GameObject[] array4 = array3;
		foreach (GameObject obj2 in array4)
		{
			Object.Destroy(obj2);
		}
		PASSENGER_PICKUP = false;
		PASSENGER_FAIL = false;
		COP_UI_FAIL.SetActive(value: false);
		PASSENGER_CREATE = false;
		BLACK_ = false;
		PASSENGER_TIMER = Random.Range(10, 20);
		RACE_MANAGER.START_RACE = false;
		GAME_MANAGER.IN_RACE_POINT = 0;
		TAXI_MANAGER.PASSENGER_COMPLETE = false;
		MEDIC_MANAGER.PASSENGER_COMPLETE = false;
		TAXI_MANAGER.PASSENGER_FAIL = false;
		MEDIC_MANAGER.PASSENGER_FAIL = false;
		PASSENGER_FAIL = false;
		PASSENGER_COMPLETE = false;
	}

	private IEnumerator NEW_LEVEL()
	{
		yield return new WaitForSecondsRealtime(3f);
		COP_UI_NEW_LEVEl.SetActive(value: false);
	}

	private IEnumerator NEW_CLIENT()
	{
		yield return new WaitForSecondsRealtime(3f);
		COP_UI_CONTROL.SetActive(value: true);
		COP_UI_NEW_CLIENT.SetActive(value: false);
		StartCoroutine(NEW_CLIENT2());
	}

	private IEnumerator NEW_CLIENT2()
	{
		COP_UI_CONTROL_2.SetActive(value: false);
		yield return new WaitForSecondsRealtime(3f);
		COP_UI_CONTROL_2.SetActive(value: true);
	}

	public void CLOSE_FAIL()
	{
		if (COP_LIGHT != null)
		{
			COP_LIGHT.SetActive(value: false);
		}
		GameObject[] array = GameObject.FindGameObjectsWithTag("PASSENGER_PREFAB");
		GameObject[] array2 = array;
		foreach (GameObject obj in array2)
		{
			Object.Destroy(obj);
		}
		GameObject[] array3 = GameObject.FindGameObjectsWithTag("PASSENGER_TARGET");
		GameObject[] array4 = array3;
		foreach (GameObject obj2 in array4)
		{
			Object.Destroy(obj2);
		}
		base.gameObject.GetComponent<GAME_MANAGER>().SHOW_3D_ICONS();
		AudioSource.PlayClipAtPoint(UI_CLICK, Camera.main.transform.position);
		if (COP_LIGHT != null)
		{
			COP_LIGHT.SetActive(value: false);
		}
		NEAR_SND.SetActive(value: false);
		PASSENGER_PICKUP = false;
		PASSENGER_FAIL = false;
		COP_UI_FAIL.SetActive(value: false);
		PASSENGER_CREATE = false;
		RACE_MANAGER.START_RACE = false;
		GAME_MANAGER.IN_RACE_POINT = 0;
		TAXI_MANAGER.PASSENGER_COMPLETE = false;
		MEDIC_MANAGER.PASSENGER_COMPLETE = false;
		TAXI_MANAGER.PASSENGER_FAIL = false;
		MEDIC_MANAGER.PASSENGER_FAIL = false;
		PASSENGER_FAIL = false;
		PASSENGER_COMPLETE = false;
		GameObject[] array5 = GameObject.FindGameObjectsWithTag("PASSENGER_PREFAB");
		GameObject[] array6 = array5;
		foreach (GameObject obj3 in array6)
		{
			Object.Destroy(obj3);
		}
		PASSENGER_TIMER = Random.Range(10, 20);
	}

	public void CLOSE_COMPLETE()
	{
		int num = Random.Range(0, 3);
		if (num == 1 && MENU_MANAGER.APPODEAL_ADS_TIMER == 0f)
		{
			MENU_MANAGER.APPODEAL_ADS_TIMER = 40f;
		}
		if (COP_LIGHT != null)
		{
			COP_LIGHT.SetActive(value: false);
		}
		base.gameObject.GetComponent<GAME_MANAGER>().SHOW_3D_ICONS();
		if (MENU_MANAGER.LANGUAGE == 1)
		{
			AUDIO_OBJ.GetComponent<AudioSource>().clip = VOICE_COMPLETE[Random.Range(0, VOICE_COMPLETE.Length)];
			AUDIO_OBJ.GetComponent<AudioSource>().Play();
		}
		ES2.Save(GAME_MANAGER.PLAYER_MONEY, "PLAYER_MONEY");
		ES2.Save(GAME_MANAGER.COP_DRIVER_PROGRESS, "COP_DRIVER_PROGRESS");
		PASSENGER_CREATE = false;
		AudioSource.PlayClipAtPoint(UI_CLICK, Camera.main.transform.position);
		PASSENGER_PICKUP = false;
		TIMER_MONEY = 0f;
		TIMER_MONEY_ACS = 0f;
		ADD_MONEY = 0;
		PASSENGER_COMPLETE = false;
		COP_UI_COMPLETE.SetActive(value: false);
		PASSENGER_TIMER = Random.Range(20, 40);
		RACE_MANAGER.START_RACE = false;
		GAME_MANAGER.IN_RACE_POINT = 0;
		TAXI_MANAGER.PASSENGER_COMPLETE = false;
		MEDIC_MANAGER.PASSENGER_COMPLETE = false;
		TAXI_MANAGER.PASSENGER_FAIL = false;
		MEDIC_MANAGER.PASSENGER_FAIL = false;
		PASSENGER_FAIL = false;
		PASSENGER_COMPLETE = false;
		COP_LIGHT.SetActive(value: false);
		NEAR_SND.SetActive(value: false);
		if (ES2.Load<string>("DAILY_MISSION_2_TYPE") == "WIN_COP_JOB" && ES2.Load<int>("DAILY_MISSION_2") < ES2.Load<int>("DAILY_MISSION_2_NEED"))
		{
			ES2.Save(ES2.Load<int>("DAILY_MISSION_2") + 1, "DAILY_MISSION_2");
			if (ES2.Load<int>("DAILY_MISSION_2") == ES2.Load<int>("DAILY_MISSION_2_NEED"))
			{
				GAME_MANAGER.DTAST_COMPELTE = true;
			}
		}
		GameObject[] array = GameObject.FindGameObjectsWithTag("PASSENGER_PREFAB");
		GameObject[] array2 = array;
		foreach (GameObject obj in array2)
		{
			Object.Destroy(obj);
		}
	}
}
