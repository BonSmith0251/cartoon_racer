using TMPro;
using UnityEngine;

public class AI_TYPE_RANDOM : MonoBehaviour
{
	public TextMeshPro TEXT;

	public Material[] CAR_MATERIAL;

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

	private int RND;

	private int RND2;

	private void Start()
	{
		RND = Random.Range(0, 8);
		base.gameObject.GetComponent<MeshRenderer>().material = CAR_MATERIAL[RND];
		if (RND == 0)
		{
			CAR_FRONT.GetComponent<MeshFilter>().mesh = _FRONT[RND];
			CAR_MIDDLE.GetComponent<MeshFilter>().mesh = _MIDDLE[RND];
			CAR_BACK.GetComponent<MeshFilter>().mesh = _BACK[RND];
			CAR_WHEEL_L.GetComponent<MeshFilter>().mesh = WHEELS_L[0];
			CAR_WHEEL_L2.GetComponent<MeshFilter>().mesh = WHEELS_L[0];
			CAR_WHEEL_R.GetComponent<MeshFilter>().mesh = WHEELS_R[0];
			CAR_WHEEL_R2.GetComponent<MeshFilter>().mesh = WHEELS_R[0];
		}
		if (RND == 1)
		{
			CAR_FRONT.GetComponent<MeshFilter>().mesh = _FRONT[RND];
			CAR_MIDDLE.GetComponent<MeshFilter>().mesh = _MIDDLE[RND];
			CAR_BACK.GetComponent<MeshFilter>().mesh = _BACK[RND];
			CAR_WHEEL_L.GetComponent<MeshFilter>().mesh = WHEELS_L[2];
			CAR_WHEEL_L2.GetComponent<MeshFilter>().mesh = WHEELS_L[2];
			CAR_WHEEL_R.GetComponent<MeshFilter>().mesh = WHEELS_R[2];
			CAR_WHEEL_R2.GetComponent<MeshFilter>().mesh = WHEELS_R[2];
		}
		if (RND == 2)
		{
			CAR_FRONT.GetComponent<MeshFilter>().mesh = _FRONT[RND];
			CAR_MIDDLE.GetComponent<MeshFilter>().mesh = _MIDDLE[RND];
			CAR_BACK.GetComponent<MeshFilter>().mesh = _BACK[RND];
			CAR_WHEEL_L.GetComponent<MeshFilter>().mesh = WHEELS_L[1];
			CAR_WHEEL_L2.GetComponent<MeshFilter>().mesh = WHEELS_L[1];
			CAR_WHEEL_R.GetComponent<MeshFilter>().mesh = WHEELS_R[1];
			CAR_WHEEL_R2.GetComponent<MeshFilter>().mesh = WHEELS_R[1];
		}
		if (RND == 3)
		{
			CAR_FRONT.GetComponent<MeshFilter>().mesh = null;
			CAR_MIDDLE.GetComponent<MeshFilter>().mesh = _MIDDLE[3];
			CAR_BACK.GetComponent<MeshFilter>().mesh = _BACK[3];
			CAR_WHEEL_L.GetComponent<MeshFilter>().mesh = WHEELS_L[3];
			CAR_WHEEL_L2.GetComponent<MeshFilter>().mesh = WHEELS_L[3];
			CAR_WHEEL_R.GetComponent<MeshFilter>().mesh = WHEELS_R[3];
			CAR_WHEEL_R2.GetComponent<MeshFilter>().mesh = WHEELS_R[3];
		}
		if (RND == 4)
		{
			CAR_FRONT.GetComponent<MeshFilter>().mesh = _FRONT[5];
			CAR_MIDDLE.GetComponent<MeshFilter>().mesh = _MIDDLE[4];
			CAR_BACK.GetComponent<MeshFilter>().mesh = _BACK[5];
			CAR_WHEEL_L.GetComponent<MeshFilter>().mesh = WHEELS_L[1];
			CAR_WHEEL_L2.GetComponent<MeshFilter>().mesh = WHEELS_L[1];
			CAR_WHEEL_R.GetComponent<MeshFilter>().mesh = WHEELS_R[1];
			CAR_WHEEL_R2.GetComponent<MeshFilter>().mesh = WHEELS_R[1];
		}
		if (RND == 5)
		{
			CAR_FRONT.GetComponent<MeshFilter>().mesh = _FRONT[6];
			CAR_MIDDLE.GetComponent<MeshFilter>().mesh = _MIDDLE[7];
			CAR_BACK.GetComponent<MeshFilter>().mesh = _BACK[6];
			CAR_WHEEL_L.GetComponent<MeshFilter>().mesh = WHEELS_L[2];
			CAR_WHEEL_L2.GetComponent<MeshFilter>().mesh = WHEELS_L[2];
			CAR_WHEEL_R.GetComponent<MeshFilter>().mesh = WHEELS_R[2];
			CAR_WHEEL_R2.GetComponent<MeshFilter>().mesh = WHEELS_R[2];
		}
		if (RND == 6)
		{
			CAR_FRONT.GetComponent<MeshFilter>().mesh = _FRONT[5];
			CAR_MIDDLE.GetComponent<MeshFilter>().mesh = _MIDDLE[6];
			CAR_BACK.GetComponent<MeshFilter>().mesh = _BACK[5];
			CAR_WHEEL_L.GetComponent<MeshFilter>().mesh = WHEELS_L[4];
			CAR_WHEEL_L2.GetComponent<MeshFilter>().mesh = WHEELS_L[4];
			CAR_WHEEL_R.GetComponent<MeshFilter>().mesh = WHEELS_R[4];
			CAR_WHEEL_R2.GetComponent<MeshFilter>().mesh = WHEELS_R[4];
		}
		if (RND == 7)
		{
			CAR_FRONT.GetComponent<MeshFilter>().mesh = _FRONT[4];
			CAR_MIDDLE.GetComponent<MeshFilter>().mesh = _MIDDLE[5];
			CAR_BACK.GetComponent<MeshFilter>().mesh = _BACK[4];
			CAR_WHEEL_L.GetComponent<MeshFilter>().mesh = WHEELS_L[2];
			CAR_WHEEL_L2.GetComponent<MeshFilter>().mesh = WHEELS_L[2];
			CAR_WHEEL_R.GetComponent<MeshFilter>().mesh = WHEELS_R[2];
			CAR_WHEEL_R2.GetComponent<MeshFilter>().mesh = WHEELS_R[2];
		}
		RND2 = Random.Range(0, 33);
		if (RND2 == 0)
		{
			TEXT.text = "MIKE";
		}
		if (RND2 == 1)
		{
			TEXT.text = "JACK";
		}
		if (RND2 == 2)
		{
			TEXT.text = "MAX";
		}
		if (RND2 == 3)
		{
			TEXT.text = "ALEX";
		}
		if (RND2 == 4)
		{
			TEXT.text = "LOGAN";
		}
		if (RND2 == 5)
		{
			TEXT.text = "ETHAN";
		}
		if (RND2 == 6)
		{
			TEXT.text = "JACOB";
		}
		if (RND2 == 7)
		{
			TEXT.text = "OLIVER";
		}
		if (RND2 == 8)
		{
			TEXT.text = "WILLIAM";
		}
		if (RND2 == 9)
		{
			TEXT.text = "DANIEL";
		}
		if (RND2 == 10)
		{
			TEXT.text = "THOMAS";
		}
		if (RND2 == 11)
		{
			TEXT.text = "MATTHEW";
		}
		if (RND2 == 12)
		{
			TEXT.text = "SMITH";
		}
		if (RND2 == 13)
		{
			TEXT.text = "BROWN";
		}
		if (RND2 == 14)
		{
			TEXT.text = "EVANS";
		}
		if (RND2 == 15)
		{
			TEXT.text = "MARK";
		}
		if (RND2 == 16)
		{
			TEXT.text = "PAUL";
		}
		if (RND2 == 17)
		{
			TEXT.text = "ROBERT";
		}
		if (RND2 == 18)
		{
			TEXT.text = "RICHARD";
		}
		if (RND2 == 19)
		{
			TEXT.text = "STEVEN";
		}
		if (RND2 == 20)
		{
			TEXT.text = "TOM";
		}
		if (RND2 == 21)
		{
			TEXT.text = "RILEY";
		}
		if (RND2 == 22)
		{
			TEXT.text = "OMAR";
		}
		if (RND2 == 23)
		{
			TEXT.text = "BILL";
		}
		if (RND2 == 24)
		{
			TEXT.text = "KIRK";
		}
		if (RND2 == 25)
		{
			TEXT.text = "LEE";
		}
		if (RND2 == 26)
		{
			TEXT.text = "MICHAEL";
		}
		if (RND2 == 27)
		{
			TEXT.text = "CHRIS";
		}
		if (RND2 == 28)
		{
			TEXT.text = "SEAN";
		}
		if (RND2 == 29)
		{
			TEXT.text = "JUSTIN";
		}
		if (RND2 == 30)
		{
			TEXT.text = "ADAM";
		}
		if (RND2 == 31)
		{
			TEXT.text = "JAMES";
		}
		if (RND2 == 32)
		{
			TEXT.text = "TOM";
		}
		if (RND2 == 33)
		{
			TEXT.text = "SAM";
		}
		base.enabled = false;
	}
}
