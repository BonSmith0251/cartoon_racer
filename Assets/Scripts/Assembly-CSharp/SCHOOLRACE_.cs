using UnityEngine;
using UnityEngine.UI;

public class SCHOOLRACE_ : MonoBehaviour
{
	public bool TAXI_;

	public bool MEDIC_;

	public bool COP_;

	public GameObject CLOSE_UI;

	public GameObject COMPLETE_UI;

	public Sprite COMPLETE_SPR;

	public GameObject MANAGER;

	public GameObject LEVEL_CANVAS;

	public bool PARKING;

	public bool CHECKPOINT;

	public bool ORIENTIR;

	public bool GUARD;

	public int INDEX;

	public void Start()
	{
		if (PARKING)
		{
			if (ES2.Load<int>("SCHOOL_TRAFFIC" + INDEX) == 1)
			{
				SCHOOL_MANAGER.PROGRESS_ += 3.125f;
				base.gameObject.GetComponent<Image>().sprite = COMPLETE_SPR;
				base.gameObject.GetComponent<Button>().interactable = false;
				COMPLETE_UI.SetActive(value: true);
				if (CLOSE_UI != null)
				{
					CLOSE_UI.SetActive(value: false);
				}
			}
			else if (CLOSE_UI != null)
			{
				if (ES2.Load<int>("SCHOOL_TRAFFIC_" + INDEX) == 0)
				{
					CLOSE_UI.SetActive(value: true);
				}
				else
				{
					base.gameObject.GetComponent<Button>().interactable = true;
					CLOSE_UI.SetActive(value: false);
				}
			}
		}
		if (CHECKPOINT)
		{
			if (ES2.Load<int>("SCHOOL_CHECKPOINT" + INDEX) == 1)
			{
				SCHOOL_MANAGER.PROGRESS_ += 3.125f;
				base.gameObject.GetComponent<Image>().sprite = COMPLETE_SPR;
				base.gameObject.GetComponent<Button>().interactable = false;
				COMPLETE_UI.SetActive(value: true);
				if (CLOSE_UI != null)
				{
					CLOSE_UI.SetActive(value: false);
				}
			}
			else if (CLOSE_UI != null)
			{
				if (ES2.Load<int>("SCHOOL_CHECKPOINT_" + INDEX) == 0)
				{
					CLOSE_UI.SetActive(value: true);
				}
				else
				{
					base.gameObject.GetComponent<Button>().interactable = true;
					CLOSE_UI.SetActive(value: false);
				}
			}
		}
		if (ORIENTIR)
		{
			if (ES2.Load<int>("SCHOOL_ORIENT" + INDEX) == 1)
			{
				SCHOOL_MANAGER.PROGRESS_ += 3.125f;
				base.gameObject.GetComponent<Image>().sprite = COMPLETE_SPR;
				base.gameObject.GetComponent<Button>().interactable = false;
				COMPLETE_UI.SetActive(value: true);
				if (CLOSE_UI != null)
				{
					CLOSE_UI.SetActive(value: false);
				}
			}
			else if (CLOSE_UI != null)
			{
				if (ES2.Load<int>("SCHOOL_ORIENT_" + INDEX) == 0)
				{
					CLOSE_UI.SetActive(value: true);
				}
				else
				{
					base.gameObject.GetComponent<Button>().interactable = true;
					CLOSE_UI.SetActive(value: false);
				}
			}
		}
		if (GUARD)
		{
			if (ES2.Load<int>("SCHOOL_REACT" + INDEX) == 1)
			{
				SCHOOL_MANAGER.PROGRESS_ += 3.125f;
				base.gameObject.GetComponent<Image>().sprite = COMPLETE_SPR;
				base.gameObject.GetComponent<Button>().interactable = false;
				COMPLETE_UI.SetActive(value: true);
				if (CLOSE_UI != null)
				{
					CLOSE_UI.SetActive(value: false);
				}
			}
			else if (CLOSE_UI != null)
			{
				if (ES2.Load<int>("SCHOOL_REACT_" + INDEX) == 0)
				{
					CLOSE_UI.SetActive(value: true);
				}
				else
				{
					base.gameObject.GetComponent<Button>().interactable = true;
					CLOSE_UI.SetActive(value: false);
				}
			}
		}
		if (SCHOOL_MANAGER.RESTORE)
		{
			INDEX = SCHOOL_MANAGER.SELECTED_LEVEL;
			START_();
			SCHOOL_MANAGER.RESTORE = false;
		}
	}

	public void START()
	{
		LEVEL_CANVAS.SetActive(value: false);
		if (PARKING)
		{
			MANAGER.GetComponent<SCHOOL_MANAGER>().SHOW_LEVEL(INDEX, "PARKING");
		}
		if (CHECKPOINT)
		{
			MANAGER.GetComponent<SCHOOL_MANAGER>().SHOW_LEVEL(INDEX, "CHECKPOINT");
		}
		if (ORIENTIR)
		{
			MANAGER.GetComponent<SCHOOL_MANAGER>().SHOW_LEVEL(INDEX, "ORIENTIR");
		}
		if (GUARD)
		{
			MANAGER.GetComponent<SCHOOL_MANAGER>().SHOW_LEVEL(INDEX, "GUARD");
		}
		MANAGER.GetComponent<SCHOOL_MANAGER>().CREATE_CAR();
	}

	public void START_()
	{
		LEVEL_CANVAS.SetActive(value: false);
		if (SCHOOL_MANAGER.SELECTED_TYPE == "PARKING")
		{
			MANAGER.GetComponent<SCHOOL_MANAGER>().SHOW_LEVEL(INDEX, "PARKING");
		}
		if (SCHOOL_MANAGER.SELECTED_TYPE == "CHECKPOINT")
		{
			MANAGER.GetComponent<SCHOOL_MANAGER>().SHOW_LEVEL(INDEX, "CHECKPOINT");
		}
		if (SCHOOL_MANAGER.SELECTED_TYPE == "ORIENTIR")
		{
			MANAGER.GetComponent<SCHOOL_MANAGER>().SHOW_LEVEL(INDEX, "ORIENTIR");
		}
		if (SCHOOL_MANAGER.SELECTED_TYPE == "GUARD")
		{
			MANAGER.GetComponent<SCHOOL_MANAGER>().SHOW_LEVEL(INDEX, "GUARD");
		}
		MANAGER.GetComponent<SCHOOL_MANAGER>().CREATE_CAR();
	}
}
