using UnityEngine;

public class TRAFFIC_TRIGGER : MonoBehaviour
{
	public GameObject POINT;

	private void OnTriggerEnter(Collider car2)
	{
		if (car2.CompareTag("Player") & !TRAFFIC_MANAGER.CREATE_ROAD)
		{
			TRAFFIC_MANAGER.CREATE_ROAD = true;
			TRAFFIC_MANAGER.ROAD_POINT_Z = POINT.transform.position.z;
			base.enabled = false;
		}
	}
}
