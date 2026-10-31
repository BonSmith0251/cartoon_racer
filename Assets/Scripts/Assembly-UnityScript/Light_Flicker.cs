using System;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class Light_Flicker : MonoBehaviour
{
	public float time;

	public float min;

	public float max;

	public bool useSmooth;

	public float smoothTime;

	public Light_Flicker()
	{
		time = 0.2f;
		min = 0.5f;
		max = 5f;
		smoothTime = 10f;
	}

	public virtual void Start()
	{
		if (!useSmooth && (bool)GetComponent<Light>())
		{
			InvokeRepeating("OneLightChange", time, time);
		}
	}

	public virtual void OneLightChange()
	{
		GetComponent<Light>().intensity = UnityEngine.Random.Range(min, max);
	}

	public virtual void Update()
	{
		if (useSmooth && (bool)GetComponent<Light>())
		{
			GetComponent<Light>().intensity = Mathf.Lerp(GetComponent<Light>().intensity, UnityEngine.Random.Range(min, max), Time.deltaTime * smoothTime);
		}
		if (RuntimeServices.EqualityOperator(GetComponent<Light>(), false))
		{
			MonoBehaviour.print("Please add a light component for light flicker");
		}
	}

	public virtual void Main()
	{
	}
}
