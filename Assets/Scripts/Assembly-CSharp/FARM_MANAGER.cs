using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FARM_MANAGER : MonoBehaviour
{
	public GameObject WARN_SEED;

	public GameObject WARN_WATER;

	public GameObject BYED_FARM;

	public GameObject MINUS_UI;

	public GameObject WATER_UI;

	public GameObject LOCKED_UI;

	public Text COST_TXT;

	public Button BUY_BUTTON;

	public Sprite BUTTON_OFF;

	public Sprite BUTTON_ON;

	public Sprite BUTTONBUY_OFF;

	public Sprite BUTTONBUY_ON;

	public Button WATER_ADD;

	public Image WATER_LEVEL;

	public AudioClip BUY_SND;

	public AudioClip NEXT_SND;

	public AudioClip WATER_SND;

	public AudioClip CLEAN_SND;

	public AudioClip SELL_SND;

	public AudioClip PLANT_SND;

	public GameObject FARMCAMERA;

	public GameObject PLANT_SELL_FX;

	public GameObject PLANT_FX;

	public GameObject PLANT_OFF_FX;

	public GameObject INFO_UI;

	public Text TIME_TXT;

	public GameObject SEED_OFF;

	public GameObject SEED_LOW;

	public GameObject SEED_MED;

	public GameObject SEED_HIGH;

	public GameObject SEED_MAX;

	public GameObject FIELD_1_OBJ;

	public GameObject FIELD_2_OBJ;

	public GameObject FIELD_3_OBJ;

	public GameObject[] FIELD_1_SECTORS;

	public GameObject[] FIELD_2_SECTORS;

	public GameObject[] FIELD_3_SECTORS;

	private RaycastHit hit;

	public Text CURRENT_MONEY_TXT;

	public Text CURRENT_SEED_TXT;

	private int CURRENT_MONEY;

	private int CURRENT_SEED;

	private float CURRENT_WATER;

	private int CURRENT_FIELD;

	private float UI_Timer;

	private float BUY_TIMER;

	private string string1;

	private string string2;

	private int F_1;

	private int F_2;

	private int F_3;

	public void CLOSE_WARN()
	{
		AudioSource.PlayClipAtPoint(NEXT_SND, FARMCAMERA.transform.position, 0.8f);
		WARN_SEED.SetActive(value: false);
		WARN_WATER.SetActive(value: false);
	}

	public void CLOSE_BYED()
	{
		AudioSource.PlayClipAtPoint(NEXT_SND, FARMCAMERA.transform.position, 0.8f);
		BYED_FARM.SetActive(value: false);
	}

	public void BUY_FIELD()
	{
		BUY_TIMER = 2f;
		AudioSource.PlayClipAtPoint(BUY_SND, FARMCAMERA.transform.position, 0.8f);
		if ((CURRENT_FIELD == 1) & (F_1 == 0))
		{
			CURRENT_MONEY -= 1000;
			ES2.Save(CURRENT_MONEY, "PLAYER_MONEY");
			CURRENT_MONEY_TXT.text = string.Empty + CURRENT_MONEY;
			ES2.Save(1, "FIELD1");
			F_1 = 1;
			LOCKED_UI.SetActive(value: false);
			WATER_UI.SetActive(value: true);
			BYED_FARM.SetActive(value: true);
		}
		else if ((CURRENT_FIELD == 2) & (F_2 == 0))
		{
			CURRENT_MONEY -= 7000;
			ES2.Save(CURRENT_MONEY, "PLAYER_MONEY");
			CURRENT_MONEY_TXT.text = string.Empty + CURRENT_MONEY;
			ES2.Save(1, "FIELD2");
			F_2 = 1;
			LOCKED_UI.SetActive(value: false);
			WATER_UI.SetActive(value: true);
			BYED_FARM.SetActive(value: true);
		}
		else if ((CURRENT_FIELD == 3) & (F_3 == 0))
		{
			CURRENT_MONEY -= 12000;
			ES2.Save(CURRENT_MONEY, "PLAYER_MONEY");
			CURRENT_MONEY_TXT.text = string.Empty + CURRENT_MONEY;
			ES2.Save(1, "FIELD3");
			F_3 = 1;
			LOCKED_UI.SetActive(value: false);
			WATER_UI.SetActive(value: true);
			BYED_FARM.SetActive(value: true);
		}
	}

	public void NEXT_FIELD()
	{
		AudioSource.PlayClipAtPoint(NEXT_SND, FARMCAMERA.transform.position, 0.8f);
		CURRENT_FIELD++;
		if (CURRENT_FIELD > 3)
		{
			CURRENT_FIELD = 1;
		}
		if (CURRENT_FIELD == 1)
		{
			CHECK_FIELD(1);
			FARMCAMERA.transform.position = new Vector3(199.6f, 62.6f, 168.5f);
			FARMCAMERA.transform.rotation = Quaternion.Euler(54.8f, -90f, 0f);
			FIELD_2_OBJ.SetActive(value: false);
			FIELD_3_OBJ.SetActive(value: false);
			FIELD_1_OBJ.SetActive(value: true);
			if (F_1 == 0)
			{
				WATER_UI.SetActive(value: false);
				LOCKED_UI.SetActive(value: true);
				COST_TXT.text = "1000";
				if (CURRENT_MONEY > 999)
				{
					BUY_BUTTON.GetComponent<Image>().sprite = BUTTONBUY_ON;
					BUY_BUTTON.interactable = true;
				}
				else
				{
					BUY_BUTTON.GetComponent<Image>().sprite = BUTTONBUY_OFF;
					BUY_BUTTON.interactable = false;
				}
			}
			else
			{
				WATER_UI.SetActive(value: true);
				LOCKED_UI.SetActive(value: false);
			}
		}
		if (CURRENT_FIELD == 2)
		{
			CHECK_FIELD(2);
			FARMCAMERA.transform.position = new Vector3(210f, 62.6f, 166.5f);
			FARMCAMERA.transform.rotation = Quaternion.Euler(54.8f, 90f, 0f);
			FIELD_1_OBJ.SetActive(value: false);
			FIELD_3_OBJ.SetActive(value: false);
			FIELD_2_OBJ.SetActive(value: true);
			if (F_2 == 0)
			{
				WATER_UI.SetActive(value: false);
				LOCKED_UI.SetActive(value: true);
				COST_TXT.text = "7000";
				if (CURRENT_MONEY > 6999)
				{
					BUY_BUTTON.GetComponent<Image>().sprite = BUTTONBUY_ON;
					BUY_BUTTON.interactable = true;
				}
				else
				{
					BUY_BUTTON.GetComponent<Image>().sprite = BUTTONBUY_OFF;
					BUY_BUTTON.interactable = false;
				}
			}
			else
			{
				WATER_UI.SetActive(value: true);
				LOCKED_UI.SetActive(value: false);
			}
		}
		if (CURRENT_FIELD != 3)
		{
			return;
		}
		CHECK_FIELD(3);
		FARMCAMERA.transform.position = new Vector3(200.1f, 62.6f, 61.8f);
		FARMCAMERA.transform.rotation = Quaternion.Euler(54.8f, 180f, 0f);
		FIELD_2_OBJ.SetActive(value: false);
		FIELD_1_OBJ.SetActive(value: false);
		FIELD_3_OBJ.SetActive(value: true);
		if (F_3 == 0)
		{
			WATER_UI.SetActive(value: false);
			LOCKED_UI.SetActive(value: true);
			COST_TXT.text = "12000";
			if (CURRENT_MONEY > 11999)
			{
				BUY_BUTTON.GetComponent<Image>().sprite = BUTTONBUY_ON;
				BUY_BUTTON.interactable = true;
			}
			else
			{
				BUY_BUTTON.GetComponent<Image>().sprite = BUTTONBUY_OFF;
				BUY_BUTTON.interactable = false;
			}
		}
		else
		{
			WATER_UI.SetActive(value: true);
			LOCKED_UI.SetActive(value: false);
		}
	}

	public void BACK_FIELD()
	{
		AudioSource.PlayClipAtPoint(NEXT_SND, FARMCAMERA.transform.position, 0.8f);
		CURRENT_FIELD--;
		if (CURRENT_FIELD < 1)
		{
			CURRENT_FIELD = 3;
		}
		if (CURRENT_FIELD == 1)
		{
			CHECK_FIELD(1);
			FARMCAMERA.transform.position = new Vector3(199.6f, 62.6f, 168.5f);
			FARMCAMERA.transform.rotation = Quaternion.Euler(54.8f, -90f, 0f);
			FIELD_2_OBJ.SetActive(value: false);
			FIELD_3_OBJ.SetActive(value: false);
			FIELD_1_OBJ.SetActive(value: true);
			if (F_1 == 0)
			{
				WATER_UI.SetActive(value: false);
				LOCKED_UI.SetActive(value: true);
				COST_TXT.text = "1000";
				if (CURRENT_MONEY > 999)
				{
					BUY_BUTTON.GetComponent<Image>().sprite = BUTTONBUY_ON;
					BUY_BUTTON.interactable = true;
				}
				else
				{
					BUY_BUTTON.GetComponent<Image>().sprite = BUTTONBUY_OFF;
					BUY_BUTTON.interactable = false;
				}
			}
			else
			{
				WATER_UI.SetActive(value: true);
				LOCKED_UI.SetActive(value: false);
			}
		}
		if (CURRENT_FIELD == 2)
		{
			CHECK_FIELD(2);
			FARMCAMERA.transform.position = new Vector3(210f, 62.6f, 166.5f);
			FARMCAMERA.transform.rotation = Quaternion.Euler(54.8f, 90f, 0f);
			FIELD_1_OBJ.SetActive(value: false);
			FIELD_3_OBJ.SetActive(value: false);
			FIELD_2_OBJ.SetActive(value: true);
			if (F_2 == 0)
			{
				WATER_UI.SetActive(value: false);
				LOCKED_UI.SetActive(value: true);
				COST_TXT.text = "7000";
				if (CURRENT_MONEY > 6999)
				{
					BUY_BUTTON.GetComponent<Image>().sprite = BUTTONBUY_ON;
					BUY_BUTTON.interactable = true;
				}
				else
				{
					BUY_BUTTON.GetComponent<Image>().sprite = BUTTONBUY_OFF;
					BUY_BUTTON.interactable = false;
				}
			}
			else
			{
				WATER_UI.SetActive(value: true);
				LOCKED_UI.SetActive(value: false);
			}
		}
		if (CURRENT_FIELD != 3)
		{
			return;
		}
		CHECK_FIELD(3);
		FARMCAMERA.transform.position = new Vector3(200.1f, 62.6f, 61.8f);
		FARMCAMERA.transform.rotation = Quaternion.Euler(54.8f, 180f, 0f);
		FIELD_2_OBJ.SetActive(value: false);
		FIELD_1_OBJ.SetActive(value: false);
		FIELD_3_OBJ.SetActive(value: true);
		if (F_3 == 0)
		{
			WATER_UI.SetActive(value: false);
			LOCKED_UI.SetActive(value: true);
			COST_TXT.text = "12000";
			if (CURRENT_MONEY > 11999)
			{
				BUY_BUTTON.GetComponent<Image>().sprite = BUTTONBUY_ON;
				BUY_BUTTON.interactable = true;
			}
			else
			{
				BUY_BUTTON.GetComponent<Image>().sprite = BUTTONBUY_OFF;
				BUY_BUTTON.interactable = false;
			}
		}
		else
		{
			WATER_UI.SetActive(value: true);
			LOCKED_UI.SetActive(value: false);
		}
	}

	private void OnEnable()
	{
		F_1 = ES2.Load<int>("FIELD1");
		F_2 = ES2.Load<int>("FIELD2");
		F_3 = ES2.Load<int>("FIELD3");
		CURRENT_MONEY = ES2.Load<int>("PLAYER_MONEY");
		CURRENT_SEED = ES2.Load<int>("PLAYER_SEED");
		CURRENT_WATER = ES2.Load<float>("WATER");
		WATER_LEVEL.fillAmount = CURRENT_WATER;
		CURRENT_MONEY_TXT.text = string.Empty + CURRENT_MONEY;
		CURRENT_SEED_TXT.text = string.Empty + CURRENT_SEED;
		FIELD_2_OBJ.SetActive(value: false);
		FIELD_3_OBJ.SetActive(value: false);
		FIELD_1_OBJ.SetActive(value: true);
		FARMCAMERA.transform.position = new Vector3(199.6f, 62.6f, 168.5f);
		FARMCAMERA.transform.rotation = Quaternion.Euler(54.8f, -90f, 0f);
		CURRENT_FIELD = 1;
		if (F_1 == 0)
		{
			WATER_UI.SetActive(value: false);
			LOCKED_UI.SetActive(value: true);
			COST_TXT.text = "1000";
			if (CURRENT_MONEY > 999)
			{
				BUY_BUTTON.GetComponent<Image>().sprite = BUTTONBUY_ON;
				BUY_BUTTON.interactable = true;
			}
			else
			{
				BUY_BUTTON.GetComponent<Image>().sprite = BUTTONBUY_OFF;
				BUY_BUTTON.interactable = false;
			}
		}
		if (CURRENT_WATER < 1f)
		{
			WATER_ADD.interactable = true;
			WATER_ADD.GetComponent<Image>().sprite = BUTTON_ON;
		}
		else
		{
			WATER_ADD.interactable = false;
			WATER_ADD.GetComponent<Image>().sprite = BUTTON_OFF;
		}
		CHECK_FIELD(1);
	}

	public void ADD_WATER_()
	{
		if (CURRENT_MONEY > 9)
		{
			AudioSource.PlayClipAtPoint(WATER_SND, FARMCAMERA.transform.position, 0.8f);
			CURRENT_MONEY -= 10;
			ES2.Save(CURRENT_MONEY, "PLAYER_MONEY");
			CURRENT_MONEY_TXT.text = string.Empty + CURRENT_MONEY;
			CURRENT_WATER += 0.2f;
			WATER_LEVEL.fillAmount = CURRENT_WATER;
			ES2.Save(CURRENT_WATER, "WATER");
			if (CURRENT_WATER < 1f)
			{
				WATER_ADD.interactable = true;
				WATER_ADD.GetComponent<Image>().sprite = BUTTON_ON;
			}
			else
			{
				WATER_ADD.interactable = false;
				WATER_ADD.GetComponent<Image>().sprite = BUTTON_OFF;
			}
		}
	}

	private void Update()
	{
		if (BUY_TIMER > 0f)
		{
			BUY_TIMER -= Time.deltaTime;
			if (BUY_TIMER < 0.01f)
			{
				BUY_TIMER = 0f;
			}
		}
		if (Input.GetMouseButtonUp(0) & (BUY_TIMER == 0f))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (((CURRENT_FIELD == 1) & (F_1 == 1)) && Physics.Raycast(ray, out hit))
			{
				if (hit.collider.name == "SF_OFF_")
				{
					FIELD_1_SECTORS[hit.collider.transform.parent.gameObject.GetComponent<SF_OFF>().INDEX].GetComponent<BoxCollider>().enabled = true;
					FIELD_1_SECTORS[hit.collider.transform.parent.gameObject.GetComponent<SF_OFF>().INDEX].GetComponent<SpriteRenderer>().color = new Color(0f, 1f, 0f, 1f);
					FIELD_1_SECTORS[hit.collider.transform.parent.gameObject.GetComponent<SF_OFF>().INDEX].GetComponent<SECTOR>().FREE = true;
					int iNDEX = FIELD_1_SECTORS[hit.collider.transform.parent.gameObject.GetComponent<SF_OFF>().INDEX].GetComponent<SECTOR>().INDEX;
					string identifier = "F1_S" + iNDEX + "_TIME";
					ES2.Save(string.Empty, identifier);
					GameObject gameObject = UnityEngine.Object.Instantiate(PLANT_OFF_FX, hit.collider.transform.position, base.transform.rotation);
					gameObject.transform.position = new Vector3(hit.collider.transform.position.x, 33f, hit.collider.transform.position.z);
					AudioSource.PlayClipAtPoint(CLEAN_SND, FARMCAMERA.transform.position, 0.8f);
					UnityEngine.Object.Destroy(hit.collider.transform.parent.gameObject);
					return;
				}
				if (EventSystem.current.IsPointerOverGameObject() || hit.collider == null || hit.collider.tag != "SECTOR")
				{
					INFO_UI.SetActive(value: false);
					TIME_TXT.text = null;
					return;
				}
				if (hit.collider.tag == "SECTOR")
				{
					if (hit.collider.GetComponent<SECTOR>().FREE)
					{
						if ((CURRENT_SEED >= 2) & (CURRENT_WATER > 0.19f))
						{
							INFO_UI.SetActive(value: false);
							TIME_TXT.text = null;
							MINUS_UI.SetActive(value: false);
							MINUS_UI.SetActive(value: true);
							MINUS_UI.GetComponent<Animator>().enabled = true;
							MINUS_UI.GetComponent<Animator>().SetBool("PLAY", value: true);
							AudioSource.PlayClipAtPoint(PLANT_SND, FARMCAMERA.transform.position, 0.8f);
							GameObject gameObject2 = UnityEngine.Object.Instantiate(PLANT_FX, hit.collider.transform.position, base.transform.rotation);
							gameObject2.transform.position = new Vector3(hit.collider.transform.position.x, 30.5f, hit.collider.transform.position.z);
							GameObject gameObject3 = UnityEngine.Object.Instantiate(SEED_LOW, hit.collider.transform.position, base.transform.rotation);
							gameObject3.transform.position = new Vector3(hit.collider.transform.position.x, 30.5f, hit.collider.transform.position.z);
							hit.collider.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f, 0f);
							hit.collider.GetComponent<SECTOR>().FREE = false;
							int iNDEX2 = hit.collider.GetComponent<SECTOR>().INDEX;
							string sTR_ = "F1_S" + iNDEX2 + "_TIME";
							ResetNextRewardTime(sTR_);
							CURRENT_SEED -= 2;
							ES2.Save(CURRENT_SEED, "PLAYER_SEED");
							CURRENT_SEED_TXT.text = string.Empty + CURRENT_SEED;
							CURRENT_WATER -= 0.2f;
							WATER_LEVEL.fillAmount = CURRENT_WATER;
							ES2.Save(CURRENT_WATER, "WATER");
							if (CURRENT_WATER < 1f)
							{
								WATER_ADD.interactable = true;
								WATER_ADD.GetComponent<Image>().sprite = BUTTON_ON;
							}
							else
							{
								WATER_ADD.interactable = false;
								WATER_ADD.GetComponent<Image>().sprite = BUTTON_OFF;
							}
						}
						else if (CURRENT_WATER < 0.2f)
						{
							WARN_WATER.SetActive(value: true);
						}
						else if (CURRENT_SEED < 2)
						{
							WARN_SEED.SetActive(value: true);
						}
						return;
					}
					GetNextRewardTime(CURRENT_FIELD, hit.collider.GetComponent<SECTOR>().INDEX);
					TimeSpan timeSpan = GetNextRewardTime(CURRENT_FIELD, hit.collider.GetComponent<SECTOR>().INDEX).Subtract(DateTime.Now);
					if (timeSpan > TimeSpan.Zero)
					{
						INFO_UI.SetActive(value: true);
						TIME_TXT.text = null;
						UI_Timer = 4f;
						TIME_TXT.text = $"{timeSpan.Hours:00}:{timeSpan.Minutes:00}";
						return;
					}
					GameObject[] array = GameObject.FindGameObjectsWithTag("GEAR");
					GameObject[] array2 = array;
					foreach (GameObject gameObject4 in array2)
					{
						if (gameObject4.GetComponent<SF_OFF>().INDEX == hit.collider.GetComponent<SECTOR>().INDEX)
						{
							FIELD_1_SECTORS[gameObject4.GetComponent<SF_OFF>().INDEX].GetComponent<BoxCollider>().enabled = true;
							FIELD_1_SECTORS[gameObject4.GetComponent<SF_OFF>().INDEX].GetComponent<SpriteRenderer>().color = new Color(0f, 1f, 0f, 1f);
							FIELD_1_SECTORS[gameObject4.GetComponent<SF_OFF>().INDEX].GetComponent<SECTOR>().FREE = true;
							GameObject gameObject5 = UnityEngine.Object.Instantiate(PLANT_SELL_FX, hit.collider.transform.position, base.transform.rotation);
							gameObject5.transform.position = new Vector3(hit.collider.transform.position.x, 32f, hit.collider.transform.position.z);
							int iNDEX3 = FIELD_1_SECTORS[gameObject4.GetComponent<SF_OFF>().INDEX].GetComponent<SECTOR>().INDEX;
							string identifier2 = "F1_S" + iNDEX3 + "_TIME";
							ES2.Save(string.Empty, identifier2);
							CURRENT_MONEY += 50;
							ES2.Save(CURRENT_MONEY, "PLAYER_MONEY");
							ES2.Save(ES2.Load<int>("SALE_ALL") + 1, "SALE_ALL");
							CURRENT_MONEY_TXT.text = string.Empty + CURRENT_MONEY;
							UnityEngine.Object.Destroy(gameObject4);
							AudioSource.PlayClipAtPoint(SELL_SND, FARMCAMERA.transform.position, 0.8f);
							break;
						}
					}
					return;
				}
			}
			if (((CURRENT_FIELD == 2) & (F_2 == 1)) && Physics.Raycast(ray, out hit))
			{
				if (hit.collider.name == "SF_OFF_")
				{
					FIELD_2_SECTORS[hit.collider.transform.parent.gameObject.GetComponent<SF_OFF>().INDEX].GetComponent<BoxCollider>().enabled = true;
					FIELD_2_SECTORS[hit.collider.transform.parent.gameObject.GetComponent<SF_OFF>().INDEX].GetComponent<SpriteRenderer>().color = new Color(0f, 1f, 0f, 1f);
					FIELD_2_SECTORS[hit.collider.transform.parent.gameObject.GetComponent<SF_OFF>().INDEX].GetComponent<SECTOR>().FREE = true;
					int iNDEX4 = FIELD_2_SECTORS[hit.collider.transform.parent.gameObject.GetComponent<SF_OFF>().INDEX].GetComponent<SECTOR>().INDEX;
					string identifier3 = "F2_S" + iNDEX4 + "_TIME";
					ES2.Save(string.Empty, identifier3);
					GameObject gameObject6 = UnityEngine.Object.Instantiate(PLANT_OFF_FX, hit.collider.transform.position, base.transform.rotation);
					gameObject6.transform.position = new Vector3(hit.collider.transform.position.x, 33f, hit.collider.transform.position.z);
					AudioSource.PlayClipAtPoint(CLEAN_SND, FARMCAMERA.transform.position, 0.8f);
					UnityEngine.Object.Destroy(hit.collider.transform.parent.gameObject);
					return;
				}
				if (EventSystem.current.IsPointerOverGameObject() || hit.collider == null || hit.collider.tag != "SECTOR")
				{
					INFO_UI.SetActive(value: false);
					TIME_TXT.text = null;
					return;
				}
				if (hit.collider.tag == "SECTOR")
				{
					if (hit.collider.GetComponent<SECTOR>().FREE)
					{
						if ((CURRENT_SEED >= 2) & (CURRENT_WATER > 0.19f))
						{
							INFO_UI.SetActive(value: false);
							TIME_TXT.text = null;
							MINUS_UI.SetActive(value: false);
							MINUS_UI.SetActive(value: true);
							MINUS_UI.GetComponent<Animator>().enabled = true;
							MINUS_UI.GetComponent<Animator>().SetBool("PLAY", value: true);
							AudioSource.PlayClipAtPoint(PLANT_SND, FARMCAMERA.transform.position, 0.8f);
							GameObject gameObject7 = UnityEngine.Object.Instantiate(PLANT_FX, hit.collider.transform.position, base.transform.rotation);
							gameObject7.transform.position = new Vector3(hit.collider.transform.position.x, 30.5f, hit.collider.transform.position.z);
							GameObject gameObject8 = UnityEngine.Object.Instantiate(SEED_LOW, hit.collider.transform.position, base.transform.rotation);
							gameObject8.transform.position = new Vector3(hit.collider.transform.position.x, 30.5f, hit.collider.transform.position.z);
							hit.collider.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f, 0f);
							hit.collider.GetComponent<SECTOR>().FREE = false;
							int iNDEX5 = hit.collider.GetComponent<SECTOR>().INDEX;
							string sTR_2 = "F2_S" + iNDEX5 + "_TIME";
							ResetNextRewardTime(sTR_2);
							CURRENT_SEED -= 2;
							ES2.Save(CURRENT_SEED, "PLAYER_SEED");
							CURRENT_SEED_TXT.text = string.Empty + CURRENT_SEED;
							CURRENT_WATER -= 0.2f;
							WATER_LEVEL.fillAmount = CURRENT_WATER;
							ES2.Save(CURRENT_WATER, "WATER");
							if (CURRENT_WATER < 1f)
							{
								WATER_ADD.interactable = true;
								WATER_ADD.GetComponent<Image>().sprite = BUTTON_ON;
							}
							else
							{
								WATER_ADD.interactable = false;
								WATER_ADD.GetComponent<Image>().sprite = BUTTON_OFF;
							}
						}
						else if (CURRENT_WATER < 0.2f)
						{
							WARN_WATER.SetActive(value: true);
						}
						else if (CURRENT_SEED < 2)
						{
							WARN_SEED.SetActive(value: true);
						}
						return;
					}
					GetNextRewardTime(CURRENT_FIELD, hit.collider.GetComponent<SECTOR>().INDEX);
					TimeSpan timeSpan2 = GetNextRewardTime(CURRENT_FIELD, hit.collider.GetComponent<SECTOR>().INDEX).Subtract(DateTime.Now);
					if (timeSpan2 > TimeSpan.Zero)
					{
						INFO_UI.SetActive(value: true);
						TIME_TXT.text = null;
						UI_Timer = 4f;
						TIME_TXT.text = $"{timeSpan2.Hours:00}:{timeSpan2.Minutes:00}";
						return;
					}
					GameObject[] array3 = GameObject.FindGameObjectsWithTag("GEAR");
					GameObject[] array4 = array3;
					foreach (GameObject gameObject9 in array4)
					{
						if (gameObject9.GetComponent<SF_OFF>().INDEX == hit.collider.GetComponent<SECTOR>().INDEX)
						{
							FIELD_2_SECTORS[gameObject9.GetComponent<SF_OFF>().INDEX].GetComponent<BoxCollider>().enabled = true;
							FIELD_2_SECTORS[gameObject9.GetComponent<SF_OFF>().INDEX].GetComponent<SpriteRenderer>().color = new Color(0f, 1f, 0f, 1f);
							FIELD_2_SECTORS[gameObject9.GetComponent<SF_OFF>().INDEX].GetComponent<SECTOR>().FREE = true;
							GameObject gameObject10 = UnityEngine.Object.Instantiate(PLANT_SELL_FX, hit.collider.transform.position, base.transform.rotation);
							gameObject10.transform.position = new Vector3(hit.collider.transform.position.x, 32f, hit.collider.transform.position.z);
							int iNDEX6 = FIELD_2_SECTORS[gameObject9.GetComponent<SF_OFF>().INDEX].GetComponent<SECTOR>().INDEX;
							string identifier4 = "F2_S" + iNDEX6 + "_TIME";
							ES2.Save(string.Empty, identifier4);
							CURRENT_MONEY += 50;
							ES2.Save(CURRENT_MONEY, "PLAYER_MONEY");
							ES2.Save(ES2.Load<int>("SALE_ALL") + 1, "SALE_ALL");
							CURRENT_MONEY_TXT.text = string.Empty + CURRENT_MONEY;
							UnityEngine.Object.Destroy(gameObject9);
							AudioSource.PlayClipAtPoint(SELL_SND, FARMCAMERA.transform.position, 0.8f);
							break;
						}
					}
					return;
				}
			}
			if (((CURRENT_FIELD == 3) & (F_3 == 1)) && Physics.Raycast(ray, out hit))
			{
				if (hit.collider.name == "SF_OFF_")
				{
					FIELD_3_SECTORS[hit.collider.transform.parent.gameObject.GetComponent<SF_OFF>().INDEX].GetComponent<BoxCollider>().enabled = true;
					FIELD_3_SECTORS[hit.collider.transform.parent.gameObject.GetComponent<SF_OFF>().INDEX].GetComponent<SpriteRenderer>().color = new Color(0f, 1f, 0f, 1f);
					FIELD_3_SECTORS[hit.collider.transform.parent.gameObject.GetComponent<SF_OFF>().INDEX].GetComponent<SECTOR>().FREE = true;
					int iNDEX7 = FIELD_3_SECTORS[hit.collider.transform.parent.gameObject.GetComponent<SF_OFF>().INDEX].GetComponent<SECTOR>().INDEX;
					string identifier5 = "F3_S" + iNDEX7 + "_TIME";
					ES2.Save(string.Empty, identifier5);
					GameObject gameObject11 = UnityEngine.Object.Instantiate(PLANT_OFF_FX, hit.collider.transform.position, base.transform.rotation);
					gameObject11.transform.position = new Vector3(hit.collider.transform.position.x, 33f, hit.collider.transform.position.z);
					AudioSource.PlayClipAtPoint(CLEAN_SND, FARMCAMERA.transform.position, 0.8f);
					UnityEngine.Object.Destroy(hit.collider.transform.parent.gameObject);
					return;
				}
				if (EventSystem.current.IsPointerOverGameObject() || hit.collider == null || hit.collider.tag != "SECTOR")
				{
					INFO_UI.SetActive(value: false);
					TIME_TXT.text = null;
					return;
				}
				if (hit.collider.tag == "SECTOR")
				{
					if (hit.collider.GetComponent<SECTOR>().FREE)
					{
						if ((CURRENT_SEED >= 2) & (CURRENT_WATER > 0.19f))
						{
							INFO_UI.SetActive(value: false);
							TIME_TXT.text = null;
							MINUS_UI.SetActive(value: false);
							MINUS_UI.SetActive(value: true);
							MINUS_UI.GetComponent<Animator>().enabled = true;
							MINUS_UI.GetComponent<Animator>().SetBool("PLAY", value: true);
							AudioSource.PlayClipAtPoint(PLANT_SND, FARMCAMERA.transform.position, 0.8f);
							GameObject gameObject12 = UnityEngine.Object.Instantiate(PLANT_FX, hit.collider.transform.position, base.transform.rotation);
							gameObject12.transform.position = new Vector3(hit.collider.transform.position.x, 30.5f, hit.collider.transform.position.z);
							GameObject gameObject13 = UnityEngine.Object.Instantiate(SEED_LOW, hit.collider.transform.position, base.transform.rotation);
							gameObject13.transform.position = new Vector3(hit.collider.transform.position.x, 30.5f, hit.collider.transform.position.z);
							hit.collider.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f, 0f);
							hit.collider.GetComponent<SECTOR>().FREE = false;
							int iNDEX8 = hit.collider.GetComponent<SECTOR>().INDEX;
							string sTR_3 = "F3_S" + iNDEX8 + "_TIME";
							ResetNextRewardTime(sTR_3);
							CURRENT_SEED -= 2;
							ES2.Save(CURRENT_SEED, "PLAYER_SEED");
							CURRENT_SEED_TXT.text = string.Empty + CURRENT_SEED;
							CURRENT_WATER -= 0.2f;
							WATER_LEVEL.fillAmount = CURRENT_WATER;
							ES2.Save(CURRENT_WATER, "WATER");
							if (CURRENT_WATER < 1f)
							{
								WATER_ADD.interactable = true;
								WATER_ADD.GetComponent<Image>().sprite = BUTTON_ON;
							}
							else
							{
								WATER_ADD.interactable = false;
								WATER_ADD.GetComponent<Image>().sprite = BUTTON_OFF;
							}
						}
						else if (CURRENT_WATER < 0.2f)
						{
							WARN_WATER.SetActive(value: true);
						}
						else if (CURRENT_SEED < 2)
						{
							WARN_SEED.SetActive(value: true);
						}
						return;
					}
					GetNextRewardTime(CURRENT_FIELD, hit.collider.GetComponent<SECTOR>().INDEX);
					TimeSpan timeSpan3 = GetNextRewardTime(CURRENT_FIELD, hit.collider.GetComponent<SECTOR>().INDEX).Subtract(DateTime.Now);
					if (timeSpan3 > TimeSpan.Zero)
					{
						INFO_UI.SetActive(value: true);
						TIME_TXT.text = null;
						UI_Timer = 4f;
						TIME_TXT.text = $"{timeSpan3.Hours:00}:{timeSpan3.Minutes:00}";
						return;
					}
					GameObject[] array5 = GameObject.FindGameObjectsWithTag("GEAR");
					GameObject[] array6 = array5;
					foreach (GameObject gameObject14 in array6)
					{
						if (gameObject14.GetComponent<SF_OFF>().INDEX == hit.collider.GetComponent<SECTOR>().INDEX)
						{
							FIELD_3_SECTORS[gameObject14.GetComponent<SF_OFF>().INDEX].GetComponent<BoxCollider>().enabled = true;
							FIELD_3_SECTORS[gameObject14.GetComponent<SF_OFF>().INDEX].GetComponent<SpriteRenderer>().color = new Color(0f, 1f, 0f, 1f);
							FIELD_3_SECTORS[gameObject14.GetComponent<SF_OFF>().INDEX].GetComponent<SECTOR>().FREE = true;
							GameObject gameObject15 = UnityEngine.Object.Instantiate(PLANT_SELL_FX, hit.collider.transform.position, base.transform.rotation);
							gameObject15.transform.position = new Vector3(hit.collider.transform.position.x, 32f, hit.collider.transform.position.z);
							int iNDEX9 = FIELD_3_SECTORS[gameObject14.GetComponent<SF_OFF>().INDEX].GetComponent<SECTOR>().INDEX;
							string identifier6 = "F3_S" + iNDEX9 + "_TIME";
							ES2.Save(string.Empty, identifier6);
							CURRENT_MONEY += 50;
							ES2.Save(CURRENT_MONEY, "PLAYER_MONEY");
							ES2.Save(ES2.Load<int>("SALE_ALL") + 1, "SALE_ALL");
							CURRENT_MONEY_TXT.text = string.Empty + CURRENT_MONEY;
							UnityEngine.Object.Destroy(gameObject14);
							AudioSource.PlayClipAtPoint(SELL_SND, FARMCAMERA.transform.position, 0.8f);
							break;
						}
					}
					return;
				}
			}
		}
		if (UI_Timer > 0f)
		{
			UI_Timer -= Time.deltaTime;
			if (UI_Timer < 0.1f)
			{
				INFO_UI.SetActive(value: false);
				UI_Timer = 0f;
			}
		}
	}

	public void ResetNextRewardTime(string STR_)
	{
		DateTime time = DateTime.Now.Add(new TimeSpan(24, 0, 0));
		StoreNextRewardTime(time, STR_);
	}

	private void StoreNextRewardTime(DateTime time, string STR)
	{
		ES2.Save(time.ToBinary().ToString(), STR);
	}

	private DateTime GetNextRewardTime(int FIELD, int INDEX)
	{
		string identifier = "F" + FIELD + "_S" + INDEX + "_TIME";
		string value = ES2.Load<string>(identifier);
		if (!string.IsNullOrEmpty(value))
		{
			return DateTime.FromBinary(Convert.ToInt64(value));
		}
		return DateTime.Now;
	}

	public void CHECK_FIELD(int field)
	{
		GameObject[] array = GameObject.FindGameObjectsWithTag("SEED");
		GameObject[] array2 = array;
		foreach (GameObject obj in array2)
		{
			UnityEngine.Object.Destroy(obj);
		}
		if (field == 1)
		{
			for (int j = 0; j < FIELD_1_SECTORS.Length; j++)
			{
				int iNDEX = FIELD_1_SECTORS[j].GetComponent<SECTOR>().INDEX;
				string identifier = "F1_S" + iNDEX + "_TIME";
				string text = ES2.Load<string>(identifier);
				if (text == string.Empty)
				{
					FIELD_1_SECTORS[j].GetComponent<SpriteRenderer>().color = new Color(0f, 1f, 0f, 1f);
					FIELD_1_SECTORS[j].GetComponent<SECTOR>().FREE = true;
					continue;
				}
				FIELD_1_SECTORS[j].GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f, 0f);
				FIELD_1_SECTORS[j].GetComponent<SECTOR>().FREE = false;
				if (GetNextRewardTime(CURRENT_FIELD, j).Subtract(DateTime.Now) <= TimeSpan.Zero)
				{
					string1 = DateTime.FromBinary(Convert.ToInt64(text)).ToShortDateString();
					string2 = DateTime.Now.ToShortDateString();
					if (string1 != string2)
					{
						FIELD_1_SECTORS[j].GetComponent<BoxCollider>().enabled = false;
						GameObject gameObject = UnityEngine.Object.Instantiate(SEED_OFF, FIELD_1_SECTORS[j].transform.position, base.transform.rotation);
						gameObject.transform.position = new Vector3(FIELD_1_SECTORS[j].transform.position.x, 30.5f, FIELD_1_SECTORS[j].transform.position.z);
						gameObject.transform.rotation = Quaternion.Euler(0f, -90f, 0f);
						gameObject.GetComponent<SF_OFF>().INDEX = j;
					}
					else
					{
						GameObject gameObject2 = UnityEngine.Object.Instantiate(SEED_MAX, FIELD_1_SECTORS[j].transform.position, base.transform.rotation);
						gameObject2.transform.position = new Vector3(FIELD_1_SECTORS[j].transform.position.x, 30.5f, FIELD_1_SECTORS[j].transform.position.z);
						gameObject2.transform.rotation = Quaternion.Euler(0f, -90f, 0f);
						gameObject2.GetComponent<SF_OFF>().INDEX = j;
					}
					continue;
				}
				GetNextRewardTime(CURRENT_FIELD, FIELD_1_SECTORS[j].GetComponent<SECTOR>().INDEX);
				TimeSpan timeSpan = GetNextRewardTime(CURRENT_FIELD, FIELD_1_SECTORS[j].GetComponent<SECTOR>().INDEX).Subtract(DateTime.Now);
				if ((timeSpan.Hours < 24) & (timeSpan.Hours > 15))
				{
					GameObject gameObject3 = UnityEngine.Object.Instantiate(SEED_LOW, FIELD_1_SECTORS[j].transform.position, base.transform.rotation);
					gameObject3.transform.position = new Vector3(FIELD_1_SECTORS[j].transform.position.x, 30.5f, FIELD_1_SECTORS[j].transform.position.z);
					gameObject3.transform.rotation = Quaternion.Euler(0f, -90f, 0f);
				}
				if ((timeSpan.Hours < 16) & (timeSpan.Hours > 7))
				{
					GameObject gameObject4 = UnityEngine.Object.Instantiate(SEED_MED, FIELD_1_SECTORS[j].transform.position, base.transform.rotation);
					gameObject4.transform.position = new Vector3(FIELD_1_SECTORS[j].transform.position.x, 30.5f, FIELD_1_SECTORS[j].transform.position.z);
					gameObject4.transform.rotation = Quaternion.Euler(0f, -90f, 0f);
				}
				if ((timeSpan.Hours < 8) & (timeSpan.Hours > 0))
				{
					GameObject gameObject5 = UnityEngine.Object.Instantiate(SEED_HIGH, FIELD_1_SECTORS[j].transform.position, base.transform.rotation);
					gameObject5.transform.position = new Vector3(FIELD_1_SECTORS[j].transform.position.x, 30.5f, FIELD_1_SECTORS[j].transform.position.z);
					gameObject5.transform.rotation = Quaternion.Euler(0f, -90f, 0f);
				}
			}
		}
		if (field == 2)
		{
			for (int k = 0; k < FIELD_2_SECTORS.Length; k++)
			{
				int iNDEX2 = FIELD_2_SECTORS[k].GetComponent<SECTOR>().INDEX;
				string identifier2 = "F2_S" + iNDEX2 + "_TIME";
				string text2 = ES2.Load<string>(identifier2);
				if (text2 == string.Empty)
				{
					FIELD_2_SECTORS[k].GetComponent<SpriteRenderer>().color = new Color(0f, 1f, 0f, 1f);
					FIELD_2_SECTORS[k].GetComponent<SECTOR>().FREE = true;
					continue;
				}
				FIELD_2_SECTORS[k].GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f, 0f);
				FIELD_2_SECTORS[k].GetComponent<SECTOR>().FREE = false;
				if (GetNextRewardTime(CURRENT_FIELD, k).Subtract(DateTime.Now) <= TimeSpan.Zero)
				{
					string1 = DateTime.FromBinary(Convert.ToInt64(text2)).ToShortDateString();
					string2 = DateTime.Now.ToShortDateString();
					if (string1 != string2)
					{
						FIELD_2_SECTORS[k].GetComponent<BoxCollider>().enabled = false;
						GameObject gameObject6 = UnityEngine.Object.Instantiate(SEED_OFF, FIELD_2_SECTORS[k].transform.position, base.transform.rotation);
						gameObject6.transform.position = new Vector3(FIELD_2_SECTORS[k].transform.position.x, 30.5f, FIELD_2_SECTORS[k].transform.position.z);
						gameObject6.transform.rotation = Quaternion.Euler(0f, -90f, 0f);
						gameObject6.GetComponent<SF_OFF>().INDEX = k;
					}
					else
					{
						GameObject gameObject7 = UnityEngine.Object.Instantiate(SEED_MAX, FIELD_2_SECTORS[k].transform.position, base.transform.rotation);
						gameObject7.transform.position = new Vector3(FIELD_2_SECTORS[k].transform.position.x, 30.5f, FIELD_2_SECTORS[k].transform.position.z);
						gameObject7.transform.rotation = Quaternion.Euler(0f, -90f, 0f);
						gameObject7.GetComponent<SF_OFF>().INDEX = k;
					}
					continue;
				}
				GetNextRewardTime(CURRENT_FIELD, FIELD_2_SECTORS[k].GetComponent<SECTOR>().INDEX);
				TimeSpan timeSpan2 = GetNextRewardTime(CURRENT_FIELD, FIELD_2_SECTORS[k].GetComponent<SECTOR>().INDEX).Subtract(DateTime.Now);
				if ((timeSpan2.Hours < 24) & (timeSpan2.Hours > 15))
				{
					GameObject gameObject8 = UnityEngine.Object.Instantiate(SEED_LOW, FIELD_2_SECTORS[k].transform.position, base.transform.rotation);
					gameObject8.transform.position = new Vector3(FIELD_2_SECTORS[k].transform.position.x, 30.5f, FIELD_2_SECTORS[k].transform.position.z);
					gameObject8.transform.rotation = Quaternion.Euler(0f, -90f, 0f);
				}
				if ((timeSpan2.Hours < 16) & (timeSpan2.Hours > 7))
				{
					GameObject gameObject9 = UnityEngine.Object.Instantiate(SEED_MED, FIELD_2_SECTORS[k].transform.position, base.transform.rotation);
					gameObject9.transform.position = new Vector3(FIELD_2_SECTORS[k].transform.position.x, 30.5f, FIELD_2_SECTORS[k].transform.position.z);
					gameObject9.transform.rotation = Quaternion.Euler(0f, -90f, 0f);
				}
				if ((timeSpan2.Hours < 8) & (timeSpan2.Hours > 0))
				{
					GameObject gameObject10 = UnityEngine.Object.Instantiate(SEED_HIGH, FIELD_2_SECTORS[k].transform.position, base.transform.rotation);
					gameObject10.transform.position = new Vector3(FIELD_2_SECTORS[k].transform.position.x, 30.5f, FIELD_2_SECTORS[k].transform.position.z);
					gameObject10.transform.rotation = Quaternion.Euler(0f, -90f, 0f);
				}
			}
		}
		if (field != 3)
		{
			return;
		}
		for (int l = 0; l < FIELD_3_SECTORS.Length; l++)
		{
			int iNDEX3 = FIELD_3_SECTORS[l].GetComponent<SECTOR>().INDEX;
			string identifier3 = "F3_S" + iNDEX3 + "_TIME";
			string text3 = ES2.Load<string>(identifier3);
			if (text3 == string.Empty)
			{
				FIELD_3_SECTORS[l].GetComponent<SpriteRenderer>().color = new Color(0f, 1f, 0f, 1f);
				FIELD_3_SECTORS[l].GetComponent<SECTOR>().FREE = true;
				continue;
			}
			FIELD_3_SECTORS[l].GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f, 0f);
			FIELD_3_SECTORS[l].GetComponent<SECTOR>().FREE = false;
			if (GetNextRewardTime(CURRENT_FIELD, l).Subtract(DateTime.Now) <= TimeSpan.Zero)
			{
				string1 = DateTime.FromBinary(Convert.ToInt64(text3)).ToShortDateString();
				string2 = DateTime.Now.ToShortDateString();
				if (string1 != string2)
				{
					FIELD_3_SECTORS[l].GetComponent<BoxCollider>().enabled = false;
					GameObject gameObject11 = UnityEngine.Object.Instantiate(SEED_OFF, FIELD_3_SECTORS[l].transform.position, base.transform.rotation);
					gameObject11.transform.position = new Vector3(FIELD_3_SECTORS[l].transform.position.x, 30.5f, FIELD_3_SECTORS[l].transform.position.z);
					gameObject11.transform.rotation = Quaternion.Euler(0f, -90f, 0f);
					gameObject11.GetComponent<SF_OFF>().INDEX = l;
				}
				else
				{
					GameObject gameObject12 = UnityEngine.Object.Instantiate(SEED_MAX, FIELD_3_SECTORS[l].transform.position, base.transform.rotation);
					gameObject12.transform.position = new Vector3(FIELD_3_SECTORS[l].transform.position.x, 30.5f, FIELD_3_SECTORS[l].transform.position.z);
					gameObject12.transform.rotation = Quaternion.Euler(0f, -90f, 0f);
					gameObject12.GetComponent<SF_OFF>().INDEX = l;
				}
				continue;
			}
			GetNextRewardTime(CURRENT_FIELD, FIELD_3_SECTORS[l].GetComponent<SECTOR>().INDEX);
			TimeSpan timeSpan3 = GetNextRewardTime(CURRENT_FIELD, FIELD_3_SECTORS[l].GetComponent<SECTOR>().INDEX).Subtract(DateTime.Now);
			if ((timeSpan3.Hours < 24) & (timeSpan3.Hours > 15))
			{
				GameObject gameObject13 = UnityEngine.Object.Instantiate(SEED_LOW, FIELD_3_SECTORS[l].transform.position, base.transform.rotation);
				gameObject13.transform.position = new Vector3(FIELD_3_SECTORS[l].transform.position.x, 30.5f, FIELD_3_SECTORS[l].transform.position.z);
				gameObject13.transform.rotation = Quaternion.Euler(0f, -90f, 0f);
			}
			if ((timeSpan3.Hours < 16) & (timeSpan3.Hours > 7))
			{
				GameObject gameObject14 = UnityEngine.Object.Instantiate(SEED_MED, FIELD_3_SECTORS[l].transform.position, base.transform.rotation);
				gameObject14.transform.position = new Vector3(FIELD_3_SECTORS[l].transform.position.x, 30.5f, FIELD_3_SECTORS[l].transform.position.z);
				gameObject14.transform.rotation = Quaternion.Euler(0f, -90f, 0f);
			}
			if ((timeSpan3.Hours < 8) & (timeSpan3.Hours > 0))
			{
				GameObject gameObject15 = UnityEngine.Object.Instantiate(SEED_HIGH, FIELD_3_SECTORS[l].transform.position, base.transform.rotation);
				gameObject15.transform.position = new Vector3(FIELD_3_SECTORS[l].transform.position.x, 30.5f, FIELD_3_SECTORS[l].transform.position.z);
				gameObject15.transform.rotation = Quaternion.Euler(0f, -90f, 0f);
			}
		}
	}
}
