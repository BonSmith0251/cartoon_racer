using UnityEngine;

public class STOP_TRIGGER : MonoBehaviour
{
	private void OnTriggerExit(Collider car2)
	{
		if (car2.CompareTag("Player"))
		{
			base.gameObject.GetComponent<BoxCollider>().isTrigger = false;
			base.enabled = false;
		}
	}
}
