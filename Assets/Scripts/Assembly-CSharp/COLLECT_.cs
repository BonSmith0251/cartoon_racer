using UnityEngine;

public class COLLECT_ : MonoBehaviour
{
	public AudioClip AUDIOSOURCE_;

	public GameObject FX_;

	private void OnTriggerEnter(Collider car2)
	{
		if (car2.CompareTag("Player") & !VILLY_MANAGMENT.END_GAME)
		{
			VILLY_MANAGMENT.PIKCIP_MONEY = true;
			GameObject gameObject = Object.Instantiate(FX_, base.transform.position, base.transform.rotation);
			AudioSource.PlayClipAtPoint(AUDIOSOURCE_, Camera.main.transform.position);
			base.gameObject.SetActive(value: false);
		}
	}
}
