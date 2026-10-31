using UnityEngine;

public class MOVE_TEXT : MonoBehaviour
{
	private void OnEnable()
	{
		base.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(4200f, -71f, 0f);
	}

	private void Update()
	{
		base.gameObject.GetComponent<RectTransform>().transform.Translate(Vector3.left * Time.deltaTime * 60f);
	}
}
