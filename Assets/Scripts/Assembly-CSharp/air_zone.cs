using UnityEngine;

public class air_zone : MonoBehaviour
{
	private float SCORE;

	public bool V2;

	private void OnTriggerStay(Collider car2)
	{
		if (!car2.CompareTag("Player") || !GAME_MANAGER.IN_AIR)
		{
			return;
		}
		if (SCORE < 0.2f)
		{
			if (!V2)
			{
				SCORE += Time.deltaTime / 10f;
			}
			else
			{
				SCORE += Time.deltaTime / 25f;
			}
		}
		if (SCORE >= 0.2f)
		{
			MISSION_MANAGER.ADD_PROGRESS += 0.2f;
			base.gameObject.SetActive(value: false);
		}
	}
}
