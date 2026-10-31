using UnityEngine;

public class TRAFFIC_DESTROYS : MonoBehaviour
{
	private float distance;

	private void Update()
	{
		if (Time.frameCount % 200 == 0 && base.transform.position.z < Camera.main.transform.position.z - 70f)
		{
			Object.Destroy(base.gameObject);
		}
	}
}
