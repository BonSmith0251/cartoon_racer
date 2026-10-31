using UnityEngine;

public class FX_BLACKSCREEN : MonoBehaviour
{
	private float alpha;

	private void OnEnable()
	{
		alpha = 1f;
	}

	private void LateUpdate()
	{
		if (Time.frameCount % 3 == 0)
		{
			base.gameObject.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f, alpha);
		}
		if (alpha > 0f)
		{
			alpha -= Time.deltaTime / 3f;
			if (alpha < 0.01f)
			{
				base.gameObject.SetActive(value: false);
			}
		}
	}
}
