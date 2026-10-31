using UnityEngine;
using UnityEngine.UI;

[AddComponentMenu("BoneCracker Games/Realistic Car Controller/UI/RCC UI Dashboard Button")]
public class RCC_UIDashboardButton : MonoBehaviour
{
	public enum ButtonType
	{
		Start,
		ABS,
		ESP,
		TCS,
		Headlights,
		LeftIndicator,
		RightIndicator,
		Gear,
		Low,
		Med,
		High,
		SH,
		GearUp,
		GearDown,
		HazardLights,
		SlowMo,
		Record,
		Replay,
		Neutral
	}

	public ButtonType _buttonType;

	private Scrollbar gearSlider;

	public int gearDirection;

	private void Start()
	{
		if (_buttonType == ButtonType.Gear && (bool)GetComponentInChildren<Scrollbar>())
		{
			gearSlider = GetComponentInChildren<Scrollbar>();
			gearSlider.onValueChanged.AddListener(delegate
			{
				ChangeGear();
			});
		}
	}

	private void OnEnable()
	{
		Check();
	}

	public void Check()
	{
		if (!GetComponent<Image>() || !RCC_SceneManager.Instance.activePlayerVehicle)
		{
			return;
		}
		switch (_buttonType)
		{
		case ButtonType.ABS:
			if (RCC_SceneManager.Instance.activePlayerVehicle.ABS)
			{
				GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
			}
			else
			{
				GetComponent<Image>().color = new Color(0.25f, 0.25f, 0.25f, 1f);
			}
			break;
		case ButtonType.ESP:
			if (RCC_SceneManager.Instance.activePlayerVehicle.ESP)
			{
				GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
			}
			else
			{
				GetComponent<Image>().color = new Color(0.25f, 0.25f, 0.25f, 1f);
			}
			break;
		case ButtonType.TCS:
			if (RCC_SceneManager.Instance.activePlayerVehicle.TCS)
			{
				GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
			}
			else
			{
				GetComponent<Image>().color = new Color(0.25f, 0.25f, 0.25f, 1f);
			}
			break;
		case ButtonType.SH:
			if (RCC_SceneManager.Instance.activePlayerVehicle.steeringHelper)
			{
				GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
			}
			else
			{
				GetComponent<Image>().color = new Color(0.25f, 0.25f, 0.25f, 1f);
			}
			break;
		case ButtonType.Headlights:
			if (RCC_SceneManager.Instance.activePlayerVehicle.lowBeamHeadLightsOn || RCC_SceneManager.Instance.activePlayerVehicle.highBeamHeadLightsOn)
			{
				GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
			}
			else
			{
				GetComponent<Image>().color = new Color(0.25f, 0.25f, 0.25f, 1f);
			}
			break;
		}
	}

	public void ChangeGear()
	{
		if ((bool)RCC_SceneManager.Instance.activePlayerVehicle && gearDirection != Mathf.CeilToInt(gearSlider.value * 2f))
		{
			gearDirection = Mathf.CeilToInt(gearSlider.value * 2f);
			RCC_SceneManager.Instance.activePlayerVehicle.semiAutomaticGear = true;
			switch (gearDirection)
			{
			case 0:
				RCC_SceneManager.Instance.activePlayerVehicle.StartCoroutine("ChangeGear", 0);
				RCC_SceneManager.Instance.activePlayerVehicle.NGear = false;
				break;
			case 1:
				RCC_SceneManager.Instance.activePlayerVehicle.NGear = true;
				break;
			case 2:
				RCC_SceneManager.Instance.activePlayerVehicle.StartCoroutine("ChangeGear", -1);
				RCC_SceneManager.Instance.activePlayerVehicle.NGear = false;
				break;
			}
		}
	}

	private void OnDisable()
	{
	}
}
