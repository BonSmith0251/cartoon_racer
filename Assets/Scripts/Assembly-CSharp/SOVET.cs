using UnityEngine;
using UnityEngine.UI;

public class SOVET : MonoBehaviour
{
	private int RND;

	public string[] SOVETS_RUS;

	public string[] SOVETS_ENG;

	private void Start()
	{
		if (MENU_MANAGER.LANGUAGE == 0)
		{
			RND = Random.Range(0, SOVETS_ENG.Length);
			base.gameObject.GetComponent<Text>().text = "Tip of the day: " + SOVETS_ENG[RND];
		}
		else
		{
			RND = Random.Range(0, SOVETS_RUS.Length);
			base.gameObject.GetComponent<Text>().text = "Совет дня: " + SOVETS_RUS[RND];
		}
	}
}
