using UnityEngine;

public class DISTANCE_DESTROYER2 : MonoBehaviour
{
	public bool MORE_DISTANCE;

	public GameObject START;

	private float distance;

	private int DIST;

	private void Start()
	{
		if (MORE_DISTANCE)
		{
			DIST = 500;
		}
		else
		{
			DIST = 150;
		}
	}

	private void Update()
	{
		if (Time.frameCount % 150 == 0)
		{
			distance = Vector3.Distance(START.transform.position, Camera.main.transform.position);
			if (distance > (float)DIST)
			{
				Object.Destroy(base.gameObject);
			}
		}
	}
}
