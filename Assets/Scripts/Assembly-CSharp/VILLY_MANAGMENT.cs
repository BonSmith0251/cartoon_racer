using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class VILLY_MANAGMENT : MonoBehaviour
{
	public Image FILL;

	public GameObject TUTORIAL;

	public GameObject AWARD;

	public Text AWARD_TXT;

	public GameObject NEW_REC;

	public GameObject FINISH_UI;

	public Text RECORD_TXT_;

	public Text SCORE_TXT_;

	public Animator BIRD_ANIM;

	public Material SKY_DAY;

	public CameraFilterPack_Color_GrayScale GRAY;

	public GameObject BIRD;

	public GameObject START_OBJ;

	public GameObject[] MAP_PREFAB;

	public GameObject COINS_PREFAB;

	public GameObject[] AIRPLANE_PREFAB;

	public GameObject[] CAR_PREFAB;

	public GameObject BOMB_PREFAB;

	public GameObject RING_PREFAB;

	public Image START_IMG;

	public Image START_IMG2;

	public Image START_IMG3;

	public Sprite SPR_START1;

	public Sprite SPR_START2;

	public Sprite SPR_START3;

	public AudioClip SIGNAL_1;

	public AudioClip SIGNAL_2;

	public AudioClip FAILE;

	public Text SCORE_TXT;

	public Text MONEY_TXT;

	public static float NEXT_X;

	public static bool NEXT_TILE_;

	public static bool END_GAME;

	public static bool PIKCIP_MONEY;

	private float gray_scale;

	private float UP_force;

	private float Game_Time;

	private float start_timer;

	private int start_count;

	private float sky_rotate;

	public static float bird_rotate;

	private float score_;

	private float airplane_timer;

	private float airplane_timer2;

	private float airplane_timer3;

	private float airplane_timer4;

	private int SCORE;

	private float COINS_TIMER;

	private int MONEY;

	private int ENEMY_;

	private int BEST_SCORE;

	private float POLOSA_FILL;

	private int AWARD_MULT;

	private int AWARD_;

	public static float RING_POWER;

	private float scale;

	public GameObject RING_OBJ;

	public Image RING_FILL;

	public GameObject PAUSE_UI;

	public GameObject RESTART_UI;

	public GameObject QUIT_UI;

	public void OPEN_PAUSE()
	{
		AudioListener.volume = 0f;
		if (!START_OBJ.activeInHierarchy)
		{
			scale = Time.timeScale;
			Time.timeScale = 0f;
			if (!END_GAME)
			{
				GRAY._Fade = 1f;
			}
			PAUSE_UI.SetActive(value: true);
		}
	}

	public void CLOSE_PAUSE()
	{
		AudioListener.volume = ES2.Load<float>("MAIN_VOLUME");
		Time.timeScale = scale;
		PAUSE_UI.SetActive(value: false);
		if (!END_GAME)
		{
			GRAY._Fade = 0f;
		}
	}

	public void OPEN_RESTART()
	{
		RESTART_UI.SetActive(value: true);
	}

	public void OPEN_QUIT()
	{
		QUIT_UI.SetActive(value: true);
	}

	public void CLOSE_RESTART()
	{
		RESTART_UI.SetActive(value: false);
	}

	public void CLOSE_QUIT()
	{
		QUIT_UI.SetActive(value: false);
	}

	public void ACCEPT_RESTART()
	{
		PAUSE_UI.SetActive(value: false);
		Time.timeScale = 1f;
		Application.LoadLevel(Application.loadedLevel);
	}

	public void ACCEPT_QUIT()
	{
		PAUSE_UI.SetActive(value: false);
		Time.timeScale = 1f;
		Application.LoadLevel(0);
	}

	public void CLOSE_TUT()
	{
		TUTORIAL.SetActive(value: false);
	}

	private void Start()
	{
		AWARD_MULT = 1;
		AWARD_ = 0;
		END_GAME = false;
		NEXT_TILE_ = false;
		NEXT_X = 0f;
		gray_scale = 0f;
		Game_Time = 0f;
		start_count = 0;
		start_timer = 0f;
		bird_rotate = 0f;
		SCORE = 0;
		COINS_TIMER = 0f;
		PIKCIP_MONEY = false;
		POLOSA_FILL = 0f;
		RING_POWER = 0f;
		BIRD.transform.localPosition = new Vector3(-9.5f, 1.2f, 20.22f);
		BIRD_ANIM.Play("Anim 1");
		BIRD_ANIM.speed = 1f;
		MONEY = ES2.Load<int>("PLAYER_MONEY");
		MONEY_TXT.text = string.Empty + MONEY;
		SCORE_TXT.text = "0";
		BEST_SCORE = ES2.Load<int>("BEST_SCORE");
		FILL.fillAmount = 1f;
		RING_FILL.fillAmount = 0f;
		RING_OBJ.SetActive(value: false);
		AWARD.SetActive(value: false);
		if (ES2.Load<int>("VILLY_TUTORIAL") == 0)
		{
			TUTORIAL.SetActive(value: true);
			ES2.Save(1, "VILLY_TUTORIAL");
			GameObject[] array = GameObject.FindGameObjectsWithTag("COIN2");
			GameObject[] array2 = array;
			foreach (GameObject obj in array2)
			{
				Object.Destroy(obj);
			}
		}
	}

	public void RESTART()
	{
		ES2.Save(SCORE, "CUR_SCORE");
		ES2.Save(MONEY, "PLAYER_MONEY");
		Application.LoadLevel(Application.loadedLevel);
	}

	public void QUIT()
	{
		ES2.Save(SCORE, "CUR_SCORE");
		ES2.Save(MONEY, "PLAYER_MONEY");
		Application.LoadLevel(0);
	}

	public void ROTATE()
	{
		if ((Game_Time > 2f) & (bird_rotate == 0f))
		{
			BIRD_ANIM.Play("Anim 3");
			bird_rotate = 1.2f;
		}
	}

	public void ADD_POWER()
	{
		RING_FILL.fillAmount = RING_POWER;
	}

	private IEnumerator CLOSE_AWARD()
	{
		yield return new WaitForSecondsRealtime(5f);
		AWARD.SetActive(value: false);
	}

	private void Update()
	{
		if (!END_GAME)
		{
			if (RING_POWER > 0.99f)
			{
				AWARD.SetActive(value: true);
				AWARD_ += 25 * AWARD_MULT;
				AWARD_TXT.text = "+" + AWARD_;
				MONEY += AWARD_;
				MONEY_TXT.text = string.Empty + MONEY;
				AWARD_MULT++;
				RING_FILL.fillAmount = 0f;
				RING_POWER = 0f;
				StartCoroutine(CLOSE_AWARD());
			}
			if (PIKCIP_MONEY)
			{
				MONEY++;
				PIKCIP_MONEY = false;
				MONEY_TXT.text = string.Empty + MONEY;
			}
			if (bird_rotate > 0f)
			{
				FILL.fillAmount = bird_rotate;
				bird_rotate -= Time.deltaTime;
				if (bird_rotate < 0.01f)
				{
					FILL.fillAmount = 1f;
					BIRD_ANIM.Play("Anim 1");
					bird_rotate = 0f;
				}
			}
			sky_rotate += Time.deltaTime / 1f;
			SKY_DAY.SetFloat("_Rotation", sky_rotate);
			if (start_count > 1)
			{
				Game_Time += Time.deltaTime;
				if (Game_Time > 2f)
				{
					RING_OBJ.SetActive(value: true);
					if (Time.timeScale < 2f)
					{
						Time.timeScale += Time.deltaTime / 800f;
					}
					score_ += Time.deltaTime;
					if (score_ > 1f)
					{
						SCORE++;
						SCORE_TXT.text = string.Empty + SCORE;
						score_ = 0f;
					}
					COINS_TIMER += Time.deltaTime;
					if (COINS_TIMER > 5f)
					{
						GameObject gameObject = Object.Instantiate(COINS_PREFAB, new Vector3(BIRD.transform.position.x - 20f, Random.Range(22f, 35f), 373.5f), base.transform.rotation);
						COINS_TIMER = 0f;
					}
					airplane_timer += Time.deltaTime;
					airplane_timer2 += Time.deltaTime;
					airplane_timer3 += Time.deltaTime;
					airplane_timer4 += Time.deltaTime;
					if (airplane_timer > 6f)
					{
						GameObject gameObject2 = Object.Instantiate(AIRPLANE_PREFAB[Random.Range(0, AIRPLANE_PREFAB.Length)], new Vector3(BIRD.transform.position.x - 20f, Random.Range(26f, 38f), 275.2f), base.transform.rotation);
						airplane_timer = 0f;
					}
					if (airplane_timer3 > 15f)
					{
						GameObject gameObject3 = Object.Instantiate(BOMB_PREFAB, new Vector3(BIRD.transform.position.x - 80f, Random.Range(38, 45), 276f), base.transform.rotation);
						airplane_timer3 = 0f;
					}
					if (airplane_timer4 > 8f)
					{
						GameObject gameObject4 = Object.Instantiate(RING_PREFAB, new Vector3(BIRD.transform.position.x - 80f, Random.Range(36, 43), 276f), RING_PREFAB.transform.rotation);
						airplane_timer4 = 0f;
					}
					if (airplane_timer2 > 10f)
					{
						if (Random.Range(0, 2) == 0)
						{
							GameObject gameObject5 = Object.Instantiate(CAR_PREFAB[Random.Range(0, CAR_PREFAB.Length)], new Vector3(BIRD.transform.position.x - 50f, 32.52f, 273.28f), CAR_PREFAB[0].transform.rotation);
						}
						else
						{
							GameObject gameObject6 = Object.Instantiate(CAR_PREFAB[Random.Range(0, CAR_PREFAB.Length)], new Vector3(BIRD.transform.position.x - 50f, 32.52f, 278.34f), CAR_PREFAB[0].transform.rotation);
						}
						airplane_timer2 = 0f;
					}
				}
			}
			if (BIRD.transform.localPosition.y > 9.8f)
			{
				BIRD.transform.localPosition = new Vector3(BIRD.transform.localPosition.x, 9.8f, 20.22f);
				UP_force = 0f;
				BIRD_ANIM.Play("Anim 1");
				BIRD_ANIM.speed = 1f;
			}
			if (UP_force > 0f)
			{
				BIRD.transform.Translate(Vector3.up * Time.deltaTime * 18f);
				UP_force -= Time.deltaTime * 4f;
				if (UP_force < 0.01f)
				{
					BIRD_ANIM.Play("Anim 1");
					BIRD_ANIM.speed = 1f;
					UP_force = 0f;
				}
			}
			else
			{
				BIRD.GetComponent<AudioSource>().mute = true;
			}
			if ((Input.GetMouseButtonUp(0) & (BIRD.transform.localPosition.y < 9f) & (Game_Time > 2f) & (bird_rotate == 0f)) && !EventSystem.current.IsPointerOverGameObject())
			{
				BIRD.GetComponent<AudioSource>().mute = false;
				BIRD.GetComponent<AudioSource>().Play();
				UP_force = 1f;
				BIRD_ANIM.Play("Anim 2");
				BIRD_ANIM.speed = 2f;
			}
			if (Input.GetMouseButtonUp(1) & !Input.GetMouseButtonUp(0) & (BIRD.transform.localPosition.y < 9f) & (Game_Time > 2f) & (bird_rotate < 0.5f))
			{
				UP_force = 0f;
				if (!EventSystem.current.IsPointerOverGameObject())
				{
					ROTATE();
				}
			}
			if (BIRD.transform.localPosition.y > -5.5f)
			{
				if ((Game_Time > 2f) & (UP_force < 0.5f) & (bird_rotate == 0f))
				{
					BIRD.transform.Translate(Vector3.down * Time.deltaTime * 6f);
				}
			}
			else
			{
				AudioSource.PlayClipAtPoint(FAILE, Camera.main.transform.position);
				END_GAME = true;
				base.gameObject.GetComponent<AudioSource>().enabled = false;
				BIRD.GetComponent<Animator>().enabled = false;
				if (BIRD.GetComponent<Rigidbody>() == null)
				{
					BIRD.AddComponent<Rigidbody>();
				}
				Time.timeScale = 1f;
				BIRD.GetComponent<Rigidbody>().mass = 3f;
				BIRD.GetComponent<Rigidbody>().interpolation = RigidbodyInterpolation.Extrapolate;
				BIRD.GetComponent<Rigidbody>().AddForceAtPosition(Vector3.left * 3000f, BIRD.transform.position);
				BIRD.GetComponent<Rigidbody>().AddForceAtPosition(Vector3.down * 1000f, BIRD.transform.position);
				StartCoroutine(DISABLE_());
			}
		}
		else
		{
			RING_OBJ.SetActive(value: false);
			if (gray_scale < 1f)
			{
				gray_scale += Time.deltaTime;
				GRAY._Fade = gray_scale;
			}
		}
		if (NEXT_TILE_)
		{
			GameObject gameObject7 = Object.Instantiate(MAP_PREFAB[Random.Range(0, MAP_PREFAB.Length)], new Vector3(NEXT_X - 302f, -6.885864f, 409.68f), base.transform.rotation);
			gameObject7.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
			NEXT_TILE_ = false;
		}
		if (!((start_count < 5) & !TUTORIAL.activeInHierarchy))
		{
			return;
		}
		start_timer += Time.deltaTime;
		if ((start_timer > 0.15f) & (start_count < 4))
		{
			START_OBJ.SetActive(value: true);
		}
		if (start_timer > 1f)
		{
			start_count++;
			start_timer = 0f;
			if (start_count == 1)
			{
				START_IMG.color = new Color(1f, 1f, 1f, 1f);
				START_IMG2.color = new Color(1f, 1f, 1f, 1f);
				START_IMG3.color = new Color(1f, 1f, 1f, 1f);
				START_IMG.sprite = SPR_START1;
				START_IMG2.sprite = SPR_START1;
				START_IMG3.sprite = SPR_START1;
				AudioSource.PlayClipAtPoint(SIGNAL_1, Camera.main.transform.position);
			}
			if (start_count == 2)
			{
				START_IMG.sprite = SPR_START2;
				START_IMG2.sprite = SPR_START2;
				START_IMG3.sprite = SPR_START2;
				AudioSource.PlayClipAtPoint(SIGNAL_1, Camera.main.transform.position);
			}
			if (start_count == 3)
			{
				START_IMG.sprite = SPR_START3;
				START_IMG2.sprite = SPR_START3;
				START_IMG3.sprite = SPR_START3;
				AudioSource.PlayClipAtPoint(SIGNAL_2, Camera.main.transform.position);
			}
			if (start_count == 4)
			{
				base.gameObject.GetComponent<AudioSource>().volume = ES2.Load<float>("MUSIC_VOLUME");
				base.gameObject.GetComponent<AudioSource>().enabled = true;
				START_OBJ.SetActive(value: false);
			}
		}
	}

	public void END_GAME_()
	{
		Time.timeScale = 1f;
		AudioSource.PlayClipAtPoint(FAILE, Camera.main.transform.position);
		END_GAME = true;
		base.gameObject.GetComponent<AudioSource>().enabled = false;
		BIRD.GetComponent<Animator>().enabled = false;
		if (BIRD.GetComponent<Rigidbody>() == null)
		{
			BIRD.AddComponent<Rigidbody>();
		}
		BIRD.GetComponent<Rigidbody>().mass = 3f;
		BIRD.GetComponent<Rigidbody>().interpolation = RigidbodyInterpolation.Extrapolate;
		BIRD.GetComponent<Rigidbody>().AddForceAtPosition(Vector3.left * 1000f, BIRD.transform.position);
		BIRD.GetComponent<Rigidbody>().AddForceAtPosition(Vector3.down * 1000f, BIRD.transform.position);
		StartCoroutine(DISABLE_());
	}

	private IEnumerator DISABLE_()
	{
		yield return new WaitForSecondsRealtime(1f);
		BIRD.GetComponent<Rigidbody>().freezeRotation = true;
		FINISH_UI.SetActive(value: true);
		SCORE_TXT_.text = string.Empty + SCORE;
		RECORD_TXT_.text = string.Empty + BEST_SCORE;
		if (SCORE > BEST_SCORE)
		{
			NEW_REC.SetActive(value: true);
			ES2.Save(SCORE, "BEST_SCORE");
		}
		else
		{
			NEW_REC.SetActive(value: false);
		}
	}
}
