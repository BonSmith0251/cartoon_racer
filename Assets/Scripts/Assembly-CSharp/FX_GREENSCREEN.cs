using UnityEngine;

public class FX_GREENSCREEN : MonoBehaviour
{
	private float alpha;

	private void OnEnable()
	{
		alpha = 1f;
	}

	private void Update()
	{
		base.gameObject.GetComponent<SpriteRenderer>().color = new Color(0.6f, 1f, 0f, alpha);
		if (alpha > 0f)
		{
			alpha -= Time.deltaTime / 2f;
			if (alpha < 0.01f)
			{
				base.gameObject.SetActive(value: false);
			}
		}
	}
}
