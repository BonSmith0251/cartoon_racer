using UnityEngine;
using UnityEngine.UI;

public class RCC_Useless : MonoBehaviour
{
	public enum Useless
	{
		Controller,
		Behavior,
		Graphics
	}

	public Useless useless;

	private void Awake()
	{
		int value = 0;
		if (useless == Useless.Behavior)
		{
			switch (RCC_Settings.Instance.behaviorType)
			{
			case RCC_Settings.BehaviorType.Simulator:
				value = 0;
				break;
			case RCC_Settings.BehaviorType.Racing:
				value = 1;
				break;
			case RCC_Settings.BehaviorType.SemiArcade:
				value = 2;
				break;
			case RCC_Settings.BehaviorType.Drift:
				value = 3;
				break;
			case RCC_Settings.BehaviorType.Fun:
				value = 4;
				break;
			case RCC_Settings.BehaviorType.Custom:
				value = 5;
				break;
			}
		}
		if (useless == Useless.Controller)
		{
			switch (RCC_Settings.Instance.mobileController)
			{
			case RCC_Settings.MobileController.TouchScreen:
				value = 0;
				break;
			case RCC_Settings.MobileController.Gyro:
				value = 1;
				break;
			case RCC_Settings.MobileController.SteeringWheel:
				value = 2;
				break;
			case RCC_Settings.MobileController.Joystick:
				value = 3;
				break;
			}
		}
		if (useless == Useless.Graphics)
		{
			value = QualitySettings.GetQualityLevel();
		}
		GetComponent<Dropdown>().value = value;
		GetComponent<Dropdown>().RefreshShownValue();
	}
}
