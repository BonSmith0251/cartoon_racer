using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TRAFFIC_MANAGER : MonoBehaviour
{
	public GameObject EVENTS;

	public GameObject TUTORIAL_6;

	public GameObject MUSIC_MANAGER;

	public GameObject SHOW_GAS;

	public GameObject RCC_CAMERA;

	public GameObject START_BUTTON;

	public GameObject LAODING_FIIL;

	public GameObject LOADING_CANVAS;

	public Image LOADING_FILL;

	private float loading_progress;

	public GameObject RACE_FALIED_UI;

	public GameObject RACE_FALIED_DAMAGE;

	public GameObject RACE_FALIED_TIME;

	public GameObject RACE_FALIED_FUEL;

	public GameObject RACE_COMPLETE_UI;

	private float start_timer;

	private int start_count;

	public GameObject СONTROL_OBJ;

	public GameObject START_OBJ;

	public static bool NEED_QUIT;

	public AudioClip AMBIENT;

	public AudioClip FARM_AMBIENT;

	public AudioClip SIGNAL_1;

	public AudioClip SIGNAL_2;

	public AudioClip MONEY_SND;

	public Image START_IMG;

	public Image START_IMG2;

	public Image START_IMG3;

	public Sprite SPR_START1;

	public Sprite SPR_START2;

	public Sprite SPR_START3;

	public AudioClip[] TRAFFIC_MUSIC;

	public GameObject TIME_PREFAB;

	public GameObject TRAFFIC_UI;

	public GameObject FREE_UI;

	public GameObject TRAFFIC_UI2;

	public GameObject COIN_PREFAB;

	public GameObject[] PLAYER_PREFAB;

	public GameObject[] AIRPLANE_PREFAB;

	public GameObject GUARD_PREFAB;

	public GameObject WRONG_WAY;

	public GameObject FREE_DASHBOARD;

	public GameObject RACEPOINTS;

	public GameObject RACEPOINTS2;

	public GameObject MINIMAP_ICO;

	public GameObject MINIMAP;

	public RCC_Camera RCC_Camera;

	public GameObject[] ROAD_PREFAB;

	public GameObject[] TRAFFIC_CAR;

	public GameObject NITRO_PREFAB;

	public Image CLOCK_FILL;

	public Image FUEL_FILL;

	public Text MONEY_TXT;

	public Text MONEY_FINISH_TXT;

	public Image DISTANCE_UI;

	public Button FINISH_CLOSE;

	public static bool COMPLETE;

	public static bool FALIED;

	public static bool TRAFFIC_MODE;

	public static bool CREATE_ROAD;

	public static float ROAD_POINT_Z;

	public static float TRAFFIC_POINT_Z;

	public static int MAX_TRAFFIC;

	public static int CURRENT_TRAFFIC;

	public static bool ADD_TIME;

	public static bool ADD_FUEL;

	private float RND_TIME;

	private int RND_TIME_SIDE;

	private float RND_AIR;

	private float RND_COIN;

	private int RND_COIN_SIDE;

	private float RND_CAR;

	private int RND_SIDE;

	private int RND_CAR2;

	private float RND_NITRO;

	private float RND_GUARD;

	private int RND_GUARD2;

	private int RND_NITRO_SIDE;

	private int SELECTED_CAR;

	private bool NEW_ROAD;

	private int FUEL_LOCATION;

	private float NEW_XP;

	private float TIME_;

	private float FUEL_;

	private float TIME_GLITCH;

	private float FUEL_GLITCH;

	private float DISTANCE;

	private int AMOUNT;

	private int CAR_AMOUNT;

	private int MORE_XP;

	private float TIMER_MONEY_ACS;

	private float TIMER_MONEY;

	private int ALL_MONEY;

	private int ADD_MONEY;

	private GameObject PLAYER;

	public void ON_START()
	{
		loading_progress = 0f;
		NEW_XP = 0f;
		FUEL_LOCATION = 0;
		START_BUTTON.SetActive(value: false);
		GameObject[] array = GameObject.FindGameObjectsWithTag("GEAR");
		GameObject[] array2 = array;
		foreach (GameObject obj in array2)
		{
			UnityEngine.Object.Destroy(obj);
		}
		GameObject[] array3 = GameObject.FindGameObjectsWithTag("TRAFFIC");
		GameObject[] array4 = array3;
		foreach (GameObject obj2 in array4)
		{
			UnityEngine.Object.Destroy(obj2);
		}
		base.gameObject.GetComponent<AudioSource>().Stop();
		LOADING_CANVAS.SetActive(value: true);
		if (!GAME_MANAGER.START_RACE_FROM_MENU)
		{
			if (MENU_MANAGER.LOADING_LEVEL == 0)
			{
				SceneManager.UnloadSceneAsync("FARM_STATIC");
			}
			else
			{
				SceneManager.UnloadSceneAsync("CITY_STATIC");
			}
		}
		UnityEngine.Object.Destroy(GameObject.FindGameObjectWithTag("COINS_MANAGER"));
		PLAYER = RCC_CAMERA.GetComponent<RCC_Camera>().playerCar.gameObject;
		PLAYER.transform.position = new Vector3(-1881.5f, 33f, -1707f);
		PLAYER.transform.rotation = Quaternion.Euler(0f, RACE_TRIGGER._PLAYER_POSITION.y, 0f);
		PLAYER.gameObject.SetActive(value: false);
		SceneManager.LoadSceneAsync("TRAFFIC", LoadSceneMode.Additive);
		Camera.main.farClipPlane = 180f;
		RenderSettings.fog = true;
		RenderSettings.fogStartDistance = 150f;
		RenderSettings.fogEndDistance = 180f;
		FREE_DASHBOARD.SetActive(value: false);
		MINIMAP.SetActive(value: false);
		MINIMAP_ICO.SetActive(value: false);
		RACEPOINTS.SetActive(value: false);
		RACEPOINTS2.SetActive(value: false);
		TRAFFIC_UI2.SetActive(value: false);
		TRAFFIC_UI.SetActive(value: true);
		СONTROL_OBJ.SetActive(value: false);
		WRONG_WAY.SetActive(value: false);
		CREATE_ROAD = false;
		TRAFFIC_MODE = true;
		FALIED = false;
		COMPLETE = false;
		TRAFFIC_POINT_Z = -1600f;
		RND_CAR = 900f;
		GAME_MANAGER.PLAYER_FUEL = 1f;
		TIME_ = 0.8f;
		FUEL_ = 0.9f;
		CLOCK_FILL.fillAmount = 1f;
		FUEL_FILL.fillAmount = 1f;
		ADD_MONEY = 0;
		ALL_MONEY = RACE_TRIGGER._1ST_AWARD_;
		AMOUNT = RACE_TRIGGER._TRAFFIC_DISTANCE + 500;
		CAR_AMOUNT = 120;
		start_count = 0;
		start_timer = 0f;
		DISTANCE = 0f;
		if (ES2.Load<int>("SELECT_CHARACTER") == 3)
		{
			MORE_XP = 1;
		}
		else
		{
			MORE_XP = 0;
		}
		loading_progress = 0f;
	}

	private IEnumerator SHOW_GAS_()
	{
		SHOW_GAS.SetActive(value: true);
		yield return new WaitForSecondsRealtime(4f);
		SHOW_GAS.SetActive(value: false);
	}

	private IEnumerator DISABLE_()
	{
		yield return new WaitForSecondsRealtime(3f);
		CREATE_ROAD = false;
		NEW_ROAD = false;
	}

	public void START_RACE_()
	{
		Camera.main.GetComponent<CameraFilterPack_Blur_Blurry>().enabled = false;
		PLAYER.gameObject.SetActive(value: true);
		LOADING_CANVAS.SetActive(value: false);
		loading_progress = 0f;
		Camera.main.GetComponent<ScreenFader>().enabled = true;
		Camera.main.GetComponent<ScreenFader>().RS();
		if (ES2.Load<int>("TUTORIAL_17") == 0)
		{
			Camera.main.GetComponent<ScreenFader>().enabled = false;
			TUTORIAL_6.SetActive(value: true);
			ES2.Save(1, "TUTORIAL_17");
			Time.timeScale = 0f;
		}
	}

	public void CLOSE_TUT()
	{
		Time.timeScale = 1f;
		TUTORIAL_6.SetActive(value: false);
	}

	private void Update()
	{
		if (!TRAFFIC_MODE)
		{
			return;
		}
		if (Time.timeScale < 2f)
		{
			Time.timeScale += Time.deltaTime / 800f;
		}
		if (loading_progress < 1f)
		{
			loading_progress += Time.deltaTime / 4f + (float)(UnityEngine.Random.Range(1500, 3000) / 6190);
			LOADING_FILL.fillAmount = loading_progress;
			START_BUTTON.SetActive(value: false);
			LAODING_FIIL.SetActive(value: true);
		}
		else
		{
			START_BUTTON.SetActive(value: true);
			LAODING_FIIL.SetActive(value: false);
		}
		if (!COMPLETE || !FALIED)
		{
			if (Time.frameCount % 10 == 0)
			{
				DISTANCE = Camera.main.transform.position.z + 1700f;
				DISTANCE_UI.fillAmount = DISTANCE / (float)AMOUNT;
			}
			if (Time.frameCount % 30 == 0)
			{
				MONEY_TXT.text = string.Empty + GAME_MANAGER.PLAYER_MONEY;
				CLOCK_FILL.fillAmount = TIME_;
				FUEL_FILL.fillAmount = FUEL_;
			}
			if ((DISTANCE > (float)AMOUNT) & (start_count > 4))
			{
				COMPLETE = true;
			}
			if (!COMPLETE)
			{
				if (TIME_ < 0.1f)
				{
					FALIED = true;
					RACE_FALIED_TIME.SetActive(value: true);
					RACE_FALIED_FUEL.SetActive(value: false);
					RACE_FALIED_DAMAGE.SetActive(value: false);
				}
				if (FUEL_ < 0.1f)
				{
					FALIED = true;
					RACE_FALIED_TIME.SetActive(value: false);
					RACE_FALIED_FUEL.SetActive(value: true);
					RACE_FALIED_DAMAGE.SetActive(value: false);
				}
			}
		}
		if (FALIED & !RACE_FALIED_UI.activeInHierarchy)
		{
			PLAYER.SetActive(value: false);
			Terrain.activeTerrain.gameObject.GetComponent<AudioSource>().clip = null;
			Terrain.activeTerrain.gameObject.GetComponent<AudioSource>().enabled = false;
			RACE_FALIED_UI.SetActive(value: true);
			TRAFFIC_UI.SetActive(value: false);
			TRAFFIC_UI2.SetActive(value: false);
			СONTROL_OBJ.SetActive(value: false);
			if (!RACE_FALIED_TIME.activeInHierarchy || !RACE_FALIED_FUEL.activeInHierarchy)
			{
				RACE_FALIED_DAMAGE.SetActive(value: true);
			}
		}
		if (COMPLETE & !RACE_COMPLETE_UI.activeInHierarchy)
		{
			Time.timeScale = 1f;
			Terrain.activeTerrain.gameObject.GetComponent<AudioSource>().clip = null;
			Terrain.activeTerrain.gameObject.GetComponent<AudioSource>().enabled = false;
			RACE_COMPLETE_UI.SetActive(value: true);
			TRAFFIC_UI.SetActive(value: false);
			TRAFFIC_UI2.SetActive(value: false);
			СONTROL_OBJ.SetActive(value: false);
			PLAYER.SetActive(value: false);
			ES2.Save(1, "RACE_TRAFFIC" + RACE_TRIGGER._INDEX);
			COMPLETE = false;
		}
		if ((ADD_MONEY < ALL_MONEY) & RACE_COMPLETE_UI.activeInHierarchy)
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
				MONEY_FINISH_TXT.text = "+ " + ADD_MONEY;
			}
		}
		if ((ADD_MONEY == ALL_MONEY) & !FINISH_CLOSE.interactable)
		{
			ES2.Save(GAME_MANAGER.PLAYER_MONEY, "PLAYER_MONEY");
			FINISH_CLOSE.interactable = true;
		}
		if (ADD_FUEL)
		{
			FUEL_ = 0.9f;
			ADD_FUEL = false;
			FUEL_FILL.fillAmount = FUEL_;
		}
		if ((FUEL_ > 0.1f) & !LOADING_CANVAS.activeInHierarchy)
		{
			FUEL_ -= Time.deltaTime / 200f;
			if (FUEL_ < 0.3f)
			{
				FUEL_GLITCH += Time.deltaTime;
				if (FUEL_GLITCH > 0.5f)
				{
					FUEL_FILL.color = new Color(1f, 1f, 1f, 1f);
				}
				else
				{
					FUEL_FILL.color = new Color(1f, 1f, 1f, 0f);
				}
				if (FUEL_GLITCH > 1f)
				{
					FUEL_GLITCH = 0f;
				}
			}
		}
		if (ADD_TIME)
		{
			TIME_ += 0.3f;
			if (TIME_ > 0.8f)
			{
				TIME_ = 0.8f;
			}
			ADD_TIME = false;
			CLOCK_FILL.fillAmount = TIME_;
		}
		if ((TIME_ > 0.1f) & !LOADING_CANVAS.activeInHierarchy)
		{
			TIME_ -= Time.deltaTime / 120f;
			if (TIME_ < 0.3f)
			{
				TIME_GLITCH += Time.deltaTime;
				if (TIME_GLITCH > 0.5f)
				{
					CLOCK_FILL.color = new Color(1f, 1f, 1f, 1f);
				}
				else
				{
					CLOCK_FILL.color = new Color(1f, 1f, 1f, 0f);
				}
				if (TIME_GLITCH > 1f)
				{
					TIME_GLITCH = 0f;
				}
			}
			else
			{
				CLOCK_FILL.color = new Color(1f, 1f, 1f, 1f);
			}
		}
		if ((RCC_Camera.playerCar.transform.rotation.eulerAngles.y > 100f) & (RCC_Camera.playerCar.transform.rotation.eulerAngles.y < 270f) & !FALIED & !START_OBJ.activeInHierarchy)
		{
			WRONG_WAY.SetActive(value: true);
			RCC_Camera.playerCar.permanentGas = false;
		}
		else
		{
			WRONG_WAY.SetActive(value: false);
			if (!COMPLETE & !LOADING_CANVAS.activeInHierarchy)
			{
				RCC_Camera.playerCar.permanentGas = true;
			}
		}
		if (CREATE_ROAD & !NEW_ROAD)
		{
			if (FUEL_LOCATION == 3)
			{
				if (CAR_AMOUNT > 80)
				{
					CAR_AMOUNT -= 5;
				}
				GameObject gameObject = UnityEngine.Object.Instantiate(ROAD_PREFAB[0], new Vector3(-1914f, 12f, ROAD_POINT_Z + 564.2f), base.transform.rotation);
				gameObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
				FUEL_LOCATION = 0;
				StartCoroutine(SHOW_GAS_());
			}
			else
			{
				GameObject gameObject2 = UnityEngine.Object.Instantiate(ROAD_PREFAB[UnityEngine.Random.Range(1, 4)], new Vector3(-1914f, 12f, ROAD_POINT_Z + 564.2f), base.transform.rotation);
				gameObject2.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
			}
			NEW_ROAD = true;
			StartCoroutine(DISABLE_());
			FUEL_LOCATION++;
		}
		if ((RCC_CarControllerV3.SPEED > 60f) & (Time.timeScale > 0.9f))
		{
			if (DISTANCE > 3000f)
			{
				RND_GUARD += Time.deltaTime * 10f + (float)UnityEngine.Random.Range(-5, 15);
				if (RND_GUARD > 3000f)
				{
					RND_GUARD = 0f;
					RND_GUARD2 = UnityEngine.Random.Range(0, 2);
					GameObject gameObject3 = UnityEngine.Object.Instantiate(GUARD_PREFAB, new Vector3(-1882.2f, 25.26f, Camera.main.transform.position.z + 200f), base.transform.rotation);
					gameObject3.transform.rotation = Quaternion.Euler(0f, 90f, 0f);
					gameObject3.GetComponent<GUARD>().DYNAMIC = true;
				}
			}
			RND_TIME += Time.deltaTime * 10f + (float)UnityEngine.Random.Range(-5, 10);
			if (RND_TIME > 2000f)
			{
				RND_TIME = 0f;
				RND_TIME_SIDE = UnityEngine.Random.Range(0, 2);
				if (RND_TIME_SIDE == 1)
				{
					GameObject gameObject4 = UnityEngine.Object.Instantiate(TIME_PREFAB, new Vector3(-1887f, 32.9f, Camera.main.transform.position.z + 200f), base.transform.rotation);
					gameObject4.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
				}
				else
				{
					GameObject gameObject5 = UnityEngine.Object.Instantiate(TIME_PREFAB, new Vector3(-1881.4f, 32.9f, Camera.main.transform.position.z + 200f), base.transform.rotation);
					gameObject5.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
				}
			}
			RND_AIR += Time.deltaTime * 10f + (float)UnityEngine.Random.Range(-5, 10);
			if (RND_AIR > 3000f)
			{
				RND_AIR = 0f;
				GameObject gameObject6 = UnityEngine.Object.Instantiate(AIRPLANE_PREFAB[UnityEngine.Random.Range(0, AIRPLANE_PREFAB.Length)], new Vector3(UnityEngine.Random.Range(-1850f, -1920f), 50.5f, Camera.main.transform.position.z + UnityEngine.Random.Range(300f, 450f)), base.transform.rotation);
				gameObject6.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
			}
			RND_COIN += Time.deltaTime * 10f + (float)UnityEngine.Random.Range(-5, 10);
			if (RND_COIN > 800f)
			{
				RND_COIN = 0f;
				RND_COIN_SIDE = UnityEngine.Random.Range(0, 2);
				if (RND_COIN_SIDE == 1)
				{
					GameObject gameObject7 = UnityEngine.Object.Instantiate(COIN_PREFAB, new Vector3(-1885.8f, 14.8f, Camera.main.transform.position.z + 200f), base.transform.rotation);
					gameObject7.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
				}
				else
				{
					GameObject gameObject8 = UnityEngine.Object.Instantiate(COIN_PREFAB, new Vector3(-1880f, 14.8f, Camera.main.transform.position.z + 200f), base.transform.rotation);
					gameObject8.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
				}
			}
			RND_NITRO += Time.deltaTime * 10f + (float)UnityEngine.Random.Range(-5, 10);
			if (RND_NITRO > 2500f)
			{
				RND_NITRO = 0f;
				RND_NITRO_SIDE = UnityEngine.Random.Range(0, 2);
				if (RND_NITRO_SIDE == 1)
				{
					GameObject gameObject9 = UnityEngine.Object.Instantiate(NITRO_PREFAB, new Vector3(-1886.94f, 32.46f, Camera.main.transform.position.z + 200f), base.transform.rotation);
					gameObject9.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
				}
				else
				{
					GameObject gameObject10 = UnityEngine.Object.Instantiate(NITRO_PREFAB, new Vector3(-1881.56f, 32.46f, Camera.main.transform.position.z + 200f), base.transform.rotation);
					gameObject10.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
				}
			}
			RND_CAR += Time.deltaTime * 10f + (float)UnityEngine.Random.Range(-5, 20);
			RND_CAR2 = UnityEngine.Random.Range(0, 350);
			if (RND_CAR > 1000f)
			{
				RND_CAR = 0f;
				RND_SIDE++;
				if (RND_SIDE > 3)
				{
					RND_SIDE = 1;
				}
				TRAFFIC_POINT_Z += UnityEngine.Random.Range(55, CAR_AMOUNT);
				if (TRAFFIC_POINT_Z < Camera.main.transform.position.z + 200f)
				{
					TRAFFIC_POINT_Z = Camera.main.transform.position.z + 240f;
				}
				if (RND_SIDE == 2)
				{
					GameObject gameObject11 = UnityEngine.Object.Instantiate(TRAFFIC_CAR[UnityEngine.Random.Range(0, TRAFFIC_CAR.Length)], new Vector3(-1887.15f, 34f, TRAFFIC_POINT_Z), base.transform.rotation);
					gameObject11.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
				}
				else
				{
					GameObject gameObject12 = UnityEngine.Object.Instantiate(TRAFFIC_CAR[UnityEngine.Random.Range(0, TRAFFIC_CAR.Length)], new Vector3(-1881.31f, 34f, TRAFFIC_POINT_Z), base.transform.rotation);
					gameObject12.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
				}
			}
			if (RND_CAR2 == 1)
			{
				RND_SIDE = UnityEngine.Random.Range(1, 3);
				if (RND_SIDE == 1)
				{
					GameObject gameObject13 = UnityEngine.Object.Instantiate(TRAFFIC_CAR[UnityEngine.Random.Range(0, TRAFFIC_CAR.Length)], new Vector3(-1908.65f, 33f, Camera.main.transform.position.z + 200f), base.transform.rotation);
					gameObject13.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
					gameObject13.GetComponent<TRAFFIC_MOVE>().KUDA = true;
				}
				else
				{
					GameObject gameObject14 = UnityEngine.Object.Instantiate(TRAFFIC_CAR[UnityEngine.Random.Range(0, TRAFFIC_CAR.Length)], new Vector3(-1914.42f, 33f, Camera.main.transform.position.z + 200f), base.transform.rotation);
					gameObject14.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
					gameObject14.GetComponent<TRAFFIC_MOVE>().KUDA = true;
				}
			}
		}
		if (!((start_count < 5) & !LOADING_CANVAS.activeInHierarchy))
		{
			return;
		}
		start_timer += Time.deltaTime;
		if (start_timer > 0.15f)
		{
			START_OBJ.SetActive(value: true);
		}
		if (start_timer > 1f)
		{
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
			}
			if (start_count == 4)
			{
				base.gameObject.GetComponent<AudioSource>().clip = AMBIENT;
				base.gameObject.GetComponent<AudioSource>().Play();
				Terrain.activeTerrain.gameObject.GetComponent<AudioSource>().clip = TRAFFIC_MUSIC[UnityEngine.Random.Range(0, TRAFFIC_MUSIC.Length)];
				Terrain.activeTerrain.gameObject.GetComponent<AudioSource>().enabled = true;
				Terrain.activeTerrain.gameObject.GetComponent<AudioSource>().volume = GAME_MANAGER.MUSIC_VOLUME;
				Terrain.activeTerrain.gameObject.GetComponent<AudioSource>().Play();
				TRAFFIC_UI2.SetActive(value: true);
				START_OBJ.SetActive(value: false);
				СONTROL_OBJ.SetActive(value: true);
				start_count = 99;
			}
		}
	}

	private IEnumerator ADS()
	{
		if (!NEED_QUIT && !RACE_FALIED_UI.activeInHierarchy)
		{
			GAME_MANAGER.AFTER_RACE = true;
			GAME_MANAGER.RND_POS = true;
			GAME_MANAGER.SHOW_XP = true;
		}
		EVENTS.SetActive(value: false);
		yield return new WaitForSeconds(1f);
		EVENTS.SetActive(value: true);
		EVENTS.SetActive(value: true);
		if (((ES2.Load<string>("DAILY_MISSION_2_TYPE") == "WIN_RACES") & !RACE_FALIED_UI.activeInHierarchy) && ES2.Load<int>("DAILY_MISSION_2") < ES2.Load<int>("DAILY_MISSION_2_NEED"))
		{
			ES2.Save(ES2.Load<int>("DAILY_MISSION_2") + 1, "DAILY_MISSION_2");
			if (ES2.Load<int>("DAILY_MISSION_2") == ES2.Load<int>("DAILY_MISSION_2_NEED"))
			{
				GAME_MANAGER.DTAST_COMPELTE = true;
			}
		}
		TRAFFIC_MODE = false;
		FALIED = false;
		COMPLETE = false;
		if (0 == 0)
		{
			Time.timeScale = 1f;
			if (MENU_MANAGER.LOADING_LEVEL == 0)
			{
				SceneManager.LoadSceneAsync("FARM_STATIC", LoadSceneMode.Additive);
				RACEPOINTS.SetActive(value: true);
			}
			else
			{
				SceneManager.LoadSceneAsync("CITY_STATIC", LoadSceneMode.Additive);
				RACEPOINTS2.SetActive(value: true);
			}
			GameObject[] array = GameObject.FindGameObjectsWithTag("TRAFFIC");
			GameObject[] array2 = array;
			foreach (GameObject obj in array2)
			{
				UnityEngine.Object.Destroy(obj);
			}
			GameObject[] array3 = GameObject.FindGameObjectsWithTag("COIN2");
			GameObject[] array4 = array3;
			foreach (GameObject obj2 in array4)
			{
				UnityEngine.Object.Destroy(obj2);
			}
			GameObject[] array5 = GameObject.FindGameObjectsWithTag("NUTRO");
			GameObject[] array6 = array5;
			foreach (GameObject obj3 in array6)
			{
				UnityEngine.Object.Destroy(obj3);
			}
			base.gameObject.GetComponent<GAME_MANAGER>().GEAR();
			base.gameObject.GetComponent<GAME_MANAGER>().COINS();
			SceneManager.UnloadSceneAsync("TRAFFIC");
			Camera.main.farClipPlane = 150f;
			RenderSettings.fogStartDistance = 120f;
			RenderSettings.fogEndDistance = 150f;
			PLAYER.transform.position = new Vector3(307f, 33f, 539f);
			PLAYER.transform.rotation = Quaternion.Euler(0f, -10f, 0f);
			TRAFFIC_UI.SetActive(value: false);
			TRAFFIC_UI2.SetActive(value: false);
			MINIMAP.SetActive(value: true);
			MINIMAP_ICO.SetActive(value: true);
			FREE_UI.SetActive(value: true);
			СONTROL_OBJ.SetActive(value: true);
			RACE_FALIED_UI.SetActive(value: false);
			RACE_COMPLETE_UI.SetActive(value: false);
			PLAYER.SetActive(value: true);
			RCC_Camera.playerCar.permanentGas = false;
			WRONG_WAY.SetActive(value: false);
			base.gameObject.GetComponent<AudioSource>().clip = FARM_AMBIENT;
			base.gameObject.GetComponent<AudioSource>().Play();
			START_BUTTON.SetActive(value: false);
			Camera.main.GetComponent<ScreenFader>().enabled = true;
			Camera.main.GetComponent<ScreenFader>().RS();
			base.gameObject.GetComponent<GAME_MANAGER>().SET_RANDROM_POSITION();
			Camera.main.GetComponent<ScreenFader>().enabled = true;
			Camera.main.GetComponent<ScreenFader>().RS();
			MUSIC_MANAGER.GetComponent<MUSIC_MANAGER>().PLAY_();
			bool check = true;
			GAME_MANAGER.AV_MISSIONS = 0;
			Resources.UnloadUnusedAssets();
			GC.Collect();
		}
	}

	public void CLOSE_FALIED()
	{
		GAME_MANAGER.TRAFFIC_CURRENT = 0;
		GAME_MANAGER.AV_MISSIONS = 0;
		if (!RACE_FALIED_UI.activeInHierarchy & RACE_COMPLETE_UI.activeInHierarchy)
		{
			MENU_MANAGER.APPODEAL_ADS_TIMER = 50f;
		}
		StartCoroutine(ADS());
	}
}
