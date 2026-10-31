using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("BoneCracker Games/Realistic Car Controller/AI/RCC AI Waypoints Container")]
public class RCC_AIWaypointsContainer : MonoBehaviour
{
	public enum Type
	{
		FollowWaypoints,
		ChaseThisObject
	}

	public Type type;

	public List<Transform> waypoints = new List<Transform>();

	public Transform target;

	private void OnDrawGizmos()
	{
		for (int i = 0; i < waypoints.Count; i++)
		{
			if (i < waypoints.Count - 1 && (bool)waypoints[i] && (bool)waypoints[i + 1] && waypoints.Count > 0)
			{
				Gizmos.color = Color.green;
				if (i < waypoints.Count - 1)
				{
					Gizmos.DrawLine(waypoints[i].position, waypoints[i + 1].position);
				}
				if (i < waypoints.Count - 2)
				{
					Gizmos.DrawLine(waypoints[waypoints.Count - 1].position, waypoints[0].position);
				}
			}
		}
	}
}
