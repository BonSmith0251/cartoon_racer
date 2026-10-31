using UnityEngine;

public class ScreenFader : MonoBehaviour
{
	public enum FadeState
	{
		In,
		Out,
		Stop,
		InEnd,
		OutEnd
	}

	private Texture colorTexture;

	private Color fadeColor = Color.black;

	[HideInInspector]
	public float fadeBalance;

	public FadeState fadeState;

	public float fadeSpeed;

	public float fromInDelay;

	public float fromOutDelay;

	private float FPS;

	public void reset()
	{
		fadeBalance = 0.5f;
	}

	public void RS()
	{
		fadeSpeed = 0.3f;
		fadeBalance = 0.5f;
		fadeState = FadeState.Out;
		Awake();
	}

	public void RST()
	{
		fadeSpeed = 0.3f;
		fadeBalance = 0.5f;
		fadeState = FadeState.In;
		Awake();
	}

	private void Awake()
	{
		fadeSpeed *= 1.5f;
		Texture2D texture2D = new Texture2D(1, 1);
		texture2D.SetPixel(0, 0, Color.black);
		texture2D.Apply();
		colorTexture = texture2D;
		fadeBalance = 1f + fromInDelay;
	}

	private void LateUpdate()
	{
		if (fadeState == FadeState.OutEnd)
		{
			base.gameObject.GetComponent<ScreenFader>().enabled = false;
		}
		fadeColor.a = fadeBalance;
		if (fadeBalance > 1f + fromInDelay)
		{
			fadeBalance = 1f + fromInDelay;
			fadeState = FadeState.InEnd;
		}
		if (fadeBalance < 0f - fromOutDelay)
		{
			fadeBalance = 0f - fromOutDelay;
			fadeState = FadeState.OutEnd;
		}
		switch (fadeState)
		{
		case FadeState.In:
			fadeBalance += Time.deltaTime * fadeSpeed;
			break;
		case FadeState.Out:
			fadeBalance -= Time.deltaTime * fadeSpeed;
			break;
		case FadeState.Stop:
			fadeBalance = fadeBalance;
			break;
		case FadeState.InEnd:
			fadeBalance = 1f + fromInDelay;
			break;
		case FadeState.OutEnd:
			fadeBalance = 0f - fromOutDelay;
			break;
		}
	}

	private void OnGUI()
	{
		GUI.depth = -2;
		GUI.color = fadeColor;
		GUI.DrawTexture(new Rect(0f, 0f, Screen.width, Screen.height), colorTexture, ScaleMode.StretchToFill, alphaBlend: true);
	}
}
