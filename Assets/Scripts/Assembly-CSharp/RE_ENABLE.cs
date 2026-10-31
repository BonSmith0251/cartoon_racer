using System.Collections;
using UnityEngine;

public class RE_ENABLE : MonoBehaviour
{
	public GameObject LIGHT;

	private void OnEnable()
	{
		LIGHT.SetActive(value: true);
		base.gameObject.GetComponent<MeshRenderer>().enabled = true;
		base.gameObject.GetComponent<BoxCollider>().enabled = true;
	}

	public void HIDE()
	{
		StartCoroutine(DELAY());
	}

	private IEnumerator DELAY()
	{
		base.gameObject.GetComponent<MeshRenderer>().enabled = false;
		base.gameObject.GetComponent<BoxCollider>().enabled = false;
		LIGHT.SetActive(value: false);
		yield return new WaitForSeconds(5f);
		LIGHT.SetActive(value: true);
		base.gameObject.GetComponent<MeshRenderer>().enabled = true;
		base.gameObject.GetComponent<BoxCollider>().enabled = true;
	}
}
