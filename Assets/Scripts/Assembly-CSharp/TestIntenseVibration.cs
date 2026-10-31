using UnityEngine;

public class TestIntenseVibration : MonoBehaviour
{
	private void Start()
	{
	}

	private void Update()
	{
	}

	private void OnGUI()
	{
		GUILayout.BeginArea(new Rect((float)Screen.width / 2f - 200f, 0f, 400f, Screen.height));
		if (GUILayout.Button("Vibrate 50ms", GUILayout.MaxHeight(50f)))
		{
			IntenseVibration.Instance.Vibrate(50L);
		}
		if (GUILayout.Button("Vibrate 200ms", GUILayout.MaxHeight(50f)))
		{
			IntenseVibration.Instance.Vibrate(200L);
		}
		for (int i = 0; i < 10; i++)
		{
			GUILayout.BeginHorizontal();
			if (GUILayout.Button("Vibrate 50ms (Intensity: " + i + ")", GUILayout.MaxHeight(50f)))
			{
				IntenseVibration.Instance.Vibrate(50L, i);
			}
			if (GUILayout.Button("Vibrate 200ms (Intensity: " + i + ")", GUILayout.MaxHeight(50f)))
			{
				IntenseVibration.Instance.Vibrate(200L, i);
			}
			GUILayout.EndHorizontal();
		}
		GUILayout.Space(25f);
		if (GUILayout.Button("Vibrate Pattern", GUILayout.MaxHeight(50f)))
		{
			long num = 100L;
			long num2 = 300L;
			long num3 = 100L;
			long[] pattern = new long[16]
			{
				num3, num, num3, num, num3, num, num3, num2, num3, num2,
				num3, num, num3, num, num3, num
			};
			IntenseVibration.Instance.Vibrate(pattern, -1);
		}
		if (GUILayout.Button("Cancel", GUILayout.MaxHeight(50f)))
		{
			IntenseVibration.Instance.Cancel();
		}
		GUILayout.Space(25f);
		if (GUILayout.Button("Exit", GUILayout.MaxHeight(50f)))
		{
			Application.Quit();
		}
		GUILayout.EndArea();
	}
}
