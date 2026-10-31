using UnityEngine;

public class DISTANCE_DESTROYER : MonoBehaviour
{
	public GameObject START;

	private float distance;

	private void Update()
	{
		if (Time.frameCount % 150 == 0)
		{
			distance = Vector3.Distance(START.transform.position, Camera.main.transform.position);
			if (distance > 900f)
			{
				Object.Destroy(base.gameObject);
			}
		}
	}
}
