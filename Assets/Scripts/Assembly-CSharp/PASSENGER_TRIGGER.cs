using UnityEngine;

public class PASSENGER_TRIGGER : MonoBehaviour
{
	public GameObject OBJ;

	public bool IS_TARGET;

	public bool MAN;

	private void OnTriggerStay(Collider car2)
	{
		if (!((car2.tag == "Player") & (RCC_CarControllerV3.SPEED < 15f)))
		{
			return;
		}
		if (IS_TARGET)
		{
			MEDIC_MANAGER.PASSENGER_COMPLETE = true;
			TAXI_MANAGER.PASSENGER_COMPLETE = true;
		}
		else
		{
			MEDIC_MANAGER.PASSENGER_PICKUP = true;
			TAXI_MANAGER.PASSENGER_PICKUP = true;
			if (MAN)
			{
				MEDIC_MANAGER.PASSENGER_GENDER = true;
				TAXI_MANAGER.PASSENGER_GENDER = true;
			}
			else
			{
				MEDIC_MANAGER.PASSENGER_GENDER = false;
				TAXI_MANAGER.PASSENGER_GENDER = false;
			}
		}
		Object.Destroy(OBJ);
	}
}
