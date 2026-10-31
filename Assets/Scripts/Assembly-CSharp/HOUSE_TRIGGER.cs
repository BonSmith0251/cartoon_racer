using System;
using System.Collections;
using UnityEngine;

public class HOUSE_TRIGGER : MonoBehaviour
{
	public int ID;

	public int COST;

	public string NAME_RUS;

	public string NAME_ENG;

	private bool ENTER;

	public static int COST_;

	public static string NAME_;

	public static int ID_;

	public static bool GET_AWARD;

	public static bool HOUSE_BUYED;

	public static bool CHECK;

	public GameObject CASE;

	public Material CASE_NO;

	public Material CASE_YES;

	public void Start()
	{
		if (ES2.Load<int>("HOUSE_" + ID) == 1)
		{
			if (ES2.Load<int>("HOUSE_" + ID + "_TIME") != DateTime.Now.Day)
			{
				CASE.GetComponent<MeshRenderer>().material = CASE_YES;
			}
			else
			{
				CASE.GetComponent<MeshRenderer>().material = CASE_NO;
			}
		}
	}

	private void OnTriggerStay(Collider car2)
	{
		if (CHECK)
		{
			Start();
			CHECK = false;
		}
		if (!((car2.gameObject.tag == "Player") & !ENTER & !GAME_MANAGER.IN_HOUSE_POINT) || !(RCC_CarControllerV3.SPEED < 5f))
		{
			return;
		}
		if (ES2.Load<int>("HOUSE_" + ID) == 0)
		{
			HOUSE_BUYED = false;
		}
		else
		{
			HOUSE_BUYED = true;
			if (ES2.Load<int>("HOUSE_" + ID + "_TIME") != DateTime.Now.Day)
			{
				GET_AWARD = true;
			}
			else
			{
				GET_AWARD = false;
			}
		}
		ID_ = ID;
		COST_ = COST;
		if (MENU_MANAGER.LANGUAGE == 1)
		{
			NAME_ = NAME_RUS;
		}
		else
		{
			NAME_ = NAME_ENG;
		}
		GAME_MANAGER.IN_HOUSE_POINT = true;
		ENTER = true;
	}

	private IEnumerator DELAY()
	{
		yield return new WaitForSecondsRealtime(10f);
		ENTER = false;
	}

	private void OnTriggerExit(Collider car2)
	{
		if ((car2.gameObject.tag == "Player") & !GAME_MANAGER.IN_HOUSE_POINT)
		{
			ENTER = false;
			StartCoroutine(DELAY());
		}
	}
}
