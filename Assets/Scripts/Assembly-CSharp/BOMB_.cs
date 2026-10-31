using UnityEngine;

public class BOMB_ : MonoBehaviour
{
	public GameObject FX;

	private void OnTriggerEnter(Collider car2)
	{
		if (car2.CompareTag("Player"))
		{
			GameObject gameObject = Object.Instantiate(FX, base.transform.position, base.transform.rotation);
			car2.GetComponentInParent<RCC_CarControllerV3>().HAND();
			base.gameObject.GetComponent<MeshRenderer>().enabled = false;
		}
	}

	private void OnTriggerExit(Collider car2)
	{
		if (car2.CompareTag("Player"))
		{
			base.gameObject.SetActive(value: true);
			base.gameObject.GetComponent<MeshRenderer>().enabled = true;
		}
	}
}
