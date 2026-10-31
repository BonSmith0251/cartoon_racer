using UnityEngine;
using UnityEngine.UI;

public class TUNING_ITEM_CHECK : MonoBehaviour
{
	public Text TXT;

	public Image IMG;

	public Button BUTTON;

	public GameObject LOCK;

	public bool IS_BACK;

	public bool IS_FRONT;

	public bool IS_MIDDLE;

	public bool IS_WHEELS;

	public int INDEX;

	public int INDEX2;

	private string STR;

	private int INT;

	private int INT2;

	private string STR_1;

	public void START()
	{
		TXT.color = new Color(0.5f, 0.5f, 0.5f, 0.4f);
		IMG.color = new Color(0.5f, 0.5f, 0.5f, 0.4f);
		BUTTON.interactable = false;
		INT = 0;
		STR = string.Empty;
		INT2 = 0;
		STR_1 = string.Empty;
		Start();
	}

	private void Start()
	{
		INT = 0;
		STR = string.Empty;
		INT2 = 0;
		STR_1 = string.Empty;
		TXT.color = new Color(0.5f, 0.5f, 0.5f, 0.4f);
		IMG.color = new Color(0.5f, 0.5f, 0.5f, 0.4f);
		INT = INDEX + 1;
		STR = "CAR" + INT;
		if (ES2.Load<int>(STR) == 1)
		{
			if (LOCK != null)
			{
				LOCK.SetActive(value: false);
			}
			if (IS_BACK)
			{
				TUNING_MENU.ITEM_NAME = "BACK";
				INT2 = MENU_MANAGER.SPAWN_CAR_ + 1;
				STR_1 = "CAR" + INT2 + "_BACK";
				if (ES2.Load<int>(STR_1) == INDEX2)
				{
					BUTTON.interactable = false;
					TXT.color = new Color(1f, 1f, 1f, 1f);
					IMG.color = new Color(1f, 1f, 1f, 1f);
				}
				else
				{
					TXT.color = new Color(0.5f, 0.5f, 0.5f, 0.4f);
					IMG.color = new Color(0.5f, 0.5f, 0.5f, 0.4f);
					BUTTON.interactable = true;
				}
			}
			if (IS_FRONT)
			{
				TUNING_MENU.ITEM_NAME = "FRONT";
				INT2 = MENU_MANAGER.SPAWN_CAR_ + 1;
				STR_1 = "CAR" + INT2 + "_FRONT";
				if (ES2.Load<int>(STR_1) == INDEX2)
				{
					BUTTON.interactable = false;
					TXT.color = new Color(1f, 1f, 1f, 1f);
					IMG.color = new Color(1f, 1f, 1f, 1f);
				}
				else
				{
					TXT.color = new Color(0.5f, 0.5f, 0.5f, 0.4f);
					IMG.color = new Color(0.5f, 0.5f, 0.5f, 0.4f);
					BUTTON.interactable = true;
				}
			}
			if (IS_MIDDLE)
			{
				TUNING_MENU.ITEM_NAME = "MIDDLE";
				INT2 = MENU_MANAGER.SPAWN_CAR_ + 1;
				STR_1 = "CAR" + INT2 + "_MIDDLE";
				if (ES2.Load<int>(STR_1) == INDEX2)
				{
					BUTTON.interactable = false;
					TXT.color = new Color(1f, 1f, 1f, 1f);
					IMG.color = new Color(1f, 1f, 1f, 1f);
				}
				else
				{
					TXT.color = new Color(0.5f, 0.5f, 0.5f, 0.4f);
					IMG.color = new Color(0.5f, 0.5f, 0.5f, 0.4f);
					BUTTON.interactable = true;
				}
			}
			if (IS_WHEELS)
			{
				TUNING_MENU.ITEM_NAME = "WHEELS";
				INT2 = MENU_MANAGER.SPAWN_CAR_ + 1;
				STR_1 = "CAR" + INT2 + "_WHEELS";
				if (ES2.Load<int>(STR_1) == INDEX2)
				{
					BUTTON.interactable = false;
					TXT.color = new Color(1f, 1f, 1f, 1f);
					IMG.color = new Color(1f, 1f, 1f, 1f);
				}
				else
				{
					TXT.color = new Color(0.5f, 0.5f, 0.5f, 0.4f);
					IMG.color = new Color(0.5f, 0.5f, 0.5f, 0.4f);
					BUTTON.interactable = true;
				}
			}
		}
		else
		{
			if (LOCK != null)
			{
				LOCK.SetActive(value: true);
			}
			BUTTON.interactable = false;
		}
	}
}
