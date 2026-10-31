using UnityEngine;
using UnityEngine.UI;

public class RACE_ : MonoBehaviour
{
	public Text LOADING_LOCATION;

	public GameObject LOADING_CANVAS;

	public int INDEX;

	public bool FARM;

	public bool CITY;

	public bool _TRAFFIC_RACE;

	public Sprite WIN_IMG;

	public Sprite NON_IMG;

	public Text PLACE_TXT;

	public GameObject COMPLETE_;

	public AudioClip CLICK_SND;

	private void OnEnable()
	{
		if (_TRAFFIC_RACE)
		{
			if (ES2.Load<int>("RACE_TRAFFIC" + INDEX) == 1)
			{
				base.gameObject.GetComponent<Image>().sprite = WIN_IMG;
				COMPLETE_.SetActive(value: true);
				PLACE_TXT.text = "1 место";
				RACE_MENU.RACE_COMPLETE++;
			}
			else
			{
				base.gameObject.GetComponent<Image>().sprite = NON_IMG;
				COMPLETE_.SetActive(value: false);
			}
		}
		else if (ES2.Load<int>("RACE_" + INDEX) != 0)
		{
			base.gameObject.GetComponent<Image>().sprite = WIN_IMG;
			COMPLETE_.SetActive(value: true);
			PLACE_TXT.text = ES2.Load<int>("RACE_" + INDEX) + " место";
			RACE_MENU.RACE_COMPLETE++;
		}
		else
		{
			base.gameObject.GetComponent<Image>().sprite = NON_IMG;
			COMPLETE_.SetActive(value: false);
		}
		RACE_MENU.RACE_ALL++;
		RACE_MENU.UPD_INFO = true;
	}

	public void START_RACE()
	{
		AudioSource.PlayClipAtPoint(CLICK_SND, Camera.main.transform.position, 1f);
		if (_TRAFFIC_RACE)
		{
			GAME_MANAGER.RACE_TYPE = true;
		}
		else
		{
			GAME_MANAGER.RACE_TYPE = false;
		}
		if (CITY)
		{
			MENU_MANAGER.LOADING_LEVEL = 1;
		}
		else
		{
			MENU_MANAGER.LOADING_LEVEL = 0;
		}
		GAME_MANAGER.NEED_INDEX = INDEX;
		GAME_MANAGER.START_RACE_FROM_MENU = true;
		LOADING_CANVAS.SetActive(value: true);
		if (MENU_MANAGER.LANGUAGE == 0)
		{
			if (MENU_MANAGER.LOADING_LEVEL == 1)
			{
				LOADING_LOCATION.text = "Green Valleys";
			}
			else
			{
				LOADING_LOCATION.text = "SunRise town";
			}
		}
		else if (MENU_MANAGER.LOADING_LEVEL == 0)
		{
			LOADING_LOCATION.text = "Зеленые долины";
		}
		else
		{
			LOADING_LOCATION.text = "Санрайз таун";
		}
		Application.LoadLevel(1);
	}
}
