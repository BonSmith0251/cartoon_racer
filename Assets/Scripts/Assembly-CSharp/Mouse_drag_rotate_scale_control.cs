using UnityEngine;

public class Mouse_drag_rotate_scale_control : MonoBehaviour
{
	private Vector3 init_position;

	private Quaternion init_rotation;

	private Vector3 init_scale;

	[Header("Does it need to drag")]
	public bool is_dragable;

	private bool is_dragging;

	private float distance_z;

	private Vector3 drag_offset;

	[Header("Does it need to rotate")]
	public bool is_rotation;

	[Range(0f, 1f)]
	[Header("Rotational speed 0~1")]
	public float rotation_speed;

	[Header("Does it need to scale")]
	public bool is_scale;

	[Header("max scale and min scale")]
	public float max_scale;

	public float min_scale;

	[Header("mouse drag texture")]
	public Texture2D mouse_drag_texture;

	private bool is_mouse_down;

	private float mouse_position_x;

	private float mouse_position_y;

	private void Start()
	{
		init_position = base.transform.position;
		init_rotation = base.transform.rotation;
		init_scale = base.transform.localScale;
	}

	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			is_mouse_down = true;
			mouse_position_x = Input.mousePosition.x;
			mouse_position_y = Input.mousePosition.y;
			if (is_dragable && !is_dragging)
			{
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				if (Physics.Raycast(ray, out var hitInfo) && hitInfo.transform.name == base.gameObject.name)
				{
					Cursor.SetCursor(mouse_drag_texture, Vector2.zero, CursorMode.Auto);
					is_dragging = true;
					base.transform.localScale = base.transform.localScale * 0.9f;
					distance_z = hitInfo.transform.position.z - Camera.main.transform.position.z;
					drag_offset = hitInfo.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance_z));
				}
			}
		}
		else if (Input.GetMouseButtonUp(0))
		{
			is_mouse_down = false;
			if (is_dragging)
			{
				is_dragging = false;
				base.transform.localScale = base.transform.localScale / 9f * 10f;
				Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
			}
		}
		if (!is_mouse_down || (is_dragable && is_dragging) || !is_rotation)
		{
			return;
		}
		Vector2 vector = new Vector2(Input.mousePosition.x - mouse_position_x, Input.mousePosition.y - mouse_position_y);
		if (Mathf.Abs(vector.x) > Mathf.Abs(vector.y))
		{
			if (Mathf.Abs(vector.x) > 5f)
			{
				base.transform.Rotate(Vector3.down * vector.x * rotation_speed, Space.Self);
			}
		}
		else if (!(Mathf.Abs(vector.y) > 5f))
		{
		}
		mouse_position_x = Input.mousePosition.x;
		mouse_position_y = Input.mousePosition.y;
	}

	public void reset_transform()
	{
		base.transform.position = init_position;
		base.transform.rotation = init_rotation;
		base.transform.localScale = init_scale;
	}
}
