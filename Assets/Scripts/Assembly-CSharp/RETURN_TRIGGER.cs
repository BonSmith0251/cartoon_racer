using UnityEngine;

public class RETURN_TRIGGER : MonoBehaviour
{
	private void OnTriggerEnter(Collider car2)
	{
		if ((car2.gameObject.tag == "Player") & !RACE_MANAGER.RETURN_ & GAME_MANAGER.IN_RACE & (RACE_MANAGER.CURRENT_CHECKPOINT_FOR_FINISH > 0))
		{
			RACE_MANAGER.RETURN_ = true;
		}
	}
}
