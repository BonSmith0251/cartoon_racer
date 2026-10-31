using UnityEngine;

public class CAR_MOVE : MonoBehaviour
{
	private void Update()
	{
		base.transform.Translate(Vector3.forward * Time.deltaTime * 12f);
	}
}
