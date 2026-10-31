using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TAXI_MANAGER : MonoBehaviour
{
	public AudioClip NEGATIVE;

	private int G;

	private float H;

	public GameObject FALIED_TIME_UI;

	public GameObject TIME_OBJ;

	public Image TIME_FILL;

	private float TIME__;

	private float TIME_LOW;

	private int TIME_RND;

	public GameObject WORD_DAY;

	public GameObject STOP_;

	public GameObject STOP2_;

	public GameObject AUDIO_OBJ;

	public AudioClip VOICE_ZADANIE;

	public AudioClip[] VOICE_COMPLETE;

	public AudioClip[] VOICE_FAIL;

	private bool BLACK_;

	public Button COMPLETE_BUTTON;

	public GameObject[] PASSENGER_PREFAB;

	public GameObject TARGET_PREFAB;

	public GameObject BLACK_FX;

	public GameObject TAXI_UI_NEW_CLIENT;

	public GameObject TAXI_UI_START;

	public GameObject TAXI_UI_NEW_LEVEl;

	public GameObject TAXI_UI_COMPLETE;

	public GameObject TAXI_UI_CONTROL;

	public GameObject TAXI_UI_FAIL;

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

	public Image BUTTON_;

	public Image BUTTON_ICON;

	public Image START_UI_LEVEL_FILL;

	public Sprite BUTTON_OFF;

	public Sprite BUTTON_ON;

	public AudioClip CALL_SND;

	public AudioClip MONEY_SND;

	public AudioClip UI_CLICK;

	public AudioClip DOOR_CLOSED_SND;

	public AudioClip[] WOMAN_HIT_SND;

	public AudioClip[] MAN_HIT_SND;

	public AudioClip[] WOMAN_COMPLETE_SND;

	public AudioClip[] MAN_COMPLETE_SND;

	public AudioClip[] WOMAN_AIR_SND;

	public AudioClip[] MAN_AIR_SND;

	public static bool PASSENGER_GENDER;

	public static bool PASSENGER_PICKUP;

	public static bool PASSENGER_COMPLETE;

	public static bool PASSENGER_HIT;

	public static bool PASSENGER_AIR;

	public static bool PASSENGER_FAIL;

	private bool air_snd;

	private float PASSENGER_COMFORT_;

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

	private int LICENSE;

	public Vector3[] PASSENGER_POSITION;

	public Vector3[] TARGET_POSITION;

	public Vector3[] PASSENGER_POSITION2;

	public Vector3[] TARGET_POSITION2;

	private void Start()
	{
		LICENSE = ES2.Load<int>("TAXI_LICENSE");
		BLACK_ = false;
		GAME_MANAGER.MEDIC_DRIVER = false;
		GAME_MANAGER.TAXI_DRIVER = false;
		GAME_MANAGER.COP_DRIVER = false;
	}

	private void START_INFO()
	{
		if (GAME_MANAGER.TAXI_DRIVER_LEVEL < 10)
		{
			if (MENU_MANAGER.LANGUAGE == 0)
			{
				START_UI_LEVEL_TXT.text = "LEVEL " + GAME_MANAGER.TAXI_DRIVER_LEVEL;
			}
			else
			{
				START_UI_LEVEL_TXT.text = "УРОВЕНЬ " + GAME_MANAGER.TAXI_DRIVER_LEVEL;
			}
			START_UI_LEVEL_FILL.fillAmount = (float)GAME_MANAGER.TAXI_DRIVER_LEVEL / 10f;
			START_UI_LEVEL_TXT2.text = Mathf.Round(GAME_MANAGER.TAXI_DRIVER_LEVEL * 10000 / 1000) + " %";
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
			if (GAME_MANAGER.TAXI_DRIVER_LEVEL == 0)
			{
				START_UI_LEVEL_TXT_DESCR.text = "BEGINNER";
			}
			if (GAME_MANAGER.TAXI_DRIVER_LEVEL == 1)
			{
				START_UI_LEVEL_TXT_DESCR.text = "ROOKIE";
			}
			if (GAME_MANAGER.TAXI_DRIVER_LEVEL == 2)
			{
				START_UI_LEVEL_TXT_DESCR.text = "STUDENT";
			}
			if (GAME_MANAGER.TAXI_DRIVER_LEVEL == 3)
			{
				START_UI_LEVEL_TXT_DESCR.text = "REGULAR";
			}
			if (GAME_MANAGER.TAXI_DRIVER_LEVEL == 4)
			{
				START_UI_LEVEL_TXT_DESCR.text = "STRONG";
			}
			if (GAME_MANAGER.TAXI_DRIVER_LEVEL == 5)
			{
				START_UI_LEVEL_TXT_DESCR.text = "RACER";
			}
			if (GAME_MANAGER.TAXI_DRIVER_LEVEL == 6)
			{
				START_UI_LEVEL_TXT_DESCR.text = "MASTER";
			}
			if (GAME_MANAGER.TAXI_DRIVER_LEVEL == 7)
			{
				START_UI_LEVEL_TXT_DESCR.text = "EXPERT";
			}
			if (GAME_MANAGER.TAXI_DRIVER_LEVEL == 8)
			{
				START_UI_LEVEL_TXT_DESCR.text = "PROFESSIONAL";
			}
			if (GAME_MANAGER.TAXI_DRIVER_LEVEL == 9)
			{
				START_UI_LEVEL_TXT_DESCR.text = "ELITE";
			}
			if (GAME_MANAGER.TAXI_DRIVER_LEVEL == 10)
			{
				START_UI_LEVEL_TXT_DESCR.text = "LEGEND";
			}
		}
		else
		{
			if (GAME_MANAGER.TAXI_DRIVER_LEVEL == 0)
			{
				START_UI_LEVEL_TXT_DESCR.text = "ЧАЙНИК";
			}
			if (GAME_MANAGER.TAXI_DRIVER_LEVEL == 1)
			{
				START_UI_LEVEL_TXT_DESCR.text = "НОВИЧОК";
			}
			if (GAME_MANAGER.TAXI_DRIVER_LEVEL == 2)
			{
				START_UI_LEVEL_TXT_DESCR.text = "СТУДЕНТ";
			}
			if (GAME_MANAGER.TAXI_DRIVER_LEVEL == 3)
			{
				START_UI_LEVEL_TXT_DESCR.text = "ОБЫЧНЫЙ";
			}
			if (GAME_MANAGER.TAXI_DRIVER_LEVEL == 4)
			{
				START_UI_LEVEL_TXT_DESCR.text = "УВЕРЕННЫЙ";
			}
			if (GAME_MANAGER.TAXI_DRIVER_LEVEL == 5)
			{
				START_UI_LEVEL_TXT_DESCR.text = "ГОНЩИК";
			}
			if (GAME_MANAGER.TAXI_DRIVER_LEVEL == 6)
			{
				START_UI_LEVEL_TXT_DESCR.text = "МАСТЕР";
			}
			if (GAME_MANAGER.TAXI_DRIVER_LEVEL == 7)
			{
				START_UI_LEVEL_TXT_DESCR.text = "ЭКСПЕРТ";
			}
			if (GAME_MANAGER.TAXI_DRIVER_LEVEL == 8)
			{
				START_UI_LEVEL_TXT_DESCR.text = "ПРОФЕССИОНАЛ";
			}
			if (GAME_MANAGER.TAXI_DRIVER_LEVEL == 9)
			{
				START_UI_LEVEL_TXT_DESCR.text = "ЭЛИТА";
			}
			if (GAME_MANAGER.TAXI_DRIVER_LEVEL == 10)
			{
				START_UI_LEVEL_TXT_DESCR.text = "ЛЕГЕНДА";
			}
		}
	}

	public void SWITCH_()
	{
		if (!GAME_MANAGER.IN_RACE & (LICENSE == 1) & !GAME_MANAGER.IN_MISSION)
		{
			if (!GAME_MANAGER.TAXI_DRIVER)
			{
				AudioSource.PlayClipAtPoint(UI_CLICK, Camera.main.transform.position);
				GAME_MANAGER.TAXI_DRIVER = true;
				WORD_DAY.SetActive(value: false);
			}
			else if (!PASSENGER_PICKUP)
			{
				base.gameObject.GetComponent<GAME_MANAGER>().SHOW_3D_ICONS();
				AudioSource.PlayClipAtPoint(UI_CLICK, Camera.main.transform.position);
				GAME_MANAGER.TAXI_DRIVER = !GAME_MANAGER.TAXI_DRIVER;
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
			if (GAME_MANAGER.TAXI_DRIVER & !PASSENGER_PICKUP)
			{
				if (ES2.Exists("TAXI_DRIVER_LEVEL"))
				{
					GAME_MANAGER.TAXI_DRIVER_LEVEL = ES2.Load<int>("TAXI_DRIVER_LEVEL");
				}
				if (ES2.Exists("TAXI_DRIVER_PROGRESS"))
				{
					GAME_MANAGER.TAXI_DRIVER_PROGRESS = ES2.Load<float>("TAXI_DRIVER_PROGRESS");
				}
				START_INFO();
				PASSENGER_TIMER = Random.Range(5, 10);
				TAXI_UI_START.SetActive(value: true);
				BUTTON_.sprite = BUTTON_ON;
				BUTTON_ICON.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
			}
			if (!GAME_MANAGER.TAXI_DRIVER)
			{
				TAXI_UI_START.SetActive(value: false);
				BUTTON_.sprite = BUTTON_OFF;
				BUTTON_ICON.GetComponent<Image>().color = new Color(0f, 0f, 0f, 0.5f);
			}
		}
		else
		{
			AudioSource.PlayClipAtPoint(NEGATIVE, Camera.main.transform.position);
		}
	}

	private void Update()
	{
		if (!GAME_MANAGER.TAXI_DRIVER)
		{
			return;
		}
		if ((PASSENGER_TIMER > 0f) & !PASSENGER_CREATE & GAME_MANAGER.TAXI_DRIVER & (GAME_MANAGER.PLAYER_FUEL > 0f))
		{
			PASSENGER_TIMER -= Time.deltaTime / 2f;
			if (PASSENGER_TIMER < 1f)
			{
				TAXI_UI_START.SetActive(value: false);
				PASSENGER_RND = Random.Range(0, PASSENGER_PREFAB.Length);
				if (MENU_MANAGER.LOADING_LEVEL == 0)
				{
					POSITION_RND = Random.Range(0, PASSENGER_POSITION.Length);
					GameObject gameObject = Object.Instantiate(PASSENGER_PREFAB[PASSENGER_RND], new Vector3(PASSENGER_POSITION[POSITION_RND].x, 30f, PASSENGER_POSITION[POSITION_RND].z), base.transform.rotation);
					gameObject.transform.eulerAngles = new Vector3(0f, PASSENGER_POSITION[POSITION_RND].y, 0f);
				}
				else
				{
					POSITION_RND = Random.Range(0, PASSENGER_POSITION2.Length);
					GameObject gameObject2 = Object.Instantiate(PASSENGER_PREFAB[PASSENGER_RND], new Vector3(PASSENGER_POSITION2[POSITION_RND].x, 30f, PASSENGER_POSITION2[POSITION_RND].z), base.transform.rotation);
					gameObject2.transform.eulerAngles = new Vector3(0f, PASSENGER_POSITION2[POSITION_RND].y, 0f);
				}
				base.gameObject.GetComponent<GAME_MANAGER>().HIDE_3D_ICONS();
				PASSENGER_CREATE = true;
				BLACK_ = false;
				AudioSource.PlayClipAtPoint(CALL_SND, Camera.main.transform.position);
				PASSENGER_COMFORT_ = 1f;
				TAXI_UI_NEW_CLIENT.SetActive(value: true);
				StartCoroutine(NEW_CLIENT());
				if (MENU_MANAGER.LANGUAGE == 1)
				{
					AUDIO_OBJ.GetComponent<AudioSource>().clip = VOICE_ZADANIE;
					AUDIO_OBJ.GetComponent<AudioSource>().Play();
				}
			}
		}
		if (PASSENGER_PICKUP & (TIME_RND == 1) & (TIME__ > 0f))
		{
			TIME__ -= Time.deltaTime / 70f;
			TIME_FILL.fillAmount = TIME__;
			if (TIME__ < 0.25f)
			{
				TIME_LOW += Time.deltaTime;
				if (TIME_LOW < 0.5f)
				{
					TIME_FILL.color = new Color(1f, 1f, 1f, 0f);
				}
				else
				{
					TIME_FILL.color = new Color(1f, 1f, 1f, 1f);
				}
				if (TIME_LOW > 1f)
				{
					TIME_LOW = 0f;
				}
			}
			if (TIME__ < 0.2f)
			{
				PASSENGER_COMFORT_ = 0f;
				return;
			}
		}
		if (PASSENGER_PICKUP & !BLACK_)
		{
			TIME_RND = Random.Range(0, 3);
			if (TIME_RND == 1)
			{
				TIME__ = 0.7f;
				TIME_OBJ.SetActive(value: true);
				TIME_FILL.fillAmount = TIME__;
			}
			STOP_.SetActive(value: true);
			STOP2_.SetActive(value: true);
			AudioSource.PlayClipAtPoint(DOOR_CLOSED_SND, Camera.main.transform.position);
			PASSENGER_COMFORT_ = 1f;
			ALL_MONEY = 0;
			ADD_MONEY = 0;
			PASSENGER_FAIL = false;
			PASSENGER_HIT = false;
			CONTROL_FILL_IMG.fillAmount = PASSENGER_COMFORT_;
			CONTROL_FILL_TEXT.text = Mathf.Round(PASSENGER_COMFORT_ * 10000f / 100f) + " %";
			BLACK_FX.SetActive(value: true);
			TAXI_UI_CONTROL.SetActive(value: true);
			BLACK_ = true;
			if (MENU_MANAGER.LOADING_LEVEL == 0)
			{
				POSITION_RND = Random.Range(0, TARGET_POSITION.Length);
				GameObject gameObject3 = Object.Instantiate(TARGET_PREFAB, TARGET_POSITION[POSITION_RND], base.transform.rotation);
			}
			else
			{
				POSITION_RND = Random.Range(0, TARGET_POSITION2.Length);
				GameObject gameObject4 = Object.Instantiate(TARGET_PREFAB, TARGET_POSITION2[POSITION_RND], base.transform.rotation);
			}
		}
		if (!PASSENGER_AIR)
		{
			air_snd = false;
		}
		if (PASSENGER_AIR && !air_snd)
		{
			if (!PASSENGER_GENDER)
			{
				SND_RND = Random.Range(0, WOMAN_AIR_SND.Length);
				AudioSource.PlayClipAtPoint(WOMAN_AIR_SND[SND_RND], Camera.main.transform.position);
			}
			else
			{
				SND_RND = Random.Range(0, MAN_AIR_SND.Length);
				AudioSource.PlayClipAtPoint(MAN_AIR_SND[SND_RND], Camera.main.transform.position);
			}
			air_snd = true;
		}
		if (PASSENGER_HIT & !PASSENGER_FAIL)
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
				PASSENGER_COMFORT_ -= Random.Range(0.15f, 0.3f);
			}
			CONTROL_FILL_IMG.fillAmount = PASSENGER_COMFORT_;
			CONTROL_FILL_TEXT.text = Mathf.Round(PASSENGER_COMFORT_ * 10000f / 100f) + " %";
			PASSENGER_HIT = false;
		}
		if (PASSENGER_COMPLETE & PASSENGER_PICKUP)
		{
			TIME_OBJ.SetActive(value: false);
			COMPLETE_BUTTON.interactable = false;
			STOP_.SetActive(value: false);
			STOP2_.SetActive(value: false);
			if (GAME_MANAGER.TAXI_DRIVER_LEVEL == 0)
			{
				ALL_MONEY = Random.Range(10, 30) + (int)PASSENGER_COMFORT_ * 10;
			}
			else
			{
				ALL_MONEY = Random.Range(10, 30) + (int)PASSENGER_COMFORT_ * 10 * GAME_MANAGER.TAXI_DRIVER_LEVEL;
			}
			AudioSource.PlayClipAtPoint(DOOR_CLOSED_SND, Camera.main.transform.position);
			BLACK_FX.SetActive(value: true);
			StartCoroutine(COMPLETE_VOICE());
			if (GAME_MANAGER.TAXI_DRIVER_LEVEL < 10)
			{
				G = 0;
				H = 0f;
				if (GAME_MANAGER.TAXI_DRIVER_LEVEL > 0)
				{
					G = GAME_MANAGER.TAXI_DRIVER_LEVEL + 3;
					H = PASSENGER_COMFORT_ / (float)G;
					GAME_MANAGER.TAXI_DRIVER_PROGRESS += H;
				}
				else
				{
					GAME_MANAGER.TAXI_DRIVER_PROGRESS += PASSENGER_COMFORT_ / 2f;
				}
				if (GAME_MANAGER.TAXI_DRIVER_PROGRESS > 0.99f)
				{
					GAME_MANAGER.TAXI_DRIVER_PROGRESS = 1f;
					NEW_LEVEL_ = true;
				}
				COMPLETE_LEVEL_TXT.text = Mathf.Round(GAME_MANAGER.TAXI_DRIVER_PROGRESS * 10000f / 100f) + " %";
				COMPLETE_LEVEL_IMG.fillAmount = GAME_MANAGER.TAXI_DRIVER_PROGRESS;
			}
			else
			{
				COMPLETE_LEVEL_TXT.text = "100 %";
				COMPLETE_LEVEL_IMG.fillAmount = 1f;
			}
			TAXI_UI_COMPLETE.SetActive(value: true);
			TAXI_UI_CONTROL.SetActive(value: false);
			BLACK_ = false;
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
		if (NEW_LEVEL_ & !TAXI_UI_COMPLETE.activeInHierarchy)
		{
			TAXI_UI_NEW_LEVEl.SetActive(value: true);
			GAME_MANAGER.TAXI_DRIVER_LEVEL++;
			if (GAME_MANAGER.TAXI_DRIVER_LEVEL > 9)
			{
				LEVELUP_LEVEL_IMG.fillAmount = 1f;
				LEVELUP_LEVEL_TXT.text = "100 %";
			}
			else
			{
				LEVELUP_LEVEL_IMG.fillAmount = (float)GAME_MANAGER.TAXI_DRIVER_LEVEL / 10f;
				LEVELUP_LEVEL_TXT.text = Mathf.Round(GAME_MANAGER.TAXI_DRIVER_LEVEL * 10000 / 1000) + " %";
			}
			StartCoroutine(NEW_LEVEL());
			NEW_LEVEL_ = false;
		}
		if (!((PASSENGER_COMFORT_ < 0.01f) & PASSENGER_PICKUP))
		{
			return;
		}
		TIME_OBJ.SetActive(value: false);
		TAXI_UI_CONTROL.SetActive(value: false);
		STOP_.SetActive(value: false);
		STOP2_.SetActive(value: false);
		if (!TAXI_UI_FAIL.activeInHierarchy & !FALIED_TIME_UI.activeInHierarchy)
		{
			StartCoroutine(FAIL_VOICE());
			AudioSource.PlayClipAtPoint(DOOR_CLOSED_SND, Camera.main.transform.position);
			BLACK_FX.SetActive(value: true);
			GameObject[] array = GameObject.FindGameObjectsWithTag("PASSENGER_TARGET");
			GameObject[] array2 = array;
			foreach (GameObject obj in array2)
			{
				Object.Destroy(obj);
			}
		}
		if (TIME_RND == 1)
		{
			FALIED_TIME_UI.SetActive(value: true);
			TIME_RND = 0;
		}
		else
		{
			TAXI_UI_FAIL.SetActive(value: true);
		}
		PASSENGER_FAIL = true;
		CONTROL_FILL_IMG.fillAmount = 0f;
		CONTROL_FILL_TEXT.text = "0 %";
	}

	public void END_FUEL()
	{
		base.gameObject.GetComponent<GAME_MANAGER>().SHOW_3D_ICONS();
		TIME_OBJ.SetActive(value: false);
		TAXI_UI_CONTROL.SetActive(value: false);
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
		TAXI_UI_FAIL.SetActive(value: false);
		PASSENGER_CREATE = false;
		BLACK_ = false;
		PASSENGER_TIMER = Random.Range(10, 20);
		RACE_MANAGER.START_RACE = false;
		GAME_MANAGER.IN_RACE_POINT = 0;
		PASSENGER_COMPLETE = false;
		MEDIC_MANAGER.PASSENGER_COMPLETE = false;
		PASSENGER_FAIL = false;
		MEDIC_MANAGER.PASSENGER_FAIL = false;
		COP_MANAGER.PASSENGER_FAIL = false;
		COP_MANAGER.PASSENGER_COMPLETE = false;
		FALIED_TIME_UI.SetActive(value: false);
		FALIED_TIME_UI.SetActive(value: false);
		TIME_OBJ.SetActive(value: false);
		PASSENGER_PICKUP = false;
		PASSENGER_FAIL = false;
		TAXI_UI_FAIL.SetActive(value: false);
		PASSENGER_CREATE = false;
		BLACK_ = false;
		PASSENGER_TIMER = Random.Range(10, 20);
		RACE_MANAGER.START_RACE = false;
		GAME_MANAGER.IN_RACE_POINT = 0;
		PASSENGER_COMPLETE = false;
		MEDIC_MANAGER.PASSENGER_COMPLETE = false;
		PASSENGER_FAIL = false;
		MEDIC_MANAGER.PASSENGER_FAIL = false;
		COP_MANAGER.PASSENGER_FAIL = false;
		COP_MANAGER.PASSENGER_COMPLETE = false;
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

	private IEnumerator COMPLETE_VOICE()
	{
		yield return new WaitForSecondsRealtime(0.5f);
		if (MENU_MANAGER.LANGUAGE == 1)
		{
			if (!PASSENGER_GENDER)
			{
				SND_RND = Random.Range(0, WOMAN_COMPLETE_SND.Length);
				AudioSource.PlayClipAtPoint(WOMAN_COMPLETE_SND[SND_RND], Camera.main.transform.position);
			}
			else
			{
				SND_RND = Random.Range(0, MAN_COMPLETE_SND.Length);
				AudioSource.PlayClipAtPoint(MAN_COMPLETE_SND[SND_RND], Camera.main.transform.position);
			}
		}
	}

	private IEnumerator NEW_LEVEL()
	{
		ES2.Save(GAME_MANAGER.TAXI_DRIVER_LEVEL, "TAXI_DRIVER_LEVEL");
		ES2.Save(GAME_MANAGER.TAXI_DRIVER_PROGRESS, "TAXI_DRIVER_PROGRESS");
		GAME_MANAGER.TAXI_DRIVER_PROGRESS = 0f;
		yield return new WaitForSecondsRealtime(3f);
		TAXI_UI_NEW_LEVEl.SetActive(value: false);
	}

	private IEnumerator NEW_CLIENT()
	{
		yield return new WaitForSecondsRealtime(3f);
		TAXI_UI_NEW_CLIENT.SetActive(value: false);
	}

	public void CLOSE_FAIL()
	{
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
		TIME_OBJ.SetActive(value: false);
		FALIED_TIME_UI.SetActive(value: false);
		base.gameObject.GetComponent<GAME_MANAGER>().SHOW_3D_ICONS();
		FALIED_TIME_UI.SetActive(value: false);
		TIME_OBJ.SetActive(value: false);
		AudioSource.PlayClipAtPoint(UI_CLICK, Camera.main.transform.position);
		PASSENGER_PICKUP = false;
		PASSENGER_FAIL = false;
		TAXI_UI_FAIL.SetActive(value: false);
		PASSENGER_CREATE = false;
		BLACK_ = false;
		PASSENGER_TIMER = Random.Range(10, 20);
		RACE_MANAGER.START_RACE = false;
		GAME_MANAGER.IN_RACE_POINT = 0;
		PASSENGER_COMPLETE = false;
		MEDIC_MANAGER.PASSENGER_COMPLETE = false;
		PASSENGER_FAIL = false;
		MEDIC_MANAGER.PASSENGER_FAIL = false;
		COP_MANAGER.PASSENGER_FAIL = false;
		COP_MANAGER.PASSENGER_COMPLETE = false;
	}

	public void CLOSE_COMPLETE()
	{
		int num = Random.Range(0, 3);
		if (num == 1 && MENU_MANAGER.APPODEAL_ADS_TIMER == 0f)
		{
			MENU_MANAGER.APPODEAL_ADS_TIMER = 40f;
		}
		TIME_OBJ.SetActive(value: false);
		base.gameObject.GetComponent<GAME_MANAGER>().SHOW_3D_ICONS();
		if (MENU_MANAGER.LANGUAGE == 1)
		{
			AUDIO_OBJ.GetComponent<AudioSource>().clip = VOICE_COMPLETE[Random.Range(0, VOICE_COMPLETE.Length)];
			AUDIO_OBJ.GetComponent<AudioSource>().Play();
		}
		GAME_MANAGER.SHOW_XP = true;
		ES2.Save(GAME_MANAGER.PLAYER_MONEY, "PLAYER_MONEY");
		ES2.Save(GAME_MANAGER.TAXI_DRIVER_PROGRESS, "TAXI_DRIVER_PROGRESS");
		PASSENGER_CREATE = false;
		AudioSource.PlayClipAtPoint(UI_CLICK, Camera.main.transform.position);
		PASSENGER_PICKUP = false;
		TIMER_MONEY = 0f;
		TIMER_MONEY_ACS = 0f;
		ADD_MONEY = 0;
		RACE_MANAGER.START_RACE = false;
		GAME_MANAGER.IN_RACE_POINT = 0;
		PASSENGER_COMPLETE = false;
		MEDIC_MANAGER.PASSENGER_COMPLETE = false;
		PASSENGER_FAIL = false;
		MEDIC_MANAGER.PASSENGER_FAIL = false;
		COP_MANAGER.PASSENGER_FAIL = false;
		COP_MANAGER.PASSENGER_COMPLETE = false;
		TAXI_UI_COMPLETE.SetActive(value: false);
		PASSENGER_TIMER = Random.Range(20, 40);
		if (ES2.Load<string>("DAILY_MISSION_2_TYPE") == "WIN_TAXI_JOB" && ES2.Load<int>("DAILY_MISSION_2") < ES2.Load<int>("DAILY_MISSION_2_NEED"))
		{
			ES2.Save(ES2.Load<int>("DAILY_MISSION_2") + 1, "DAILY_MISSION_2");
			if (ES2.Load<int>("DAILY_MISSION_2") == ES2.Load<int>("DAILY_MISSION_2_NEED"))
			{
				GAME_MANAGER.DTAST_COMPELTE = true;
			}
		}
	}
}
