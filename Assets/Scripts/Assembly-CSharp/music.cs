using UnityEngine;
using UnityEngine.UI;

public class music : MonoBehaviour
{
	public enum EStyleMusic
	{
		DNB,
		ELECTRO,
		ROCK
	}

	public static music MyMusic;

	private bool selFirstAS = true;

	public AudioSource audio1;

	private float VOLUME;

	private Clips selClips;

	public Clips DNB_MUSIC;

	public Clips ELECTRO_MUSIC;

	public Clips ROCK_MUSIC;

	public Text SONG_NAME;

	public float fadingMusic = 2f;

	public bool randomClips = true;

	[SerializeField]
	private EStyleMusic _styleMusic;

	public EStyleMusic styleMusic
	{
		get
		{
			return _styleMusic;
		}
		set
		{
			if (_styleMusic != value)
			{
				_styleMusic = value;
				switch (_styleMusic)
				{
				case EStyleMusic.DNB:
					playDNBMusics();
					break;
				case EStyleMusic.ELECTRO:
					playELECTROMusics();
					break;
				case EStyleMusic.ROCK:
					playROCKMusics();
					break;
				}
			}
		}
	}

	private void OnDisable()
	{
		if (SONG_NAME != null)
		{
			if (MENU_MANAGER.LANGUAGE == 0)
			{
				SONG_NAME.text = "PRESS PLAY BUTTON";
			}
			else
			{
				SONG_NAME.text = "НАЖМИТЕ PLAY";
			}
		}
	}

	private void playMusic()
	{
		selFirstAS = !selFirstAS;
		AudioSource audioSource = ((!selFirstAS) ? audio1 : audio1);
		audioSource.clip = selClips.GetClip(randomClips);
		audioSource.volume = 0f;
		audioSource.Play();
	}

	private void playDNBMusics()
	{
		SONG_NAME.text = "SUNRISE RADIO";
		selClips = DNB_MUSIC;
		playMusic();
	}

	private void playELECTROMusics()
	{
		SONG_NAME.text = "FUN RADIO";
		selClips = ELECTRO_MUSIC;
		playMusic();
	}

	private void playROCKMusics()
	{
		SONG_NAME.text = "DRIVE RADIO";
		selClips = ROCK_MUSIC;
		playMusic();
	}

	public void nextClip()
	{
		playMusic();
	}

	public void STATION_1()
	{
		playDNBMusics();
	}

	public void STATION_2()
	{
		playELECTROMusics();
	}

	public void STATION_3()
	{
		playROCKMusics();
	}

	private void LateUpdate()
	{
		if (Time.frameCount % 20 != 0)
		{
			return;
		}
		AudioSource audioSource = ((!selFirstAS) ? audio1 : audio1);
		try
		{
			if (audioSource.clip.length - audioSource.time <= fadingMusic)
			{
				playMusic();
				audioSource = ((!selFirstAS) ? audio1 : audio1);
			}
		}
		catch
		{
			playMusic();
			audioSource = ((!selFirstAS) ? audio1 : audio1);
		}
		AudioSource audioSource2 = ((!selFirstAS) ? audio1 : audio1);
		audioSource.volume = Mathf.Clamp01(audioSource.time / fadingMusic);
		audioSource2.volume = VOLUME - 0.25f;
	}

	public void CHANGE_VOLUME()
	{
		VOLUME = GAME_MANAGER.RADIO_VOLUME;
		base.gameObject.GetComponent<AudioSource>().volume = GAME_MANAGER.RADIO_VOLUME;
	}

	private void OnEnable()
	{
		int num = Random.Range(0, 3);
		if (num == 0)
		{
			SONG_NAME.text = "SUNRISE RADIO";
			VOLUME = GAME_MANAGER.RADIO_VOLUME;
			MyMusic = this;
			playDNBMusics();
		}
		if (num == 1)
		{
			SONG_NAME.text = "FUN RADIO";
			VOLUME = GAME_MANAGER.RADIO_VOLUME;
			MyMusic = this;
			playELECTROMusics();
		}
		if (num == 2 || num == 3)
		{
			SONG_NAME.text = "DRIVE RADIO";
			VOLUME = GAME_MANAGER.RADIO_VOLUME;
			MyMusic = this;
			playROCKMusics();
		}
	}
}
