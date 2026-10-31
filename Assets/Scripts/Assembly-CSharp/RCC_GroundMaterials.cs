using System;
using UnityEngine;

[Serializable]
public class RCC_GroundMaterials : ScriptableObject
{
	[Serializable]
	public class GroundMaterialFrictions
	{
		public PhysicMaterial groundMaterial;

		public float forwardStiffness = 1f;

		public float sidewaysStiffness = 1f;

		public float slip = 0.25f;

		public float damp = 1f;

		public GameObject groundParticles;

		public AudioClip groundSound;
	}

	private static RCC_GroundMaterials instance;

	public GroundMaterialFrictions[] frictions;

	public bool useTerrainSplatMapForGroundFrictions;

	public PhysicMaterial terrainPhysicMaterial;

	public static RCC_GroundMaterials Instance
	{
		get
		{
			if (instance == null)
			{
				instance = Resources.Load("RCC Assets/RCC_GroundMaterials") as RCC_GroundMaterials;
			}
			return instance;
		}
	}
}
