using UnityEngine;

public class CHECKPOINT_TIMEADD : MonoBehaviour
{
	private bool enter;

	public int TIME_ADD;

	private void OnTriggerEnter(Collider car2)
	{
		if ((car2.gameObject.tag == "Player") & !enter & RACE_TRIGGER._TIME_RACE & !RACE_MANAGER.FINISH_RACE)
		{
			TIME_ADD -= RACE_MANAGER.CAR_LEVEL / 5;
			if (TIME_ADD < 10)
			{
				TIME_ADD = 10;
			}
			RACE_MANAGER.sec += TIME_ADD;
			RACE_MANAGER.IN_CHECKPOINT = true;
			enter = true;
		}
	}
}
