using UnityEngine;
using UnityEngine.UI;

public class CHECK_DAY : MonoBehaviour
{
	public Sprite NORMAL_;

	public Sprite GRABED_;

	public int DAY;

	public int MONEY;

	public Text TEXT;

	public Image IMAGE;

	private void OnEnable()
	{
		if (DAY < ES2.Load<int>("BONUS_DAY"))
		{
			base.gameObject.GetComponent<Image>().sprite = GRABED_;
		}
		else
		{
			base.gameObject.GetComponent<Image>().sprite = NORMAL_;
		}
		if (MENU_MANAGER.BONUS_AVAILABLE)
		{
			if (DAY == ES2.Load<int>("BONUS_DAY"))
			{
				MENU_MANAGER.MONEY_ = MONEY;
				base.gameObject.GetComponent<Image>().sprite = NORMAL_;
				TEXT.color = new Color(1f, 1f, 1f, 1f);
				IMAGE.color = new Color(1f, 1f, 1f, 1f);
				base.gameObject.GetComponent<Button>().interactable = true;
			}
		}
		else
		{
			TEXT.color = new Color(1f, 1f, 1f, 0.5f);
			IMAGE.color = new Color(1f, 1f, 1f, 0.5f);
			base.gameObject.GetComponent<Button>().interactable = false;
		}
	}
}
