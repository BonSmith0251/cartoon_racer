using UnityEngine;

public class destoy_zone : MonoBehaviour
{
	private float SCORE;

	public bool V2;

	private void OnTriggerStay(Collider car2)
	{
		if (!car2.CompareTag("Player") || !GAME_MANAGER.PLAYER_DESTROY_)
		{
			return;
		}
		if (SCORE < 0.3f)
		{
			if (!V2)
			{
				SCORE += Time.deltaTime / 15f;
			}
			else
			{
				SCORE += Time.deltaTime / 20f;
			}
		}
		if (SCORE >= 0.3f)
		{
			MISSION_MANAGER.ADD_PROGRESS += 0.34f;
			base.gameObject.SetActive(value: false);
		}
	}
}
