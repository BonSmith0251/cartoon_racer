using UnityEngine;
using UnityEngine.EventSystems;

public class ClothesScale : MonoBehaviour, IPointerUpHandler, IPointerDownHandler, IDragHandler, IEventSystemHandler
{
	private float minScale = 0.3f;

	private float maxScale = 3f;

	private int scaleDivisor = 800;

	private Touch oldTouch1;

	private Touch oldTouch2;

	private Vector2 Distance;

	private Vector2 ClothesPosition;

	private Vector2 ClothesChangePosition;

	private Vector2 ClothesChangeScale = new Vector2(1f, 1f);

	private bool IsDrag;

	private void Start()
	{
		ClothesPosition = GetComponent<RectTransform>().anchoredPosition;
	}

	public void OnDrag(PointerEventData eventData)
	{
		if (IsDrag)
		{
			ClothesChangePosition = new Vector2(Input.mousePosition.x * 1280f / (float)Screen.width + Distance.x, Input.mousePosition.y * 720f / (float)Screen.height + Distance.y);
			GetComponent<RectTransform>().anchoredPosition = ClothesChangePosition;
		}
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		base.transform.localScale = ClothesChangeScale * 0.98f;
		Distance = new Vector2(GetComponent<RectTransform>().anchoredPosition.x - Input.mousePosition.x * 1280f / (float)Screen.width, GetComponent<RectTransform>().anchoredPosition.y - Input.mousePosition.y * 720f / (float)Screen.height);
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		base.transform.localScale = ClothesChangeScale * 1f;
	}

	private void Update()
	{
		if (Input.touchCount <= 0)
		{
			IsDrag = false;
			return;
		}
		if (Input.touchCount == 1)
		{
			IsDrag = true;
			ClothesPosition = GetComponent<RectTransform>().anchoredPosition;
			if (ClothesPosition.x < 0f || ClothesPosition.x > 1280f || ClothesPosition.y < 0f || ClothesPosition.y > 720f)
			{
				if (ClothesPosition.x < 0f)
				{
					ClothesChangePosition.x = 0f;
				}
				if (ClothesPosition.x > 1280f)
				{
					ClothesChangePosition.x = 1280f;
				}
				if (ClothesPosition.y < 0f)
				{
					ClothesChangePosition.y = 0f;
				}
				if (ClothesPosition.y > 720f)
				{
					ClothesChangePosition.y = 720f;
				}
			}
			return;
		}
		IsDrag = false;
		Touch touch = Input.GetTouch(0);
		Touch touch2 = Input.GetTouch(1);
		if (touch2.phase == TouchPhase.Began)
		{
			oldTouch2 = touch2;
			oldTouch1 = touch;
			return;
		}
		float num = Vector2.Distance(oldTouch1.position, oldTouch2.position);
		float num2 = Vector2.Distance(touch.position, touch2.position);
		float num3 = num2 - num;
		float num4 = num3 / (float)scaleDivisor;
		Vector2 vector = base.transform.localScale;
		Vector2 vector2 = new Vector3(vector.x + num4, vector.y + num4);
		if (vector2.x > minScale && vector2.x < maxScale && vector2.y > minScale && vector2.y < maxScale)
		{
			base.transform.localScale = vector2;
			ClothesChangeScale = base.transform.localScale;
		}
		oldTouch1 = touch;
		oldTouch2 = touch2;
	}
}
