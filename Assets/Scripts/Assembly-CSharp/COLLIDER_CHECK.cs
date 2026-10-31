using UnityEngine;

public class COLLIDER_CHECK : MonoBehaviour
{
	private void OnTriggerEnter(Collider car2)
	{
		if (car2.CompareTag("TRAFFIC"))
		{
			Object.Destroy(base.gameObject);
		}
	}
}
