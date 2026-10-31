using UnityEngine;

public class CRYSTAL_ : MonoBehaviour
{
	public GameObject FX;

	private void Start()
	{
		base.gameObject.transform.position = new Vector3(base.gameObject.transform.position.x, 20f, base.gameObject.transform.position.z);
	}

	private void OnTriggerEnter(Collider car2)
	{
		if (car2.CompareTag("Player") && FX != null)
		{
			FX.SetActive(value: true);
		}
	}

	private void OnTriggerStay(Collider car2)
	{
		if (car2.CompareTag("Player") && base.gameObject.transform.position.y < 30f)
		{
			base.gameObject.transform.Translate(Vector3.up * 5f * Time.deltaTime);
		}
	}
}
