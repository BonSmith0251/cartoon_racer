using UnityEngine;
using UnityEngine.UI;

public class TARGETS_MENU : MonoBehaviour
{
	public GameObject END_GAME;

	public Image ZADANIE1_IMG;

	public Image ZADANIE2_IMG;

	public Image ZADANIE3_IMG;

	public Image ZADANIE4_IMG;

	public Image ZADANIE5_IMG;

	public Image ZADANIE6_IMG;

	public Image ZADANIE7_IMG;

	public Image ZADANIE8_IMG;

	public Image ZADANIE9_IMG;

	public Image ZADANIE10_IMG;

	public Image ZADANIE11_IMG;

	public Text ZADANIE1_TXT;

	public Text ZADANIE2_TXT;

	public Text ZADANIE3_TXT;

	public Text ZADANIE4_TXT;

	public Text ZADANIE5_TXT;

	public Text ZADANIE6_TXT;

	public Text ZADANIE7_TXT;

	public Text ZADANIE8_TXT;

	public Text ZADANIE9_TXT;

	public Text ZADANIE10_TXT;

	public Text ZADANIE11_TXT;

	private int ALL_RACE;

	private int ALL_COINS;

	private int SALE_ALL;

	private int DAY_ALL;

	private int ALL_HOUSE;

	private int ALL_CARS;

	private int ALL_DRIVERS;

	private int ALL_LEVEL;

	private int ALL_LICENSE;

	private int ALL_CARRER;

	private int ALL_EVENTS;

	private int ALL_;

	private void OnEnable()
	{
		ALL_ = 0;
		ALL_CARS = 0;
		ALL_HOUSE = 0;
		ALL_RACE = 0;
		ALL_DRIVERS = 0;
		ALL_LICENSE = 0;
		ALL_CARRER = 0;
		ALL_COINS = ES2.Load<int>("ALL_MONEY");
		SALE_ALL = ES2.Load<int>("SALE_ALL");
		DAY_ALL = ES2.Load<int>("DAY_ALL");
		ALL_LEVEL = ES2.Load<int>("PLAYER_LEVEL");
		ALL_EVENTS = ES2.Load<int>("ALL_EVENTS");
		if (ES2.Load<int>("TAXI_DRIVER_LEVEL") == 10)
		{
			ALL_CARRER++;
		}
		if (ES2.Load<int>("MEDIC_DRIVER_LEVEL") == 10)
		{
			ALL_CARRER++;
		}
		if (ES2.Load<int>("COP_DRIVER_LEVEL") == 10)
		{
			ALL_CARRER++;
		}
		if (ES2.Load<int>("TAXI_LICENSE") == 1)
		{
			ALL_LICENSE++;
		}
		if (ES2.Load<int>("MEDIC_LICENSE") == 1)
		{
			ALL_LICENSE++;
		}
		if (ES2.Load<int>("COP_LICENSE") == 1)
		{
			ALL_LICENSE++;
		}
		for (int i = 2; i < 16; i++)
		{
			if (ES2.Load<int>("CHAR" + i) == 1)
			{
				ALL_DRIVERS++;
			}
		}
		for (int j = 1; j < 10; j++)
		{
			if (ES2.Load<int>("CAR" + j) == 1)
			{
				ALL_CARS++;
			}
		}
		for (int k = 0; k < 21; k++)
		{
			if (ES2.Load<int>("HOUSE_" + k) == 1)
			{
				ALL_HOUSE++;
			}
		}
		for (int l = 0; l < 82; l++)
		{
			if (ES2.Load<int>("RACE_" + l) > 0)
			{
				ALL_RACE++;
			}
		}
		for (int m = 0; m < 61; m++)
		{
			if (ES2.Load<int>("RACE_TRAFFIC" + m) == 1)
			{
				ALL_RACE++;
			}
		}
		ZADANIE1_TXT.text = ALL_RACE + " / 145";
		if (ALL_RACE == 145)
		{
			ALL_++;
			ZADANIE1_IMG.color = new Color(1f, 1f, 1f, 1f);
		}
		else
		{
			ZADANIE1_IMG.color = new Color(0f, 0f, 0f, 0.25f);
		}
		ZADANIE2_TXT.text = ALL_COINS + " / 5000";
		if (ALL_COINS >= 5000)
		{
			ALL_++;
			ZADANIE2_IMG.color = new Color(1f, 1f, 1f, 1f);
		}
		else
		{
			ZADANIE2_IMG.color = new Color(0f, 0f, 0f, 0.25f);
		}
		ZADANIE3_TXT.text = SALE_ALL + " / 500";
		if (ALL_COINS >= 500)
		{
			ALL_++;
			ZADANIE3_IMG.color = new Color(1f, 1f, 1f, 1f);
		}
		else
		{
			ZADANIE3_IMG.color = new Color(0f, 0f, 0f, 0.25f);
		}
		ZADANIE4_TXT.text = DAY_ALL + " / 50";
		if (DAY_ALL >= 500)
		{
			ALL_++;
			ZADANIE4_IMG.color = new Color(1f, 1f, 1f, 1f);
		}
		else
		{
			ZADANIE4_IMG.color = new Color(0f, 0f, 0f, 0.25f);
		}
		ZADANIE5_TXT.text = ALL_HOUSE + " / 22";
		if (ALL_HOUSE == 22)
		{
			ALL_++;
			ZADANIE5_IMG.color = new Color(1f, 1f, 1f, 1f);
		}
		else
		{
			ZADANIE5_IMG.color = new Color(0f, 0f, 0f, 0.25f);
		}
		ZADANIE6_TXT.text = ALL_CARS + " / 10";
		if (ALL_CARS == 10)
		{
			ALL_++;
			ZADANIE6_IMG.color = new Color(1f, 1f, 1f, 1f);
		}
		else
		{
			ZADANIE6_IMG.color = new Color(0f, 0f, 0f, 0.25f);
		}
		ZADANIE7_TXT.text = ALL_DRIVERS + " / 14";
		if (ALL_DRIVERS == 14)
		{
			ALL_++;
			ZADANIE7_IMG.color = new Color(1f, 1f, 1f, 1f);
		}
		else
		{
			ZADANIE7_IMG.color = new Color(0f, 0f, 0f, 0.25f);
		}
		ZADANIE8_TXT.text = ALL_LEVEL + " / 70";
		if (ALL_LEVEL > 69)
		{
			ALL_++;
			ZADANIE8_IMG.color = new Color(1f, 1f, 1f, 1f);
		}
		else
		{
			ZADANIE8_IMG.color = new Color(0f, 0f, 0f, 0.25f);
		}
		ZADANIE9_TXT.text = ALL_LICENSE + " / 3";
		if (ALL_LICENSE == 3)
		{
			ALL_++;
			ZADANIE9_IMG.color = new Color(1f, 1f, 1f, 1f);
		}
		else
		{
			ZADANIE9_IMG.color = new Color(0f, 0f, 0f, 0.25f);
		}
		ZADANIE10_TXT.text = ALL_CARRER + " / 3";
		if (ALL_CARRER == 3)
		{
			ALL_++;
			ZADANIE10_IMG.color = new Color(1f, 1f, 1f, 1f);
		}
		else
		{
			ZADANIE10_IMG.color = new Color(0f, 0f, 0f, 0.25f);
		}
		ZADANIE11_TXT.text = ALL_EVENTS + " / 500";
		if (ALL_EVENTS == 3)
		{
			ALL_++;
			ZADANIE11_IMG.color = new Color(1f, 1f, 1f, 1f);
		}
		else
		{
			ZADANIE11_IMG.color = new Color(0f, 0f, 0f, 0.25f);
		}
		if ((ALL_ == 11) & (ES2.Load<int>("END_GAME") == 0))
		{
			END_GAME.SetActive(value: true);
		}
	}

	public void CLOSE_END_GAME()
	{
		END_GAME.SetActive(value: false);
		ES2.Save(1, "END_GAME");
	}
}
