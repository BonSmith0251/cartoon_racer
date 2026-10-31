using UnityEngine;

public class GUARD : MonoBehaviour
{
	public bool STATIC;

	public bool DYNAMIC;

	public GameObject[] LEFT;

	public GameObject[] CENTER;

	public GameObject[] RIGHT;

	private int RND;

	private float TIMER;

	private bool A;

	private bool B;

	private bool C;

	private float dist;

	private void Start()
	{
		if (!STATIC)
		{
			return;
		}
		RND = Random.Range(0, 6);
		if (RND == 0)
		{
			for (int i = 0; i < LEFT.Length; i++)
			{
				LEFT[i].GetComponent<SpriteRenderer>().color = new Color(1f, 0f, 0f, 1f);
				LEFT[i].GetComponent<BoxCollider>().enabled = true;
			}
			for (int j = 0; j < CENTER.Length; j++)
			{
				CENTER[j].GetComponent<SpriteRenderer>().color = new Color(1f, 0f, 0f, 1f);
				CENTER[j].GetComponent<BoxCollider>().enabled = true;
			}
			for (int k = 0; k < RIGHT.Length; k++)
			{
				RIGHT[k].GetComponent<SpriteRenderer>().color = new Color(0f, 1f, 0f, 1f);
				RIGHT[k].GetComponent<BoxCollider>().enabled = false;
			}
		}
		if (RND == 1)
		{
			for (int l = 0; l < RIGHT.Length; l++)
			{
				RIGHT[l].GetComponent<SpriteRenderer>().color = new Color(1f, 0f, 0f, 1f);
				RIGHT[l].GetComponent<BoxCollider>().enabled = true;
			}
			for (int m = 0; m < CENTER.Length; m++)
			{
				CENTER[m].GetComponent<SpriteRenderer>().color = new Color(1f, 0f, 0f, 1f);
				CENTER[m].GetComponent<BoxCollider>().enabled = true;
			}
			for (int n = 0; n < LEFT.Length; n++)
			{
				LEFT[n].GetComponent<SpriteRenderer>().color = new Color(0f, 1f, 0f, 1f);
				LEFT[n].GetComponent<BoxCollider>().enabled = false;
			}
		}
		if (RND == 2)
		{
			for (int num = 0; num < RIGHT.Length; num++)
			{
				RIGHT[num].GetComponent<SpriteRenderer>().color = new Color(1f, 0f, 0f, 1f);
				RIGHT[num].GetComponent<BoxCollider>().enabled = true;
			}
			for (int num2 = 0; num2 < CENTER.Length; num2++)
			{
				CENTER[num2].GetComponent<SpriteRenderer>().color = new Color(0f, 1f, 0f, 1f);
				CENTER[num2].GetComponent<BoxCollider>().enabled = false;
			}
			for (int num3 = 0; num3 < LEFT.Length; num3++)
			{
				LEFT[num3].GetComponent<SpriteRenderer>().color = new Color(1f, 0f, 0f, 1f);
				LEFT[num3].GetComponent<BoxCollider>().enabled = true;
			}
		}
		if (RND == 3)
		{
			for (int num4 = 0; num4 < RIGHT.Length; num4++)
			{
				RIGHT[num4].GetComponent<SpriteRenderer>().color = new Color(0f, 1f, 0f, 1f);
				RIGHT[num4].GetComponent<BoxCollider>().enabled = false;
			}
			for (int num5 = 0; num5 < CENTER.Length; num5++)
			{
				CENTER[num5].GetComponent<SpriteRenderer>().color = new Color(1f, 0f, 0f, 1f);
				CENTER[num5].GetComponent<BoxCollider>().enabled = true;
			}
			for (int num6 = 0; num6 < LEFT.Length; num6++)
			{
				LEFT[num6].GetComponent<SpriteRenderer>().color = new Color(0f, 1f, 0f, 1f);
				LEFT[num6].GetComponent<BoxCollider>().enabled = false;
			}
		}
		if (RND == 4)
		{
			for (int num7 = 0; num7 < RIGHT.Length; num7++)
			{
				RIGHT[num7].GetComponent<SpriteRenderer>().color = new Color(1f, 0f, 0f, 1f);
				RIGHT[num7].GetComponent<BoxCollider>().enabled = true;
			}
			for (int num8 = 0; num8 < CENTER.Length; num8++)
			{
				CENTER[num8].GetComponent<SpriteRenderer>().color = new Color(0f, 1f, 0f, 1f);
				CENTER[num8].GetComponent<BoxCollider>().enabled = false;
			}
			for (int num9 = 0; num9 < LEFT.Length; num9++)
			{
				LEFT[num9].GetComponent<SpriteRenderer>().color = new Color(0f, 1f, 0f, 1f);
				LEFT[num9].GetComponent<BoxCollider>().enabled = false;
			}
		}
		if (RND == 5)
		{
			for (int num10 = 0; num10 < RIGHT.Length; num10++)
			{
				RIGHT[num10].GetComponent<SpriteRenderer>().color = new Color(0f, 1f, 0f, 1f);
				RIGHT[num10].GetComponent<BoxCollider>().enabled = false;
			}
			for (int num11 = 0; num11 < CENTER.Length; num11++)
			{
				CENTER[num11].GetComponent<SpriteRenderer>().color = new Color(0f, 1f, 0f, 1f);
				CENTER[num11].GetComponent<BoxCollider>().enabled = false;
			}
			for (int num12 = 0; num12 < LEFT.Length; num12++)
			{
				LEFT[num12].GetComponent<SpriteRenderer>().color = new Color(1f, 0f, 0f, 1f);
				LEFT[num12].GetComponent<BoxCollider>().enabled = true;
			}
		}
	}

	private void Update()
	{
		if (Time.frameCount % 20 == 0)
		{
			dist = Vector3.Distance(CENTER[0].transform.position, Camera.main.transform.position);
		}
		if (STATIC)
		{
			base.enabled = false;
			return;
		}
		if (dist > 37f)
		{
			TIMER += Time.deltaTime / 1.6f;
		}
		if (TIMER > 3.2f)
		{
			for (int i = 0; i < RIGHT.Length; i++)
			{
				RIGHT[i].GetComponent<SpriteRenderer>().color = new Color(1f, 0f, 0f, 1f);
				RIGHT[i].GetComponent<BoxCollider>().enabled = true;
			}
			for (int j = 0; j < CENTER.Length; j++)
			{
				CENTER[j].GetComponent<SpriteRenderer>().color = new Color(1f, 0f, 0f, 1f);
				CENTER[j].GetComponent<BoxCollider>().enabled = true;
			}
			for (int k = 0; k < LEFT.Length; k++)
			{
				LEFT[k].GetComponent<SpriteRenderer>().color = new Color(1f, 0f, 0f, 1f);
				LEFT[k].GetComponent<BoxCollider>().enabled = true;
			}
			A = false;
			B = false;
			C = false;
			TIMER = 0f;
		}
		if ((TIMER > 0f) & (TIMER < 1f) & !A)
		{
			for (int l = 0; l < RIGHT.Length; l++)
			{
				RIGHT[l].GetComponent<SpriteRenderer>().color = new Color(1f, 0f, 0f, 1f);
				RIGHT[l].GetComponent<BoxCollider>().enabled = true;
			}
			for (int m = 0; m < CENTER.Length; m++)
			{
				CENTER[m].GetComponent<SpriteRenderer>().color = new Color(1f, 0f, 0f, 1f);
				CENTER[m].GetComponent<BoxCollider>().enabled = true;
			}
			for (int n = 0; n < LEFT.Length; n++)
			{
				LEFT[n].GetComponent<SpriteRenderer>().color = new Color(0f, 1f, 0f, 1f);
				LEFT[n].GetComponent<BoxCollider>().enabled = false;
			}
			A = true;
		}
		if ((TIMER > 1f) & (TIMER < 2f) & !B)
		{
			for (int num = 0; num < RIGHT.Length; num++)
			{
				RIGHT[num].GetComponent<SpriteRenderer>().color = new Color(1f, 0f, 0f, 1f);
				RIGHT[num].GetComponent<BoxCollider>().enabled = true;
			}
			for (int num2 = 0; num2 < CENTER.Length; num2++)
			{
				CENTER[num2].GetComponent<SpriteRenderer>().color = new Color(0f, 1f, 0f, 1f);
				CENTER[num2].GetComponent<BoxCollider>().enabled = false;
			}
			for (int num3 = 0; num3 < LEFT.Length; num3++)
			{
				LEFT[num3].GetComponent<SpriteRenderer>().color = new Color(1f, 0f, 0f, 1f);
				LEFT[num3].GetComponent<BoxCollider>().enabled = true;
			}
			B = true;
		}
		if ((TIMER > 2f) & (TIMER < 3f) & !C)
		{
			for (int num4 = 0; num4 < RIGHT.Length; num4++)
			{
				RIGHT[num4].GetComponent<SpriteRenderer>().color = new Color(0f, 1f, 0f, 1f);
				RIGHT[num4].GetComponent<BoxCollider>().enabled = false;
			}
			for (int num5 = 0; num5 < CENTER.Length; num5++)
			{
				CENTER[num5].GetComponent<SpriteRenderer>().color = new Color(1f, 0f, 0f, 1f);
				CENTER[num5].GetComponent<BoxCollider>().enabled = true;
			}
			for (int num6 = 0; num6 < LEFT.Length; num6++)
			{
				LEFT[num6].GetComponent<SpriteRenderer>().color = new Color(1f, 0f, 0f, 1f);
				LEFT[num6].GetComponent<BoxCollider>().enabled = true;
			}
			C = true;
		}
	}
}
