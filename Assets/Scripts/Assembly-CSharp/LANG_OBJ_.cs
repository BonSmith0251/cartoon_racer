using UnityEngine;

public class LANG_OBJ_ : MonoBehaviour
{
	public bool IS_ENG;

	public bool IS_RUS;

	private void OnEnable()
	{
		if (MENU_MANAGER.LANGUAGE == 0 && IS_RUS)
		{
			base.gameObject.SetActive(value: false);
		}
		if (MENU_MANAGER.LANGUAGE == 1 && IS_ENG)
		{
			base.gameObject.SetActive(value: false);
		}
	}
}
