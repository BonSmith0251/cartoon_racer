using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TUNING_MENU : MonoBehaviour
{
	private int RND_V;

	public GameObject BUY_FX;

	public GameObject TO_COLOR_OBJ;

	public GameObject[] BACK_BUTTONS;

	public GameObject[] FRONT_BUTTONS;

	public GameObject[] MIDDLE_BUTTONS;

	public GameObject[] WHEELS_BUTTONS;

	public GameObject GARAGE_CAMERA;

	public GameObject MAIN_UI;

	public GameObject BACK_MENU;

	public GameObject FRONT_MENU;

	public GameObject MIDDLE_MENU;

	public GameObject WHEELS_MENU;

	public GameObject CAMBER_MENU;

	public GameObject COLORS_MENU;

	public GameObject PLATE_MENU;

	public Text CURRENT_MONEY_TXT;

	public Text CURRENT_LEVEL_TXT;

	public Image CURRENT_IMG_FILL;

	public InputField INPUT;

	public Text CAMBER_TXT;

	public Slider CAMBER_SLIDER;

	public Button APPLY_CAMBER;

	public Button APPLY_COLOR;

	public Button APPLY_NAME;

	public Sprite BUTTON_ON;

	public Sprite BUTTON_OFF;

	public AudioClip UI_CLICK;

	public AudioClip BACK_CLICK;

	public AudioClip UPGRADE_SND;

	public AudioClip CHANGE_SND;

	public AudioClip[] VOICE_;

	private int PLAYER_MONEY;

	private int PLAYER_LEVEL;

	private float PLAYER_XP;

	public static string ITEM_NAME;

	private int INT;

	private string str;

	private int INT2;

	private string str2;

	private int INT3;

	private string str3;

	private int CAMBER_VALUE;

	private int COLOR;

	private float R_COLOR;

	private float G_COLOR;

	private float B_COLOR;

	private int CUR_COLOR;

	private string CAR_NAME;

	private void Start()
	{
		HIDE_ALL();
		MAIN_UI.SetActive(value: true);
		PLAYER_MONEY = ES2.Load<int>("PLAYER_MONEY");
		PLAYER_LEVEL = ES2.Load<int>("PLAYER_LEVEL");
		PLAYER_XP = ES2.Load<float>("PLAYER_LEVEL_PROGRESS");
		CURRENT_MONEY_TXT.text = string.Empty + PLAYER_MONEY;
		if (MENU_MANAGER.LANGUAGE == 1)
		{
			CURRENT_LEVEL_TXT.text = string.Empty + PLAYER_LEVEL + " ур";
		}
		else
		{
			CURRENT_LEVEL_TXT.text = string.Empty + PLAYER_LEVEL + " lv";
		}
		CURRENT_IMG_FILL.fillAmount = PLAYER_XP;
	}

	public void CHANGE_BACK(int INDEX)
	{
		AudioSource.PlayClipAtPoint(CHANGE_SND, GARAGE_CAMERA.transform.position, 0.5f);
		if (MENU_MANAGER.LANGUAGE == 1)
		{
			RND_V = Random.Range(0, 5);
			if (RND_V == 1)
			{
				AudioSource.PlayClipAtPoint(VOICE_[Random.Range(0, VOICE_.Length)], GARAGE_CAMERA.transform.position, 1f);
			}
		}
		if (INDEX == 0)
		{
			MENU_MANAGER.CURRENT_CAR_OBJ.GetComponent<CUSTOMIZER_>().SET_BACK_1();
		}
		if (INDEX == 1)
		{
			MENU_MANAGER.CURRENT_CAR_OBJ.GetComponent<CUSTOMIZER_>().SET_BACK_2();
		}
		if (INDEX == 2)
		{
			MENU_MANAGER.CURRENT_CAR_OBJ.GetComponent<CUSTOMIZER_>().SET_BACK_3();
		}
		if (INDEX == 3)
		{
			MENU_MANAGER.CURRENT_CAR_OBJ.GetComponent<CUSTOMIZER_>().SET_BACK_4();
		}
		if (INDEX == 5)
		{
			MENU_MANAGER.CURRENT_CAR_OBJ.GetComponent<CUSTOMIZER_>().SET_BACK_5();
		}
		if (INDEX == 6)
		{
			MENU_MANAGER.CURRENT_CAR_OBJ.GetComponent<CUSTOMIZER_>().SET_BACK_6();
		}
		if (INDEX == 7)
		{
			MENU_MANAGER.CURRENT_CAR_OBJ.GetComponent<CUSTOMIZER_>().SET_BACK_7();
		}
		MENU_MANAGER.CURRENT_CAR_OBJ.GetComponent<CUSTOMIZER_>().APPLY();
		for (int i = 0; i < BACK_BUTTONS.Length; i++)
		{
			BACK_BUTTONS[i].SetActive(value: false);
			BACK_BUTTONS[i].SetActive(value: true);
			BACK_BUTTONS[i].GetComponent<TUNING_ITEM_CHECK>().START();
		}
	}

	public void CHANGE_FRONT(int INDEX)
	{
		AudioSource.PlayClipAtPoint(CHANGE_SND, GARAGE_CAMERA.transform.position, 0.5f);
		if (MENU_MANAGER.LANGUAGE == 1)
		{
			RND_V = Random.Range(0, 5);
			if (RND_V == 1)
			{
				AudioSource.PlayClipAtPoint(VOICE_[Random.Range(0, VOICE_.Length)], GARAGE_CAMERA.transform.position, 1f);
			}
		}
		if (INDEX == 0)
		{
			MENU_MANAGER.CURRENT_CAR_OBJ.GetComponent<CUSTOMIZER_>().SET_FRONT_1();
		}
		if (INDEX == 1)
		{
			MENU_MANAGER.CURRENT_CAR_OBJ.GetComponent<CUSTOMIZER_>().SET_FRONT_2();
		}
		if (INDEX == 2)
		{
			MENU_MANAGER.CURRENT_CAR_OBJ.GetComponent<CUSTOMIZER_>().SET_FRONT_3();
		}
		if (INDEX == 3)
		{
			MENU_MANAGER.CURRENT_CAR_OBJ.GetComponent<CUSTOMIZER_>().SET_FRONT_4();
		}
		if (INDEX == 4)
		{
			MENU_MANAGER.CURRENT_CAR_OBJ.GetComponent<CUSTOMIZER_>().SET_FRONT_5();
		}
		if (INDEX == 6)
		{
			MENU_MANAGER.CURRENT_CAR_OBJ.GetComponent<CUSTOMIZER_>().SET_FRONT_6();
		}
		if (INDEX == 7)
		{
			MENU_MANAGER.CURRENT_CAR_OBJ.GetComponent<CUSTOMIZER_>().SET_FRONT_7();
		}
		MENU_MANAGER.CURRENT_CAR_OBJ.GetComponent<CUSTOMIZER_>().APPLY();
		for (int i = 0; i < FRONT_BUTTONS.Length; i++)
		{
			FRONT_BUTTONS[i].SetActive(value: false);
			FRONT_BUTTONS[i].SetActive(value: true);
			FRONT_BUTTONS[i].GetComponent<TUNING_ITEM_CHECK>().START();
		}
	}

	public void CHANGE_MIDDLE(int INDEX)
	{
		AudioSource.PlayClipAtPoint(CHANGE_SND, GARAGE_CAMERA.transform.position, 0.5f);
		if (MENU_MANAGER.LANGUAGE == 1)
		{
			RND_V = Random.Range(0, 5);
			if (RND_V == 1)
			{
				AudioSource.PlayClipAtPoint(VOICE_[Random.Range(0, VOICE_.Length)], GARAGE_CAMERA.transform.position, 1f);
			}
		}
		if (INDEX == 0)
		{
			MENU_MANAGER.CURRENT_CAR_OBJ.GetComponent<CUSTOMIZER_>().SET_MIDDLE_1();
		}
		if (INDEX == 1)
		{
			MENU_MANAGER.CURRENT_CAR_OBJ.GetComponent<CUSTOMIZER_>().SET_MIDDLE_2();
		}
		if (INDEX == 2)
		{
			MENU_MANAGER.CURRENT_CAR_OBJ.GetComponent<CUSTOMIZER_>().SET_MIDDLE_3();
		}
		if (INDEX == 4)
		{
			MENU_MANAGER.CURRENT_CAR_OBJ.GetComponent<CUSTOMIZER_>().SET_MIDDLE_4();
		}
		if (INDEX == 5)
		{
			MENU_MANAGER.CURRENT_CAR_OBJ.GetComponent<CUSTOMIZER_>().SET_MIDDLE_5();
		}
		if (INDEX == 6)
		{
			MENU_MANAGER.CURRENT_CAR_OBJ.GetComponent<CUSTOMIZER_>().SET_MIDDLE_6();
		}
		if (INDEX == 7)
		{
			MENU_MANAGER.CURRENT_CAR_OBJ.GetComponent<CUSTOMIZER_>().SET_MIDDLE_7();
		}
		MENU_MANAGER.CURRENT_CAR_OBJ.GetComponent<CUSTOMIZER_>().APPLY();
		for (int i = 0; i < MIDDLE_BUTTONS.Length; i++)
		{
			MIDDLE_BUTTONS[i].SetActive(value: false);
			MIDDLE_BUTTONS[i].SetActive(value: true);
			MIDDLE_BUTTONS[i].GetComponent<TUNING_ITEM_CHECK>().START();
		}
	}

	public void CHANGE_WHEELS(int INDEX)
	{
		AudioSource.PlayClipAtPoint(CHANGE_SND, GARAGE_CAMERA.transform.position, 0.5f);
		if (MENU_MANAGER.LANGUAGE == 1)
		{
			RND_V = Random.Range(0, 5);
			if (RND_V == 1)
			{
				AudioSource.PlayClipAtPoint(VOICE_[Random.Range(0, VOICE_.Length)], GARAGE_CAMERA.transform.position, 1f);
			}
		}
		if (INDEX == 0)
		{
			MENU_MANAGER.CURRENT_CAR_OBJ.GetComponent<CUSTOMIZER_>().SET_WHELLS_1();
		}
		if (INDEX == 1)
		{
			MENU_MANAGER.CURRENT_CAR_OBJ.GetComponent<CUSTOMIZER_>().SET_WHELLS_2();
		}
		if (INDEX == 2)
		{
			MENU_MANAGER.CURRENT_CAR_OBJ.GetComponent<CUSTOMIZER_>().SET_WHELLS_5();
		}
		if (INDEX == 4)
		{
			MENU_MANAGER.CURRENT_CAR_OBJ.GetComponent<CUSTOMIZER_>().SET_WHELLS_4();
		}
		if (INDEX == 5)
		{
			MENU_MANAGER.CURRENT_CAR_OBJ.GetComponent<CUSTOMIZER_>().SET_WHELLS_3();
		}
		MENU_MANAGER.CURRENT_CAR_OBJ.GetComponent<CUSTOMIZER_>().APPLY();
		for (int i = 0; i < WHEELS_BUTTONS.Length; i++)
		{
			WHEELS_BUTTONS[i].SetActive(value: false);
			WHEELS_BUTTONS[i].SetActive(value: true);
			WHEELS_BUTTONS[i].GetComponent<TUNING_ITEM_CHECK>().START();
		}
	}

	public void TO_BACK()
	{
		if (MENU_MANAGER.CURRENT_CAR_OBJ.GetComponent<CUSTOMIZER_>().CAR_INDEX < 9)
		{
			AudioSource.PlayClipAtPoint(UI_CLICK, GARAGE_CAMERA.transform.position, 0.5f);
			HIDE_ALL();
			BACK_MENU.SetActive(value: true);
		}
	}

	public void TO_FRONT()
	{
		if (MENU_MANAGER.CURRENT_CAR_OBJ.GetComponent<CUSTOMIZER_>().CAR_INDEX < 9)
		{
			AudioSource.PlayClipAtPoint(UI_CLICK, GARAGE_CAMERA.transform.position, 0.5f);
			HIDE_ALL();
			FRONT_MENU.SetActive(value: true);
		}
	}

	public void TO_MIDDLE()
	{
		if (MENU_MANAGER.CURRENT_CAR_OBJ.GetComponent<CUSTOMIZER_>().CAR_INDEX < 9)
		{
			AudioSource.PlayClipAtPoint(UI_CLICK, GARAGE_CAMERA.transform.position, 0.5f);
			HIDE_ALL();
			MIDDLE_MENU.SetActive(value: true);
		}
	}

	public void TO_WHEELS()
	{
		if (MENU_MANAGER.CURRENT_CAR_OBJ.GetComponent<CUSTOMIZER_>().CAR_INDEX < 9)
		{
			AudioSource.PlayClipAtPoint(UI_CLICK, GARAGE_CAMERA.transform.position, 0.5f);
			HIDE_ALL();
			WHEELS_MENU.SetActive(value: true);
		}
	}

	public void TO_CAMBER()
	{
		AudioSource.PlayClipAtPoint(UI_CLICK, GARAGE_CAMERA.transform.position, 0.5f);
		HIDE_ALL();
		CAMBER_MENU.SetActive(value: true);
		INT = 0;
		INT = MENU_MANAGER.SPAWN_CAR_ + 1;
		str = "CAR" + INT + "_CAMBER";
		CAMBER_VALUE = ES2.Load<int>(str);
		CAMBER_TXT.text = string.Empty + CAMBER_VALUE + " %";
		CAMBER_SLIDER.value = CAMBER_VALUE;
		MENU_MANAGER.CURRENT_CAR_OBJ.GetComponent<RCC_CarControllerV3>().FrontLeftWheelCollider.camber = CAMBER_VALUE;
		MENU_MANAGER.CURRENT_CAR_OBJ.GetComponent<RCC_CarControllerV3>().FrontRightWheelCollider.camber = CAMBER_VALUE;
		MENU_MANAGER.CURRENT_CAR_OBJ.GetComponent<RCC_CarControllerV3>().RearLeftWheelCollider.camber = CAMBER_VALUE;
		MENU_MANAGER.CURRENT_CAR_OBJ.GetComponent<RCC_CarControllerV3>().RearRightWheelCollider.camber = CAMBER_VALUE;
		APPLY_CAMBER.interactable = false;
		APPLY_CAMBER.GetComponent<Image>().sprite = BUTTON_OFF;
	}

	private IEnumerator OFF_TURN()
	{
		MENU_MANAGER.CURRENT_CAR_OBJ.GetComponent<Mouse_drag_rotate_scale_control>().enabled = false;
		yield return new WaitForSecondsRealtime(2f);
		MENU_MANAGER.CURRENT_CAR_OBJ.GetComponent<Mouse_drag_rotate_scale_control>().enabled = true;
	}

	public void CHANGE_CAMBER()
	{
		StartCoroutine(OFF_TURN());
		CAMBER_VALUE = (int)CAMBER_SLIDER.value;
		CAMBER_TXT.text = string.Empty + CAMBER_VALUE + " %";
		MENU_MANAGER.CURRENT_CAR_OBJ.GetComponent<RCC_CarControllerV3>().enabled = true;
		MENU_MANAGER.CURRENT_CAR_OBJ.GetComponent<RCC_CarControllerV3>().FrontLeftWheelCollider.camber = CAMBER_VALUE;
		MENU_MANAGER.CURRENT_CAR_OBJ.GetComponent<RCC_CarControllerV3>().FrontRightWheelCollider.camber = CAMBER_VALUE;
		MENU_MANAGER.CURRENT_CAR_OBJ.GetComponent<RCC_CarControllerV3>().RearLeftWheelCollider.camber = CAMBER_VALUE;
		MENU_MANAGER.CURRENT_CAR_OBJ.GetComponent<RCC_CarControllerV3>().RearRightWheelCollider.camber = CAMBER_VALUE;
		MENU_MANAGER.CURRENT_CAR_OBJ.GetComponent<RCC_CarControllerV3>().enabled = false;
		if (PLAYER_MONEY >= 250)
		{
			APPLY_CAMBER.interactable = true;
			APPLY_CAMBER.GetComponent<Image>().sprite = BUTTON_ON;
		}
	}

	public void SAVE_CAMBER()
	{
		if (!APPLY_CAMBER.interactable)
		{
			return;
		}
		GameObject gameObject = Object.Instantiate(BUY_FX, new Vector3(203.15f, 29.46f, 261.43f), base.transform.rotation);
		AudioSource.PlayClipAtPoint(CHANGE_SND, GARAGE_CAMERA.transform.position, 0.8f);
		if (MENU_MANAGER.LANGUAGE == 1)
		{
			RND_V = Random.Range(0, 5);
			if (RND_V == 1)
			{
				AudioSource.PlayClipAtPoint(VOICE_[Random.Range(0, VOICE_.Length)], GARAGE_CAMERA.transform.position, 1f);
			}
		}
		PLAYER_MONEY -= 250;
		CURRENT_MONEY_TXT.text = string.Empty + PLAYER_MONEY;
		ES2.Save(PLAYER_MONEY, "PLAYER_MONEY");
		ES2.Save(CAMBER_VALUE, str);
		APPLY_CAMBER.interactable = false;
		APPLY_CAMBER.GetComponent<Image>().sprite = BUTTON_OFF;
	}

	public void TO_COLORS()
	{
		TO_COLOR_OBJ.SetActive(value: true);
		AudioSource.PlayClipAtPoint(UI_CLICK, GARAGE_CAMERA.transform.position, 0.5f);
		HIDE_ALL();
		COLORS_MENU.SetActive(value: true);
		APPLY_COLOR.interactable = false;
		APPLY_COLOR.GetComponent<Image>().sprite = BUTTON_OFF;
		INT2 = 0;
		INT2 = MENU_MANAGER.SPAWN_CAR_ + 1;
		str2 = "CAR" + INT2 + "_LIGHT";
		COLOR = ES2.Load<int>(str2);
		MENU_MANAGER.CURRENT_CAR_OBJ.GetComponent<CUSTOMIZER_>().SHOW_LIGHT();
		string identifier = "CAR" + INT2 + "_LIGHT_R";
		string identifier2 = "CAR" + INT2 + "_LIGHT_G";
		string identifier3 = "CAR" + INT2 + "_LIGHT_B";
		float num = ES2.Load<float>(identifier);
		float num2 = ES2.Load<float>(identifier2);
		float num3 = ES2.Load<float>(identifier3);
	}

	public void SET_WHITE()
	{
		if (PLAYER_MONEY > 499)
		{
			APPLY_COLOR.interactable = true;
			APPLY_COLOR.GetComponent<Image>().sprite = BUTTON_ON;
			MENU_MANAGER.CURRENT_CAR_OBJ.GetComponent<CUSTOMIZER_>().CHANGE_LIGHT(WHITE: true, GREEN: false, YELLOW: false, RED: false, ORANGE: false, BLUE: false, PINK: false, OFF: false);
			CUR_COLOR = 1;
		}
	}

	public void SET_GREEN()
	{
		if (PLAYER_MONEY > 499)
		{
			APPLY_COLOR.interactable = true;
			APPLY_COLOR.GetComponent<Image>().sprite = BUTTON_ON;
			MENU_MANAGER.CURRENT_CAR_OBJ.GetComponent<CUSTOMIZER_>().CHANGE_LIGHT(WHITE: false, GREEN: true, YELLOW: false, RED: false, ORANGE: false, BLUE: false, PINK: false, OFF: false);
			CUR_COLOR = 2;
		}
	}

	public void SET_YELLOW()
	{
		if (PLAYER_MONEY > 499)
		{
			APPLY_COLOR.interactable = true;
			APPLY_COLOR.GetComponent<Image>().sprite = BUTTON_ON;
			MENU_MANAGER.CURRENT_CAR_OBJ.GetComponent<CUSTOMIZER_>().CHANGE_LIGHT(WHITE: false, GREEN: false, YELLOW: true, RED: false, ORANGE: false, BLUE: false, PINK: false, OFF: false);
			CUR_COLOR = 3;
		}
	}

	public void SET_RED()
	{
		if (PLAYER_MONEY > 499)
		{
			APPLY_COLOR.interactable = true;
			APPLY_COLOR.GetComponent<Image>().sprite = BUTTON_ON;
			MENU_MANAGER.CURRENT_CAR_OBJ.GetComponent<CUSTOMIZER_>().CHANGE_LIGHT(WHITE: false, GREEN: false, YELLOW: false, RED: true, ORANGE: false, BLUE: false, PINK: false, OFF: false);
			CUR_COLOR = 4;
		}
	}

	public void SET_ORANGE()
	{
		if (PLAYER_MONEY > 499)
		{
			APPLY_COLOR.interactable = true;
			APPLY_COLOR.GetComponent<Image>().sprite = BUTTON_ON;
			MENU_MANAGER.CURRENT_CAR_OBJ.GetComponent<CUSTOMIZER_>().CHANGE_LIGHT(WHITE: false, GREEN: false, YELLOW: false, RED: false, ORANGE: true, BLUE: false, PINK: false, OFF: false);
			CUR_COLOR = 5;
		}
	}

	public void SET_BLUE()
	{
		if (PLAYER_MONEY > 499)
		{
			APPLY_COLOR.interactable = true;
			APPLY_COLOR.GetComponent<Image>().sprite = BUTTON_ON;
			MENU_MANAGER.CURRENT_CAR_OBJ.GetComponent<CUSTOMIZER_>().CHANGE_LIGHT(WHITE: false, GREEN: false, YELLOW: false, RED: false, ORANGE: false, BLUE: true, PINK: false, OFF: false);
			CUR_COLOR = 6;
		}
	}

	public void SET_PINK()
	{
		if (PLAYER_MONEY > 499)
		{
			APPLY_COLOR.interactable = true;
			APPLY_COLOR.GetComponent<Image>().sprite = BUTTON_ON;
			MENU_MANAGER.CURRENT_CAR_OBJ.GetComponent<CUSTOMIZER_>().CHANGE_LIGHT(WHITE: false, GREEN: false, YELLOW: false, RED: false, ORANGE: false, BLUE: false, PINK: true, OFF: false);
			CUR_COLOR = 7;
		}
	}

	public void SET_OFF()
	{
		APPLY_COLOR.interactable = true;
		APPLY_COLOR.GetComponent<Image>().sprite = BUTTON_ON;
		MENU_MANAGER.CURRENT_CAR_OBJ.GetComponent<CUSTOMIZER_>().CHANGE_LIGHT(WHITE: false, GREEN: false, YELLOW: false, RED: false, ORANGE: false, BLUE: false, PINK: false, OFF: true);
		CUR_COLOR = 8;
	}

	public void SAVE_COLOR_()
	{
		if (!APPLY_COLOR.interactable)
		{
			return;
		}
		GameObject gameObject = Object.Instantiate(BUY_FX, new Vector3(203.15f, 29.46f, 261.43f), base.transform.rotation);
		AudioSource.PlayClipAtPoint(CHANGE_SND, GARAGE_CAMERA.transform.position, 0.8f);
		if (MENU_MANAGER.LANGUAGE == 1)
		{
			RND_V = Random.Range(0, 5);
			if (RND_V == 1)
			{
				AudioSource.PlayClipAtPoint(VOICE_[Random.Range(0, VOICE_.Length)], GARAGE_CAMERA.transform.position, 1f);
			}
		}
		if (CUR_COLOR != 8)
		{
			PLAYER_MONEY -= 500;
			CURRENT_MONEY_TXT.text = string.Empty + PLAYER_MONEY;
		}
		COLOR = 1;
		ES2.Save(PLAYER_MONEY, "PLAYER_MONEY");
		ES2.Save(COLOR, str2);
		string identifier = "CAR" + INT2 + "_LIGHT_R";
		string identifier2 = "CAR" + INT2 + "_LIGHT_G";
		string identifier3 = "CAR" + INT2 + "_LIGHT_B";
		if (CUR_COLOR == 1)
		{
			ES2.Save(1f, identifier);
			ES2.Save(1f, identifier2);
			ES2.Save(1f, identifier3);
		}
		if (CUR_COLOR == 2)
		{
			ES2.Save(0f, identifier);
			ES2.Save(1f, identifier2);
			ES2.Save(0f, identifier3);
		}
		if (CUR_COLOR == 3)
		{
			ES2.Save(1f, identifier);
			ES2.Save(1f, identifier2);
			ES2.Save(0f, identifier3);
		}
		if (CUR_COLOR == 4)
		{
			ES2.Save(1f, identifier);
			ES2.Save(0f, identifier2);
			ES2.Save(0f, identifier3);
		}
		if (CUR_COLOR == 5)
		{
			ES2.Save(1f, identifier);
			ES2.Save(0.5f, identifier2);
			ES2.Save(0f, identifier3);
		}
		if (CUR_COLOR == 6)
		{
			ES2.Save(0f, identifier);
			ES2.Save(0f, identifier2);
			ES2.Save(1f, identifier3);
		}
		if (CUR_COLOR == 7)
		{
			ES2.Save(1f, identifier);
			ES2.Save(0f, identifier2);
			ES2.Save(1f, identifier3);
		}
		if (CUR_COLOR == 8)
		{
			ES2.Save(0, str2);
			ES2.Save(0f, identifier);
			ES2.Save(0f, identifier2);
			ES2.Save(0f, identifier3);
		}
		APPLY_COLOR.interactable = false;
		APPLY_COLOR.GetComponent<Image>().sprite = BUTTON_OFF;
	}

	public void TO_PLATE()
	{
		AudioSource.PlayClipAtPoint(UI_CLICK, GARAGE_CAMERA.transform.position, 0.5f);
		HIDE_ALL();
		PLATE_MENU.SetActive(value: true);
		INT3 = 0;
		INT3 = MENU_MANAGER.SPAWN_CAR_ + 1;
		str3 = "CAR" + INT3 + "_NAME";
		CAR_NAME = ES2.Load<string>(str3);
		INPUT.text = CAR_NAME + string.Empty;
		APPLY_NAME.interactable = false;
		APPLY_NAME.GetComponent<Image>().sprite = BUTTON_OFF;
	}

	public void CHANGE_PLATE()
	{
		if (PLAYER_MONEY >= 300)
		{
			APPLY_NAME.interactable = true;
			APPLY_NAME.GetComponent<Image>().sprite = BUTTON_ON;
		}
		CAR_NAME = INPUT.text;
		MENU_MANAGER.CURRENT_CAR_OBJ.GetComponent<CUSTOMIZER_>().CHANGE_NAME(CAR_NAME);
	}

	public void SAVE_PLATE()
	{
		if (!APPLY_CAMBER.interactable)
		{
			return;
		}
		GameObject gameObject = Object.Instantiate(BUY_FX, new Vector3(203.15f, 29.46f, 261.43f), base.transform.rotation);
		AudioSource.PlayClipAtPoint(CHANGE_SND, GARAGE_CAMERA.transform.position, 0.8f);
		if (MENU_MANAGER.LANGUAGE == 1)
		{
			RND_V = Random.Range(0, 5);
			if (RND_V == 1)
			{
				AudioSource.PlayClipAtPoint(VOICE_[Random.Range(0, VOICE_.Length)], GARAGE_CAMERA.transform.position, 1f);
			}
		}
		PLAYER_MONEY -= 300;
		CURRENT_MONEY_TXT.text = string.Empty + PLAYER_MONEY;
		ES2.Save(PLAYER_MONEY, "PLAYER_MONEY");
		ES2.Save(INPUT.text, str3);
		APPLY_NAME.interactable = false;
		APPLY_NAME.GetComponent<Image>().sprite = BUTTON_OFF;
	}

	public void BACK_TO_MAIN()
	{
		MENU_MANAGER.CURRENT_CAR_OBJ.GetComponent<CUSTOMIZER_>().LOAD_NAME();
		TO_COLOR_OBJ.SetActive(value: false);
		AudioSource.PlayClipAtPoint(BACK_CLICK, GARAGE_CAMERA.transform.position, 0.7f);
		HIDE_ALL();
		MAIN_UI.SetActive(value: true);
	}

	private void HIDE_ALL()
	{
		MAIN_UI.SetActive(value: false);
		BACK_MENU.SetActive(value: false);
		FRONT_MENU.SetActive(value: false);
		MIDDLE_MENU.SetActive(value: false);
		WHEELS_MENU.SetActive(value: false);
		CAMBER_MENU.SetActive(value: false);
		COLORS_MENU.SetActive(value: false);
		PLATE_MENU.SetActive(value: false);
	}
}
