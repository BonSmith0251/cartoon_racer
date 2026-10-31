using UnityEngine;

public class GEAR_PICKUP : MonoBehaviour
{
	public GameObject FX;

	private void OnTriggerEnter(Collider car2)
	{
		if (!car2.CompareTag("Player"))
		{
			return;
		}
		GameObject gameObject = Object.Instantiate(FX, base.transform.position, base.transform.rotation);
		if (GAME_MANAGER.MORE_GEAR == 1)
		{
			ES2.Save(ES2.Load<int>("PLAYER_GEAR") + 2, "PLAYER_GEAR");
		}
		else
		{
			ES2.Save(ES2.Load<int>("PLAYER_GEAR") + 1, "PLAYER_GEAR");
		}
		GAME_MANAGER.GET_GEAR = true;
		if (ES2.Load<string>("DAILY_MISSION_1_TYPE") == "COLLECT_DETAILS" && ES2.Load<int>("DAILY_MISSION_1") < ES2.Load<int>("DAILY_MISSION_1_NEED"))
		{
			ES2.Save(ES2.Load<int>("DAILY_MISSION_1") + 1, "DAILY_MISSION_1");
			if (ES2.Load<int>("DAILY_MISSION_1") == ES2.Load<int>("DAILY_MISSION_1_NEED"))
			{
				GAME_MANAGER.DTAST_COMPELTE = true;
			}
		}
		Object.Destroy(base.gameObject);
	}

	private void OnCollisionStay(Collision collision)
	{
		if (base.transform.position.y > 35f)
		{
			base.transform.Translate(Vector3.up * 2000f * Time.deltaTime);
			base.transform.Translate(Vector3.forward * 2000f * Time.deltaTime);
		}
	}
}
