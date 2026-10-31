using UnityEngine;

public class TIME_ADD : MonoBehaviour
{
	private bool enter;

	public GameObject FX;

	public GameObject HUD;

	public int INDEX;

	private float DIST;

	private float DD;

	private float CC;

	public void RND()
	{
		if (SCHOOL_MANAGER.INDEX_ORIENTIR == INDEX)
		{
			HUD.SetActive(value: true);
			DIST = Vector3.Distance(base.transform.position, Camera.main.transform.position);
			DD = DIST * 2f;
			CC = DIST / DD;
			SCHOOL_MANAGER.TIME = CC * 5f;
		}
	}

	private void OnTriggerEnter(Collider car2)
	{
		if (!((car2.gameObject.tag == "Player") & !enter))
		{
			return;
		}
		if ((SCHOOL_MANAGER.SELECTED_TYPE == "ORIENTIR") & (SCHOOL_MANAGER.INDEX_ORIENTIR == INDEX))
		{
			FX.SetActive(value: true);
			SCHOOL_MANAGER.NEED_CHECKPOINTS++;
			SCHOOL_MANAGER.REAL_TIME += 0.5f;
			HUD.SetActive(value: false);
			SCHOOL_MANAGER.INDEX_ORIENTIR = -1;
			if (SCHOOL_MANAGER.REAL_TIME > 1f)
			{
				SCHOOL_MANAGER.REAL_TIME = 1f;
			}
			return;
		}
		if (SCHOOL_MANAGER.SELECTED_TYPE == "CHECKPOINT")
		{
			FX.SetActive(value: true);
			SCHOOL_MANAGER.NEED_CHECKPOINTS++;
			SCHOOL_MANAGER.REAL_TIME += 0.3f;
			enter = true;
		}
		if (SCHOOL_MANAGER.REAL_TIME > 1f)
		{
			SCHOOL_MANAGER.REAL_TIME = 1f;
		}
	}
}
