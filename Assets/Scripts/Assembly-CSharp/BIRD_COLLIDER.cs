using UnityEngine;

public class BIRD_COLLIDER : MonoBehaviour
{
	public bool DAMAGED;

	public bool BOMB;

	public GameObject FX_;

	private bool enter;

	private void OnTriggerEnter(Collider car2)
	{
		if (!car2.CompareTag("Player"))
		{
			return;
		}
		if (DAMAGED)
		{
			if (VILLY_MANAGMENT.bird_rotate == 0f)
			{
				Object.FindObjectOfType<VILLY_MANAGMENT>().END_GAME_();
				return;
			}
			base.gameObject.GetComponent<BoxCollider>().enabled = false;
			base.gameObject.GetComponentInParent<AIRPLANE_MOVE>().END_ = true;
			return;
		}
		if (BOMB && !enter)
		{
			GameObject gameObject = Object.Instantiate(FX_, base.gameObject.transform.position, base.gameObject.transform.rotation);
			enter = true;
		}
		Object.FindObjectOfType<VILLY_MANAGMENT>().END_GAME_();
	}
}
