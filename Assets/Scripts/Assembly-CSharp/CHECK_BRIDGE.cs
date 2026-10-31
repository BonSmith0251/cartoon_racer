using UnityEngine;

public class CHECK_BRIDGE : MonoBehaviour
{
	private void OnEnable()
	{
		if (GAME_MANAGER.PLAYER_LEVEL > 9)
		{
			Object.Destroy(base.gameObject);
		}
	}

	private void OnTriggerEnter(Collider car2)
	{
		if (car2.CompareTag("Player") && GAME_MANAGER.PLAYER_LEVEL > 9)
		{
			Object.Destroy(base.gameObject);
		}
	}
}
