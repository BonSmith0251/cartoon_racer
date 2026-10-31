using UnityEngine;

public class rotate : MonoBehaviour
{
	public Vector3 rotation;

	private void Update()
	{
		base.transform.Rotate(rotation * Time.deltaTime, Space.World);
	}
}
