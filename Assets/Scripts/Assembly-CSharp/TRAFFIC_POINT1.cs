using UnityEngine;

public class TRAFFIC_POINT1 : MonoBehaviour
{
	public GameObject[] TRAFFIC_CARS;

	public int CURRENT_WAYPOINT;

	public bool WAYPOINT_LINE1;

	public bool WAYPOINT_LINE2;

	private bool create;

	private int RND;

	private void Start()
	{
		RND = Random.Range(0, 9);
		if (RND == 1)
		{
			GameObject gameObject = Object.Instantiate(TRAFFIC_CARS[Random.Range(0, TRAFFIC_CARS.Length)], base.gameObject.transform.position - new Vector3(0f, 1f, 0f), base.gameObject.transform.rotation);
			gameObject.GetComponent<AI_Traffic_Car_PRO>().currentWaypoint = base.gameObject.GetComponent<TRAFFIC_POINT>().CURRENT_WAYPOINT;
			if (base.gameObject.GetComponent<TRAFFIC_POINT>().WAYPOINT_LINE1)
			{
				gameObject.GetComponent<AI_Traffic_Car_PRO>().WAYPOINTS_ = WAYPOINTS_S.FORWARD_1;
			}
			if (base.gameObject.GetComponent<TRAFFIC_POINT>().WAYPOINT_LINE2)
			{
				gameObject.GetComponent<AI_Traffic_Car_PRO>().WAYPOINTS_ = WAYPOINTS_S.BACKWARD_1;
			}
		}
	}
}
