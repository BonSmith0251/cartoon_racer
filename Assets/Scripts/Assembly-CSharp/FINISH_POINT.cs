using UnityEngine;

public class FINISH_POINT : MonoBehaviour
{
	public bool FINISH_FOR_SPEEDRACE;

	public GameObject PARTICLES;

	private int POP1;

	private int POP2;

	private int POP3;

	private int POP4;

	private int POP5;

	public void ACTIVE_PARTICLES()
	{
		PARTICLES.SetActive(value: true);
	}

	public void HIDE_PARTICLES()
	{
		PARTICLES.SetActive(value: false);
	}

	private void Start()
	{
		if (!RACE_TRIGGER._RACE_SPRINT)
		{
			PARTICLES.SetActive(value: false);
		}
		POP4 = RACE_MANAGER.ALL_CHECKPOINTS - 2;
		POP1 = RACE_MANAGER.ALL_CHECKPOINTS - 1;
		POP2 = RACE_MANAGER.ALL_CHECKPOINTS - 2;
		POP3 = RACE_MANAGER.ALL_CHECKPOINTS + 1;
	}

	private void OnTriggerEnter(Collider car2)
	{
		if (car2.gameObject.tag == "Player")
		{
			if (RACE_TRIGGER._SPEED_RACE)
			{
				if ((RACE_MANAGER.fire_polosa > 0f) & FINISH_FOR_SPEEDRACE)
				{
					RACE_MANAGER.FINISH_RACE = true;
					return;
				}
			}
			else if (RACE_MANAGER.CURRENT_CHECKPOINT_FOR_FINISH == RACE_MANAGER.ALL_CHECKPOINTS || RACE_MANAGER.CURRENT_CHECKPOINT_FOR_FINISH == POP1 || RACE_MANAGER.CURRENT_CHECKPOINT_FOR_FINISH == POP2 || RACE_MANAGER.CURRENT_CHECKPOINT_FOR_FINISH == POP3 || RACE_MANAGER.CURRENT_CHECKPOINT_FOR_FINISH == POP4)
			{
				RACE_MANAGER.CHEKPOINT_UPDATE = true;
				if (RACE_TRIGGER._RACE_CIRCUIT)
				{
					RACE_MANAGER.CURRENT_CHECKPOINT_FOR_FINISH = 0;
					RACE_MANAGER.CURRENT_LAP++;
					RACE_MANAGER.NEW_LAP = true;
					GameObject[] array = GameObject.FindGameObjectsWithTag("CHEKPOINT");
					GameObject[] array2 = array;
					foreach (GameObject gameObject in array2)
					{
						gameObject.GetComponent<RACE_CHECKPOINT>().PLAYER_CIRCUIT_RESET();
					}
				}
				if (RACE_TRIGGER._RACE_CIRCUIT)
				{
					if (!RACE_MANAGER.FINISH_RACE & (RACE_MANAGER.CURRENT_LAP == RACE_TRIGGER._RACE_CIRCUIT_LAPS + 1))
					{
						RACE_MANAGER.FINISH_RACE = true;
					}
				}
				else if (!RACE_MANAGER.FINISH_RACE & (RACE_MANAGER.CURRENT_CHECKPOINT_FOR_FINISH == RACE_MANAGER.ALL_CHECKPOINTS))
				{
					RACE_MANAGER.FINISH_RACE = true;
				}
				return;
			}
		}
		if (car2.gameObject.tag == "AI_1" && RACE_MANAGER.CURRENT_CHECKPOINT_FOR_FINISH_AI1 > RACE_MANAGER.ALL_CHECKPOINTS - 3)
		{
			if (RACE_TRIGGER._RACE_CIRCUIT)
			{
				RACE_MANAGER.CURRENT_CHECKPOINT_FOR_FINISH_AI1 = 0;
				GameObject[] array3 = GameObject.FindGameObjectsWithTag("CHEKPOINT");
				GameObject[] array4 = array3;
				foreach (GameObject gameObject2 in array4)
				{
					gameObject2.GetComponent<RACE_CHECKPOINT>().AI1_CIRCUIT_RESET();
				}
			}
		}
		else if (car2.gameObject.tag == "AI_2" && RACE_MANAGER.CURRENT_CHECKPOINT_FOR_FINISH_AI2 > RACE_MANAGER.ALL_CHECKPOINTS - 3)
		{
			if (RACE_TRIGGER._RACE_CIRCUIT)
			{
				RACE_MANAGER.CURRENT_CHECKPOINT_FOR_FINISH_AI2 = 0;
				GameObject[] array5 = GameObject.FindGameObjectsWithTag("CHEKPOINT");
				GameObject[] array6 = array5;
				foreach (GameObject gameObject3 in array6)
				{
					gameObject3.GetComponent<RACE_CHECKPOINT>().AI2_CIRCUIT_RESET();
				}
			}
		}
		else if (car2.gameObject.tag == "AI_3" && RACE_MANAGER.CURRENT_CHECKPOINT_FOR_FINISH_AI3 > RACE_MANAGER.ALL_CHECKPOINTS - 3 && RACE_TRIGGER._RACE_CIRCUIT)
		{
			RACE_MANAGER.CURRENT_CHECKPOINT_FOR_FINISH_AI3 = 0;
			GameObject[] array7 = GameObject.FindGameObjectsWithTag("CHEKPOINT");
			GameObject[] array8 = array7;
			foreach (GameObject gameObject4 in array8)
			{
				gameObject4.GetComponent<RACE_CHECKPOINT>().AI3_CIRCUIT_RESET();
			}
		}
	}
}
