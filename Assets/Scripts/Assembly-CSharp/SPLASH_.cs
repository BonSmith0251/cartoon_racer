using TMPro;
using UnityEngine;

public class SPLASH_ : MonoBehaviour
{
	public string PLAYER_NAME;

	public ParticleSystem[] SPLASH_FX;

	public AudioSource WATERSOURCE;

	public GameObject TXT_OBJ;

	private void Start()
	{
		SPLASH_FX[0].Stop();
		SPLASH_FX[1].Stop();
		SPLASH_FX[2].Stop();
		SPLASH_FX[3].Stop();
		SPLASH_FX[4].Stop();
		if (TXT_OBJ != null)
		{
			TXT_OBJ.SetActive(value: false);
			int num = Random.Range(1000, 9999);
			PLAYER_NAME = "PLAYER " + num;
			TXT_OBJ.GetComponent<TextMeshPro>().text = string.Empty + PLAYER_NAME;
		}
	}

	private void Update()
	{
		if (Time.frameCount % 10 != 0)
		{
			return;
		}
		if (GAME_MANAGER.IN_WATER || (GAME_MANAGER.IN_RAIN & !GAME_MANAGER.IN_AIR))
		{
			if (((RCC_CarControllerV3.SPEED > 10f) & GAME_MANAGER.IN_WATER) || ((RCC_CarControllerV3.SPEED > 30f) & GAME_MANAGER.IN_RAIN))
			{
				if (GAME_MANAGER.IN_RAIN)
				{
					WATERSOURCE.gameObject.SetActive(value: false);
					SPLASH_FX[1].startSize = 1f;
					SPLASH_FX[2].startSize = 1f;
					SPLASH_FX[3].startSize = 1f;
					SPLASH_FX[4].startSize = 1f;
				}
				if (GAME_MANAGER.IN_WATER)
				{
					WATERSOURCE.gameObject.SetActive(value: true);
					WATERSOURCE.volume = 0.3f;
					SPLASH_FX[0].startSize = 2f;
					SPLASH_FX[1].startSize = 2f;
					SPLASH_FX[2].startSize = 2f;
					SPLASH_FX[3].startSize = 2f;
					SPLASH_FX[4].startSize = 2f;
					if (RCC_CarControllerV3.DIRECT != -1)
					{
						SPLASH_FX[0].gameObject.transform.localPosition = new Vector3(0f, -1f, RCC_CarControllerV3.SPEED / 9f);
					}
					else
					{
						SPLASH_FX[0].gameObject.transform.localPosition = new Vector3(0f, -1f, -9f);
					}
				}
				else
				{
					SPLASH_FX[0].gameObject.transform.localPosition = new Vector3(0f, -10000f, -9f);
				}
				if (!GAME_MANAGER.IN_DEEP_WATER)
				{
					if (SPLASH_FX[1].isStopped)
					{
						SPLASH_FX[0].Play();
						SPLASH_FX[1].Play();
						SPLASH_FX[2].Play();
						SPLASH_FX[3].Play();
						SPLASH_FX[4].Play();
					}
				}
				else
				{
					SPLASH_FX[0].Stop();
				}
				WATERSOURCE.enabled = true;
			}
			else
			{
				SPLASH_FX[0].Stop();
				SPLASH_FX[1].Stop();
				SPLASH_FX[2].Stop();
				SPLASH_FX[3].Stop();
				SPLASH_FX[4].Stop();
				WATERSOURCE.enabled = false;
			}
		}
		else
		{
			SPLASH_FX[0].Stop();
			SPLASH_FX[1].Stop();
			SPLASH_FX[2].Stop();
			SPLASH_FX[3].Stop();
			SPLASH_FX[4].Stop();
			WATERSOURCE.enabled = false;
		}
	}
}
