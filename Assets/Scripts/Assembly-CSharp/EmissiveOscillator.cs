using System;
using UnityEngine;

public class EmissiveOscillator : MonoBehaviour
{
	private MeshRenderer emissiveRenderer;

	private Material emissiveMaterial;

	private void Start()
	{
		emissiveRenderer = GetComponent<MeshRenderer>();
		emissiveMaterial = emissiveRenderer.material;
	}

	private void Update()
	{
		Color color = Color.Lerp(Color.white, Color.black, Mathf.Sin(Time.time * (float)Math.PI) * 0.5f + 0.5f);
		emissiveMaterial.SetColor("_Emission", color);
		DynamicGI.SetEmissive(emissiveRenderer, color);
	}
}
