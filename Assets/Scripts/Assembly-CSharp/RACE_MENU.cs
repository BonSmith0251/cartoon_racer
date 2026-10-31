using UnityEngine;
using UnityEngine.UI;

public class RACE_MENU : MonoBehaviour
{
	public GameObject NEED_LEVEL;

	public Text NEED_LEVEL_TXT;

	public GameObject RACEMENU_CAMERA;

	public GameObject[] SEASONS;

	public AudioClip UI_CLICK;

	public AudioClip UI_CLICK2;

	public Text SEASON_NAME;

	public Text COMPLETE_TXT;

	private int CUR_SEASON1;

	private int CUR_SEASON;

	private int MAX_SEASON;

	public static int RACE_ALL;

	public static int RACE_COMPLETE;

	public static bool UPD_INFO;

	private int NEED_LEVEL_;

	private void Update()
	{
		if (!UPD_INFO)
		{
			return;
		}
		if (RACE_COMPLETE == RACE_ALL)
		{
			COMPLETE_TXT.color = new Color(0.3f, 1f, 0.2f, 1f);
		}
		else
		{
			COMPLETE_TXT.color = new Color(1f, 1f, 1f, 1f);
		}
		if (!NEED_LEVEL.activeInHierarchy)
		{
			if (MENU_MANAGER.LANGUAGE == 1)
			{
				COMPLETE_TXT.text = "ВЫПОЛНЕНО " + RACE_COMPLETE + " / " + RACE_ALL;
			}
			else
			{
				COMPLETE_TXT.text = "COMPLETE " + RACE_COMPLETE + " / " + RACE_ALL;
			}
		}
		else
		{
			COMPLETE_TXT.text = null;
		}
		UPD_INFO = false;
	}

	private void OnEnable()
	{
		NEED_LEVEL_ = 0;
		CUR_SEASON = 0;
		CUR_SEASON1 = CUR_SEASON + 1;
		for (int i = 0; i < SEASONS.Length; i++)
		{
			SEASONS[i].SetActive(value: false);
		}
		RACE_ALL = 0;
		RACE_COMPLETE = 0;
		SEASON_NAME.text = "СЕЗОН " + CUR_SEASON1;
		SEASONS[0].SetActive(value: true);
		NEED_LEVEL.SetActive(value: false);
		MAX_SEASON = SEASONS.Length;
	}

	public void NEXT()
	{
		RACE_ALL = 0;
		RACE_COMPLETE = 0;
		AudioSource.PlayClipAtPoint(UI_CLICK2, RACEMENU_CAMERA.transform.position);
		if (CUR_SEASON < MAX_SEASON)
		{
			for (int i = 0; i < SEASONS.Length; i++)
			{
				SEASONS[i].SetActive(value: false);
			}
		}
		CUR_SEASON++;
		CUR_SEASON1 = CUR_SEASON + 1;
		if (MENU_MANAGER.LANGUAGE == 1)
		{
			SEASON_NAME.text = "СЕЗОН " + CUR_SEASON1;
		}
		else
		{
			SEASON_NAME.text = "SEASON " + CUR_SEASON1;
		}
		if (CUR_SEASON >= MAX_SEASON)
		{
			CUR_SEASON = 0;
			CUR_SEASON1 = CUR_SEASON + 1;
			if (MENU_MANAGER.LANGUAGE == 1)
			{
				SEASON_NAME.text = "СЕЗОН " + CUR_SEASON1;
			}
			else
			{
				SEASON_NAME.text = "SEASON " + CUR_SEASON1;
			}
		}
		if (CUR_SEASON == 0)
		{
			NEED_LEVEL_ = 0;
		}
		if (CUR_SEASON == 1)
		{
			NEED_LEVEL_ = 10;
		}
		if (CUR_SEASON == 2)
		{
			NEED_LEVEL_ = 20;
		}
		if (CUR_SEASON == 3)
		{
			NEED_LEVEL_ = 30;
		}
		if (CUR_SEASON == 4)
		{
			NEED_LEVEL_ = 40;
		}
		if (CUR_SEASON == 5)
		{
			NEED_LEVEL_ = 50;
		}
		if (MENU_MANAGER.PLAYER_LEVEL >= NEED_LEVEL_)
		{
			NEED_LEVEL.SetActive(value: false);
			SEASONS[CUR_SEASON].SetActive(value: true);
			return;
		}
		SEASONS[CUR_SEASON].SetActive(value: false);
		NEED_LEVEL.SetActive(value: true);
		if (MENU_MANAGER.LANGUAGE == 1)
		{
			NEED_LEVEL_TXT.text = "необходим " + NEED_LEVEL_ + " уровень!";
		}
		else
		{
			NEED_LEVEL_TXT.text = "need " + NEED_LEVEL_ + " level!";
		}
		COMPLETE_TXT.text = string.Empty;
	}

	public void PREV()
	{
		RACE_ALL = 0;
		RACE_COMPLETE = 0;
		AudioSource.PlayClipAtPoint(UI_CLICK2, RACEMENU_CAMERA.transform.position);
		for (int i = 0; i < SEASONS.Length; i++)
		{
			SEASONS[i].SetActive(value: false);
		}
		CUR_SEASON--;
		CUR_SEASON1 = CUR_SEASON + 1;
		if (MENU_MANAGER.LANGUAGE == 1)
		{
			SEASON_NAME.text = "СЕЗОН " + CUR_SEASON1;
		}
		else
		{
			SEASON_NAME.text = "SEASON " + CUR_SEASON1;
		}
		if (CUR_SEASON < 0)
		{
			CUR_SEASON = MAX_SEASON - 1;
			CUR_SEASON1 = CUR_SEASON + 1;
			if (MENU_MANAGER.LANGUAGE == 1)
			{
				SEASON_NAME.text = "СЕЗОН " + CUR_SEASON1;
			}
			else
			{
				SEASON_NAME.text = "SEASON " + CUR_SEASON1;
			}
		}
		SEASONS[CUR_SEASON].SetActive(value: true);
		if (CUR_SEASON == 0)
		{
			NEED_LEVEL_ = 0;
		}
		if (CUR_SEASON == 1)
		{
			NEED_LEVEL_ = 10;
		}
		if (CUR_SEASON == 2)
		{
			NEED_LEVEL_ = 20;
		}
		if (CUR_SEASON == 3)
		{
			NEED_LEVEL_ = 30;
		}
		if (CUR_SEASON == 4)
		{
			NEED_LEVEL_ = 40;
		}
		if (CUR_SEASON == 5)
		{
			NEED_LEVEL_ = 50;
		}
		if (MENU_MANAGER.PLAYER_LEVEL >= NEED_LEVEL_)
		{
			NEED_LEVEL.SetActive(value: false);
			SEASONS[CUR_SEASON].SetActive(value: true);
			return;
		}
		SEASONS[CUR_SEASON].SetActive(value: false);
		NEED_LEVEL.SetActive(value: true);
		if (MENU_MANAGER.LANGUAGE == 1)
		{
			NEED_LEVEL_TXT.text = "необходим " + NEED_LEVEL_ + " уровень!";
		}
		else
		{
			NEED_LEVEL_TXT.text = "need " + NEED_LEVEL_ + " level!";
		}
		COMPLETE_TXT.text = string.Empty;
	}
}
