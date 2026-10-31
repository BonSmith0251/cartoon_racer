using UnityEngine;

public class GUARD_CHECK : MonoBehaviour
{
	public GameObject FX;

	private bool ENTER;

	private void OnTriggerEnter(Collider car2)
	{
		if (car2.CompareTag("Player") && !ENTER)
		{
			SCHOOL_MANAGER.NEED_CHECKPOINTS++;
			FX.SetActive(value: false);
			FX.SetActive(value: true);
			ENTER = true;
		}
	}
}
