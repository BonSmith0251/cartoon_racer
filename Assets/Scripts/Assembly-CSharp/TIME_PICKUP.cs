using UnityEngine;

public class TIME_PICKUP : MonoBehaviour
{
	public GameObject FX;

	public GameObject FX2;

	public bool IS_FUEL;

	private void OnTriggerEnter(Collider car2)
	{
		if (car2.gameObject.tag == "Player")
		{
			if (IS_FUEL)
			{
				TRAFFIC_MANAGER.ADD_FUEL = true;
				GameObject gameObject = Object.Instantiate(FX2, base.transform.position, base.transform.rotation);
			}
			else
			{
				TRAFFIC_MANAGER.ADD_TIME = true;
				GameObject gameObject2 = Object.Instantiate(FX, base.transform.position, base.transform.rotation);
			}
			Object.Destroy(base.gameObject);
		}
	}
}
