using UnityEngine;

public class Sea_TRIGGER : MonoBehaviour
{
	public AudioSource AUDIOSOURCE_;

	private void OnTriggerEnter(Collider car2)
	{
		if (car2.CompareTag("Player"))
		{
			AUDIOSOURCE_.enabled = true;
		}
	}

	private void OnTriggerExit(Collider car2)
	{
		if (car2.CompareTag("Player"))
		{
			AUDIOSOURCE_.enabled = false;
		}
	}
}
