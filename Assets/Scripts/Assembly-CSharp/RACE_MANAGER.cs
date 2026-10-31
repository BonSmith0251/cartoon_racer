using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RACE_MANAGER : MonoBehaviour
{
	public GameObject EVENTS;

	public GameObject TUTORIAL_7;

	public GameObject TUTORIAL_8;

	public GameObject TUTORIAL_9;

	public AudioClip[] RACING_MUSIC;

	public GameObject MUSIC_MANAGER;

	public GameObject GAME_MANAGER_;

	private float NEW_XP;

	private int MORE_XP;

	public Text PL_TXT;

	public Text AI1_TXT;

	public Text AI2_TXT;

	public Text AI3_TXT;

	public GameObject NEW_LAP_FX;

	public GameObject AUDIO_OBJ;

	public GameObject TRAFFIC_OBJ;

	public AudioClip[] VOICE_COMPLETE;

	public AudioClip[] VOICE_FAIL;

	public GameObject ADD_TIME;

	public GameObject CHECKPOINT_FX;

	private float checkpoint_fx_timer;

	public GameObject RACE_POINTS;

	public AudioClip LOWTIME_SND;

	public AudioClip MONEY_SND;

	public GameObject RCC_CAMERA;

	public GameObject FINISH_UI;

	public GameObject FINISH_1MESTO;

	public GameObject FINISH_2MESTO;

	public GameObject FINISH_3MESTO;

	public Text FINISH_1MESTO_TXT;

	public Text FINISH_2MESTO_TXT;

	public Text FINISH_3MESTO_TXT;

	public GameObject AWARD_SILVER;

	public GameObject AWARD_BRONZE;

	public Button FINISH_CLOSE;

	public GameObject FALIED_UI;

	public GameObject COINS_MANAGER;

	public GameObject GEAR;

	public GameObject LOADING_CANVAS;

	public Image LOADING_FILL;

	public GameObject LOADING_OBJ_;

	public GameObject START_OBJ_;

	private float loading_progress;

	private bool Start_load;

	private float fire_timer;

	public GameObject[] RACE_PREFAB;

	public GameObject[] RACE_AI_CARS;

	private GameObject START_;

	private GameObject PLAYER;

	public GameObject DASHBOARD_UI;

	public GameObject RACING_DASHBOARD_UI;

	public GameObject LASTLAP_UI;

	public GameObject HUD_UI;

	public GameObject RACE_UI;

	public AudioClip CLICK;

	public AudioClip SIGNAL_1;

	public AudioClip SIGNAL_2;

	public GameObject RACE_PROGRESS;

	public GameObject START_OBJ;

	public GameObject RACE_UI_;

	public GameObject RACE_LAP_;

	public GameObject RACE_PLACE_;

	public GameObject RACE_TIME_;

	public GameObject RACE_SPEED_;

	public Image RACE_SPEED_PROGRESS;

	public Image RACE_SPEED_PROGRESS2;

	public static bool NEED_QUIT;

	public Text TIME_SEC_;

	public static float fire_polosa;

	public static int sec;

	private float ms;

	public Text LAPRACE_CURRENT_PLACE;

	public Text LAPRACE_CURRENT_LAP;

	public Text LAPRACE_ALL_LAP;

	public Image START_IMG;

	public Image START_IMG2;

	public Image START_IMG3;

	public Image PROGRESS_IMG;

	public Sprite SPR_START1;

	public Sprite SPR_START2;

	public Sprite SPR_START3;

	private float start_timer;

	private int start_count;

	private bool show_last_lap;

	private int RND_CARS;

	private float PROGRESS_REAL;

	public static bool IN_SPEED_CHECKPOINT;

	public static bool NEW_LAP;

	public static bool FINISH_RACE;

	public static bool START_RACE;

	public static bool CHEKPOINT_UPDATE;

	public static bool IN_CHECKPOINT;

	public static int CURRENT_LAP;

	public static int CURRENT_PLACE;

	public static int CURRENT_CHECKPOINT_;

	public static int CURRENT_CHECKPOINT;

	public static int CURRENT_CHECKPOINT_FOR_FINISH;

	public static int ALL_CHECKPOINTS;

	private int ALL_CHECKPOINTS_;

	public static int CURRENT_CHECKPOINT_AI1;

	public static int CURRENT_CHECKPOINT_FOR_FINISH_AI1;

	public static int CURRENT_CHECKPOINT_AI2;

	public static int CURRENT_CHECKPOINT_FOR_FINISH_AI2;

	public static int CURRENT_CHECKPOINT_AI3;

	public static int CURRENT_CHECKPOINT_FOR_FINISH_AI3;

	public static float PROGRESS_RACE;

	public static int CAR_LEVEL;

	private int ALL_MONEY;

	private int ADD_MONEY;

	private float TIMER_MONEY_ACS;

	private float TIMER_MONEY;

	public static bool RETURN_;

	public static float return_timer;

	public static float LAST_x;

	public static float LAST_y;

	public static float LAST_z;

	public static float LAST_rot;

	private bool Creater_level;

	private float UPD_;

	private IEnumerator AsyncLoad()
	{
		if (MENU_MANAGER.LOADING_LEVEL == 0)
		{
			AsyncOperation operation = SceneManager.LoadSceneAsync("FARM_STATIC", LoadSceneMode.Additive);
			while (!operation.isDone)
			{
				yield return null;
			}
		}
		else
		{
			AsyncOperation operation2 = SceneManager.LoadSceneAsync("CITY_STATIC", LoadSceneMode.Additive);
			while (!operation2.isDone)
			{
				yield return null;
			}
		}
	}

	private void Update()
	{
		if (LOADING_CANVAS.activeInHierarchy & !TRAFFIC_MANAGER.TRAFFIC_MODE)
		{
			HUD_UI.SetActive(value: false);
			if ((loading_progress > 0.99f) & !START_OBJ_.activeInHierarchy)
			{
				PLAYER.SetActive(value: true);
				LOADING_OBJ_.SetActive(value: false);
				START_OBJ_.SetActive(value: true);
			}
			if (loading_progress < 1f)
			{
				START_OBJ_.SetActive(value: false);
				loading_progress += Time.deltaTime / 4f + (float)(UnityEngine.Random.Range(1500, 3000) / 6190);
				LOADING_FILL.fillAmount = loading_progress;
				if ((loading_progress > 0.8f) & !Start_load)
				{
					if (!GAME_MANAGER.START_RACE_FROM_MENU)
					{
						if (MENU_MANAGER.LOADING_LEVEL == 0)
						{
							SceneManager.UnloadSceneAsync("FARM_STATIC");
						}
						if (MENU_MANAGER.LOADING_LEVEL == 1)
						{
							SceneManager.UnloadSceneAsync("CITY_STATIC");
						}
					}
					GameObject gameObject = UnityEngine.Object.Instantiate(RACE_PREFAB[RACE_TRIGGER._INDEX], RACE_PREFAB[RACE_TRIGGER._INDEX].transform.position, RACE_PREFAB[RACE_TRIGGER._INDEX].transform.rotation);
					gameObject.gameObject.SetActive(value: true);
					START_ = GameObject.FindGameObjectWithTag("START");
					START_.GetComponent<FINISH_POINT>().HIDE_PARTICLES();
					StartCoroutine(AsyncLoad());
					Start_load = true;
					RACE_UI_.SetActive(value: false);
					PROGRESS_RACE = 0f;
					PROGRESS_REAL = 0f;
					PROGRESS_IMG.fillAmount = 0f;
					FINISH_CLOSE.interactable = false;
					start_timer = 0f;
					start_count = 0;
					show_last_lap = false;
					START_IMG.color = new Color(0f, 0f, 0f, 0.4f);
					START_IMG2.color = new Color(0f, 0f, 0f, 0.4f);
					START_IMG3.color = new Color(0f, 0f, 0f, 0.4f);
					GameObject[] array = GameObject.FindGameObjectsWithTag("TRAFFIC");
					GameObject[] array2 = array;
					foreach (GameObject obj in array2)
					{
						UnityEngine.Object.Destroy(obj);
					}
					GameObject[] array3 = GameObject.FindGameObjectsWithTag("LETTER");
					GameObject[] array4 = array3;
					foreach (GameObject obj2 in array4)
					{
						UnityEngine.Object.Destroy(obj2);
					}
					GameObject[] array5 = GameObject.FindGameObjectsWithTag("GEAR");
					GameObject[] array6 = array5;
					foreach (GameObject obj3 in array6)
					{
						UnityEngine.Object.Destroy(obj3);
					}
					UnityEngine.Object.Destroy(GameObject.FindGameObjectWithTag("COINS_MANAGER"));
					ALL_CHECKPOINTS = 0;
					RETURN_ = false;
					GAME_MANAGER.IN_RACE = true;
					START_RACE = true;
					start_timer = -2f;
					PLAYER = RCC_CAMERA.GetComponent<RCC_Camera>().playerCar.gameObject;
					PLAYER.transform.position = new Vector3(RACE_TRIGGER._PLAYER_POSITION.x, 33f, RACE_TRIGGER._PLAYER_POSITION.z);
					PLAYER.transform.rotation = Quaternion.Euler(0f, RACE_TRIGGER._PLAYER_POSITION.y, 0f);
					PLAYER.gameObject.SetActive(value: false);
					PLAYER.GetComponent<RCC_CarControllerV3>().NoS = 100f;
					if (RACE_TRIGGER._AI_RACE)
					{
						RND_CARS = UnityEngine.Random.Range(0, RACE_AI_CARS.Length);
						GameObject gameObject2 = UnityEngine.Object.Instantiate(RACE_AI_CARS[0], new Vector3(RACE_TRIGGER._AI1_POSITION.x, 33f, RACE_TRIGGER._AI1_POSITION.z), base.transform.rotation);
						gameObject2.transform.rotation = Quaternion.Euler(0f, RACE_TRIGGER._AI1_POSITION.y, 0f);
						gameObject2.GetComponent<RCC_AICarController>().REAL_SPD = UnityEngine.Random.Range(-15, -20);
						if (GAME_MANAGER.PLAYER_LEVEL > 9)
						{
							gameObject2.GetComponent<RCC_AICarController>().REAL_SPD = gameObject2.GetComponent<RCC_AICarController>().REAL_SPD + CAR_LEVEL / 4;
						}
						if (GAME_MANAGER.PLAYER_LEVEL > 19)
						{
							gameObject2.GetComponent<RCC_AICarController>().REAL_SPD = gameObject2.GetComponent<RCC_AICarController>().REAL_SPD + CAR_LEVEL / 3;
						}
						if (GAME_MANAGER.PLAYER_LEVEL > 29)
						{
							gameObject2.GetComponent<RCC_AICarController>().REAL_SPD = gameObject2.GetComponent<RCC_AICarController>().REAL_SPD + CAR_LEVEL / 2;
						}
						gameObject2.GetComponent<RCC_CarControllerV3>().engineTorque = gameObject2.GetComponent<RCC_CarControllerV3>().engineTorque + (float)(CAR_LEVEL * 2);
						GameObject gameObject3 = UnityEngine.Object.Instantiate(RACE_AI_CARS[1], new Vector3(RACE_TRIGGER._AI2_POSITION.x, 33f, RACE_TRIGGER._AI2_POSITION.z), base.transform.rotation);
						gameObject3.transform.rotation = Quaternion.Euler(0f, RACE_TRIGGER._AI2_POSITION.y, 0f);
						gameObject3.GetComponent<RCC_AICarController>().REAL_SPD = UnityEngine.Random.Range(-10, -15);
						if (GAME_MANAGER.PLAYER_LEVEL > 9)
						{
							gameObject3.GetComponent<RCC_AICarController>().REAL_SPD = gameObject3.GetComponent<RCC_AICarController>().REAL_SPD + CAR_LEVEL / 4;
						}
						if (GAME_MANAGER.PLAYER_LEVEL > 19)
						{
							gameObject3.GetComponent<RCC_AICarController>().REAL_SPD = gameObject3.GetComponent<RCC_AICarController>().REAL_SPD + CAR_LEVEL / 3;
						}
						if (GAME_MANAGER.PLAYER_LEVEL > 29)
						{
							gameObject3.GetComponent<RCC_AICarController>().REAL_SPD = gameObject3.GetComponent<RCC_AICarController>().REAL_SPD + CAR_LEVEL / 2;
						}
						gameObject3.GetComponent<RCC_CarControllerV3>().engineTorque = gameObject3.GetComponent<RCC_CarControllerV3>().engineTorque + (float)(CAR_LEVEL * 2);
						GameObject gameObject4 = UnityEngine.Object.Instantiate(RACE_AI_CARS[2], new Vector3(RACE_TRIGGER._AI3_POSITION.x, 33f, RACE_TRIGGER._AI3_POSITION.z), base.transform.rotation);
						gameObject4.transform.rotation = Quaternion.Euler(0f, RACE_TRIGGER._AI3_POSITION.y, 0f);
						gameObject4.GetComponent<RCC_AICarController>().REAL_SPD = UnityEngine.Random.Range(-5, -10);
						if (GAME_MANAGER.PLAYER_LEVEL > 9)
						{
							gameObject4.GetComponent<RCC_AICarController>().REAL_SPD = gameObject4.GetComponent<RCC_AICarController>().REAL_SPD + CAR_LEVEL / 4;
						}
						if (GAME_MANAGER.PLAYER_LEVEL > 19)
						{
							gameObject4.GetComponent<RCC_AICarController>().REAL_SPD = gameObject4.GetComponent<RCC_AICarController>().REAL_SPD + CAR_LEVEL / 3;
						}
						if (GAME_MANAGER.PLAYER_LEVEL > 29)
						{
							gameObject4.GetComponent<RCC_AICarController>().REAL_SPD = gameObject4.GetComponent<RCC_AICarController>().REAL_SPD + CAR_LEVEL / 2;
						}
						gameObject4.GetComponent<RCC_CarControllerV3>().engineTorque = gameObject4.GetComponent<RCC_CarControllerV3>().engineTorque + (float)(CAR_LEVEL * 2);
					}
					GAME_MANAGER.PLAYER_FUEL = 1f;
					GameObject[] array7 = GameObject.FindGameObjectsWithTag("CHEKPOINT");
					GameObject[] array8 = array7;
					foreach (GameObject gameObject5 in array8)
					{
						if (gameObject5 != null)
						{
							gameObject5.GetComponent<RACE_CHECKPOINT>().AI1_CIRCUIT_RESET();
							gameObject5.GetComponent<RACE_CHECKPOINT>().AI2_CIRCUIT_RESET();
							gameObject5.GetComponent<RACE_CHECKPOINT>().AI3_CIRCUIT_RESET();
							gameObject5.GetComponent<RACE_CHECKPOINT>().PLAYER_CIRCUIT_RESET();
							ALL_CHECKPOINTS++;
						}
					}
					if (RACE_TRIGGER._RACE_CIRCUIT)
					{
						ALL_CHECKPOINTS--;
						ALL_CHECKPOINTS_ = ALL_CHECKPOINTS * RACE_TRIGGER._RACE_CIRCUIT_LAPS;
					}
					else
					{
						ALL_CHECKPOINTS_ = ALL_CHECKPOINTS;
					}
				}
			}
		}
		if ((GAME_MANAGER.IN_RACE_POINT > 0) & !RACE_UI.activeInHierarchy & !GAME_MANAGER.IN_RACE)
		{
			RACE_UI.SetActive(value: true);
		}
		if (!GAME_MANAGER.IN_RACE || !GAME_MANAGER.IN_RACE)
		{
			return;
		}
		if (RETURN_)
		{
			RCC_CAMERA.GetComponent<RCC_Camera>().enabled = false;
			return_timer = 1f;
			RETURN_ = false;
		}
		if (return_timer > 0f)
		{
			return_timer -= Time.deltaTime / 2f;
			if (return_timer < 0.1f)
			{
				PLAYER.GetComponent<Rigidbody>().Sleep();
				PLAYER.SetActive(value: false);
			}
			if (return_timer < 0.01f)
			{
				return_timer = 0f;
				PLAYER.SetActive(value: true);
				PLAYER.transform.position = new Vector3(LAST_x, LAST_y + 1f, LAST_z);
				PLAYER.transform.rotation = Quaternion.Euler(0f, LAST_rot, 0f);
				RCC_CAMERA.GetComponent<RCC_Camera>().enabled = true;
			}
		}
		if (NEW_LAP)
		{
			NEW_LAP_FX.SetActive(value: true);
			NEW_LAP = false;
		}
		if (START_RACE)
		{
			START_COUNT();
		}
		if (FINISH_RACE)
		{
			if ((CURRENT_CHECKPOINT > CURRENT_CHECKPOINT_AI1) & (CURRENT_CHECKPOINT > CURRENT_CHECKPOINT_AI2) & (CURRENT_CHECKPOINT > CURRENT_CHECKPOINT_AI3))
			{
				CURRENT_PLACE = 1;
			}
			if ((CURRENT_CHECKPOINT > CURRENT_CHECKPOINT_AI1) & (CURRENT_CHECKPOINT > CURRENT_CHECKPOINT_AI2) & (CURRENT_CHECKPOINT < CURRENT_CHECKPOINT_AI3))
			{
				CURRENT_PLACE = 2;
			}
			if ((CURRENT_CHECKPOINT > CURRENT_CHECKPOINT_AI2) & (CURRENT_CHECKPOINT > CURRENT_CHECKPOINT_AI3) & (CURRENT_CHECKPOINT < CURRENT_CHECKPOINT_AI1))
			{
				CURRENT_PLACE = 2;
			}
			if ((CURRENT_CHECKPOINT > CURRENT_CHECKPOINT_AI3) & (CURRENT_CHECKPOINT > CURRENT_CHECKPOINT_AI2) & (CURRENT_CHECKPOINT < CURRENT_CHECKPOINT_AI3))
			{
				CURRENT_PLACE = 2;
			}
			if ((CURRENT_CHECKPOINT > CURRENT_CHECKPOINT_AI1) & (CURRENT_CHECKPOINT > CURRENT_CHECKPOINT_AI3) & (CURRENT_CHECKPOINT < CURRENT_CHECKPOINT_AI2))
			{
				CURRENT_PLACE = 2;
			}
			if ((CURRENT_CHECKPOINT > CURRENT_CHECKPOINT_AI1) & (CURRENT_CHECKPOINT < CURRENT_CHECKPOINT_AI2) & (CURRENT_CHECKPOINT < CURRENT_CHECKPOINT_AI3))
			{
				CURRENT_PLACE = 3;
			}
			if ((CURRENT_CHECKPOINT > CURRENT_CHECKPOINT_AI2) & (CURRENT_CHECKPOINT < CURRENT_CHECKPOINT_AI1) & (CURRENT_CHECKPOINT < CURRENT_CHECKPOINT_AI3))
			{
				CURRENT_PLACE = 3;
			}
			if ((CURRENT_CHECKPOINT > CURRENT_CHECKPOINT_AI3) & (CURRENT_CHECKPOINT < CURRENT_CHECKPOINT_AI1) & (CURRENT_CHECKPOINT < CURRENT_CHECKPOINT_AI2))
			{
				CURRENT_PLACE = 3;
			}
			if ((CURRENT_CHECKPOINT_AI1 > CURRENT_CHECKPOINT) & (CURRENT_CHECKPOINT_AI2 > CURRENT_CHECKPOINT) & (CURRENT_CHECKPOINT_AI3 > CURRENT_CHECKPOINT))
			{
				CURRENT_PLACE = 4;
			}
			if (RACE_TRIGGER._AI_RACE)
			{
				UnityEngine.Object.Destroy(GameObject.Find("AI_RACE_CAR(Clone)"));
				UnityEngine.Object.Destroy(GameObject.Find("AI_RACE_CAR2(Clone)"));
				UnityEngine.Object.Destroy(GameObject.Find("AI_RACE_CAR3(Clone)"));
			}
			RACE_PREFAB[RACE_TRIGGER._INDEX].SetActive(value: false);
			GameObject gameObject6 = UnityEngine.Object.Instantiate(COINS_MANAGER, COINS_MANAGER.transform.position, COINS_MANAGER.transform.rotation);
			if (RACE_TRIGGER._AI_RACE)
			{
				if (CURRENT_PLACE < 4)
				{
					FINISH_UI.SetActive(value: true);
					if (MENU_MANAGER.LANGUAGE == 1)
					{
						if (CURRENT_PLACE == 1)
						{
							AUDIO_OBJ.GetComponent<AudioSource>().clip = VOICE_COMPLETE[0];
						}
						else
						{
							AUDIO_OBJ.GetComponent<AudioSource>().clip = VOICE_COMPLETE[UnityEngine.Random.Range(1, VOICE_COMPLETE.Length)];
						}
						AUDIO_OBJ.GetComponent<AudioSource>().Play();
					}
				}
				else
				{
					FALIED_UI.SetActive(value: true);
					if (MENU_MANAGER.LANGUAGE == 1)
					{
						AUDIO_OBJ.GetComponent<AudioSource>().clip = VOICE_FAIL[UnityEngine.Random.Range(0, VOICE_FAIL.Length)];
						AUDIO_OBJ.GetComponent<AudioSource>().Play();
					}
				}
			}
			if (RACE_TRIGGER._TIME_RACE)
			{
				if (sec > 0)
				{
					FINISH_UI.SetActive(value: true);
					CURRENT_PLACE = 1;
					if (MENU_MANAGER.LANGUAGE == 1)
					{
						AUDIO_OBJ.GetComponent<AudioSource>().clip = VOICE_COMPLETE[UnityEngine.Random.Range(0, VOICE_COMPLETE.Length)];
						AUDIO_OBJ.GetComponent<AudioSource>().Play();
					}
				}
				else
				{
					FALIED_UI.SetActive(value: true);
					CURRENT_PLACE = 4;
					if (MENU_MANAGER.LANGUAGE == 1)
					{
						AUDIO_OBJ.GetComponent<AudioSource>().clip = VOICE_FAIL[UnityEngine.Random.Range(0, VOICE_FAIL.Length)];
						AUDIO_OBJ.GetComponent<AudioSource>().Play();
					}
				}
			}
			if (RACE_TRIGGER._SPEED_RACE)
			{
				if (fire_polosa > 0.02f)
				{
					FINISH_UI.SetActive(value: true);
					CURRENT_PLACE = 1;
					if (MENU_MANAGER.LANGUAGE == 1)
					{
						AUDIO_OBJ.GetComponent<AudioSource>().clip = VOICE_COMPLETE[UnityEngine.Random.Range(0, VOICE_COMPLETE.Length)];
						AUDIO_OBJ.GetComponent<AudioSource>().Play();
					}
				}
				else
				{
					FALIED_UI.SetActive(value: true);
					CURRENT_PLACE = 4;
					if (MENU_MANAGER.LANGUAGE == 1)
					{
						AUDIO_OBJ.GetComponent<AudioSource>().clip = VOICE_FAIL[UnityEngine.Random.Range(0, VOICE_FAIL.Length)];
						AUDIO_OBJ.GetComponent<AudioSource>().Play();
					}
				}
			}
			RCC_CAMERA.GetComponent<RCC_Camera>().enabled = false;
			base.gameObject.GetComponent<AudioSource>().enabled = false;
			RACING_DASHBOARD_UI.SetActive(value: false);
			HUD_UI.SetActive(value: false);
			FINISH_1MESTO.SetActive(value: false);
			FINISH_2MESTO.SetActive(value: false);
			FINISH_3MESTO.SetActive(value: false);
			if (CURRENT_PLACE == 3)
			{
				ALL_MONEY = RACE_TRIGGER._3ST_AWARD_;
				FINISH_3MESTO.SetActive(value: true);
				ES2.Save(3, "RACE_" + RACE_TRIGGER._INDEX);
			}
			if (CURRENT_PLACE == 2)
			{
				ALL_MONEY = RACE_TRIGGER._2ST_AWARD_;
				FINISH_2MESTO.SetActive(value: true);
				ES2.Save(2, "RACE_" + RACE_TRIGGER._INDEX);
			}
			if (CURRENT_PLACE == 1)
			{
				ALL_MONEY = RACE_TRIGGER._1ST_AWARD_;
				FINISH_1MESTO.SetActive(value: true);
				ES2.Save(1, "RACE_" + RACE_TRIGGER._INDEX);
			}
			FINISH_1MESTO_TXT.text = "0";
			FINISH_2MESTO_TXT.text = "0";
			FINISH_3MESTO_TXT.text = "0";
			FINISH_RACE = false;
		}
		if (FINISH_UI.activeInHierarchy || FALIED_UI.activeInHierarchy)
		{
			PLAYER.SetActive(value: false);
			GAME_MANAGER.IN_RACE_POINT = 1;
			if ((ADD_MONEY == ALL_MONEY) & !FINISH_CLOSE.interactable)
			{
				ES2.Save(GAME_MANAGER.PLAYER_MONEY, "PLAYER_MONEY");
				FINISH_CLOSE.interactable = true;
			}
			if ((ADD_MONEY < ALL_MONEY) & FINISH_UI.activeInHierarchy)
			{
				TIMER_MONEY_ACS += Time.deltaTime;
				if (TIMER_MONEY_ACS > 1f)
				{
					TIMER_MONEY += Time.deltaTime * 10f;
					if (TIMER_MONEY > 1f)
					{
						ADD_MONEY += 50;
						GAME_MANAGER.PLAYER_MONEY += 50;
						TIMER_MONEY = 0f;
						AudioSource.PlayClipAtPoint(MONEY_SND, Camera.main.transform.position);
					}
					if (ADD_MONEY > ALL_MONEY)
					{
						ADD_MONEY = ALL_MONEY;
					}
					if (CURRENT_PLACE == 3)
					{
						FINISH_3MESTO_TXT.text = "+ " + ADD_MONEY;
					}
					if (CURRENT_PLACE == 2)
					{
						FINISH_2MESTO_TXT.text = "+ " + ADD_MONEY;
					}
					if (CURRENT_PLACE == 1)
					{
						FINISH_1MESTO_TXT.text = "+ " + ADD_MONEY;
					}
				}
			}
		}
		if ((RACE_TRIGGER._SPEED_RACE & !START_RACE) && (!FINISH_UI.activeInHierarchy & !FALIED_UI.activeInHierarchy) && !START_RACE)
		{
			RACE_SPEED_PROGRESS.fillAmount = fire_polosa;
			RACE_SPEED_PROGRESS2.fillAmount = fire_polosa;
			if ((fire_polosa > 0f) & (fire_timer == 0f))
			{
				fire_polosa -= Time.deltaTime / 250f * (float)CAR_LEVEL / 1.6f;
			}
			if (fire_polosa < 0.01f)
			{
				fire_polosa = 0f;
				CURRENT_PLACE = 4;
				FINISH_RACE = true;
			}
			if (fire_timer > 0f)
			{
				fire_timer -= Time.deltaTime;
				if (fire_timer < 0.01f)
				{
					fire_timer = 0f;
				}
			}
			if (IN_SPEED_CHECKPOINT)
			{
				fire_timer = 0.7f;
				RACE_SPEED_.GetComponent<AudioSource>().Play();
				IN_SPEED_CHECKPOINT = false;
			}
		}
		if (RACE_TRIGGER._TIME_RACE & !START_RACE)
		{
			TIME_SEC_.text = string.Empty + sec;
			if (sec < 10)
			{
				if (ms < 0.5f)
				{
					TIME_SEC_.color = new Color(1f, 1f, 1f, 1f);
				}
				if (ms > 0.49f)
				{
					TIME_SEC_.color = new Color(1f, 0f, 0f, 1f);
				}
			}
			else
			{
				TIME_SEC_.color = new Color(1f, 1f, 1f, 1f);
			}
			if (!FINISH_UI.activeInHierarchy & !FALIED_UI.activeInHierarchy)
			{
				ms -= Time.deltaTime;
				if (ms < 0f)
				{
					if (sec > 0)
					{
						sec--;
					}
					ms = 1f;
					if ((sec < 10) & (sec > 0))
					{
						AudioSource.PlayClipAtPoint(LOWTIME_SND, Camera.main.transform.position);
					}
					if (sec == 0)
					{
						TIME_SEC_.text = "0";
						FINISH_RACE = true;
						sec = -5;
					}
				}
			}
			if (IN_CHECKPOINT)
			{
				ADD_TIME.SetActive(value: true);
				CHECKPOINT_FX.SetActive(value: true);
				checkpoint_fx_timer = 1f;
				IN_CHECKPOINT = false;
			}
			if (checkpoint_fx_timer > 0f)
			{
				checkpoint_fx_timer -= Time.deltaTime / 3f;
				CHECKPOINT_FX.GetComponent<SpriteRenderer>().color = new Color(0f, 1f, 0f, checkpoint_fx_timer);
				if (checkpoint_fx_timer < 0.01f)
				{
					checkpoint_fx_timer = 0f;
					CHECKPOINT_FX.SetActive(value: false);
					ADD_TIME.SetActive(value: false);
				}
			}
		}
		if (RACE_TRIGGER._RACE_CIRCUIT)
		{
			if (PROGRESS_IMG.fillAmount < PROGRESS_REAL)
			{
				PROGRESS_IMG.fillAmount += Time.deltaTime / 68f;
			}
		}
		else if (PROGRESS_IMG.fillAmount < PROGRESS_REAL)
		{
			PROGRESS_IMG.fillAmount += Time.deltaTime / 38f;
		}
		if (!START_RACE & (CURRENT_CHECKPOINT > 0))
		{
			UPD_ += Time.deltaTime * 2f;
		}
		if (UPD_ > 1f)
		{
			CHEKPOINT_UPDATE = true;
			UPD_ = 0f;
		}
		if (!CHEKPOINT_UPDATE)
		{
			return;
		}
		if (CURRENT_CHECKPOINT_FOR_FINISH > 1)
		{
			if ((CURRENT_CHECKPOINT > CURRENT_CHECKPOINT_AI1) & (CURRENT_CHECKPOINT > CURRENT_CHECKPOINT_AI2) & (CURRENT_CHECKPOINT > CURRENT_CHECKPOINT_AI3))
			{
				CURRENT_PLACE = 1;
			}
			if ((CURRENT_CHECKPOINT > CURRENT_CHECKPOINT_AI1) & (CURRENT_CHECKPOINT > CURRENT_CHECKPOINT_AI2) & (CURRENT_CHECKPOINT < CURRENT_CHECKPOINT_AI3))
			{
				CURRENT_PLACE = 2;
			}
			if ((CURRENT_CHECKPOINT > CURRENT_CHECKPOINT_AI2) & (CURRENT_CHECKPOINT > CURRENT_CHECKPOINT_AI3) & (CURRENT_CHECKPOINT < CURRENT_CHECKPOINT_AI1))
			{
				CURRENT_PLACE = 2;
			}
			if ((CURRENT_CHECKPOINT > CURRENT_CHECKPOINT_AI3) & (CURRENT_CHECKPOINT > CURRENT_CHECKPOINT_AI2) & (CURRENT_CHECKPOINT < CURRENT_CHECKPOINT_AI3))
			{
				CURRENT_PLACE = 2;
			}
			if ((CURRENT_CHECKPOINT > CURRENT_CHECKPOINT_AI1) & (CURRENT_CHECKPOINT > CURRENT_CHECKPOINT_AI3) & (CURRENT_CHECKPOINT < CURRENT_CHECKPOINT_AI2))
			{
				CURRENT_PLACE = 2;
			}
			if ((CURRENT_CHECKPOINT > CURRENT_CHECKPOINT_AI1) & (CURRENT_CHECKPOINT < CURRENT_CHECKPOINT_AI2) & (CURRENT_CHECKPOINT < CURRENT_CHECKPOINT_AI3))
			{
				CURRENT_PLACE = 3;
			}
			if ((CURRENT_CHECKPOINT > CURRENT_CHECKPOINT_AI2) & (CURRENT_CHECKPOINT < CURRENT_CHECKPOINT_AI1) & (CURRENT_CHECKPOINT < CURRENT_CHECKPOINT_AI3))
			{
				CURRENT_PLACE = 3;
			}
			if ((CURRENT_CHECKPOINT > CURRENT_CHECKPOINT_AI3) & (CURRENT_CHECKPOINT < CURRENT_CHECKPOINT_AI1) & (CURRENT_CHECKPOINT < CURRENT_CHECKPOINT_AI2))
			{
				CURRENT_PLACE = 3;
			}
			if ((CURRENT_CHECKPOINT_AI1 > CURRENT_CHECKPOINT) & (CURRENT_CHECKPOINT_AI2 > CURRENT_CHECKPOINT) & (CURRENT_CHECKPOINT_AI3 > CURRENT_CHECKPOINT))
			{
				CURRENT_PLACE = 4;
			}
		}
		if (CURRENT_CHECKPOINT_FOR_FINISH > ALL_CHECKPOINTS - 11)
		{
			START_.GetComponent<FINISH_POINT>().ACTIVE_PARTICLES();
		}
		if (CURRENT_CHECKPOINT_FOR_FINISH == 2)
		{
			START_.GetComponent<FINISH_POINT>().HIDE_PARTICLES();
		}
		if (RACE_TRIGGER._RACE_CIRCUIT)
		{
			PROGRESS_REAL = (float)CURRENT_CHECKPOINT_ / (float)ALL_CHECKPOINTS_;
			LAPRACE_CURRENT_LAP.text = string.Empty + CURRENT_LAP;
			LAPRACE_CURRENT_PLACE.text = string.Empty + CURRENT_PLACE;
			if ((CURRENT_LAP == RACE_TRIGGER._RACE_CIRCUIT_LAPS) & !show_last_lap)
			{
				StartCoroutine(SHOW_LASTLAP());
				show_last_lap = true;
			}
		}
		else
		{
			LAPRACE_CURRENT_PLACE.text = string.Empty + CURRENT_PLACE;
			PROGRESS_REAL = (float)CURRENT_CHECKPOINT_ / (float)ALL_CHECKPOINTS_;
		}
		CHEKPOINT_UPDATE = false;
	}

	private IEnumerator ADS()
	{
		if (!NEED_QUIT && !FALIED_UI.activeInHierarchy)
		{
			GAME_MANAGER.AFTER_RACE = true;
			GAME_MANAGER.RND_POS = true;
			GAME_MANAGER.SHOW_XP = true;
		}
		EVENTS.SetActive(value: false);
		yield return new WaitForSeconds(1f);
		EVENTS.SetActive(value: true);
		GameObject[] PREAFAB_ = GameObject.FindGameObjectsWithTag("RACE_PREFAB");
		GameObject[] array = PREAFAB_;
		foreach (GameObject obj in array)
		{
			UnityEngine.Object.Destroy(obj);
		}
		if (((ES2.Load<string>("DAILY_MISSION_2_TYPE") == "WIN_RACES") & !FALIED_UI.activeInHierarchy) && ES2.Load<int>("DAILY_MISSION_2") < ES2.Load<int>("DAILY_MISSION_2_NEED"))
		{
			ES2.Save(ES2.Load<int>("DAILY_MISSION_2") + 1, "DAILY_MISSION_2");
			if (ES2.Load<int>("DAILY_MISSION_2") == ES2.Load<int>("DAILY_MISSION_2_NEED"))
			{
				GAME_MANAGER.DTAST_COMPELTE = true;
			}
		}
		MENU_MANAGER.APPODEAL_ADS_TIMER = 50f;
		TIMER_MONEY = 0f;
		TIMER_MONEY_ACS = 0f;
		ADD_MONEY = 0;
		START_RACE = false;
		RETURN_ = false;
		Creater_level = false;
		return_timer = 0f;
		GAME_MANAGER.IN_RACE_POINT = 0;
		GAME_MANAGER.IN_RACE = false;
		if (!FALIED_UI.activeInHierarchy && ES2.Load<int>("TUTORIAL_13") == 0)
		{
			GAME_MANAGER_.GetComponent<GAME_MANAGER>().SHOW_TUT();
		}
		GAME_MANAGER_.GetComponent<GAME_MANAGER>().SHOW_3D_ICONS();
		TRAFFIC_OBJ.GetComponent<GAME_MANAGER>().LETTER();
		TRAFFIC_OBJ.GetComponent<GAME_MANAGER>().GEAR();
		RCC_CAMERA.GetComponent<RCC_Camera>().enabled = true;
		PLAYER.SetActive(value: true);
		FINISH_UI.SetActive(value: false);
		RACE_POINTS.SetActive(value: true);
		FALIED_UI.SetActive(value: false);
		HUD_UI.SetActive(value: true);
		DASHBOARD_UI.SetActive(value: true);
		RACE_POINTS.SetActive(value: true);
		RCC_CAMERA.GetComponent<RCC_Camera>().enabled = true;
		RACE_UI.SetActive(value: false);
		Camera.main.GetComponent<ScreenFader>().enabled = true;
		Camera.main.GetComponent<ScreenFader>().RS();
		MUSIC_MANAGER.GetComponent<MUSIC_MANAGER>().PLAY_();
		Resources.UnloadUnusedAssets();
		GC.Collect();
	}

	public void CLOSE_COMPLETE_()
	{
		GAME_MANAGER.TRAFFIC_CURRENT = 0;
		AudioSource.PlayClipAtPoint(CLICK, Camera.main.transform.position);
		if (!FALIED_UI.activeInHierarchy & FINISH_UI.activeInHierarchy)
		{
		}
		StartCoroutine(ADS());
	}

	public void START_RACE_()
	{
		Camera.main.GetComponent<CameraFilterPack_Blur_Blurry>().enabled = false;
		Creater_level = false;
		AudioSource.PlayClipAtPoint(CLICK, Camera.main.transform.position);
		DASHBOARD_UI.SetActive(value: false);
		RACING_DASHBOARD_UI.SetActive(value: true);
		GAME_MANAGER.TRAFFIC_CURRENT = 0;
		LOADING_CANVAS.GetComponent<AudioSource>().enabled = false;
		LOADING_CANVAS.SetActive(value: false);
		TRAFFIC_OBJ.GetComponent<AudioSource>().mute = false;
		Camera.main.GetComponent<ScreenFader>().enabled = true;
		Camera.main.GetComponent<ScreenFader>().RS();
		if ((RACE_TRIGGER._AI_RACE || RACE_TRIGGER._RACE_SPRINT) && ES2.Load<int>("TUTORIAL_18") == 0)
		{
			Camera.main.GetComponent<ScreenFader>().enabled = false;
			TUTORIAL_7.SetActive(value: true);
			ES2.Save(1, "TUTORIAL_18");
			Time.timeScale = 0f;
		}
		if ((!RACE_TRIGGER._AI_RACE & RACE_TRIGGER._SPEED_RACE) && ES2.Load<int>("TUTORIAL_19") == 0)
		{
			Camera.main.GetComponent<ScreenFader>().enabled = false;
			TUTORIAL_8.SetActive(value: true);
			ES2.Save(1, "TUTORIAL_19");
			Time.timeScale = 0f;
		}
		if ((!RACE_TRIGGER._AI_RACE & RACE_TRIGGER._TIME_RACE) && ES2.Load<int>("TUTORIAL_20") == 0)
		{
			Camera.main.GetComponent<ScreenFader>().enabled = false;
			TUTORIAL_9.SetActive(value: true);
			ES2.Save(1, "TUTORIAL_20");
			Time.timeScale = 0f;
		}
	}

	public void CLOSE_TUT()
	{
		Time.timeScale = 1f;
		TUTORIAL_7.SetActive(value: false);
	}

	public void CLOSE_TUT2()
	{
		Time.timeScale = 1f;
		TUTORIAL_8.SetActive(value: false);
	}

	public void CLOSE_TUT3()
	{
		Time.timeScale = 1f;
		TUTORIAL_9.SetActive(value: false);
	}

	public void START_RACE_UI()
	{
		if (ES2.Load<int>("SELECT_CHARACTER") == 3)
		{
			MORE_XP = 1;
		}
		else
		{
			MORE_XP = 0;
		}
		GAME_MANAGER_.GetComponent<GAME_MANAGER>().HIDE_3D_ICONS();
		AudioSource.PlayClipAtPoint(CLICK, Camera.main.transform.position);
		if (RACE_TRIGGER._TRAFFIC_RACE)
		{
			RACE_UI.SetActive(value: false);
			TRAFFIC_OBJ.GetComponent<TRAFFIC_MANAGER>().ON_START();
			GAME_MANAGER.IN_RACE_POINT = 0;
			return;
		}
		RACE_POINTS.SetActive(value: false);
		CURRENT_CHECKPOINT_AI1 = 0;
		CURRENT_CHECKPOINT_AI2 = 0;
		CURRENT_CHECKPOINT_AI3 = 0;
		CURRENT_CHECKPOINT_FOR_FINISH_AI1 = 0;
		CURRENT_CHECKPOINT_FOR_FINISH_AI2 = 0;
		CURRENT_CHECKPOINT_FOR_FINISH_AI3 = 0;
		CURRENT_CHECKPOINT_FOR_FINISH = 0;
		GAME_MANAGER.IN_RACE_POINT = 0;
		FINISH_RACE = false;
		show_last_lap = false;
		PROGRESS_IMG.fillAmount = 0f;
		PROGRESS_RACE = 0f;
		CURRENT_LAP = 1;
		CURRENT_PLACE = 4;
		ALL_CHECKPOINTS = 0;
		CURRENT_CHECKPOINT = 0;
		CHEKPOINT_UPDATE = false;
		START_RACE = false;
		RACE_UI.SetActive(value: false);
		loading_progress = 0f;
		Start_load = false;
		LOADING_FILL.fillAmount = loading_progress;
		LOADING_OBJ_.SetActive(value: true);
		START_OBJ_.SetActive(value: false);
		LOADING_CANVAS.SetActive(value: true);
		LOADING_CANVAS.GetComponent<AudioSource>().enabled = true;
		LOADING_CANVAS.GetComponent<AudioSource>().volume = GAME_MANAGER.MUSIC_VOLUME - 0.2f;
		TRAFFIC_OBJ.GetComponent<AudioSource>().mute = true;
		if (RACE_TRIGGER._TIME_RACE || RACE_TRIGGER._SPEED_RACE)
		{
			AWARD_BRONZE.SetActive(value: false);
			AWARD_SILVER.SetActive(value: false);
		}
		else
		{
			AWARD_BRONZE.SetActive(value: true);
			AWARD_SILVER.SetActive(value: true);
		}
		NEW_XP = 0f;
		fire_polosa = 1f;
		sec = 31;
	}

	public void CLOSE_RACE_UI()
	{
		AudioSource.PlayClipAtPoint(CLICK, Camera.main.transform.position);
		if (GAME_MANAGER.START_RACE_FROM_MENU)
		{
			StartCoroutine(ADS());
			Application.LoadLevel(0);
		}
		GAME_MANAGER.IN_RACE_POINT = 0;
		RACE_UI.SetActive(value: false);
	}

	private IEnumerator SHOW_LASTLAP()
	{
		LASTLAP_UI.SetActive(value: true);
		yield return new WaitForSecondsRealtime(3f);
		LASTLAP_UI.SetActive(value: false);
	}

	private void START_COUNT()
	{
		if (!(START_RACE & !LOADING_CANVAS.activeInHierarchy))
		{
			return;
		}
		start_timer += Time.deltaTime;
		if (start_timer > 0.15f)
		{
			START_OBJ.SetActive(value: true);
		}
		if (!(start_timer > 1f))
		{
			return;
		}
		start_count++;
		start_timer = 0f;
		if (start_count == 1)
		{
			START_IMG.color = new Color(1f, 1f, 1f, 1f);
			START_IMG2.color = new Color(1f, 1f, 1f, 1f);
			START_IMG3.color = new Color(1f, 1f, 1f, 1f);
			START_IMG.sprite = SPR_START1;
			START_IMG2.sprite = SPR_START1;
			START_IMG3.sprite = SPR_START1;
			AudioSource.PlayClipAtPoint(SIGNAL_1, Camera.main.transform.position);
		}
		if (start_count == 2)
		{
			START_IMG.sprite = SPR_START2;
			START_IMG2.sprite = SPR_START2;
			START_IMG3.sprite = SPR_START2;
			AudioSource.PlayClipAtPoint(SIGNAL_1, Camera.main.transform.position);
		}
		if (start_count == 3)
		{
			START_IMG.sprite = SPR_START3;
			START_IMG2.sprite = SPR_START3;
			START_IMG3.sprite = SPR_START3;
			AudioSource.PlayClipAtPoint(SIGNAL_2, Camera.main.transform.position);
			base.gameObject.GetComponent<AudioSource>().clip = RACING_MUSIC[UnityEngine.Random.Range(0, RACING_MUSIC.Length)];
			base.gameObject.GetComponent<AudioSource>().enabled = true;
			base.gameObject.GetComponent<AudioSource>().volume = GAME_MANAGER.MUSIC_VOLUME;
		}
		if (start_count == 4)
		{
			RACE_PROGRESS.SetActive(value: true);
			RACE_UI_.SetActive(value: true);
			RACE_LAP_.SetActive(value: false);
			RACE_PLACE_.SetActive(value: false);
			RACE_TIME_.SetActive(value: false);
			RACE_SPEED_.SetActive(value: false);
			CURRENT_CHECKPOINT_ = 0;
			GAME_MANAGER.IN_RACE_POINT = 0;
			LAPRACE_CURRENT_PLACE.text = string.Empty + CURRENT_PLACE;
			if (RACE_TRIGGER._RACE_CIRCUIT)
			{
				RACE_PLACE_.SetActive(value: true);
				RACE_LAP_.SetActive(value: true);
				LAPRACE_ALL_LAP.text = string.Empty + RACE_TRIGGER._RACE_CIRCUIT_LAPS;
				LAPRACE_CURRENT_LAP.text = string.Empty + CURRENT_LAP;
			}
			if (RACE_TRIGGER._RACE_SPRINT)
			{
				RACE_PLACE_.SetActive(value: true);
			}
			if (RACE_TRIGGER._TIME_RACE)
			{
				RACE_TIME_.SetActive(value: true);
				TIME_SEC_.text = "30";
			}
			if (RACE_TRIGGER._SPEED_RACE)
			{
				RACE_SPEED_.SetActive(value: true);
				RACE_PROGRESS.SetActive(value: false);
				RACE_SPEED_PROGRESS.fillAmount = 1f;
				RACE_SPEED_PROGRESS2.fillAmount = 1f;
				fire_polosa = 1f;
			}
			START_OBJ.SetActive(value: false);
			HUD_UI.SetActive(value: true);
			START_RACE = false;
		}
	}
}
