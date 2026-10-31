using UnityEngine;

public class DEVIL : MonoBehaviour
{
	private void OnTriggerEnter(Collider car2)
	{
		if (car2.CompareTag("Player"))
		{
			GAME_MANAGER.DEVIL_TIMER = 10f;
			base.gameObject.GetComponent<AudioSource>().enabled = true;
			if (!base.gameObject.GetComponent<AudioSource>().isPlaying)
			{
				base.gameObject.GetComponent<AudioSource>().Play();
			}
			base.gameObject.GetComponent<MeshRenderer>().enabled = false;
		}
	}

	private void OnTriggerExit(Collider car2)
	{
		if (car2.CompareTag("Player"))
		{
			base.gameObject.SetActive(value: true);
			base.gameObject.GetComponent<MeshRenderer>().enabled = true;
		}
	}
}
