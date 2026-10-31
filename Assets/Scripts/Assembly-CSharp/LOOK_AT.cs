using UnityEngine;

public class LOOK_AT : MonoBehaviour
{
	private GameObject PLAYER;

	private Vector3 posCam;

	private Quaternion lastPos;

	public float turnSpeed = 10f;

	private float distance;

	public AudioClip HEY_TAXI_SND;

	private bool SND;

	private void Start()
	{
		PLAYER = RCC_SceneManager.Instance.activePlayerVehicle.gameObject;
		posCam = PLAYER.transform.position - base.transform.position;
		base.gameObject.transform.rotation = Quaternion.Euler(0f, Random.Range(0, 360), 0f);
	}

	private void Update()
	{
		if (Time.frameCount % 25 == 0 && !SND)
		{
			distance = Vector3.Distance(base.transform.position, PLAYER.gameObject.transform.position);
			if ((distance < 25f) & !GAME_MANAGER.MEDIC_DRIVER)
			{
				AudioSource.PlayClipAtPoint(HEY_TAXI_SND, Camera.main.transform.position);
				SND = true;
				return;
			}
		}
		posCam = PLAYER.transform.position - base.transform.position;
		posCam.y = 0f;
		lastPos = Quaternion.LookRotation(-posCam);
		base.transform.rotation = Quaternion.Slerp(base.transform.rotation, lastPos, Time.deltaTime * turnSpeed);
	}
}
