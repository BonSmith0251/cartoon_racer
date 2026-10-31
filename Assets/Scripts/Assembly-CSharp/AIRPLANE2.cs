using UnityEngine;

public class AIRPLANE2 : MonoBehaviour
{
	public int yy;

	private void Update()
	{
		base.transform.Translate(Vector3.forward * 25f * Time.deltaTime);
	}
}
