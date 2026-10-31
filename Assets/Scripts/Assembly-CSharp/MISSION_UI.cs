using UnityEngine;

public class MISSION_UI : MonoBehaviour
{
	public GameObject[] MISSIONS;

	private void OnEnable()
	{
		for (int i = 0; i < MISSIONS.Length; i++)
		{
			if (MISSIONS[i] != null)
			{
				MISSIONS[i].SetActive(value: false);
			}
		}
		MISSIONS[MISSION_TRIGGER._INDEX].SetActive(value: true);
	}
}
