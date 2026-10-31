using UnityEngine;

public class line : MonoBehaviour
{
	private float gg;

	private bool VIS;

	private void OnBecameVisible()
	{
		VIS = true;
	}

	private void OnBecameInvisible()
	{
		VIS = false;
	}

	private void Update()
	{
		if (VIS)
		{
			gg += Time.deltaTime * 1.3f;
			base.gameObject.GetComponent<MeshRenderer>().material.mainTextureOffset = new Vector2(gg, 0f);
		}
	}
}
