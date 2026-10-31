using System;
using UnityEngine;

[Serializable]
public class ScrollUV : MonoBehaviour
{
	public float scrollSpeed_Y;

	public int VIS;

	public ScrollUV()
	{
		scrollSpeed_Y = 0.5f;
	}

	public virtual void OnBecameVisible()
	{
		VIS = 1;
	}

	public virtual void OnBecameInvisible()
	{
		VIS = 0;
	}

	public virtual void Update()
	{
		if (VIS == 1)
		{
			float y = Time.time * scrollSpeed_Y;
			GetComponent<Renderer>().material.mainTextureOffset = new Vector2(0f, y);
		}
	}

	public virtual void Main()
	{
	}
}
