using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UPGRADE_MENU : MonoBehaviour
{
	public AudioClip[] VOICE_;

	public GameObject BUY_FX;

	public GameObject GARAGE_CAMERA;

	public GameObject BUY_BUTTON;

	public Sprite BUY_BUTTON_OFF;

	public Sprite BUY_BUTTON_ON;

	public GameObject ZAMOK;

	public GameObject BUY_UI;

	public GameObject BACK_UI;

	public GameObject INFO_UI;

	public GameObject MAIN_UI;

	public GameObject ENGINES_MENU;

	public GameObject TIRES_MENU;

	public GameObject TRANS_MENU;

	public GameObject BRAKES_MENU;

	public GameObject NITRO_MENU;

	public GameObject SUSPENSION_MENU;

	public GameObject WEIGHT_MENU;

	public Text TITLE_TXT;

	public Text DESCR_TXT;

	public Text COST_TXT;

	public Text GEAR_TXT;

	public Image POWER_IMG;

	public Image SPEED_IMG;

	public Image CONTROL_IMG;

	public Text POWER_TXT;

	public Text SPEED_TXT;

	public Text CONTROL_TXT;

	public Text CURRENT_MONEY_TXT;

	public Text CURRENT_LEVEL_TXT;

	public Text CURRENT_GEAR_TXT;

	public Image CURRENT_XP_IMG;

	public AudioClip UI_CLICK;

	public AudioClip BACK_CLICK;

	public AudioClip UPGRADE_SND;

	public static bool BUY_AVAIBLE;

	public static string UPGRADE_ITEM;

	public static int UPGRADE_STADIA;

	public static int UPGRADE_COST;

	public static int UPGRADE_GEAR;

	private int PLAYER_MONEY;

	private int PLAYER_GEAR;

	public static bool UPGRADE_COMPLETE;

	public GameObject MONEY_OBJ;

	public GameObject DETAIL_OBJ;

	public GameObject COMPLETE_OBJ;

	public static int MORE_COST;

	private void Awake()
	{
		if (ES2.Load<int>("SELECT_CHARACTER") == 8)
		{
			MORE_COST = 1;
		}
		else
		{
			MORE_COST = 0;
		}
	}

	private void Start()
	{
		BUY_AVAIBLE = false;
		UPGRADE_ITEM = string.Empty;
		UPGRADE_STADIA = 0;
		UPGRADE_COST = 0;
		UPGRADE_GEAR = 0;
		HIDE_ALL();
		MAIN_UI.SetActive(value: true);
		BACK_UI.SetActive(value: true);
		PLAYER_MONEY = ES2.Load<int>("PLAYER_MONEY");
		PLAYER_GEAR = ES2.Load<int>("PLAYER_GEAR");
		CURRENT_MONEY_TXT.text = string.Empty + PLAYER_MONEY;
		CURRENT_GEAR_TXT.text = string.Empty + PLAYER_GEAR;
		if (MENU_MANAGER.LANGUAGE == 1)
		{
			CURRENT_LEVEL_TXT.text = ES2.Load<int>("PLAYER_LEVEL") + " ур";
		}
		else
		{
			CURRENT_LEVEL_TXT.text = ES2.Load<int>("PLAYER_LEVEL") + " lv";
		}
		CURRENT_XP_IMG.fillAmount = ES2.Load<float>("PLAYER_LEVEL_PROGRESS");
	}

	private void Update()
	{
		if (BUY_AVAIBLE)
		{
			StartCoroutine(BUY_BUTTON_());
			BUY_AVAIBLE = false;
		}
		if (UPGRADE_COMPLETE)
		{
			COMPLETE_OBJ.SetActive(value: true);
			DETAIL_OBJ.SetActive(value: false);
			MONEY_OBJ.SetActive(value: false);
		}
		else
		{
			COMPLETE_OBJ.SetActive(value: false);
			DETAIL_OBJ.SetActive(value: true);
			MONEY_OBJ.SetActive(value: true);
		}
	}

	private IEnumerator BUY_BUTTON_()
	{
		yield return new WaitForSecondsRealtime(0.7f);
		BUY_BUTTON.SetActive(value: true);
		if (PLAYER_MONEY < UPGRADE_COST || PLAYER_GEAR < UPGRADE_GEAR)
		{
			BUY_BUTTON.GetComponent<Button>().interactable = false;
			BUY_BUTTON.GetComponent<Image>().sprite = BUY_BUTTON_OFF;
			ZAMOK.SetActive(value: true);
		}
		else
		{
			BUY_BUTTON.GetComponent<Button>().interactable = true;
			BUY_BUTTON.GetComponent<Image>().sprite = BUY_BUTTON_ON;
			ZAMOK.SetActive(value: false);
		}
	}

	public void BUY_ITEM()
	{
		AudioSource.PlayClipAtPoint(UI_CLICK, GARAGE_CAMERA.transform.position, 0.5f);
		BUY_UI.SetActive(value: true);
	}

	public void CANCEL_BUY_ITEM()
	{
		AudioSource.PlayClipAtPoint(BACK_CLICK, GARAGE_CAMERA.transform.position, 0.5f);
		BUY_UI.SetActive(value: false);
	}

	public void ACCEPT_BUY_ITEM()
	{
		if (MENU_MANAGER.LANGUAGE == 1)
		{
			AudioSource.PlayClipAtPoint(VOICE_[Random.Range(0, VOICE_.Length)], GARAGE_CAMERA.transform.position, 1f);
		}
		AudioSource.PlayClipAtPoint(UI_CLICK, GARAGE_CAMERA.transform.position, 0.5f);
		BUY_UI.SetActive(value: false);
		PLAYER_MONEY -= UPGRADE_COST;
		PLAYER_GEAR -= UPGRADE_GEAR;
		ES2.Save(PLAYER_MONEY, "PLAYER_MONEY");
		ES2.Save(PLAYER_GEAR, "PLAYER_GEAR");
		if (UPGRADE_ITEM == "ENGINE")
		{
			int num = MENU_MANAGER.SPAWN_CAR_ + 1;
			string identifier = "CAR" + num + "_ENGINE";
			ES2.Save(UPGRADE_STADIA, identifier);
			Start();
			TO_ENGINES();
		}
		if (UPGRADE_ITEM == "TIRES")
		{
			int num2 = MENU_MANAGER.SPAWN_CAR_ + 1;
			string identifier2 = "CAR" + num2 + "_TIRES";
			ES2.Save(UPGRADE_STADIA, identifier2);
			Start();
			TO_TIRES();
		}
		if (UPGRADE_ITEM == "TRANS")
		{
			int num3 = MENU_MANAGER.SPAWN_CAR_ + 1;
			string identifier3 = "CAR" + num3 + "_KPP";
			ES2.Save(UPGRADE_STADIA, identifier3);
			Start();
			TO_TRANS();
		}
		if (UPGRADE_ITEM == "BRAKES")
		{
			int num4 = MENU_MANAGER.SPAWN_CAR_ + 1;
			string identifier4 = "CAR" + num4 + "_BRAKES";
			ES2.Save(UPGRADE_STADIA, identifier4);
			Start();
			TO_BRAKES();
		}
		if (UPGRADE_ITEM == "NITRO")
		{
			int num5 = MENU_MANAGER.SPAWN_CAR_ + 1;
			string identifier5 = "CAR" + num5 + "_NITRO";
			ES2.Save(UPGRADE_STADIA, identifier5);
			Start();
			TO_NITRO();
		}
		if (UPGRADE_ITEM == "SUSP")
		{
			int num6 = MENU_MANAGER.SPAWN_CAR_ + 1;
			string identifier6 = "CAR" + num6 + "_SUSP";
			ES2.Save(UPGRADE_STADIA, identifier6);
			Start();
			TO_SUSPENSION();
		}
		if (UPGRADE_ITEM == "WEIGHT")
		{
			int num7 = MENU_MANAGER.SPAWN_CAR_ + 1;
			string identifier7 = "CAR" + num7 + "_WEIGHT";
			ES2.Save(UPGRADE_STADIA, identifier7);
			Start();
			TO_WEIGHT();
		}
		GameObject gameObject = Object.Instantiate(BUY_FX, new Vector3(203.15f, 29.46f, 261.43f), base.transform.rotation);
		AudioSource.PlayClipAtPoint(UPGRADE_SND, GARAGE_CAMERA.transform.position, 0.5f);
	}

	public void TO_ENGINES()
	{
		AudioSource.PlayClipAtPoint(UI_CLICK, GARAGE_CAMERA.transform.position, 0.5f);
		HIDE_ALL();
		ENGINES_MENU.SetActive(value: true);
		INFO_UI.SetActive(value: true);
		if (MENU_MANAGER.LANGUAGE == 1)
		{
			TITLE_TXT.text = "Двигатель";
			DESCR_TXT.text = "Сердце машины, именно от него зависит основная мощность и скорость!";
		}
		else
		{
			TITLE_TXT.text = "ENGINE";
			DESCR_TXT.text = "The heart of the car, it depends on the main power and speed!";
		}
		POWER_IMG.color = new Color(1f, 1f, 1f, 1f);
		POWER_TXT.color = new Color(1f, 0.28f, 0.14f, 1f);
		SPEED_IMG.color = new Color(1f, 1f, 1f, 1f);
		SPEED_TXT.color = new Color(0f, 0.94f, 1f, 1f);
		CONTROL_IMG.color = new Color(0f, 0f, 0f, 0.35f);
		CONTROL_TXT.color = new Color(0f, 0f, 0f, 0.35f);
	}

	public void TO_TIRES()
	{
		AudioSource.PlayClipAtPoint(UI_CLICK, GARAGE_CAMERA.transform.position, 0.5f);
		HIDE_ALL();
		TIRES_MENU.SetActive(value: true);
		INFO_UI.SetActive(value: true);
		if (MENU_MANAGER.LANGUAGE == 1)
		{
			TITLE_TXT.text = "Покрышки";
			DESCR_TXT.text = "От качества покрышек зависит общее управление машиной!";
		}
		else
		{
			TITLE_TXT.text = "TIRES";
			DESCR_TXT.text = "The quality of the tires depends on the overall control of the car!";
		}
		POWER_IMG.color = new Color(0f, 0f, 0f, 0.35f);
		POWER_TXT.color = new Color(0f, 0f, 0f, 0.35f);
		SPEED_IMG.color = new Color(0f, 0f, 0f, 0.35f);
		SPEED_TXT.color = new Color(0f, 0f, 0f, 0.35f);
		CONTROL_IMG.color = new Color(1f, 1f, 1f, 1f);
		CONTROL_TXT.color = new Color(0.2f, 1f, 0.2f, 1f);
	}

	public void TO_TRANS()
	{
		AudioSource.PlayClipAtPoint(UI_CLICK, GARAGE_CAMERA.transform.position, 0.5f);
		HIDE_ALL();
		TRANS_MENU.SetActive(value: true);
		INFO_UI.SetActive(value: true);
		if (MENU_MANAGER.LANGUAGE == 1)
		{
			TITLE_TXT.text = "КПП";
			DESCR_TXT.text = "Чем лучше коробка передач, тем быстрее машина набирает скорость!";
		}
		else
		{
			TITLE_TXT.text = "transmission";
			DESCR_TXT.text = "The better the gearbox, the faster the car picks up speed!";
		}
		POWER_IMG.color = new Color(0f, 0f, 0f, 0.35f);
		POWER_TXT.color = new Color(0f, 0f, 0f, 0.35f);
		SPEED_IMG.color = new Color(1f, 1f, 1f, 1f);
		SPEED_TXT.color = new Color(0f, 0.94f, 1f, 1f);
		CONTROL_IMG.color = new Color(0f, 0f, 0f, 0.35f);
		CONTROL_TXT.color = new Color(0f, 0f, 0f, 0.35f);
	}

	public void TO_BRAKES()
	{
		AudioSource.PlayClipAtPoint(UI_CLICK, GARAGE_CAMERA.transform.position, 0.5f);
		HIDE_ALL();
		BRAKES_MENU.SetActive(value: true);
		INFO_UI.SetActive(value: true);
		if (MENU_MANAGER.LANGUAGE == 1)
		{
			TITLE_TXT.text = "ТОРМОЗА";
			DESCR_TXT.text = "Тормозные колодки обеспечивают эффективное торможение!";
		}
		else
		{
			TITLE_TXT.text = "BRAKES";
			DESCR_TXT.text = "Brake pads provide effective braking!";
		}
		POWER_IMG.color = new Color(0f, 0f, 0f, 0.35f);
		POWER_TXT.color = new Color(0f, 0f, 0f, 0.35f);
		SPEED_IMG.color = new Color(0f, 0f, 0f, 0.35f);
		SPEED_TXT.color = new Color(0f, 0f, 0f, 0.35f);
		CONTROL_IMG.color = new Color(1f, 1f, 1f, 1f);
		CONTROL_TXT.color = new Color(0.2f, 1f, 0.2f, 1f);
	}

	public void TO_NITRO()
	{
		AudioSource.PlayClipAtPoint(UI_CLICK, GARAGE_CAMERA.transform.position, 0.5f);
		HIDE_ALL();
		NITRO_MENU.SetActive(value: true);
		INFO_UI.SetActive(value: true);
		if (MENU_MANAGER.LANGUAGE == 1)
		{
			TITLE_TXT.text = "НИТРО";
			DESCR_TXT.text = "Вспрыск нитро временно увеличивает мощность и скорость!";
		}
		else
		{
			TITLE_TXT.text = "BOOST";
			DESCR_TXT.text = "The nitro injection temporarily increases the power and speed!";
		}
		POWER_IMG.color = new Color(0f, 0f, 0f, 0.35f);
		POWER_TXT.color = new Color(0f, 0f, 0f, 0.35f);
		SPEED_IMG.color = new Color(1f, 1f, 1f, 1f);
		SPEED_TXT.color = new Color(0f, 0.94f, 1f, 1f);
		CONTROL_IMG.color = new Color(0f, 0f, 0f, 0.35f);
		CONTROL_TXT.color = new Color(0f, 0f, 0f, 0.35f);
	}

	public void TO_SUSPENSION()
	{
		AudioSource.PlayClipAtPoint(UI_CLICK, GARAGE_CAMERA.transform.position, 0.5f);
		HIDE_ALL();
		SUSPENSION_MENU.SetActive(value: true);
		INFO_UI.SetActive(value: true);
		if (MENU_MANAGER.LANGUAGE == 1)
		{
			TITLE_TXT.text = "ПОДВЕСКА";
			DESCR_TXT.text = "Подвеска улучшает стабильность машины на любой поверхности!";
		}
		else
		{
			TITLE_TXT.text = "SUSPENSION";
			DESCR_TXT.text = "Suspension improves the stability of the machine on any surface!";
		}
		POWER_IMG.color = new Color(0f, 0f, 0f, 0.35f);
		POWER_TXT.color = new Color(0f, 0f, 0f, 0.35f);
		SPEED_IMG.color = new Color(0f, 0f, 0f, 0.35f);
		SPEED_TXT.color = new Color(0f, 0f, 0f, 0.35f);
		CONTROL_IMG.color = new Color(1f, 1f, 1f, 1f);
		CONTROL_TXT.color = new Color(0.2f, 1f, 0.2f, 1f);
	}

	public void TO_WEIGHT()
	{
		AudioSource.PlayClipAtPoint(UI_CLICK, GARAGE_CAMERA.transform.position, 0.5f);
		HIDE_ALL();
		WEIGHT_MENU.SetActive(value: true);
		INFO_UI.SetActive(value: true);
		if (MENU_MANAGER.LANGUAGE == 1)
		{
			TITLE_TXT.text = "ВЕС";
			DESCR_TXT.text = "Снижение веса машины увеличивает ее мощность!";
		}
		else
		{
			TITLE_TXT.text = "WEIGHT";
			DESCR_TXT.text = "Reducing the weight of the machine increases its power!";
		}
		POWER_IMG.color = new Color(1f, 1f, 1f, 1f);
		POWER_TXT.color = new Color(1f, 0.28f, 0.14f, 1f);
		SPEED_IMG.color = new Color(0f, 0f, 0f, 0.35f);
		SPEED_TXT.color = new Color(0f, 0f, 0f, 0.35f);
		CONTROL_IMG.color = new Color(0f, 0f, 0f, 0.35f);
		CONTROL_TXT.color = new Color(0f, 0f, 0f, 0.35f);
	}

	public void BACK_TO_MAIN()
	{
		AudioSource.PlayClipAtPoint(BACK_CLICK, GARAGE_CAMERA.transform.position, 0.7f);
		HIDE_ALL();
		MAIN_UI.SetActive(value: true);
		BACK_UI.SetActive(value: true);
	}

	private void HIDE_ALL()
	{
		BUY_BUTTON.SetActive(value: false);
		BACK_UI.SetActive(value: false);
		INFO_UI.SetActive(value: false);
		MAIN_UI.SetActive(value: false);
		ENGINES_MENU.SetActive(value: false);
		TIRES_MENU.SetActive(value: false);
		TRANS_MENU.SetActive(value: false);
		BRAKES_MENU.SetActive(value: false);
		NITRO_MENU.SetActive(value: false);
		SUSPENSION_MENU.SetActive(value: false);
		WEIGHT_MENU.SetActive(value: false);
	}
}
