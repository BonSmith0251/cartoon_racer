using UnityEngine;

public class SMOKE_ : MonoBehaviour
{
	public static int SMOKE_INT;

	public bool GENFDER;

	public GameObject SMOKE_LIGHT_;

	public GameObject SMOKE_HARD_;

	private void Start()
	{
		SMOKE_INT = 0;
		SMOKE_LIGHT_.SetActive(value: false);
		SMOKE_HARD_.SetActive(value: false);
		if (GENFDER)
		{
			COP_MANAGER.PASSENGER_GENDER = true;
		}
		else
		{
			COP_MANAGER.PASSENGER_GENDER = false;
		}
	}

	private void Update()
	{
		if (SMOKE_INT == 1)
		{
			SMOKE_LIGHT_.SetActive(value: true);
			SMOKE_HARD_.SetActive(value: false);
		}
		if (SMOKE_INT == 2)
		{
			SMOKE_LIGHT_.SetActive(value: false);
			SMOKE_HARD_.SetActive(value: true);
		}
	}
}
