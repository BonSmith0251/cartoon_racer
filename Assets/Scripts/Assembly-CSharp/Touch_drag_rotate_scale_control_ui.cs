using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class Touch_drag_rotate_scale_control_ui : MonoBehaviour
{
	[Header("Does it need to drag")]
	public bool is_dragable;

	[Header("long touch drag time")]
	public float long_touch_drag_time;

	private bool is_dragging;

	private int start_time_stamp;

	private bool is_long_touch_timing;

	[Header("Does it need to rotate")]
	public bool is_rotation;

	[Header("Rotational speed 0~1")]
	[Range(0f, 1f)]
	public float rotation_speed;

	[Header("Does it need to scale")]
	public bool is_scale;

	[Header("scale speed")]
	[Range(0.001f, 0.02f)]
	public float scale_speed;

	[Header("max scale and min scale")]
	public float max_scale;

	public float min_scale;

	private Touch oldTouch1;

	private Touch oldTouch2;

	private void Update()
	{
		if (Input.touchCount <= 0)
		{
			is_dragging = false;
			is_long_touch_timing = false;
		}
		else if (Input.touchCount == 1)
		{
			Touch touch = Input.touches[0];
			Vector3 vector = touch.position;
			if (is_dragable)
			{
				if (!is_dragging)
				{
					if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
					{
						if (!is_long_touch_timing)
						{
							start_time_stamp = Environment.TickCount;
							is_long_touch_timing = true;
						}
						if ((float)(Environment.TickCount - start_time_stamp) >= 1000f * long_touch_drag_time)
						{
							is_dragging = true;
							base.transform.localScale = base.transform.localScale * 0.9f;
						}
					}
				}
				else if (is_dragging && touch.phase == TouchPhase.Moved)
				{
					GetComponent<RectTransform>().position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
				}
				else if (is_dragging && (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled))
				{
					is_dragging = false;
					is_long_touch_timing = false;
					base.transform.localScale = base.transform.localScale * 1.112f;
				}
			}
			if (!is_rotation || touch.phase != TouchPhase.Moved || is_dragging)
			{
				return;
			}
			Vector2 deltaPosition = touch.deltaPosition;
			if (Mathf.Abs(deltaPosition.x) > Mathf.Abs(deltaPosition.y))
			{
				if (Mathf.Abs(deltaPosition.x) > 5f)
				{
					is_dragging = false;
					is_long_touch_timing = false;
					base.transform.Rotate(new Vector3(0f, 0f, deltaPosition.x * rotation_speed));
				}
			}
			else if (Mathf.Abs(deltaPosition.y) > 5f)
			{
				is_dragging = false;
				is_long_touch_timing = false;
				base.transform.Rotate(new Vector3(0f, 0f, deltaPosition.y * rotation_speed));
			}
		}
		else
		{
			if (!is_scale)
			{
				return;
			}
			is_dragging = false;
			is_long_touch_timing = false;
			Touch touch2 = Input.GetTouch(0);
			Touch touch3 = Input.GetTouch(1);
			if (touch3.phase == TouchPhase.Began)
			{
				oldTouch2 = touch3;
				oldTouch1 = touch2;
				return;
			}
			float num = Vector2.Distance(touch2.position, touch3.position) - Vector2.Distance(oldTouch1.position, oldTouch2.position);
			float num2 = num * scale_speed;
			Vector3 localScale = base.transform.localScale;
			if (localScale.x + num2 < max_scale && localScale.x + num2 > min_scale)
			{
				base.transform.localScale = new Vector3(localScale.x + num2, localScale.y + num2, localScale.z + num2);
			}
			oldTouch1 = touch2;
			oldTouch2 = touch3;
		}
	}
}
