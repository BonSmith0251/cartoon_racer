using UnityEngine;

public class LEVEL_GROUP_CHECKER : MonoBehaviour
{
	public int NEED_LEVEL;

	private void OnEnable()
	{
		if (NEED_LEVEL > MENU_MANAGER.PLAYER_LEVEL)
		{
			base.gameObject.SetActive(value: false);
		}
		else
		{
			base.enabled = false;
		}
	}
}
