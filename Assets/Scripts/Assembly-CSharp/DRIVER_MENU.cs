using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DRIVER_MENU : MonoBehaviour
{
	public GameObject BUY_FX2;

	public GameObject CHARACTER_INFO;

	public GameObject DRIVERCAMERA;

	public GameObject[] CHARACTERS;

	public GameObject EFFECT_SPAWN;

	public GameObject UNLOCK_BUTTON;

	public Text UNLOCK_BUTTON_TXT;

	public GameObject CURRENT_BUTTON;

	public GameObject SELECT_BUTTON;

	public GameObject COST_OBJ;

	public GameObject BUYED_OBJ;

	public AudioClip[] WELCOME_SND_RUS;

	public AudioClip NEXT_SND;

	public AudioClip BUY_CHAR_SND;

	public AudioClip CLICK_SND;

	public AudioClip BACK_SND;

	public Text DRIVER_NAME;

	public Text DRIVER_DESCR;

	public Text DRIVER_COST;

	private int SELECT_CHAR;

	private int CHARACTER_INDEX;

	private int OLD_INDEX;

	private int COST_;

	private int CHAR_LVL;

	private int CHAR_1;

	private int CHAR_2;

	private int CHAR_3;

	private int CHAR_4;

	private int CHAR_5;

	private int CHAR_6;

	private int CHAR_7;

	private int CHAR_8;

	private int CHAR_9;

	private int CHAR_10;

	private int CHAR_11;

	private int CHAR_12;

	private int CHAR_13;

	private int CHAR_14;

	private int CHAR_15;

	public GameObject BUYCHAR_UI;

	public GameObject NEED_LVL_POPUP;

	public Text NEED_LVL_POPUP_TXT;

	public GameObject ZAMOK_IMAGE;

	public Image CURRENT_XP_FILL;

	public Text CURRENT_LEVEL_TXT;

	public Text CURRENT_MONEY_TXT2;

	public int CURRENT_MONEY;

	public int CURRENT_XP_LEVEL;

	public Sprite NOT_AVAILIBLE;

	public Sprite AVAILIBLE;

	private GameObject OBJ_;

	private void OnEnable()
	{
		CURRENT_XP_LEVEL = ES2.Load<int>("PLAYER_LEVEL");
		CURRENT_MONEY = ES2.Load<int>("PLAYER_MONEY");
		CURRENT_MONEY_TXT2.text = string.Empty + CURRENT_MONEY;
		float fillAmount = ES2.Load<float>("PLAYER_LEVEL_PROGRESS");
		CURRENT_XP_FILL.fillAmount = fillAmount;
		CHARACTER_INFO.SetActive(value: false);
		CHAR_1 = ES2.Load<int>("CHAR1");
		CHAR_2 = ES2.Load<int>("CHAR2");
		CHAR_3 = ES2.Load<int>("CHAR3");
		CHAR_4 = ES2.Load<int>("CHAR4");
		CHAR_5 = ES2.Load<int>("CHAR5");
		CHAR_6 = ES2.Load<int>("CHAR6");
		CHAR_7 = ES2.Load<int>("CHAR7");
		CHAR_8 = ES2.Load<int>("CHAR8");
		CHAR_9 = ES2.Load<int>("CHAR9");
		CHAR_10 = ES2.Load<int>("CHAR10");
		CHAR_11 = ES2.Load<int>("CHAR11");
		CHAR_12 = ES2.Load<int>("CHAR12");
		CHAR_13 = ES2.Load<int>("CHAR13");
		CHAR_14 = ES2.Load<int>("CHAR14");
		CHAR_15 = ES2.Load<int>("CHAR15");
		SELECT_CHAR = ES2.Load<int>("SELECT_CHARACTER");
		CHARACTER_INDEX = SELECT_CHAR;
		StartCoroutine(SPAWN_CHARACTER());
	}

	private IEnumerator SPAWN_CHARACTER()
	{
		NEED_LVL_POPUP.SetActive(value: false);
		base.gameObject.GetComponent<AudioSource>().Stop();
		GameObject[] PREAFAB_ = GameObject.FindGameObjectsWithTag("CHARACTER");
		GameObject[] array = PREAFAB_;
		foreach (GameObject obj in array)
		{
			Object.Destroy(obj);
		}
		GameObject OBJ_2 = Object.Instantiate(EFFECT_SPAWN, new Vector3(203.32f, 33f, 261.44f), base.transform.rotation);
		yield return new WaitForSecondsRealtime(0.5f);
		GameObject OBJ = Object.Instantiate(CHARACTERS[CHARACTER_INDEX], base.transform.position, base.transform.rotation);
		OBJ.transform.position = new Vector3(203.22f, 30.76f, 259.67f);
		OBJ.transform.rotation = Quaternion.Euler(0f, 178.2f, 0f);
		OLD_INDEX = CHARACTER_INDEX;
		if (MENU_MANAGER.LANGUAGE == 1)
		{
			base.gameObject.GetComponent<AudioSource>().clip = WELCOME_SND_RUS[CHARACTER_INDEX];
			base.gameObject.GetComponent<AudioSource>().Play();
		}
		OBJ_ = OBJ;
		CHARACTER_INFO.SetActive(value: true);
		if (CHARACTER_INDEX == 0)
		{
			if (MENU_MANAGER.LANGUAGE == 1)
			{
				DRIVER_NAME.text = "Мак";
				DRIVER_DESCR.text = "Обычный сельский парень, без особенностей";
			}
			else
			{
				DRIVER_NAME.text = "Mac";
				DRIVER_DESCR.text = "The usual rural guy, without features";
			}
			CHAR_LVL = 0;
		}
		if (CHARACTER_INDEX == 1)
		{
			if (MENU_MANAGER.LANGUAGE == 1)
			{
				DRIVER_NAME.text = "Джек";
				DRIVER_DESCR.text = "Увеличение обьема <color=#0095FF>нитро</color> на <color=#FFB800>10%</color>";
			}
			else
			{
				DRIVER_NAME.text = "Jack";
				DRIVER_DESCR.text = "Increase volume <color=#0095FF>boost</color> by <color=#FFB800>10%</color>";
			}
			COST_ = 1000;
			DRIVER_COST.text = string.Empty + COST_;
			CHAR_LVL = 3;
		}
		if (CHARACTER_INDEX == 2)
		{
			if (MENU_MANAGER.LANGUAGE == 1)
			{
				DRIVER_NAME.text = "Майкл";
				DRIVER_DESCR.text = "Максимальная <color=#0095FF>скорость</color> больше на <color=#FFB800>5%</color>";
			}
			else
			{
				DRIVER_NAME.text = "Michael";
				DRIVER_DESCR.text = "Maximum <color=#0095FF>speed</color> more on <color=#FFB800>5%</color>";
			}
			COST_ = 2500;
			DRIVER_COST.text = string.Empty + COST_;
			CHAR_LVL = 8;
		}
		if (CHARACTER_INDEX == 3)
		{
			if (MENU_MANAGER.LANGUAGE == 1)
			{
				DRIVER_NAME.text = "Грэгори";
				DRIVER_DESCR.text = "Увеличение <color=#0095FF>опыта</color> на <color=#FFB800>10%</color>";
			}
			else
			{
				DRIVER_NAME.text = "Gregory";
				DRIVER_DESCR.text = "Increase <color=#0095FF>experience</color> on <color=#FFB800>10%</color>";
			}
			COST_ = 5000;
			DRIVER_COST.text = string.Empty + COST_;
			CHAR_LVL = 15;
		}
		if (CHARACTER_INDEX == 4)
		{
			if (MENU_MANAGER.LANGUAGE == 1)
			{
				DRIVER_NAME.text = "Сэм";
				DRIVER_DESCR.text = "Увеличение обьема <color=#0095FF>бензобака</color> на <color=#FFB800>25%</color>";
			}
			else
			{
				DRIVER_NAME.text = "Sam";
				DRIVER_DESCR.text = "Increase volume <color=#0095FF>gas tank</color> to <color=#FFB800>25%</color>";
			}
			COST_ = 8000;
			DRIVER_COST.text = string.Empty + COST_;
			CHAR_LVL = 17;
		}
		if (CHARACTER_INDEX == 5)
		{
			if (MENU_MANAGER.LANGUAGE == 1)
			{
				DRIVER_NAME.text = "Лео";
				DRIVER_DESCR.text = "Максимальная <color=#0095FF>скорость</color> больше на <color=#FFB800>10%</color>";
			}
			else
			{
				DRIVER_NAME.text = "LEO";
				DRIVER_DESCR.text = "Maximum <color=#0095FF>speed</color> more on <color=#FFB800>10%</color>";
			}
			COST_ = 13000;
			DRIVER_COST.text = string.Empty + COST_;
			CHAR_LVL = 19;
		}
		if (CHARACTER_INDEX == 6)
		{
			if (MENU_MANAGER.LANGUAGE == 1)
			{
				DRIVER_NAME.text = "Джон";
				DRIVER_DESCR.text = "Увеличение <color=#0095FF>выигрыша в гонках</color> на <color=#FFB800>10%</color>";
			}
			else
			{
				DRIVER_NAME.text = "John";
				DRIVER_DESCR.text = "Increase  <color=#0095FF>race wins</color> by <color=#FFB800>10%</color>";
			}
			COST_ = 15000;
			DRIVER_COST.text = string.Empty + COST_;
			CHAR_LVL = 22;
		}
		if (CHARACTER_INDEX == 7)
		{
			if (MENU_MANAGER.LANGUAGE == 1)
			{
				DRIVER_NAME.text = "Стивен";
				DRIVER_DESCR.text = "Каждая найденная <color=#0095FF>монета</color> умножается <color=#FFB800>на два</color>";
			}
			else
			{
				DRIVER_NAME.text = "Steven";
				DRIVER_DESCR.text = "Each found <color=#0095FF>coin</color> is multiplied by <color=#FFB800>twice</color>";
			}
			COST_ = 18000;
			DRIVER_COST.text = string.Empty + COST_;
			CHAR_LVL = 25;
		}
		if (CHARACTER_INDEX == 8)
		{
			if (MENU_MANAGER.LANGUAGE == 1)
			{
				DRIVER_NAME.text = "Ричард";
				DRIVER_DESCR.text = "Цены на апгрейд <color=#0095FF>снижаются</color> на <color=#FFB800>10%</color>";
			}
			else
			{
				DRIVER_NAME.text = "RICHARD";
				DRIVER_DESCR.text = "Upgrade prices <color=#0095FF>go down</color> by  <color=#FFB800>10%</color>";
			}
			COST_ = 22000;
			DRIVER_COST.text = string.Empty + COST_;
			CHAR_LVL = 28;
		}
		if (CHARACTER_INDEX == 9)
		{
			if (MENU_MANAGER.LANGUAGE == 1)
			{
				DRIVER_NAME.text = "Том";
				DRIVER_DESCR.text = "Машина тонет под <color=#0095FF>водой</color> дольше <color=#FFB800>на 50% </color>";
			}
			else
			{
				DRIVER_NAME.text = "Tom";
				DRIVER_DESCR.text = "The machine sinks under <color=#0095FF>water</color> for <color=#FFB800>50% </color> longer than";
			}
			COST_ = 25000;
			DRIVER_COST.text = string.Empty + COST_;
			CHAR_LVL = 30;
		}
		if (CHARACTER_INDEX == 10)
		{
			if (MENU_MANAGER.LANGUAGE == 1)
			{
				DRIVER_NAME.text = "Лукас";
				DRIVER_DESCR.text = "Увеличение обьема <color=#0095FF>нитро</color> на <color=#FFB800>20%</color>";
			}
			else
			{
				DRIVER_NAME.text = "lucas";
				DRIVER_DESCR.text = "Increase volume <color=#0095FF>boost</color> by <color=#FFB800>20%</color>";
			}
			COST_ = 28000;
			DRIVER_COST.text = string.Empty + COST_;
			CHAR_LVL = 34;
		}
		if (CHARACTER_INDEX == 11)
		{
			if (MENU_MANAGER.LANGUAGE == 1)
			{
				DRIVER_NAME.text = "Билли";
				DRIVER_DESCR.text = "Каждая найденная <color=#0095FF>деталь</color> умножается <color=#FFB800>вдвое</color>";
			}
			else
			{
				DRIVER_NAME.text = "Billy";
				DRIVER_DESCR.text = "Each found <color=#0095FF>gear</color> is multiplied by <color=#FFB800>twice</color>";
			}
			COST_ = 34000;
			DRIVER_COST.text = string.Empty + COST_;
			CHAR_LVL = 37;
		}
		if (CHARACTER_INDEX == 12)
		{
			if (MENU_MANAGER.LANGUAGE == 1)
			{
				DRIVER_NAME.text = "Шон";
				DRIVER_DESCR.text = "С подсолнухов  <color=#0095FF>выпадает</color> вдвое <color=#FFB800>больше семян</color>";
			}
			else
			{
				DRIVER_NAME.text = "Sean";
				DRIVER_DESCR.text = "Each found <color=#0095FF>seed</color> is multiplied by <color=#FFB800>twice</color>";
			}
			COST_ = 38000;
			DRIVER_COST.text = string.Empty + COST_;
			CHAR_LVL = 40;
		}
		if (CHARACTER_INDEX == 13)
		{
			if (MENU_MANAGER.LANGUAGE == 1)
			{
				DRIVER_NAME.text = "Марвин";
				DRIVER_DESCR.text = "Увеличение <color=#0095FF>опыта</color> на <color=#FFB800>25%</color>";
			}
			else
			{
				DRIVER_NAME.text = "Marvin";
				DRIVER_DESCR.text = "Increase <color=#0095FF>experience</color> on <color=#FFB800>25%</color>";
			}
			COST_ = 43000;
			DRIVER_COST.text = string.Empty + COST_;
			CHAR_LVL = 42;
		}
		if (CHARACTER_INDEX == 14)
		{
			if (MENU_MANAGER.LANGUAGE == 1)
			{
				DRIVER_NAME.text = "Нил";
				DRIVER_DESCR.text = "Увеличение обьема <color=#0095FF>бензобака</color> на <color=#FFB800>50%</color>";
			}
			else
			{
				DRIVER_NAME.text = "Neal";
				DRIVER_DESCR.text = "Increase volume <color=#0095FF>gas tank</color> to <color=#FFB800>50%</color>";
			}
			COST_ = 50000;
			DRIVER_COST.text = string.Empty + COST_;
			CHAR_LVL = 45;
		}
		if (CHARACTER_INDEX == 0)
		{
			CURRENT_BUTTON.SetActive(value: false);
			SELECT_BUTTON.SetActive(value: false);
			if (CHAR_1 == 0)
			{
				COST_OBJ.SetActive(value: true);
				BUYED_OBJ.SetActive(value: false);
				CHECK_CHAR();
			}
			else
			{
				COST_OBJ.SetActive(value: false);
				BUYED_OBJ.SetActive(value: true);
				StopCoroutine(SELECT_CHAR_());
				UNLOCK_BUTTON.SetActive(value: false);
				if (SELECT_CHAR == CHARACTER_INDEX)
				{
					StartCoroutine(CURRENT_CHAR_());
				}
				else
				{
					StartCoroutine(SELECT_CHAR_());
				}
			}
		}
		if (CHARACTER_INDEX == 1)
		{
			CURRENT_BUTTON.SetActive(value: false);
			SELECT_BUTTON.SetActive(value: false);
			if (CHAR_2 == 0)
			{
				COST_OBJ.SetActive(value: true);
				BUYED_OBJ.SetActive(value: false);
				CHECK_CHAR();
			}
			else
			{
				COST_OBJ.SetActive(value: false);
				BUYED_OBJ.SetActive(value: true);
				StopCoroutine(SELECT_CHAR_());
				UNLOCK_BUTTON.SetActive(value: false);
				if (SELECT_CHAR == CHARACTER_INDEX)
				{
					StartCoroutine(CURRENT_CHAR_());
				}
				else
				{
					StartCoroutine(SELECT_CHAR_());
				}
			}
		}
		if (CHARACTER_INDEX == 2)
		{
			CURRENT_BUTTON.SetActive(value: false);
			SELECT_BUTTON.SetActive(value: false);
			if (CHAR_3 == 0)
			{
				COST_OBJ.SetActive(value: true);
				BUYED_OBJ.SetActive(value: false);
				CHECK_CHAR();
			}
			else
			{
				COST_OBJ.SetActive(value: false);
				BUYED_OBJ.SetActive(value: true);
				StopCoroutine(SELECT_CHAR_());
				UNLOCK_BUTTON.SetActive(value: false);
				if (SELECT_CHAR == CHARACTER_INDEX)
				{
					StartCoroutine(CURRENT_CHAR_());
				}
				else
				{
					StartCoroutine(SELECT_CHAR_());
				}
			}
		}
		if (CHARACTER_INDEX == 3)
		{
			CURRENT_BUTTON.SetActive(value: false);
			SELECT_BUTTON.SetActive(value: false);
			if (CHAR_4 == 0)
			{
				COST_OBJ.SetActive(value: true);
				BUYED_OBJ.SetActive(value: false);
				CHECK_CHAR();
			}
			else
			{
				COST_OBJ.SetActive(value: false);
				BUYED_OBJ.SetActive(value: true);
				StopCoroutine(SELECT_CHAR_());
				UNLOCK_BUTTON.SetActive(value: false);
				if (SELECT_CHAR == CHARACTER_INDEX)
				{
					StartCoroutine(CURRENT_CHAR_());
				}
				else
				{
					StartCoroutine(SELECT_CHAR_());
				}
			}
		}
		if (CHARACTER_INDEX == 4)
		{
			CURRENT_BUTTON.SetActive(value: false);
			SELECT_BUTTON.SetActive(value: false);
			if (CHAR_5 == 0)
			{
				COST_OBJ.SetActive(value: true);
				BUYED_OBJ.SetActive(value: false);
				CHECK_CHAR();
			}
			else
			{
				COST_OBJ.SetActive(value: false);
				BUYED_OBJ.SetActive(value: true);
				StopCoroutine(SELECT_CHAR_());
				UNLOCK_BUTTON.SetActive(value: false);
				if (SELECT_CHAR == CHARACTER_INDEX)
				{
					StartCoroutine(CURRENT_CHAR_());
				}
				else
				{
					StartCoroutine(SELECT_CHAR_());
				}
			}
		}
		if (CHARACTER_INDEX == 5)
		{
			CURRENT_BUTTON.SetActive(value: false);
			SELECT_BUTTON.SetActive(value: false);
			if (CHAR_6 == 0)
			{
				COST_OBJ.SetActive(value: true);
				BUYED_OBJ.SetActive(value: false);
				CHECK_CHAR();
			}
			else
			{
				COST_OBJ.SetActive(value: false);
				BUYED_OBJ.SetActive(value: true);
				StopCoroutine(SELECT_CHAR_());
				UNLOCK_BUTTON.SetActive(value: false);
				if (SELECT_CHAR == CHARACTER_INDEX)
				{
					StartCoroutine(CURRENT_CHAR_());
				}
				else
				{
					StartCoroutine(SELECT_CHAR_());
				}
			}
		}
		if (CHARACTER_INDEX == 6)
		{
			CURRENT_BUTTON.SetActive(value: false);
			SELECT_BUTTON.SetActive(value: false);
			if (CHAR_7 == 0)
			{
				COST_OBJ.SetActive(value: true);
				BUYED_OBJ.SetActive(value: false);
				CHECK_CHAR();
			}
			else
			{
				COST_OBJ.SetActive(value: false);
				BUYED_OBJ.SetActive(value: true);
				StopCoroutine(SELECT_CHAR_());
				UNLOCK_BUTTON.SetActive(value: false);
				if (SELECT_CHAR == CHARACTER_INDEX)
				{
					StartCoroutine(CURRENT_CHAR_());
				}
				else
				{
					StartCoroutine(SELECT_CHAR_());
				}
			}
		}
		if (CHARACTER_INDEX == 7)
		{
			CURRENT_BUTTON.SetActive(value: false);
			SELECT_BUTTON.SetActive(value: false);
			if (CHAR_8 == 0)
			{
				COST_OBJ.SetActive(value: true);
				BUYED_OBJ.SetActive(value: false);
				CHECK_CHAR();
			}
			else
			{
				COST_OBJ.SetActive(value: false);
				BUYED_OBJ.SetActive(value: true);
				StopCoroutine(SELECT_CHAR_());
				UNLOCK_BUTTON.SetActive(value: false);
				if (SELECT_CHAR == CHARACTER_INDEX)
				{
					StartCoroutine(CURRENT_CHAR_());
				}
				else
				{
					StartCoroutine(SELECT_CHAR_());
				}
			}
		}
		if (CHARACTER_INDEX == 8)
		{
			CURRENT_BUTTON.SetActive(value: false);
			SELECT_BUTTON.SetActive(value: false);
			if (CHAR_9 == 0)
			{
				COST_OBJ.SetActive(value: true);
				BUYED_OBJ.SetActive(value: false);
				CHECK_CHAR();
			}
			else
			{
				COST_OBJ.SetActive(value: false);
				BUYED_OBJ.SetActive(value: true);
				StopCoroutine(SELECT_CHAR_());
				UNLOCK_BUTTON.SetActive(value: false);
				if (SELECT_CHAR == CHARACTER_INDEX)
				{
					StartCoroutine(CURRENT_CHAR_());
				}
				else
				{
					StartCoroutine(SELECT_CHAR_());
				}
			}
		}
		if (CHARACTER_INDEX == 9)
		{
			CURRENT_BUTTON.SetActive(value: false);
			SELECT_BUTTON.SetActive(value: false);
			if (CHAR_10 == 0)
			{
				COST_OBJ.SetActive(value: true);
				BUYED_OBJ.SetActive(value: false);
				CHECK_CHAR();
			}
			else
			{
				COST_OBJ.SetActive(value: false);
				BUYED_OBJ.SetActive(value: true);
				StopCoroutine(SELECT_CHAR_());
				UNLOCK_BUTTON.SetActive(value: false);
				if (SELECT_CHAR == CHARACTER_INDEX)
				{
					StartCoroutine(CURRENT_CHAR_());
				}
				else
				{
					StartCoroutine(SELECT_CHAR_());
				}
			}
		}
		if (CHARACTER_INDEX == 10)
		{
			CURRENT_BUTTON.SetActive(value: false);
			SELECT_BUTTON.SetActive(value: false);
			if (CHAR_11 == 0)
			{
				COST_OBJ.SetActive(value: true);
				BUYED_OBJ.SetActive(value: false);
				CHECK_CHAR();
			}
			else
			{
				COST_OBJ.SetActive(value: false);
				BUYED_OBJ.SetActive(value: true);
				StopCoroutine(SELECT_CHAR_());
				UNLOCK_BUTTON.SetActive(value: false);
				if (SELECT_CHAR == CHARACTER_INDEX)
				{
					StartCoroutine(CURRENT_CHAR_());
				}
				else
				{
					StartCoroutine(SELECT_CHAR_());
				}
			}
		}
		if (CHARACTER_INDEX == 11)
		{
			CURRENT_BUTTON.SetActive(value: false);
			SELECT_BUTTON.SetActive(value: false);
			if (CHAR_12 == 0)
			{
				COST_OBJ.SetActive(value: true);
				BUYED_OBJ.SetActive(value: false);
				CHECK_CHAR();
			}
			else
			{
				COST_OBJ.SetActive(value: false);
				BUYED_OBJ.SetActive(value: true);
				StopCoroutine(SELECT_CHAR_());
				UNLOCK_BUTTON.SetActive(value: false);
				if (SELECT_CHAR == CHARACTER_INDEX)
				{
					StartCoroutine(CURRENT_CHAR_());
				}
				else
				{
					StartCoroutine(SELECT_CHAR_());
				}
			}
		}
		if (CHARACTER_INDEX == 12)
		{
			CURRENT_BUTTON.SetActive(value: false);
			SELECT_BUTTON.SetActive(value: false);
			if (CHAR_13 == 0)
			{
				COST_OBJ.SetActive(value: true);
				BUYED_OBJ.SetActive(value: false);
				CHECK_CHAR();
			}
			else
			{
				COST_OBJ.SetActive(value: false);
				BUYED_OBJ.SetActive(value: true);
				StopCoroutine(SELECT_CHAR_());
				UNLOCK_BUTTON.SetActive(value: false);
				if (SELECT_CHAR == CHARACTER_INDEX)
				{
					StartCoroutine(CURRENT_CHAR_());
				}
				else
				{
					StartCoroutine(SELECT_CHAR_());
				}
			}
		}
		if (CHARACTER_INDEX == 13)
		{
			CURRENT_BUTTON.SetActive(value: false);
			SELECT_BUTTON.SetActive(value: false);
			if (CHAR_14 == 0)
			{
				COST_OBJ.SetActive(value: true);
				BUYED_OBJ.SetActive(value: false);
				CHECK_CHAR();
			}
			else
			{
				COST_OBJ.SetActive(value: false);
				BUYED_OBJ.SetActive(value: true);
				StopCoroutine(SELECT_CHAR_());
				UNLOCK_BUTTON.SetActive(value: false);
				if (SELECT_CHAR == CHARACTER_INDEX)
				{
					StartCoroutine(CURRENT_CHAR_());
				}
				else
				{
					StartCoroutine(SELECT_CHAR_());
				}
			}
		}
		if (CHARACTER_INDEX != 14)
		{
			yield break;
		}
		CURRENT_BUTTON.SetActive(value: false);
		SELECT_BUTTON.SetActive(value: false);
		if (CHAR_15 == 0)
		{
			COST_OBJ.SetActive(value: true);
			BUYED_OBJ.SetActive(value: false);
			CHECK_CHAR();
			yield break;
		}
		COST_OBJ.SetActive(value: false);
		BUYED_OBJ.SetActive(value: true);
		StopCoroutine(SELECT_CHAR_());
		UNLOCK_BUTTON.SetActive(value: false);
		if (SELECT_CHAR == CHARACTER_INDEX)
		{
			StartCoroutine(CURRENT_CHAR_());
		}
		else
		{
			StartCoroutine(SELECT_CHAR_());
		}
	}

	public void BUY_CHAR_CANCEL()
	{
		AudioSource.PlayClipAtPoint(BACK_SND, DRIVERCAMERA.transform.position, 0.5f);
		BUYCHAR_UI.SetActive(value: false);
	}

	public void BUY_CHAR()
	{
		AudioSource.PlayClipAtPoint(CLICK_SND, DRIVERCAMERA.transform.position, 0.5f);
		if (OBJ_ != null)
		{
			BUYCHAR_UI.SetActive(value: true);
		}
	}

	public void SELECT_CHAR__()
	{
		AudioSource.PlayClipAtPoint(CLICK_SND, DRIVERCAMERA.transform.position, 1f);
		ES2.Save(OLD_INDEX, "SELECT_CHARACTER");
		SELECT_CHAR = ES2.Load<int>("SELECT_CHARACTER");
		SELECT_BUTTON.SetActive(value: false);
		CURRENT_BUTTON.SetActive(value: true);
	}

	private IEnumerator BUY_FX_()
	{
		GameObject OBJ_22 = Object.Instantiate(BUY_FX2, new Vector3(203.15f, 30.13f, 259.93f), base.transform.rotation);
		yield return new WaitForSecondsRealtime(5f);
	}

	public void BUY_CHAR_ACCEPT()
	{
		StartCoroutine(BUY_FX_());
		AudioSource.PlayClipAtPoint(CLICK_SND, DRIVERCAMERA.transform.position, 0.5f);
		AudioSource.PlayClipAtPoint(BUY_CHAR_SND, DRIVERCAMERA.transform.position, 1f);
		UNLOCK_BUTTON.SetActive(value: false);
		CURRENT_BUTTON.SetActive(value: true);
		BUYCHAR_UI.SetActive(value: false);
		CURRENT_MONEY -= COST_;
		ES2.Save(OLD_INDEX, "SELECT_CHARACTER");
		int num = OLD_INDEX + 1;
		ES2.Save(1, "CHAR" + num);
		ES2.Save(CURRENT_MONEY, "PLAYER_MONEY");
		SELECT_CHAR = ES2.Load<int>("SELECT_CHARACTER");
		CURRENT_MONEY = ES2.Load<int>("PLAYER_MONEY");
		CURRENT_MONEY_TXT2.text = string.Empty + CURRENT_MONEY;
		CHAR_1 = ES2.Load<int>("CHAR1");
		CHAR_2 = ES2.Load<int>("CHAR2");
		CHAR_3 = ES2.Load<int>("CHAR3");
		CHAR_4 = ES2.Load<int>("CHAR4");
		CHAR_5 = ES2.Load<int>("CHAR5");
		CHAR_6 = ES2.Load<int>("CHAR6");
		CHAR_7 = ES2.Load<int>("CHAR7");
		CHAR_8 = ES2.Load<int>("CHAR8");
		CHAR_9 = ES2.Load<int>("CHAR9");
		CHAR_10 = ES2.Load<int>("CHAR10");
		CHAR_11 = ES2.Load<int>("CHAR11");
		CHAR_12 = ES2.Load<int>("CHAR12");
		CHAR_13 = ES2.Load<int>("CHAR13");
		CHAR_14 = ES2.Load<int>("CHAR14");
		CHAR_15 = ES2.Load<int>("CHAR15");
		if (CHAR_2 == 1)
		{
		}
		if (CHAR_3 == 1)
		{
		}
		if (CHAR_4 == 1)
		{
		}
		if (CHAR_5 == 1)
		{
		}
		if (CHAR_6 == 1)
		{
		}
		if (CHAR_7 == 1)
		{
		}
		if (CHAR_8 == 1)
		{
		}
		if (CHAR_9 == 1)
		{
		}
		if (CHAR_10 == 1)
		{
		}
		if (CHAR_11 == 1)
		{
		}
		if (CHAR_12 == 1)
		{
		}
		if (CHAR_13 == 1)
		{
		}
		if (CHAR_14 == 1)
		{
		}
		if (CHAR_15 != 1)
		{
		}
	}

	private void CHECK_CHAR()
	{
		StartCoroutine(UNLOCK_BUTTON_());
		if (CURRENT_MONEY < COST_)
		{
			UNLOCK_BUTTON.GetComponent<Button>().interactable = false;
			UNLOCK_BUTTON.GetComponent<Image>().sprite = NOT_AVAILIBLE;
			ZAMOK_IMAGE.SetActive(value: true);
			UNLOCK_BUTTON_TXT.color = new Color(1f, 1f, 1f, 0.5f);
		}
		else
		{
			ZAMOK_IMAGE.SetActive(value: false);
			UNLOCK_BUTTON.GetComponent<Button>().interactable = true;
			UNLOCK_BUTTON.GetComponent<Image>().sprite = AVAILIBLE;
			UNLOCK_BUTTON_TXT.color = new Color(1f, 1f, 1f, 1f);
		}
		if (CURRENT_XP_LEVEL < CHAR_LVL)
		{
			UNLOCK_BUTTON.GetComponent<Button>().interactable = false;
			UNLOCK_BUTTON.GetComponent<Image>().sprite = NOT_AVAILIBLE;
			ZAMOK_IMAGE.SetActive(value: true);
			UNLOCK_BUTTON_TXT.color = new Color(1f, 1f, 1f, 0.5f);
			if (MENU_MANAGER.LANGUAGE == 1)
			{
				NEED_LVL_POPUP_TXT.text = "НЕОБХОДИМ УРОВЕНЬ " + CHAR_LVL + "!";
			}
			else
			{
				NEED_LVL_POPUP_TXT.text = "NEED LEVEL " + CHAR_LVL + "!";
			}
			NEED_LVL_POPUP.SetActive(value: true);
		}
		else
		{
			ZAMOK_IMAGE.SetActive(value: false);
			UNLOCK_BUTTON.GetComponent<Button>().interactable = true;
			UNLOCK_BUTTON.GetComponent<Image>().sprite = AVAILIBLE;
			UNLOCK_BUTTON_TXT.color = new Color(1f, 1f, 1f, 1f);
			NEED_LVL_POPUP.SetActive(value: false);
		}
	}

	private IEnumerator UNLOCK_BUTTON_()
	{
		yield return new WaitForSecondsRealtime(0.7f);
		if (base.gameObject.activeInHierarchy)
		{
			UNLOCK_BUTTON.SetActive(value: true);
		}
	}

	private IEnumerator CURRENT_CHAR_()
	{
		yield return new WaitForSecondsRealtime(0.7f);
		if (base.gameObject.activeInHierarchy)
		{
			CURRENT_BUTTON.SetActive(value: true);
		}
	}

	private IEnumerator SELECT_CHAR_()
	{
		yield return new WaitForSecondsRealtime(0.7f);
		if (base.gameObject.activeInHierarchy)
		{
			SELECT_BUTTON.SetActive(value: true);
		}
	}

	public void NEXT_PERS()
	{
		if (OBJ_ != null)
		{
			AudioSource.PlayClipAtPoint(NEXT_SND, DRIVERCAMERA.transform.position, 0.5f);
			CHARACTER_INDEX++;
			if (CHARACTER_INDEX > 14)
			{
				CHARACTER_INDEX = 0;
			}
			if (CHARACTERS[OLD_INDEX] != null)
			{
				StartCoroutine(SPAWN_CHARACTER());
			}
		}
	}

	public void PREV_PERS()
	{
		if (OBJ_ != null)
		{
			AudioSource.PlayClipAtPoint(NEXT_SND, DRIVERCAMERA.transform.position, 0.5f);
			CHARACTER_INDEX--;
			if (CHARACTER_INDEX < 0)
			{
				CHARACTER_INDEX = 14;
			}
			if (CHARACTERS[OLD_INDEX] != null)
			{
				StartCoroutine(SPAWN_CHARACTER());
			}
		}
	}
}
