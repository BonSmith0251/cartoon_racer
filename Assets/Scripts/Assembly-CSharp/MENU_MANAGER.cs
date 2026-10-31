using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MENU_MANAGER : MonoBehaviour
{
	public GameObject BIRD_UI;

	public Text BIRD_RECORD;

	public static float APPODEAL_ADS_TIMER;

	public static bool CONNECT_GPG;

	public GameObject FREE_MONEY_UI;

	public GameObject FREE_DETAIL_UI;

	public GameObject SHOPFREE_MONEY_LOADING;

	public GameObject SHOPFREE_DETAIL_LOADING;

	public GameObject SHOPFREE_MONEY;

	public GameObject SHOPFREE_DETAIL;

	public Text LOADING_LOCATION;

	public GameObject RATE_GAME_UI;

	public GameObject TUTORIAL;

	public GameObject TUTORIAL2;

	public GameObject TUTORIAL3;

	public GameObject TUTORIAL4;

	public GameObject TUTORIAL5;

	public GameObject TUTORIAL6;

	public GameObject TUTORIAL7;

	public GameObject BUY_CAR_BEFORE;

	public Scrollbar SCROLL;

	public GameObject GDPR_UI;

	public GameObject GDPC_CANCEL_UI;

	public GameObject GDPC_ACCEPT_UI;

	public GameObject POLITIC_UI;

	public static int LANGUAGE;

	public static int SELECT_SCHOOL_;

	public Text GAME_CURRENT_MONEY_TXT;

	public Text GAME_CURRENT_LEVEL_TXT;

	public Text GAME_CURRENT_GEAR_TXT;

	public Image GAME_CURRENT_XP_IMG;

	public GameObject TAXI_PROGRESS;

	public GameObject MED_PROGRESS;

	public GameObject COP_PROGRESS;

	public GameObject TAXI_AVAIBLE;

	public GameObject TAXI_NO_AVAIBLE;

	public GameObject TAXI_COMPLETE;

	public GameObject MED_AVAIBLE;

	public GameObject MED_NO_AVAIBLE;

	public GameObject MED_COMPLETE;

	public GameObject COP_AVAIBLE;

	public GameObject COP_NO_AVAIBLE;

	public GameObject COP_COMPLETE;

	public GameObject FARM_NO_AVAILBE;

	public GameObject SCHOOL_MENU;

	public GameObject SCHOOL_TAXI;

	public GameObject SCHOOL_MEDIC;

	public GameObject SCHOOL_COP;

	public Button SELECT_SCHOOL;

	public AudioClip BUY_CAR_VOICE;

	public AudioClip VOICE_BONUS;

	public AudioClip[] VOICE_WELCOME;

	private float DISPLAY_RESOLUTION;

	private int SCR_X;

	private int SCR_Y;

	public GameObject LOADING_CANVAS;

	public GameObject TIRE_SMOKE_3D;

	public GameObject BUY_FX2;

	public GameObject BUY_FX;

	public GameObject EFFECT_SPAWN;

	public GameObject[] GARAGE_CARS;

	public GameObject[] CHARACTERS;

	public GameObject MENU_CAR;

	public GameObject GAMECAMERA;

	public GameObject MAINCAMERA;

	public GameObject DRIVERCAMERA;

	public GameObject GARAGECAMERA;

	public GameObject FARMCAMERA;

	public GameObject SHOPCAMERA;

	public static GameObject CURRENT_CAR_OBJ;

	public GameObject CARINFO_UI;

	public GameObject BUYCAR_UI;

	public GameObject NEWCAR_POPUP;

	public GameObject ZAMOK_IMAGE;

	public GameObject NEED_LEVEL_POPUP;

	public GameObject BYED_OBJ;

	public GameObject COST_OBJ;

	public GameObject UPGARDE_OBJ;

	public GameObject TUNING_OBJ;

	public GameObject[] CARINFO_POWER;

	public GameObject[] CARINFO_SPEED;

	public GameObject[] CARINFO_CONTROL;

	public GameObject BUYCAR_BUTTON;

	public GameObject SELECT_BUTTON;

	public GameObject CURRENT_CAR;

	public Image CURRENT_XP_IMG;

	public Image CURRENT_XP_IMG2;

	public Text BUYCAR_TEXT;

	public Text NEEDLV_TXT;

	public Sprite BUYCAR_AVAILIBLE;

	public Sprite BUYCAR_NOT_AVAILIBLE;

	public Button START_BUTTON;

	public Sprite START_BUTTON_ON;

	public Sprite START_BUTTON_OFF;

	public GameObject FARM_LOC;

	public GameObject CITY_LOC;

	public GameObject OPTIONS_MENU;

	public GameObject MAINMENU_UI;

	public GameObject STARTMENU_UI;

	public GameObject CITYLOCKED_UI;

	public GameObject RACEMENU_UI;

	public GameObject GAMEMENU_UI;

	public GameObject BONUSMENU_UI;

	public GameObject DRIVERMENU_UI;

	public GameObject GARAGEMENU_UI;

	public GameObject UPGRADEMENU_UI;

	public GameObject TUNINGMENU_UI;

	public GameObject BONUSGET_UI;

	public GameObject FARMMENU_UI;

	public GameObject SHOPMENU_UI;

	public GameObject TARGETS_UI;

	public GameObject SHOP_MONEY_MENU;

	public GameObject SHOP_GEAR_MENU;

	public GameObject SHOP_COIN_BUTTON;

	public GameObject SHOP_GEAR_BUTTON;

	public Sprite SHOP_AVAILIBLE;

	public Sprite SHOP_NOT_AVAILIBLE;

	public Text SHOP_CURRENT_SEED_TXT;

	public Text SHOP_CURRENT_MONEY_TXT;

	public Text SHOP_CURRENT_LEVEL_TXT;

	public Text SHOP_CURRENT_GEAR_TXT;

	public Image SHOP_CURRENT_XP_IMG;

	public Button BONUS_BUTTON;

	public Sprite planka_power;

	public Sprite planka_speed;

	public Sprite planka_control;

	public Sprite planka_off;

	public Text BONUS_TXT;

	public Text CURRENT_MONEY_TXT;

	public Text CURRENT_MONEY_TXT2;

	public Text CURRENT_MONEY_TXT3;

	public Text CURRENT_LV_TXT;

	public Text CURRENT_LV_TXT2;

	public Text MONEY_ADD_BONUS_TXT;

	public Text GARAGE_CAR_NAME;

	public Text GARAGE_CAR_COST;

	public AudioClip BACK_SND;

	public AudioClip NEXT_SND;

	public AudioClip CLICK_SND;

	public AudioClip MONEY_SND;

	public AudioClip CARCHANGE_SND;

	public AudioClip BUY_CAR_SND;

	public AudioClip CAR_SND;

	private int CAR_COST;

	private int CAR_POWER_INT;

	private int CAR_SPEED_INT;

	private int CAR_CONTROL_INT;

	public static int LOADING_LEVEL;

	public static int PLAYER_LEVEL;

	public static int MONEY_;

	public static bool BONUS_AVAILABLE;

	private int OLD_MONEY_;

	private bool ADD_MONEY_;

	private int CURRENT_MONEY;

	public static int SPAWN_CAR_;

	private int SELECTED_CAR;

	private float TIMER_;

	private string string1;

	private string string2;

	private int CAR_LEVEL;

	private float XaxisRotation;

	private const string NextRewardTimePPK = "";

	private int CAR_1;

	private int CAR_2;

	private int CAR_3;

	private int CAR_4;

	private int CAR_5;

	private int CAR_6;

	private int CAR_7;

	private int CAR_8;

	private int CAR_9;

	private int CAR_10;

	public Material SKY_DAY;

	private float sky_rotate;

	public Button SELECT_SCHOOL_BUTTON;

	public Text SCHOOL_TEXT;

	private int JJA;

	public GameObject START_UI;

	public GameObject SELECT_ENG;

	public GameObject SELECT_RUS;

	public Button CONTINUE_BUTTON;

	public Text CONTINUE_BUTTON_TXT;

	public Text TITLE_TXT;

	public GameObject QUIT_MENU;

	public GameObject ACHIV_MENU;

	public DateTime NextRewardTime => GetNextRewardTime();

	public TimeSpan TimeUntilReward => NextRewardTime.Subtract(DateTime.Now);

	private void Awake()
	{
		if (!ES2.Exists("POLITIC"))
		{
			MAINMENU_UI.SetActive(value: false);
			ES2.Save(0, "POLITIC_RESULT");
			ES2.Save(0, "GDPR");
			ES2.Save(1, "POLITIC");
			ES2.Save(0, "LANGUAGE");
			ES2.Save(0, "RUS_VOICE");
		}
		if (ES2.Load<int>("POLITIC_RESULT") == 0)
		{
			ES2.Save(1, "POLITIC_RESULT");
			START_UI.SetActive(value: true);
			base.enabled = false;
		}
		else if (ES2.Load<int>("LANGUAGE") == 0)
		{
			LANGUAGE = 0;
		}
		else
		{
			LANGUAGE = 1;
		}
	}

	public void CONTINUE()
	{
		if (SELECT_RUS.activeInHierarchy)
		{
			ES2.Save(1, "LANGUAGE");
			ES2.Save(1, "RUS_VOICE");
			LANGUAGE = 1;
		}
		else
		{
			ES2.Save(0, "LANGUAGE");
			ES2.Save(0, "RUS_VOICE");
			LANGUAGE = 0;
		}
		Application.LoadLevel(0);
	}

	public void SELECT_ENG_()
	{
		SELECT_ENG.SetActive(value: true);
		SELECT_RUS.SetActive(value: false);
		CONTINUE_BUTTON.interactable = true;
		TITLE_TXT.text = "SELECT LANGUAGE";
		CONTINUE_BUTTON_TXT.text = "CONTINUE";
		CONTINUE_BUTTON_TXT.color = new Color(1f, 1f, 1f, 1f);
	}

	public void SELECT_RUS_()
	{
		SELECT_ENG.SetActive(value: false);
		SELECT_RUS.SetActive(value: true);
		CONTINUE_BUTTON.interactable = true;
		TITLE_TXT.text = "ВЫБОР ЯЗЫКА";
		CONTINUE_BUTTON_TXT.text = "ПРОДОЛЖИТЬ";
		CONTINUE_BUTTON_TXT.color = new Color(1f, 1f, 1f, 1f);
	}

	public void OPEN_URL(string URL)
	{
		Application.OpenURL(URL);
	}

	public void ACCEPT_POLITIC()
	{
		ES2.Save(1, "POLITIC_RESULT");
		POLITIC_UI.SetActive(value: false);
		GDPR_UI.SetActive(value: true);
	}

	public void CANCEL_GDPR()
	{
		ES2.Save(0, "GDPR");
		GDPR_UI.SetActive(value: false);
		GDPC_CANCEL_UI.SetActive(value: true);
	}

	public void ACCEPT_GDPR()
	{
		ES2.Save(1, "GDPR");
		GDPR_UI.SetActive(value: false);
		GDPC_ACCEPT_UI.SetActive(value: true);
	}

	public void CLOSE_GDPR()
	{
		GDPC_CANCEL_UI.SetActive(value: false);
		GDPC_ACCEPT_UI.SetActive(value: false);
		START_UI.SetActive(value: true);
	}

	public void WATCH_FREE_MONEY()
	{
		ES2.Save(DateTime.Now.ToShortDateString(), "FREE_MONEY_SHOP");
		FREE_MONEY_UI.SetActive(value: false);
		SHOPFREE_MONEY.SetActive(value: false);
		SHOPFREE_MONEY_LOADING.SetActive(value: false);
		ES2.Save(ES2.Load<int>("PLAYER_MONEY") + 250, "PLAYER_MONEY");
		SHOP_CURRENT_MONEY_TXT.text = string.Empty + ES2.Load<int>("PLAYER_MONEY");
	}

	public void CANCEL_FREE_MONEY()
	{
		FREE_MONEY_UI.SetActive(value: false);
	}

	public void WATCH_FREE_DETAIL()
	{
		ES2.Save(DateTime.Now.ToShortDateString(), "FREE_DETAIL_SHOP");
		FREE_DETAIL_UI.SetActive(value: false);
		SHOPFREE_DETAIL.SetActive(value: false);
		SHOPFREE_DETAIL_LOADING.SetActive(value: false);
		ES2.Save(ES2.Load<int>("PLAYER_GEAR") + 10, "PLAYER_GEAR");
		SHOP_CURRENT_GEAR_TXT.text = string.Empty + ES2.Load<int>("PLAYER_GEAR");
	}

	public void CANCEL_FREE_DETAIL()
	{
		FREE_DETAIL_UI.SetActive(value: false);
	}

	private void Start()
	{
		GAME_MANAGER.START_RACE_FROM_MENU = false;
		if (!ES2.Exists("DEFAULT_CONFIG_6"))
		{
			for (int i = 0; i < 36; i++)
			{
				ES2.Save(0, "MISSION_" + i);
			}
			ES2.Save(param: true, "DEFAULT_CONFIG_6");
		}
		if (!ES2.Exists("DEFAULT_CONFIG_4"))
		{
			ES2.Save(0, "BEST_SCORE");
			ES2.Save(0, "CUR_SCORE");
			ES2.Save(0, "VILLY_TUTORIAL");
			ES2.Save(1, "VSYNC");
			ES2.Save(param: true, "DEFAULT_CONFIG_4");
		}
		if (!ES2.Exists("DEFAULT_CONFIG_3"))
		{
			ES2.Save(0, "CAR9");
			ES2.Save(0, "CAR9_ENGINE");
			ES2.Save(0, "CAR9_TIRES");
			ES2.Save(0, "CAR9_KPP");
			ES2.Save(0, "CAR9_BRAKES");
			ES2.Save(0, "CAR9_NITRO");
			ES2.Save(0, "CAR9_SUSP");
			ES2.Save(0, "CAR9_WEIGHT");
			ES2.Save(0, "CAR10");
			ES2.Save(0, "CAR10_ENGINE");
			ES2.Save(0, "CAR10_TIRES");
			ES2.Save(0, "CAR10_KPP");
			ES2.Save(0, "CAR10_BRAKES");
			ES2.Save(0, "CAR10_NITRO");
			ES2.Save(0, "CAR10_SUSP");
			ES2.Save(0, "CAR10_WEIGHT");
			ES2.Save(5, "CAR9_FRONT");
			ES2.Save(5, "CAR9_BACK");
			ES2.Save(5, "CAR9_MIDDLE");
			ES2.Save(2, "CAR9_WHEELS");
			ES2.Save(0, "CAR9_CAMBER");
			ES2.Save(1f, "CAR9_LIGHT_R");
			ES2.Save(1f, "CAR9_LIGHT_G");
			ES2.Save(1f, "CAR9_LIGHT_B");
			ES2.Save(0, "CAR9_LIGHT");
			ES2.Save("ABGAMES89", "CAR9_NAME");
			ES2.Save(6, "CAR10_FRONT");
			ES2.Save(6, "CAR10_BACK");
			ES2.Save(6, "CAR10_MIDDLE");
			ES2.Save(2, "CAR10_WHEELS");
			ES2.Save(0, "CAR10_CAMBER");
			ES2.Save(1f, "CAR10_LIGHT_R");
			ES2.Save(1f, "CAR10_LIGHT_G");
			ES2.Save(1f, "CAR10_LIGHT_B");
			ES2.Save(0, "CAR10_LIGHT");
			ES2.Save("ABGAMES89", "CAR10_NAME");
			ES2.Save(param: true, "DEFAULT_CONFIG_3");
		}
		if (!ES2.Exists("DEFAULT_CONFIG"))
		{
			ES2.Save(0, "DRIFT_REC");
			ES2.Save(0, "DESTROY_REC");
			ES2.Save(0, "AIR_REC");
			ES2.Save(Screen.width, "DISPLAY_X");
			ES2.Save(Screen.height, "DISPLAY_Y");
			ES2.Save(string.Empty, "FREE_MONEY_SHOP");
			ES2.Save(string.Empty, "FREE_DETAIL_SHOP");
			ES2.Save(0.8f, "RESOLUTION");
			ES2.Save(3, "TEXTURES");
			ES2.Save(2, "VIEW_DISTANCE");
			ES2.Save(2, "WATER_QUALITY");
			ES2.Save(2, "TERRAIN");
			ES2.Save(1, "FILTER");
			ES2.Save(1, "SHADOW");
			ES2.Save(1, "SKIDMARK");
			ES2.Save(0, "BLOOMFX");
			ES2.Save(1, "CONTROL");
			ES2.Save(1f, "SPEED_CONTROL");
			ES2.Save(1f, "SPEED_TILT");
			ES2.Save(1f, "WHEEL_SIZE");
			ES2.Save(1f, "MAIN_VOLUME");
			ES2.Save(0.65f, "MUSIC_VOLUME");
			ES2.Save(0.65f, "RADIO_VOLUME");
			ES2.Save(1, "MUSIC_TRACK");
			ES2.Save(1, "TRAFFIC");
			ES2.Save(1, "VIEW");
			ES2.Save(0, "VIBRO");
			ES2.Save(1, "RAIN");
			ES2.Save(0, "BENCHMARK");
			ES2.Save(0, "PLAYER_SEED");
			ES2.Save(1f, "WATER");
			ES2.Save(0, "PLAYER_GEAR");
			ES2.Save(3500, "PLAYER_MONEY");
			ES2.Save(0, "ALL_MONEY");
			ES2.Save(0, "SALE_ALL");
			ES2.Save(0, "DAY_ALL");
			ES2.Save(0, "ALL_EVENTS");
			ES2.Save(0, "PLAYER_LEVEL");
			ES2.Save(0f, "PLAYER_LEVEL_PROGRESS");
			ES2.Save(0, "SELECT_CAR");
			ES2.Save(0, "SELECT_CHARACTER");
			ES2.Save(0, "TAXI_DRIVER_LEVEL");
			ES2.Save(0f, "TAXI_DRIVER_PROGRESS");
			ES2.Save(0, "MEDIC_DRIVER_LEVEL");
			ES2.Save(0f, "MEDIC_DRIVER_PROGRESS");
			ES2.Save(0, "COP_DRIVER_LEVEL");
			ES2.Save(0f, "COP_DRIVER_PROGRESS");
			ES2.Save(0, "END_GAME");
			ES2.Save(0, "RATE_GAME");
			ES2.Save(0, "TUTORIAL_1");
			ES2.Save(0, "TUTORIAL_2");
			ES2.Save(0, "TUTORIAL_3");
			ES2.Save(0, "TUTORIAL_4");
			ES2.Save(0, "TUTORIAL_5");
			ES2.Save(0, "TUTORIAL_6");
			ES2.Save(0, "TUTORIAL_7");
			ES2.Save(0, "TUTORIAL_8");
			ES2.Save(0, "TUTORIAL_9");
			ES2.Save(0, "TUTORIAL_10");
			ES2.Save(0, "TUTORIAL_11");
			ES2.Save(0, "ROAD_INFO");
			ES2.Save(0, "TUTORIAL_12");
			ES2.Save(0, "TUTORIAL_13");
			ES2.Save(0, "TUTORIAL_14");
			ES2.Save(0, "TUTORIAL_15");
			ES2.Save(0, "TUTORIAL_16");
			ES2.Save(0, "TUTORIAL_17");
			ES2.Save(0, "TUTORIAL_18");
			ES2.Save(0, "TUTORIAL_19");
			ES2.Save(0, "TUTORIAL_20");
			ES2.Save(0, "TUTORIAL_21");
			ES2.Save(1, "CHAR1");
			ES2.Save(0, "CHAR8");
			ES2.Save(0, "CHAR15");
			ES2.Save(0, "CHAR2");
			ES2.Save(0, "CHAR9");
			ES2.Save(0, "CHAR3");
			ES2.Save(0, "CHAR10");
			ES2.Save(0, "CHAR4");
			ES2.Save(0, "CHAR11");
			ES2.Save(0, "CHAR5");
			ES2.Save(0, "CHAR12");
			ES2.Save(0, "CHAR6");
			ES2.Save(0, "CHAR13");
			ES2.Save(0, "CHAR7");
			ES2.Save(0, "CHAR14");
			ES2.Save(0, "CAR1");
			ES2.Save(0, "CAR1_ENGINE");
			ES2.Save(0, "CAR1_TIRES");
			ES2.Save(0, "CAR1_KPP");
			ES2.Save(0, "CAR1_BRAKES");
			ES2.Save(0, "CAR1_NITRO");
			ES2.Save(0, "CAR1_SUSP");
			ES2.Save(0, "CAR1_WEIGHT");
			ES2.Save(0, "CAR2");
			ES2.Save(0, "CAR2_ENGINE");
			ES2.Save(0, "CAR2_TIRES");
			ES2.Save(0, "CAR2_KPP");
			ES2.Save(0, "CAR2_BRAKES");
			ES2.Save(0, "CAR2_NITRO");
			ES2.Save(0, "CAR2_SUSP");
			ES2.Save(0, "CAR2_WEIGHT");
			ES2.Save(0, "CAR3");
			ES2.Save(0, "CAR3_ENGINE");
			ES2.Save(0, "CAR3_TIRES");
			ES2.Save(0, "CAR3_KPP");
			ES2.Save(0, "CAR3_BRAKES");
			ES2.Save(0, "CAR3_NITRO");
			ES2.Save(0, "CAR3_SUSP");
			ES2.Save(0, "CAR3_WEIGHT");
			ES2.Save(0, "CAR4");
			ES2.Save(0, "CAR4_ENGINE");
			ES2.Save(0, "CAR4_TIRES");
			ES2.Save(0, "CAR4_KPP");
			ES2.Save(0, "CAR4_BRAKES");
			ES2.Save(0, "CAR4_NITRO");
			ES2.Save(0, "CAR4_SUSP");
			ES2.Save(0, "CAR4_WEIGHT");
			ES2.Save(0, "CAR5");
			ES2.Save(0, "CAR5_ENGINE");
			ES2.Save(0, "CAR5_TIRES");
			ES2.Save(0, "CAR5_KPP");
			ES2.Save(0, "CAR5_BRAKES");
			ES2.Save(0, "CAR5_NITRO");
			ES2.Save(0, "CAR5_SUSP");
			ES2.Save(0, "CAR5_WEIGHT");
			ES2.Save(0, "CAR6");
			ES2.Save(0, "CAR6_ENGINE");
			ES2.Save(0, "CAR6_TIRES");
			ES2.Save(0, "CAR6_KPP");
			ES2.Save(0, "CAR6_BRAKES");
			ES2.Save(0, "CAR6_NITRO");
			ES2.Save(0, "CAR6_SUSP");
			ES2.Save(0, "CAR6_WEIGHT");
			ES2.Save(0, "CAR7");
			ES2.Save(0, "CAR7_ENGINE");
			ES2.Save(0, "CAR7_TIRES");
			ES2.Save(0, "CAR7_KPP");
			ES2.Save(0, "CAR7_BRAKES");
			ES2.Save(0, "CAR7_NITRO");
			ES2.Save(0, "CAR7_SUSP");
			ES2.Save(0, "CAR7_WEIGHT");
			ES2.Save(0, "CAR8");
			ES2.Save(0, "CAR8_ENGINE");
			ES2.Save(0, "CAR8_TIRES");
			ES2.Save(0, "CAR8_KPP");
			ES2.Save(0, "CAR8_BRAKES");
			ES2.Save(0, "CAR8_NITRO");
			ES2.Save(0, "CAR8_SUSP");
			ES2.Save(0, "CAR8_WEIGHT");
			ES2.Save(0, "CAR9");
			ES2.Save(0, "CAR9_ENGINE");
			ES2.Save(0, "CAR9_TIRES");
			ES2.Save(0, "CAR9_KPP");
			ES2.Save(0, "CAR9_BRAKES");
			ES2.Save(0, "CAR9_NITRO");
			ES2.Save(0, "CAR9_SUSP");
			ES2.Save(0, "CAR9_WEIGHT");
			ES2.Save(0, "CAR10");
			ES2.Save(0, "CAR10_ENGINE");
			ES2.Save(0, "CAR10_TIRES");
			ES2.Save(0, "CAR10_KPP");
			ES2.Save(0, "CAR10_BRAKES");
			ES2.Save(0, "CAR10_NITRO");
			ES2.Save(0, "CAR10_SUSP");
			ES2.Save(0, "CAR10_WEIGHT");
			ES2.Save(0, "CAR1_FRONT");
			ES2.Save(0, "CAR1_BACK");
			ES2.Save(0, "CAR1_MIDDLE");
			ES2.Save(0, "CAR1_WHEELS");
			ES2.Save(0, "CAR1_CAMBER");
			ES2.Save(1f, "CAR1_LIGHT_R");
			ES2.Save(1f, "CAR1_LIGHT_G");
			ES2.Save(1f, "CAR1_LIGHT_B");
			ES2.Save(0, "CAR1_LIGHT");
			ES2.Save("ABGAMES89", "CAR1_NAME");
			ES2.Save(1, "CAR2_FRONT");
			ES2.Save(1, "CAR2_BACK");
			ES2.Save(1, "CAR2_MIDDLE");
			ES2.Save(1, "CAR2_WHEELS");
			ES2.Save(0, "CAR2_CAMBER");
			ES2.Save(1f, "CAR2_LIGHT_R");
			ES2.Save(1f, "CAR2_LIGHT_G");
			ES2.Save(1f, "CAR2_LIGHT_B");
			ES2.Save(0, "CAR2_LIGHT");
			ES2.Save("ABGAMES89", "CAR2_NAME");
			ES2.Save(2, "CAR3_FRONT");
			ES2.Save(2, "CAR3_BACK");
			ES2.Save(2, "CAR3_MIDDLE");
			ES2.Save(4, "CAR3_WHEELS");
			ES2.Save(0, "CAR3_CAMBER");
			ES2.Save(1f, "CAR3_LIGHT_R");
			ES2.Save(1f, "CAR3_LIGHT_G");
			ES2.Save(1f, "CAR3_LIGHT_B");
			ES2.Save(0, "CAR3_LIGHT");
			ES2.Save("ABGAMES89", "CAR3_NAME");
			ES2.Save(3, "CAR4_FRONT");
			ES2.Save(3, "CAR4_BACK");
			ES2.Save(0, "CAR4_MIDDLE");
			ES2.Save(0, "CAR4_WHEELS");
			ES2.Save(0, "CAR4_CAMBER");
			ES2.Save(1f, "CAR4_LIGHT_R");
			ES2.Save(1f, "CAR4_LIGHT_G");
			ES2.Save(1f, "CAR4_LIGHT_B");
			ES2.Save(0, "CAR4_LIGHT");
			ES2.Save("ABGAMES89", "CAR4_NAME");
			ES2.Save(4, "CAR5_FRONT");
			ES2.Save(2, "CAR5_BACK");
			ES2.Save(3, "CAR5_MIDDLE");
			ES2.Save(1, "CAR5_WHEELS");
			ES2.Save(0, "CAR5_CAMBER");
			ES2.Save(1f, "CAR5_LIGHT_R");
			ES2.Save(1f, "CAR5_LIGHT_G");
			ES2.Save(1f, "CAR5_LIGHT_B");
			ES2.Save(0, "CAR5_LIGHT");
			ES2.Save("ABGAMES89", "CAR5_NAME");
			ES2.Save(0, "CAR6_FRONT");
			ES2.Save(4, "CAR6_BACK");
			ES2.Save(4, "CAR6_MIDDLE");
			ES2.Save(5, "CAR6_WHEELS");
			ES2.Save(0, "CAR6_CAMBER");
			ES2.Save(1f, "CAR6_LIGHT_R");
			ES2.Save(1f, "CAR6_LIGHT_G");
			ES2.Save(1f, "CAR6_LIGHT_B");
			ES2.Save(0, "CAR6_LIGHT");
			ES2.Save("ABGAMES89", "CAR6_NAME");
			ES2.Save(5, "CAR7_FRONT");
			ES2.Save(5, "CAR7_BACK");
			ES2.Save(5, "CAR7_MIDDLE");
			ES2.Save(2, "CAR7_WHEELS");
			ES2.Save(0, "CAR7_CAMBER");
			ES2.Save(1f, "CAR7_LIGHT_R");
			ES2.Save(1f, "CAR7_LIGHT_G");
			ES2.Save(1f, "CAR7_LIGHT_B");
			ES2.Save(0, "CAR7_LIGHT");
			ES2.Save("ABGAMES89", "CAR7_NAME");
			ES2.Save(6, "CAR8_FRONT");
			ES2.Save(6, "CAR8_BACK");
			ES2.Save(6, "CAR8_MIDDLE");
			ES2.Save(2, "CAR8_WHEELS");
			ES2.Save(0, "CAR8_CAMBER");
			ES2.Save(1f, "CAR8_LIGHT_R");
			ES2.Save(1f, "CAR8_LIGHT_G");
			ES2.Save(1f, "CAR8_LIGHT_B");
			ES2.Save(0, "CAR8_LIGHT");
			ES2.Save("ABGAMES89", "CAR8_NAME");
			ES2.Save(5, "CAR9_FRONT");
			ES2.Save(5, "CAR9_BACK");
			ES2.Save(5, "CAR9_MIDDLE");
			ES2.Save(2, "CAR9_WHEELS");
			ES2.Save(0, "CAR9_CAMBER");
			ES2.Save(1f, "CAR9_LIGHT_R");
			ES2.Save(1f, "CAR9_LIGHT_G");
			ES2.Save(1f, "CAR9_LIGHT_B");
			ES2.Save(0, "CAR9_LIGHT");
			ES2.Save("ABGAMES89", "CAR9_NAME");
			ES2.Save(6, "CAR10_FRONT");
			ES2.Save(6, "CAR10_BACK");
			ES2.Save(6, "CAR10_MIDDLE");
			ES2.Save(2, "CAR10_WHEELS");
			ES2.Save(0, "CAR10_CAMBER");
			ES2.Save(1f, "CAR10_LIGHT_R");
			ES2.Save(1f, "CAR10_LIGHT_G");
			ES2.Save(1f, "CAR10_LIGHT_B");
			ES2.Save(0, "CAR10_LIGHT");
			ES2.Save("ABGAMES89", "CAR10_NAME");
			ES2.Save(string.Empty, "F1_S0_TIME");
			ES2.Save(string.Empty, "F1_S1_TIME");
			ES2.Save(string.Empty, "F1_S2_TIME");
			ES2.Save(string.Empty, "F1_S3_TIME");
			ES2.Save(string.Empty, "F1_S4_TIME");
			ES2.Save(string.Empty, "F1_S5_TIME");
			ES2.Save(string.Empty, "F1_S6_TIME");
			ES2.Save(string.Empty, "F1_S7_TIME");
			ES2.Save(string.Empty, "F1_S8_TIME");
			ES2.Save(string.Empty, "F1_S9_TIME");
			ES2.Save(string.Empty, "F1_S10_TIME");
			ES2.Save(string.Empty, "F1_S11_TIME");
			ES2.Save(string.Empty, "F1_S12_TIME");
			ES2.Save(string.Empty, "F1_S13_TIME");
			ES2.Save(string.Empty, "F1_S14_TIME");
			ES2.Save(string.Empty, "F1_S15_TIME");
			ES2.Save(string.Empty, "F1_S16_TIME");
			ES2.Save(string.Empty, "F1_S17_TIME");
			ES2.Save(string.Empty, "F1_S18_TIME");
			ES2.Save(string.Empty, "F1_S19_TIME");
			ES2.Save(string.Empty, "F2_S0_TIME");
			ES2.Save(string.Empty, "F2_S1_TIME");
			ES2.Save(string.Empty, "F2_S2_TIME");
			ES2.Save(string.Empty, "F2_S3_TIME");
			ES2.Save(string.Empty, "F2_S4_TIME");
			ES2.Save(string.Empty, "F2_S5_TIME");
			ES2.Save(string.Empty, "F2_S6_TIME");
			ES2.Save(string.Empty, "F2_S7_TIME");
			ES2.Save(string.Empty, "F2_S8_TIME");
			ES2.Save(string.Empty, "F2_S9_TIME");
			ES2.Save(string.Empty, "F2_S10_TIME");
			ES2.Save(string.Empty, "F2_S11_TIME");
			ES2.Save(string.Empty, "F2_S12_TIME");
			ES2.Save(string.Empty, "F2_S13_TIME");
			ES2.Save(string.Empty, "F2_S14_TIME");
			ES2.Save(string.Empty, "F2_S15_TIME");
			ES2.Save(string.Empty, "F2_S16_TIME");
			ES2.Save(string.Empty, "F2_S17_TIME");
			ES2.Save(string.Empty, "F2_S18_TIME");
			ES2.Save(string.Empty, "F2_S19_TIME");
			ES2.Save(string.Empty, "F3_S0_TIME");
			ES2.Save(string.Empty, "F3_S1_TIME");
			ES2.Save(string.Empty, "F3_S2_TIME");
			ES2.Save(string.Empty, "F3_S3_TIME");
			ES2.Save(string.Empty, "F3_S4_TIME");
			ES2.Save(string.Empty, "F3_S5_TIME");
			ES2.Save(string.Empty, "F3_S6_TIME");
			ES2.Save(string.Empty, "F3_S7_TIME");
			ES2.Save(string.Empty, "F3_S8_TIME");
			ES2.Save(string.Empty, "F3_S9_TIME");
			ES2.Save(string.Empty, "F3_S10_TIME");
			ES2.Save(string.Empty, "F3_S11_TIME");
			ES2.Save(string.Empty, "F3_S12_TIME");
			ES2.Save(string.Empty, "F3_S13_TIME");
			ES2.Save(string.Empty, "F3_S14_TIME");
			ES2.Save(string.Empty, "F3_S15_TIME");
			ES2.Save(string.Empty, "F3_S16_TIME");
			ES2.Save(string.Empty, "F3_S17_TIME");
			ES2.Save(string.Empty, "F3_S18_TIME");
			ES2.Save(string.Empty, "F3_S19_TIME");
			ES2.Save(0, "FIELD1");
			ES2.Save(0, "FIELD2");
			ES2.Save(0, "FIELD3");
			ES2.Save(string.Empty, "NextRewardTimePPK");
			ES2.Save(0, "BONUS_DAY");
			ES2.Save(string.Empty, "WORD_OF_DAY");
			ES2.Save(0, "WORD_DAY");
			ES2.Save(0, "LETTERS");
			ES2.Save(0, "DAILY_MISSION_DAY");
			ES2.Save(string.Empty, "DAILY_MISSION");
			ES2.Save(0, "DAILY_MISSION_1");
			ES2.Save(0, "DAILY_MISSION_2");
			ES2.Save(0, "DAILY_MISSION_3");
			ES2.Save(0, "DAILY_MISSION_1_NEED");
			ES2.Save(0, "DAILY_MISSION_2_NEED");
			ES2.Save(0, "DAILY_MISSION_3_NEED");
			ES2.Save(string.Empty, "DAILY_MISSION_1_TYPE");
			ES2.Save(string.Empty, "DAILY_MISSION_2_TYPE");
			ES2.Save(string.Empty, "DAILY_MISSION_3_TYPE");
			ES2.Save(0, "HOUSE_0");
			ES2.Save(string.Empty, "HOUSE_0_TIME");
			ES2.Save(0, "HOUSE_1");
			ES2.Save(string.Empty, "HOUSE_1_TIME");
			ES2.Save(0, "HOUSE_2");
			ES2.Save(string.Empty, "HOUSE_2_TIME");
			ES2.Save(0, "HOUSE_3");
			ES2.Save(string.Empty, "HOUSE_3_TIME");
			ES2.Save(0, "HOUSE_4");
			ES2.Save(string.Empty, "HOUSE_4_TIME");
			ES2.Save(0, "HOUSE_5");
			ES2.Save(string.Empty, "HOUSE_5_TIME");
			ES2.Save(0, "HOUSE_6");
			ES2.Save(string.Empty, "HOUSE_6_TIME");
			ES2.Save(0, "HOUSE_7");
			ES2.Save(string.Empty, "HOUSE_7_TIME");
			ES2.Save(0, "HOUSE_8");
			ES2.Save(string.Empty, "HOUSE_8_TIME");
			ES2.Save(0, "HOUSE_9");
			ES2.Save(string.Empty, "HOUSE_9_TIME");
			ES2.Save(0, "HOUSE_10");
			ES2.Save(string.Empty, "HOUSE_10_TIME");
			ES2.Save(0, "HOUSE_11");
			ES2.Save(string.Empty, "HOUSE_11_TIME");
			ES2.Save(0, "HOUSE_12");
			ES2.Save(string.Empty, "HOUSE_12_TIME");
			ES2.Save(0, "HOUSE_13");
			ES2.Save(string.Empty, "HOUSE_13_TIME");
			ES2.Save(0, "HOUSE_14");
			ES2.Save(string.Empty, "HOUSE_14_TIME");
			ES2.Save(0, "HOUSE_15");
			ES2.Save(string.Empty, "HOUSE_15_TIME");
			ES2.Save(0, "HOUSE_16");
			ES2.Save(string.Empty, "HOUSE_16_TIME");
			ES2.Save(0, "HOUSE_17");
			ES2.Save(string.Empty, "HOUSE_17_TIME");
			ES2.Save(0, "HOUSE_18");
			ES2.Save(string.Empty, "HOUSE_18_TIME");
			ES2.Save(0, "HOUSE_19");
			ES2.Save(string.Empty, "HOUSE_19_TIME");
			ES2.Save(0, "HOUSE_20");
			ES2.Save(string.Empty, "HOUSE_20_TIME");
			ES2.Save(0, "HOUSE_21");
			ES2.Save(string.Empty, "HOUSE_21_TIME");
			for (int j = 0; j < 83; j++)
			{
				ES2.Save(0, "RACE_" + j);
			}
			for (int k = 0; k < 62; k++)
			{
				ES2.Save(0, "RACE_TRAFFIC" + k);
			}
			for (int l = 0; l < 24; l++)
			{
				ES2.Save(0, "SCHOOL_TRAFFIC" + l);
			}
			for (int m = 0; m < 24; m++)
			{
				ES2.Save(0, "SCHOOL_CHECKPOINT" + m);
			}
			for (int n = 0; n < 24; n++)
			{
				ES2.Save(0, "SCHOOL_ORIENT" + n);
			}
			for (int num = 0; num < 24; num++)
			{
				ES2.Save(0, "SCHOOL_REACT" + num);
			}
			for (int num2 = 0; num2 < 24; num2++)
			{
				ES2.Save(0, "SCHOOL_TRAFFIC_" + num2);
			}
			for (int num3 = 0; num3 < 24; num3++)
			{
				ES2.Save(0, "SCHOOL_CHECKPOINT_" + num3);
			}
			for (int num4 = 0; num4 < 24; num4++)
			{
				ES2.Save(0, "SCHOOL_ORIENT_" + num4);
			}
			for (int num5 = 0; num5 < 24; num5++)
			{
				ES2.Save(0, "SCHOOL_REACT_" + num5);
			}
			ES2.Save(1, "SCHOOL_LEVEL_0");
			ES2.Save(1, "SCHOOL_LEVEL_16");
			ES2.Save(1, "SCHOOL_LEVEL");
			ES2.Save(0, "TAXI_LICENSE_START");
			ES2.Save(0, "MEDIC_LICENSE_START");
			ES2.Save(0, "COP_LICENSE_START");
			ES2.Save(0, "TAXI_LICENSE");
			ES2.Save(0, "MEDIC_LICENSE");
			ES2.Save(0, "COP_LICENSE");
			ES2.Save(DateTime.Now.ToShortDateString(), "SKIP_DAY");
			ES2.Save(3, "SKIP_TODAY");
			ES2.Save(param: true, "DEFAULT_CONFIG");
		}
		Application.targetFrameRate = 60;
		Terrain.activeTerrain.heightmapPixelError = 10f;
		Terrain.activeTerrain.basemapDistance = 120f;
		GAME_MANAGER.SHOW_WORD = false;
		if (ES2.Load<int>("TEXTURES") == 0)
		{
			QualitySettings.SetQualityLevel(0, applyExpensiveChanges: false);
		}
		if (ES2.Load<int>("TEXTURES") == 1)
		{
			QualitySettings.SetQualityLevel(1, applyExpensiveChanges: false);
		}
		if (ES2.Load<int>("TEXTURES") == 2)
		{
			QualitySettings.SetQualityLevel(2, applyExpensiveChanges: false);
		}
		if (ES2.Load<int>("TEXTURES") == 3)
		{
			QualitySettings.SetQualityLevel(3, applyExpensiveChanges: false);
		}
		if (ES2.Load<int>("VSYNC") == 1)
		{
			QualitySettings.vSyncCount = 1;
		}
		else
		{
			QualitySettings.vSyncCount = 0;
		}
		if (ES2.Load<int>("BLOOMFX") == 1)
		{
			GAMECAMERA.GetComponent<FxPro>().enabled = true;
			MAINCAMERA.GetComponent<FxPro>().enabled = true;
			DRIVERCAMERA.GetComponent<FxPro>().enabled = true;
			GARAGECAMERA.GetComponent<FxPro>().enabled = true;
			FARMCAMERA.GetComponent<FxPro>().enabled = false;
			SHOPCAMERA.GetComponent<FxPro>().enabled = false;
		}
		Time.timeScale = 1f;
		AudioListener.volume = ES2.Load<float>("MAIN_VOLUME");
		base.gameObject.GetComponent<AudioSource>().volume = ES2.Load<float>("MUSIC_VOLUME") - 0.15f;
		MAINCAMERA.SetActive(value: true);
		GARAGECAMERA.SetActive(value: false);
		MAINMENU_UI.SetActive(value: true);
		GAMEMENU_UI.SetActive(value: false);
		BONUSMENU_UI.SetActive(value: false);
		TIRE_SMOKE_3D.SetActive(value: true);
		if ((ES2.Load<int>("BONUS_DAY") > 0) & CanRewardNow())
		{
			string1 = DateTime.FromBinary(Convert.ToInt64(ES2.Load<string>("NextRewardTimePPK"))).ToShortDateString();
			string2 = DateTime.Now.ToShortDateString();
			if (string1 != string2)
			{
				ES2.Save(DateTime.Now.ToBinary().ToString(), "NextRewardTimePPK");
				ES2.Save(0, "BONUS_DAY");
			}
		}
		if (ES2.Load<int>("TUTORIAL_1") == 0)
		{
			TUTORIAL.SetActive(value: true);
			ES2.Save(1, "TUTORIAL_1");
		}
		else
		{
			StartCoroutine(START_VOICE());
		}
		GameObject gameObject = UnityEngine.Object.Instantiate(CHARACTERS[ES2.Load<int>("SELECT_CHARACTER")], base.transform.position, base.transform.rotation);
		gameObject.transform.position = new Vector3(200.58f, 30.45f, 263.68f);
		gameObject.transform.rotation = Quaternion.Euler(0f, 230.5f, 0f);
		gameObject.GetComponent<Mouse_drag_rotate_scale_control>().enabled = false;
		LOADING_LEVEL = 0;
		PLAYER_LEVEL = ES2.Load<int>("PLAYER_LEVEL");
		Resources.UnloadUnusedAssets();
		GC.Collect();
	}

	public void LOAD_VILLY()
	{
		AudioSource.PlayClipAtPoint(CLICK_SND, GAMECAMERA.transform.position, 0.7f);
		BIRD_UI.SetActive(value: false);
		Application.LoadLevel(7);
	}

	public void CLOSE_VILLY()
	{
		AudioSource.PlayClipAtPoint(CLICK_SND, GAMECAMERA.transform.position, 0.7f);
		BIRD_UI.SetActive(value: false);
	}

	public void OPEN_VILLY()
	{
		AudioSource.PlayClipAtPoint(CLICK_SND, GAMECAMERA.transform.position, 0.7f);
		BIRD_UI.SetActive(value: true);
		BIRD_RECORD.text = string.Empty + ES2.Load<int>("BEST_SCORE");
	}

	public void CLOSE_RATE()
	{
		AudioSource.PlayClipAtPoint(CLICK_SND, GAMECAMERA.transform.position, 0.7f);
		RATE_GAME_UI.SetActive(value: false);
		ES2.Save(4, "RATE_GAME");
	}

	public void ACCEPT_RATE()
	{
		AudioSource.PlayClipAtPoint(CLICK_SND, GAMECAMERA.transform.position, 0.7f);
		RATE_GAME_UI.SetActive(value: false);
		Application.OpenURL("https://play.google.com/store/apps/details?id=com.AB.CHR");
		ES2.Save(4, "RATE_GAME");
	}

	public void ACHIV_GET()
	{
	}

	private void Update()
	{
		sky_rotate += Time.deltaTime / 1.3f;
		SKY_DAY.SetFloat("_Rotation", sky_rotate);
		BONUS();
		if (CURRENT_CAR_OBJ != null)
		{
			CURRENT_CAR_OBJ.transform.Rotate(0f, 13f * Time.deltaTime, 0f);
		}
	}

	public void PLAY_SCHOOL()
	{
		AudioSource.PlayClipAtPoint(CLICK_SND, GAMECAMERA.transform.position, 0.7f);
		if (SCHOOL_TAXI.activeInHierarchy)
		{
			SELECT_SCHOOL_ = 1;
			if (ES2.Load<int>("TAXI_LICENSE_START") == 0)
			{
				int num = ES2.Load<int>("PLAYER_MONEY");
				num -= 500;
				ES2.Save(num, "PLAYER_MONEY");
				ES2.Save(1, "TAXI_LICENSE_START");
			}
		}
		if (SCHOOL_MEDIC.activeInHierarchy)
		{
			SELECT_SCHOOL_ = 2;
			if (ES2.Load<int>("MEDIC_LICENSE_START") == 0)
			{
				int num2 = ES2.Load<int>("PLAYER_MONEY");
				num2 -= 2500;
				ES2.Save(num2, "PLAYER_MONEY");
				ES2.Save(1, "MEDIC_LICENSE_START");
			}
		}
		if (SCHOOL_COP.activeInHierarchy)
		{
			SELECT_SCHOOL_ = 3;
			if (ES2.Load<int>("COP_LICENSE_START") == 0)
			{
				int num3 = ES2.Load<int>("PLAYER_MONEY");
				num3 -= 5000;
				ES2.Save(num3, "PLAYER_MONEY");
				ES2.Save(1, "COP_LICENSE_START");
			}
		}
		Application.LoadLevel(5);
	}

	public void OPEN_QUIT()
	{
		AudioSource.PlayClipAtPoint(CLICK_SND, MAINCAMERA.transform.position, 0.7f);
		QUIT_MENU.SetActive(value: true);
	}

	public void CANCEL_QUIT()
	{
		AudioSource.PlayClipAtPoint(BACK_SND, MAINCAMERA.transform.position, 0.7f);
		QUIT_MENU.SetActive(value: false);
	}

	public void ACCEPT_QUIT()
	{
		AudioSource.PlayClipAtPoint(CLICK_SND, MAINCAMERA.transform.position, 0.7f);
		Application.Quit();
	}

	public void OPEN_OPTIONS()
	{
		AudioSource.PlayClipAtPoint(CLICK_SND, MAINCAMERA.transform.position, 0.7f);
		MAINMENU_UI.SetActive(value: false);
		OPTIONS_MENU.SetActive(value: true);
	}

	public void CLOSE_OPTIONS()
	{
		AudioSource.PlayClipAtPoint(BACK_SND, MAINCAMERA.transform.position, 0.7f);
		MAINMENU_UI.SetActive(value: true);
		OPTIONS_MENU.SetActive(value: false);
	}

	public void OPEN_TARGETSMENU()
	{
		AudioSource.PlayClipAtPoint(CLICK_SND, GAMECAMERA.transform.position, 0.7f);
		GAMEMENU_UI.SetActive(value: false);
		TARGETS_UI.SetActive(value: true);
	}

	public void CLOSE_TARGETSMENU()
	{
		AudioSource.PlayClipAtPoint(BACK_SND, GAMECAMERA.transform.position, 0.7f);
		GAMEMENU_UI.SetActive(value: true);
		TARGETS_UI.SetActive(value: false);
	}

	public void OPEN_RACESMENU()
	{
		AudioSource.PlayClipAtPoint(CLICK_SND, GAMECAMERA.transform.position, 0.7f);
		GAMEMENU_UI.SetActive(value: false);
		RACEMENU_UI.SetActive(value: true);
	}

	public void CLOSE_RACESMENU()
	{
		AudioSource.PlayClipAtPoint(BACK_SND, GAMECAMERA.transform.position, 0.7f);
		GAMEMENU_UI.SetActive(value: true);
		RACEMENU_UI.SetActive(value: false);
	}

	public void NEXT_LOC()
	{
		AudioSource.PlayClipAtPoint(NEXT_SND, GAMECAMERA.transform.position, 0.7f);
		FARM_LOC.SetActive(value: false);
		CITY_LOC.SetActive(value: true);
		if (PLAYER_LEVEL < 10)
		{
			START_BUTTON.GetComponent<Image>().sprite = START_BUTTON_OFF;
			START_BUTTON.interactable = false;
			CITYLOCKED_UI.SetActive(value: true);
		}
		else
		{
			START_BUTTON.GetComponent<Image>().sprite = START_BUTTON_ON;
			START_BUTTON.interactable = true;
			CITYLOCKED_UI.SetActive(value: false);
		}
	}

	public void PREV_LOC()
	{
		AudioSource.PlayClipAtPoint(NEXT_SND, GAMECAMERA.transform.position, 0.7f);
		FARM_LOC.SetActive(value: true);
		CITY_LOC.SetActive(value: false);
		START_BUTTON.GetComponent<Image>().sprite = START_BUTTON_ON;
		START_BUTTON.interactable = true;
	}

	public void PLAY_BUTTON()
	{
		AudioSource.PlayClipAtPoint(CLICK_SND, GAMECAMERA.transform.position, 0.7f);
		if (FARM_LOC.activeInHierarchy)
		{
			LOADING_LEVEL = 0;
		}
		else
		{
			LOADING_LEVEL = 1;
		}
		if (LANGUAGE == 0)
		{
			if (LOADING_LEVEL == 0)
			{
				LOADING_LOCATION.text = "Green Valleys";
			}
			else
			{
				LOADING_LOCATION.text = "SunRise town";
			}
		}
		else if (LOADING_LEVEL == 0)
		{
			LOADING_LOCATION.text = "Зеленые долины";
		}
		else
		{
			LOADING_LOCATION.text = "Санрайз таун";
		}
		LOADING_CANVAS.SetActive(value: true);
		Application.LoadLevel(1);
	}

	public void NEXT_SCHOOL()
	{
		AudioSource.PlayClipAtPoint(NEXT_SND, GAMECAMERA.transform.position, 0.7f);
		if (SCHOOL_TAXI.activeInHierarchy)
		{
			SCHOOL_TAXI.SetActive(value: false);
			SCHOOL_MEDIC.SetActive(value: true);
			SCHOOL_COP.SetActive(value: false);
			CHECK_SCHOOL();
		}
		else if (SCHOOL_MEDIC.activeInHierarchy)
		{
			SCHOOL_TAXI.SetActive(value: false);
			SCHOOL_MEDIC.SetActive(value: false);
			SCHOOL_COP.SetActive(value: true);
			CHECK_SCHOOL();
		}
	}

	public void PREV_SCHOOL()
	{
		AudioSource.PlayClipAtPoint(NEXT_SND, GAMECAMERA.transform.position, 0.7f);
		if (SCHOOL_COP.activeInHierarchy)
		{
			SCHOOL_TAXI.SetActive(value: false);
			SCHOOL_MEDIC.SetActive(value: true);
			SCHOOL_COP.SetActive(value: false);
			CHECK_SCHOOL();
		}
		else if (SCHOOL_MEDIC.activeInHierarchy)
		{
			SCHOOL_TAXI.SetActive(value: true);
			SCHOOL_MEDIC.SetActive(value: false);
			SCHOOL_COP.SetActive(value: false);
			CHECK_SCHOOL();
		}
	}

	private void CHECK_SCHOOL()
	{
		if (SCHOOL_TAXI.activeInHierarchy)
		{
			if (ES2.Load<int>("CAR1") == 1)
			{
				TAXI_NO_AVAIBLE.SetActive(value: false);
				if (ES2.Load<int>("TAXI_LICENSE") == 0)
				{
					TAXI_COMPLETE.SetActive(value: false);
					SELECT_SCHOOL_BUTTON.GetComponent<Image>().sprite = START_BUTTON_ON;
					SELECT_SCHOOL_BUTTON.GetComponent<Button>().interactable = true;
					if (ES2.Load<int>("PLAYER_MONEY") < 500)
					{
						TAXI_AVAIBLE.SetActive(value: true);
						SCHOOL_TEXT.color = new Color(1f, 1f, 1f, 0.5f);
						SELECT_SCHOOL_BUTTON.GetComponent<Image>().sprite = START_BUTTON_OFF;
						SELECT_SCHOOL_BUTTON.GetComponent<Button>().interactable = false;
					}
					else
					{
						SCHOOL_TEXT.color = new Color(1f, 1f, 1f, 1f);
						TAXI_AVAIBLE.SetActive(value: true);
						SELECT_SCHOOL_BUTTON.GetComponent<Image>().sprite = START_BUTTON_ON;
						SELECT_SCHOOL_BUTTON.GetComponent<Button>().interactable = true;
					}
					if (ES2.Load<int>("TAXI_LICENSE_START") == 1)
					{
						if (LANGUAGE == 1)
						{
							SCHOOL_TEXT.text = "Продолжить";
						}
						else
						{
							SCHOOL_TEXT.text = "continue";
						}
						TAXI_PROGRESS.SetActive(value: true);
						TAXI_AVAIBLE.SetActive(value: false);
						SELECT_SCHOOL_BUTTON.GetComponent<Image>().sprite = START_BUTTON_ON;
						SELECT_SCHOOL_BUTTON.GetComponent<Button>().interactable = true;
						SCHOOL_TEXT.color = new Color(1f, 1f, 1f, 1f);
					}
					else
					{
						if (LANGUAGE == 1)
						{
							SCHOOL_TEXT.text = "ВЫбрать";
						}
						else
						{
							SCHOOL_TEXT.text = "Select";
						}
						TAXI_PROGRESS.SetActive(value: false);
					}
				}
				else
				{
					if (LANGUAGE == 1)
					{
						SCHOOL_TEXT.text = "ВЫбрать";
					}
					else
					{
						SCHOOL_TEXT.text = "Select";
					}
					SCHOOL_TEXT.color = new Color(1f, 1f, 1f, 0.5f);
					TAXI_COMPLETE.SetActive(value: true);
					SELECT_SCHOOL_BUTTON.GetComponent<Image>().sprite = START_BUTTON_OFF;
					SELECT_SCHOOL_BUTTON.GetComponent<Button>().interactable = false;
				}
			}
			else
			{
				if (LANGUAGE == 1)
				{
					SCHOOL_TEXT.text = "ВЫбрать";
				}
				else
				{
					SCHOOL_TEXT.text = "Select";
				}
				TAXI_NO_AVAIBLE.SetActive(value: true);
				SCHOOL_TEXT.color = new Color(1f, 1f, 1f, 0.5f);
				SELECT_SCHOOL_BUTTON.GetComponent<Image>().sprite = START_BUTTON_OFF;
				SELECT_SCHOOL_BUTTON.GetComponent<Button>().interactable = false;
			}
		}
		if (SCHOOL_MEDIC.activeInHierarchy)
		{
			if (ES2.Load<int>("CAR3") == 1)
			{
				MED_NO_AVAIBLE.SetActive(value: false);
				if (ES2.Load<int>("MEDIC_LICENSE") == 0)
				{
					MED_COMPLETE.SetActive(value: false);
					SELECT_SCHOOL_BUTTON.GetComponent<Image>().sprite = START_BUTTON_ON;
					SELECT_SCHOOL_BUTTON.GetComponent<Button>().interactable = true;
					if (ES2.Load<int>("PLAYER_MONEY") < 2500)
					{
						MED_AVAIBLE.SetActive(value: true);
						SELECT_SCHOOL_BUTTON.GetComponent<Image>().sprite = START_BUTTON_OFF;
						SELECT_SCHOOL_BUTTON.GetComponent<Button>().interactable = false;
						SCHOOL_TEXT.color = new Color(1f, 1f, 1f, 0.5f);
					}
					else
					{
						MED_AVAIBLE.SetActive(value: true);
						SELECT_SCHOOL_BUTTON.GetComponent<Image>().sprite = START_BUTTON_ON;
						SELECT_SCHOOL_BUTTON.GetComponent<Button>().interactable = true;
						SCHOOL_TEXT.color = new Color(1f, 1f, 1f, 1f);
					}
					if (ES2.Load<int>("MEDIC_LICENSE_START") == 1)
					{
						if (LANGUAGE == 1)
						{
							SCHOOL_TEXT.text = "ПРОДОЛЖИТЬ";
						}
						else
						{
							SCHOOL_TEXT.text = "continue";
						}
						MED_PROGRESS.SetActive(value: true);
						MED_AVAIBLE.SetActive(value: false);
						SELECT_SCHOOL_BUTTON.GetComponent<Image>().sprite = START_BUTTON_ON;
						SELECT_SCHOOL_BUTTON.GetComponent<Button>().interactable = true;
						SCHOOL_TEXT.color = new Color(1f, 1f, 1f, 1f);
					}
					else
					{
						if (LANGUAGE == 1)
						{
							SCHOOL_TEXT.text = "ВЫбрать";
						}
						else
						{
							SCHOOL_TEXT.text = "Select";
						}
						MED_PROGRESS.SetActive(value: false);
					}
				}
				else
				{
					if (LANGUAGE == 1)
					{
						SCHOOL_TEXT.text = "ВЫбрать";
					}
					else
					{
						SCHOOL_TEXT.text = "Select";
					}
					MED_COMPLETE.SetActive(value: true);
					SELECT_SCHOOL_BUTTON.GetComponent<Image>().sprite = START_BUTTON_OFF;
					SELECT_SCHOOL_BUTTON.GetComponent<Button>().interactable = false;
					SCHOOL_TEXT.color = new Color(1f, 1f, 1f, 0.5f);
				}
			}
			else
			{
				if (LANGUAGE == 1)
				{
					SCHOOL_TEXT.text = "ВЫбрать";
				}
				else
				{
					SCHOOL_TEXT.text = "Select";
				}
				SCHOOL_TEXT.color = new Color(1f, 1f, 1f, 0.5f);
				SELECT_SCHOOL_BUTTON.GetComponent<Image>().sprite = START_BUTTON_OFF;
				SELECT_SCHOOL_BUTTON.GetComponent<Button>().interactable = false;
				MED_NO_AVAIBLE.SetActive(value: true);
			}
		}
		if (!SCHOOL_COP.activeInHierarchy)
		{
			return;
		}
		if (ES2.Load<int>("CAR5") == 1)
		{
			COP_NO_AVAIBLE.SetActive(value: false);
			if (ES2.Load<int>("COP_LICENSE") == 0)
			{
				COP_COMPLETE.SetActive(value: false);
				SELECT_SCHOOL_BUTTON.GetComponent<Image>().sprite = START_BUTTON_ON;
				SELECT_SCHOOL_BUTTON.GetComponent<Button>().interactable = true;
				if (ES2.Load<int>("PLAYER_MONEY") < 5000)
				{
					COP_AVAIBLE.SetActive(value: true);
					SELECT_SCHOOL_BUTTON.GetComponent<Image>().sprite = START_BUTTON_OFF;
					SELECT_SCHOOL_BUTTON.GetComponent<Button>().interactable = false;
					SCHOOL_TEXT.color = new Color(1f, 1f, 1f, 0.5f);
				}
				else
				{
					COP_AVAIBLE.SetActive(value: true);
					SELECT_SCHOOL_BUTTON.GetComponent<Image>().sprite = START_BUTTON_ON;
					SELECT_SCHOOL_BUTTON.GetComponent<Button>().interactable = true;
					SCHOOL_TEXT.color = new Color(1f, 1f, 1f, 1f);
				}
				if (ES2.Load<int>("COP_LICENSE_START") == 1)
				{
					if (LANGUAGE == 1)
					{
						SCHOOL_TEXT.text = "ПРОДОЛЖИТЬ";
					}
					else
					{
						SCHOOL_TEXT.text = "continue";
					}
					COP_PROGRESS.SetActive(value: true);
					COP_AVAIBLE.SetActive(value: false);
					SELECT_SCHOOL_BUTTON.GetComponent<Image>().sprite = START_BUTTON_ON;
					SELECT_SCHOOL_BUTTON.GetComponent<Button>().interactable = true;
					SCHOOL_TEXT.color = new Color(1f, 1f, 1f, 1f);
				}
				else
				{
					if (LANGUAGE == 1)
					{
						SCHOOL_TEXT.text = "ВЫбрать";
					}
					else
					{
						SCHOOL_TEXT.text = "Select";
					}
					COP_PROGRESS.SetActive(value: false);
				}
			}
			else
			{
				if (LANGUAGE == 1)
				{
					SCHOOL_TEXT.text = "ВЫбрать";
				}
				else
				{
					SCHOOL_TEXT.text = "Select";
				}
				COP_COMPLETE.SetActive(value: true);
				SELECT_SCHOOL_BUTTON.GetComponent<Image>().sprite = START_BUTTON_OFF;
				SCHOOL_TEXT.color = new Color(1f, 1f, 1f, 0.5f);
				SELECT_SCHOOL_BUTTON.GetComponent<Button>().interactable = false;
			}
		}
		else
		{
			SCHOOL_TEXT.color = new Color(1f, 1f, 1f, 0.5f);
			SELECT_SCHOOL_BUTTON.GetComponent<Image>().sprite = START_BUTTON_OFF;
			SELECT_SCHOOL_BUTTON.GetComponent<Button>().interactable = false;
			COP_NO_AVAIBLE.SetActive(value: true);
			if (LANGUAGE == 1)
			{
				SCHOOL_TEXT.text = "ВЫбрать";
			}
			else
			{
				SCHOOL_TEXT.text = "Select";
			}
		}
	}

	public void OPEN_SCHOOL()
	{
		AudioSource.PlayClipAtPoint(CLICK_SND, GAMECAMERA.transform.position, 0.7f);
		GAMEMENU_UI.SetActive(value: false);
		SCHOOL_MENU.SetActive(value: true);
		SCHOOL_TAXI.SetActive(value: true);
		SCHOOL_MEDIC.SetActive(value: false);
		SCHOOL_COP.SetActive(value: false);
		CHECK_SCHOOL();
	}

	public void CLOSE_SCHOOL()
	{
		AudioSource.PlayClipAtPoint(BACK_SND, GAMECAMERA.transform.position, 0.7f);
		SCHOOL_MENU.SetActive(value: false);
		GAMEMENU_UI.SetActive(value: true);
	}

	public void OPEN_SELECTLOCATION()
	{
		AudioSource.PlayClipAtPoint(CLICK_SND, GAMECAMERA.transform.position, 0.7f);
		GAMEMENU_UI.SetActive(value: false);
		STARTMENU_UI.SetActive(value: true);
		CITYLOCKED_UI.SetActive(value: false);
		FARM_LOC.SetActive(value: true);
		CITY_LOC.SetActive(value: false);
		START_BUTTON.GetComponent<Image>().sprite = START_BUTTON_ON;
		START_BUTTON.interactable = true;
	}

	public void CLOSE_SELECTLOCATION()
	{
		AudioSource.PlayClipAtPoint(BACK_SND, GAMECAMERA.transform.position, 0.7f);
		GAMEMENU_UI.SetActive(value: true);
		STARTMENU_UI.SetActive(value: false);
	}

	public void OPEN_GAMEMENU()
	{
		if (ES2.Load<int>("CAR1") == 1)
		{
			if (ES2.Load<int>("TUTORIAL_4") == 0)
			{
				TUTORIAL4.SetActive(value: true);
				ES2.Save(1, "TUTORIAL_4");
			}
			GAME_CURRENT_MONEY_TXT.text = string.Empty + ES2.Load<int>("PLAYER_MONEY");
			GAME_CURRENT_GEAR_TXT.text = string.Empty + ES2.Load<int>("PLAYER_GEAR");
			if (LANGUAGE == 1)
			{
				GAME_CURRENT_LEVEL_TXT.text = ES2.Load<int>("PLAYER_LEVEL") + " ур";
			}
			else
			{
				GAME_CURRENT_LEVEL_TXT.text = ES2.Load<int>("PLAYER_LEVEL") + " lv";
			}
			GAME_CURRENT_XP_IMG.fillAmount = ES2.Load<float>("PLAYER_LEVEL_PROGRESS");
			MAINCAMERA.GetComponent<ScreenFader>().reset();
			GAMECAMERA.GetComponent<ScreenFader>().reset();
			MAINCAMERA.GetComponent<ScreenFader>().fadeState = ScreenFader.FadeState.Out;
			GAMECAMERA.GetComponent<ScreenFader>().fadeState = ScreenFader.FadeState.Out;
			MAINCAMERA.SetActive(value: false);
			GAMECAMERA.SetActive(value: true);
			AudioSource.PlayClipAtPoint(CLICK_SND, GAMECAMERA.transform.position, 0.7f);
			MAINMENU_UI.SetActive(value: false);
			GAMEMENU_UI.SetActive(value: true);
		}
		else
		{
			BUY_CAR_BEFORE.SetActive(value: true);
		}
	}

	public void CLOSE_BEFORE()
	{
		AudioSource.PlayClipAtPoint(CLICK_SND, GAMECAMERA.transform.position, 0.7f);
		BUY_CAR_BEFORE.SetActive(value: false);
	}

	public void CLOSE_GAMEMENU()
	{
		MAINCAMERA.GetComponent<ScreenFader>().reset();
		GAMECAMERA.GetComponent<ScreenFader>().reset();
		MAINCAMERA.GetComponent<ScreenFader>().fadeState = ScreenFader.FadeState.Out;
		GAMECAMERA.GetComponent<ScreenFader>().fadeState = ScreenFader.FadeState.Out;
		MAINCAMERA.SetActive(value: true);
		GAMECAMERA.SetActive(value: false);
		AudioSource.PlayClipAtPoint(CLICK_SND, MAINCAMERA.transform.position, 0.7f);
		MAINMENU_UI.SetActive(value: true);
		GAMEMENU_UI.SetActive(value: false);
		if (ES2.Load<int>("BLOOMFX") == 1)
		{
			MAINCAMERA.GetComponent<FxPro>().enabled = false;
			MAINCAMERA.GetComponent<FxPro>().enabled = true;
		}
	}

	public void SELECT_COINS()
	{
		SHOP_GEAR_BUTTON.GetComponent<Image>().sprite = SHOP_NOT_AVAILIBLE;
		SHOP_COIN_BUTTON.GetComponent<Image>().sprite = SHOP_AVAILIBLE;
		SHOP_MONEY_MENU.SetActive(value: true);
		SHOP_GEAR_MENU.SetActive(value: false);
	}

	public void SELECT_GEARS()
	{
		SHOP_GEAR_BUTTON.GetComponent<Image>().sprite = SHOP_AVAILIBLE;
		SHOP_COIN_BUTTON.GetComponent<Image>().sprite = SHOP_NOT_AVAILIBLE;
		SHOP_MONEY_MENU.SetActive(value: false);
		SHOP_GEAR_MENU.SetActive(value: true);
	}

	public void OPEN_UPGRADE()
	{
		if (ES2.Load<int>("TUTORIAL_5") == 0)
		{
			TUTORIAL5.SetActive(value: true);
			ES2.Save(1, "TUTORIAL_5");
		}
		TIRE_SMOKE_3D.SetActive(value: false);
		AudioSource.PlayClipAtPoint(CLICK_SND, GARAGECAMERA.transform.position, 0.7f);
		if (CURRENT_CAR_OBJ != null)
		{
			GARAGEMENU_UI.SetActive(value: false);
			UPGRADEMENU_UI.SetActive(value: true);
		}
	}

	public void CLOSE_UPGRADE()
	{
		TIRE_SMOKE_3D.SetActive(value: true);
		AudioSource.PlayClipAtPoint(BACK_SND, MAINCAMERA.transform.position, 0.7f);
		BUYCAR_BUTTON.SetActive(value: false);
		SELECT_BUTTON.SetActive(value: false);
		CURRENT_CAR.SetActive(value: false);
		UPGRADEMENU_UI.SetActive(value: false);
		OPEN_GARAGE();
	}

	public void OPEN_TUNING()
	{
		if (ES2.Load<int>("TUTORIAL_6") == 0)
		{
			TUTORIAL6.SetActive(value: true);
			ES2.Save(1, "TUTORIAL_6");
		}
		TIRE_SMOKE_3D.SetActive(value: false);
		AudioSource.PlayClipAtPoint(CLICK_SND, GARAGECAMERA.transform.position, 0.7f);
		if (CURRENT_CAR_OBJ != null)
		{
			GARAGEMENU_UI.SetActive(value: false);
			TUNINGMENU_UI.SetActive(value: true);
		}
	}

	public void CLOSE_TUNING()
	{
		TIRE_SMOKE_3D.SetActive(value: true);
		AudioSource.PlayClipAtPoint(BACK_SND, MAINCAMERA.transform.position, 0.7f);
		BUYCAR_BUTTON.SetActive(value: false);
		SELECT_BUTTON.SetActive(value: false);
		CURRENT_CAR.SetActive(value: false);
		TUNINGMENU_UI.SetActive(value: false);
		OPEN_GARAGE();
	}

	public void CLOSE_NO_FARM()
	{
		AudioSource.PlayClipAtPoint(CLICK_SND, MAINCAMERA.transform.position, 0.5f);
		FARM_NO_AVAILBE.SetActive(value: false);
	}

	public void OPEN_FERM()
	{
		if (ES2.Load<int>("CAR1") == 1)
		{
			if (ES2.Load<int>("TUTORIAL_7") == 0)
			{
				TUTORIAL7.SetActive(value: true);
				ES2.Save(1, "TUTORIAL_7");
			}
			TIRE_SMOKE_3D.SetActive(value: false);
			AudioSource.PlayClipAtPoint(CLICK_SND, FARMCAMERA.transform.position, 0.5f);
			MAINCAMERA.GetComponent<ScreenFader>().reset();
			FARMCAMERA.GetComponent<ScreenFader>().reset();
			MAINCAMERA.GetComponent<ScreenFader>().fadeState = ScreenFader.FadeState.Out;
			FARMCAMERA.GetComponent<ScreenFader>().fadeState = ScreenFader.FadeState.Out;
			MAINMENU_UI.SetActive(value: false);
			FARMMENU_UI.SetActive(value: true);
			MAINCAMERA.SetActive(value: false);
			FARMCAMERA.SetActive(value: true);
		}
		else
		{
			FARM_NO_AVAILBE.SetActive(value: true);
		}
	}

	public void CLOSE_FERM()
	{
		TIRE_SMOKE_3D.SetActive(value: true);
		GameObject[] array = GameObject.FindGameObjectsWithTag("SEED");
		GameObject[] array2 = array;
		foreach (GameObject obj in array2)
		{
			UnityEngine.Object.Destroy(obj);
		}
		AudioSource.PlayClipAtPoint(BACK_SND, MAINCAMERA.transform.position, 0.5f);
		MAINCAMERA.GetComponent<ScreenFader>().reset();
		FARMCAMERA.GetComponent<ScreenFader>().reset();
		MAINCAMERA.GetComponent<ScreenFader>().fadeState = ScreenFader.FadeState.Out;
		FARMCAMERA.GetComponent<ScreenFader>().fadeState = ScreenFader.FadeState.Out;
		MAINMENU_UI.SetActive(value: true);
		FARMMENU_UI.SetActive(value: false);
		MAINCAMERA.SetActive(value: true);
		FARMCAMERA.SetActive(value: false);
		if (ES2.Load<int>("BLOOMFX") == 1)
		{
			MAINCAMERA.GetComponent<FxPro>().enabled = false;
			MAINCAMERA.GetComponent<FxPro>().enabled = true;
		}
	}

	public void OPEN_DRIVER()
	{
		TIRE_SMOKE_3D.SetActive(value: false);
		AudioSource.PlayClipAtPoint(CLICK_SND, DRIVERCAMERA.transform.position, 0.5f);
		CURRENT_MONEY = ES2.Load<int>("PLAYER_MONEY");
		PLAYER_LEVEL = ES2.Load<int>("PLAYER_LEVEL");
		if (LANGUAGE == 1)
		{
			CURRENT_LV_TXT2.text = PLAYER_LEVEL + " ур";
		}
		else
		{
			CURRENT_LV_TXT2.text = PLAYER_LEVEL + " lv";
		}
		float fillAmount = ES2.Load<float>("PLAYER_LEVEL_PROGRESS");
		CURRENT_XP_IMG2.fillAmount = fillAmount;
		CURRENT_MONEY_TXT3.text = string.Empty + CURRENT_MONEY;
		MAINCAMERA.GetComponent<ScreenFader>().reset();
		DRIVERCAMERA.GetComponent<ScreenFader>().reset();
		MAINCAMERA.GetComponent<ScreenFader>().fadeState = ScreenFader.FadeState.Out;
		DRIVERCAMERA.GetComponent<ScreenFader>().fadeState = ScreenFader.FadeState.Out;
		MENU_CAR.SetActive(value: false);
		MAINMENU_UI.SetActive(value: false);
		DRIVERMENU_UI.SetActive(value: true);
		MAINCAMERA.SetActive(value: false);
		DRIVERCAMERA.SetActive(value: true);
	}

	public void CLOSE_DRIVER()
	{
		TIRE_SMOKE_3D.SetActive(value: true);
		GameObject gameObject = GameObject.Find("UPGRADE_FX3(Clone)");
		if (gameObject != null)
		{
			UnityEngine.Object.Destroy(gameObject);
		}
		AudioSource.PlayClipAtPoint(BACK_SND, MAINCAMERA.transform.position, 0.5f);
		DRIVERCAMERA.GetComponent<ScreenFader>().reset();
		MAINCAMERA.GetComponent<ScreenFader>().reset();
		DRIVERCAMERA.GetComponent<ScreenFader>().fadeState = ScreenFader.FadeState.Out;
		MAINCAMERA.GetComponent<ScreenFader>().fadeState = ScreenFader.FadeState.Out;
		DRIVERMENU_UI.SetActive(value: false);
		MAINMENU_UI.SetActive(value: true);
		DRIVERCAMERA.SetActive(value: false);
		MAINCAMERA.SetActive(value: true);
		if (ES2.Load<int>("BLOOMFX") == 1)
		{
			MAINCAMERA.GetComponent<FxPro>().enabled = false;
			MAINCAMERA.GetComponent<FxPro>().enabled = true;
		}
		MENU_CAR.SetActive(value: true);
		GameObject[] array = GameObject.FindGameObjectsWithTag("CHARACTER");
		GameObject[] array2 = array;
		foreach (GameObject obj in array2)
		{
			UnityEngine.Object.Destroy(obj);
		}
		GameObject gameObject2 = UnityEngine.Object.Instantiate(CHARACTERS[ES2.Load<int>("SELECT_CHARACTER")], base.transform.position, base.transform.rotation);
		gameObject2.transform.position = new Vector3(201.23f, 30.45f, 263.23f);
		gameObject2.transform.rotation = Quaternion.Euler(0f, 230.5f, 0f);
		gameObject2.GetComponent<Mouse_drag_rotate_scale_control>().enabled = false;
	}

	public void OPEN_GARAGE()
	{
		if (ES2.Load<int>("TUTORIAL_2") == 0)
		{
			TUTORIAL2.SetActive(value: true);
			ES2.Save(1, "TUTORIAL_2");
		}
		TIRE_SMOKE_3D.SetActive(value: false);
		NEED_LEVEL_POPUP.SetActive(value: false);
		AudioSource.PlayClipAtPoint(CLICK_SND, GARAGECAMERA.transform.position, 0.5f);
		CURRENT_MONEY = ES2.Load<int>("PLAYER_MONEY");
		PLAYER_LEVEL = ES2.Load<int>("PLAYER_LEVEL");
		if (LANGUAGE == 1)
		{
			CURRENT_LV_TXT.text = PLAYER_LEVEL + " ур";
		}
		else
		{
			CURRENT_LV_TXT.text = PLAYER_LEVEL + " lv";
		}
		CURRENT_XP_IMG.fillAmount = ES2.Load<float>("PLAYER_LEVEL_PROGRESS");
		SELECTED_CAR = ES2.Load<int>("SELECT_CAR");
		CAR_1 = ES2.Load<int>("CAR1");
		CAR_2 = ES2.Load<int>("CAR2");
		CAR_3 = ES2.Load<int>("CAR3");
		CAR_4 = ES2.Load<int>("CAR4");
		CAR_5 = ES2.Load<int>("CAR5");
		CAR_6 = ES2.Load<int>("CAR6");
		CAR_7 = ES2.Load<int>("CAR7");
		CAR_8 = ES2.Load<int>("CAR8");
		CAR_9 = ES2.Load<int>("CAR9");
		CAR_10 = ES2.Load<int>("CAR10");
		CURRENT_MONEY_TXT2.text = string.Empty + CURRENT_MONEY;
		GARAGECAMERA.GetComponent<ScreenFader>().reset();
		MAINCAMERA.GetComponent<ScreenFader>().reset();
		GARAGECAMERA.GetComponent<ScreenFader>().fadeState = ScreenFader.FadeState.Out;
		MAINCAMERA.GetComponent<ScreenFader>().fadeState = ScreenFader.FadeState.Out;
		GameObject gameObject = GameObject.FindGameObjectWithTag("CHARACTER");
		gameObject.transform.position = new Vector3(211.5f, 30.45f, 263f);
		gameObject.transform.rotation = Quaternion.Euler(0f, 226f, 0f);
		MENU_CAR.SetActive(value: false);
		MAINMENU_UI.SetActive(value: false);
		GARAGEMENU_UI.SetActive(value: true);
		MAINCAMERA.SetActive(value: false);
		GARAGECAMERA.SetActive(value: true);
		SPAWN_CAR_ = SELECTED_CAR;
		UPGARDE_OBJ.SetActive(value: false);
		TUNING_OBJ.SetActive(value: false);
		StartCoroutine(SPAWN_CAR());
	}

	public void NEXT_CAR()
	{
		TUNING_OBJ.SetActive(value: false);
		UPGARDE_OBJ.SetActive(value: false);
		AudioSource.PlayClipAtPoint(NEXT_SND, GARAGECAMERA.transform.position, 0.5f);
		SPAWN_CAR_++;
		if (SPAWN_CAR_ > 9)
		{
			SPAWN_CAR_ = 0;
		}
		if (CURRENT_CAR_OBJ != null)
		{
			StartCoroutine(SPAWN_CAR());
		}
	}

	public void PREV_CAR()
	{
		TUNING_OBJ.SetActive(value: false);
		UPGARDE_OBJ.SetActive(value: false);
		AudioSource.PlayClipAtPoint(NEXT_SND, GARAGECAMERA.transform.position, 0.5f);
		SPAWN_CAR_--;
		if (SPAWN_CAR_ < 0)
		{
			SPAWN_CAR_ = 9;
		}
		if (CURRENT_CAR_OBJ != null)
		{
			StartCoroutine(SPAWN_CAR());
		}
	}

	private IEnumerator BUY_BUTTON_()
	{
		yield return new WaitForSecondsRealtime(0.7f);
		if (GARAGEMENU_UI.activeInHierarchy)
		{
			BUYCAR_BUTTON.SetActive(value: true);
		}
	}

	private IEnumerator CURRENT_CAR_()
	{
		yield return new WaitForSecondsRealtime(0.7f);
		if (GARAGEMENU_UI.activeInHierarchy)
		{
			CURRENT_CAR.SetActive(value: true);
		}
	}

	private IEnumerator SELECT_CAR_()
	{
		yield return new WaitForSecondsRealtime(0.7f);
		if (GARAGEMENU_UI.activeInHierarchy)
		{
			SELECT_BUTTON.SetActive(value: true);
		}
	}

	private IEnumerator SPAWN_CAR()
	{
		GameObject OBJ_2 = UnityEngine.Object.Instantiate(EFFECT_SPAWN, new Vector3(203.32f, 33f, 261.44f), base.transform.rotation);
		CURRENT_CAR_OBJ = null;
		GameObject[] PREAFAB_ = GameObject.FindGameObjectsWithTag("Player");
		GameObject[] array = PREAFAB_;
		foreach (GameObject obj in array)
		{
			UnityEngine.Object.Destroy(obj);
		}
		yield return new WaitForSecondsRealtime(0.5f);
		if (GARAGEMENU_UI.activeInHierarchy)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate(GARAGE_CARS[SPAWN_CAR_], new Vector3(203.32f, 33f, 261.44f), base.transform.rotation);
			gameObject.transform.rotation = Quaternion.Euler(0f, UnityEngine.Random.Range(0, 360), 0f);
			gameObject.GetComponent<RCC_CarControllerV3>().canControl = false;
			gameObject.GetComponent<SPLASH_>().enabled = false;
			gameObject.GetComponent<Mouse_drag_rotate_scale_control>().enabled = true;
			CURRENT_CAR_OBJ = gameObject;
			AudioSource.PlayClipAtPoint(CARCHANGE_SND, Camera.main.transform.position, 0.5f);
		}
		NEED_LEVEL_POPUP.SetActive(value: false);
		CARINFO_UI.SetActive(value: true);
		COST_OBJ.SetActive(value: false);
		BYED_OBJ.SetActive(value: false);
		if (SPAWN_CAR_ == 0)
		{
			if (LANGUAGE == 1)
			{
				GARAGE_CAR_NAME.text = "ТАКСИ";
			}
			else
			{
				GARAGE_CAR_NAME.text = "TAXI";
			}
			CAR_POWER_INT = 6;
			CAR_SPEED_INT = 4;
			CAR_CONTROL_INT = 5;
			CAR_COST = 3000;
			CAR_LEVEL = 0;
			GARAGE_CAR_COST.text = string.Empty + CAR_COST;
		}
		if (SPAWN_CAR_ == 1)
		{
			if (LANGUAGE == 1)
			{
				GARAGE_CAR_NAME.text = "МОЛНИЯ";
			}
			else
			{
				GARAGE_CAR_NAME.text = "thunder";
			}
			CAR_POWER_INT = 4;
			CAR_SPEED_INT = 5;
			CAR_CONTROL_INT = 6;
			CAR_COST = 8000;
			CAR_LEVEL = 5;
			GARAGE_CAR_COST.text = string.Empty + CAR_COST;
		}
		if (SPAWN_CAR_ == 2)
		{
			if (LANGUAGE == 1)
			{
				GARAGE_CAR_NAME.text = "СКОРАЯ";
			}
			else
			{
				GARAGE_CAR_NAME.text = "medic";
			}
			CAR_POWER_INT = 5;
			CAR_SPEED_INT = 6;
			CAR_CONTROL_INT = 4;
			CAR_COST = 13000;
			CAR_LEVEL = 10;
			GARAGE_CAR_COST.text = string.Empty + CAR_COST;
		}
		if (SPAWN_CAR_ == 3)
		{
			if (LANGUAGE == 1)
			{
				GARAGE_CAR_NAME.text = "ТОРНАДО";
			}
			else
			{
				GARAGE_CAR_NAME.text = "TORNADO";
			}
			CAR_POWER_INT = 7;
			CAR_SPEED_INT = 6;
			CAR_CONTROL_INT = 7;
			CAR_COST = 17000;
			CAR_LEVEL = 17;
			GARAGE_CAR_COST.text = string.Empty + CAR_COST;
		}
		if (SPAWN_CAR_ == 4)
		{
			if (LANGUAGE == 1)
			{
				GARAGE_CAR_NAME.text = "ПОЛИЦИЯ";
			}
			else
			{
				GARAGE_CAR_NAME.text = "police";
			}
			CAR_POWER_INT = 7;
			CAR_SPEED_INT = 8;
			CAR_CONTROL_INT = 7;
			CAR_COST = 27000;
			CAR_LEVEL = 23;
			GARAGE_CAR_COST.text = string.Empty + CAR_COST;
		}
		if (SPAWN_CAR_ == 5)
		{
			if (LANGUAGE == 1)
			{
				GARAGE_CAR_NAME.text = "ВИКИНГ";
			}
			else
			{
				GARAGE_CAR_NAME.text = "VIKING";
			}
			CAR_POWER_INT = 8;
			CAR_SPEED_INT = 6;
			CAR_CONTROL_INT = 5;
			CAR_COST = 34000;
			CAR_LEVEL = 30;
			GARAGE_CAR_COST.text = string.Empty + CAR_COST;
		}
		if (SPAWN_CAR_ == 6)
		{
			if (LANGUAGE == 1)
			{
				GARAGE_CAR_NAME.text = "ЧЕРЕП";
			}
			else
			{
				GARAGE_CAR_NAME.text = "SKULL";
			}
			CAR_POWER_INT = 7;
			CAR_SPEED_INT = 9;
			CAR_CONTROL_INT = 9;
			CAR_COST = 45000;
			CAR_LEVEL = 37;
			GARAGE_CAR_COST.text = string.Empty + CAR_COST;
		}
		if (SPAWN_CAR_ == 7)
		{
			if (LANGUAGE == 1)
			{
				GARAGE_CAR_NAME.text = "ГЕНЕРАЛ";
			}
			else
			{
				GARAGE_CAR_NAME.text = "GENERAL";
			}
			CAR_POWER_INT = 9;
			CAR_SPEED_INT = 9;
			CAR_CONTROL_INT = 8;
			CAR_COST = 60000;
			CAR_LEVEL = 50;
			GARAGE_CAR_COST.text = string.Empty + CAR_COST;
		}
		if (SPAWN_CAR_ == 8)
		{
			if (LANGUAGE == 1)
			{
				GARAGE_CAR_NAME.text = "ПРОЕКТ: X";
			}
			else
			{
				GARAGE_CAR_NAME.text = "PROJECT: X";
			}
			CAR_POWER_INT = 9;
			CAR_SPEED_INT = 9;
			CAR_CONTROL_INT = 9;
			CAR_COST = 70000;
			CAR_LEVEL = 60;
			GARAGE_CAR_COST.text = string.Empty + CAR_COST;
		}
		if (SPAWN_CAR_ == 9)
		{
			if (LANGUAGE == 1)
			{
				GARAGE_CAR_NAME.text = "ПРОЕКТ: Z";
			}
			else
			{
				GARAGE_CAR_NAME.text = "PROJECT: Z";
			}
			CAR_POWER_INT = 9;
			CAR_SPEED_INT = 9;
			CAR_CONTROL_INT = 9;
			CAR_COST = 80000;
			CAR_LEVEL = 70;
			GARAGE_CAR_COST.text = string.Empty + CAR_COST;
		}
		POWER_POLOSA(CAR_POWER_INT);
		SPEED_POLOSA(CAR_SPEED_INT);
		CONTROL_POLOSA(CAR_CONTROL_INT);
		if (SPAWN_CAR_ == 0)
		{
			CURRENT_CAR.SetActive(value: false);
			SELECT_BUTTON.SetActive(value: false);
			if (CAR_1 == 0)
			{
				COST_OBJ.SetActive(value: true);
				BYED_OBJ.SetActive(value: false);
				UPGARDE_OBJ.SetActive(value: false);
				TUNING_OBJ.SetActive(value: false);
				CHECK_CAR();
			}
			else
			{
				UPGARDE_OBJ.SetActive(value: true);
				TUNING_OBJ.SetActive(value: true);
				COST_OBJ.SetActive(value: false);
				BYED_OBJ.SetActive(value: true);
				StopCoroutine(BUY_BUTTON_());
				BUYCAR_BUTTON.SetActive(value: false);
				if (SELECTED_CAR == SPAWN_CAR_)
				{
					StartCoroutine(CURRENT_CAR_());
				}
				else
				{
					StartCoroutine(SELECT_CAR_());
				}
			}
		}
		if (SPAWN_CAR_ == 1)
		{
			CURRENT_CAR.SetActive(value: false);
			SELECT_BUTTON.SetActive(value: false);
			if (CAR_2 == 0)
			{
				COST_OBJ.SetActive(value: true);
				BYED_OBJ.SetActive(value: false);
				UPGARDE_OBJ.SetActive(value: false);
				TUNING_OBJ.SetActive(value: false);
				CHECK_CAR();
			}
			else
			{
				UPGARDE_OBJ.SetActive(value: true);
				TUNING_OBJ.SetActive(value: true);
				COST_OBJ.SetActive(value: false);
				BYED_OBJ.SetActive(value: true);
				StopCoroutine(BUY_BUTTON_());
				BUYCAR_BUTTON.SetActive(value: false);
				if (SELECTED_CAR == SPAWN_CAR_)
				{
					StartCoroutine(CURRENT_CAR_());
				}
				else
				{
					StartCoroutine(SELECT_CAR_());
				}
			}
		}
		if (SPAWN_CAR_ == 2)
		{
			CURRENT_CAR.SetActive(value: false);
			SELECT_BUTTON.SetActive(value: false);
			if (CAR_3 == 0)
			{
				COST_OBJ.SetActive(value: true);
				BYED_OBJ.SetActive(value: false);
				UPGARDE_OBJ.SetActive(value: false);
				TUNING_OBJ.SetActive(value: false);
				CHECK_CAR();
			}
			else
			{
				UPGARDE_OBJ.SetActive(value: true);
				TUNING_OBJ.SetActive(value: true);
				COST_OBJ.SetActive(value: false);
				BYED_OBJ.SetActive(value: true);
				StopCoroutine(BUY_BUTTON_());
				BUYCAR_BUTTON.SetActive(value: false);
				if (SELECTED_CAR == SPAWN_CAR_)
				{
					StartCoroutine(CURRENT_CAR_());
				}
				else
				{
					StartCoroutine(SELECT_CAR_());
				}
			}
		}
		if (SPAWN_CAR_ == 3)
		{
			CURRENT_CAR.SetActive(value: false);
			SELECT_BUTTON.SetActive(value: false);
			if (CAR_4 == 0)
			{
				COST_OBJ.SetActive(value: true);
				BYED_OBJ.SetActive(value: false);
				UPGARDE_OBJ.SetActive(value: false);
				TUNING_OBJ.SetActive(value: false);
				CHECK_CAR();
			}
			else
			{
				UPGARDE_OBJ.SetActive(value: true);
				TUNING_OBJ.SetActive(value: true);
				COST_OBJ.SetActive(value: false);
				BYED_OBJ.SetActive(value: true);
				StopCoroutine(BUY_BUTTON_());
				BUYCAR_BUTTON.SetActive(value: false);
				if (SELECTED_CAR == SPAWN_CAR_)
				{
					StartCoroutine(CURRENT_CAR_());
				}
				else
				{
					StartCoroutine(SELECT_CAR_());
				}
			}
		}
		if (SPAWN_CAR_ == 4)
		{
			CURRENT_CAR.SetActive(value: false);
			SELECT_BUTTON.SetActive(value: false);
			if (CAR_5 == 0)
			{
				COST_OBJ.SetActive(value: true);
				BYED_OBJ.SetActive(value: false);
				UPGARDE_OBJ.SetActive(value: false);
				TUNING_OBJ.SetActive(value: false);
				CHECK_CAR();
			}
			else
			{
				UPGARDE_OBJ.SetActive(value: true);
				TUNING_OBJ.SetActive(value: true);
				COST_OBJ.SetActive(value: false);
				BYED_OBJ.SetActive(value: true);
				StopCoroutine(BUY_BUTTON_());
				BUYCAR_BUTTON.SetActive(value: false);
				if (SELECTED_CAR == SPAWN_CAR_)
				{
					StartCoroutine(CURRENT_CAR_());
				}
				else
				{
					StartCoroutine(SELECT_CAR_());
				}
			}
		}
		if (SPAWN_CAR_ == 5)
		{
			CURRENT_CAR.SetActive(value: false);
			SELECT_BUTTON.SetActive(value: false);
			if (CAR_6 == 0)
			{
				COST_OBJ.SetActive(value: true);
				BYED_OBJ.SetActive(value: false);
				UPGARDE_OBJ.SetActive(value: false);
				TUNING_OBJ.SetActive(value: false);
				CHECK_CAR();
			}
			else
			{
				UPGARDE_OBJ.SetActive(value: true);
				TUNING_OBJ.SetActive(value: true);
				COST_OBJ.SetActive(value: false);
				BYED_OBJ.SetActive(value: true);
				StopCoroutine(BUY_BUTTON_());
				BUYCAR_BUTTON.SetActive(value: false);
				if (SELECTED_CAR == SPAWN_CAR_)
				{
					StartCoroutine(CURRENT_CAR_());
				}
				else
				{
					StartCoroutine(SELECT_CAR_());
				}
			}
		}
		if (SPAWN_CAR_ == 6)
		{
			CURRENT_CAR.SetActive(value: false);
			SELECT_BUTTON.SetActive(value: false);
			if (CAR_7 == 0)
			{
				COST_OBJ.SetActive(value: true);
				BYED_OBJ.SetActive(value: false);
				UPGARDE_OBJ.SetActive(value: false);
				TUNING_OBJ.SetActive(value: false);
				CHECK_CAR();
			}
			else
			{
				UPGARDE_OBJ.SetActive(value: true);
				TUNING_OBJ.SetActive(value: true);
				COST_OBJ.SetActive(value: false);
				BYED_OBJ.SetActive(value: true);
				StopCoroutine(BUY_BUTTON_());
				BUYCAR_BUTTON.SetActive(value: false);
				if (SELECTED_CAR == SPAWN_CAR_)
				{
					StartCoroutine(CURRENT_CAR_());
				}
				else
				{
					StartCoroutine(SELECT_CAR_());
				}
			}
		}
		if (SPAWN_CAR_ == 7)
		{
			CURRENT_CAR.SetActive(value: false);
			SELECT_BUTTON.SetActive(value: false);
			if (CAR_8 == 0)
			{
				COST_OBJ.SetActive(value: true);
				BYED_OBJ.SetActive(value: false);
				UPGARDE_OBJ.SetActive(value: false);
				TUNING_OBJ.SetActive(value: false);
				CHECK_CAR();
			}
			else
			{
				UPGARDE_OBJ.SetActive(value: true);
				TUNING_OBJ.SetActive(value: true);
				COST_OBJ.SetActive(value: false);
				BYED_OBJ.SetActive(value: true);
				StopCoroutine(BUY_BUTTON_());
				BUYCAR_BUTTON.SetActive(value: false);
				if (SELECTED_CAR == SPAWN_CAR_)
				{
					StartCoroutine(CURRENT_CAR_());
				}
				else
				{
					StartCoroutine(SELECT_CAR_());
				}
			}
		}
		if (SPAWN_CAR_ == 8)
		{
			CURRENT_CAR.SetActive(value: false);
			SELECT_BUTTON.SetActive(value: false);
			if (CAR_9 == 0)
			{
				COST_OBJ.SetActive(value: true);
				BYED_OBJ.SetActive(value: false);
				UPGARDE_OBJ.SetActive(value: false);
				TUNING_OBJ.SetActive(value: false);
				CHECK_CAR();
			}
			else
			{
				UPGARDE_OBJ.SetActive(value: true);
				TUNING_OBJ.SetActive(value: true);
				COST_OBJ.SetActive(value: false);
				BYED_OBJ.SetActive(value: true);
				StopCoroutine(BUY_BUTTON_());
				BUYCAR_BUTTON.SetActive(value: false);
				if (SELECTED_CAR == SPAWN_CAR_)
				{
					StartCoroutine(CURRENT_CAR_());
				}
				else
				{
					StartCoroutine(SELECT_CAR_());
				}
			}
		}
		if (SPAWN_CAR_ != 9)
		{
			yield break;
		}
		CURRENT_CAR.SetActive(value: false);
		SELECT_BUTTON.SetActive(value: false);
		if (CAR_10 == 0)
		{
			COST_OBJ.SetActive(value: true);
			BYED_OBJ.SetActive(value: false);
			UPGARDE_OBJ.SetActive(value: false);
			TUNING_OBJ.SetActive(value: false);
			CHECK_CAR();
			yield break;
		}
		UPGARDE_OBJ.SetActive(value: true);
		TUNING_OBJ.SetActive(value: true);
		COST_OBJ.SetActive(value: false);
		BYED_OBJ.SetActive(value: true);
		StopCoroutine(BUY_BUTTON_());
		BUYCAR_BUTTON.SetActive(value: false);
		if (SELECTED_CAR == SPAWN_CAR_)
		{
			StartCoroutine(CURRENT_CAR_());
		}
		else
		{
			StartCoroutine(SELECT_CAR_());
		}
	}

	private IEnumerator START_VOICE()
	{
		yield return new WaitForSecondsRealtime(1f);
		if (LANGUAGE == 1)
		{
			AudioSource.PlayClipAtPoint(VOICE_WELCOME[UnityEngine.Random.Range(0, VOICE_WELCOME.Length)], MAINCAMERA.transform.position, 1f);
		}
	}

	private IEnumerator BUY_FX_()
	{
		BUY_FX.SetActive(value: true);
		GameObject OBJ_22 = UnityEngine.Object.Instantiate(BUY_FX2, new Vector3(203.15f, 29.46f, 261.43f), base.transform.rotation);
		yield return new WaitForSecondsRealtime(5f);
		BUY_FX.SetActive(value: false);
	}

	private IEnumerator NEWCAR_POPUP_()
	{
		NEWCAR_POPUP.SetActive(value: true);
		yield return new WaitForSecondsRealtime(10f);
		NEWCAR_POPUP.SetActive(value: false);
	}

	public void SELECT_CAR()
	{
		AudioSource.PlayClipAtPoint(CAR_SND, GARAGECAMERA.transform.position, 1f);
		ES2.Save(SPAWN_CAR_, "SELECT_CAR");
		SELECTED_CAR = ES2.Load<int>("SELECT_CAR");
		SELECT_BUTTON.SetActive(value: false);
		CURRENT_CAR.SetActive(value: true);
	}

	public void BUY_CAR_ACCEPT()
	{
		StartCoroutine(BUY_FX_());
		StartCoroutine(NEWCAR_POPUP_());
		AudioSource.PlayClipAtPoint(CLICK_SND, GARAGECAMERA.transform.position, 0.5f);
		AudioSource.PlayClipAtPoint(BUY_CAR_SND, GARAGECAMERA.transform.position, 1f);
		BUYCAR_BUTTON.SetActive(value: false);
		CURRENT_CAR.SetActive(value: true);
		BUYCAR_UI.SetActive(value: false);
		CURRENT_MONEY -= CAR_COST;
		ES2.Save(SPAWN_CAR_, "SELECT_CAR");
		int num = SPAWN_CAR_ + 1;
		ES2.Save(1, "CAR" + num);
		ES2.Save(CURRENT_MONEY, "PLAYER_MONEY");
		SELECTED_CAR = ES2.Load<int>("SELECT_CAR");
		CURRENT_MONEY = ES2.Load<int>("PLAYER_MONEY");
		CURRENT_MONEY_TXT2.text = string.Empty + CURRENT_MONEY;
		CAR_1 = ES2.Load<int>("CAR1");
		CAR_2 = ES2.Load<int>("CAR2");
		CAR_3 = ES2.Load<int>("CAR3");
		CAR_4 = ES2.Load<int>("CAR4");
		CAR_5 = ES2.Load<int>("CAR5");
		CAR_6 = ES2.Load<int>("CAR6");
		CAR_7 = ES2.Load<int>("CAR7");
		CAR_8 = ES2.Load<int>("CAR8");
		CAR_9 = ES2.Load<int>("CAR9");
		CAR_10 = ES2.Load<int>("CAR10");
		UPGARDE_OBJ.SetActive(value: true);
		TUNING_OBJ.SetActive(value: true);
		if (LANGUAGE == 1)
		{
			AudioSource.PlayClipAtPoint(BUY_CAR_VOICE, GARAGECAMERA.transform.position, 1f);
		}
		if ((ES2.Load<int>("TUTORIAL_3") == 0) & (ES2.Load<int>("CAR1") == 1))
		{
			TUTORIAL3.SetActive(value: true);
			ES2.Save(1, "TUTORIAL_3");
		}
	}

	public void BUY_CAR_CANCEL()
	{
		AudioSource.PlayClipAtPoint(BACK_SND, GARAGECAMERA.transform.position, 0.5f);
		BUYCAR_UI.SetActive(value: false);
	}

	public void BUY_CAR()
	{
		AudioSource.PlayClipAtPoint(CLICK_SND, GARAGECAMERA.transform.position, 0.5f);
		if (CURRENT_CAR_OBJ != null)
		{
			BUYCAR_UI.SetActive(value: true);
		}
	}

	private void CHECK_CAR()
	{
		StartCoroutine(BUY_BUTTON_());
		if (PLAYER_LEVEL < CAR_LEVEL)
		{
			BUYCAR_BUTTON.GetComponent<Button>().interactable = false;
			BUYCAR_BUTTON.GetComponent<Image>().sprite = BUYCAR_NOT_AVAILIBLE;
			ZAMOK_IMAGE.SetActive(value: true);
			BUYCAR_TEXT.color = new Color(1f, 1f, 1f, 0.5f);
			if (LANGUAGE == 1)
			{
				NEEDLV_TXT.text = "НЕОБХОДИМ УРОВЕНЬ " + CAR_LEVEL + "!";
			}
			else
			{
				NEEDLV_TXT.text = "NEED LEVEL " + CAR_LEVEL + "!";
			}
			NEED_LEVEL_POPUP.SetActive(value: true);
			return;
		}
		ZAMOK_IMAGE.SetActive(value: false);
		BUYCAR_BUTTON.GetComponent<Button>().interactable = true;
		BUYCAR_BUTTON.GetComponent<Image>().sprite = BUYCAR_AVAILIBLE;
		BUYCAR_TEXT.color = new Color(1f, 1f, 1f, 1f);
		NEED_LEVEL_POPUP.SetActive(value: false);
		if (CURRENT_MONEY < CAR_COST)
		{
			BUYCAR_BUTTON.GetComponent<Button>().interactable = false;
			BUYCAR_BUTTON.GetComponent<Image>().sprite = BUYCAR_NOT_AVAILIBLE;
			ZAMOK_IMAGE.SetActive(value: true);
			BUYCAR_TEXT.color = new Color(1f, 1f, 1f, 0.5f);
		}
		else
		{
			ZAMOK_IMAGE.SetActive(value: false);
			BUYCAR_BUTTON.GetComponent<Button>().interactable = true;
			BUYCAR_BUTTON.GetComponent<Image>().sprite = BUYCAR_AVAILIBLE;
			BUYCAR_TEXT.color = new Color(1f, 1f, 1f, 1f);
		}
	}

	public void CLOSE_GARAGE()
	{
		TIRE_SMOKE_3D.SetActive(value: true);
		AudioSource.PlayClipAtPoint(CLICK_SND, MAINCAMERA.transform.position, 0.5f);
		if (CURRENT_CAR_OBJ != null)
		{
			StopCoroutine(SELECT_CAR_());
			StopCoroutine(CURRENT_CAR_());
			StopCoroutine(SPAWN_CAR());
			StopCoroutine(BUY_BUTTON_());
			GameObject[] array = GameObject.FindGameObjectsWithTag("Player");
			GameObject[] array2 = array;
			foreach (GameObject obj in array2)
			{
				UnityEngine.Object.Destroy(obj);
			}
			SELECT_BUTTON.SetActive(value: false);
			CURRENT_CAR.SetActive(value: false);
			BUYCAR_BUTTON.SetActive(value: false);
			GARAGECAMERA.GetComponent<ScreenFader>().reset();
			MAINCAMERA.GetComponent<ScreenFader>().reset();
			GARAGECAMERA.GetComponent<ScreenFader>().fadeState = ScreenFader.FadeState.Out;
			MAINCAMERA.GetComponent<ScreenFader>().fadeState = ScreenFader.FadeState.Out;
			MAINMENU_UI.SetActive(value: true);
			GARAGEMENU_UI.SetActive(value: false);
			MAINCAMERA.SetActive(value: true);
			GARAGECAMERA.SetActive(value: false);
			CARINFO_UI.SetActive(value: false);
			MENU_CAR.SetActive(value: true);
			GameObject gameObject = GameObject.FindGameObjectWithTag("CHARACTER");
			gameObject.transform.position = new Vector3(201.23f, 30.45f, 263.23f);
			gameObject.transform.rotation = Quaternion.Euler(0f, 230.5f, 0f);
		}
		if (ES2.Load<int>("BLOOMFX") == 1)
		{
			MAINCAMERA.GetComponent<FxPro>().enabled = false;
			MAINCAMERA.GetComponent<FxPro>().enabled = true;
		}
	}

	public void GET_BONUS()
	{
		TIRE_SMOKE_3D.SetActive(value: false);
		AudioSource.PlayClipAtPoint(CLICK_SND, MAINCAMERA.transform.position, 0.5f);
		BONUSMENU_UI.SetActive(value: true);
		MAINMENU_UI.SetActive(value: false);
		CURRENT_MONEY = ES2.Load<int>("PLAYER_MONEY");
		CURRENT_MONEY_TXT.text = string.Empty + CURRENT_MONEY;
	}

	public void TO_MAINMENU()
	{
		TIRE_SMOKE_3D.SetActive(value: true);
		AudioSource.PlayClipAtPoint(CLICK_SND, MAINCAMERA.transform.position, 0.5f);
		if (OLD_MONEY_ < 1)
		{
			BONUSMENU_UI.SetActive(value: false);
			MAINMENU_UI.SetActive(value: true);
		}
	}

	public void GETBONUS_POPUP()
	{
		BONUSGET_UI.SetActive(value: true);
		MONEY_ADD_BONUS_TXT.text = "+" + MONEY_;
	}

	public void CANCELBONUS_POPUP()
	{
		AudioSource.PlayClipAtPoint(CLICK_SND, MAINCAMERA.transform.position, 0.5f);
		BONUSGET_UI.SetActive(value: false);
	}

	public void GRAB_BONUS()
	{
		if (LANGUAGE == 1)
		{
			AudioSource.PlayClipAtPoint(VOICE_BONUS, MAINCAMERA.transform.position, 1f);
		}
		AudioSource.PlayClipAtPoint(CLICK_SND, MAINCAMERA.transform.position, 0.5f);
		int num = ES2.Load<int>("BONUS_DAY");
		num++;
		if (num == 20)
		{
			num = 0;
		}
		ES2.Save(num, "BONUS_DAY");
		ResetNextRewardTime();
		BONUS_AVAILABLE = false;
		BONUSGET_UI.SetActive(value: false);
		BONUSMENU_UI.SetActive(value: false);
		BONUSMENU_UI.SetActive(value: true);
		ADD_MONEY_ = true;
	}

	private void BONUS()
	{
		if (CanRewardNow())
		{
			if (LANGUAGE == 1)
			{
				BONUS_TXT.text = "ПОЛУЧИТЬ БОНУС";
			}
			else
			{
				BONUS_TXT.text = "GET BONUS";
			}
			BONUS_AVAILABLE = true;
		}
		else
		{
			BONUS_BUTTON.interactable = false;
			BONUS_AVAILABLE = false;
			TimeSpan timeUntilReward = TimeUntilReward;
			if (LANGUAGE == 1)
			{
				BONUS_TXT.text = $"БУДЕТ ЧЕРЕЗ {timeUntilReward.Hours:00}:{timeUntilReward.Minutes:00}:{timeUntilReward.Seconds:00}";
			}
			else
			{
				BONUS_TXT.text = $"WILL BE {timeUntilReward.Hours:00}:{timeUntilReward.Minutes:00}:{timeUntilReward.Seconds:00}";
			}
		}
		if (ADD_MONEY_)
		{
			OLD_MONEY_ = MONEY_;
			MONEY_ = 0;
			ADD_MONEY_ = false;
		}
		if (OLD_MONEY_ > 0)
		{
			TIMER_ += Time.deltaTime;
			if (TIMER_ > 0.1f)
			{
				OLD_MONEY_ -= 100;
				CURRENT_MONEY += 100;
				CURRENT_MONEY_TXT.text = string.Empty + CURRENT_MONEY;
				AudioSource.PlayClipAtPoint(MONEY_SND, Camera.main.transform.position);
				TIMER_ = 0f;
			}
			if (OLD_MONEY_ < 2)
			{
				ES2.Save(CURRENT_MONEY, "PLAYER_MONEY");
			}
		}
	}

	private void POWER_POLOSA(int INT)
	{
		for (int i = 0; i < CARINFO_POWER.Length; i++)
		{
			CARINFO_POWER[i].GetComponent<Image>().sprite = planka_off;
			CARINFO_POWER[i].GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 0.8f);
		}
		for (int j = 0; j < INT; j++)
		{
			CARINFO_POWER[j].GetComponent<Image>().sprite = planka_power;
			CARINFO_POWER[j].GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
		}
	}

	private void SPEED_POLOSA(int INT)
	{
		for (int i = 0; i < CARINFO_SPEED.Length; i++)
		{
			CARINFO_SPEED[i].GetComponent<Image>().sprite = planka_off;
			CARINFO_SPEED[i].GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 0.8f);
		}
		for (int j = 0; j < INT; j++)
		{
			CARINFO_SPEED[j].GetComponent<Image>().sprite = planka_speed;
			CARINFO_SPEED[j].GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
		}
	}

	private void CONTROL_POLOSA(int INT)
	{
		for (int i = 0; i < CARINFO_CONTROL.Length; i++)
		{
			CARINFO_CONTROL[i].GetComponent<Image>().sprite = planka_off;
			CARINFO_CONTROL[i].GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 0.8f);
		}
		for (int j = 0; j < INT; j++)
		{
			CARINFO_CONTROL[j].GetComponent<Image>().sprite = planka_control;
			CARINFO_CONTROL[j].GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
		}
	}

	public void ResetNextRewardTime()
	{
		DateTime time = DateTime.Now.Add(new TimeSpan(24, 0, 0));
		StoreNextRewardTime(time);
	}

	private void StoreNextRewardTime(DateTime time)
	{
		ES2.Save(time.ToBinary().ToString(), "NextRewardTimePPK");
	}

	private DateTime GetNextRewardTime()
	{
		string value = ES2.Load<string>("NextRewardTimePPK");
		if (!string.IsNullOrEmpty(value))
		{
			return DateTime.FromBinary(Convert.ToInt64(value));
		}
		return DateTime.Now;
	}

	public bool CanRewardNow()
	{
		return TimeUntilReward <= TimeSpan.Zero;
	}

	public void OPEN_ACHIV_MENU()
	{
		AudioSource.PlayClipAtPoint(CLICK_SND, Camera.main.transform.position);
		ACHIV_MENU.SetActive(value: true);
	}

	public void CLOSE_ACHIV_MENU()
	{
		AudioSource.PlayClipAtPoint(BACK_SND, Camera.main.transform.position);
		ACHIV_MENU.SetActive(value: false);
	}

	public void OPEN_ACHIV()
	{
		AudioSource.PlayClipAtPoint(CLICK_SND, Camera.main.transform.position);
		ACHIV_MENU.SetActive(value: false);
	}

	public void OPEN_LEAD()
	{
		AudioSource.PlayClipAtPoint(CLICK_SND, Camera.main.transform.position);
		ACHIV_MENU.SetActive(value: false);
	}
}
