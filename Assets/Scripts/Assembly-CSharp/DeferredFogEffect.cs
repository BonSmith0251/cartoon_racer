using System;
using UnityEngine;

[ExecuteInEditMode]
public class DeferredFogEffect : MonoBehaviour
{
	public Shader deferredFog;

	[NonSerialized]
	private Material fogMaterial;

	[NonSerialized]
	private Camera deferredCamera;

	[NonSerialized]
	private Vector3[] frustumCorners;

	[NonSerialized]
	private Vector4[] vectorArray;

	[ImageEffectOpaque]
	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		if (fogMaterial == null)
		{
			deferredCamera = GetComponent<Camera>();
			frustumCorners = new Vector3[4];
			vectorArray = new Vector4[4];
			fogMaterial = new Material(deferredFog);
		}
		deferredCamera.CalculateFrustumCorners(new Rect(0f, 0f, 1f, 1f), deferredCamera.farClipPlane, deferredCamera.stereoActiveEye, frustumCorners);
		ref Vector4 reference = ref vectorArray[0];
		reference = frustumCorners[0];
		ref Vector4 reference2 = ref vectorArray[1];
		reference2 = frustumCorners[3];
		ref Vector4 reference3 = ref vectorArray[2];
		reference3 = frustumCorners[1];
		ref Vector4 reference4 = ref vectorArray[3];
		reference4 = frustumCorners[2];
		fogMaterial.SetVectorArray("_FrustumCorners", vectorArray);
		Graphics.Blit(source, destination, fogMaterial);
	}
}
