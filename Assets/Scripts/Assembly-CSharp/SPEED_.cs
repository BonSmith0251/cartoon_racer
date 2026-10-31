using UnityEngine;

public class SPEED_ : MonoBehaviour
{
	private void OnTriggerEnter(Collider car2)
	{
		if (car2.gameObject.tag == "Player")
		{
			RACE_MANAGER.IN_SPEED_CHECKPOINT = true;
			if ((RACE_MANAGER.fire_polosa < 1f) & !RACE_MANAGER.FINISH_RACE)
			{
				RACE_MANAGER.fire_polosa += 0.016f;
			}
			GameObject gameObject = Object.Instantiate(GAME_MANAGER.PICKUP_OBJ5_, base.gameObject.transform.position, base.transform.rotation);
			gameObject.transform.position += Vector3.up * 2f;
			base.gameObject.SetActive(value: false);
		}
	}
}
