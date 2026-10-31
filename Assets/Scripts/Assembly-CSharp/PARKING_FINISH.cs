using UnityEngine;

public class PARKING_FINISH : MonoBehaviour
{
	private void OnTriggerStay(Collider car2)
	{
		if ((car2.gameObject.tag == "Player") & (RCC_CarControllerV3.SPEED < 5f) & !SCHOOL_MANAGER.FINISH)
		{
			SCHOOL_MANAGER.FINISH = true;
		}
	}
}
