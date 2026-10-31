using UnityEngine;

public class TRAFFIC_DESTROY : MonoBehaviour
{
	private float distance;

	private void Update()
	{
		if (Time.frameCount % 500 == 0)
		{
			distance = Vector3.Distance(Camera.main.transform.position, base.gameObject.transform.position);
		}
		if (distance > 300f)
		{
			GAME_MANAGER.TRAFFIC_CURRENT--;
			if (GAME_MANAGER.TRAFFIC_CURRENT < 0)
			{
				GAME_MANAGER.TRAFFIC_CURRENT = 0;
			}
			Object.Destroy(base.gameObject);
		}
	}
}
