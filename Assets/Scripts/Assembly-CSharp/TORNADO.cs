using UnityEngine;

public class TORNADO : MonoBehaviour
{
	private int side;

	private Transform START_POS;

	private void OnTriggerStay(Collider car2)
	{
		if (car2.CompareTag("Player"))
		{
			car2.GetComponentInParent<Rigidbody>().gameObject.transform.eulerAngles += new Vector3(0f, (float)side / 1.6f, 0f);
		}
	}

	private void Start()
	{
		side = Random.Range(0, 2);
		if (side == 1)
		{
			side = -1;
		}
		else
		{
			side = 1;
		}
		if (START_POS == null)
		{
			START_POS = base.gameObject.transform;
		}
		base.gameObject.transform.position = START_POS.position;
	}
}
