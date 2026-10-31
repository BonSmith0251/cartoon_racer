using UnityEngine;

[RequireComponent(typeof(Camera))]
[ExecuteInEditMode]
public class HexBokeh : MonoBehaviour
{
	public enum SampleCount
	{
		Low,
		High
	}

	[SerializeField]
	private Shader shader;

	public Transform focalTarget;

	public float focalLength = 10f;

	public float focalSize = 0.05f;

	public float aperture = 11.5f;

	public bool visualize;

	public bool nearBlur;

	public SampleCount sampleCount = SampleCount.High;

	public float sampleDist = 1f;

	private Material material;

	private Vector3 focalPoint
	{
		get
		{
			if (focalTarget != null)
			{
				return focalTarget.position;
			}
			return focalLength * GetComponent<Camera>().transform.forward + GetComponent<Camera>().transform.position;
		}
	}

	private void OnEnable()
	{
		GetComponent<Camera>().depthTextureMode |= DepthTextureMode.Depth;
	}

	private void SetUpObjects()
	{
		if (!(material != null))
		{
			material = new Material(shader);
			material.hideFlags = HideFlags.DontSave;
		}
	}

	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		SetUpObjects();
		if (nearBlur)
		{
			material.EnableKeyword("NEAR_ON");
		}
		else
		{
			material.DisableKeyword("NEAR_ON");
		}
		if (sampleCount == SampleCount.High)
		{
			material.EnableKeyword("SAMPLE_HIGH");
		}
		else
		{
			material.DisableKeyword("SAMPLE_HIGH");
		}
		float z = GetComponent<Camera>().WorldToViewportPoint(focalPoint).z / (GetComponent<Camera>().farClipPlane - GetComponent<Camera>().nearClipPlane);
		material.SetVector("_CurveParams", new Vector4(focalSize, aperture / 10f, z, 0f));
		Graphics.Blit(source, source, material, 0);
		if (visualize)
		{
			Graphics.Blit(source, destination, material, 1);
			return;
		}
		RenderTexture temporary = RenderTexture.GetTemporary(source.width, source.height, 0, source.format);
		RenderTexture temporary2 = RenderTexture.GetTemporary(source.width, source.height, 0, source.format);
		RenderTexture temporary3 = RenderTexture.GetTemporary(source.width, source.height, 0, source.format);
		material.SetVector("_BlurDisp", new Vector4(1f, 0f, -1f, 0f) * sampleDist);
		Graphics.Blit(source, temporary, material, 2);
		material.SetVector("_BlurDisp", new Vector4(-0.5f, -1f, 0.5f, 1f) * sampleDist);
		Graphics.Blit(temporary, temporary2, material, 2);
		material.SetVector("_BlurDisp", new Vector4(0.5f, -1f, -0.5f, 1f) * sampleDist);
		Graphics.Blit(temporary, temporary3, material, 2);
		material.SetTexture("_BlurTex1", temporary2);
		material.SetTexture("_BlurTex2", temporary3);
		Graphics.Blit(source, destination, material, 3);
		material.SetTexture("_BlurTex1", null);
		material.SetTexture("_BlurTex2", null);
		RenderTexture.ReleaseTemporary(temporary);
		RenderTexture.ReleaseTemporary(temporary2);
		RenderTexture.ReleaseTemporary(temporary3);
	}
}
