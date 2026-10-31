using UnityEngine;

public class TRAFFIC_MOVE : MonoBehaviour
{
	public bool KUDA;

	private void Update()
	{
		if (Time.frameCount % 5 == 0)
		{
			base.gameObject.transform.position = new Vector3(base.gameObject.transform.position.x, 32.4f, base.gameObject.transform.position.z);
		}
		if (!KUDA)
		{
			GetComponent<Rigidbody>().velocity = Vector3.forward * 12f;
		}
		else
		{
			GetComponent<Rigidbody>().velocity = Vector3.back * 12f;
		}
	}
}
