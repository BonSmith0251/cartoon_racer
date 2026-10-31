using UnityEngine;
using UnityEngine.UI;

public class LOGO_ : MonoBehaviour
{
	public Sprite[] IMG;

	private int RND;

	private void OnEnable()
	{
		base.gameObject.GetComponent<Image>().sprite = IMG[Random.Range(0, IMG.Length)];
	}
}
