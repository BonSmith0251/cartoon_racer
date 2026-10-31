using System;
using UnityEngine;

[Serializable]
public class Clips
{
	private int i;

	public AudioClip[] clips;

	public AudioClip GetClip(bool random)
	{
		i = (random ? UnityEngine.Random.Range(0, clips.Length) : ((i < clips.Length - 1) ? (i + 1) : 0));
		return clips[i];
	}
}
