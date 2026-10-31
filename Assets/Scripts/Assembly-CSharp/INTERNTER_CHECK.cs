using UnityEngine;
using UnityEngine.UI;

public class INTERNTER_CHECK : MonoBehaviour
{
	public bool IS_BUTTON;

	private void Awake()
	{
		if (Application.internetReachability == NetworkReachability.NotReachable)
		{
			if (IS_BUTTON)
			{
				base.gameObject.GetComponent<Button>().interactable = false;
			}
			else
			{
				base.gameObject.SetActive(value: false);
			}
		}
	}

	private void Update()
	{
		if (Time.frameCount % 15 == 0 && Application.internetReachability == NetworkReachability.NotReachable)
		{
			if (IS_BUTTON)
			{
				base.gameObject.GetComponent<Button>().interactable = false;
			}
			else
			{
				base.gameObject.SetActive(value: false);
			}
		}
	}
}
