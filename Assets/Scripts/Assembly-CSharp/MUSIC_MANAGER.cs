using UnityEngine;
using UnityEngine.UI;

public class MUSIC_MANAGER : MonoBehaviour
{
	public AudioClip CLICK;

	public AudioClip CLICK2;

	public GameObject XP_OBJ;

	public Image RADIO_ICON;

	public Sprite ICON_OFF;

	public Sprite ICON_ON;

	public GameObject RADIO_OBJ;

	public Slider VOLUME_SLIDER;

	public GameObject PLAY_BUTTON;

	public GameObject STOP_BUTTON;

	private int STATION;

	private void Start()
	{
		RADIO_ICON.sprite = ICON_OFF;
		VOLUME_SLIDER.value = GAME_MANAGER.RADIO_VOLUME;
		base.gameObject.GetComponent<AudioSource>().enabled = false;
		RADIO_ICON.sprite = ICON_ON;
		PLAY_BUTTON.SetActive(value: false);
		STOP_BUTTON.SetActive(value: true);
		base.gameObject.GetComponent<music>().enabled = true;
		base.gameObject.GetComponent<AudioSource>().enabled = true;
		base.gameObject.GetComponent<AudioSource>().volume = GAME_MANAGER.RADIO_VOLUME;
		base.gameObject.GetComponent<AudioSource>().Play();
	}

	public void PLAY_()
	{
		AudioSource.PlayClipAtPoint(CLICK, Camera.main.transform.position);
		RADIO_ICON.sprite = ICON_ON;
		PLAY_BUTTON.SetActive(value: false);
		STOP_BUTTON.SetActive(value: true);
		base.gameObject.GetComponent<music>().enabled = true;
		base.gameObject.GetComponent<AudioSource>().enabled = true;
		base.gameObject.GetComponent<AudioSource>().volume = GAME_MANAGER.RADIO_VOLUME;
		base.gameObject.GetComponent<AudioSource>().Play();
	}

	public void STOP_()
	{
		AudioSource.PlayClipAtPoint(CLICK, Camera.main.transform.position);
		RADIO_ICON.sprite = ICON_OFF;
		PLAY_BUTTON.SetActive(value: true);
		STOP_BUTTON.SetActive(value: false);
		base.gameObject.GetComponent<music>().enabled = false;
		base.gameObject.GetComponent<AudioSource>().enabled = false;
		base.gameObject.GetComponent<AudioSource>().Stop();
	}

	public void NEXT_()
	{
		if (STOP_BUTTON.activeInHierarchy)
		{
			AudioSource.PlayClipAtPoint(CLICK, Camera.main.transform.position);
			STATION++;
			if (STATION > 2)
			{
				STATION = 0;
			}
			if (STATION == 0)
			{
				base.gameObject.GetComponent<music>().STATION_1();
			}
			if (STATION == 1)
			{
				base.gameObject.GetComponent<music>().STATION_2();
			}
			if (STATION == 2)
			{
				base.gameObject.GetComponent<music>().STATION_3();
			}
		}
	}

	public void PREV_()
	{
		if (STOP_BUTTON.activeInHierarchy)
		{
			AudioSource.PlayClipAtPoint(CLICK, Camera.main.transform.position);
			STATION--;
			if (STATION < 0)
			{
				STATION = 2;
			}
			if (STATION == 0)
			{
				base.gameObject.GetComponent<music>().STATION_1();
			}
			if (STATION == 1)
			{
				base.gameObject.GetComponent<music>().STATION_2();
			}
			if (STATION == 2)
			{
				base.gameObject.GetComponent<music>().STATION_3();
			}
		}
	}

	public void OPEN_RADIO_()
	{
		AudioSource.PlayClipAtPoint(CLICK2, Camera.main.transform.position);
		XP_OBJ.SetActive(value: false);
		RADIO_OBJ.SetActive(value: true);
	}

	public void CLOSE_RADIO_()
	{
		AudioSource.PlayClipAtPoint(CLICK2, Camera.main.transform.position);
		RADIO_OBJ.SetActive(value: false);
	}

	public void CHANGE_VOLUME()
	{
		if (Time.timeScale > 0f)
		{
			ES2.Save(VOLUME_SLIDER.value, "RADIO_VOLUME");
			GAME_MANAGER.RADIO_VOLUME = ES2.Load<float>("RADIO_VOLUME");
		}
		else
		{
			VOLUME_SLIDER.value = GAME_MANAGER.RADIO_VOLUME;
		}
		base.gameObject.GetComponent<AudioSource>().volume = VOLUME_SLIDER.value;
	}
}
