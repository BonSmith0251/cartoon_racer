using UnityEngine;

public class WATER_QUALITY : MonoBehaviour
{
	public GameObject WATER_LOW;

	public GameObject WATER_MED;

	public GameObject WATER_HIGH;

	public GameObject WATER_MAX;

	private void Awake()
	{
		if (ES2.Load<int>("WATER_QUALITY") == 0)
		{
			WATER_LOW.SetActive(value: true);
		}
		if (ES2.Load<int>("WATER_QUALITY") == 1)
		{
			WATER_MED.SetActive(value: true);
		}
		if (ES2.Load<int>("WATER_QUALITY") == 2)
		{
			WATER_HIGH.SetActive(value: true);
		}
		if (ES2.Load<int>("WATER_QUALITY") == 3)
		{
			WATER_MAX.SetActive(value: true);
		}
	}
}
