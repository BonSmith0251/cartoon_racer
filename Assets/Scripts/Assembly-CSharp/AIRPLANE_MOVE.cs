using UnityEngine;

public class AIRPLANE_MOVE : MonoBehaviour
{
	private float distance;

	private float speed;

	public bool END_;

	private bool FX;

	public GameObject FX_;

	private GameObject FXX;

	private void Start()
	{
		speed = Random.Range(5, 8);
		FXX = base.gameObject.GetComponentInChildren<BIRD_COLLIDER>().gameObject;
	}

	private void Update()
	{
		if (END_)
		{
			if (!FX)
			{
				GameObject gameObject = Object.Instantiate(FX_, FXX.transform.position, FXX.transform.rotation);
				FX = true;
			}
			base.transform.Translate(Vector3.down * Time.deltaTime * 4f);
			base.transform.Translate(-Vector3.left * Time.deltaTime * speed / 2f);
		}
		else
		{
			base.transform.Translate(-Vector3.left * Time.deltaTime * speed);
		}
		if (Time.frameCount % 150 == 0)
		{
			distance = Vector3.Distance(base.gameObject.transform.position, Camera.main.transform.position);
			if (distance > 100f)
			{
				Object.Destroy(base.gameObject);
			}
		}
	}
}
