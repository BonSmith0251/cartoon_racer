using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SCHOOL_MANAGER : MonoBehaviour
{
	public GameObject TUTORIAL;

	public GameObject TUTORIAL2;

	public GameObject TUTORIAL3;

	public GameObject TUTORIAL4;

	public AudioClip CLICK;

	public GameObject LOADING_SCREEN;

	public GameObject TAXI_LICENSE_GET_UI;

	public GameObject MEDIC_LICENSE_GET_UI;

	public GameObject COP_LICENSE_GET_UI;

	public Image TAXI_PROGRESS_FILL;

	public Text TAXI_PROGRESS_TXT;

	public Image MEDIC_PROGRESS_FILL;

	public Text MEDIC_PROGRESS_TXT;

	public Image COP_PROGRESS_FILL;

	public Text COP_PROGRESS_TXT;

	public GameObject SKIP_UI;

	public GameObject NITROS_PREFABS;

	public Text CUR_TARGET;

	public Text ALL_TARGET;

	public GameObject TARGET_UI;

	public GameObject NITRO_AVA;

	public GameObject FALIED_UI;

	public GameObject COMPLETE_UI;

	public AudioClip SHTRAF_SND;

	public CameraFilterPack_Color_GrayScale FGX_;

	private float FGX_power;

	public static bool SHTRAF;

	public GameObject PICKUP_OBJ4;

	public GameObject PROGRESS_UI;

	public GameObject START_OBJ;

	private float start_timer;

	private int start_count;

	public Image START_IMG;

	public Image START_IMG2;

	public Image START_IMG3;

	public Sprite SPR_START1;

	public Sprite SPR_START2;

	public Sprite SPR_START3;

	public AudioClip SIGNAL_1;

	public AudioClip SIGNAL_2;

	public GameObject TAXI_SCHOOL_UI;

	public GameObject MEDIC_SCHOOL_UI;

	public GameObject COP_SCHOOL_UI;

	public GameObject RCC_CAMERA;

	public GameObject CAM_FX2;

	public Image NOS_IMG;

	public GameObject NOS_FULL_IMG;

	public GameObject HYDRANT_FX;

	public GameObject[] PLAYER_PREFAB;

	private GameObject PLAYER_;

	public Image PROGRESS_TIME;

	public AudioClip[] FENCE_;

	public AudioClip[] TRASH_;

	public AudioClip[] LIGHT_;

	public AudioClip[] STRAW_;

	public AudioClip[] BARREL_;

	public AudioClip[] BOX_;

	public AudioClip METAL_1;

	public AudioClip HYDRANT_SND;

	private float cam_fx_alpha2;

	private int HIT_RND;

	private int SCR_X;

	private int SCR_Y;

	private float X_COORD;

	private float Z_COORD;

	private float ROT_COORD;

	public static float TIME;

	public static float REAL_TIME;

	public static int NEED_CHECKPOINTS;

	private float AUDIOLISTENER_volume;

	private float MUSIC_VOLUME;

	private float MAIN_VOLUME;

	private float DISPLAY_RESOLUTION;

	public GameObject[] PARKING_LEVELS;

	public GameObject[] CHECKPOINT_LEVELS;

	public GameObject[] ORIENTIR_LEVELS;

	public GameObject[] GUARD_LEVELS;

	public static int INDEX_ORIENTIR;

	public static int SELECTED_LEVEL;

	public static string SELECTED_TYPE;

	public static bool RESTORE;

	private int INDEX_;

	public static int RESTORES;

	private int ALL_CHECKPOINTS_NEED;

	public static bool FALIED;

	public static bool FINISH;

	public static float PROGRESS_;

	public GameObject PAUSE_UI_MAIN;

	public GameObject PAUSE_UI;

	public GameObject PAUSE_REAL_QUIT;

	public GameObject PAUSE_REAL_RESTART;

	public Button SKIP_BUTTON;

	public Sprite SKIP_AVAILBE;

	public Sprite SKIP_NO_AVAILBE;

	public Text SKIP_TXT;

	public void OPEN_SKIP()
	{
		PAUSE_UI.SetActive(value: false);
		if (ES2.Load<int>("SKIP_TODAY") > 0)
		{
			SKIP_UI.SetActive(value: true);
		}
	}

	public void RESTART_CANCEL()
	{
		PAUSE_REAL_RESTART.SetActive(value: false);
		PAUSE_UI_MAIN.SetActive(value: true);
	}

	public void OPEN_RESTART()
	{
		PAUSE_REAL_RESTART.SetActive(value: true);
		PAUSE_UI_MAIN.SetActive(value: false);
	}

	public void QUIT_ACCEPT()
	{
		Time.timeScale = 1f;
		PAUSE_UI.SetActive(value: false);
		Application.LoadLevel(5);
	}

	public void QUIT_CANCEL()
	{
		PAUSE_REAL_QUIT.SetActive(value: false);
		PAUSE_UI_MAIN.SetActive(value: true);
	}

	public void OPEN_QUIT()
	{
		PAUSE_REAL_QUIT.SetActive(value: true);
		PAUSE_UI_MAIN.SetActive(value: false);
	}

	public void OPEN_PAUSE()
	{
		PAUSE_UI_MAIN.SetActive(value: true);
		if (ES2.Load<int>("SKIP_TODAY") > 0)
		{
			SKIP_TXT.color = new Color(1f, 1f, 1f, 1f);
			SKIP_BUTTON.GetComponent<Image>().sprite = SKIP_AVAILBE;
			SKIP_BUTTON.GetComponent<Button>().interactable = true;
		}
		else
		{
			SKIP_TXT.color = new Color(1f, 1f, 1f, 0.5f);
			SKIP_BUTTON.GetComponent<Button>().interactable = false;
			SKIP_BUTTON.GetComponent<Image>().sprite = SKIP_NO_AVAILBE;
		}
		AudioListener.volume = 0f;
		AUDIOLISTENER_volume = 0f;
		Time.timeScale = 0f;
		PAUSE_UI.SetActive(value: true);
		Camera.main.GetComponent<CameraFilterPack_Color_GrayScale>().enabled = true;
		Camera.main.GetComponent<CameraFilterPack_Color_GrayScale>()._Fade = 1f;
	}

	public void RESUME()
	{
		Time.timeScale = 1f;
		PAUSE_UI.SetActive(value: false);
		Camera.main.GetComponent<CameraFilterPack_Color_GrayScale>().enabled = false;
		Camera.main.GetComponent<CameraFilterPack_Color_GrayScale>()._Fade = 0f;
	}

	private void Start()
	{
		FALIED_UI.SetActive(value: false);
		string text = ES2.Load<string>("SKIP_DAY");
		string text2 = DateTime.Now.ToShortDateString();
		if (text != text2)
		{
			ES2.Save(DateTime.Now.ToShortDateString(), "SKIP_DAY");
			ES2.Save(3, "SKIP_TODAY");
		}
		GameObject gameObject = GameObject.FindGameObjectWithTag("Player");
		if (gameObject != null)
		{
			UnityEngine.Object.Destroy(gameObject);
		}
		PROGRESS_ = 0f;
		TAXI_SCHOOL_UI.SetActive(value: false);
		MEDIC_SCHOOL_UI.SetActive(value: false);
		COP_SCHOOL_UI.SetActive(value: false);
		if (MENU_MANAGER.SELECT_SCHOOL_ == 1)
		{
			TAXI_SCHOOL_UI.SetActive(value: true);
		}
		if (MENU_MANAGER.SELECT_SCHOOL_ == 2)
		{
			MEDIC_SCHOOL_UI.SetActive(value: true);
		}
		if (MENU_MANAGER.SELECT_SCHOOL_ == 3)
		{
			COP_SCHOOL_UI.SetActive(value: true);
		}
		TARGET_UI.SetActive(value: false);
		start_count = 0;
		start_timer = 0f;
		FINISH = false;
		FALIED = false;
		ALL_CHECKPOINTS_NEED = 0;
		NEED_CHECKPOINTS = 0;
		TIME = 0f;
		REAL_TIME = 1f;
		GAME_MANAGER.PICKUP_OBJ4_ = PICKUP_OBJ4;
		GAME_MANAGER.HYDRANT_FX_ = HYDRANT_FX;
		GAME_MANAGER.PLAYER_NITRO_CONSUM = 2f;
		GAME_MANAGER.ZOOM_MAP = true;
		GAME_MANAGER.PLAYER_FUEL = 999f;
		AudioListener.volume = 0f;
		AUDIOLISTENER_volume = 0f;
		MUSIC_VOLUME = ES2.Load<float>("MUSIC_VOLUME");
		MAIN_VOLUME = ES2.Load<float>("MAIN_VOLUME");
		Screen.sleepTimeout = -1;
		Application.targetFrameRate = 60;
		Time.timeScale = 1f;
		if (ES2.Load<int>("BLOOMFX") == 1)
		{
			Camera.main.GetComponent<FxPro>().enabled = true;
		}
		if (ES2.Load<int>("VIEW_DISTANCE") == 0)
		{
			RenderSettings.fog = true;
			Camera.main.farClipPlane = 150f;
			RenderSettings.fogStartDistance = 120f;
			RenderSettings.fogEndDistance = 155f;
		}
		if (ES2.Load<int>("VIEW_DISTANCE") == 1)
		{
			RenderSettings.fog = true;
			Camera.main.farClipPlane = 200f;
			RenderSettings.fogStartDistance = 180f;
			RenderSettings.fogEndDistance = 205f;
		}
		if (ES2.Load<int>("VIEW_DISTANCE") == 2)
		{
			RenderSettings.fog = true;
			Camera.main.farClipPlane = 240f;
			RenderSettings.fogStartDistance = 190f;
			RenderSettings.fogEndDistance = 245f;
		}
		if (ES2.Load<int>("VIEW_DISTANCE") == 3)
		{
			RenderSettings.fog = true;
			Camera.main.farClipPlane = 280f;
			RenderSettings.fogStartDistance = 250f;
			RenderSettings.fogEndDistance = 285f;
		}
		RCC_Settings.Instance.controllerType = RCC_Settings.ControllerType.Keyboard;
		START_OBJ.SetActive(value: false);
		PROGRESS_UI.SetActive(value: false);
		StartCoroutine(CHECK_());
	}

	public void GET_TAXI_LICENSE()
	{
		ES2.Save(1, "TAXI_LICENSE");
		TAXI_LICENSE_GET_UI.SetActive(value: false);
		AudioSource.PlayClipAtPoint(CLICK, Camera.main.transform.position);
	}

	public void GET_MEDIC_LICENSE()
	{
		ES2.Save(1, "MEDIC_LICENSE");
		MEDIC_LICENSE_GET_UI.SetActive(value: false);
		AudioSource.PlayClipAtPoint(CLICK, Camera.main.transform.position);
	}

	public void GET_COP_LICENSE()
	{
		ES2.Save(1, "COP_LICENSE");
		COP_LICENSE_GET_UI.SetActive(value: false);
		AudioSource.PlayClipAtPoint(CLICK, Camera.main.transform.position);
	}

	public void EXIT()
	{
		Application.LoadLevel(0);
	}

	private IEnumerator CHECK_()
	{
		yield return new WaitForSecondsRealtime(2f);
		if (TAXI_SCHOOL_UI.activeInHierarchy && ((PROGRESS_ > 99f) & (ES2.Load<int>("TAXI_LICENSE") == 0)))
		{
			TAXI_LICENSE_GET_UI.SetActive(value: true);
		}
		if (MEDIC_SCHOOL_UI.activeInHierarchy && ((PROGRESS_ > 99f) & (ES2.Load<int>("MEDIC_LICENSE") == 0)))
		{
			MEDIC_LICENSE_GET_UI.SetActive(value: true);
		}
		if (COP_SCHOOL_UI.activeInHierarchy && ((PROGRESS_ > 99f) & (ES2.Load<int>("COP_LICENSE") == 0)))
		{
			COP_LICENSE_GET_UI.SetActive(value: true);
		}
	}

	private void Update()
	{
		if (!FINISH & !FALIED & !PAUSE_UI.activeInHierarchy & Input.GetKeyUp(KeyCode.Escape))
		{
			OPEN_PAUSE();
		}
		if (Time.frameCount % 10 == 0)
		{
			if (TAXI_SCHOOL_UI.activeInHierarchy)
			{
				TAXI_PROGRESS_FILL.fillAmount = PROGRESS_ / 100f;
				if (MENU_MANAGER.LANGUAGE == 1)
				{
					TAXI_PROGRESS_TXT.text = "ПРОГРЕСС " + Mathf.Round(PROGRESS_) + " %";
				}
				else
				{
					TAXI_PROGRESS_TXT.text = "PROGRESS " + Mathf.Round(PROGRESS_) + " %";
				}
			}
			if (MEDIC_SCHOOL_UI.activeInHierarchy)
			{
				MEDIC_PROGRESS_FILL.fillAmount = PROGRESS_ / 100f;
				if (MENU_MANAGER.LANGUAGE == 1)
				{
					MEDIC_PROGRESS_TXT.text = "ПРОГРЕСС " + Mathf.Round(PROGRESS_) + " %";
				}
				else
				{
					MEDIC_PROGRESS_TXT.text = "PROGRESS " + Mathf.Round(PROGRESS_) + " %";
				}
			}
			if (COP_SCHOOL_UI.activeInHierarchy)
			{
				COP_PROGRESS_FILL.fillAmount = PROGRESS_ / 100f;
				if (MENU_MANAGER.LANGUAGE == 1)
				{
					COP_PROGRESS_TXT.text = "ПРОГРЕСС " + Mathf.Round(PROGRESS_) + " %";
				}
				else
				{
					COP_PROGRESS_TXT.text = "PROGRESS " + Mathf.Round(PROGRESS_) + " %";
				}
			}
		}
		if (GAME_MANAGER.DEVIL_TIMER > 0f)
		{
			GAME_MANAGER.DEVIL_TIMER -= Time.deltaTime * 4f;
			if (Camera.main.transform.rotation.eulerAngles.z < 180f)
			{
				Camera.main.transform.Rotate(0f, 0f, 5f, Space.Self);
			}
			if (GAME_MANAGER.DEVIL_TIMER < 0.01f)
			{
				GAME_MANAGER.DEVIL_TIMER = 0f;
				Camera.main.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
			}
		}
		PLAYER_EVENTS();
		if (Time.frameCount % 3 == 0)
		{
			PROGRESS_TIME.fillAmount = REAL_TIME;
			if (FGX_power > 0f)
			{
				FGX_power -= Time.deltaTime;
				FGX_.enabled = true;
				FGX_._Fade = FGX_power;
				if (FGX_power < 0.01f)
				{
					FGX_power = 0f;
					FGX_.enabled = true;
				}
			}
		}
		if (start_count == 4)
		{
			if (REAL_TIME > 0f)
			{
				REAL_TIME -= Time.deltaTime / 170f * TIME;
			}
			if (SHTRAF)
			{
				AudioSource.PlayClipAtPoint(SHTRAF_SND, Camera.main.transform.position);
				REAL_TIME -= Time.deltaTime * 5f;
				PROGRESS_TIME.fillAmount = REAL_TIME;
				if (FGX_power < 1f)
				{
					FGX_power += 0.4f;
					if (FGX_power > 1f)
					{
						FGX_power = 1f;
					}
				}
				SHTRAF = false;
			}
			if ((REAL_TIME <= 0f) & !FALIED & !FINISH)
			{
				PROGRESS_UI.SetActive(value: false);
				FALIED_UI.SetActive(value: true);
				UnityEngine.Object.Destroy(PLAYER_);
				REAL_TIME = 0f;
				PROGRESS_TIME.fillAmount = REAL_TIME;
				FALIED = true;
				NEED_CHECKPOINTS = 0;
				ALL_CHECKPOINTS_NEED = 0;
				return;
			}
			if (SELECTED_TYPE == "CHECKPOINT")
			{
				CUR_TARGET.text = string.Empty + NEED_CHECKPOINTS;
				ALL_TARGET.text = string.Empty + ALL_CHECKPOINTS_NEED;
				if ((ALL_CHECKPOINTS_NEED == NEED_CHECKPOINTS) & (REAL_TIME > 0f) & !COMPLETE_UI.activeInHierarchy)
				{
					start_count = 99;
					PROGRESS_UI.SetActive(value: false);
					COMPLETE_UI.SetActive(value: true);
					UnityEngine.Object.Destroy(PLAYER_);
					ES2.Save(1, "SCHOOL_CHECKPOINT" + INDEX_);
					if (INDEX_ != 23)
					{
						int num = INDEX_ + 1;
						ES2.Save(1, "SCHOOL_CHECKPOINT_" + num);
					}
					return;
				}
			}
			if (SELECTED_TYPE == "PARKING" && (FINISH & (REAL_TIME > 0f) & !COMPLETE_UI.activeInHierarchy))
			{
				start_count = 99;
				PROGRESS_UI.SetActive(value: false);
				COMPLETE_UI.SetActive(value: true);
				UnityEngine.Object.Destroy(PLAYER_);
				ES2.Save(1, "SCHOOL_TRAFFIC" + INDEX_);
				if (INDEX_ != 23)
				{
					int num2 = INDEX_ + 1;
					ES2.Save(1, "SCHOOL_TRAFFIC_" + num2);
				}
				return;
			}
			if (SELECTED_TYPE == "ORIENTIR")
			{
				CUR_TARGET.text = string.Empty + NEED_CHECKPOINTS;
				ALL_TARGET.text = string.Empty + ALL_CHECKPOINTS_NEED;
				if (INDEX_ORIENTIR == -1)
				{
					INDEX_ORIENTIR = UnityEngine.Random.Range(0, 10);
					GameObject[] array = GameObject.FindGameObjectsWithTag("CHEKPOINT");
					GameObject[] array2 = array;
					foreach (GameObject gameObject in array2)
					{
						gameObject.GetComponent<TIME_ADD>().RND();
					}
				}
				if ((ALL_CHECKPOINTS_NEED == NEED_CHECKPOINTS) & (REAL_TIME > 0f) & !COMPLETE_UI.activeInHierarchy)
				{
					start_count = 99;
					COMPLETE_UI.SetActive(value: true);
					PROGRESS_UI.SetActive(value: false);
					UnityEngine.Object.Destroy(PLAYER_);
					ES2.Save(1, "SCHOOL_ORIENT" + INDEX_);
					if (INDEX_ != 23)
					{
						int num3 = INDEX_ + 1;
						ES2.Save(1, "SCHOOL_ORIENT_" + num3);
					}
					return;
				}
			}
			if (SELECTED_TYPE == "GUARD")
			{
				CUR_TARGET.text = string.Empty + NEED_CHECKPOINTS;
				ALL_TARGET.text = string.Empty + ALL_CHECKPOINTS_NEED;
				if ((ALL_CHECKPOINTS_NEED == NEED_CHECKPOINTS) & (REAL_TIME > 0f) & !COMPLETE_UI.activeInHierarchy)
				{
					start_count = 99;
					COMPLETE_UI.SetActive(value: true);
					PROGRESS_UI.SetActive(value: false);
					UnityEngine.Object.Destroy(PLAYER_);
					ES2.Save(1, "SCHOOL_REACT" + INDEX_);
					if (INDEX_ != 23)
					{
						int num4 = INDEX_ + 1;
						ES2.Save(1, "SCHOOL_REACT_" + num4);
					}
					return;
				}
			}
		}
		if (PLAYER_ != null)
		{
			if (start_count != 4)
			{
				PLAYER_.GetComponent<RCC_CarControllerV3>().canControl = false;
				NOS_IMG.fillAmount = 1f;
			}
			else
			{
				PLAYER_.GetComponent<RCC_CarControllerV3>().canControl = true;
			}
		}
	}

	public void ACCEPT_SKIP()
	{
		if (SELECTED_TYPE == "GUARD")
		{
			ES2.Save(1, "SCHOOL_REACT" + INDEX_);
			if (INDEX_ != 23)
			{
				int num = INDEX_ + 1;
				ES2.Save(1, "SCHOOL_REACT_" + num);
			}
		}
		if (SELECTED_TYPE == "ORIENTIR")
		{
			ES2.Save(1, "SCHOOL_ORIENT" + INDEX_);
			if (INDEX_ != 23)
			{
				int num2 = INDEX_ + 1;
				ES2.Save(1, "SCHOOL_ORIENT_" + num2);
			}
		}
		if (SELECTED_TYPE == "PARKING")
		{
			ES2.Save(1, "SCHOOL_TRAFFIC" + INDEX_);
			if (INDEX_ != 23)
			{
				int num3 = INDEX_ + 1;
				ES2.Save(1, "SCHOOL_TRAFFIC_" + num3);
			}
		}
		if (SELECTED_TYPE == "CHECKPOINT")
		{
			ES2.Save(1, "SCHOOL_CHECKPOINT" + INDEX_);
			if (INDEX_ != 23)
			{
				int num4 = INDEX_ + 1;
				ES2.Save(1, "SCHOOL_CHECKPOINT_" + num4);
			}
		}
		SKIP_UI.SetActive(value: false);
		ES2.Save(ES2.Load<int>("SKIP_TODAY") - 1, "SKIP_TODAY");
		RESTORES = 0;
		StartCoroutine(SHOW_ADS());
	}

	private IEnumerator SHOW_ADS_COMPLETE()
	{
		SELECTED_TYPE = string.Empty;
		RESTORE = false;
		SELECTED_LEVEL = 0;
		yield return new WaitForSecondsRealtime(1f);
		int HH = UnityEngine.Random.Range(0, 6);
		Application.LoadLevel(5);
	}

	private IEnumerator SHOW_ADS()
	{
		LOADING_SCREEN.SetActive(value: true);
		yield return new WaitForSecondsRealtime(1f);
		Time.timeScale = 1f;
		Application.LoadLevel(5);
	}

	private IEnumerator SHOW_ADS2()
	{
		yield return new WaitForSecondsRealtime(1f);
	}

	public void QUIT()
	{
		SELECTED_TYPE = string.Empty;
		RESTORE = false;
		Application.LoadLevel(0);
	}

	public void QUIT_TO_LEVELS()
	{
		SELECTED_TYPE = string.Empty;
		RESTORE = false;
		Application.LoadLevel(5);
	}

	public void COMPLETE_CLOSE()
	{
		StartCoroutine(SHOW_ADS_COMPLETE());
	}

	public void RESTART()
	{
		LOADING_SCREEN.SetActive(value: true);
		PAUSE_REAL_RESTART.SetActive(value: false);
		PAUSE_UI.SetActive(value: false);
		Time.timeScale = 1f;
		RESTORES++;
		RESTORE = true;
		SELECTED_LEVEL = INDEX_;
		Application.LoadLevel(5);
	}

	public void SHOW_LEVEL(int INDEX, string TYPE)
	{
		INDEX_ = INDEX;
		if (TYPE == "PARKING")
		{
			TARGET_UI.SetActive(value: false);
			SELECTED_TYPE = "PARKING";
			NITRO_AVA.SetActive(value: false);
			PARKING_LEVELS[INDEX].SetActive(value: true);
			X_COORD = PARKING_LEVELS[INDEX].GetComponent<_LEVEL>().X;
			Z_COORD = PARKING_LEVELS[INDEX].GetComponent<_LEVEL>().Z;
			ROT_COORD = PARKING_LEVELS[INDEX].GetComponent<_LEVEL>().ROT;
			TIME = PARKING_LEVELS[INDEX].GetComponent<_LEVEL>().TIME;
			GAME_MANAGER.PLAYER_MAXIMUM_SPEED = 70f;
			GAME_MANAGER.PLAYER_MAXIMUM_NITRO = 100f;
			GAME_MANAGER.PLAYER_CONTROL_SUSPENSION = 45000f;
			if (ES2.Load<int>("TUTORIAL_8") == 0)
			{
				TUTORIAL.SetActive(value: true);
				ES2.Save(1, "TUTORIAL_8");
			}
		}
		if (TYPE == "CHECKPOINT")
		{
			TARGET_UI.SetActive(value: true);
			NITRO_AVA.SetActive(value: true);
			SELECTED_TYPE = "CHECKPOINT";
			CHECKPOINT_LEVELS[INDEX].SetActive(value: true);
			X_COORD = CHECKPOINT_LEVELS[INDEX].GetComponent<_LEVEL>().X;
			Z_COORD = CHECKPOINT_LEVELS[INDEX].GetComponent<_LEVEL>().Z;
			ROT_COORD = CHECKPOINT_LEVELS[INDEX].GetComponent<_LEVEL>().ROT;
			TIME = CHECKPOINT_LEVELS[INDEX].GetComponent<_LEVEL>().TIME;
			ALL_CHECKPOINTS_NEED = CHECKPOINT_LEVELS[INDEX].GetComponent<_LEVEL>().NEED_LEVEL_FOR_CHECKPOINT;
			GAME_MANAGER.PLAYER_MAXIMUM_SPEED = 100f;
			GAME_MANAGER.PLAYER_MAXIMUM_NITRO = 130f;
			GAME_MANAGER.PLAYER_CONTROL_SUSPENSION = 30000f;
			if (ES2.Load<int>("TUTORIAL_9") == 0)
			{
				TUTORIAL2.SetActive(value: true);
				ES2.Save(1, "TUTORIAL_9");
			}
		}
		if (TYPE == "ORIENTIR")
		{
			GameObject gameObject = UnityEngine.Object.Instantiate(NITROS_PREFABS, NITROS_PREFABS.transform.position, NITROS_PREFABS.transform.rotation);
			TARGET_UI.SetActive(value: true);
			NITRO_AVA.SetActive(value: true);
			SELECTED_TYPE = "ORIENTIR";
			ORIENTIR_LEVELS[INDEX].SetActive(value: true);
			X_COORD = ORIENTIR_LEVELS[INDEX].GetComponent<_LEVEL>().X;
			Z_COORD = ORIENTIR_LEVELS[INDEX].GetComponent<_LEVEL>().Z;
			ROT_COORD = ORIENTIR_LEVELS[INDEX].GetComponent<_LEVEL>().ROT;
			TIME = ORIENTIR_LEVELS[INDEX].GetComponent<_LEVEL>().TIME;
			ALL_CHECKPOINTS_NEED = ORIENTIR_LEVELS[INDEX].GetComponent<_LEVEL>().NEED_LEVEL_FOR_CHECKPOINT;
			INDEX_ORIENTIR = UnityEngine.Random.Range(0, 10);
			GameObject[] array = GameObject.FindGameObjectsWithTag("CHEKPOINT");
			GameObject[] array2 = array;
			foreach (GameObject gameObject2 in array2)
			{
				gameObject2.GetComponent<TIME_ADD>().RND();
			}
			GAME_MANAGER.PLAYER_MAXIMUM_SPEED = 100f;
			GAME_MANAGER.PLAYER_MAXIMUM_NITRO = 140f;
			GAME_MANAGER.PLAYER_CONTROL_SUSPENSION = 30000f;
			if (ES2.Load<int>("TUTORIAL_10") == 0)
			{
				TUTORIAL3.SetActive(value: true);
				ES2.Save(1, "TUTORIAL_10");
			}
		}
		if (TYPE == "GUARD")
		{
			TARGET_UI.SetActive(value: true);
			NITRO_AVA.SetActive(value: true);
			SELECTED_TYPE = "GUARD";
			GUARD_LEVELS[INDEX].SetActive(value: true);
			X_COORD = GUARD_LEVELS[INDEX].GetComponent<_LEVEL>().X;
			Z_COORD = GUARD_LEVELS[INDEX].GetComponent<_LEVEL>().Z;
			ROT_COORD = GUARD_LEVELS[INDEX].GetComponent<_LEVEL>().ROT;
			TIME = GUARD_LEVELS[INDEX].GetComponent<_LEVEL>().TIME;
			ALL_CHECKPOINTS_NEED = GUARD_LEVELS[INDEX].GetComponent<_LEVEL>().NEED_LEVEL_FOR_CHECKPOINT;
			GAME_MANAGER.PLAYER_MAXIMUM_SPEED = 100f;
			GAME_MANAGER.PLAYER_MAXIMUM_NITRO = 140f;
			GAME_MANAGER.PLAYER_CONTROL_SUSPENSION = 30000f;
			if (ES2.Load<int>("TUTORIAL_11") == 0)
			{
				TUTORIAL4.SetActive(value: true);
				ES2.Save(1, "TUTORIAL_11");
			}
		}
	}

	public void CREATE_CAR()
	{
		if (MENU_MANAGER.SELECT_SCHOOL_ == 1)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate(PLAYER_PREFAB[0], new Vector3(X_COORD, 33f, Z_COORD), base.transform.rotation);
			gameObject.transform.rotation = Quaternion.Euler(0f, ROT_COORD, 0f);
			PLAYER_ = gameObject;
			RCC_SceneManager.Instance.activePlayerVehicle = PLAYER_.GetComponent<RCC_CarControllerV3>();
			RCC_CAMERA.GetComponent<RCC_Camera>().playerCar = PLAYER_.GetComponent<RCC_CarControllerV3>();
			PLAYER_.GetComponent<RCC_CarControllerV3>().tractionHelperStrength = 0.3f;
			PLAYER_.GetComponent<RCC_CarControllerV3>().brakeTorque = 20000f;
		}
		if (MENU_MANAGER.SELECT_SCHOOL_ == 2)
		{
			GameObject gameObject2 = UnityEngine.Object.Instantiate(PLAYER_PREFAB[2], new Vector3(X_COORD, 33f, Z_COORD), base.transform.rotation);
			gameObject2.transform.rotation = Quaternion.Euler(0f, ROT_COORD, 0f);
			PLAYER_ = gameObject2;
			RCC_SceneManager.Instance.activePlayerVehicle = PLAYER_.GetComponent<RCC_CarControllerV3>();
			RCC_CAMERA.GetComponent<RCC_Camera>().playerCar = PLAYER_.GetComponent<RCC_CarControllerV3>();
			PLAYER_.GetComponent<RCC_CarControllerV3>().tractionHelperStrength = 0.4f;
			PLAYER_.GetComponent<RCC_CarControllerV3>().brakeTorque = 20000f;
		}
		if (MENU_MANAGER.SELECT_SCHOOL_ == 3)
		{
			GameObject gameObject3 = UnityEngine.Object.Instantiate(PLAYER_PREFAB[4], new Vector3(X_COORD, 33f, Z_COORD), base.transform.rotation);
			gameObject3.transform.rotation = Quaternion.Euler(0f, ROT_COORD, 0f);
			PLAYER_ = gameObject3;
			RCC_SceneManager.Instance.activePlayerVehicle = PLAYER_.GetComponent<RCC_CarControllerV3>();
			RCC_CAMERA.GetComponent<RCC_Camera>().playerCar = PLAYER_.GetComponent<RCC_CarControllerV3>();
			PLAYER_.GetComponent<RCC_CarControllerV3>().tractionHelperStrength = 0.5f;
			PLAYER_.GetComponent<RCC_CarControllerV3>().brakeTorque = 20000f;
		}
	}

	public void CANCEL_SKIP()
	{
		SKIP_UI.SetActive(value: false);
		if (Time.timeScale == 0f)
		{
			PAUSE_UI.SetActive(value: true);
		}
		else
		{
			RESTORES = 0;
		}
	}

	public void PLAYER_EVENTS()
	{
		if (RESTORES == 3)
		{
			if (ES2.Load<int>("SKIP_TODAY") > 0)
			{
				SKIP_UI.SetActive(value: true);
			}
			else
			{
				RESTORES = 0;
			}
		}
		if ((PLAYER_ != null) & (start_count != 4) & (RESTORES < 3))
		{
			if (!TUTORIAL.activeInHierarchy & !TUTORIAL2.activeInHierarchy & !TUTORIAL3.activeInHierarchy & !TUTORIAL4.activeInHierarchy)
			{
				start_timer += Time.deltaTime;
			}
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
					base.gameObject.GetComponent<AudioSource>().enabled = true;
					base.gameObject.GetComponent<AudioSource>().volume = GAME_MANAGER.MUSIC_VOLUME;
				}
				if (start_count == 4)
				{
					PROGRESS_UI.SetActive(value: true);
					START_OBJ.SetActive(value: false);
					return;
				}
			}
		}
		if (cam_fx_alpha2 > 0f)
		{
			CAM_FX2.SetActive(value: true);
			cam_fx_alpha2 -= Time.deltaTime;
			CAM_FX2.GetComponent<SpriteRenderer>().color = new Color(0f, 0.75f, 1f, cam_fx_alpha2);
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
		if (AUDIOLISTENER_volume < MAIN_VOLUME)
		{
			if ((AUDIOLISTENER_volume > 0.05f) & (AUDIOLISTENER_volume < 0.2f))
			{
			}
			AUDIOLISTENER_volume += Time.deltaTime / 3f;
			AudioListener.volume = AUDIOLISTENER_volume;
		}
		if (GAME_MANAGER.HIT_SND > 0)
		{
			if (GAME_MANAGER.HIT_SND == 1)
			{
				HIT_RND = UnityEngine.Random.Range(0, 2);
				AudioSource.PlayClipAtPoint(FENCE_[HIT_RND], Camera.main.transform.position);
			}
			if (GAME_MANAGER.HIT_SND == 2)
			{
				AudioSource.PlayClipAtPoint(METAL_1, Camera.main.transform.position);
			}
			if (GAME_MANAGER.HIT_SND == 3)
			{
				HIT_RND = UnityEngine.Random.Range(0, 2);
				AudioSource.PlayClipAtPoint(TRASH_[HIT_RND], Camera.main.transform.position);
			}
			if (GAME_MANAGER.HIT_SND == 4)
			{
				HIT_RND = UnityEngine.Random.Range(0, 2);
				AudioSource.PlayClipAtPoint(LIGHT_[HIT_RND], Camera.main.transform.position);
			}
			if (GAME_MANAGER.HIT_SND == 5)
			{
				HIT_RND = UnityEngine.Random.Range(0, 2);
				AudioSource.PlayClipAtPoint(STRAW_[HIT_RND], Camera.main.transform.position);
			}
			if (GAME_MANAGER.HIT_SND == 6)
			{
				HIT_RND = UnityEngine.Random.Range(0, 2);
				AudioSource.PlayClipAtPoint(BARREL_[HIT_RND], Camera.main.transform.position);
			}
			if (GAME_MANAGER.HIT_SND == 7)
			{
				HIT_RND = UnityEngine.Random.Range(0, 2);
				AudioSource.PlayClipAtPoint(BOX_[HIT_RND], Camera.main.transform.position);
			}
			if (GAME_MANAGER.HIT_SND == 9)
			{
				AudioSource.PlayClipAtPoint(HYDRANT_SND, Camera.main.transform.position);
			}
			GAME_MANAGER.HIT_SND = 0;
		}
	}
}
