using UnityEngine;

public class Fruit_screen_Fx : MonoBehaviour
{
	private float RND;

	private float ALPHA;

	private Color COLORS_;

	public void SETCOLOR(Color CLR)
	{
		COLORS_ = CLR;
	}

	private void Start()
	{
		base.gameObject.GetComponent<SpriteRenderer>().color = COLORS_;
		ALPHA = 0.9f;
		RND = Random.Range(0.04f, 0.07f);
		base.gameObject.transform.localScale = new Vector3(RND, RND - 0.01f, RND);
		base.gameObject.transform.localRotation = Quaternion.Euler(0f, 0f, Random.Range(0, 360));
		base.gameObject.transform.localPosition = new Vector3(Random.Range(-0.3f, 0.3f), Random.Range(-0.15f, 0.15f), 0.32f);
	}

	private void Update()
	{
		base.gameObject.transform.GetComponent<SpriteRenderer>().color = new Color(COLORS_.r, COLORS_.g, COLORS_.b, ALPHA);
		if (ALPHA > 0f)
		{
			ALPHA -= Time.deltaTime / 5f;
			if (ALPHA < 0.1f)
			{
				Object.Destroy(base.gameObject);
			}
		}
	}
}
