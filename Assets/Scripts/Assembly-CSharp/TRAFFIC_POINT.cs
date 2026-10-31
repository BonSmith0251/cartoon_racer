using UnityEngine;

public class TRAFFIC_POINT : MonoBehaviour
{
	public GameObject[] TRAFFIC_CARS;

	public int CURRENT_WAYPOINT;

	public bool WAYPOINT_LINE1;

	public bool WAYPOINT_LINE2;

	private bool create;

	private int RND;

	private void OnTriggerEnter(Collider car2)
	{
		if (!((car2.tag == "Player") & (RCC_CarControllerV3.SPEED > 35f) & (GAME_MANAGER.TRAFFIC_CURRENT < GAME_MANAGER.TRAFFIC_MAXIMUM) & !COP_MANAGER.NEAR & !create & !GAME_MANAGER.IN_RACE))
		{
			return;
		}
		RND = Random.Range(0, 2);
		if (RND == 0)
		{
			GAME_MANAGER.TRAFFIC_CURRENT++;
			GameObject gameObject = Object.Instantiate(TRAFFIC_CARS[Random.Range(0, TRAFFIC_CARS.Length)], base.gameObject.transform.position - new Vector3(0f, 1f, 0f), base.gameObject.transform.rotation);
			gameObject.GetComponent<AI_Traffic_Car_PRO>().currentWaypoint = CURRENT_WAYPOINT;
			if (WAYPOINT_LINE1)
			{
				gameObject.GetComponent<AI_Traffic_Car_PRO>().WAYPOINTS_ = WAYPOINTS_S.FORWARD_1;
			}
			if (WAYPOINT_LINE2)
			{
				gameObject.GetComponent<AI_Traffic_Car_PRO>().WAYPOINTS_ = WAYPOINTS_S.BACKWARD_1;
			}
			base.gameObject.GetComponent<BoxCollider>().enabled = false;
		}
		create = true;
	}

	private void OnTriggerExit(Collider car2)
	{
		if (car2.tag == "Player")
		{
			base.gameObject.GetComponent<BoxCollider>().enabled = true;
			create = false;
		}
	}
}
