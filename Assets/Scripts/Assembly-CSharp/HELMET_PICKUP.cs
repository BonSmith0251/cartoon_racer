using UnityEngine;

public class HELMET_PICKUP : MonoBehaviour
{
	public GameObject FX;

	private void OnTriggerEnter(Collider car2)
	{
		if (car2.CompareTag("Player"))
		{
			GameObject gameObject = Object.Instantiate(FX, base.transform.position, base.transform.rotation);
			GAME_MANAGER.GET_HEL = true;
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
