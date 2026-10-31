using System.Collections;
using UnityEngine;

public class DDS : MonoBehaviour
{
	private void Start()
	{
		StartCoroutine(TASK());
	}

	private IEnumerator TASK()
	{
		yield return new WaitForSeconds(10f);
		Object.Destroy(GetComponent<Rigidbody>());
	}
}
