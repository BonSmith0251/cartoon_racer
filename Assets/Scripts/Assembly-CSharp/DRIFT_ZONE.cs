using UnityEngine;

public class DRIFT_ZONE : MonoBehaviour
{
	private float SCORE;

	public bool V2;

	private void OnTriggerStay(Collider car2)
	{
		if (!car2.CompareTag("Player") || !GAME_MANAGER.IN_DRIFT)
		{
			return;
		}
		if (SCORE < 0.34f)
		{
			if (!V2)
			{
				SCORE += Time.deltaTime / 50f;
			}
			else
			{
				SCORE += Time.deltaTime / 100f;
			}
		}
		if (SCORE >= 0.34f)
		{
			MISSION_MANAGER.ADD_PROGRESS += 0.34f;
			base.gameObject.SetActive(value: false);
		}
	}
}
