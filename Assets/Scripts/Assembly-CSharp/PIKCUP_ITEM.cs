using UnityEngine;

public class PIKCUP_ITEM : MonoBehaviour
{
	public float PROGRESS_ADD;

	public AudioClip SND;

	public AudioClip SND_2;

	public bool IS_SPEED_POINT;

	public bool NEED_SPEED;

	public bool BURGERS_;

	public GameObject BURG_HIDE;

	private void OnTriggerEnter(Collider car2)
	{
		if (!car2.CompareTag("Player"))
		{
			return;
		}
		if (BURGERS_)
		{
			MISSION_MANAGER.ADD_PROGRESS += PROGRESS_ADD;
			AudioSource.PlayClipAtPoint(SND, Camera.main.transform.position);
			base.gameObject.GetComponent<MeshRenderer>().enabled = true;
			base.gameObject.GetComponent<BoxCollider>().enabled = false;
			BURG_HIDE.SetActive(value: false);
			return;
		}
		if (!IS_SPEED_POINT & !NEED_SPEED)
		{
			MISSION_MANAGER.ADD_PROGRESS += PROGRESS_ADD;
			AudioSource.PlayClipAtPoint(SND, Camera.main.transform.position);
			base.gameObject.SetActive(value: false);
		}
		if (IS_SPEED_POINT)
		{
			if (RCC_CarControllerV3.SPEED >= GAME_MANAGER.PLAYER_MAXIMUM_NITRO - 5f)
			{
				MISSION_MANAGER.ADD_PROGRESS += PROGRESS_ADD;
				AudioSource.PlayClipAtPoint(SND, Camera.main.transform.position);
				base.gameObject.SetActive(value: false);
			}
			else
			{
				AudioSource.PlayClipAtPoint(SND_2, Camera.main.transform.position);
			}
		}
		if (NEED_SPEED && RCC_CarControllerV3.SPEED >= GAME_MANAGER.PLAYER_MAXIMUM_NITRO - 30f)
		{
			MISSION_MANAGER.ADD_PROGRESS += PROGRESS_ADD;
			AudioSource.PlayClipAtPoint(SND, Camera.main.transform.position);
			base.gameObject.SetActive(value: false);
		}
	}
}
