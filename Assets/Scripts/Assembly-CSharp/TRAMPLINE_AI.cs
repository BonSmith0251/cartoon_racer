using UnityEngine;

public class TRAMPLINE_AI : MonoBehaviour
{
	public GameObject[] OBJ;

	private int obj_;

	private float timer;

	private void OnTriggerStay(Collider car2)
	{
		if (!(car2.CompareTag("Player") & !GAME_MANAGER.IN_RACE))
		{
			return;
		}
		timer += Time.deltaTime * 5f;
		if (timer > 1f)
		{
			for (int i = 0; i < OBJ.Length; i++)
			{
				OBJ[i].SetActive(value: false);
			}
			OBJ[obj_].SetActive(value: true);
			obj_++;
			if (obj_ > 6)
			{
				obj_ = 0;
			}
			timer = 0f;
		}
	}
}
