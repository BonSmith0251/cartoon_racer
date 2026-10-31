using UnityEngine;

public class RING_ : MonoBehaviour
{
	private float size;

	private float size2;

	public AudioClip SND;

	public GameObject FX_;

	private bool enter;

	private void Start()
	{
		size = base.gameObject.transform.lossyScale.x;
		size2 = base.gameObject.transform.lossyScale.y;
	}

	private void OnTriggerEnter(Collider car2)
	{
		if (car2.CompareTag("Player") & !enter)
		{
			GameObject gameObject = Object.Instantiate(FX_, base.gameObject.transform.position, base.gameObject.transform.rotation);
			if (VILLY_MANAGMENT.RING_POWER < 1f)
			{
				VILLY_MANAGMENT.RING_POWER += 0.1f;
				Object.FindObjectOfType<VILLY_MANAGMENT>().ADD_POWER();
			}
			AudioSource.PlayClipAtPoint(SND, Camera.main.transform.position);
			enter = true;
		}
	}

	private void Update()
	{
		if (enter && size > 0f)
		{
			size -= Time.deltaTime * 200f;
			size2 -= Time.deltaTime * 200f;
			base.gameObject.transform.localScale = new Vector3(size, size2, -7.5f);
			if (size < 0.01f)
			{
				Object.Destroy(base.gameObject);
			}
		}
	}
}
