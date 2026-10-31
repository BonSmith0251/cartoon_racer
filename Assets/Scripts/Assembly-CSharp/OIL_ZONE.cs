using UnityEngine;

public class OIL_ZONE : MonoBehaviour
{
	private int side;

	private void OnTriggerEnter(Collider car2)
	{
		if (car2.CompareTag("Player"))
		{
			side = Random.Range(0, 2);
			car2.GetComponentInParent<RCC_CarControllerV3>().HAND2();
		}
	}

	private void OnTriggerStay(Collider car2)
	{
		if (car2.CompareTag("Player") & (RCC_CarControllerV3.SPEED > 20f))
		{
			car2.GetComponentInParent<Rigidbody>().angularDrag = 40f;
			if (side == 0)
			{
				car2.GetComponentInParent<Rigidbody>().gameObject.transform.eulerAngles += new Vector3(0f, 0.15f, 0f);
			}
			else
			{
				car2.GetComponentInParent<Rigidbody>().gameObject.transform.eulerAngles += new Vector3(0f, -0.15f, 0f);
			}
		}
	}

	private void OnTriggerExit(Collider car2)
	{
		if (car2.CompareTag("Player"))
		{
			if (!GAME_MANAGER.IN_RAIN)
			{
				car2.GetComponentInParent<Rigidbody>().angularDrag = 0.05f;
			}
			else
			{
				car2.GetComponentInParent<Rigidbody>().angularDrag = 0.1f;
			}
		}
	}
}
