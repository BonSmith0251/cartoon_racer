using System;
using UnityEngine;

[ExecuteInEditMode]
[ImageEffectAllowedInSceneView]
public class BloomEffect : MonoBehaviour
{
	private const int BoxDownPrefilterPass = 0;

	private const int BoxDownPass = 1;

	private const int BoxUpPass = 2;

	private const int ApplyBloomPass = 3;

	private const int DebugBloomPass = 4;

	public Shader bloomShader;

	[Range(0f, 10f)]
	public float intensity = 1f;

	[Range(1f, 16f)]
	public int iterations = 4;

	[Range(0f, 10f)]
	public float threshold = 1f;

	[Range(0f, 1f)]
	public float softThreshold = 0.5f;

	public bool debug;

	private RenderTexture[] textures = new RenderTexture[16];

	[NonSerialized]
	private Material bloom;

	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		if (bloom == null)
		{
			bloom = new Material(bloomShader);
			bloom.hideFlags = HideFlags.HideAndDontSave;
		}
		float num = threshold * softThreshold;
		Vector4 value = default(Vector4);
		value.x = threshold;
		value.y = value.x - num;
		value.z = 2f * num;
		value.w = 0.25f / (num + 1E-05f);
		bloom.SetVector("_Filter", value);
		bloom.SetFloat("_Intensity", Mathf.GammaToLinearSpace(intensity));
		int num2 = source.width / 2;
		int num3 = source.height / 2;
		RenderTextureFormat format = source.format;
		RenderTexture renderTexture = (textures[0] = RenderTexture.GetTemporary(num2, num3, 0, format));
		Graphics.Blit(source, renderTexture, bloom, 0);
		RenderTexture renderTexture2 = renderTexture;
		int i;
		for (i = 1; i < iterations; i++)
		{
			num2 /= 2;
			num3 /= 2;
			if (num3 < 2)
			{
				break;
			}
			renderTexture = (textures[i] = RenderTexture.GetTemporary(num2, num3, 0, format));
			Graphics.Blit(renderTexture2, renderTexture, bloom, 1);
			renderTexture2 = renderTexture;
		}
		for (i -= 2; i >= 0; i--)
		{
			renderTexture = textures[i];
			textures[i] = null;
			Graphics.Blit(renderTexture2, renderTexture, bloom, 2);
			RenderTexture.ReleaseTemporary(renderTexture2);
			renderTexture2 = renderTexture;
		}
		if (debug)
		{
			Graphics.Blit(renderTexture2, destination, bloom, 4);
		}
		else
		{
			bloom.SetTexture("_SourceTex", source);
			Graphics.Blit(renderTexture2, destination, bloom, 3);
		}
		RenderTexture.ReleaseTemporary(renderTexture2);
	}
}
