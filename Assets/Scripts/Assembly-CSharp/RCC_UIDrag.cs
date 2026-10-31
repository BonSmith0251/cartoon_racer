using UnityEngine;
using UnityEngine.EventSystems;

[AddComponentMenu("BoneCracker Games/Realistic Car Controller/UI/RCC UI Drag Handler")]
public class RCC_UIDrag : MonoBehaviour, IDragHandler, IEndDragHandler, IEventSystemHandler
{
	private bool isPressing;

	public void OnDrag(PointerEventData data)
	{
		isPressing = true;
		RCC_SceneManager.Instance.activePlayerCamera.OnDrag(data);
	}

	public void OnEndDrag(PointerEventData data)
	{
		isPressing = false;
	}
}
