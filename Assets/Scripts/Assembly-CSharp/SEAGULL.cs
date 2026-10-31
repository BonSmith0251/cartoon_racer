using UnityEngine;

public class SEAGULL : MonoBehaviour
{
	public GameObject GULL;

	private bool enter;

	private float yy;

	private int rnd;

	public AnimationClip ANIM;

	private void OnTriggerEnter(Collider car2)
	{
		if (car2.CompareTag("Player") & !enter)
		{
			enter = true;
			rnd = Random.Range(0, 2);
			if (rnd == 0)
			{
				yy = 85f;
			}
			else
			{
				yy = -85f;
			}
			GULL.GetComponent<Animation>().CrossFade(ANIM.name, 0.2f);
			GULL.GetComponent<AudioSource>().enabled = true;
		}
	}

	private void Update()
	{
		if (enter)
		{
			Quaternion quaternion = Quaternion.AngleAxis(yy * Time.deltaTime, Vector3.up);
			base.gameObject.transform.localRotation *= quaternion;
			base.transform.Translate(Vector3.forward * 10f * Time.deltaTime);
			base.transform.Translate(Vector3.up * 6f * Time.deltaTime);
			if (base.transform.position.y > 80f)
			{
				Object.Destroy(base.gameObject);
			}
		}
	}
}
