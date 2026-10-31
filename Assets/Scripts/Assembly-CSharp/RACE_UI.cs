using UnityEngine;
using UnityEngine.UI;

public class RACE_UI : MonoBehaviour
{
	public GameObject SILVER_;

	public GameObject BRONZE_;

	public GameObject BKG_1;

	public GameObject BGK_2;

	public Text _3ST_AWARD;

	public Text _2ST_AWARD;

	public Text _1ST_AWARD;

	public Text _3ST_AWARD_;

	public Text _2ST_AWARD_;

	public Text _1ST_AWARD_;

	public Text RACE_TYPE;

	public Text RACE_TYPE_;

	private void OnEnable()
	{
		if (ES2.Load<int>("SELECT_CHARACTER") == 6)
		{
			RACE_TRIGGER._1ST_AWARD_ += RACE_TRIGGER._1ST_AWARD_ / 10;
			RACE_TRIGGER._2ST_AWARD_ += RACE_TRIGGER._2ST_AWARD_ / 10;
			RACE_TRIGGER._3ST_AWARD_ += RACE_TRIGGER._3ST_AWARD_ / 10;
		}
		BKG_1.SetActive(value: false);
		BGK_2.SetActive(value: false);
		SILVER_.SetActive(value: true);
		BRONZE_.SetActive(value: true);
		if (RACE_TRIGGER._TIME_RACE)
		{
			if (MENU_MANAGER.LANGUAGE == 1)
			{
				RACE_TYPE.text = "КОНТРОЛЬНЫЕ ТОЧКИ";
				RACE_TYPE_.text = "КОНТРОЛЬНЫЕ ТОЧКИ";
			}
			else
			{
				RACE_TYPE.text = "CHECKPOINT RACE";
				RACE_TYPE_.text = "CHECKPOINT RACE";
			}
			BKG_1.SetActive(value: true);
			BGK_2.SetActive(value: true);
			SILVER_.SetActive(value: false);
			BRONZE_.SetActive(value: false);
		}
		if (RACE_TRIGGER._SPEED_RACE)
		{
			if (MENU_MANAGER.LANGUAGE == 1)
			{
				RACE_TYPE.text = "СКОРОСТНОЙ ЗАЕЗД";
				RACE_TYPE_.text = "СКОРОСТНОЙ ЗАЕЗД";
			}
			else
			{
				RACE_TYPE.text = "SPEED RACE";
				RACE_TYPE_.text = "SPEED RACE";
			}
			BKG_1.SetActive(value: true);
			BGK_2.SetActive(value: true);
			SILVER_.SetActive(value: false);
			BRONZE_.SetActive(value: false);
		}
		if (RACE_TRIGGER._RACE_CIRCUIT || RACE_TRIGGER._AI_RACE)
		{
			if (RACE_TRIGGER._RACE_CIRCUIT_LAPS < 5)
			{
				if (MENU_MANAGER.LANGUAGE == 1)
				{
					RACE_TYPE.text = RACE_TRIGGER._RACE_CIRCUIT_LAPS + " КРУГА";
					RACE_TYPE_.text = RACE_TRIGGER._RACE_CIRCUIT_LAPS + " КРУГА";
				}
				else
				{
					RACE_TYPE.text = RACE_TRIGGER._RACE_CIRCUIT_LAPS + " LAPS";
					RACE_TYPE_.text = RACE_TRIGGER._RACE_CIRCUIT_LAPS + " LAPS";
				}
			}
			else if (MENU_MANAGER.LANGUAGE == 0)
			{
				RACE_TYPE.text = RACE_TRIGGER._RACE_CIRCUIT_LAPS + " LAPS";
				RACE_TYPE_.text = RACE_TRIGGER._RACE_CIRCUIT_LAPS + " LAPS";
			}
			else
			{
				RACE_TYPE.text = RACE_TRIGGER._RACE_CIRCUIT_LAPS + " КРУГОВ";
				RACE_TYPE_.text = RACE_TRIGGER._RACE_CIRCUIT_LAPS + " КРУГОВ";
			}
		}
		if (RACE_TRIGGER._RACE_SPRINT)
		{
			if (MENU_MANAGER.LANGUAGE == 1)
			{
				RACE_TYPE.text = "СПРИНТ ГОНКА";
				RACE_TYPE_.text = "СПРИНТ ГОНКА";
			}
			else
			{
				RACE_TYPE.text = "SPRINT RACE";
				RACE_TYPE_.text = "SPRINT RACE";
			}
		}
		if (RACE_TRIGGER._TRAFFIC_RACE)
		{
			if (MENU_MANAGER.LANGUAGE == 1)
			{
				RACE_TYPE.text = "ТРАФИК ЗАЕЗД ";
				RACE_TYPE_.text = "ТРАФИК ЗАЕЗД";
			}
			else
			{
				RACE_TYPE.text = "TRAFFIC RACE ";
				RACE_TYPE_.text = "TRAFFIC RACE";
			}
			BKG_1.SetActive(value: true);
			BGK_2.SetActive(value: true);
			SILVER_.SetActive(value: false);
			BRONZE_.SetActive(value: false);
		}
		_1ST_AWARD.text = string.Empty + RACE_TRIGGER._1ST_AWARD_;
		_2ST_AWARD.text = string.Empty + RACE_TRIGGER._2ST_AWARD_;
		_3ST_AWARD.text = string.Empty + RACE_TRIGGER._3ST_AWARD_;
		_1ST_AWARD_.text = string.Empty + RACE_TRIGGER._1ST_AWARD_;
		_2ST_AWARD_.text = string.Empty + RACE_TRIGGER._2ST_AWARD_;
		_3ST_AWARD_.text = string.Empty + RACE_TRIGGER._3ST_AWARD_;
	}
}
