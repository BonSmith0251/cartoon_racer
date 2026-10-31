using UnityEngine;

public class EYES_ : MonoBehaviour
{
	public Texture EYES_OPEN;

	public Texture EYES_CLOSED;

	private float timer;

	private void Update()
	{
		timer += Time.deltaTime;
		if (timer > 4f)
		{
			base.gameObject.GetComponent<SkinnedMeshRenderer>().material.mainTexture = EYES_CLOSED;
			if (timer > 4.1f)
			{
				timer = 0f;
			}
		}
		else
		{
			base.gameObject.GetComponent<SkinnedMeshRenderer>().material.mainTexture = EYES_OPEN;
		}
	}
}
