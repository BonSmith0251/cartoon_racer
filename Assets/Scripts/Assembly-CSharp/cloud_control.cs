using UnityEngine;

public class cloud_control : MonoBehaviour
{
	private float rot;

	private void Start()
	{
	}

	private void LateUpdate()
	{
		rot += Time.deltaTime * 2f;
		base.transform.eulerAngles = new Vector3(18f, rot, 0f);
	}
}
