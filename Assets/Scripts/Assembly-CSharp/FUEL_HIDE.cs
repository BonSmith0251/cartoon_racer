using System.Collections;
using UnityEngine;

public class FUEL_HIDE : MonoBehaviour
{
	public GameObject spr;

	public void START_HIDE()
	{
		StartCoroutine(HIDE());
	}

	private IEnumerator HIDE()
	{
		base.gameObject.GetComponent<BoxCollider>().enabled = false;
		base.gameObject.GetComponent<MeshRenderer>().enabled = false;
		spr.SetActive(value: false);
		yield return new WaitForSecondsRealtime(3f);
		base.gameObject.GetComponent<BoxCollider>().enabled = true;
		base.gameObject.GetComponent<MeshRenderer>().enabled = true;
		spr.SetActive(value: true);
	}
}
