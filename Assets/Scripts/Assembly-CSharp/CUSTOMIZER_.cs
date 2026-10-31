using TMPro;
using UnityEngine;

public class CUSTOMIZER_ : MonoBehaviour
{
	public int CAR_INDEX;

	private string STR;

	private string STR2;

	private string STR3;

	private string STR4;

	private string STR5;

	private string STR6;

	private string STR7;

	private int LOAD_FRONT;

	private int LOAD_BACK;

	private int LOAD_MIDDLE;

	private int LOAD_WHEELS;

	private int LOAD_CAMBER;

	private int LOAD_LIGHT;

	public TextMeshPro CARNAME;

	public TextMeshPro CARNAME2;

	public Mesh[] _FRONT;

	public Mesh[] _MIDDLE;

	public Mesh[] _BACK;

	public Mesh[] WHEELS_R;

	public Mesh[] WHEELS_L;

	public GameObject CAR_FRONT;

	public GameObject CAR_MIDDLE;

	public GameObject CAR_BACK;

	public GameObject CAR_WHEEL_L;

	public GameObject CAR_WHEEL_L2;

	public GameObject CAR_WHEEL_R;

	public GameObject CAR_WHEEL_R2;

	private int SET_FRONT;

	private int SET_BACK;

	private int SET_MIDDLE;

	private int SET_WHEELS;

	public GameObject SHADOW;

	public GameObject LIGHT;

	private int IN_1;

	private int IN_2;

	private int IN_3;

	public void CHANGE_NAME(string NAME)
	{
		if (CARNAME != null)
		{
			CARNAME.text = NAME;
		}
		if (CARNAME2 != null)
		{
			CARNAME2.text = NAME;
		}
	}

	public void CHANGE_LIGHT(bool WHITE, bool GREEN, bool YELLOW, bool RED, bool ORANGE, bool BLUE, bool PINK, bool OFF)
	{
		if (WHITE)
		{
			LIGHT.GetComponent<Projector>().material.SetColor("_Color", new Color(1f, 1f, 1f, 1f));
		}
		if (GREEN)
		{
			LIGHT.GetComponent<Projector>().material.SetColor("_Color", new Color(0f, 1f, 0f, 1f));
		}
		if (YELLOW)
		{
			LIGHT.GetComponent<Projector>().material.SetColor("_Color", new Color(1f, 1f, 0f, 1f));
		}
		if (RED)
		{
			LIGHT.GetComponent<Projector>().material.SetColor("_Color", new Color(1f, 0f, 0f, 1f));
		}
		if (ORANGE)
		{
			LIGHT.GetComponent<Projector>().material.SetColor("_Color", new Color(1f, 0.5f, 0f, 1f));
		}
		if (BLUE)
		{
			LIGHT.GetComponent<Projector>().material.SetColor("_Color", new Color(0f, 0f, 1f, 1f));
		}
		if (PINK)
		{
			LIGHT.GetComponent<Projector>().material.SetColor("_Color", new Color(1f, 0f, 1f, 1f));
		}
		if (OFF)
		{
			LIGHT.GetComponent<Projector>().material.SetColor("_Color", new Color(0f, 0f, 0f, 1f));
		}
	}

	public void SHOW_LIGHT()
	{
		SHADOW.SetActive(value: false);
		LIGHT.SetActive(value: true);
		IN_1 = 0;
		IN_2 = 0;
		IN_3 = 0;
		IN_1 = MENU_MANAGER.SPAWN_CAR_ + 1;
		IN_2 = MENU_MANAGER.SPAWN_CAR_ + 1;
		IN_3 = MENU_MANAGER.SPAWN_CAR_ + 1;
		string identifier = "CAR" + IN_1 + "_LIGHT_R";
		string identifier2 = "CAR" + IN_2 + "_LIGHT_G";
		string identifier3 = "CAR" + IN_3 + "_LIGHT_B";
		float r = ES2.Load<float>(identifier);
		float g = ES2.Load<float>(identifier2);
		float b = ES2.Load<float>(identifier3);
		LIGHT.GetComponent<Projector>().material.SetColor("_Color", new Color(r, g, b, 1f));
	}

	public void SHOW_SHADOW()
	{
		SHADOW.SetActive(value: true);
		LIGHT.SetActive(value: false);
	}

	public void APPLY()
	{
		STR = null;
		STR2 = null;
		STR3 = null;
		STR4 = null;
		STR = "CAR" + CAR_INDEX + "_FRONT";
		STR2 = "CAR" + CAR_INDEX + "_BACK";
		STR3 = "CAR" + CAR_INDEX + "_MIDDLE";
		STR4 = "CAR" + CAR_INDEX + "_WHEELS";
		ES2.Save(SET_FRONT, STR);
		ES2.Save(SET_BACK, STR2);
		ES2.Save(SET_MIDDLE, STR3);
		ES2.Save(SET_WHEELS, STR4);
	}

	public void LOAD_NAME()
	{
		STR7 = "CAR" + CAR_INDEX + "_NAME";
		if (CARNAME != null)
		{
			CARNAME.text = ES2.Load<string>(STR7);
		}
		if (CARNAME2 != null)
		{
			CARNAME2.text = ES2.Load<string>(STR7);
		}
	}

	private void Start()
	{
		if (Application.loadedLevel == 5)
		{
			base.enabled = false;
			return;
		}
		STR6 = "CAR" + CAR_INDEX + "_LIGHT";
		LOAD_LIGHT = ES2.Load<int>(STR6);
		if (LOAD_LIGHT == 1)
		{
			SHOW_LIGHT();
		}
		else
		{
			SHOW_SHADOW();
		}
		STR5 = "CAR" + CAR_INDEX + "_CAMBER";
		LOAD_CAMBER = ES2.Load<int>(STR5);
		STR7 = "CAR" + CAR_INDEX + "_NAME";
		if (CARNAME != null)
		{
			CARNAME.text = ES2.Load<string>(STR7);
		}
		if (CARNAME2 != null)
		{
			CARNAME2.text = ES2.Load<string>(STR7);
		}
		base.gameObject.GetComponent<RCC_CarControllerV3>().FrontLeftWheelCollider.camber = LOAD_CAMBER;
		base.gameObject.GetComponent<RCC_CarControllerV3>().FrontRightWheelCollider.camber = LOAD_CAMBER;
		base.gameObject.GetComponent<RCC_CarControllerV3>().RearLeftWheelCollider.camber = LOAD_CAMBER;
		base.gameObject.GetComponent<RCC_CarControllerV3>().RearRightWheelCollider.camber = LOAD_CAMBER;
		if (CAR_INDEX < 9)
		{
			STR = "CAR" + CAR_INDEX + "_FRONT";
			LOAD_FRONT = ES2.Load<int>(STR);
			STR2 = "CAR" + CAR_INDEX + "_BACK";
			LOAD_BACK = ES2.Load<int>(STR2);
			STR3 = "CAR" + CAR_INDEX + "_MIDDLE";
			LOAD_MIDDLE = ES2.Load<int>(STR3);
			STR4 = "CAR" + CAR_INDEX + "_WHEELS";
			LOAD_WHEELS = ES2.Load<int>(STR4);
			if (LOAD_FRONT == 0)
			{
				SET_FRONT_1();
			}
			if (LOAD_FRONT == 1)
			{
				SET_FRONT_2();
			}
			if (LOAD_FRONT == 2)
			{
				SET_FRONT_3();
			}
			if (LOAD_FRONT == 3)
			{
				SET_FRONT_4();
			}
			if (LOAD_FRONT == 4)
			{
				SET_FRONT_5();
			}
			if (LOAD_FRONT == 5)
			{
				SET_FRONT_6();
			}
			if (LOAD_FRONT == 6)
			{
				SET_FRONT_7();
			}
			if (LOAD_BACK == 0)
			{
				SET_BACK_1();
			}
			if (LOAD_BACK == 1)
			{
				SET_BACK_2();
			}
			if (LOAD_BACK == 2)
			{
				SET_BACK_3();
			}
			if (LOAD_BACK == 3)
			{
				SET_BACK_4();
			}
			if (LOAD_BACK == 4)
			{
				SET_BACK_5();
			}
			if (LOAD_BACK == 5)
			{
				SET_BACK_6();
			}
			if (LOAD_BACK == 6)
			{
				SET_BACK_7();
			}
			if (LOAD_MIDDLE == 0)
			{
				SET_MIDDLE_1();
			}
			if (LOAD_MIDDLE == 1)
			{
				SET_MIDDLE_2();
			}
			if (LOAD_MIDDLE == 2)
			{
				SET_MIDDLE_3();
			}
			if (LOAD_MIDDLE == 3)
			{
				SET_MIDDLE_4();
			}
			if (LOAD_MIDDLE == 4)
			{
				SET_MIDDLE_5();
			}
			if (LOAD_MIDDLE == 5)
			{
				SET_MIDDLE_6();
			}
			if (LOAD_MIDDLE == 6)
			{
				SET_MIDDLE_7();
			}
			if (LOAD_WHEELS == 0)
			{
				SET_WHELLS_1();
			}
			if (LOAD_WHEELS == 1)
			{
				SET_WHELLS_2();
			}
			if (LOAD_WHEELS == 2)
			{
				SET_WHELLS_3();
			}
			if (LOAD_WHEELS == 3)
			{
				SET_WHELLS_4();
			}
			if (LOAD_WHEELS == 4)
			{
				SET_WHELLS_5();
			}
		}
	}

	public void SET_FRONT_1()
	{
		SET_FRONT = 0;
		CAR_FRONT.GetComponent<MeshFilter>().mesh = _FRONT[0];
	}

	public void SET_FRONT_2()
	{
		SET_FRONT = 1;
		CAR_FRONT.GetComponent<MeshFilter>().mesh = _FRONT[1];
	}

	public void SET_FRONT_3()
	{
		SET_FRONT = 2;
		CAR_FRONT.GetComponent<MeshFilter>().mesh = _FRONT[2];
	}

	public void SET_FRONT_4()
	{
		SET_FRONT = 3;
		CAR_FRONT.GetComponent<MeshFilter>().mesh = _FRONT[3];
	}

	public void SET_FRONT_5()
	{
		SET_FRONT = 4;
		CAR_FRONT.GetComponent<MeshFilter>().mesh = _FRONT[4];
	}

	public void SET_FRONT_6()
	{
		SET_FRONT = 5;
		CAR_FRONT.GetComponent<MeshFilter>().mesh = _FRONT[5];
	}

	public void SET_FRONT_7()
	{
		SET_FRONT = 6;
		CAR_FRONT.GetComponent<MeshFilter>().mesh = _FRONT[6];
	}

	public void SET_BACK_1()
	{
		SET_BACK = 0;
		CAR_BACK.GetComponent<MeshFilter>().mesh = _BACK[0];
	}

	public void SET_BACK_2()
	{
		SET_BACK = 1;
		CAR_BACK.GetComponent<MeshFilter>().mesh = _BACK[1];
	}

	public void SET_BACK_3()
	{
		SET_BACK = 2;
		CAR_BACK.GetComponent<MeshFilter>().mesh = _BACK[2];
	}

	public void SET_BACK_4()
	{
		SET_BACK = 3;
		CAR_BACK.GetComponent<MeshFilter>().mesh = _BACK[3];
	}

	public void SET_BACK_5()
	{
		SET_BACK = 4;
		CAR_BACK.GetComponent<MeshFilter>().mesh = _BACK[4];
	}

	public void SET_BACK_6()
	{
		SET_BACK = 5;
		CAR_BACK.GetComponent<MeshFilter>().mesh = _BACK[5];
	}

	public void SET_BACK_7()
	{
		SET_BACK = 6;
		CAR_BACK.GetComponent<MeshFilter>().mesh = _BACK[6];
	}

	public void SET_MIDDLE_1()
	{
		SET_MIDDLE = 0;
		CAR_MIDDLE.GetComponent<MeshFilter>().mesh = _MIDDLE[0];
	}

	public void SET_MIDDLE_2()
	{
		SET_MIDDLE = 1;
		CAR_MIDDLE.GetComponent<MeshFilter>().mesh = _MIDDLE[1];
	}

	public void SET_MIDDLE_3()
	{
		SET_MIDDLE = 2;
		CAR_MIDDLE.GetComponent<MeshFilter>().mesh = _MIDDLE[2];
	}

	public void SET_MIDDLE_4()
	{
		SET_MIDDLE = 3;
		CAR_MIDDLE.GetComponent<MeshFilter>().mesh = _MIDDLE[3];
	}

	public void SET_MIDDLE_5()
	{
		SET_MIDDLE = 4;
		CAR_MIDDLE.GetComponent<MeshFilter>().mesh = _MIDDLE[4];
	}

	public void SET_MIDDLE_6()
	{
		SET_MIDDLE = 5;
		CAR_MIDDLE.GetComponent<MeshFilter>().mesh = _MIDDLE[5];
	}

	public void SET_MIDDLE_7()
	{
		SET_MIDDLE = 6;
		CAR_MIDDLE.GetComponent<MeshFilter>().mesh = _MIDDLE[6];
	}

	public void SET_WHELLS_1()
	{
		SET_WHEELS = 0;
		CAR_WHEEL_L.GetComponent<MeshFilter>().mesh = WHEELS_L[0];
		CAR_WHEEL_L2.GetComponent<MeshFilter>().mesh = WHEELS_L[0];
		CAR_WHEEL_R.GetComponent<MeshFilter>().mesh = WHEELS_R[0];
		CAR_WHEEL_R2.GetComponent<MeshFilter>().mesh = WHEELS_R[0];
	}

	public void SET_WHELLS_2()
	{
		SET_WHEELS = 1;
		CAR_WHEEL_L.GetComponent<MeshFilter>().mesh = WHEELS_L[1];
		CAR_WHEEL_L2.GetComponent<MeshFilter>().mesh = WHEELS_L[1];
		CAR_WHEEL_R.GetComponent<MeshFilter>().mesh = WHEELS_R[1];
		CAR_WHEEL_R2.GetComponent<MeshFilter>().mesh = WHEELS_R[1];
	}

	public void SET_WHELLS_3()
	{
		SET_WHEELS = 2;
		CAR_WHEEL_L.GetComponent<MeshFilter>().mesh = WHEELS_L[2];
		CAR_WHEEL_L2.GetComponent<MeshFilter>().mesh = WHEELS_L[2];
		CAR_WHEEL_R.GetComponent<MeshFilter>().mesh = WHEELS_R[2];
		CAR_WHEEL_R2.GetComponent<MeshFilter>().mesh = WHEELS_R[2];
	}

	public void SET_WHELLS_4()
	{
		SET_WHEELS = 3;
		CAR_WHEEL_L.GetComponent<MeshFilter>().mesh = WHEELS_L[3];
		CAR_WHEEL_L2.GetComponent<MeshFilter>().mesh = WHEELS_L[3];
		CAR_WHEEL_R.GetComponent<MeshFilter>().mesh = WHEELS_R[3];
		CAR_WHEEL_R2.GetComponent<MeshFilter>().mesh = WHEELS_R[3];
	}

	public void SET_WHELLS_5()
	{
		SET_WHEELS = 4;
		CAR_WHEEL_L.GetComponent<MeshFilter>().mesh = WHEELS_L[4];
		CAR_WHEEL_L2.GetComponent<MeshFilter>().mesh = WHEELS_L[4];
		CAR_WHEEL_R.GetComponent<MeshFilter>().mesh = WHEELS_R[4];
		CAR_WHEEL_R2.GetComponent<MeshFilter>().mesh = WHEELS_R[4];
	}
}
