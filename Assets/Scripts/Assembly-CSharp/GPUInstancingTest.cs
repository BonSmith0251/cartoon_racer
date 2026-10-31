using UnityEngine;

public class GPUInstancingTest : MonoBehaviour
{
	public Transform prefab;

	public int instances = 5000;

	public float radius = 50f;

	private void Start()
	{
		MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();
		for (int i = 0; i < instances; i++)
		{
			Transform transform = Object.Instantiate(prefab);
			transform.localPosition = Random.insideUnitSphere * radius;
			transform.SetParent(base.transform);
			materialPropertyBlock.SetColor("_Color", new Color(Random.value, Random.value, Random.value));
			MeshRenderer component = transform.GetComponent<MeshRenderer>();
			if ((bool)component)
			{
				component.SetPropertyBlock(materialPropertyBlock);
				continue;
			}
			for (int j = 0; j < transform.childCount; j++)
			{
				component = transform.GetChild(j).GetComponent<MeshRenderer>();
				if ((bool)component)
				{
					component.SetPropertyBlock(materialPropertyBlock);
				}
			}
		}
	}
}
