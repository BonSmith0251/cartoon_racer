using UnityEngine;

public class SEED : MonoBehaviour
{
	private float LIFETIME;

	private float RND;

	private float ff;

	private void Start()
	{
		LIFETIME = 30f;
	}

	private void Update()
	{
		LIFETIME -= Time.deltaTime;
		ff += Time.deltaTime * 20f;
		base.gameObject.GetComponent<Rigidbody>().AddTorque(base.transform.forward * Random.Range(300, 700));
		if (LIFETIME < 1f)
		{
			Object.Destroy(base.gameObject);
		}
	}
}
