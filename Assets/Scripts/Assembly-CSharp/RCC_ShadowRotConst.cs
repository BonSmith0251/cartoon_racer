using UnityEngine;

[AddComponentMenu("BoneCracker Games/Realistic Car Controller/Misc/RCC Shadow")]
public class RCC_ShadowRotConst : MonoBehaviour
{
	private Transform root;

	private void Start()
	{
		root = GetComponentInParent<RCC_CarControllerV3>().transform;
		if (ES2.Exists("SHADOW") && ES2.Load<int>("SHADOW") == 0)
		{
			base.gameObject.SetActive(value: false);
		}
	}

	private void Update()
	{
		base.transform.rotation = Quaternion.Euler(90f, root.eulerAngles.y, 0f);
	}
}
