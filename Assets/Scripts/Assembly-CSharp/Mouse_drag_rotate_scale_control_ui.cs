using UnityEngine;
using UnityEngine.EventSystems;

public class Mouse_drag_rotate_scale_control_ui : MonoBehaviour
{
	[Header("Does it need to drag")]
	public bool is_dragable;

	private bool is_dragging;

	private float distance_z;

	private Vector3 drag_offset;

	[Header("Does it need to rotate")]
	public bool is_rotation;

	[Header("Rotational speed 0~1")]
	[Range(0f, 1f)]
	public float rotation_speed;

	[Header("Does it need to scale")]
	public bool is_scale;

	[Header("max scale and min scale")]
	public float max_scale;

	public float min_scale;

	private bool is_mouse_down;

	private float mouse_position_x;

	private float mouse_position_y;

	private void Update()
	{
		if (Input.GetMouseButtonDown(0) || (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began))
		{
			is_mouse_down = true;
			mouse_position_x = Input.mousePosition.x;
			mouse_position_y = Input.mousePosition.y;
			if (EventSystem.current.IsPointerOverGameObject() && is_dragable && !is_dragging)
			{
				is_dragging = true;
			}
		}
		else if (Input.GetMouseButtonUp(0))
		{
			is_mouse_down = false;
			if (is_dragging)
			{
				is_dragging = false;
			}
		}
		if (is_mouse_down)
		{
			if (is_dragable && is_dragging)
			{
				GetComponent<RectTransform>().position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
			}
			else if (is_rotation)
			{
				Vector2 vector = new Vector2(Input.mousePosition.x - mouse_position_x, Input.mousePosition.y - mouse_position_y);
				if (Mathf.Abs(vector.x) > Mathf.Abs(vector.y))
				{
					if (Mathf.Abs(vector.x) > 5f)
					{
						base.transform.Rotate(new Vector3(0f, 0f, vector.x * rotation_speed));
					}
				}
				else if (Mathf.Abs(vector.y) > 5f)
				{
					base.transform.Rotate(new Vector3(0f, 0f, vector.y * rotation_speed));
				}
				mouse_position_x = Input.mousePosition.x;
				mouse_position_y = Input.mousePosition.y;
			}
		}
		if (Input.GetAxis("Mouse ScrollWheel") < 0f && base.transform.localScale.x > min_scale)
		{
			base.transform.localScale = base.transform.localScale * 0.98f;
		}
		if (Input.GetAxis("Mouse ScrollWheel") > 0f && base.transform.localScale.x < max_scale)
		{
			base.transform.localScale = base.transform.localScale * 1.02f;
		}
		if (Input.GetAxis("Mouse ScrollWheel") != 0f)
		{
		}
	}
}
