using SickscoreGames.HUDNavigationSystem;
using UnityEngine;

public class TRAIL_CONTROLLER : MonoBehaviour
{
	public GameObject CHECK_;

	public GameObject COP_LIGHT;

	public TrailRenderer TRAIL1;

	public TrailRenderer TRAIL2;

	public HNSMapProfile FARM_MAP;

	public HNSMapProfile CITY_MAP;

	private void Awake()
	{
		if (Application.loadedLevel == 1)
		{
			if (MENU_MANAGER.LOADING_LEVEL == 0)
			{
				base.gameObject.GetComponent<HUDNavigationSystem>().minimapProfile = FARM_MAP;
			}
			else
			{
				base.gameObject.GetComponent<HUDNavigationSystem>().minimapProfile = CITY_MAP;
			}
			base.gameObject.GetComponent<HUDNavigationSystem>().minimapScale = 0.9f;
			base.gameObject.GetComponent<HUDNavigationSystem>().minimapRadius = 100f;
			base.gameObject.GetComponent<HUDNavigationSystem>().enabled = true;
		}
		if (Application.loadedLevel == 5)
		{
			base.gameObject.GetComponent<HUDNavigationSystem>().useMinimap = false;
			base.gameObject.GetComponent<HUDNavigationSystem>().enabled = true;
		}
		if (Application.loadedLevel == 0)
		{
			base.gameObject.GetComponent<Rigidbody>().constraints = (RigidbodyConstraints)10;
			base.gameObject.GetComponent<Rigidbody>().constraints = (RigidbodyConstraints)80;
		}
		TRAIL1.emitting = false;
		TRAIL2.emitting = false;
	}

	private void Update()
	{
		if (RCC_CarControllerV3.BOOST_)
		{
			TRAIL1.emitting = true;
			TRAIL2.emitting = true;
		}
		else
		{
			TRAIL1.emitting = false;
			TRAIL2.emitting = false;
		}
		if (GAME_MANAGER.IN_RACE)
		{
			CHECK_.SetActive(value: true);
		}
		else
		{
			CHECK_.SetActive(value: false);
		}
	}
}
