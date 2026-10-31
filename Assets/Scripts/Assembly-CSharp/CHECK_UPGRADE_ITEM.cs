using UnityEngine;
using UnityEngine.UI;

public class CHECK_UPGRADE_ITEM : MonoBehaviour
{
	public Text COST_TXT;

	public Text GEAR_TXT;

	public Text LVL_TEXT;

	public bool ENGINE;

	public bool TIRES;

	public bool TRANS;

	public bool BRAKES;

	public bool NITRO;

	public bool SUSP;

	public bool WEIGHT;

	public int NEED_LEVEL;

	public int STADIA;

	public int COST;

	public int GEAR;

	public Image OBJ_IMG;

	public GameObject LOCK;

	private string str;

	private int int_;

	private void OnDisable()
	{
		int_ = 0;
		str = null;
	}

	private void OnEnable()
	{
		int_ = 0;
		str = null;
		int_ = MENU_MANAGER.SPAWN_CAR_ + 1;
		if (ENGINE)
		{
			str = "CAR" + int_ + "_ENGINE";
		}
		if (TIRES)
		{
			str = "CAR" + int_ + "_TIRES";
		}
		if (TRANS)
		{
			str = "CAR" + int_ + "_KPP";
		}
		if (BRAKES)
		{
			str = "CAR" + int_ + "_BRAKES";
		}
		if (NITRO)
		{
			str = "CAR" + int_ + "_NITRO";
		}
		if (SUSP)
		{
			str = "CAR" + int_ + "_SUSP";
		}
		if (WEIGHT)
		{
			str = "CAR" + int_ + "_WEIGHT";
		}
		if (ES2.Load<int>(str) == STADIA)
		{
			OBJ_IMG.color = new Color(1f, 1f, 1f, 1f);
			if (LOCK != null)
			{
				LOCK.SetActive(value: false);
			}
			if (STADIA == 4)
			{
				UPGRADE_MENU.UPGRADE_COMPLETE = true;
				return;
			}
			UPGRADE_MENU.UPGRADE_COMPLETE = false;
		}
		else
		{
			OBJ_IMG.color = new Color(0f, 0f, 0f, 0.35f);
			if ((ES2.Load<int>(str) < STADIA) & (ES2.Load<int>(str) == STADIA - 1))
			{
				CHECK_();
			}
		}
		if (MENU_MANAGER.PLAYER_LEVEL >= NEED_LEVEL && LOCK != null)
		{
			LOCK.SetActive(value: false);
		}
	}

	private void CHECK_()
	{
		if (MENU_MANAGER.PLAYER_LEVEL < NEED_LEVEL)
		{
			if (!UPGRADE_MENU.BUY_AVAIBLE)
			{
				COST_TXT.text = string.Empty + COST;
				GEAR_TXT.text = string.Empty + GEAR;
			}
			if (LOCK != null)
			{
				LOCK.SetActive(value: true);
			}
			return;
		}
		if (LVL_TEXT != null)
		{
			LVL_TEXT.color = new Color(1f, 1f, 1f, 1f);
		}
		UPGRADE_MENU.BUY_AVAIBLE = true;
		if (UPGRADE_MENU.MORE_COST == 1)
		{
			COST -= COST / 10;
		}
		if (UPGRADE_MENU.MORE_COST == 1)
		{
			GEAR -= GEAR / 10;
		}
		COST_TXT.text = string.Empty + COST;
		GEAR_TXT.text = string.Empty + GEAR;
		if (ENGINE)
		{
			UPGRADE_MENU.UPGRADE_ITEM = "ENGINE";
		}
		if (TIRES)
		{
			UPGRADE_MENU.UPGRADE_ITEM = "TIRES";
		}
		if (TRANS)
		{
			UPGRADE_MENU.UPGRADE_ITEM = "TRANS";
		}
		if (BRAKES)
		{
			UPGRADE_MENU.UPGRADE_ITEM = "BRAKES";
		}
		if (NITRO)
		{
			UPGRADE_MENU.UPGRADE_ITEM = "NITRO";
		}
		if (SUSP)
		{
			UPGRADE_MENU.UPGRADE_ITEM = "SUSP";
		}
		if (WEIGHT)
		{
			UPGRADE_MENU.UPGRADE_ITEM = "WEIGHT";
		}
		UPGRADE_MENU.UPGRADE_COST = COST;
		UPGRADE_MENU.UPGRADE_GEAR = GEAR;
		UPGRADE_MENU.UPGRADE_STADIA = STADIA;
	}
}
