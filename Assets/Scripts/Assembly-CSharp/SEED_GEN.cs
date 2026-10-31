using UnityEngine;

public class SEED_GEN : MonoBehaviour
{
	private int RAND;

	private int RAND2;

	public void GEN()
	{
		RAND2 = Random.Range(0, 3);
		RAND = Random.Range(0, 3);
		if (RAND2 != 0)
		{
			for (int i = 0; i < RAND; i++)
			{
				GameObject gameObject = Object.Instantiate(GAME_MANAGER.SEED_OBJ_, base.gameObject.transform.position, base.transform.rotation);
				gameObject.transform.position += Vector3.up * 8f;
				base.transform.rotation = Quaternion.Euler(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
				gameObject.gameObject.GetComponent<Rigidbody>().AddExplosionForce(Random.Range(10, 15), base.gameObject.transform.position, 300f);
			}
		}
	}
}
