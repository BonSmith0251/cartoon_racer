using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GAME_MANAGER : MonoBehaviour
{
	public GameObject MISSION_UI;

	public Text AV_MISSIONS_TXT;

	public GameObject DRIFT_REC_UI;

	public GameObject AIR_REC_UI;

	public GameObject DESTROY_REC_UI;

	public Text DRIFT_REC_TXT;

	public Text AIR_REC_TXT;

	public Text DESTROY_REC_TXT;

	private int DRIFT_REC;

	private int AIR_REC;

	private int DESTROY_REC;

	public static bool RND_POS;

	public GameObject TUTORIAL_1;

	public GameObject TUTORIAL_2;

	public GameObject TUTORIAL_3;

	public GameObject TUTORIAL_4;

	public GameObject TUTORIAL_5;

	public GameObject TUTORIAL_6;

	public GameObject ROAD_CLOSED_ui;

	public GameObject ROAD_OPEN_ui;

	public GameObject ROAD_CLOSED_ui_RUS;

	public GameObject ROAD_OPEN_ui_RUS;

	public Vector3[] START_POSITION_FARM;

	public Vector3[] START_POSITION_CITY;

	private int ROAD_INFO;

	private int ADD_COINS;

	public static int NITRO_VOLUME;

	private int MORE_XP;

	public static int MORE_BENZIN;

	private int MORE_COIN;

	public static int MORE_GEAR;

	private int MORE_WATER;

	private int MORE_SEED;

	public static bool CHECK_COIN;

	public static bool CHECK_SEED;

	private bool CHECK_DRIFT;

	private bool CHECK_AIR;

	private bool CHECK_DESTROY;

	public bool DEVELOPEMENT_MODE;

	public static bool IN_RAIN;

	public GameObject COMPLETE_1_MISSION;

	public GameObject COMPLETE_2_MISSION;

	public GameObject COMPLETE_3_MISSION;

	public Material ROAD;

	public Shader MOBILE_SHADER;

	public Shader RAIN_SHADER;

	public Cubemap CUBEMAP;

	public GameObject RAIN_FX;

	public static float PL_X;

	public static float PL_Y;

	public static float PL_Z;

	public static float PL_ROT;

	public static int NEED_INDEX;

	public static bool RACE_TYPE;

	public static bool SHOW_WORD_TODAY;

	public static int SKIDMARK;

	public static int VIBRATE;

	public GameObject HOUSE_BUY_UI;

	public Button HOUSE_BUY_BUTTON;

	public Text HOUSE_BUY_COST;

	public Text HOUSE_BUY_PERCENT;

	public Text HOUSE_BUY_NAME;

	public AudioClip AWARD_SND;

	public GameObject HOUSE_AWARD_UI;

	public Text HOUSE_AWARD_COST;

	public GameObject HOUSE_AWARD_AVAIBLE;

	public GameObject HOUSE_AWARD_NOT_AVAIBLE;

	public GameObject CURRENT_GEAR_UI;

	public Text CUR_GEAR_TXT;

	public GameObject DAILY_COMPLETE;

	public Text DAILY_COMPLETE_AWARD;

	public GameObject DPART_COMPLETE;

	public GameObject DAILY_MISSIONS;

	public Image DM_1_IMG;

	public Image DM_1_IMG_FILL;

	public Text DM_1_TXT;

	public GameObject DM_1_CMP;

	public Image DM_2_IMG;

	public Image DM_2_IMG_FILL;

	public Text DM_2_TXT;

	public GameObject DM_2_CMP;

	public Image DM_3_IMG;

	public Image DM_3_IMG_FILL;

	public Text DM_3_TXT;

	public GameObject DM_3_CMP;

	public Text DM_AWARD;

	public GameObject RACE3D_POINTS_FARM;

	public GameObject RACE3D_POINTS_CITY;

	public CameraFilterPack_Blur_Radial_Fast BLUR_;

	public Material SKY_DAY;

	public GameObject DRIFT_COMPLETE_UI;

	public GameObject DRIFT_UI;

	public Image DRIFT_IMG_LV;

	public Text DRIFT_MULT;

	public Text DRIFT_AWARD;

	public GameObject DESTROY_COMPLETE_UI;

	public GameObject DESTROY_UI;

	public Image DESTROY_IMG_LV;

	public Text DESTROY_MULT;

	public Text DESTROY_AWARD;

	public GameObject AIR_COMPLETE_UI;

	public GameObject AIR_UI;

	public Image AIR_IMG_LV;

	public Text AIR_MULT;

	public Text AIR_AWARD;

	public GameObject HUD_ICON_FARM;

	public GameObject HUD_ICON_CITY;

	public GameObject COINS_MANAGER_FARM;

	public GameObject COINS_MANAGER_CITY;

	public GameObject TERRAIN_FARM;

	public GameObject TERRAIN_CITY;

	public GameObject GEAR_OBJ;

	public GameObject XP_OBJ;

	public GameObject XP_OBJ2;

	public GameObject FIND_WORD_UI;

	public GameObject LETTER_OBJ;

	public GameObject WORD_OF_DAY_UI;

	public GameObject PAUSE_CANVAS;

	public GameObject PAUSE_MAIN;

	public GameObject PAUSE_EXIT;

	public GameObject PAUSE_RESTART;

	public GameObject OPTIONS_;

	public GameObject MAIN_;

	public GameObject CANVAS_;

	public GameObject CANVAS_2;

	public GameObject FUEL_END_UI;

	public GameObject[] PLAYER_PREFAB;

	public GameObject[] LAGSFREE_OBJECTS;

	public GameObject RCC_CAMERA;

	public GameObject CAM_PARTICLES;

	public GameObject POINT_CAM_FX;

	public GameObject CAM_FX;

	public GameObject CAM_FX2;

	public GameObject WATER_END_UI;

	public GameObject NEW_LEVEL_XP_UI;

	public GameObject XP_UI;

	public GameObject RACE_MANGER_;

	public GameObject VOICE_OBJ;

	public GameObject RADIO_UI;

	public Button FUEL_END_BUTTON;

	public Button FUEL_END_BUTTON_ADS;

	public Button WATER_END_BUTTON_ADS;

	public Button WATER_END_BUTTON;

	public Text NEW_LEVEL_XP_LEVEL;

	public Text NEW_LEVEL_XP_AWARD;

	public Text FIND_WORD_WORD_TEXT;

	public Text FIND_WORD_MONEY_TEXT;

	public Text CURRENT_XP_TXT;

	public Text WORD_TEXT;

	public Image CURRENT_XP_IMG;

	public Image CONTROL;

	public Image FUEL_IMG;

	public Slider MAIN_VOLUME_SLIDER;

	public Slider MUSIC_VOLUME_SLDIER;

	public Slider DISPLAY_RES_SLIDER;

	public AudioClip FUEL_SND;

	public AudioClip UI_CLICK;

	public AudioClip UI_CLICK2;

	public AudioClip[] VOICE_FUEL;

	public AudioClip[] VOICE_EVENT;

	private float cam_fx_alpha;

	private float cam_fx_alpha2;

	private float blur_int;

	private float sky_rotate;

	private bool DISP_CHANGE;

	public static int PLAYER_SEED;

	public static int PLAYER_MONEY;

	public static int PLAYER_LEVEL;

	public static float PLAYER_LEVEL_PROGRESS;

	public static float PLAYER_FUEL;

	public static float PLAYER_NITRO_CONSUM;

	public static float PLAYER_MAXIMUM_SPEED;

	public static float PLAYER_CONTROL_SUSPENSION;

	public static float PLAYER_MAXIMUM_NITRO;

	public static float MUSIC_VOLUME;

	public static float RADIO_VOLUME;

	public static float MAIN_VOLUME;

	public static float DISPLAY_RESOLUTION;

	public static bool TAXI_DRIVER;

	public static int TAXI_DRIVER_LEVEL;

	public static float TAXI_DRIVER_PROGRESS;

	public static bool MEDIC_DRIVER;

	public static int MEDIC_DRIVER_LEVEL;

	public static float MEDIC_DRIVER_PROGRESS;

	public static bool COP_DRIVER;

	public static int COP_DRIVER_LEVEL;

	public static float COP_DRIVER_PROGRESS;

	public static int IN_RACE_POINT;

	public static bool IN_RACE;

	public static bool SHOW_XP;

	public static bool IN_HOUSE_POINT;

	public static bool SHOW_WORD;

	public static int FIND_LETTER;

	public static bool CHECK_LETTER;

	public static int TRAFFIC_CURRENT;

	public static int TRAFFIC_MAXIMUM;

	public static int HIT_SND;

	public static bool IN_WATER;

	public static bool IN_DEEP_WATER;

	public static bool CAR_WATER_;

	public static bool IN_AIR;

	public static bool IN_DRIFT;

	public static bool FUEL_DESTROY;

	public static bool SEED_DESTROY;

	public static bool MONEY_DESTROY;

	public static bool AFTER_RACE;

	public static bool NEW_LVL_XP;

	public static int REG_ID;

	public static bool PLAYER_DESTROY_;

	private float PLAYER_DESTROY_X;

	private float PLAYER_DESTROY_TIMER;

	private float PLAYER_DRIFT_TIMER;

	private float PLAYER_AIR_X;

	private float PLAYER_AIR_TIMER;

	private float PLAYER_DRIFT_X;

	public static GameObject FRUIT3_FX;

	public static int SCREEN_FRUIT_FX;

	public static GameObject FRUIT1_FX;

	public static GameObject FRUIT2_FX;

	public static GameObject SEED_FX_;

	public static GameObject SEED_OBJ_;

	public static GameObject PICKUP_OBJ_;

	public static GameObject PICKUP_OBJ2_;

	public static GameObject PICKUP_OBJ3_;

	public static GameObject PICKUP_OBJ4_;

	public static GameObject PICKUP_OBJ5_;

	public static GameObject HYDRANT_FX_;

	private float fuel_level_timer;

	private float water_level;

	private float AUDIOLISTENER_volume;

	public AudioClip WATER_SND;

	public AudioClip LOW_FUEL;

	public AudioClip SPLAT_1;

	public AudioClip SPLAT_2;

	public AudioClip[] FENCE_;

	public AudioClip[] TRASH_;

	public AudioClip[] LIGHT_;

	public AudioClip[] STRAW_;

	public AudioClip[] BARREL_;

	public AudioClip[] BOX_;

	public AudioClip[] PICKUP_SND;

	public AudioClip METAL_1;

	public AudioClip HYDRANT_SND;

	private float LAGFREE_timer;

	public static bool GET_GEAR;

	public static bool GET_HEL;

	public static bool DTAST_COMPELTE;

	public static bool ZOOM_MAP;

	private int PICKUP_INT;

	private int HIT_RND;

	private int SPLAT_RND;

	public static float DEVIL_TIMER;

	public static bool START_RACE_FROM_MENU;

	public GameObject FRUIT1_FX_;

	public GameObject FRUIT2_FX_;

	public GameObject FRUIT3_FX_;

	public GameObject FRUIT_SCR_FX;

	public GameObject SEED_FX;

	public GameObject SEED_OBJ;

	public GameObject PICKUP_OBJ;

	public GameObject PICKUP_OBJ2;

	public GameObject PICKUP_OBJ3;

	public GameObject PICKUP_OBJ4;

	public GameObject PICKUP_OBJ5;

	public GameObject HYDRANT_FX;

	public GameObject WATER_SCREEN;

	public GameObject LOW_FUEL_OBj;

	public GameObject TAXI_JOB_;

	public GameObject MED_JOB_;

	public GameObject COP_JOB_;

	private GameObject PLAYER_;

	private int SCR_X;

	private int SCR_Y;

	public Text MONEY_TEXT;

	public Image MONEY_IMG;

	public Image NOS_IMG;

	public Text SEED_TEXT;

	public Image SEED_IMG;

	private float NOS_alpha;

	public GameObject NOS_FULL_IMG;

	private float NEW_XP;

	private float OLD_PROGRESS;

	private int AWARD_NEW_LEVEL;

	private int AWARD_FIND_WORD;

	private float xp_timer;

	private int SELECTED_CAR;

	private float G;

	private string WORD;

	private string WORD_;

	public string[] LETTER_;

	private bool fv;

	private float fb;

	private float fc;

	private float PLAYER_DESTROYER_LEVEL;

	private int PLAYER_DESTROYER_LEVEL_X = 1;

	private float PLAYER_AIR_LEVEL;

	private int PLAYER_AIR_LEVEL_X = 5;

	private float PLAYER_DRIFT_LEVEL;

	private int PLAYER_DRIFT_LEVEL_X = 1;

	private int POWER_LEVEL;

	private int SPEED_LEVEL;

	private int CONTROL_LEVEL;

	private int COIN_MULTIPLAYER;

	private float RAIN_TIME;

	private float RAIN_PAUSE;

	private float R_;

	private float G_;

	private float B_;

	private float A_;

	private float A1_;

	private float A2_;

	private int DD;

	private float RAIN_COLOR;

	public static bool RESTORE_RACE;

	public static bool IN_MISSION;

	public static bool IN_MISSION_POINT;

	private int RAIN;

	public static int AV_MISSIONS;

	public void SHOW_3D_ICONS()
	{
		if (MENU_MANAGER.LOADING_LEVEL == 0)
		{
			RACE3D_POINTS_FARM.SetActive(value: true);
			RACE3D_POINTS_CITY.SetActive(value: false);
		}
		else
		{
			RACE3D_POINTS_FARM.SetActive(value: false);
			RACE3D_POINTS_CITY.SetActive(value: true);
		}
	}

	public void HIDE_3D_ICONS()
	{
		RACE3D_POINTS_FARM.SetActive(value: false);
		RACE3D_POINTS_CITY.SetActive(value: false);
	}

	private void Start()
	{
		TRAFFIC_CURRENT = 0;
		IN_MISSION = false;
		IN_MISSION_POINT = false;
		CAR_WATER_ = false;
		TRAFFIC_MANAGER.COMPLETE = false;
		TRAFFIC_MANAGER.FALIED = false;
		NEW_LVL_XP = false;
		RACE_MANAGER.START_RACE = false;
		IN_RACE_POINT = 0;
		TAXI_MANAGER.PASSENGER_COMPLETE = false;
		MEDIC_MANAGER.PASSENGER_COMPLETE = false;
		TAXI_MANAGER.PASSENGER_FAIL = false;
		MEDIC_MANAGER.PASSENGER_FAIL = false;
		COP_MANAGER.PASSENGER_FAIL = false;
		COP_MANAGER.PASSENGER_COMPLETE = false;
		RACE_MANAGER.NEED_QUIT = false;
		TRAFFIC_MANAGER.NEED_QUIT = false;
		TRAFFIC_MANAGER.TRAFFIC_MODE = false;
		IN_RACE = false;
		TRAFFIC_MANAGER.FALIED = false;
		RACE_MANAGER.START_RACE = false;
		IN_RACE_POINT = 0;
		CHECK_COIN = false;
		CHECK_SEED = false;
		GameObject gameObject = GameObject.FindGameObjectWithTag("Player");
		if (gameObject == null)
		{
			CREATE_PLAYER();
		}
		IN_RAIN = false;
		ROAD.shader = MOBILE_SHADER;
		PLAYER_.GetComponent<Rigidbody>().angularDrag = 0.1f;
		RAIN_PAUSE = UnityEngine.Random.Range(200, 400);
		RAIN_TIME = 0f;
		DISPLAY_MISSION_TXT();
		if (VIBRATE == 1)
		{
			IntenseVibration.Instance.Vibrate(1L);
		}
	}

	public void CHECK_MISSIONS_()
	{
		AV_MISSIONS++;
		AV_MISSIONS_TXT.text = string.Empty + AV_MISSIONS;
		if (AV_MISSIONS > 9)
		{
			AV_MISSIONS_TXT.text = "+";
		}
	}

	public void CHECK_MISSIONS()
	{
		AV_MISSIONS--;
		AV_MISSIONS_TXT.text = string.Empty + AV_MISSIONS;
		if (AV_MISSIONS > 9)
		{
			AV_MISSIONS_TXT.text = string.Empty + AV_MISSIONS;
		}
	}

	private void Awake()
	{
		AV_MISSIONS = 0;
		if (!DEVELOPEMENT_MODE)
		{
			if (MENU_MANAGER.LOADING_LEVEL == 0)
			{
				GameObject gameObject = UnityEngine.Object.Instantiate(TERRAIN_FARM, TERRAIN_FARM.transform.position, TERRAIN_FARM.transform.rotation);
				if (!START_RACE_FROM_MENU)
				{
					SceneManager.LoadSceneAsync("FARM_STATIC", LoadSceneMode.Additive);
					DRIFT_REC = ES2.Load<int>("DRIFT_REC");
					AIR_REC = ES2.Load<int>("AIR_REC");
					DESTROY_REC = ES2.Load<int>("DESTROY_REC");
				}
				HUD_ICON_FARM.SetActive(value: true);
				HUD_ICON_CITY.SetActive(value: false);
				RACE3D_POINTS_FARM.SetActive(value: true);
				RACE3D_POINTS_CITY.SetActive(value: false);
			}
			if (MENU_MANAGER.LOADING_LEVEL == 1)
			{
				GameObject gameObject2 = UnityEngine.Object.Instantiate(TERRAIN_CITY, TERRAIN_CITY.transform.position, TERRAIN_CITY.transform.rotation);
				if (!START_RACE_FROM_MENU)
				{
					SceneManager.LoadSceneAsync("CITY_STATIC", LoadSceneMode.Additive);
				}
				HUD_ICON_FARM.SetActive(value: false);
				HUD_ICON_CITY.SetActive(value: true);
				RACE3D_POINTS_FARM.SetActive(value: false);
				RACE3D_POINTS_CITY.SetActive(value: true);
			}
		}
		if (ES2.Load<int>("SELECT_CHARACTER") == 1)
		{
			NITRO_VOLUME = 1;
		}
		else
		{
			NITRO_VOLUME = 0;
		}
		if (ES2.Load<int>("SELECT_CHARACTER") == 10)
		{
			NITRO_VOLUME = 2;
		}
		else
		{
			NITRO_VOLUME = 0;
		}
		if (ES2.Load<int>("SELECT_CHARACTER") == 3)
		{
			MORE_XP = 1;
		}
		else
		{
			MORE_XP = 0;
		}
		if (ES2.Load<int>("SELECT_CHARACTER") == 13)
		{
			MORE_XP = 2;
		}
		else
		{
			MORE_XP = 0;
		}
		if (ES2.Load<int>("SELECT_CHARACTER") == 4)
		{
			MORE_BENZIN = 95;
		}
		else
		{
			MORE_BENZIN = 60;
		}
		if (ES2.Load<int>("SELECT_CHARACTER") == 14)
		{
			MORE_BENZIN = 115;
		}
		else
		{
			MORE_BENZIN = 60;
		}
		if (ES2.Load<int>("SELECT_CHARACTER") == 7)
		{
			MORE_COIN = 1;
		}
		else
		{
			MORE_COIN = 0;
		}
		if (ES2.Load<int>("SELECT_CHARACTER") == 11)
		{
			MORE_GEAR = 1;
		}
		else
		{
			MORE_GEAR = 0;
		}
		if (ES2.Load<int>("SELECT_CHARACTER") == 9)
		{
			MORE_WATER = 1;
		}
		else
		{
			MORE_WATER = 0;
		}
		if (ES2.Load<int>("SELECT_CHARACTER") == 12)
		{
			MORE_SEED = 1;
		}
		else
		{
			MORE_SEED = 0;
		}
		CAR_WATER_ = false;
		IN_WATER = false;
		IN_DEEP_WATER = false;
		IN_AIR = false;
		IN_DRIFT = false;
		FUEL_DESTROY = false;
		SEED_DESTROY = false;
		MONEY_DESTROY = false;
		AFTER_RACE = false;
		NEW_LVL_XP = false;
		ZOOM_MAP = false;
		REG_ID = 0;
		IN_HOUSE_POINT = false;
		for (int i = 0; i < LAGSFREE_OBJECTS.Length; i++)
		{
			LAGSFREE_OBJECTS[i].SetActive(value: true);
		}
		VIBRATE = ES2.Load<int>("VIBRO");
		RAIN = ES2.Load<int>("RAIN");
		SELECTED_CAR = ES2.Load<int>("SELECT_CAR");
		GameObject obj = GameObject.FindGameObjectWithTag("Player");
		UnityEngine.Object.Destroy(obj);
		TAXI_JOB_.SetActive(value: false);
		MED_JOB_.SetActive(value: false);
		COP_JOB_.SetActive(value: false);
		if (SELECTED_CAR == 0)
		{
			TAXI_JOB_.SetActive(value: true);
		}
		if (SELECTED_CAR == 2)
		{
			MED_JOB_.SetActive(value: true);
		}
		if (SELECTED_CAR == 4)
		{
			COP_JOB_.SetActive(value: true);
		}
		AudioListener.volume = 0f;
		DISPLAY_RESOLUTION = ES2.Load<float>("RESOLUTION");
		SCR_X = ES2.Load<int>("DISPLAY_X");
		SCR_Y = ES2.Load<int>("DISPLAY_Y");
		MUSIC_VOLUME = ES2.Load<float>("MUSIC_VOLUME");
		RADIO_VOLUME = ES2.Load<float>("RADIO_VOLUME");
		MAIN_VOLUME = ES2.Load<float>("MAIN_VOLUME");
		PLAYER_SEED = ES2.Load<int>("PLAYER_SEED");
		PLAYER_MONEY = ES2.Load<int>("PLAYER_MONEY");
		PLAYER_LEVEL = ES2.Load<int>("PLAYER_LEVEL");
		SKIDMARK = ES2.Load<int>("SKIDMARK");
		PLAYER_LEVEL_PROGRESS = ES2.Load<float>("PLAYER_LEVEL_PROGRESS");
		if (ES2.Load<int>("TRAFFIC") == 0)
		{
			TRAFFIC_MAXIMUM = 4;
		}
		if (ES2.Load<int>("TRAFFIC") == 1)
		{
			TRAFFIC_MAXIMUM = 7;
		}
		if (ES2.Load<int>("TRAFFIC") == 2)
		{
			TRAFFIC_MAXIMUM = 14;
		}
		TRAFFIC_CURRENT = 0;
		PLAYER_FUEL = 1f;
		IN_RACE = false;
		PICKUP_OBJ5_ = PICKUP_OBJ5;
		PICKUP_OBJ4_ = PICKUP_OBJ4;
		PICKUP_OBJ3_ = PICKUP_OBJ3;
		PICKUP_OBJ2_ = PICKUP_OBJ2;
		PICKUP_OBJ_ = PICKUP_OBJ;
		SEED_OBJ_ = SEED_OBJ;
		SEED_FX_ = SEED_FX;
		FRUIT1_FX = FRUIT1_FX_;
		FRUIT2_FX = FRUIT2_FX_;
		FRUIT3_FX = FRUIT3_FX_;
		HYDRANT_FX_ = HYDRANT_FX;
		NEW_LVL_XP = false;
		TAXI_MANAGER.PASSENGER_PICKUP = false;
		TAXI_MANAGER.PASSENGER_COMPLETE = false;
		MEDIC_MANAGER.PASSENGER_PICKUP = false;
		MEDIC_MANAGER.PASSENGER_COMPLETE = false;
		DTAST_COMPELTE = false;
		ZOOM_MAP = false;
		IN_WATER = false;
		IN_DEEP_WATER = false;
		if (ES2.Load<int>("BLOOMFX") == 1)
		{
			Camera.main.GetComponent<FxPro>().enabled = true;
		}
		if (ES2.Load<int>("FILTER") == 0)
		{
			QualitySettings.anisotropicFiltering = AnisotropicFiltering.Disable;
		}
		else
		{
			QualitySettings.anisotropicFiltering = AnisotropicFiltering.Enable;
		}
		if ((PLAYER_LEVEL > 9) & (PLAYER_LEVEL < 20))
		{
			COIN_MULTIPLAYER = 2;
		}
		if ((PLAYER_LEVEL > 19) & (PLAYER_LEVEL < 30))
		{
			COIN_MULTIPLAYER = 3;
		}
		if ((PLAYER_LEVEL > 29) & (PLAYER_LEVEL < 40))
		{
			COIN_MULTIPLAYER = 4;
		}
		if ((PLAYER_LEVEL > 39) & (PLAYER_LEVEL < 50))
		{
			COIN_MULTIPLAYER = 5;
		}
		if ((PLAYER_LEVEL > 49) & (PLAYER_LEVEL < 60))
		{
			COIN_MULTIPLAYER = 6;
		}
		if ((PLAYER_LEVEL > 59) & (PLAYER_LEVEL < 71))
		{
			COIN_MULTIPLAYER = 7;
		}
		if (!TRAFFIC_MANAGER.TRAFFIC_MODE)
		{
			if (ES2.Load<int>("VIEW_DISTANCE") == 0)
			{
				RenderSettings.fog = true;
				Camera.main.farClipPlane = 160f;
				RenderSettings.fogStartDistance = 145f;
				RenderSettings.fogEndDistance = 170f;
			}
			if (ES2.Load<int>("VIEW_DISTANCE") == 1)
			{
				RenderSettings.fog = true;
				Camera.main.farClipPlane = 170f;
				RenderSettings.fogStartDistance = 155f;
				RenderSettings.fogEndDistance = 180f;
			}
			if (ES2.Load<int>("VIEW_DISTANCE") == 2)
			{
				RenderSettings.fog = true;
				Camera.main.farClipPlane = 190f;
				RenderSettings.fogStartDistance = 165f;
				RenderSettings.fogEndDistance = 200f;
			}
			if (ES2.Load<int>("VIEW_DISTANCE") == 3)
			{
				RenderSettings.fog = true;
				Camera.main.farClipPlane = 230f;
				RenderSettings.fogStartDistance = 215f;
				RenderSettings.fogEndDistance = 240f;
			}
		}
		if (Terrain.activeTerrain != null)
		{
			if (ES2.Load<int>("TERRAIN") == 0)
			{
				Terrain.activeTerrain.heightmapPixelError = 100f;
				Terrain.activeTerrain.basemapDistance = 270f;
			}
			if (ES2.Load<int>("TERRAIN") == 1)
			{
				Terrain.activeTerrain.heightmapPixelError = 60f;
				Terrain.activeTerrain.basemapDistance = 270f;
			}
			if (ES2.Load<int>("TERRAIN") == 2)
			{
				Terrain.activeTerrain.heightmapPixelError = 25f;
				Terrain.activeTerrain.basemapDistance = 270f;
			}
			if (ES2.Load<int>("TERRAIN") == 3)
			{
				Terrain.activeTerrain.heightmapPixelError = 10f;
				Terrain.activeTerrain.basemapDistance = 270f;
			}
		}
		if (!DEVELOPEMENT_MODE & !START_RACE_FROM_MENU & !RESTORE_RACE)
		{
			if (MENU_MANAGER.LOADING_LEVEL == 0)
			{
				GameObject gameObject3 = UnityEngine.Object.Instantiate(COINS_MANAGER_FARM, COINS_MANAGER_FARM.transform.position, COINS_MANAGER_FARM.transform.rotation);
			}
			else
			{
				GameObject gameObject4 = UnityEngine.Object.Instantiate(COINS_MANAGER_CITY, COINS_MANAGER_CITY.transform.position, COINS_MANAGER_CITY.transform.rotation);
			}
			for (int j = 0; j < UnityEngine.Random.Range(15, 30); j++)
			{
				GameObject gameObject5 = UnityEngine.Object.Instantiate(GEAR_OBJ, new Vector3(UnityEngine.Random.Range(50, 900), 80f, UnityEngine.Random.Range(80, 950)), base.transform.rotation);
			}
			for (int k = 0; k < UnityEngine.Random.Range(2, 3); k++)
			{
				GameObject gameObject6 = UnityEngine.Object.Instantiate(XP_OBJ, new Vector3(UnityEngine.Random.Range(50, 900), 80f, UnityEngine.Random.Range(80, 950)), base.transform.rotation);
			}
			for (int l = 0; l < UnityEngine.Random.Range(2, 3); l++)
			{
				GameObject gameObject7 = UnityEngine.Object.Instantiate(XP_OBJ2, new Vector3(UnityEngine.Random.Range(50, 900), 80f, UnityEngine.Random.Range(80, 950)), base.transform.rotation);
			}
			ROAD_INFO = ES2.Load<int>("ROAD_INFO");
			if ((PLAYER_LEVEL < 10) & (ROAD_INFO == 0))
			{
				StartCoroutine(ROAD_CLOSED_());
				ES2.Save(1, "ROAD_INFO");
			}
			if ((PLAYER_LEVEL >= 10) & (ROAD_INFO == 1))
			{
				StartCoroutine(ROAD_OPEN_());
				ES2.Save(0, "ROAD_INFO");
			}
			LETTER();
			if (ES2.Load<int>("TUTORIAL_12") == 0 && (!START_RACE_FROM_MENU & !IN_RACE))
			{
				StartCoroutine(SHOW_TUTORIAL_1());
			}
			if (((ES2.Load<int>("TUTORIAL_14") == 0) & (ES2.Load<int>("TUTORIAL_12") == 1)) && (!START_RACE_FROM_MENU & !IN_RACE))
			{
				StartCoroutine(SHOW_TUTORIAL_3());
			}
			if (((ES2.Load<int>("TUTORIAL_15") == 0) & (ES2.Load<int>("TUTORIAL_14") == 1)) && (!START_RACE_FROM_MENU & !IN_RACE))
			{
				StartCoroutine(SHOW_TUTORIAL_4());
			}
			if (((ES2.Load<int>("TUTORIAL_16") == 0) & (ES2.Load<int>("TUTORIAL_15") == 1)) && (!START_RACE_FROM_MENU & !IN_RACE))
			{
				StartCoroutine(SHOW_TUTORIAL_5());
			}
			if (((ES2.Load<int>("TUTORIAL_21") == 0) & (ES2.Load<int>("TUTORIAL_16") == 1)) && (!START_RACE_FROM_MENU & !IN_RACE))
			{
				StartCoroutine(SHOW_TUTORIAL_6());
			}
		}
		Application.targetFrameRate = 60;
		Time.timeScale = 1f;
		RCC_Settings.Instance.controllerType = RCC_Settings.ControllerType.Keyboard;
		if (START_RACE_FROM_MENU)
		{
			Camera.main.GetComponent<CameraFilterPack_Blur_Blurry>().enabled = true;
		}
	}

	public void CLOSE_MISSION()
	{
		AudioSource.PlayClipAtPoint(UI_CLICK, Camera.main.transform.position);
		MISSION_UI.SetActive(value: false);
		IN_MISSION_POINT = false;
	}

	public void ACCEPT_MISSION()
	{
		AudioSource.PlayClipAtPoint(UI_CLICK, Camera.main.transform.position);
		MISSION_UI.SetActive(value: false);
		IN_MISSION_POINT = false;
		IN_MISSION = true;
		base.gameObject.GetComponent<MISSION_MANAGER>().START_MISSION();
	}

	private void Update()
	{
		if (MENU_MANAGER.APPODEAL_ADS_TIMER > 0f)
		{
			MENU_MANAGER.APPODEAL_ADS_TIMER -= Time.deltaTime / 2f;
			if (MENU_MANAGER.APPODEAL_ADS_TIMER < 0.1f)
			{
				MENU_MANAGER.APPODEAL_ADS_TIMER = 0f;
			}
		}
		if (IN_MISSION_POINT & !MISSION_UI.activeInHierarchy & !IN_MISSION)
		{
			MISSION_UI.SetActive(value: true);
		}
		if (CHECK_COIN)
		{
			ES2.Save(ES2.Load<int>("ALL_MONEY") + ADD_COINS, "ALL_MONEY");
			ADD_COINS = 0;
			if (ES2.Load<string>("DAILY_MISSION_1_TYPE") == "COLLECT_COINS" && ES2.Load<int>("DAILY_MISSION_1") < ES2.Load<int>("DAILY_MISSION_1_NEED"))
			{
				ES2.Save(ES2.Load<int>("DAILY_MISSION_1") + 1, "DAILY_MISSION_1");
				if (ES2.Load<int>("DAILY_MISSION_1") == ES2.Load<int>("DAILY_MISSION_1_NEED"))
				{
					DTAST_COMPELTE = true;
				}
			}
			CHECK_COIN = false;
		}
		if (CHECK_SEED)
		{
			if (ES2.Load<string>("DAILY_MISSION_1_TYPE") == "COLLECT_SEEDS" && ES2.Load<int>("DAILY_MISSION_1") < ES2.Load<int>("DAILY_MISSION_1_NEED"))
			{
				ES2.Save(ES2.Load<int>("DAILY_MISSION_1") + 1, "DAILY_MISSION_1");
				if (ES2.Load<int>("DAILY_MISSION_1") == ES2.Load<int>("DAILY_MISSION_1_NEED"))
				{
					DTAST_COMPELTE = true;
				}
			}
			CHECK_SEED = false;
		}
		if (CHECK_DRIFT)
		{
			if (ES2.Load<string>("DAILY_MISSION_3_TYPE") == "COMPLETE_X_DRIFT" && ES2.Load<int>("DAILY_MISSION_3") < ES2.Load<int>("DAILY_MISSION_3_NEED"))
			{
				ES2.Save(ES2.Load<int>("DAILY_MISSION_3") + 1, "DAILY_MISSION_3");
				if (ES2.Load<int>("DAILY_MISSION_3") == ES2.Load<int>("DAILY_MISSION_3_NEED"))
				{
					DTAST_COMPELTE = true;
				}
			}
			CHECK_DRIFT = false;
		}
		if (CHECK_AIR)
		{
			if (ES2.Load<string>("DAILY_MISSION_3_TYPE") == "COMPLETE_X_AIR" && ES2.Load<int>("DAILY_MISSION_3") < ES2.Load<int>("DAILY_MISSION_3_NEED"))
			{
				ES2.Save(ES2.Load<int>("DAILY_MISSION_3") + 1, "DAILY_MISSION_3");
				if (ES2.Load<int>("DAILY_MISSION_3") == ES2.Load<int>("DAILY_MISSION_3_NEED"))
				{
					DTAST_COMPELTE = true;
				}
			}
			CHECK_AIR = false;
		}
		if (CHECK_DESTROY)
		{
			if (ES2.Load<string>("DAILY_MISSION_3_TYPE") == "COMPLETE_X_DESTROY" && ES2.Load<int>("DAILY_MISSION_3") < ES2.Load<int>("DAILY_MISSION_3_NEED"))
			{
				ES2.Save(ES2.Load<int>("DAILY_MISSION_3") + 1, "DAILY_MISSION_3");
				if (ES2.Load<int>("DAILY_MISSION_3") == ES2.Load<int>("DAILY_MISSION_3_NEED"))
				{
					DTAST_COMPELTE = true;
				}
			}
			CHECK_DESTROY = false;
		}
		if (Input.GetKeyUp(KeyCode.Escape) & !RACE_MANAGER.START_RACE)
		{
			PAUSE();
		}
		if (DEVIL_TIMER > 0f)
		{
			DEVIL_TIMER -= Time.deltaTime * 4f;
			if (Camera.main.transform.rotation.eulerAngles.z < 180f)
			{
				Camera.main.transform.Rotate(0f, 0f, 5f, Space.Self);
			}
			if (DEVIL_TIMER < 0.01f)
			{
				DEVIL_TIMER = 0f;
				Camera.main.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
			}
		}
		if (IN_HOUSE_POINT)
		{
			Camera.main.GetComponent<ScreenFader>().enabled = false;
			Camera.main.GetComponent<CameraFilterPack_Blur_Blurry>().enabled = true;
			if (!HOUSE_TRIGGER.HOUSE_BUYED)
			{
				HOUSE_BUY_UI.SetActive(value: true);
				HOUSE_BUY_NAME.text = HOUSE_TRIGGER.NAME_;
				HOUSE_BUY_COST.text = string.Empty + HOUSE_TRIGGER.COST_;
				HOUSE_BUY_PERCENT.text = string.Empty + HOUSE_TRIGGER.COST_ / 20;
				if (HOUSE_TRIGGER.COST_ < PLAYER_MONEY)
				{
					HOUSE_BUY_BUTTON.interactable = true;
				}
				else
				{
					HOUSE_BUY_BUTTON.interactable = false;
				}
			}
			else if (HOUSE_TRIGGER.GET_AWARD)
			{
				HOUSE_AWARD_UI.SetActive(value: true);
				HOUSE_AWARD_AVAIBLE.SetActive(value: true);
				HOUSE_AWARD_NOT_AVAIBLE.SetActive(value: false);
				HOUSE_AWARD_COST.text = "+ " + HOUSE_TRIGGER.COST_ / 20;
			}
			else
			{
				HOUSE_AWARD_UI.SetActive(value: true);
				HOUSE_AWARD_AVAIBLE.SetActive(value: false);
				HOUSE_AWARD_NOT_AVAIBLE.SetActive(value: true);
			}
			COP_MANAGER.PASSENGER_COMPLETE = true;
			IN_HOUSE_POINT = false;
		}
		if (DTAST_COMPELTE)
		{
			StartCoroutine(SHOW_TASK_COMPLETE());
			DTAST_COMPELTE = false;
		}
		if (CHECK_LETTER)
		{
			SHOW_WORD = false;
			ES2.Save(ES2.Load<int>("LETTERS") + 1, "LETTERS");
			WORD_OF_DAY_UI.SetActive(value: true);
			SHOW_WORD_TODAY = false;
			LETTER();
			CHECK_LETTER = false;
		}
		PLAYER_EVENTS();
		PICKUP();
		UI();
		FX();
		if (RND_POS)
		{
			if (MENU_MANAGER.LOADING_LEVEL == 0)
			{
				SET_RANDROM_POSITION();
			}
			else
			{
				SET_RANDROM_POSITION2();
			}
			RND_POS = false;
		}
		if (xp_timer > 10f)
		{
			CHECK_XP();
		}
		if (!(xp_timer < 10f))
		{
			return;
		}
		xp_timer += Time.deltaTime;
		if (IN_RACE_POINT != 0 || TRAFFIC_MANAGER.TRAFFIC_MODE || RADIO_UI.activeInHierarchy)
		{
			XP_UI.SetActive(value: false);
			xp_timer = 999f;
			return;
		}
		if (!XP_UI.activeInHierarchy)
		{
			CURRENT_XP_IMG.fillAmount = ES2.Load<float>("PLAYER_LEVEL_PROGRESS");
			if (MENU_MANAGER.LANGUAGE == 1)
			{
				CURRENT_XP_TXT.text = ES2.Load<int>("PLAYER_LEVEL") + " ур";
			}
			else
			{
				CURRENT_XP_TXT.text = ES2.Load<int>("PLAYER_LEVEL") + " lv";
			}
			XP_UI.SetActive(value: true);
			XP_UI.GetComponent<AudioSource>().Stop();
		}
		if (xp_timer > 9f)
		{
			XP_UI.SetActive(value: false);
			xp_timer = 999f;
		}
	}

	public void SHOW_TUT()
	{
		StartCoroutine(SHOW_TUTORIAL_2());
	}

	public void CLOSE_TUT_1()
	{
		AudioSource.PlayClipAtPoint(UI_CLICK, Camera.main.transform.position);
		ES2.Save(1, "TUTORIAL_12");
		TUTORIAL_1.SetActive(value: false);
		TAXI_MANAGER.PASSENGER_FAIL = false;
	}

	public void CLOSE_TUT_2()
	{
		AudioSource.PlayClipAtPoint(UI_CLICK, Camera.main.transform.position);
		ES2.Save(1, "TUTORIAL_13");
		TUTORIAL_2.SetActive(value: false);
		TAXI_MANAGER.PASSENGER_FAIL = false;
	}

	public void CLOSE_TUT_3()
	{
		AudioSource.PlayClipAtPoint(UI_CLICK, Camera.main.transform.position);
		ES2.Save(1, "TUTORIAL_14");
		TUTORIAL_3.SetActive(value: false);
		TAXI_MANAGER.PASSENGER_FAIL = false;
	}

	public void CLOSE_TUT_4()
	{
		AudioSource.PlayClipAtPoint(UI_CLICK, Camera.main.transform.position);
		ES2.Save(1, "TUTORIAL_15");
		TUTORIAL_4.SetActive(value: false);
		TAXI_MANAGER.PASSENGER_FAIL = false;
	}

	public void CLOSE_TUT_5()
	{
		AudioSource.PlayClipAtPoint(UI_CLICK, Camera.main.transform.position);
		ES2.Save(1, "TUTORIAL_16");
		TUTORIAL_5.SetActive(value: false);
		TAXI_MANAGER.PASSENGER_FAIL = false;
	}

	public void CLOSE_TUT_6()
	{
		AudioSource.PlayClipAtPoint(UI_CLICK, Camera.main.transform.position);
		ES2.Save(1, "TUTORIAL_21");
		TUTORIAL_6.SetActive(value: false);
		TAXI_MANAGER.PASSENGER_FAIL = false;
	}

	private IEnumerator SHOW_TUTORIAL_1()
	{
		yield return new WaitForSecondsRealtime(45f);
		if (!TRAFFIC_MANAGER.TRAFFIC_MODE & !IN_RACE)
		{
			TAXI_MANAGER.PASSENGER_FAIL = true;
			TUTORIAL_1.SetActive(value: true);
		}
	}

	private IEnumerator SHOW_TUTORIAL_2()
	{
		yield return new WaitForSecondsRealtime(10f);
		if (!TRAFFIC_MANAGER.TRAFFIC_MODE & !IN_RACE)
		{
			TAXI_MANAGER.PASSENGER_FAIL = true;
			TUTORIAL_2.SetActive(value: true);
		}
	}

	private IEnumerator SHOW_TUTORIAL_3()
	{
		yield return new WaitForSecondsRealtime(45f);
		if (!TRAFFIC_MANAGER.TRAFFIC_MODE & !IN_RACE)
		{
			TAXI_MANAGER.PASSENGER_FAIL = true;
			TUTORIAL_3.SetActive(value: true);
		}
	}

	private IEnumerator SHOW_TUTORIAL_4()
	{
		yield return new WaitForSecondsRealtime(45f);
		if (!TRAFFIC_MANAGER.TRAFFIC_MODE & !IN_RACE)
		{
			TAXI_MANAGER.PASSENGER_FAIL = true;
			TUTORIAL_4.SetActive(value: true);
		}
	}

	private IEnumerator SHOW_TUTORIAL_5()
	{
		yield return new WaitForSecondsRealtime(45f);
		if (!TRAFFIC_MANAGER.TRAFFIC_MODE & !IN_RACE)
		{
			TAXI_MANAGER.PASSENGER_FAIL = true;
			TUTORIAL_5.SetActive(value: true);
		}
	}

	private IEnumerator SHOW_TUTORIAL_6()
	{
		yield return new WaitForSecondsRealtime(45f);
		if (!TRAFFIC_MANAGER.TRAFFIC_MODE & !IN_RACE)
		{
			TAXI_MANAGER.PASSENGER_FAIL = true;
			TUTORIAL_6.SetActive(value: true);
		}
	}

	public void GET_HOUSE_AWARD()
	{
		AudioSource.PlayClipAtPoint(AWARD_SND, Camera.main.transform.position);
		HOUSE_AWARD_UI.SetActive(value: false);
		HOUSE_AWARD_NOT_AVAIBLE.SetActive(value: false);
		HOUSE_AWARD_AVAIBLE.SetActive(value: false);
		COP_MANAGER.PASSENGER_COMPLETE = false;
		Camera.main.GetComponent<CameraFilterPack_Blur_Blurry>().enabled = false;
		PLAYER_MONEY += HOUSE_TRIGGER.COST_ / 20;
		ES2.Save(PLAYER_MONEY, "PLAYER_MONEY");
		ES2.Save(DateTime.Now.Day, "HOUSE_" + HOUSE_TRIGGER.ID_ + "_TIME");
		HOUSE_TRIGGER.CHECK = true;
		if (MENU_MANAGER.APPODEAL_ADS_TIMER == 0f)
		{
			int num = UnityEngine.Random.Range(0, 4);
			MENU_MANAGER.APPODEAL_ADS_TIMER = 40f;
		}
	}

	public void CLOSE_HOUSE_AWARD()
	{
		AudioSource.PlayClipAtPoint(UI_CLICK, Camera.main.transform.position);
		HOUSE_AWARD_UI.SetActive(value: false);
		HOUSE_AWARD_NOT_AVAIBLE.SetActive(value: false);
		HOUSE_AWARD_AVAIBLE.SetActive(value: false);
		COP_MANAGER.PASSENGER_COMPLETE = false;
		Camera.main.GetComponent<CameraFilterPack_Blur_Blurry>().enabled = false;
	}

	public void ACCEPT_HOUSE_BUY()
	{
		AudioSource.PlayClipAtPoint(UI_CLICK, Camera.main.transform.position);
		HOUSE_BUY_UI.SetActive(value: false);
		HOUSE_AWARD_UI.SetActive(value: true);
		HOUSE_AWARD_NOT_AVAIBLE.SetActive(value: true);
		HOUSE_AWARD_AVAIBLE.SetActive(value: false);
		PLAYER_MONEY -= HOUSE_TRIGGER.COST_;
		ES2.Save(PLAYER_MONEY, "PLAYER_MONEY");
		ES2.Save(1, "HOUSE_" + HOUSE_TRIGGER.ID_);
		ES2.Save(DateTime.Now.Day, "HOUSE_" + HOUSE_TRIGGER.ID_ + "_TIME");
	}

	public void CLOSE_HOUSE_BUY()
	{
		AudioSource.PlayClipAtPoint(UI_CLICK, Camera.main.transform.position);
		Camera.main.GetComponent<CameraFilterPack_Blur_Blurry>().enabled = false;
		HOUSE_BUY_UI.SetActive(value: false);
		COP_MANAGER.PASSENGER_COMPLETE = false;
	}

	public void CLOSE_COMPLETE_TASK()
	{
		if (MENU_MANAGER.APPODEAL_ADS_TIMER == 0f)
		{
			MENU_MANAGER.APPODEAL_ADS_TIMER = 40f;
		}
		COP_MANAGER.PASSENGER_COMPLETE = false;
		if (PLAYER_LEVEL == 0)
		{
			PLAYER_MONEY += 50;
		}
		else
		{
			PLAYER_MONEY += PLAYER_LEVEL * 100;
		}
		ES2.Save(PLAYER_MONEY, "PLAYER_MONEY");
		ES2.Save(ES2.Load<int>("DAY_ALL") + 1, "DAY_ALL");
		DAILY_COMPLETE.SetActive(value: false);
	}

	private IEnumerator ROAD_CLOSED_()
	{
		yield return new WaitForSecondsRealtime(13f);
		TAXI_MANAGER.PASSENGER_FAIL = true;
		ROAD_CLOSED_ui.SetActive(value: true);
		if (MENU_MANAGER.LANGUAGE == 1)
		{
			ROAD_CLOSED_ui_RUS.SetActive(value: true);
		}
	}

	private IEnumerator ROAD_OPEN_()
	{
		yield return new WaitForSecondsRealtime(13f);
		TAXI_MANAGER.PASSENGER_FAIL = true;
		ROAD_OPEN_ui.SetActive(value: true);
		if (MENU_MANAGER.LANGUAGE == 1)
		{
			ROAD_OPEN_ui_RUS.SetActive(value: true);
		}
	}

	private IEnumerator SHOW_TASK_COMPLETE()
	{
		DPART_COMPLETE.SetActive(value: true);
		DISPLAY_MISSION_TXT();
		yield return new WaitForSecondsRealtime(3f);
		DPART_COMPLETE.SetActive(value: false);
		if (((ES2.Load<int>("DAILY_MISSION_1") >= ES2.Load<int>("DAILY_MISSION_1_NEED")) & (ES2.Load<int>("DAILY_MISSION_2") >= ES2.Load<int>("DAILY_MISSION_2_NEED")) & (ES2.Load<int>("DAILY_MISSION_3") >= ES2.Load<int>("DAILY_MISSION_3_NEED"))) && ES2.Load<string>("DAILY_MISSION") != "COMPLETE")
		{
			ES2.Save("COMPLETE", "DAILY_MISSION");
			DAILY_COMPLETE.SetActive(value: true);
			COP_MANAGER.PASSENGER_COMPLETE = true;
			if (PLAYER_LEVEL == 0)
			{
				DAILY_COMPLETE_AWARD.text = "+ " + 50;
			}
			else
			{
				DAILY_COMPLETE_AWARD.text = "+ " + PLAYER_LEVEL * 100;
			}
		}
	}

	public void CHECK_DAILY_MISSIONS()
	{
		COMPLETE_1_MISSION.SetActive(value: false);
		COMPLETE_2_MISSION.SetActive(value: false);
		COMPLETE_3_MISSION.SetActive(value: false);
		int num = ES2.Load<int>("DAILY_MISSION_DAY");
		if ((ES2.Load<string>("DAILY_MISSION") == "COMPLETE") & (num == DateTime.Now.Day))
		{
			DM_1_IMG.color = new Color(1f, 1f, 1f, 1f);
			DM_2_IMG.color = new Color(1f, 1f, 1f, 1f);
			DM_3_IMG.color = new Color(1f, 1f, 1f, 1f);
			DM_1_IMG_FILL.fillAmount = 1f;
			DM_2_IMG_FILL.fillAmount = 1f;
			DM_3_IMG_FILL.fillAmount = 1f;
			DM_1_CMP.SetActive(value: true);
			DM_2_CMP.SetActive(value: true);
			DM_3_CMP.SetActive(value: true);
			DM_AWARD.text = "0";
			DISPLAY_MISSION_TXT();
			return;
		}
		DM_1_IMG_FILL.fillAmount = 0f;
		DM_2_IMG_FILL.fillAmount = 0f;
		DM_3_IMG_FILL.fillAmount = 0f;
		DM_1_IMG.color = new Color(0f, 0f, 0f, 0.5f);
		DM_2_IMG.color = new Color(0f, 0f, 0f, 0.5f);
		DM_3_IMG.color = new Color(0f, 0f, 0f, 0.5f);
		DM_1_CMP.SetActive(value: false);
		DM_2_CMP.SetActive(value: false);
		DM_3_CMP.SetActive(value: false);
		if (num != DateTime.Now.Day)
		{
			ES2.Save(DateTime.Now.Day, "DAILY_MISSION_DAY");
			ES2.Save(0, "DAILY_MISSION_1");
			ES2.Save(0, "DAILY_MISSION_1_NEED");
			ES2.Save(0, "DAILY_MISSION_2");
			ES2.Save(0, "DAILY_MISSION_2_NEED");
			ES2.Save(0, "DAILY_MISSION_3");
			ES2.Save(0, "DAILY_MISSION_3_NEED");
			ES2.Save(string.Empty, "DAILY_MISSION");
			COMPLETE_1_MISSION.SetActive(value: false);
			COMPLETE_2_MISSION.SetActive(value: false);
			COMPLETE_3_MISSION.SetActive(value: false);
			int num2 = UnityEngine.Random.Range(0, 4);
			if (num2 == 0)
			{
				ES2.Save("COLLECT_COINS", "DAILY_MISSION_1_TYPE");
				ES2.Save(UnityEngine.Random.Range(50, 200), "DAILY_MISSION_1_NEED");
			}
			if (num2 == 1)
			{
				ES2.Save("COLLECT_DETAILS", "DAILY_MISSION_1_TYPE");
				ES2.Save(UnityEngine.Random.Range(10, 20), "DAILY_MISSION_1_NEED");
			}
			if (num2 == 2)
			{
				ES2.Save("COLLECT_SEEDS", "DAILY_MISSION_1_TYPE");
				ES2.Save(UnityEngine.Random.Range(10, 20), "DAILY_MISSION_1_NEED");
			}
			if (num2 == 3)
			{
				ES2.Save("COLLECT_WORDS", "DAILY_MISSION_1_TYPE");
				ES2.Save(1, "DAILY_MISSION_1_NEED");
			}
			int num3 = UnityEngine.Random.Range(0, 4);
			if (SELECTED_CAR < 2 && num3 == 2)
			{
				num3 = UnityEngine.Random.Range(0, 2);
			}
			if (SELECTED_CAR < 4 && num3 == 3)
			{
				num3 = UnityEngine.Random.Range(0, 3);
			}
			if ((num3 == 1) & (ES2.Load<int>("TAXI_LICENSE") == 0))
			{
				num3 = 0;
			}
			if ((num3 == 2) & (ES2.Load<int>("MEDIC_LICENSE") == 0))
			{
				num3 = 0;
			}
			if ((num3 == 3) & (ES2.Load<int>("COP_LICENSE") == 0))
			{
				num3 = 0;
			}
			if (num3 == 0)
			{
				ES2.Save("WIN_RACES", "DAILY_MISSION_2_TYPE");
				ES2.Save(UnityEngine.Random.Range(2, 5), "DAILY_MISSION_2_NEED");
			}
			if (num3 == 1)
			{
				ES2.Save("WIN_TAXI_JOB", "DAILY_MISSION_2_TYPE");
				ES2.Save(UnityEngine.Random.Range(4, 8), "DAILY_MISSION_2_NEED");
			}
			if (num3 == 2)
			{
				ES2.Save("WIN_MEDIC_JOB", "DAILY_MISSION_2_TYPE");
				ES2.Save(UnityEngine.Random.Range(3, 8), "DAILY_MISSION_2_NEED");
			}
			if (num3 == 3)
			{
				ES2.Save("WIN_COP_JOB", "DAILY_MISSION_2_TYPE");
				ES2.Save(UnityEngine.Random.Range(3, 6), "DAILY_MISSION_2_NEED");
			}
			int num4 = UnityEngine.Random.Range(0, 3);
			if (num4 == 0)
			{
				ES2.Save("COMPLETE_X_AIR", "DAILY_MISSION_3_TYPE");
				ES2.Save(UnityEngine.Random.Range(1, 3), "DAILY_MISSION_3_NEED");
			}
			if (num4 == 1)
			{
				ES2.Save("COMPLETE_X_DRIFT", "DAILY_MISSION_3_TYPE");
				ES2.Save(UnityEngine.Random.Range(1, 3), "DAILY_MISSION_3_NEED");
			}
			if (num4 == 2)
			{
				ES2.Save("COMPLETE_X_DESTROY", "DAILY_MISSION_3_TYPE");
				ES2.Save(UnityEngine.Random.Range(1, 3), "DAILY_MISSION_3_NEED");
			}
			DISPLAY_MISSION_TXT();
			DISPLAY_MISSION_TXT();
			DISPLAY_MISSION_TXT();
			if (PLAYER_LEVEL == 0)
			{
				DM_AWARD.text = string.Empty + 50;
			}
			else
			{
				DM_AWARD.text = string.Empty + PLAYER_LEVEL * 50;
			}
		}
		else
		{
			DISPLAY_MISSION_TXT();
			if (PLAYER_LEVEL == 0)
			{
				DM_AWARD.text = string.Empty + 50;
			}
			else
			{
				DM_AWARD.text = string.Empty + PLAYER_LEVEL * 50;
			}
		}
	}

	private void DISPLAY_MISSION_TXT()
	{
		if (ES2.Load<string>("DAILY_MISSION_1_TYPE") == "COLLECT_COINS")
		{
			if (MENU_MANAGER.LANGUAGE == 0)
			{
				DM_1_TXT.text = "COLLECT " + ES2.Load<int>("DAILY_MISSION_1_NEED") + " COINS";
			}
			else
			{
				DM_1_TXT.text = "СОБРАТЬ " + ES2.Load<int>("DAILY_MISSION_1_NEED") + " МОНЕТ";
			}
			DM_1_IMG_FILL.fillAmount = (float)ES2.Load<int>("DAILY_MISSION_1") / (float)ES2.Load<int>("DAILY_MISSION_1_NEED");
			if (DM_1_IMG_FILL.fillAmount >= 1f)
			{
				DM_1_CMP.SetActive(value: true);
				COMPLETE_1_MISSION.SetActive(value: true);
			}
		}
		if (ES2.Load<string>("DAILY_MISSION_1_TYPE") == "COLLECT_DETAILS")
		{
			if (MENU_MANAGER.LANGUAGE == 0)
			{
				DM_1_TXT.text = "COLLECT " + ES2.Load<int>("DAILY_MISSION_1_NEED") + " GEARS";
			}
			else
			{
				DM_1_TXT.text = "СОБРАТЬ " + ES2.Load<int>("DAILY_MISSION_1_NEED") + " ДЕТАЛЕЙ";
			}
			DM_1_IMG_FILL.fillAmount = (float)ES2.Load<int>("DAILY_MISSION_1") / (float)ES2.Load<int>("DAILY_MISSION_1_NEED");
			if (DM_1_IMG_FILL.fillAmount >= 1f)
			{
				DM_1_CMP.SetActive(value: true);
				COMPLETE_1_MISSION.SetActive(value: true);
			}
		}
		if (ES2.Load<string>("DAILY_MISSION_1_TYPE") == "COLLECT_SEEDS")
		{
			if (MENU_MANAGER.LANGUAGE == 0)
			{
				DM_1_TXT.text = "COLLECT " + ES2.Load<int>("DAILY_MISSION_1_NEED") + " SEEDS";
			}
			else
			{
				DM_1_TXT.text = "СОБРАТЬ " + ES2.Load<int>("DAILY_MISSION_1_NEED") + " СЕМЯН";
			}
			DM_1_IMG_FILL.fillAmount = (float)ES2.Load<int>("DAILY_MISSION_1") / (float)ES2.Load<int>("DAILY_MISSION_1_NEED");
			if (DM_1_IMG_FILL.fillAmount >= 1f)
			{
				DM_1_CMP.SetActive(value: true);
				COMPLETE_1_MISSION.SetActive(value: true);
			}
		}
		if (ES2.Load<string>("DAILY_MISSION_1_TYPE") == "COLLECT_WORDS")
		{
			if (MENU_MANAGER.LANGUAGE == 0)
			{
				DM_1_TXT.text = "COLLECT " + ES2.Load<int>("DAILY_MISSION_1_NEED") + " WORD";
			}
			else
			{
				DM_1_TXT.text = "СОБРАТЬ " + ES2.Load<int>("DAILY_MISSION_1_NEED") + " СЛОВО";
			}
			if (ES2.Load<int>("DAILY_MISSION_1") == 1)
			{
				DM_1_IMG_FILL.fillAmount = 1f;
			}
			if (DM_1_IMG_FILL.fillAmount >= 1f)
			{
				DM_1_CMP.SetActive(value: true);
				COMPLETE_1_MISSION.SetActive(value: true);
			}
		}
		if (ES2.Load<string>("DAILY_MISSION_2_TYPE") == "WIN_RACES")
		{
			if (MENU_MANAGER.LANGUAGE == 0)
			{
				DM_2_TXT.text = "WIN " + ES2.Load<int>("DAILY_MISSION_2_NEED") + " RACES";
			}
			else
			{
				DM_2_TXT.text = "ВЫИГРАТЬ " + ES2.Load<int>("DAILY_MISSION_2_NEED") + " гонки";
			}
			DM_2_IMG_FILL.fillAmount = (float)ES2.Load<int>("DAILY_MISSION_2") / (float)ES2.Load<int>("DAILY_MISSION_2_NEED");
			if (DM_2_IMG_FILL.fillAmount >= 1f)
			{
				DM_2_CMP.SetActive(value: true);
				COMPLETE_2_MISSION.SetActive(value: true);
			}
		}
		if (ES2.Load<string>("DAILY_MISSION_2_TYPE") == "WIN_TAXI_JOB")
		{
			if (MENU_MANAGER.LANGUAGE == 0)
			{
				DM_2_TXT.text = "COMPLETE TAXI " + ES2.Load<int>("DAILY_MISSION_2_NEED") + " JOB";
			}
			else
			{
				DM_2_TXT.text = "Выполнить " + ES2.Load<int>("DAILY_MISSION_2_NEED") + "работ такси";
			}
			DM_2_IMG_FILL.fillAmount = (float)ES2.Load<int>("DAILY_MISSION_2") / (float)ES2.Load<int>("DAILY_MISSION_2_NEED");
			if (DM_2_IMG_FILL.fillAmount >= 1f)
			{
				DM_2_CMP.SetActive(value: true);
				COMPLETE_2_MISSION.SetActive(value: true);
			}
		}
		if (ES2.Load<string>("DAILY_MISSION_2_TYPE") == "WIN_MEDIC_JOB")
		{
			if (MENU_MANAGER.LANGUAGE == 0)
			{
				DM_2_TXT.text = "COMPLETE MEDIC " + ES2.Load<int>("DAILY_MISSION_2_NEED") + " JOB";
			}
			else
			{
				DM_2_TXT.text = "ВЫполнить " + ES2.Load<int>("DAILY_MISSION_2_NEED") + "работ медика";
			}
			DM_2_IMG_FILL.fillAmount = (float)ES2.Load<int>("DAILY_MISSION_2") / (float)ES2.Load<int>("DAILY_MISSION_2_NEED");
			if (DM_2_IMG_FILL.fillAmount >= 1f)
			{
				DM_2_CMP.SetActive(value: true);
				COMPLETE_2_MISSION.SetActive(value: true);
			}
		}
		if (ES2.Load<string>("DAILY_MISSION_2_TYPE") == "WIN_COP_JOB")
		{
			if (MENU_MANAGER.LANGUAGE == 0)
			{
				DM_2_TXT.text = "COMPLETE COP " + ES2.Load<int>("DAILY_MISSION_2_NEED") + " JOB";
			}
			else
			{
				DM_2_TXT.text = "ВЫполнить " + ES2.Load<int>("DAILY_MISSION_2_NEED") + "работ копа";
			}
			DM_2_IMG_FILL.fillAmount = (float)ES2.Load<int>("DAILY_MISSION_2") / (float)ES2.Load<int>("DAILY_MISSION_2_NEED");
			if (DM_2_IMG_FILL.fillAmount >= 1f)
			{
				DM_2_CMP.SetActive(value: true);
				COMPLETE_2_MISSION.SetActive(value: true);
			}
		}
		if (ES2.Load<string>("DAILY_MISSION_3_TYPE") == "COMPLETE_X_AIR")
		{
			if (MENU_MANAGER.LANGUAGE == 0)
			{
				DM_3_TXT.text = "FILL " + ES2.Load<int>("DAILY_MISSION_3_NEED") + " AIRTIME LINES";
			}
			else if (ES2.Load<int>("DAILY_MISSION_3_NEED") < 2)
			{
				DM_3_TXT.text = "Время в воздухе " + ES2.Load<int>("DAILY_MISSION_3_NEED") + " раз";
			}
			else
			{
				DM_3_TXT.text = "Время в воздухе " + ES2.Load<int>("DAILY_MISSION_3_NEED") + " раза";
			}
			DM_3_IMG_FILL.fillAmount = (float)ES2.Load<int>("DAILY_MISSION_3") / (float)ES2.Load<int>("DAILY_MISSION_3_NEED");
			if (DM_3_IMG_FILL.fillAmount >= 1f)
			{
				DM_3_CMP.SetActive(value: true);
				COMPLETE_3_MISSION.SetActive(value: true);
			}
		}
		if (ES2.Load<string>("DAILY_MISSION_3_TYPE") == "COMPLETE_X_DRIFT")
		{
			if (MENU_MANAGER.LANGUAGE == 0)
			{
				DM_3_TXT.text = "FILL " + ES2.Load<int>("DAILY_MISSION_3_NEED") + " DRIFTTIME LINES";
			}
			else if (ES2.Load<int>("DAILY_MISSION_3_NEED") < 2)
			{
				DM_3_TXT.text = "Время дрифта " + ES2.Load<int>("DAILY_MISSION_3_NEED") + " раз";
			}
			else
			{
				DM_3_TXT.text = "Время дрифта " + ES2.Load<int>("DAILY_MISSION_3_NEED") + " раза";
			}
			DM_3_IMG_FILL.fillAmount = (float)ES2.Load<int>("DAILY_MISSION_3") / (float)ES2.Load<int>("DAILY_MISSION_3_NEED");
			if (DM_3_IMG_FILL.fillAmount >= 1f)
			{
				DM_3_CMP.SetActive(value: true);
				COMPLETE_3_MISSION.SetActive(value: true);
			}
		}
		if (ES2.Load<string>("DAILY_MISSION_3_TYPE") == "COMPLETE_X_DESTROY")
		{
			if (MENU_MANAGER.LANGUAGE == 0)
			{
				DM_3_TXT.text = "FILL " + ES2.Load<int>("DAILY_MISSION_3_NEED") + " DESTROYTIME LINES";
			}
			else if (ES2.Load<int>("DAILY_MISSION_3_NEED") < 2)
			{
				DM_3_TXT.text = "Время разрушений " + ES2.Load<int>("DAILY_MISSION_3_NEED") + " раз";
			}
			else
			{
				DM_3_TXT.text = "Время разрушений " + ES2.Load<int>("DAILY_MISSION_3_NEED") + " раза";
			}
			DM_3_IMG_FILL.fillAmount = (float)ES2.Load<int>("DAILY_MISSION_3") / (float)ES2.Load<int>("DAILY_MISSION_3_NEED");
			if (DM_3_IMG_FILL.fillAmount >= 1f)
			{
				DM_3_CMP.SetActive(value: true);
				COMPLETE_3_MISSION.SetActive(value: true);
			}
		}
	}

	public void OPEN_DAILY_MISSIONS()
	{
		CHECK_DAILY_MISSIONS();
		Time.timeScale = 0f;
		AudioListener.volume = 0f;
		AUDIOLISTENER_volume = 0f;
		Camera.main.GetComponent<ScreenFader>().enabled = false;
		Camera.main.GetComponent<CameraFilterPack_Blur_Blurry>().enabled = true;
		WORD_OF_DAY_UI.SetActive(value: false);
		XP_UI.SetActive(value: false);
		DAILY_MISSIONS.SetActive(value: true);
	}

	public void CLOSE_DAILY_MISSIONS()
	{
		Time.timeScale = 1f;
		AUDIOLISTENER_volume = MAIN_VOLUME;
		AudioListener.volume = AUDIOLISTENER_volume;
		Camera.main.GetComponent<CameraFilterPack_Blur_Blurry>().enabled = false;
		DAILY_MISSIONS.SetActive(value: false);
	}

	public void PLAYER_EVENTS()
	{
		if (RAIN == 1)
		{
			if (RAIN_PAUSE > 0f)
			{
				RAIN_PAUSE -= Time.deltaTime;
				if (RAIN_PAUSE < 0f)
				{
					RAIN_PAUSE = 0f;
				}
			}
			if (!IN_RAIN & (RAIN_PAUSE == 0f) & (RAIN_TIME == 0f))
			{
				RAIN_TIME = 100f;
				RAIN_COLOR = 0f;
				RAIN_FX.SetActive(value: true);
				RAIN_FX.GetComponent<ParticleSystem>().startColor = new Color(1f, 1f, 1f, RAIN_COLOR);
				RAIN_FX.GetComponent<AudioSource>().Play();
				RAIN_FX.GetComponent<AudioSource>().volume = 0f;
				ROAD.shader = RAIN_SHADER;
				ROAD.SetTexture("_Cube", CUBEMAP);
				ROAD.SetColor("_Color", new Color(1f, 1f, 1f, 1f));
				ROAD.SetColor("_ReflectColor", new Color(0f, 0f, 0f, 0f));
				R_ = 1f;
				G_ = 1f;
				B_ = 1f;
				A_ = 0f;
			}
			if (RAIN_TIME > 0f)
			{
				RAIN_TIME -= Time.deltaTime;
				if (RAIN_TIME < 0f)
				{
					RAIN_TIME = 0f;
				}
			}
			if (RAIN_TIME > 30f)
			{
				if (RAIN_FX.GetComponent<AudioSource>().volume < 0.8f)
				{
					RAIN_FX.GetComponent<AudioSource>().volume += Time.deltaTime / 60f;
				}
				if (RAIN_COLOR < 0.17f)
				{
					RAIN_COLOR += Time.deltaTime / 300f;
					if (Time.frameCount % 5 == 0)
					{
						RAIN_FX.GetComponent<ParticleSystem>().startColor = new Color(1f, 1f, 1f, RAIN_COLOR);
					}
				}
				if (ROAD.GetColor("_Color").r > 0.68f)
				{
					R_ -= Time.deltaTime / 120f;
					G_ -= Time.deltaTime / 120f;
					B_ -= Time.deltaTime / 120f;
					if (Time.frameCount % 5 == 0)
					{
						ROAD.SetColor("_Color", new Color(R_, G_, B_, 1f));
					}
				}
				if ((ROAD.GetColor("_ReflectColor").a < 0.3f) & (R_ < 0.8f))
				{
					A1_ += Time.deltaTime / 150f;
					if (A2_ < 0.2f)
					{
						A2_ += Time.deltaTime / 60f;
					}
					if ((A2_ > 0.1f) & !IN_RAIN)
					{
						IN_RAIN = true;
						PLAYER_.GetComponent<Rigidbody>().angularDrag = 0f;
					}
					if (Time.frameCount % 5 == 0)
					{
						ROAD.SetColor("_ReflectColor", new Color(A2_, A2_, A2_, A1_));
					}
				}
			}
			else if (IN_RAIN)
			{
				if (RAIN_FX.GetComponent<AudioSource>().volume > 0f)
				{
					RAIN_FX.GetComponent<AudioSource>().volume -= Time.deltaTime / 30f;
				}
				if (RAIN_COLOR > 0f)
				{
					RAIN_COLOR -= Time.deltaTime / 80f;
					if (Time.frameCount % 5 == 0)
					{
						RAIN_FX.GetComponent<ParticleSystem>().startColor = new Color(1f, 1f, 1f, RAIN_COLOR);
					}
				}
				R_ += Time.deltaTime / 60f;
				G_ += Time.deltaTime / 60f;
				B_ += Time.deltaTime / 60f;
				if (Time.frameCount % 5 == 0)
				{
					ROAD.SetColor("_Color", new Color(R_, G_, B_, 1f));
					ROAD.SetColor("_ReflectColor", new Color(A2_, A2_, A2_, A1_));
				}
				A2_ -= Time.deltaTime / 100f;
				A1_ -= Time.deltaTime / 150f;
				if (R_ > 0.98f)
				{
					IN_RAIN = false;
					RAIN_TIME = 0f;
					RAIN_PAUSE = UnityEngine.Random.Range(450, 600);
					RAIN_FX.SetActive(value: false);
					ROAD.shader = MOBILE_SHADER;
					PLAYER_.GetComponent<Rigidbody>().angularDrag = 0.1f;
					return;
				}
			}
		}
		if (IN_DRIFT)
		{
			IN_AIR = false;
			AIR_UI.SetActive(value: false);
			AIR_COMPLETE_UI.SetActive(value: false);
			PLAYER_AIR_TIMER = 0f;
			fc += Time.deltaTime;
			if (fc > 0.1f)
			{
				PLAYER_DRIFT_X += 1f;
				fc = 0f;
			}
			if (DRIFT_UI.activeInHierarchy & (PLAYER_DRIFT_TIMER < 0.3f))
			{
				PLAYER_DRIFT_X -= 1f;
				IN_DRIFT = false;
				return;
			}
			if ((PLAYER_DRIFT_X > 1f) & !DRIFT_UI.activeInHierarchy)
			{
				DRIFT_UI.SetActive(value: true);
				DRIFT_UI.transform.localScale = new Vector3(1f, 1f, 1f);
				DRIFT_MULT.text = "X1";
				PLAYER_DRIFT_X = 1f;
			}
			DRIFT_MULT.text = "X" + PLAYER_DRIFT_X;
			if (!DRIFT_UI.activeInHierarchy)
			{
				PLAYER_DRIFT_TIMER = 0.6f;
			}
			else
			{
				DD = 9 + PLAYER_DRIFT_LEVEL_X;
				PLAYER_DRIFT_LEVEL += Time.deltaTime / (float)DD;
				DRIFT_IMG_LV.fillAmount = PLAYER_DRIFT_LEVEL;
				PLAYER_DRIFT_TIMER = 3f;
				if (PLAYER_DRIFT_LEVEL > 0.99f)
				{
					IN_DRIFT = false;
					PLAYER_DRIFT_LEVEL_X++;
					DRIFT_AWARD.text = "+ " + PLAYER_DRIFT_LEVEL_X * 50;
					PLAYER_MONEY += PLAYER_DRIFT_LEVEL_X * 50;
					ES2.Save(PLAYER_MONEY, "PLAYER_MONEY");
					ES2.Save(ES2.Load<int>("ALL_EVENTS") + 1, "ALL_EVENTS");
					if (MENU_MANAGER.LANGUAGE == 1 && !IN_RACE)
					{
						VOICE_OBJ.GetComponent<AudioSource>().clip = VOICE_EVENT[UnityEngine.Random.Range(0, VOICE_EVENT.Length)];
						VOICE_OBJ.GetComponent<AudioSource>().Play();
					}
					DRIFT_COMPLETE_UI.SetActive(value: true);
					DRIFT_UI.SetActive(value: false);
					PLAYER_DRIFT_X = -100f;
					PLAYER_DRIFT_TIMER = 4f;
					PLAYER_DRIFT_LEVEL = 0f;
					CHECK_DRIFT = true;
				}
			}
		}
		if (PLAYER_DRIFT_TIMER > 0f)
		{
			PLAYER_DRIFT_TIMER -= Time.deltaTime;
			if ((double)PLAYER_DRIFT_TIMER < 0.3)
			{
				DRIFT_UI.transform.localScale -= Vector3.left;
				DRIFT_UI.transform.localScale -= Vector3.up;
			}
			if (PLAYER_DRIFT_TIMER < 0.1f)
			{
				DRIFT_COMPLETE_UI.SetActive(value: false);
				if (PLAYER_DRIFT_X > (float)DRIFT_REC)
				{
					DRIFT_REC = (int)PLAYER_DRIFT_X;
					StartCoroutine(SHOW_DRIFT_REC());
					DRIFT_REC_TXT.text = "x" + DRIFT_REC;
					ES2.Save(DRIFT_REC, "DRIFT_REC");
				}
				PLAYER_DRIFT_X = 0f;
				PLAYER_DRIFT_TIMER = 0f;
				IN_DRIFT = false;
				DRIFT_UI.SetActive(value: false);
			}
		}
		if (IN_AIR)
		{
			IN_DRIFT = false;
			DRIFT_UI.SetActive(value: false);
			DRIFT_COMPLETE_UI.SetActive(value: false);
			PLAYER_DRIFT_TIMER = 0f;
			fb += Time.deltaTime;
			if (fb > 0.2f)
			{
				PLAYER_AIR_X += 1f;
				fb = 0f;
			}
			if (AIR_UI.activeInHierarchy & (PLAYER_AIR_TIMER < 0.3f))
			{
				PLAYER_AIR_X -= 1f;
			}
			if ((PLAYER_AIR_X > 1f) & !AIR_UI.activeInHierarchy)
			{
				AIR_UI.SetActive(value: true);
				AIR_UI.transform.localScale = new Vector3(1f, 1f, 1f);
				AIR_MULT.text = "X1";
				PLAYER_AIR_X = 1f;
			}
			AIR_MULT.text = "X" + PLAYER_AIR_X;
			if (!AIR_UI.activeInHierarchy)
			{
				PLAYER_AIR_TIMER = 0.6f;
			}
			else
			{
				PLAYER_AIR_LEVEL += Time.deltaTime / (float)PLAYER_AIR_LEVEL_X;
				AIR_IMG_LV.fillAmount = PLAYER_AIR_LEVEL;
				PLAYER_AIR_TIMER = 3f;
				if (PLAYER_AIR_LEVEL > 0.99f)
				{
					IN_AIR = false;
					PLAYER_AIR_LEVEL_X += 5;
					AIR_AWARD.text = "+ " + PLAYER_AIR_LEVEL_X * 25;
					PLAYER_MONEY += PLAYER_AIR_LEVEL_X * 25;
					ES2.Save(PLAYER_MONEY, "PLAYER_MONEY");
					ES2.Save(ES2.Load<int>("ALL_EVENTS") + 1, "ALL_EVENTS");
					if (MENU_MANAGER.LANGUAGE == 1 && !IN_RACE)
					{
						VOICE_OBJ.GetComponent<AudioSource>().clip = VOICE_EVENT[UnityEngine.Random.Range(0, VOICE_EVENT.Length)];
						VOICE_OBJ.GetComponent<AudioSource>().Play();
					}
					AIR_COMPLETE_UI.SetActive(value: true);
					AIR_UI.SetActive(value: false);
					PLAYER_AIR_X = -100f;
					PLAYER_AIR_TIMER = 4f;
					PLAYER_AIR_LEVEL = 0f;
					CHECK_AIR = true;
				}
			}
		}
		if (PLAYER_AIR_TIMER > 0f)
		{
			PLAYER_AIR_TIMER -= Time.deltaTime;
			if ((double)PLAYER_AIR_TIMER < 0.3)
			{
				AIR_UI.transform.localScale -= Vector3.left;
				AIR_UI.transform.localScale -= Vector3.up;
			}
			if (PLAYER_AIR_TIMER < 0.1f)
			{
				AIR_COMPLETE_UI.SetActive(value: false);
				if (PLAYER_AIR_X > (float)AIR_REC)
				{
					AIR_REC = (int)PLAYER_AIR_X;
					StartCoroutine(SHOW_AIR_REC());
					AIR_REC_TXT.text = "x" + AIR_REC;
					ES2.Save(AIR_REC, "AIR_REC");
				}
				PLAYER_AIR_X = 0f;
				PLAYER_AIR_TIMER = 0f;
				IN_AIR = false;
				AIR_UI.SetActive(value: false);
			}
		}
		if (PLAYER_DESTROY_ & !IN_RACE)
		{
			PLAYER_DESTROY_X += 1f;
			if (DESTROY_UI.activeInHierarchy & (PLAYER_DESTROY_TIMER < 0.3f))
			{
				PLAYER_DESTROY_X -= 1f;
				PLAYER_DESTROY_ = false;
				return;
			}
			if ((PLAYER_DESTROY_X > 4f) & !DESTROY_UI.activeInHierarchy)
			{
				DESTROY_UI.SetActive(value: true);
				DESTROY_UI.transform.localScale = new Vector3(1f, 1f, 1f);
				DESTROY_MULT.text = "X2";
				PLAYER_DESTROY_X = 2f;
			}
			DESTROY_MULT.text = "X" + PLAYER_DESTROY_X;
			if (!DESTROY_UI.activeInHierarchy)
			{
				PLAYER_DESTROY_TIMER = 0.6f;
			}
			else
			{
				PLAYER_DESTROYER_LEVEL += Time.deltaTime * 2f / (float)PLAYER_DESTROYER_LEVEL_X;
				DESTROY_IMG_LV.fillAmount = PLAYER_DESTROYER_LEVEL;
				PLAYER_DESTROY_TIMER = 3f;
				if (PLAYER_DESTROYER_LEVEL > 0.99f)
				{
					PLAYER_DESTROYER_LEVEL_X++;
					DESTROY_AWARD.text = "+ " + PLAYER_DESTROYER_LEVEL_X * 50;
					PLAYER_MONEY += PLAYER_DESTROYER_LEVEL_X * 50;
					if (MENU_MANAGER.LANGUAGE == 1 && !IN_RACE)
					{
						VOICE_OBJ.GetComponent<AudioSource>().clip = VOICE_EVENT[UnityEngine.Random.Range(0, VOICE_EVENT.Length)];
						VOICE_OBJ.GetComponent<AudioSource>().Play();
					}
					ES2.Save(PLAYER_MONEY, "PLAYER_MONEY");
					ES2.Save(ES2.Load<int>("ALL_EVENTS") + 1, "ALL_EVENTS");
					DESTROY_COMPLETE_UI.SetActive(value: true);
					DESTROY_UI.SetActive(value: false);
					PLAYER_DESTROY_X = -100f;
					PLAYER_DESTROY_TIMER = 4f;
					PLAYER_DESTROYER_LEVEL = 0f;
					CHECK_DESTROY = true;
				}
			}
			PLAYER_DESTROY_ = false;
		}
		if (!(PLAYER_DESTROY_TIMER > 0f))
		{
			return;
		}
		PLAYER_DESTROY_TIMER -= Time.deltaTime;
		if ((double)PLAYER_DESTROY_TIMER < 0.3)
		{
			DESTROY_UI.transform.localScale -= Vector3.right;
			DESTROY_UI.transform.localScale -= Vector3.up;
		}
		if (PLAYER_DESTROY_TIMER < 0.1f)
		{
			DESTROY_COMPLETE_UI.SetActive(value: false);
			if (PLAYER_DESTROY_X > (float)DESTROY_REC)
			{
				DESTROY_REC = (int)PLAYER_DESTROY_X;
				StartCoroutine(SHOW_DESTROY_REC());
				DESTROY_REC_TXT.text = "x" + DESTROY_REC;
				ES2.Save(DESTROY_REC, "DESTROY_REC");
			}
			PLAYER_DESTROY_X = 0f;
			PLAYER_DESTROY_TIMER = 0f;
			PLAYER_DESTROY_ = false;
			DESTROY_UI.SetActive(value: false);
		}
	}

	public void LETTER()
	{
		int num = ES2.Load<int>("WORD_DAY");
		if ((ES2.Load<string>("WORD_OF_DAY") == "COMPLETE") & (num == DateTime.Now.Day))
		{
			return;
		}
		if (num != DateTime.Now.Day)
		{
			int num2 = UnityEngine.Random.Range(0, 17);
			if (num2 == 0)
			{
				WORD = "LUCKY";
			}
			if (num2 == 9)
			{
				WORD = "SMILE";
			}
			if (num2 == 1)
			{
				WORD = "HAPPY";
			}
			if (num2 == 10)
			{
				WORD = "ABGAMES89";
			}
			if (num2 == 2)
			{
				WORD = "SUNNY";
			}
			if (num2 == 11)
			{
				WORD = "FREEDOM";
			}
			if (num2 == 3)
			{
				WORD = "SURPRISE";
			}
			if (num2 == 12)
			{
				WORD = "GALAXY";
			}
			if (num2 == 4)
			{
				WORD = "MAGIC";
			}
			if (num2 == 13)
			{
				WORD = "GLAMOUR";
			}
			if (num2 == 5)
			{
				WORD = "RAINBOW";
			}
			if (num2 == 14)
			{
				WORD = "SUNFLOWER";
			}
			if (num2 == 6)
			{
				WORD = "SPEED";
			}
			if (num2 == 15)
			{
				WORD = "SUNSHINE";
			}
			if (num2 == 7)
			{
				WORD = "AMAZING";
			}
			if (num2 == 16)
			{
				WORD = "BANANA";
			}
			if (num2 == 8)
			{
				WORD = "SMILE";
			}
			if (num2 == 17)
			{
				WORD = "BUBBLE";
			}
			ES2.Save(0, "LETTERS");
			ES2.Save(WORD, "WORD_OF_DAY");
			ES2.Save(DateTime.Now.Day, "WORD_DAY");
			FIND_LETTER = 0;
		}
		else
		{
			WORD = ES2.Load<string>("WORD_OF_DAY");
			FIND_LETTER = ES2.Load<int>("LETTERS");
		}
		int num3 = WORD.Length - FIND_LETTER;
		for (int i = 0; i < num3; i++)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate(LETTER_OBJ, new Vector3(UnityEngine.Random.Range(50, 900), 80f, UnityEngine.Random.Range(80, 950)), base.transform.rotation);
		}
		for (int j = 0; j < WORD.Length; j++)
		{
			if (FIND_LETTER > 0)
			{
				FIND_LETTER--;
				LETTER_[j] = "<color=#00ffffff>" + WORD.Substring(j, 1) + "</color>";
			}
			else
			{
				LETTER_[j] = "<color=#808080ff>" + WORD.Substring(j, 1) + "</color>";
			}
		}
		WORD_ = string.Empty;
		for (int k = 0; k < WORD.Length; k++)
		{
			WORD_ += LETTER_[k];
		}
		WORD_TEXT.text = WORD_;
		if (!START_RACE_FROM_MENU & !SHOW_WORD_TODAY)
		{
			StartCoroutine(WORD_OF_DAY_ON());
		}
		if (ES2.Load<int>("LETTERS") >= ES2.Load<string>("WORD_OF_DAY").Length)
		{
			StopCoroutine(WORD_OF_DAY_ON());
			COP_MANAGER.PASSENGER_COMPLETE = true;
			WORD_OF_DAY_UI.SetActive(value: false);
			FIND_WORD_UI.SetActive(value: true);
			FIND_WORD_WORD_TEXT.text = WORD;
			if (PLAYER_LEVEL > 0)
			{
				AWARD_FIND_WORD = PLAYER_LEVEL * 150;
			}
			else
			{
				AWARD_FIND_WORD = 100;
			}
			FIND_WORD_MONEY_TEXT.text = string.Empty + AWARD_FIND_WORD;
		}
	}

	public void CLOSE_WORD_FIND()
	{
		if (MENU_MANAGER.APPODEAL_ADS_TIMER == 0f)
		{
			MENU_MANAGER.APPODEAL_ADS_TIMER = 40f;
		}
		COP_MANAGER.PASSENGER_COMPLETE = false;
		ES2.Save("COMPLETE", "WORD_OF_DAY");
		AudioSource.PlayClipAtPoint(UI_CLICK, Camera.main.transform.position);
		PLAYER_MONEY += AWARD_FIND_WORD;
		ES2.Save(PLAYER_MONEY, "PLAYER_MONEY");
		FIND_WORD_UI.SetActive(value: false);
		GameObject[] array = GameObject.FindGameObjectsWithTag("LETTER");
		GameObject[] array2 = array;
		foreach (GameObject obj in array2)
		{
			UnityEngine.Object.Destroy(obj);
		}
		if (ES2.Load<string>("DAILY_MISSION_1_TYPE") == "COLLECT_WORDS" && ES2.Load<int>("DAILY_MISSION_1") < ES2.Load<int>("DAILY_MISSION_1_NEED"))
		{
			ES2.Save(1, "DAILY_MISSION_1");
			if (ES2.Load<int>("DAILY_MISSION_1") == 1)
			{
				DTAST_COMPELTE = true;
			}
		}
	}

	public void GEAR()
	{
		for (int i = 0; i < 12; i++)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate(GEAR_OBJ, new Vector3(UnityEngine.Random.Range(50, 900), 80f, UnityEngine.Random.Range(80, 950)), base.transform.rotation);
		}
	}

	public void COINS()
	{
		if (MENU_MANAGER.LOADING_LEVEL == 0)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate(COINS_MANAGER_FARM, COINS_MANAGER_FARM.transform.position, COINS_MANAGER_FARM.transform.rotation);
		}
		else
		{
			GameObject gameObject2 = UnityEngine.Object.Instantiate(COINS_MANAGER_CITY, COINS_MANAGER_CITY.transform.position, COINS_MANAGER_CITY.transform.rotation);
		}
	}

	public void SET_RANDROM_POSITION()
	{
		int num = UnityEngine.Random.Range(0, START_POSITION_FARM.Length);
		PLAYER_.GetComponent<RCC_CarControllerV3>().HAND();
		PLAYER_.transform.position = new Vector3(START_POSITION_FARM[num].x, 32f, START_POSITION_FARM[num].z);
		PLAYER_.transform.rotation = Quaternion.Euler(0f, START_POSITION_FARM[num].y, 0f);
	}

	public void SET_RANDROM_POSITION2()
	{
		int num = UnityEngine.Random.Range(0, START_POSITION_CITY.Length);
		PLAYER_.GetComponent<RCC_CarControllerV3>().HAND();
		PLAYER_.transform.position = new Vector3(START_POSITION_CITY[num].x, 32f, START_POSITION_CITY[num].z);
		PLAYER_.transform.rotation = Quaternion.Euler(0f, START_POSITION_CITY[num].y, 0f);
	}

	public void CREATE_PLAYER()
	{
		if (MENU_MANAGER.LOADING_LEVEL == 1)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate(PLAYER_PREFAB[SELECTED_CAR], new Vector3(340f, 33f, 661f), base.transform.rotation);
			gameObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
			PLAYER_ = gameObject;
		}
		else
		{
			GameObject gameObject2 = UnityEngine.Object.Instantiate(PLAYER_PREFAB[SELECTED_CAR], new Vector3(313f, 33f, 540f), base.transform.rotation);
			gameObject2.transform.rotation = Quaternion.Euler(0f, -30f, 0f);
			PLAYER_ = gameObject2;
		}
		if (START_RACE_FROM_MENU)
		{
			PLAYER_.transform.position = new Vector3(PL_X, PL_Y, PL_Z);
			PLAYER_.transform.rotation = Quaternion.Euler(0f, PL_ROT, 0f);
		}
		else
		{
			if (MENU_MANAGER.LOADING_LEVEL == 0)
			{
				int num = UnityEngine.Random.Range(0, START_POSITION_FARM.Length);
				PLAYER_.transform.position = new Vector3(START_POSITION_FARM[num].x, 32f, START_POSITION_FARM[num].z);
				PLAYER_.transform.rotation = Quaternion.Euler(0f, START_POSITION_FARM[num].y, 0f);
			}
			if (MENU_MANAGER.LOADING_LEVEL == 1)
			{
				int num2 = UnityEngine.Random.Range(0, START_POSITION_CITY.Length);
				PLAYER_.transform.position = new Vector3(START_POSITION_CITY[num2].x, 32f, START_POSITION_CITY[num2].z);
				PLAYER_.transform.rotation = Quaternion.Euler(0f, START_POSITION_CITY[num2].y, 0f);
			}
		}
		if (RESTORE_RACE)
		{
			PLAYER_.transform.position = new Vector3(PL_X, PL_Y, PL_Z);
			PLAYER_.transform.rotation = Quaternion.Euler(0f, PL_ROT, 0f);
			RESTORE_RACE = false;
		}
		RCC_SceneManager.Instance.activePlayerVehicle = PLAYER_.GetComponent<RCC_CarControllerV3>();
		if (DEVELOPEMENT_MODE)
		{
			PLAYER_.transform.position = new Vector3(488f, 32f, 385f);
			PLAYER_.transform.rotation = Quaternion.Euler(0f, -89f, 0f);
		}
		if (SELECTED_CAR == 0)
		{
			POWER_LEVEL = 6;
			SPEED_LEVEL = 4;
			CONTROL_LEVEL = 5;
		}
		if (SELECTED_CAR == 1)
		{
			POWER_LEVEL = 4;
			SPEED_LEVEL = 5;
			CONTROL_LEVEL = 6;
		}
		if (SELECTED_CAR == 2)
		{
			POWER_LEVEL = 5;
			SPEED_LEVEL = 6;
			CONTROL_LEVEL = 4;
		}
		if (SELECTED_CAR == 3)
		{
			POWER_LEVEL = 7;
			SPEED_LEVEL = 6;
			CONTROL_LEVEL = 7;
		}
		if (SELECTED_CAR == 4)
		{
			POWER_LEVEL = 7;
			SPEED_LEVEL = 8;
			CONTROL_LEVEL = 7;
		}
		if (SELECTED_CAR == 5)
		{
			POWER_LEVEL = 8;
			SPEED_LEVEL = 6;
			CONTROL_LEVEL = 5;
		}
		if (SELECTED_CAR == 6)
		{
			POWER_LEVEL = 7;
			SPEED_LEVEL = 9;
			CONTROL_LEVEL = 9;
		}
		if (SELECTED_CAR == 7)
		{
			POWER_LEVEL = 9;
			SPEED_LEVEL = 8;
			CONTROL_LEVEL = 7;
		}
		if (SELECTED_CAR == 8)
		{
			POWER_LEVEL = 9;
			SPEED_LEVEL = 9;
			CONTROL_LEVEL = 9;
		}
		if (SELECTED_CAR == 9)
		{
			POWER_LEVEL = 9;
			SPEED_LEVEL = 9;
			CONTROL_LEVEL = 9;
		}
		int num3 = SELECTED_CAR + 1;
		int num4 = ES2.Load<int>("CAR" + num3 + "_ENGINE");
		int num5 = ES2.Load<int>("CAR" + num3 + "_KPP");
		int num6 = ES2.Load<int>("CAR" + num3 + "_TIRES");
		int num7 = ES2.Load<int>("CAR" + num3 + "_BRAKES");
		int num8 = ES2.Load<int>("CAR" + num3 + "_NITRO");
		int num9 = ES2.Load<int>("CAR" + num3 + "_SUSP");
		int num10 = ES2.Load<int>("CAR" + num3 + "_WEIGHT");
		if (POWER_LEVEL == 4)
		{
			PLAYER_.GetComponent<RCC_CarControllerV3>().engineTorque = 2000f;
		}
		if (POWER_LEVEL == 5)
		{
			PLAYER_.GetComponent<RCC_CarControllerV3>().engineTorque = 2500f;
		}
		if (POWER_LEVEL == 6)
		{
			PLAYER_.GetComponent<RCC_CarControllerV3>().engineTorque = 3000f;
		}
		if (POWER_LEVEL == 7)
		{
			PLAYER_.GetComponent<RCC_CarControllerV3>().engineTorque = 3500f;
		}
		if (POWER_LEVEL == 8)
		{
			PLAYER_.GetComponent<RCC_CarControllerV3>().engineTorque = 4000f;
		}
		if (POWER_LEVEL == 9)
		{
			PLAYER_.GetComponent<RCC_CarControllerV3>().engineTorque = 4500f;
		}
		if (CONTROL_LEVEL == 4)
		{
			PLAYER_CONTROL_SUSPENSION = 10000f;
			PLAYER_.GetComponent<RCC_CarControllerV3>().tractionHelperStrength = 0.1f;
			PLAYER_.GetComponent<RCC_CarControllerV3>().brakeTorque = 10000f;
		}
		if (CONTROL_LEVEL == 5)
		{
			PLAYER_CONTROL_SUSPENSION = 12000f;
			PLAYER_.GetComponent<RCC_CarControllerV3>().tractionHelperStrength = 0.15f;
			PLAYER_.GetComponent<RCC_CarControllerV3>().brakeTorque = 30000f;
		}
		if (CONTROL_LEVEL == 6)
		{
			PLAYER_CONTROL_SUSPENSION = 14000f;
			PLAYER_.GetComponent<RCC_CarControllerV3>().tractionHelperStrength = 0.2f;
			PLAYER_.GetComponent<RCC_CarControllerV3>().brakeTorque = 60000f;
		}
		if (CONTROL_LEVEL == 7)
		{
			PLAYER_CONTROL_SUSPENSION = 16000f;
			PLAYER_.GetComponent<RCC_CarControllerV3>().tractionHelperStrength = 0.25f;
			PLAYER_.GetComponent<RCC_CarControllerV3>().brakeTorque = 90000f;
		}
		if (CONTROL_LEVEL == 8)
		{
			PLAYER_CONTROL_SUSPENSION = 18000f;
			PLAYER_.GetComponent<RCC_CarControllerV3>().tractionHelperStrength = 0.3f;
			PLAYER_.GetComponent<RCC_CarControllerV3>().brakeTorque = 120000f;
		}
		if (CONTROL_LEVEL == 9)
		{
			PLAYER_CONTROL_SUSPENSION = 20000f;
			PLAYER_.GetComponent<RCC_CarControllerV3>().tractionHelperStrength = 0.35f;
			PLAYER_.GetComponent<RCC_CarControllerV3>().brakeTorque = 150000f;
		}
		if (SPEED_LEVEL == 4)
		{
			PLAYER_MAXIMUM_SPEED = 85f;
		}
		if (SPEED_LEVEL == 5)
		{
			PLAYER_MAXIMUM_SPEED = 88f;
		}
		if (SPEED_LEVEL == 6)
		{
			PLAYER_MAXIMUM_SPEED = 92f;
		}
		if (SPEED_LEVEL == 7)
		{
			PLAYER_MAXIMUM_SPEED = 96f;
		}
		if (SPEED_LEVEL == 8)
		{
			PLAYER_MAXIMUM_SPEED = 102f;
		}
		if (SPEED_LEVEL == 9)
		{
			PLAYER_MAXIMUM_SPEED = 105f;
		}
		if (ES2.Load<int>("SELECT_CHARACTER") == 2)
		{
			PLAYER_MAXIMUM_SPEED += 10f;
		}
		if (ES2.Load<int>("SELECT_CHARACTER") == 5)
		{
			PLAYER_MAXIMUM_SPEED += 20f;
		}
		if (num4 > 0)
		{
			PLAYER_.GetComponent<RCC_CarControllerV3>().engineTorque = PLAYER_.GetComponent<RCC_CarControllerV3>().engineTorque + (float)(num4 * 600);
			PLAYER_.GetComponent<RCC_CarControllerV3>().engineTorque = PLAYER_.GetComponent<RCC_CarControllerV3>().engineTorque + (float)(num10 * 400);
			PLAYER_MAXIMUM_SPEED += num4 * 4;
		}
		if (num5 > 0)
		{
			PLAYER_MAXIMUM_SPEED += num5 * 6;
		}
		PLAYER_MAXIMUM_NITRO = PLAYER_MAXIMUM_SPEED + 14f;
		if (num8 > 0)
		{
			PLAYER_MAXIMUM_NITRO += num8 * 4;
			if (num8 == 1)
			{
				PLAYER_NITRO_CONSUM = 1.7f;
			}
			if (num8 == 2)
			{
				PLAYER_NITRO_CONSUM = 1.5f;
			}
			if (num8 == 3)
			{
				PLAYER_NITRO_CONSUM = 1.3f;
			}
			if (num8 == 4)
			{
				PLAYER_NITRO_CONSUM = 1f;
			}
		}
		else
		{
			PLAYER_NITRO_CONSUM = 2f;
		}
		if (num6 > 0)
		{
			PLAYER_.GetComponent<RCC_CarControllerV3>().brakeTorque = PLAYER_.GetComponent<RCC_CarControllerV3>().brakeTorque + (float)(num6 * 20000);
			if (num6 == 1)
			{
				PLAYER_.GetComponent<RCC_CarControllerV3>().tractionHelperStrength = PLAYER_.GetComponent<RCC_CarControllerV3>().tractionHelperStrength + 0.15f;
			}
			if (num6 == 2)
			{
				PLAYER_.GetComponent<RCC_CarControllerV3>().tractionHelperStrength = PLAYER_.GetComponent<RCC_CarControllerV3>().tractionHelperStrength + 0.1f;
			}
			if (num6 == 3)
			{
				PLAYER_.GetComponent<RCC_CarControllerV3>().tractionHelperStrength = PLAYER_.GetComponent<RCC_CarControllerV3>().tractionHelperStrength + 0.1f;
			}
			if (num6 == 4)
			{
				PLAYER_.GetComponent<RCC_CarControllerV3>().tractionHelperStrength = PLAYER_.GetComponent<RCC_CarControllerV3>().tractionHelperStrength + 0.1f;
			}
		}
		if (num9 > 0)
		{
			if (num9 == 1)
			{
				PLAYER_CONTROL_SUSPENSION += 5000f;
			}
			if (num9 == 2)
			{
				PLAYER_CONTROL_SUSPENSION += 10000f;
			}
			if (num9 == 3)
			{
				PLAYER_CONTROL_SUSPENSION += 15000f;
			}
			if (num9 == 4)
			{
				PLAYER_CONTROL_SUSPENSION += 20000f;
			}
		}
		RACE_MANAGER.CAR_LEVEL = 0;
		RACE_MANAGER.CAR_LEVEL = RACE_MANAGER.CAR_LEVEL + POWER_LEVEL + SPEED_LEVEL + CONTROL_LEVEL;
		RACE_MANAGER.CAR_LEVEL = RACE_MANAGER.CAR_LEVEL + num9 + num6 + num8 + num5 + num8 + num10;
		TRAFFIC_MANAGER.COMPLETE = false;
		TRAFFIC_MANAGER.FALIED = false;
	}

	public void CLOSE_NEWLEVEL()
	{
		AudioSource.PlayClipAtPoint(UI_CLICK, Camera.main.transform.position);
		if (MENU_MANAGER.APPODEAL_ADS_TIMER == 0f)
		{
			MENU_MANAGER.APPODEAL_ADS_TIMER = 40f;
		}
		NEW_LEVEL_XP_UI.SetActive(value: false);
		NEW_LVL_XP = false;
		xp_timer = 0f;
		XP_UI.SetActive(value: false);
		if ((PLAYER_LEVEL >= 10) & (ROAD_INFO == 1))
		{
			StartCoroutine(ROAD_OPEN_());
			ES2.Save(0, "ROAD_INFO");
		}
		HIDE_3D_ICONS();
		SHOW_3D_ICONS();
	}

	public void PAUSE_QUIT_()
	{
		PAUSE_MAIN.SetActive(value: false);
		PAUSE_EXIT.SetActive(value: true);
	}

	public void PAUSE_QUIT_YES()
	{
		Time.timeScale = 1f;
		TRAFFIC_MANAGER.NEED_QUIT = true;
		RACE_MANAGER.NEED_QUIT = true;
		if (START_RACE_FROM_MENU)
		{
			if (TRAFFIC_MANAGER.TRAFFIC_MODE || IN_RACE)
			{
				if (TRAFFIC_MANAGER.TRAFFIC_MODE)
				{
					base.gameObject.GetComponent<TRAFFIC_MANAGER>().CLOSE_FALIED();
				}
				else
				{
					RACE_MANGER_.GetComponent<RACE_MANAGER>().CLOSE_COMPLETE_();
				}
				Application.LoadLevel(0);
			}
			else
			{
				Application.LoadLevel(0);
			}
			return;
		}
		if (TRAFFIC_MANAGER.TRAFFIC_MODE || IN_RACE)
		{
			if (TRAFFIC_MANAGER.TRAFFIC_MODE)
			{
				base.gameObject.GetComponent<TRAFFIC_MANAGER>().CLOSE_FALIED();
			}
			else
			{
				RACE_MANGER_.GetComponent<RACE_MANAGER>().CLOSE_COMPLETE_();
			}
			Application.LoadLevel(1);
			return;
		}
		if (MENU_MANAGER.APPODEAL_ADS_TIMER == 0f)
		{
			int num = UnityEngine.Random.Range(0, 5);
			if (num == 1)
			{
				MENU_MANAGER.APPODEAL_ADS_TIMER = 40f;
			}
		}
		if (Application.isMobilePlatform && ES2.Load<int>("RATE_GAME") < 3)
		{
			ES2.Save(ES2.Load<int>("RATE_GAME") + 1, "RATE_GAME");
		}
		Application.LoadLevel(0);
	}

	public void PAUSE_QUIT_NO()
	{
		PAUSE_MAIN.SetActive(value: true);
		PAUSE_EXIT.SetActive(value: false);
	}

	public void PAUSE_RESTART_()
	{
		PAUSE_MAIN.SetActive(value: false);
		PAUSE_RESTART.SetActive(value: true);
	}

	public void PAUSE_RESTART_YES()
	{
		if (MENU_MANAGER.APPODEAL_ADS_TIMER == 0f)
		{
			int num = UnityEngine.Random.Range(0, 5);
			if (num == 1)
			{
				MENU_MANAGER.APPODEAL_ADS_TIMER = 40f;
			}
		}
		TRAFFIC_MANAGER.TRAFFIC_MODE = false;
		RACE_MANAGER.FINISH_RACE = false;
		RACE_MANAGER.START_RACE = false;
		START_RACE_FROM_MENU = false;
		if (TRAFFIC_MANAGER.TRAFFIC_MODE)
		{
			base.gameObject.GetComponent<TRAFFIC_MANAGER>().CLOSE_FALIED();
		}
		RESTORE_RACE = false;
		if (IN_RACE)
		{
			RACE_MANGER_.GetComponent<RACE_MANAGER>().CLOSE_COMPLETE_();
			RESTORE_RACE = true;
		}
		if (MENU_MANAGER.APPODEAL_ADS_TIMER == 0f)
		{
			int num2 = UnityEngine.Random.Range(0, 5);
			if (num2 == 1)
			{
				MENU_MANAGER.APPODEAL_ADS_TIMER = 40f;
			}
		}
		Application.LoadLevel(1);
	}

	public void PAUSE_RESTART_NO()
	{
		PAUSE_MAIN.SetActive(value: true);
		PAUSE_RESTART.SetActive(value: false);
	}

	public void PAUSE()
	{
		MUSIC_VOLUME = ES2.Load<float>("MUSIC_VOLUME");
		MAIN_VOLUME = ES2.Load<float>("MAIN_VOLUME");
		MAIN_VOLUME_SLIDER.value = MAIN_VOLUME * 10f;
		MUSIC_VOLUME_SLDIER.value = MUSIC_VOLUME * 10f;
		PAUSE_MAIN.SetActive(value: true);
		PAUSE_EXIT.SetActive(value: false);
		PAUSE_RESTART.SetActive(value: false);
		PAUSE_CANVAS.SetActive(value: true);
		CANVAS_.SetActive(value: false);
		CANVAS_2.SetActive(value: false);
		MAIN_.SetActive(value: true);
		OPTIONS_.SetActive(value: false);
		Time.timeScale = 0f;
		AudioListener.volume = 0f;
		AUDIOLISTENER_volume = 0f;
		Camera.main.GetComponent<ScreenFader>().enabled = false;
		Camera.main.GetComponent<CameraFilterPack_Blur_Blurry>().enabled = true;
	}

	public void TO_OPTIONS()
	{
		MAIN_.SetActive(value: false);
		OPTIONS_.SetActive(value: true);
	}

	public void TO_MAIN()
	{
		if (DISP_CHANGE)
		{
			float num = DISPLAY_RESOLUTION * 100f - 10f;
			Screen.SetResolution(SCR_X * (int)num / 100, SCR_Y * (int)num / 100, fullscreen: true);
			DISP_CHANGE = false;
		}
		MAIN_.SetActive(value: true);
		OPTIONS_.SetActive(value: false);
	}

	public void CHANGE_MAINVOLUME()
	{
		MAIN_VOLUME = MAIN_VOLUME_SLIDER.value / 10f;
		ES2.Save(MAIN_VOLUME, "MAIN_VOLUME");
	}

	public void CHANGE_MUSICVOLUME()
	{
		MUSIC_VOLUME = MUSIC_VOLUME_SLDIER.value / 10f;
		ES2.Save(MUSIC_VOLUME, "MUSIC_VOLUME");
	}

	public void CHANGE_DISPLAYRESOLUTION()
	{
		DISPLAY_RESOLUTION = DISPLAY_RES_SLIDER.value / 10f;
		ES2.Save(DISPLAY_RESOLUTION, "RESOLUTION");
		DISP_CHANGE = true;
	}

	public void SELECT_ARROWS()
	{
		RCC_Settings.Instance.mobileController = RCC_Settings.MobileController.TouchScreen;
		ES2.Save(1, "CONTROL");
		CONTROL.transform.localPosition = new Vector3(0f, 200f, 0f);
	}

	public void SELECT_WHEEL()
	{
		RCC_Settings.Instance.mobileController = RCC_Settings.MobileController.SteeringWheel;
		ES2.Save(0, "CONTROL");
		CONTROL.transform.localPosition = new Vector3(-185f, 200f, 0f);
	}

	public void SELECT_GYRO()
	{
		RCC_Settings.Instance.mobileController = RCC_Settings.MobileController.Gyro;
		ES2.Save(2, "CONTROL");
		CONTROL.transform.localPosition = new Vector3(185f, 200f, 0f);
	}

	public void RESUME()
	{
		AUDIOLISTENER_volume = MAIN_VOLUME;
		AudioListener.volume = AUDIOLISTENER_volume;
		PAUSE_CANVAS.SetActive(value: false);
		if (!TRAFFIC_MANAGER.TRAFFIC_MODE)
		{
			CANVAS_.SetActive(value: true);
		}
		CANVAS_2.SetActive(value: true);
		Time.timeScale = 1f;
		Camera.main.GetComponent<CameraFilterPack_Blur_Blurry>().enabled = false;
	}

	private IEnumerator SHOW_DRIFT_REC()
	{
		DRIFT_REC_UI.SetActive(value: true);
		AIR_REC_UI.SetActive(value: false);
		DESTROY_REC_UI.SetActive(value: false);
		yield return new WaitForSecondsRealtime(4f);
		DRIFT_REC_UI.SetActive(value: false);
	}

	private IEnumerator SHOW_AIR_REC()
	{
		AIR_REC_UI.SetActive(value: true);
		DESTROY_REC_UI.SetActive(value: false);
		DRIFT_REC_UI.SetActive(value: false);
		yield return new WaitForSecondsRealtime(4f);
		AIR_REC_UI.SetActive(value: false);
	}

	private IEnumerator SHOW_DESTROY_REC()
	{
		DESTROY_REC_UI.SetActive(value: true);
		AIR_REC_UI.SetActive(value: false);
		DRIFT_REC_UI.SetActive(value: false);
		yield return new WaitForSecondsRealtime(4f);
		DESTROY_REC_UI.SetActive(value: false);
	}

	private IEnumerator MONEY_COUR()
	{
		yield return new WaitForSecondsRealtime(2f);
		MONEY_IMG.transform.localScale = new Vector3(1f, 1f, 1f);
		MONEY_IMG.GetComponent<Animator>().enabled = false;
		if (PICKUP_INT > 0)
		{
			PICKUP_INT--;
		}
	}

	private IEnumerator WORD_OF_DAY_ON()
	{
		if (!SHOW_WORD)
		{
			WORD_OF_DAY_UI.SetActive(value: true);
			SHOW_WORD = true;
		}
		yield return new WaitForSecondsRealtime(10f);
		WORD_OF_DAY_UI.SetActive(value: false);
		SHOW_WORD_TODAY = true;
	}

	private IEnumerator SEED_COUR()
	{
		yield return new WaitForSecondsRealtime(2f);
		SEED_IMG.transform.localScale = new Vector3(1f, 1f, 1f);
		SEED_IMG.GetComponent<Animator>().enabled = false;
	}

	private void CHECK_XP()
	{
		if (SHOW_XP & (PLAYER_LEVEL < 71))
		{
			StartCoroutine(SHOW_XP_COUR());
			SHOW_XP = false;
		}
		if (!XP_UI.activeInHierarchy)
		{
			return;
		}
		RADIO_UI.SetActive(value: false);
		if (OLD_PROGRESS < PLAYER_LEVEL_PROGRESS)
		{
			CURRENT_XP_IMG.GetComponent<AudioSource>().enabled = true;
			OLD_PROGRESS += Time.deltaTime / 5f;
			CURRENT_XP_IMG.fillAmount = OLD_PROGRESS;
			if (OLD_PROGRESS > 0.99f)
			{
				CURRENT_XP_IMG.GetComponent<AudioSource>().enabled = false;
				OLD_PROGRESS = 0f;
				PLAYER_LEVEL_PROGRESS = 0f;
				PLAYER_LEVEL++;
				if (MENU_MANAGER.LANGUAGE == 1)
				{
					CURRENT_XP_TXT.text = PLAYER_LEVEL + " ур";
				}
				else
				{
					CURRENT_XP_TXT.text = PLAYER_LEVEL + " lv";
				}
				CURRENT_XP_IMG.fillAmount = 0f;
				ES2.Save(0f, "PLAYER_LEVEL_PROGRESS");
				ES2.Save(PLAYER_LEVEL, "PLAYER_LEVEL");
				XP_UI.SetActive(value: false);
				NEW_LEVEL_XP_UI.SetActive(value: true);
				NEW_LVL_XP = true;
				AWARD_NEW_LEVEL = PLAYER_LEVEL * 200;
				NEW_LEVEL_XP_AWARD.text = "+ " + AWARD_NEW_LEVEL;
				if (MENU_MANAGER.LANGUAGE == 1)
				{
					NEW_LEVEL_XP_LEVEL.text = PLAYER_LEVEL + " УРОВЕНЬ";
				}
				else
				{
					NEW_LEVEL_XP_LEVEL.text = PLAYER_LEVEL + " LEVEL";
				}
				PLAYER_MONEY += AWARD_NEW_LEVEL;
				ES2.Save(PLAYER_MONEY, "PLAYER_MONEY");
			}
		}
		else
		{
			CURRENT_XP_IMG.GetComponent<AudioSource>().enabled = false;
		}
	}

	private void FX()
	{
		if (LAGFREE_timer < 1f)
		{
			LAGFREE_timer += Time.deltaTime;
			if (LAGFREE_timer > 0.05f)
			{
				for (int i = 0; i < LAGSFREE_OBJECTS.Length; i++)
				{
					LAGSFREE_OBJECTS[i].SetActive(value: false);
				}
				LAGFREE_timer = 1f;
			}
		}
		if ((IN_RACE_POINT > 0) & !IN_RACE)
		{
			POINT_CAM_FX.SetActive(value: true);
			if (IN_RACE_POINT == 1)
			{
				POINT_CAM_FX.GetComponent<SpriteRenderer>().color = new Color(0f, 0.87f, 1f, 1f);
			}
			if (IN_RACE_POINT == 2)
			{
				POINT_CAM_FX.GetComponent<SpriteRenderer>().color = new Color(1f, 0.73f, 0f, 1f);
			}
			if (IN_RACE_POINT == 3)
			{
				POINT_CAM_FX.GetComponent<SpriteRenderer>().color = new Color(0f, 1f, 0f, 1f);
			}
		}
		else
		{
			POINT_CAM_FX.SetActive(value: false);
		}
		if (AUDIOLISTENER_volume < MAIN_VOLUME)
		{
			if ((AUDIOLISTENER_volume > 0.05f) & (AUDIOLISTENER_volume < 0.2f))
			{
			}
			AUDIOLISTENER_volume += Time.deltaTime / 3f;
			AudioListener.volume = AUDIOLISTENER_volume;
		}
		sky_rotate += Time.deltaTime / 1.3f;
		SKY_DAY.SetFloat("_Rotation", sky_rotate);
		CAM_PARTICLES.SetActive(value: true);
		if (IN_RAIN)
		{
			CAM_PARTICLES.SetActive(value: false);
		}
		if (IN_AIR)
		{
			if (IN_AIR && AUDIOLISTENER_volume > 0.3f)
			{
				AUDIOLISTENER_volume -= Time.deltaTime / 2f;
				AudioListener.volume = AUDIOLISTENER_volume;
			}
			BLUR_.enabled = true;
			BLUR_.Intensity = blur_int;
			if ((double)blur_int < 0.065)
			{
				blur_int += Time.deltaTime / 10f;
			}
		}
		else if (blur_int > 0f)
		{
			BLUR_.Intensity = blur_int;
			blur_int -= Time.deltaTime / 5f;
			if (blur_int < 0.001f)
			{
				BLUR_.enabled = false;
			}
		}
		if (IN_DEEP_WATER)
		{
			if (IN_RACE)
			{
				return;
			}
			WATER_SCREEN.SetActive(value: true);
			if ((water_level < 0.6f) & !IN_RACE)
			{
				if (MORE_WATER == 1)
				{
					water_level += Time.deltaTime / 12f;
				}
				else
				{
					water_level += Time.deltaTime / 6f;
				}
			}
			if ((water_level > 0.57f) & !CAR_WATER_)
			{
				CAR_WATER_ = true;
				if (Application.internetReachability != 0)
				{
					WATER_END_BUTTON_ADS.interactable = true;
				}
				else
				{
					WATER_END_BUTTON_ADS.interactable = false;
				}
				WATER_END_UI.SetActive(value: true);
				water_level = 0.57f;
				base.gameObject.GetComponent<TAXI_MANAGER>().END_FUEL();
				base.gameObject.GetComponent<MEDIC_MANAGER>().END_FUEL();
				base.gameObject.GetComponent<COP_MANAGER>().END_FUEL();
			}
			WATER_SCREEN.transform.localPosition = new Vector3(0f, -1.45f + water_level, 0.5f);
		}
		else
		{
			WATER_SCREEN.transform.localPosition = new Vector3(0f, -1.45f + water_level, 0.5f);
			if (water_level > 0f)
			{
				water_level -= Time.deltaTime / 8f;
			}
			if (water_level < 0.01f)
			{
				WATER_SCREEN.SetActive(value: false);
			}
		}
	}

	private void UI()
	{
		if (cam_fx_alpha > 0f)
		{
			CAM_FX.SetActive(value: true);
			cam_fx_alpha -= Time.deltaTime / 3f;
			if (Time.frameCount % 3 == 0)
			{
				CAM_FX.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, cam_fx_alpha);
			}
			if (cam_fx_alpha < 0.02f)
			{
				cam_fx_alpha = 0f;
				CAM_FX.SetActive(value: false);
			}
		}
		if (cam_fx_alpha2 > 0f)
		{
			CAM_FX2.SetActive(value: true);
			cam_fx_alpha2 -= Time.deltaTime;
			if (Time.frameCount % 3 == 0)
			{
				CAM_FX2.GetComponent<SpriteRenderer>().color = new Color(0f, 0.75f, 1f, cam_fx_alpha2);
			}
			if (cam_fx_alpha2 < 0.02f)
			{
				cam_fx_alpha2 = 0f;
				CAM_FX2.SetActive(value: false);
			}
		}
		if (RCC_CarControllerV3.BOOST_ && cam_fx_alpha2 < 1f)
		{
			cam_fx_alpha2 += Time.deltaTime * 3f;
		}
		NOS_IMG.fillAmount = RCC_CarControllerV3.NOS_;
		if (RCC_CarControllerV3.NOS_ > 0.99f)
		{
			NOS_FULL_IMG.SetActive(value: true);
		}
		else
		{
			NOS_FULL_IMG.SetActive(value: false);
		}
		if ((PLAYER_FUEL < 0.2f) & (PLAYER_FUEL > 0f))
		{
			fuel_level_timer += Time.deltaTime / 2f;
			if (fuel_level_timer > 0.4f)
			{
				LOW_FUEL_OBj.SetActive(value: false);
				FUEL_IMG.color = new Color(1f, 1f, 1f);
			}
			else
			{
				LOW_FUEL_OBj.SetActive(value: true);
				FUEL_IMG.color = new Color(1f, 0f, 0f);
				if ((PLAYER_FUEL < 0.01f) & !FUEL_END_UI.activeInHierarchy)
				{
					if (Application.internetReachability != 0)
					{
						FUEL_END_BUTTON_ADS.interactable = true;
					}
					else
					{
						FUEL_END_BUTTON_ADS.interactable = false;
					}
					FUEL_END_UI.SetActive(value: true);
					PLAYER_FUEL = 0f;
					base.gameObject.GetComponent<TAXI_MANAGER>().END_FUEL();
					base.gameObject.GetComponent<MEDIC_MANAGER>().END_FUEL();
					base.gameObject.GetComponent<COP_MANAGER>().END_FUEL();
					return;
				}
			}
			if (fuel_level_timer > 1f)
			{
				AudioSource.PlayClipAtPoint(LOW_FUEL, Camera.main.transform.position);
				fuel_level_timer = 0f;
			}
		}
		else
		{
			fuel_level_timer = 0f;
			LOW_FUEL_OBj.SetActive(value: false);
		}
		if (Time.frameCount % 10 != 0)
		{
			return;
		}
		FUEL_IMG.fillAmount = PLAYER_FUEL;
		if (Time.frameCount % 10 == 0)
		{
			if (PLAYER_FUEL < 0.4f)
			{
				FUEL_IMG.color = new Color(1f, 1f, 0f);
			}
			else
			{
				FUEL_IMG.color = new Color(1f, 1f, 1f);
			}
			if ((PLAYER_FUEL < 0.2f) & (fuel_level_timer == 0f))
			{
				FUEL_IMG.color = new Color(1f, 0f, 0f);
			}
		}
		SEED_TEXT.text = string.Empty + PLAYER_SEED;
		MONEY_TEXT.text = string.Empty + PLAYER_MONEY;
	}

	public void FUEL_ADS()
	{
		MENU_MANAGER.APPODEAL_ADS_TIMER = 30f;
		Camera.main.GetComponent<ScreenFader>().enabled = true;
		Camera.main.GetComponent<ScreenFader>().RS();
		FUEL_END_UI.SetActive(value: false);
		PLAYER_FUEL = 1f;
		AudioSource.PlayClipAtPoint(FUEL_SND, Camera.main.transform.position);
		PLAYER_.GetComponent<RCC_CarControllerV3>().canControl = true;
	}

	public void FUEL_MONEY()
	{
		Camera.main.GetComponent<ScreenFader>().enabled = true;
		Camera.main.GetComponent<ScreenFader>().RS();
		FUEL_END_UI.SetActive(value: false);
		PLAYER_FUEL = 1f;
		AudioSource.PlayClipAtPoint(FUEL_SND, Camera.main.transform.position);
		PLAYER_.GetComponent<RCC_CarControllerV3>().canControl = true;
		PLAYER_MONEY -= 250;
		ES2.Save(PLAYER_MONEY, "PLAYER_MONEY");
	}

	public void WATER_ADS()
	{
		MENU_MANAGER.APPODEAL_ADS_TIMER = 30f;
		Camera.main.GetComponent<ScreenFader>().enabled = true;
		Camera.main.GetComponent<ScreenFader>().RS();
		WATER_END_UI.SetActive(value: false);
		AudioSource.PlayClipAtPoint(WATER_SND, Camera.main.transform.position);
		if (MENU_MANAGER.LOADING_LEVEL == 0)
		{
			SET_RANDROM_POSITION();
		}
		else
		{
			SET_RANDROM_POSITION2();
		}
		CAR_WATER_ = false;
		water_level = 0f;
		IN_DEEP_WATER = false;
		IN_WATER = false;
	}

	public void WATER_MONEY()
	{
		Camera.main.GetComponent<ScreenFader>().enabled = true;
		Camera.main.GetComponent<ScreenFader>().RS();
		if (MENU_MANAGER.LOADING_LEVEL == 0)
		{
			SET_RANDROM_POSITION();
		}
		else
		{
			SET_RANDROM_POSITION2();
		}
		WATER_END_UI.SetActive(value: false);
		water_level = 0f;
		IN_DEEP_WATER = false;
		IN_WATER = false;
		CAR_WATER_ = false;
		AudioSource.PlayClipAtPoint(WATER_SND, Camera.main.transform.position);
		PLAYER_MONEY -= 250;
		ES2.Save(PLAYER_MONEY, "PLAYER_MONEY");
	}

	private IEnumerator GEAR_()
	{
		CUR_GEAR_TXT.text = string.Empty + ES2.Load<int>("PLAYER_GEAR");
		CURRENT_GEAR_UI.SetActive(value: true);
		CURRENT_GEAR_UI.GetComponent<Animator>().SetBool("PLAY", value: true);
		yield return new WaitForSecondsRealtime(6f);
		CURRENT_GEAR_UI.SetActive(value: false);
	}

	private void PICKUP()
	{
		if (GET_HEL)
		{
			PLAYER_LEVEL_PROGRESS += 0.05f;
			ES2.Save(PLAYER_LEVEL_PROGRESS, "PLAYER_LEVEL_PROGRESS");
			SHOW_XP = true;
			GET_HEL = false;
		}
		if (GET_GEAR)
		{
			StartCoroutine(GEAR_());
			GET_GEAR = false;
		}
		if (FUEL_DESTROY)
		{
			if (MENU_MANAGER.LANGUAGE == 1 && !fv)
			{
				VOICE_OBJ.GetComponent<AudioSource>().clip = VOICE_FUEL[UnityEngine.Random.Range(0, VOICE_FUEL.Length)];
				VOICE_OBJ.GetComponent<AudioSource>().Play();
				fv = true;
			}
			if (PLAYER_FUEL < 1f)
			{
				PLAYER_FUEL += Time.deltaTime / 10f;
				FUEL_IMG.fillAmount = PLAYER_FUEL;
				if (PLAYER_FUEL < 0.6f)
				{
					FUEL_IMG.color = new Color(1f, 1f, 0f);
				}
				else
				{
					FUEL_IMG.color = new Color(1f, 1f, 1f);
				}
				if (PLAYER_FUEL < 0.3f)
				{
					FUEL_IMG.color = new Color(1f, 0f, 0f);
				}
			}
			if (PLAYER_FUEL > 0.99f)
			{
				fv = false;
				FUEL_DESTROY = false;
			}
		}
		if (SEED_DESTROY)
		{
			CHECK_SEED = true;
			SEED_IMG.GetComponent<Animator>().enabled = true;
			SEED_IMG.GetComponent<Animator>().SetBool("PLAY", value: true);
			if (MORE_SEED == 1)
			{
				PLAYER_SEED++;
				PLAYER_SEED++;
			}
			else
			{
				PLAYER_SEED++;
			}
			cam_fx_alpha = 0.6f;
			ES2.Save(PLAYER_SEED, "PLAYER_SEED");
			SEED_DESTROY = false;
			StartCoroutine(SEED_COUR());
		}
		if (MONEY_DESTROY)
		{
			PICKUP_INT++;
			if (PICKUP_INT > 7)
			{
				PICKUP_INT = 7;
			}
			AudioSource.PlayClipAtPoint(PICKUP_SND[PICKUP_INT], Camera.main.transform.position);
			MONEY_IMG.GetComponent<Animator>().enabled = true;
			MONEY_IMG.GetComponent<Animator>().SetBool("PLAY", value: true);
			if (PLAYER_LEVEL < 10)
			{
				if (MORE_COIN == 1)
				{
					PLAYER_MONEY++;
					PLAYER_MONEY++;
				}
				else
				{
					PLAYER_MONEY++;
				}
			}
			else if (MORE_COIN == 1)
			{
				PLAYER_MONEY += COIN_MULTIPLAYER;
				PLAYER_MONEY += COIN_MULTIPLAYER;
			}
			else
			{
				PLAYER_MONEY += COIN_MULTIPLAYER;
			}
			ADD_COINS++;
			cam_fx_alpha = 0.6f;
			ES2.Save(PLAYER_MONEY, "PLAYER_MONEY");
			MONEY_DESTROY = false;
			StartCoroutine(MONEY_COUR());
		}
		if (HIT_SND > 0)
		{
			if (HIT_SND == 1)
			{
				HIT_RND = UnityEngine.Random.Range(0, 3);
				AudioSource.PlayClipAtPoint(FENCE_[HIT_RND], Camera.main.transform.position);
			}
			if (HIT_SND == 2)
			{
				AudioSource.PlayClipAtPoint(METAL_1, Camera.main.transform.position);
			}
			if (HIT_SND == 3)
			{
				HIT_RND = UnityEngine.Random.Range(0, 2);
				AudioSource.PlayClipAtPoint(TRASH_[HIT_RND], Camera.main.transform.position);
			}
			if (HIT_SND == 4)
			{
				HIT_RND = UnityEngine.Random.Range(0, 3);
				AudioSource.PlayClipAtPoint(LIGHT_[HIT_RND], Camera.main.transform.position);
			}
			if (HIT_SND == 5)
			{
				HIT_RND = UnityEngine.Random.Range(0, 3);
				AudioSource.PlayClipAtPoint(STRAW_[HIT_RND], Camera.main.transform.position);
			}
			if (HIT_SND == 6)
			{
				HIT_RND = UnityEngine.Random.Range(0, 2);
				AudioSource.PlayClipAtPoint(BARREL_[HIT_RND], Camera.main.transform.position);
			}
			if (HIT_SND == 7)
			{
				HIT_RND = UnityEngine.Random.Range(0, 3);
				AudioSource.PlayClipAtPoint(BOX_[HIT_RND], Camera.main.transform.position);
			}
			if (HIT_SND == 9)
			{
				AudioSource.PlayClipAtPoint(HYDRANT_SND, Camera.main.transform.position);
			}
			HIT_SND = 0;
		}
		if (SCREEN_FRUIT_FX > 0)
		{
			SPLAT_RND = UnityEngine.Random.Range(0, 2);
			if (SPLAT_RND == 0)
			{
				AudioSource.PlayClipAtPoint(SPLAT_1, Camera.main.transform.position);
			}
			else
			{
				AudioSource.PlayClipAtPoint(SPLAT_2, Camera.main.transform.position);
			}
			GameObject gameObject = UnityEngine.Object.Instantiate(FRUIT_SCR_FX, base.transform.position, base.transform.rotation);
			gameObject.transform.SetParent(Camera.main.transform, worldPositionStays: false);
			if (SCREEN_FRUIT_FX == 1)
			{
				gameObject.GetComponent<Fruit_screen_Fx>().SETCOLOR(new Color(1f, 0.88f, 0f));
			}
			if (SCREEN_FRUIT_FX == 2)
			{
				gameObject.GetComponent<Fruit_screen_Fx>().SETCOLOR(new Color(0.77f, 1f, 0f));
			}
			if (SCREEN_FRUIT_FX == 3)
			{
				gameObject.GetComponent<Fruit_screen_Fx>().SETCOLOR(new Color(0f, 0.97f, 0.5f));
			}
			SCREEN_FRUIT_FX = 0;
		}
	}

	public void CLOSE_ROAD()
	{
		AudioSource.PlayClipAtPoint(UI_CLICK, Camera.main.transform.position);
		ROAD_CLOSED_ui.SetActive(value: false);
		ROAD_OPEN_ui.SetActive(value: false);
		TAXI_MANAGER.PASSENGER_FAIL = false;
	}

	public void SET_ZOOM_MAP()
	{
		AudioSource.PlayClipAtPoint(UI_CLICK2, Camera.main.transform.position);
		ZOOM_MAP = !ZOOM_MAP;
	}

	private IEnumerator SHOW_XP_COUR()
	{
		OLD_PROGRESS = PLAYER_LEVEL_PROGRESS;
		if (PLAYER_LEVEL == 0)
		{
			if (AFTER_RACE)
			{
				NEW_XP = (PLAYER_LEVEL_PROGRESS += 0.5f);
			}
			else
			{
				NEW_XP = (PLAYER_LEVEL_PROGRESS += 0.25f);
			}
		}
		else
		{
			if (AFTER_RACE)
			{
				G = (float)PLAYER_LEVEL / 2.7f;
				if (PLAYER_LEVEL == 1)
				{
					G = 1.3f;
				}
				if (PLAYER_LEVEL == 2)
				{
					G = 1.4f;
				}
				if (PLAYER_LEVEL == 3)
				{
					G = 1.5f;
				}
				if (PLAYER_LEVEL == 4)
				{
					G = 1.6f;
				}
			}
			else
			{
				G = (float)PLAYER_LEVEL / 2f;
				if (PLAYER_LEVEL == 1)
				{
					G = 1.5f;
				}
				if (PLAYER_LEVEL == 2)
				{
					G = 1.7f;
				}
				if (PLAYER_LEVEL == 3)
				{
					G = 2.1f;
				}
				if (PLAYER_LEVEL == 4)
				{
					G = 2.3f;
				}
			}
			if (MORE_XP > 0)
			{
				if (MORE_XP == 1)
				{
					NEW_XP = (PLAYER_LEVEL_PROGRESS += 0.65f / G);
				}
				if (MORE_XP == 2)
				{
					NEW_XP = (PLAYER_LEVEL_PROGRESS += 0.75f / G);
				}
			}
			else
			{
				NEW_XP = (PLAYER_LEVEL_PROGRESS += 0.55f / G);
			}
		}
		ES2.Save(NEW_XP, "PLAYER_LEVEL_PROGRESS");
		PLAYER_LEVEL_PROGRESS = ES2.Load<float>("PLAYER_LEVEL_PROGRESS");
		XP_UI.SetActive(value: false);
		XP_UI.SetActive(value: true);
		if (MENU_MANAGER.LANGUAGE == 1)
		{
			CURRENT_XP_TXT.text = PLAYER_LEVEL + " ур.";
		}
		else
		{
			CURRENT_XP_TXT.text = PLAYER_LEVEL + " lv";
		}
		CURRENT_XP_IMG.fillAmount = OLD_PROGRESS;
		yield return new WaitForSecondsRealtime(15f);
		XP_UI.SetActive(value: false);
	}
}
