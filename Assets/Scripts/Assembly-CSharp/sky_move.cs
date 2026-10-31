using UnityEngine;

public class sky_move : MonoBehaviour
{
	private float time;

	private void Update()
	{
		time += Time.deltaTime / 300f;
		base.gameObject.GetComponent<MeshRenderer>().material.mainTextureOffset = new Vector2(time, 0f - time);
	}
}
