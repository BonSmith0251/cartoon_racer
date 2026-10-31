using UnityEngine;

public class carAddons : MonoBehaviour
{
	private float time;

	public float RandomizeCarTimer = 1f;

	public ParticleSystem changeParticle;

	public ParticleSystem flashParticle;

	public GameObject car;

	public Material[] ChassisMaterials;

	public GameObject[] AddonFront;

	public GameObject[] AddonMiddle;

	public GameObject[] AddonBack;

	public GameObject[] WheelFront;

	public GameObject[] WheelBack;

	public carTheme[] Theme;

	private int nextTheme;

	public bool useThemes;

	public bool jumpThroughThemes;

	private void disableAllObjects()
	{
		GameObject[] addonFront = AddonFront;
		foreach (GameObject gameObject in addonFront)
		{
			gameObject.GetComponent<Renderer>().enabled = false;
		}
		GameObject[] addonMiddle = AddonMiddle;
		foreach (GameObject gameObject2 in addonMiddle)
		{
			gameObject2.GetComponent<Renderer>().enabled = false;
		}
		GameObject[] addonBack = AddonBack;
		foreach (GameObject gameObject3 in addonBack)
		{
			gameObject3.GetComponent<Renderer>().enabled = false;
		}
		GameObject[] wheelFront = WheelFront;
		foreach (GameObject gameObject4 in wheelFront)
		{
			gameObject4.GetComponent<Renderer>().enabled = false;
		}
		GameObject[] wheelBack = WheelBack;
		foreach (GameObject gameObject5 in wheelBack)
		{
			gameObject5.GetComponent<Renderer>().enabled = false;
		}
	}

	private void carSet(carTheme Set)
	{
		car.GetComponent<Renderer>().material = ChassisMaterials[Set.Mat];
		disableAllObjects();
		changeParticle.Emit(30);
		flashParticle.Emit(2);
		if (Set.aFront > -1)
		{
			AddonFront[Set.aFront].GetComponent<Renderer>().enabled = true;
		}
		if (Set.aMiddle > -1)
		{
			AddonMiddle[Set.aMiddle].GetComponent<Renderer>().enabled = true;
		}
		if (Set.aBack > -1)
		{
			AddonBack[Set.aBack].GetComponent<Renderer>().enabled = true;
		}
		if (Set.wheelF > -1)
		{
			WheelFront[Set.wheelF].GetComponent<Renderer>().enabled = true;
		}
		if (Set.wheelB > -1)
		{
			WheelBack[Set.wheelB].GetComponent<Renderer>().enabled = true;
		}
	}

	private void RandomizeCar()
	{
		car.GetComponent<Renderer>().material = ChassisMaterials[Random.Range(0, ChassisMaterials.Length)];
		disableAllObjects();
		changeParticle.Emit(30);
		flashParticle.Emit(2);
		if (AddonFront.Length > 0)
		{
			AddonFront[Random.Range(0, AddonFront.Length)].GetComponent<Renderer>().enabled = true;
		}
		if (AddonMiddle.Length > 0)
		{
			AddonMiddle[Random.Range(0, AddonMiddle.Length)].GetComponent<Renderer>().enabled = true;
		}
		if (AddonBack.Length > 0)
		{
			AddonBack[Random.Range(0, AddonBack.Length)].GetComponent<Renderer>().enabled = true;
		}
		if (WheelFront.Length > 0)
		{
			WheelFront[Random.Range(0, WheelFront.Length)].GetComponent<Renderer>().enabled = true;
		}
		if (WheelBack.Length > 0)
		{
			WheelBack[Random.Range(0, WheelBack.Length)].GetComponent<Renderer>().enabled = true;
		}
	}

	private void Update()
	{
		if (useThemes)
		{
			if (jumpThroughThemes)
			{
				time -= Time.deltaTime;
				if (time < 0f)
				{
					nextTheme++;
					if (nextTheme > Theme.Length)
					{
						nextTheme = 0;
					}
					carSet(Theme[nextTheme]);
					time = RandomizeCarTimer;
				}
			}
			else if (Input.GetKeyDown(KeyCode.A))
			{
				nextTheme++;
				if (nextTheme > Theme.Length)
				{
					nextTheme = 0;
				}
				carSet(Theme[nextTheme]);
			}
		}
		else
		{
			time -= Time.deltaTime;
			if (time < 0f)
			{
				RandomizeCar();
				time = RandomizeCarTimer;
			}
		}
	}
}
