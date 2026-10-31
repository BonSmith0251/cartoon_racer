using System.Collections.Generic;
using UnityEngine;

public class RACE_CHECKPOINT : MonoBehaviour
{
	private bool player_enter;

	private bool AI1_enter;

	private bool AI2_enter;

	private bool AI3_enter;

	public int INDEX;

	public void PLAYER_CIRCUIT_RESET()
	{
		player_enter = false;
	}

	public void AI1_CIRCUIT_RESET()
	{
		AI1_enter = false;
	}

	public void AI2_CIRCUIT_RESET()
	{
		AI2_enter = false;
	}

	public void AI3_CIRCUIT_RESET()
	{
		AI3_enter = false;
	}

	public int Test(string Message)
	{
		List<char> list = new List<char>();
		for (int i = 0; i < Message.Length; i++)
		{
			if (Message[i] >= '0' && Message[i] <= '9')
			{
				list.Add(Message[i]);
			}
		}
		string text = string.Empty;
		for (int j = 0; j < list.Count; j++)
		{
			text += list[j];
		}
		int.TryParse(text, out var result);
		INDEX = result;
		return result;
	}

	private void Awake()
	{
		Test(base.gameObject.name);
	}

	private void OnTriggerEnter(Collider car2)
	{
		if ((car2.gameObject.tag == "Player") & (RACE_MANAGER.return_timer == 0f))
		{
			RACE_MANAGER.LAST_x = base.transform.position.x;
			RACE_MANAGER.LAST_y = base.transform.position.y;
			RACE_MANAGER.LAST_z = base.transform.position.z;
			RACE_MANAGER.LAST_rot = base.transform.rotation.eulerAngles.y;
		}
		if ((car2.gameObject.tag == "Player") & !player_enter)
		{
			if (!RACE_TRIGGER._RACE_CIRCUIT)
			{
				RACE_MANAGER.CURRENT_CHECKPOINT_++;
				RACE_MANAGER.CURRENT_CHECKPOINT++;
				RACE_MANAGER.CURRENT_CHECKPOINT_FOR_FINISH++;
				player_enter = true;
				return;
			}
			if (RACE_MANAGER.CURRENT_CHECKPOINT_FOR_FINISH == INDEX)
			{
				RACE_MANAGER.CURRENT_CHECKPOINT_++;
				RACE_MANAGER.CURRENT_CHECKPOINT++;
				RACE_MANAGER.CURRENT_CHECKPOINT_FOR_FINISH++;
				player_enter = true;
				return;
			}
		}
		if ((car2.gameObject.tag == "AI_1") & !AI1_enter)
		{
			if (!RACE_TRIGGER._RACE_CIRCUIT)
			{
				RACE_MANAGER.CURRENT_CHECKPOINT_AI1++;
				RACE_MANAGER.CURRENT_CHECKPOINT_FOR_FINISH_AI1++;
				return;
			}
			if (RACE_MANAGER.CURRENT_CHECKPOINT_FOR_FINISH_AI1 == INDEX)
			{
				RACE_MANAGER.CURRENT_CHECKPOINT_AI1++;
				RACE_MANAGER.CURRENT_CHECKPOINT_FOR_FINISH_AI1++;
				return;
			}
		}
		if ((car2.gameObject.tag == "AI_2") & !AI2_enter)
		{
			if (!RACE_TRIGGER._RACE_CIRCUIT)
			{
				RACE_MANAGER.CURRENT_CHECKPOINT_AI2++;
				RACE_MANAGER.CURRENT_CHECKPOINT_FOR_FINISH_AI2++;
				AI2_enter = true;
				return;
			}
			if (RACE_MANAGER.CURRENT_CHECKPOINT_FOR_FINISH_AI2 == INDEX)
			{
				RACE_MANAGER.CURRENT_CHECKPOINT_AI2++;
				RACE_MANAGER.CURRENT_CHECKPOINT_FOR_FINISH_AI2++;
				AI2_enter = true;
				return;
			}
		}
		if (!((car2.gameObject.tag == "AI_3") & !AI3_enter))
		{
			return;
		}
		if (RACE_TRIGGER._RACE_CIRCUIT)
		{
			if (RACE_MANAGER.CURRENT_CHECKPOINT_FOR_FINISH_AI3 == INDEX)
			{
				RACE_MANAGER.CURRENT_CHECKPOINT_AI3++;
				RACE_MANAGER.CURRENT_CHECKPOINT_FOR_FINISH_AI3++;
				AI3_enter = true;
			}
		}
		else
		{
			RACE_MANAGER.CURRENT_CHECKPOINT_AI3++;
			RACE_MANAGER.CURRENT_CHECKPOINT_FOR_FINISH_AI3++;
			AI3_enter = true;
		}
	}
}
