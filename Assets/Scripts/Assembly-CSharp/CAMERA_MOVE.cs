using UnityEngine;

public class CAMERA_MOVE : MonoBehaviour
{
	private void LateUpdate()
	{
		if (!VILLY_MANAGMENT.END_GAME)
		{
			base.transform.Translate(Vector3.right * Time.deltaTime * 15f);
		}
	}
}
