using UnityEngine;

[AddComponentMenu("BoneCracker Games/Realistic Car Controller/Camera/RCC Camera Config")]
public class RCC_CameraConfig : MonoBehaviour
{
	public bool automatic = true;

	private Bounds combinedBounds;

	public float distance = 10f;

	public float height = 5f;

	private void OnEnable()
	{
		if (automatic)
		{
			Quaternion rotation = base.transform.rotation;
			base.transform.rotation = Quaternion.identity;
			distance = MaxBoundsExtent(base.transform) * 2.75f;
			height = MaxBoundsExtent(base.transform) * 0.6f;
			if (height < 1f)
			{
				height = 1f;
			}
			base.transform.rotation = rotation;
		}
	}

	public void SetCameraSettings()
	{
		RCC_Camera activePlayerCamera = RCC_SceneManager.Instance.activePlayerCamera;
		if ((bool)activePlayerCamera)
		{
			activePlayerCamera.TPSDistance = distance;
			activePlayerCamera.TPSHeight = height;
		}
	}

	public static float MaxBoundsExtent(Transform obj)
	{
		Renderer[] componentsInChildren = obj.GetComponentsInChildren<Renderer>();
		Bounds bounds = default(Bounds);
		bool flag = false;
		Renderer[] array = componentsInChildren;
		foreach (Renderer renderer in array)
		{
			if (!(renderer is TrailRenderer) && !(renderer is ParticleSystemRenderer))
			{
				if (!flag)
				{
					flag = true;
					bounds = renderer.bounds;
				}
				else
				{
					bounds.Encapsulate(renderer.bounds);
				}
			}
		}
		return Mathf.Max(bounds.extents.x, bounds.extents.y, bounds.extents.z);
	}
}
