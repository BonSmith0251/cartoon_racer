using System;
using UnityEngine;

[ExecuteInEditMode]
[ImageEffectAllowedInSceneView]
public class DepthOfFieldEffect : MonoBehaviour
{
	private const int circleOfConfusionPass = 0;

	private const int preFilterPass = 1;

	private const int bokehPass = 2;

	private const int postFilterPass = 3;

	private const int combinePass = 4;

	[Range(0.1f, 100f)]
	public float focusDistance = 10f;

	[Range(0.1f, 10f)]
	public float focusRange = 3f;

	[Range(1f, 10f)]
	public float bokehRadius = 4f;

	[HideInInspector]
	public Shader dofShader;

	[NonSerialized]
	private Material dofMaterial;

	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		if (dofMaterial == null)
		{
			dofMaterial = new Material(dofShader);
			dofMaterial.hideFlags = HideFlags.HideAndDontSave;
		}
		dofMaterial.SetFloat("_BokehRadius", bokehRadius);
		dofMaterial.SetFloat("_FocusDistance", focusDistance);
		dofMaterial.SetFloat("_FocusRange", focusRange);
		RenderTexture temporary = RenderTexture.GetTemporary(source.width, source.height, 0, RenderTextureFormat.RHalf, RenderTextureReadWrite.Linear);
		int width = source.width / 2;
		int height = source.height / 2;
		RenderTextureFormat format = source.format;
		RenderTexture temporary2 = RenderTexture.GetTemporary(width, height, 0, format);
		RenderTexture temporary3 = RenderTexture.GetTemporary(width, height, 0, format);
		dofMaterial.SetTexture("_CoCTex", temporary);
		dofMaterial.SetTexture("_DoFTex", temporary2);
		Graphics.Blit(source, temporary, dofMaterial, 0);
		Graphics.Blit(source, temporary2, dofMaterial, 1);
		Graphics.Blit(temporary2, temporary3, dofMaterial, 2);
		Graphics.Blit(temporary3, temporary2, dofMaterial, 3);
		Graphics.Blit(source, destination, dofMaterial, 4);
		RenderTexture.ReleaseTemporary(temporary);
		RenderTexture.ReleaseTemporary(temporary2);
		RenderTexture.ReleaseTemporary(temporary3);
	}
}
