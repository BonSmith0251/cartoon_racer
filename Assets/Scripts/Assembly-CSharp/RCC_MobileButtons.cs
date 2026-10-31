using UnityEngine;
using UnityEngine.UI;

[AddComponentMenu("BoneCracker Games/Realistic Car Controller/UI/Mobile/RCC UI Mobile Buttons")]
public class RCC_MobileButtons : MonoBehaviour
{
	private RCC_Settings RCCSettingsInstance;

	public RCC_UIController gasButton;

	public RCC_UIController gradualGasButton;

	public RCC_UIController brakeButton;

	public RCC_UIController leftButton;

	public RCC_UIController rightButton;

	public RCC_UISteeringWheelController steeringWheel;

	public RCC_UIController handbrakeButton;

	public RCC_UIController NOSButton;

	public RCC_UIController NOSButtonSteeringWheel;

	public RCC_UIDrag drag;

	public GameObject gearButton;

	public RCC_UIJoystick joystick;

	private float gasInput;

	private float brakeInput;

	private float leftInput;

	private float rightInput;

	private float steeringWheelInput;

	private float handbrakeInput;

	private float NOSInput = 1f;

	private float gyroInput;

	private float joystickInput;

	private bool canUseNos;

	public Image BRAKE_ORG;

	public Image BRAKE_GYRO;

	private RCC_Settings RCCSettings
	{
		get
		{
			if (RCCSettingsInstance == null)
			{
				RCCSettingsInstance = RCC_Settings.Instance;
			}
			return RCCSettingsInstance;
		}
	}

	private void Start()
	{
		if (RCCSettings.controllerType != RCC_Settings.ControllerType.Mobile)
		{
			base.enabled = false;
		}
	}

	private void Update()
	{
		switch (RCCSettings.mobileController)
		{
		case RCC_Settings.MobileController.TouchScreen:
			gyroInput = 0f;
			if ((bool)steeringWheel && steeringWheel.gameObject.activeInHierarchy)
			{
				steeringWheel.gameObject.SetActive(value: false);
			}
			if ((bool)joystick && joystick.gameObject.activeInHierarchy)
			{
				joystick.gameObject.SetActive(value: false);
			}
			if (!leftButton.gameObject.activeInHierarchy)
			{
				brakeButton.transform.position = BRAKE_ORG.transform.position;
				leftButton.gameObject.SetActive(value: true);
			}
			if (!rightButton.gameObject.activeInHierarchy)
			{
				rightButton.gameObject.SetActive(value: true);
			}
			break;
		case RCC_Settings.MobileController.Gyro:
			gyroInput = Input.acceleration.x * RCCSettings.gyroSensitivity;
			brakeButton.transform.position = BRAKE_GYRO.transform.position;
			if (steeringWheel.gameObject.activeInHierarchy)
			{
				steeringWheel.gameObject.SetActive(value: false);
			}
			if ((bool)joystick && joystick.gameObject.activeInHierarchy)
			{
				joystick.gameObject.SetActive(value: false);
			}
			if (leftButton.gameObject.activeInHierarchy)
			{
				leftButton.gameObject.SetActive(value: false);
			}
			if (rightButton.gameObject.activeInHierarchy)
			{
				rightButton.gameObject.SetActive(value: false);
			}
			break;
		case RCC_Settings.MobileController.SteeringWheel:
			gyroInput = 0f;
			if (!steeringWheel.gameObject.activeInHierarchy)
			{
				steeringWheel.gameObject.SetActive(value: true);
				brakeButton.transform.position = BRAKE_ORG.transform.position;
			}
			if ((bool)joystick && joystick.gameObject.activeInHierarchy)
			{
				joystick.gameObject.SetActive(value: false);
			}
			if (leftButton.gameObject.activeInHierarchy)
			{
				leftButton.gameObject.SetActive(value: false);
			}
			if (rightButton.gameObject.activeInHierarchy)
			{
				rightButton.gameObject.SetActive(value: false);
			}
			break;
		case RCC_Settings.MobileController.Joystick:
			gyroInput = 0f;
			if ((bool)steeringWheel && steeringWheel.gameObject.activeInHierarchy)
			{
				steeringWheel.gameObject.SetActive(value: false);
			}
			if ((bool)NOSButton && NOSButton.gameObject.activeInHierarchy != canUseNos)
			{
				NOSButton.gameObject.SetActive(canUseNos);
			}
			if ((bool)joystick && !joystick.gameObject.activeInHierarchy)
			{
				joystick.gameObject.SetActive(value: true);
			}
			if (leftButton.gameObject.activeInHierarchy)
			{
				leftButton.gameObject.SetActive(value: false);
			}
			if (rightButton.gameObject.activeInHierarchy)
			{
				rightButton.gameObject.SetActive(value: false);
			}
			break;
		}
		gasInput = GetInput(gasButton) + GetInput(gradualGasButton);
		brakeInput = GetInput(brakeButton);
		leftInput = GetInput(leftButton);
		rightInput = GetInput(rightButton);
		handbrakeInput = GetInput(handbrakeButton);
		NOSInput = Mathf.Clamp((GetInput(NOSButton) + GetInput(NOSButtonSteeringWheel)) * 2.5f, 1f, 2.5f);
		if (TRAFFIC_MANAGER.TRAFFIC_MODE && ((brakeInput > 0f) & (RCC_CarControllerV3.SPEED < 65f)))
		{
			brakeInput = 0f;
			handbrakeInput = 0f;
		}
		if ((bool)steeringWheel)
		{
			steeringWheelInput = steeringWheel.input;
		}
		if ((bool)joystick)
		{
			joystickInput = joystick.inputHorizontal;
		}
		if ((bool)RCC_SceneManager.Instance.activePlayerVehicle)
		{
			canUseNos = RCC_SceneManager.Instance.activePlayerVehicle.useNOS;
			if (RCC_SceneManager.Instance.activePlayerVehicle.canControl && !RCC_SceneManager.Instance.activePlayerVehicle.externalController)
			{
				RCC_SceneManager.Instance.activePlayerVehicle.gasInput = gasInput;
				RCC_SceneManager.Instance.activePlayerVehicle.brakeInput = brakeInput;
				RCC_SceneManager.Instance.activePlayerVehicle.steerInput = 0f - leftInput + rightInput + steeringWheelInput + gyroInput + joystickInput;
				RCC_SceneManager.Instance.activePlayerVehicle.handbrakeInput = handbrakeInput;
				RCC_SceneManager.Instance.activePlayerVehicle.boostInput = NOSInput;
			}
		}
	}

	private float GetInput(RCC_UIController button)
	{
		if (button == null)
		{
			return 0f;
		}
		return button.input;
	}

	public void SetMobileController(int index)
	{
		switch (index)
		{
		case 0:
			RCC.SetMobileController(RCC_Settings.MobileController.TouchScreen);
			break;
		case 1:
			RCC.SetMobileController(RCC_Settings.MobileController.Gyro);
			break;
		case 2:
			RCC.SetMobileController(RCC_Settings.MobileController.SteeringWheel);
			break;
		case 3:
			RCC.SetMobileController(RCC_Settings.MobileController.Joystick);
			break;
		}
	}

	public void SetQuality(int index)
	{
		QualitySettings.SetQualityLevel(index);
	}

	public void ChangeCamera()
	{
		if ((bool)RCC_SceneManager.Instance.activePlayerCamera)
		{
			RCC_SceneManager.Instance.activePlayerCamera.ChangeCamera();
		}
	}
}
