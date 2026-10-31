using System.Collections.Generic;
using UnityEngine;

public class IntenseVibration : MonoBehaviour
{
	private static IntenseVibration mInstance;

	private static AndroidJavaObject mJVibrator;

	private float mVibrateTimeLeft;

	private List<long[]> mPatterns = new List<long[]>();

	public static IntenseVibration Instance
	{
		get
		{
			if (mInstance == null)
			{
				mInstance = new GameObject("IntenseVibrationObject").AddComponent<IntenseVibration>();
			}
			return mInstance;
		}
	}

	private void Init()
	{
	}

	public bool HasVibrator()
	{
		return false;
	}

	public void Vibrate(long milliseconds)
	{
	}

	public void Vibrate(long[] pattern, int repeat)
	{
	}

	public void Vibrate(long milliseconds, int intensity)
	{
		if (intensity >= 0 && intensity < 10)
		{
			Vibrate(mPatterns[intensity], 0);
			mVibrateTimeLeft = (float)milliseconds / 1000f;
		}
	}

	public void Cancel()
	{
	}

	private void Start()
	{
		Init();
		for (int i = 1; i <= 10; i++)
		{
			mPatterns.Add(new long[2]
			{
				10 - i,
				i * 5
			});
		}
	}

	private void Update()
	{
		if (mVibrateTimeLeft < 0f)
		{
			Cancel();
		}
		if (mVibrateTimeLeft > 0f)
		{
			mVibrateTimeLeft -= Time.deltaTime;
		}
	}
}
