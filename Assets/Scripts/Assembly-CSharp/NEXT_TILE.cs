using UnityEngine;

public class NEXT_TILE : MonoBehaviour
{
	private void OnTriggerEnter(Collider car2)
	{
		if (car2.gameObject.tag == "MainCamera")
		{
			VILLY_MANAGMENT.NEXT_X = base.gameObject.transform.position.x;
			VILLY_MANAGMENT.NEXT_TILE_ = true;
		}
	}
}
