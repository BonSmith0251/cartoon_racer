using Tayx.Graphy;
using UnityEngine;
using UnityEngine.UI;

public class BENCHMARK_MANAGER : MonoBehaviour
{
	public Image FILL;

	public GameObject POLOSA;

	public GameObject GRAPH;

	public GameObject CAMERA_PATH;

	public Text PROGRES_TXT;

	private float G;

	public GameObject PREOGRESS;

	public GameObject FPS_TUTORIAL;

	public GameObject FPS_RESULT;

	public AudioClip CLICK;

	private bool FINISH;

	public Text FPS_MIN;

	public Text FPS_AV;

	public Text FPS_MAX;

	public Text RESULT_TEXT;

	private void Start()
	{
		POLOSA.SetActive(value: false);
		FILL.fillAmount = 0f;
		G = 0f;
		FINISH = false;
		if (ES2.Load<int>("VIEW_DISTANCE") == 0)
		{
			RenderSettings.fog = true;
			Camera.main.farClipPlane = 110f;
			RenderSettings.fogStartDistance = 90f;
			RenderSettings.fogEndDistance = 110f;
		}
		if (ES2.Load<int>("VIEW_DISTANCE") == 1)
		{
			RenderSettings.fog = true;
			Camera.main.farClipPlane = 140f;
			RenderSettings.fogStartDistance = 120f;
			RenderSettings.fogEndDistance = 150f;
		}
		if (ES2.Load<int>("VIEW_DISTANCE") == 2)
		{
			RenderSettings.fog = true;
			Camera.main.farClipPlane = 170f;
			RenderSettings.fogStartDistance = 150f;
			RenderSettings.fogEndDistance = 180f;
		}
		if (ES2.Load<int>("VIEW_DISTANCE") == 3)
		{
			RenderSettings.fog = true;
			Camera.main.farClipPlane = 220f;
			RenderSettings.fogStartDistance = 190f;
			RenderSettings.fogEndDistance = 225f;
		}
		if (ES2.Load<int>("BLOOMFX") == 1)
		{
			Camera.main.GetComponent<FxPro>().enabled = true;
		}
		else
		{
			Camera.main.GetComponent<FxPro>().enabled = false;
		}
		if (ES2.Load<int>("FILTER") == 0)
		{
			QualitySettings.anisotropicFiltering = AnisotropicFiltering.Disable;
		}
		else
		{
			QualitySettings.anisotropicFiltering = AnisotropicFiltering.Enable;
		}
		if (ES2.Load<int>("TERRAIN") == 0)
		{
			Terrain.activeTerrain.heightmapPixelError = 130f;
			Terrain.activeTerrain.basemapDistance = 170f;
		}
		if (ES2.Load<int>("TERRAIN") == 1)
		{
			Terrain.activeTerrain.heightmapPixelError = 90f;
			Terrain.activeTerrain.basemapDistance = 170f;
		}
		if (ES2.Load<int>("TERRAIN") == 2)
		{
			Terrain.activeTerrain.heightmapPixelError = 60f;
			Terrain.activeTerrain.basemapDistance = 170f;
		}
		if (ES2.Load<int>("TERRAIN") == 3)
		{
			Terrain.activeTerrain.heightmapPixelError = 15f;
			Terrain.activeTerrain.basemapDistance = 170f;
		}
		FPS_TUTORIAL.SetActive(value: true);
		FPS_RESULT.SetActive(value: false);
		GRAPH.SetActive(value: false);
		PREOGRESS.SetActive(value: false);
	}

	public void START_TEST()
	{
		POLOSA.SetActive(value: true);
		FILL.fillAmount = 0f;
		PREOGRESS.SetActive(value: true);
		AudioSource.PlayClipAtPoint(CLICK, Camera.main.transform.position, 0.8f);
		FPS_TUTORIAL.SetActive(value: false);
		CAMERA_PATH.SetActive(value: true);
		GRAPH.SetActive(value: true);
		base.gameObject.GetComponent<AudioSource>().Play();
	}

	public void QUIT()
	{
		AudioSource.PlayClipAtPoint(CLICK, Camera.main.transform.position, 0.8f);
		Application.LoadLevel(0);
	}

	public void QUIT_AFTER_END()
	{
		ES2.Save((int)GRAPH.GetComponent<GraphyManager>().AverageFPS, "BENCHMARK");
		AudioSource.PlayClipAtPoint(CLICK, Camera.main.transform.position, 0.8f);
		Application.LoadLevel(0);
	}

	private void Update()
	{
		Application.targetFrameRate = 20;
		if (Time.frameCount % 30 != 0)
		{
			return;
		}
		if (MENU_MANAGER.LANGUAGE == 0)
		{
			PROGRES_TXT.text = "PROGRESS: " + Mathf.Round(CAMERA_PATH.GetComponent<CameraPathAnimator>().percentage * 10000f / 100f) + "%";
		}
		else
		{
			PROGRES_TXT.text = "ПРОГРЕСС: " + Mathf.Round(CAMERA_PATH.GetComponent<CameraPathAnimator>().percentage * 10000f / 100f) + "%";
		}
		FILL.fillAmount = CAMERA_PATH.GetComponent<CameraPathAnimator>().percentage;
		if (!((Mathf.Round(CAMERA_PATH.GetComponent<CameraPathAnimator>().percentage * 10000f / 100f) > 98f) & !FINISH))
		{
			return;
		}
		POLOSA.SetActive(value: false);
		PREOGRESS.SetActive(value: false);
		base.gameObject.GetComponent<AudioSource>().Stop();
		CAMERA_PATH.SetActive(value: false);
		FPS_RESULT.SetActive(value: true);
		if ((int)GRAPH.GetComponent<GraphyManager>().MinFPS > 29)
		{
			FPS_MIN.color = new Color(0f, 1f, 0f);
		}
		if ((int)GRAPH.GetComponent<GraphyManager>().MinFPS < 30)
		{
			FPS_MIN.color = new Color(1f, 1f, 0f);
		}
		if ((int)GRAPH.GetComponent<GraphyManager>().MinFPS < 15)
		{
			FPS_MIN.color = new Color(1f, 0f, 0f);
		}
		FPS_MIN.text = (int)GRAPH.GetComponent<GraphyManager>().MinFPS + " FPS";
		if ((int)GRAPH.GetComponent<GraphyManager>().AverageFPS > 44)
		{
			FPS_AV.color = new Color(0f, 1f, 0f);
		}
		if ((int)GRAPH.GetComponent<GraphyManager>().AverageFPS < 45)
		{
			FPS_AV.color = new Color(1f, 1f, 0f);
		}
		if ((int)GRAPH.GetComponent<GraphyManager>().AverageFPS < 30)
		{
			FPS_AV.color = new Color(1f, 0f, 0f);
		}
		FPS_AV.text = (int)GRAPH.GetComponent<GraphyManager>().AverageFPS + " FPS";
		if ((int)GRAPH.GetComponent<GraphyManager>().MaxFPS > 44)
		{
			FPS_MAX.color = new Color(0f, 1f, 0f);
		}
		if ((int)GRAPH.GetComponent<GraphyManager>().MaxFPS < 45)
		{
			FPS_MAX.color = new Color(1f, 1f, 0f);
		}
		if ((int)GRAPH.GetComponent<GraphyManager>().MaxFPS < 30)
		{
			FPS_MAX.color = new Color(1f, 0f, 0f);
		}
		FPS_MAX.text = (int)GRAPH.GetComponent<GraphyManager>().MaxFPS + " FPS";
		if (MENU_MANAGER.LANGUAGE == 1)
		{
			if ((int)GRAPH.GetComponent<GraphyManager>().AverageFPS > 10)
			{
				RESULT_TEXT.color = new Color(1f, 0f, 0f);
				RESULT_TEXT.text = "РЕЗУЛЬТАТ: Ужасно";
			}
			if ((int)GRAPH.GetComponent<GraphyManager>().AverageFPS > 20)
			{
				RESULT_TEXT.color = new Color(1f, 0.2f, 0f);
				RESULT_TEXT.text = "РЕЗУЛЬТАТ: Слабо";
			}
			if ((int)GRAPH.GetComponent<GraphyManager>().AverageFPS > 30)
			{
				RESULT_TEXT.color = new Color(1f, 0.7f, 0f);
				RESULT_TEXT.text = "РЕЗУЛЬТАТ: СРЕДНЕ";
			}
			if ((int)GRAPH.GetComponent<GraphyManager>().AverageFPS > 40)
			{
				RESULT_TEXT.color = new Color(1f, 1f, 0f);
				RESULT_TEXT.text = "РЕЗУЛЬТАТ: ХОРОШО";
			}
			if ((int)GRAPH.GetComponent<GraphyManager>().AverageFPS > 50)
			{
				RESULT_TEXT.color = new Color(0.6f, 1f, 0f);
				RESULT_TEXT.text = "РЕЗУЛЬТАТ: ОТЛИЧНО";
			}
			if ((int)GRAPH.GetComponent<GraphyManager>().AverageFPS > 55)
			{
				RESULT_TEXT.color = new Color(0f, 1f, 0f);
				RESULT_TEXT.text = "РЕЗУЛЬТАТ: ИДЕАЛЬНО";
			}
		}
		else
		{
			if ((int)GRAPH.GetComponent<GraphyManager>().AverageFPS > 10)
			{
				RESULT_TEXT.color = new Color(1f, 0f, 0f);
				RESULT_TEXT.text = "RESULT: Very bad";
			}
			if ((int)GRAPH.GetComponent<GraphyManager>().AverageFPS > 20)
			{
				RESULT_TEXT.color = new Color(1f, 0.2f, 0f);
				RESULT_TEXT.text = "RESULT: Bad";
			}
			if ((int)GRAPH.GetComponent<GraphyManager>().AverageFPS > 30)
			{
				RESULT_TEXT.color = new Color(1f, 0.7f, 0f);
				RESULT_TEXT.text = "RESULT: Normal";
			}
			if ((int)GRAPH.GetComponent<GraphyManager>().AverageFPS > 40)
			{
				RESULT_TEXT.color = new Color(1f, 1f, 0f);
				RESULT_TEXT.text = "RESULT: Good";
			}
			if ((int)GRAPH.GetComponent<GraphyManager>().AverageFPS > 50)
			{
				RESULT_TEXT.color = new Color(0.6f, 1f, 0f);
				RESULT_TEXT.text = "RESULT: Very good";
			}
			if ((int)GRAPH.GetComponent<GraphyManager>().AverageFPS > 55)
			{
				RESULT_TEXT.color = new Color(0f, 1f, 0f);
				RESULT_TEXT.text = "RESULT: PERFECT";
			}
		}
		GRAPH.SetActive(value: false);
		FINISH = true;
	}
}
