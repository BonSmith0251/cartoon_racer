using UnityEngine;

public class NAME_POS : MonoBehaviour
{
	private void Update()
	{
		base.transform.rotation = Quaternion.LookRotation(base.transform.position - Camera.main.transform.position, Vector3.up);
	}
}
