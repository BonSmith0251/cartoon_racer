using UnityEngine;

public class LETTER_CHECK : MonoBehaviour
{
	public GameObject FX;

	private void OnTriggerEnter(Collider car2)
	{
		if (car2.CompareTag("Player"))
		{
			GAME_MANAGER.CHECK_LETTER = true;
			GameObject gameObject = Object.Instantiate(FX, base.transform.position, base.transform.rotation);
			Object.Destroy(base.gameObject);
		}
	}

	private void OnCollisionStay(Collision collision)
	{
		if (base.transform.position.y > 35f)
		{
			base.transform.Translate(Vector3.up * 2000f * Time.deltaTime);
			base.transform.Translate(Vector3.forward * 2000f * Time.deltaTime);
		}
	}
}
