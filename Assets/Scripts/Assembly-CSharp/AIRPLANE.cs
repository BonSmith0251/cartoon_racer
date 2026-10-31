using UnityEngine;

public class AIRPLANE : MonoBehaviour
{
	public int yy;

	private void Update()
	{
		Quaternion quaternion = Quaternion.AngleAxis((float)yy * Time.deltaTime, Vector3.up);
		base.gameObject.transform.localRotation *= quaternion;
		base.transform.Translate(Vector3.forward * 25f * Time.deltaTime);
	}
}
