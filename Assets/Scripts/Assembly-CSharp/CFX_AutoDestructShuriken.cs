using System.Collections;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class CFX_AutoDestructShuriken : MonoBehaviour
{
	public bool UP_;

	public bool OnlyDeactivate;

	private void Update()
	{
		if (UP_)
		{
			base.gameObject.transform.position += Vector3.up * Time.deltaTime * 2f;
		}
	}

	private void OnEnable()
	{
		StartCoroutine("CheckIfAlive");
	}

	private IEnumerator CheckIfAlive()
	{
		do
		{
			yield return new WaitForSeconds(0.5f);
		}
		while (GetComponent<ParticleSystem>().IsAlive(withChildren: true));
		if (OnlyDeactivate)
		{
			base.gameObject.SetActive(value: false);
		}
		else
		{
			Object.Destroy(base.gameObject);
		}
	}
}
