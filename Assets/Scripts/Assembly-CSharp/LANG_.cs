using UnityEngine;
using UnityEngine.UI;

public class LANG_ : MonoBehaviour
{
	private int GG;

	public string RUS;

	public string ENG;

	private void OnEnable()
	{
		if (MENU_MANAGER.LANGUAGE == 0)
		{
			base.gameObject.GetComponent<Text>().text = string.Empty + ENG;
		}
		if (MENU_MANAGER.LANGUAGE == 1)
		{
			base.gameObject.GetComponent<Text>().text = string.Empty + RUS;
		}
	}
}
