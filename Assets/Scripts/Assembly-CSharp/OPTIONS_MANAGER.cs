using UnityEngine;
using UnityEngine.UI;

public class OPTIONS_MANAGER : MonoBehaviour
{
	private int SCR_X;

	private int SCR_Y;

	private float DISPLAY_RESOLUTION;

	public GameObject MENU_MANAGER;

	public GameObject[] ALL_CAM;

	public GameObject DISPLAY_CATEGORY;

	public GameObject CONTROL_CATEGORY;

	public GameObject AUDIO_CATEGORY;

	public GameObject GAME_CATEGORY;

	public Sprite ON_BUTTON;

	public Sprite OFF_BUTTON;

	public GameObject DISPLAY_BUTTON;

	public GameObject CONTROL_BUTTON;

	public GameObject AUDIO_BUTTON;

	public GameObject GAME_BUTTON;

	public AudioClip CLICK;

	public AudioClip APPLY;

	public Sprite SELECT_ON_BUTTON;

	public Sprite SELECT_OFF_BUTTON;

	public GameObject TEXTURE_LOW;

	public GameObject TEXTURE_NORM;

	public GameObject TEXTURE_HIGH;

	public GameObject TEXTURE_MAX;

	public GameObject RENDER_LOW;

	public GameObject RENDER_NORM;

	public GameObject RENDER_HIGH;

	public GameObject RENDER_MAX;

	public GameObject VIEW_LOW;

	public GameObject VIEW_NORM;

	public GameObject VIEW_HIGH;

	public GameObject VIEW_MAX;

	public GameObject WATER_LOW;

	public GameObject WATER_NORM;

	public GameObject WATER_HIGH;

	public GameObject WATER_MAX;

	public GameObject LANDSCAPE_LOW;

	public GameObject LANDSCAPE_NORM;

	public GameObject LANDSCAPE_HIGH;

	public GameObject LANDSCAPE_MAX;

	public GameObject FILTER_OFF;

	public GameObject FILTER_ON;

	public GameObject SHADOW_OFF;

	public GameObject SHADOW_ON;

	public GameObject BLOOMFX_OFF;

	public GameObject BLOOMFX_ON;

	public GameObject SKIDMARKS_OFF;

	public GameObject SKIDMARKS_ON;

	public GameObject SET_ARROW;

	public GameObject SET_RUL;

	public GameObject SET_TILT;

	public Scrollbar CONTROL_SENS;

	public Scrollbar TILT_SENS;

	public Scrollbar RUL_SIZE;

	public Scrollbar MAIN_VOLUME;

	public Scrollbar MUSIC_VOLUME;

	public Scrollbar RADIO_VOLUME;

	public GameObject MUSIC_TRACK_ON;

	public GameObject MUSIC_TRACK_OFF;

	public GameObject RUSSIAN_VOICE_ON;

	public GameObject RUSSIAN_VOICE_OFF;

	public GameObject ENGLISH_OBJ;

	public GameObject RUSSIAN_OBJ;

	public GameObject DIST_LOW;

	public GameObject DIST_MED;

	public GameObject DIST_HIGH;

	public GameObject VIBRO_OFF;

	public GameObject VIBRO_ON;

	public GameObject RAIN_OFF;

	public GameObject RAIN_ON;

	public GameObject TRAFFIC_LOW;

	public GameObject TRAFFIC_MED;

	public GameObject TRAFFIC_HIGH;

	public GameObject VSYNC_OFF;

	public GameObject VSYNC_ON;

	public Text BENCH_RESULT;

	public GameObject LOADING_SCREEN;

	public void START_BENCH()
	{
		LOADING_SCREEN.SetActive(value: true);
		Application.LoadLevel(6);
	}

	private void CHECK_ALL()
	{
		if (ES2.Load<int>("BENCHMARK") == 0)
		{
			BENCH_RESULT.text = "-------";
		}
		else
		{
			BENCH_RESULT.text = ES2.Load<int>("BENCHMARK") + " FPS";
		}
		if (ES2.Load<int>("TRAFFIC") == 0)
		{
			TRAFFIC_LOW.GetComponent<Button>().interactable = false;
			TRAFFIC_MED.GetComponent<Button>().interactable = true;
			TRAFFIC_HIGH.GetComponent<Button>().interactable = true;
			TRAFFIC_LOW.GetComponent<Image>().sprite = SELECT_ON_BUTTON;
			TRAFFIC_MED.GetComponent<Image>().sprite = SELECT_OFF_BUTTON;
			TRAFFIC_HIGH.GetComponent<Image>().sprite = SELECT_OFF_BUTTON;
		}
		if (ES2.Load<int>("TRAFFIC") == 1)
		{
			TRAFFIC_LOW.GetComponent<Button>().interactable = true;
			TRAFFIC_MED.GetComponent<Button>().interactable = false;
			TRAFFIC_HIGH.GetComponent<Button>().interactable = true;
			TRAFFIC_LOW.GetComponent<Image>().sprite = SELECT_OFF_BUTTON;
			TRAFFIC_MED.GetComponent<Image>().sprite = SELECT_ON_BUTTON;
			TRAFFIC_HIGH.GetComponent<Image>().sprite = SELECT_OFF_BUTTON;
		}
		if (ES2.Load<int>("TRAFFIC") == 2)
		{
			TRAFFIC_LOW.GetComponent<Button>().interactable = true;
			TRAFFIC_MED.GetComponent<Button>().interactable = true;
			TRAFFIC_HIGH.GetComponent<Button>().interactable = false;
			TRAFFIC_LOW.GetComponent<Image>().sprite = SELECT_OFF_BUTTON;
			TRAFFIC_MED.GetComponent<Image>().sprite = SELECT_OFF_BUTTON;
			TRAFFIC_HIGH.GetComponent<Image>().sprite = SELECT_ON_BUTTON;
		}
		if (ES2.Load<int>("TEXTURES") == 1)
		{
			TEXTURE_LOW.GetComponent<Button>().interactable = true;
			TEXTURE_NORM.GetComponent<Button>().interactable = false;
			TEXTURE_HIGH.GetComponent<Button>().interactable = true;
			TEXTURE_MAX.GetComponent<Button>().interactable = true;
			TEXTURE_LOW.GetComponent<Image>().sprite = SELECT_OFF_BUTTON;
			TEXTURE_NORM.GetComponent<Image>().sprite = SELECT_ON_BUTTON;
			TEXTURE_HIGH.GetComponent<Image>().sprite = SELECT_OFF_BUTTON;
			TEXTURE_MAX.GetComponent<Image>().sprite = SELECT_OFF_BUTTON;
			QualitySettings.SetQualityLevel(1, applyExpensiveChanges: true);
		}
		if (ES2.Load<int>("TEXTURES") == 2)
		{
			TEXTURE_LOW.GetComponent<Button>().interactable = true;
			TEXTURE_NORM.GetComponent<Button>().interactable = true;
			TEXTURE_HIGH.GetComponent<Button>().interactable = false;
			TEXTURE_MAX.GetComponent<Button>().interactable = true;
			TEXTURE_LOW.GetComponent<Image>().sprite = SELECT_OFF_BUTTON;
			TEXTURE_NORM.GetComponent<Image>().sprite = SELECT_OFF_BUTTON;
			TEXTURE_HIGH.GetComponent<Image>().sprite = SELECT_ON_BUTTON;
			TEXTURE_MAX.GetComponent<Image>().sprite = SELECT_OFF_BUTTON;
			QualitySettings.SetQualityLevel(2, applyExpensiveChanges: true);
		}
		if (ES2.Load<int>("TEXTURES") == 3)
		{
			TEXTURE_LOW.GetComponent<Button>().interactable = true;
			TEXTURE_NORM.GetComponent<Button>().interactable = true;
			TEXTURE_HIGH.GetComponent<Button>().interactable = true;
			TEXTURE_MAX.GetComponent<Button>().interactable = false;
			TEXTURE_LOW.GetComponent<Image>().sprite = SELECT_OFF_BUTTON;
			TEXTURE_NORM.GetComponent<Image>().sprite = SELECT_OFF_BUTTON;
			TEXTURE_HIGH.GetComponent<Image>().sprite = SELECT_OFF_BUTTON;
			TEXTURE_MAX.GetComponent<Image>().sprite = SELECT_ON_BUTTON;
			QualitySettings.SetQualityLevel(3, applyExpensiveChanges: true);
		}
		MAIN_VOLUME.value = ES2.Load<float>("MAIN_VOLUME");
		MUSIC_VOLUME.value = ES2.Load<float>("MUSIC_VOLUME");
		RADIO_VOLUME.value = ES2.Load<float>("RADIO_VOLUME");
		AudioListener.volume = MAIN_VOLUME.value;
		MENU_MANAGER.GetComponent<AudioSource>().volume = MUSIC_VOLUME.value - 0.15f;
		if (ES2.Load<int>("LANGUAGE") == 0)
		{
			ENGLISH_OBJ.SetActive(value: true);
			RUSSIAN_OBJ.SetActive(value: false);
		}
		if (ES2.Load<int>("LANGUAGE") == 1)
		{
			ENGLISH_OBJ.SetActive(value: false);
			RUSSIAN_OBJ.SetActive(value: true);
		}
		if (ES2.Load<int>("RAIN") == 0)
		{
			RAIN_OFF.GetComponent<Button>().interactable = false;
			RAIN_ON.GetComponent<Button>().interactable = true;
			RAIN_OFF.GetComponent<Image>().sprite = SELECT_ON_BUTTON;
			RAIN_ON.GetComponent<Image>().sprite = SELECT_OFF_BUTTON;
		}
		if (ES2.Load<int>("RAIN") == 1)
		{
			RAIN_OFF.GetComponent<Button>().interactable = true;
			RAIN_ON.GetComponent<Button>().interactable = false;
			RAIN_OFF.GetComponent<Image>().sprite = SELECT_OFF_BUTTON;
			RAIN_ON.GetComponent<Image>().sprite = SELECT_ON_BUTTON;
		}
		if (ES2.Load<int>("VIBRO") == 0)
		{
			VIBRO_OFF.GetComponent<Button>().interactable = false;
			VIBRO_ON.GetComponent<Button>().interactable = true;
			VIBRO_OFF.GetComponent<Image>().sprite = SELECT_ON_BUTTON;
			VIBRO_ON.GetComponent<Image>().sprite = SELECT_OFF_BUTTON;
		}
		if (ES2.Load<int>("VIBRO") == 1)
		{
			VIBRO_OFF.GetComponent<Button>().interactable = true;
			VIBRO_ON.GetComponent<Button>().interactable = false;
			VIBRO_OFF.GetComponent<Image>().sprite = SELECT_OFF_BUTTON;
			VIBRO_ON.GetComponent<Image>().sprite = SELECT_ON_BUTTON;
		}
		if (ES2.Load<int>("VIEW") == 0)
		{
			DIST_LOW.GetComponent<Button>().interactable = false;
			DIST_MED.GetComponent<Button>().interactable = true;
			DIST_HIGH.GetComponent<Button>().interactable = true;
			DIST_LOW.GetComponent<Image>().sprite = SELECT_ON_BUTTON;
			DIST_MED.GetComponent<Image>().sprite = SELECT_OFF_BUTTON;
			DIST_HIGH.GetComponent<Image>().sprite = SELECT_OFF_BUTTON;
		}
		if (ES2.Load<int>("VIEW") == 1)
		{
			DIST_LOW.GetComponent<Button>().interactable = true;
			DIST_MED.GetComponent<Button>().interactable = false;
			DIST_HIGH.GetComponent<Button>().interactable = true;
			DIST_LOW.GetComponent<Image>().sprite = SELECT_OFF_BUTTON;
			DIST_MED.GetComponent<Image>().sprite = SELECT_ON_BUTTON;
			DIST_HIGH.GetComponent<Image>().sprite = SELECT_OFF_BUTTON;
		}
		if (ES2.Load<int>("VIEW") == 2)
		{
			DIST_LOW.GetComponent<Button>().interactable = true;
			DIST_MED.GetComponent<Button>().interactable = true;
			DIST_HIGH.GetComponent<Button>().interactable = false;
			DIST_LOW.GetComponent<Image>().sprite = SELECT_OFF_BUTTON;
			DIST_MED.GetComponent<Image>().sprite = SELECT_OFF_BUTTON;
			DIST_HIGH.GetComponent<Image>().sprite = SELECT_ON_BUTTON;
		}
		if (ES2.Load<int>("MUSIC_TRACK") == 0)
		{
			MUSIC_TRACK_ON.GetComponent<Image>().sprite = SELECT_OFF_BUTTON;
			MUSIC_TRACK_OFF.GetComponent<Image>().sprite = SELECT_ON_BUTTON;
			MUSIC_TRACK_ON.GetComponent<Button>().interactable = true;
			MUSIC_TRACK_OFF.GetComponent<Button>().interactable = false;
		}
		if (ES2.Load<int>("MUSIC_TRACK") == 1)
		{
			MUSIC_TRACK_ON.GetComponent<Image>().sprite = SELECT_ON_BUTTON;
			MUSIC_TRACK_OFF.GetComponent<Image>().sprite = SELECT_OFF_BUTTON;
			MUSIC_TRACK_ON.GetComponent<Button>().interactable = false;
			MUSIC_TRACK_OFF.GetComponent<Button>().interactable = true;
		}
		if (ES2.Load<int>("RUS_VOICE") == 0)
		{
			RUSSIAN_VOICE_ON.GetComponent<Image>().sprite = SELECT_OFF_BUTTON;
			RUSSIAN_VOICE_OFF.GetComponent<Image>().sprite = SELECT_ON_BUTTON;
			RUSSIAN_VOICE_ON.GetComponent<Button>().interactable = true;
			RUSSIAN_VOICE_OFF.GetComponent<Button>().interactable = false;
		}
		if (ES2.Load<int>("RUS_VOICE") == 1)
		{
			RUSSIAN_VOICE_ON.GetComponent<Image>().sprite = SELECT_ON_BUTTON;
			RUSSIAN_VOICE_OFF.GetComponent<Image>().sprite = SELECT_OFF_BUTTON;
			RUSSIAN_VOICE_ON.GetComponent<Button>().interactable = false;
			RUSSIAN_VOICE_OFF.GetComponent<Button>().interactable = true;
		}
		if (ES2.Load<int>("TEXTURES") == 0)
		{
			TEXTURE_LOW.GetComponent<Button>().interactable = false;
			TEXTURE_NORM.GetComponent<Button>().interactable = true;
			TEXTURE_HIGH.GetComponent<Button>().interactable = true;
			TEXTURE_MAX.GetComponent<Button>().interactable = true;
			TEXTURE_LOW.GetComponent<Image>().sprite = SELECT_ON_BUTTON;
			TEXTURE_NORM.GetComponent<Image>().sprite = SELECT_OFF_BUTTON;
			TEXTURE_HIGH.GetComponent<Image>().sprite = SELECT_OFF_BUTTON;
			TEXTURE_MAX.GetComponent<Image>().sprite = SELECT_OFF_BUTTON;
			QualitySettings.SetQualityLevel(0, applyExpensiveChanges: true);
		}
		if (ES2.Load<float>("RESOLUTION") == 0.5f)
		{
			RENDER_LOW.GetComponent<Button>().interactable = false;
			RENDER_NORM.GetComponent<Button>().interactable = true;
			RENDER_HIGH.GetComponent<Button>().interactable = true;
			RENDER_MAX.GetComponent<Button>().interactable = true;
			RENDER_LOW.GetComponent<Image>().sprite = SELECT_ON_BUTTON;
			RENDER_NORM.GetComponent<Image>().sprite = SELECT_OFF_BUTTON;
			RENDER_HIGH.GetComponent<Image>().sprite = SELECT_OFF_BUTTON;
			RENDER_MAX.GetComponent<Image>().sprite = SELECT_OFF_BUTTON;
		}
		if (ES2.Load<float>("RESOLUTION") == 0.6f || ES2.Load<float>("RESOLUTION") == 0.7f)
		{
			RENDER_LOW.GetComponent<Button>().interactable = true;
			RENDER_NORM.GetComponent<Button>().interactable = false;
			RENDER_HIGH.GetComponent<Button>().interactable = true;
			RENDER_MAX.GetComponent<Button>().interactable = true;
			RENDER_LOW.GetComponent<Image>().sprite = SELECT_OFF_BUTTON;
			RENDER_NORM.GetComponent<Image>().sprite = SELECT_ON_BUTTON;
			RENDER_HIGH.GetComponent<Image>().sprite = SELECT_OFF_BUTTON;
			RENDER_MAX.GetComponent<Image>().sprite = SELECT_OFF_BUTTON;
		}
		if (ES2.Load<float>("RESOLUTION") == 0.7f || ES2.Load<float>("RESOLUTION") == 0.8f)
		{
			RENDER_LOW.GetComponent<Button>().interactable = true;
			RENDER_NORM.GetComponent<Button>().interactable = true;
			RENDER_HIGH.GetComponent<Button>().interactable = false;
			RENDER_MAX.GetComponent<Button>().interactable = true;
			RENDER_LOW.GetComponent<Image>().sprite = SELECT_OFF_BUTTON;
			RENDER_NORM.GetComponent<Image>().sprite = SELECT_OFF_BUTTON;
			RENDER_HIGH.GetComponent<Image>().sprite = SELECT_ON_BUTTON;
			RENDER_MAX.GetComponent<Image>().sprite = SELECT_OFF_BUTTON;
		}
		if (ES2.Load<float>("RESOLUTION") == 0.9f || ES2.Load<float>("RESOLUTION") == 1f)
		{
			RENDER_LOW.GetComponent<Button>().interactable = true;
			RENDER_NORM.GetComponent<Button>().interactable = true;
			RENDER_HIGH.GetComponent<Button>().interactable = true;
			RENDER_MAX.GetComponent<Button>().interactable = false;
			RENDER_LOW.GetComponent<Image>().sprite = SELECT_OFF_BUTTON;
			RENDER_NORM.GetComponent<Image>().sprite = SELECT_OFF_BUTTON;
			RENDER_HIGH.GetComponent<Image>().sprite = SELECT_OFF_BUTTON;
			RENDER_MAX.GetComponent<Image>().sprite = SELECT_ON_BUTTON;
		}
		if (ES2.Load<int>("VIEW_DISTANCE") == 0)
		{
			VIEW_LOW.GetComponent<Button>().interactable = false;
			VIEW_NORM.GetComponent<Button>().interactable = true;
			VIEW_HIGH.GetComponent<Button>().interactable = true;
			VIEW_MAX.GetComponent<Button>().interactable = true;
			VIEW_LOW.GetComponent<Image>().sprite = SELECT_ON_BUTTON;
			VIEW_NORM.GetComponent<Image>().sprite = SELECT_OFF_BUTTON;
			VIEW_HIGH.GetComponent<Image>().sprite = SELECT_OFF_BUTTON;
			VIEW_MAX.GetComponent<Image>().sprite = SELECT_OFF_BUTTON;
		}
		if (ES2.Load<int>("VIEW_DISTANCE") == 1)
		{
			VIEW_LOW.GetComponent<Button>().interactable = true;
			VIEW_NORM.GetComponent<Button>().interactable = false;
			VIEW_HIGH.GetComponent<Button>().interactable = true;
			VIEW_MAX.GetComponent<Button>().interactable = true;
			VIEW_LOW.GetComponent<Image>().sprite = SELECT_OFF_BUTTON;
			VIEW_NORM.GetComponent<Image>().sprite = SELECT_ON_BUTTON;
			VIEW_HIGH.GetComponent<Image>().sprite = SELECT_OFF_BUTTON;
			VIEW_MAX.GetComponent<Image>().sprite = SELECT_OFF_BUTTON;
		}
		if (ES2.Load<int>("VIEW_DISTANCE") == 2)
		{
			VIEW_LOW.GetComponent<Button>().interactable = true;
			VIEW_NORM.GetComponent<Button>().interactable = true;
			VIEW_HIGH.GetComponent<Button>().interactable = false;
			VIEW_MAX.GetComponent<Button>().interactable = true;
			VIEW_LOW.GetComponent<Image>().sprite = SELECT_OFF_BUTTON;
			VIEW_NORM.GetComponent<Image>().sprite = SELECT_OFF_BUTTON;
			VIEW_HIGH.GetComponent<Image>().sprite = SELECT_ON_BUTTON;
			VIEW_MAX.GetComponent<Image>().sprite = SELECT_OFF_BUTTON;
		}
		if (ES2.Load<int>("VIEW_DISTANCE") == 3)
		{
			VIEW_LOW.GetComponent<Button>().interactable = true;
			VIEW_NORM.GetComponent<Button>().interactable = true;
			VIEW_HIGH.GetComponent<Button>().interactable = true;
			VIEW_MAX.GetComponent<Button>().interactable = false;
			VIEW_LOW.GetComponent<Image>().sprite = SELECT_OFF_BUTTON;
			VIEW_NORM.GetComponent<Image>().sprite = SELECT_OFF_BUTTON;
			VIEW_HIGH.GetComponent<Image>().sprite = SELECT_OFF_BUTTON;
			VIEW_MAX.GetComponent<Image>().sprite = SELECT_ON_BUTTON;
		}
		if (ES2.Load<int>("WATER_QUALITY") == 0)
		{
			WATER_LOW.GetComponent<Button>().interactable = false;
			WATER_NORM.GetComponent<Button>().interactable = true;
			WATER_HIGH.GetComponent<Button>().interactable = true;
			WATER_MAX.GetComponent<Button>().interactable = true;
			WATER_LOW.GetComponent<Image>().sprite = SELECT_ON_BUTTON;
			WATER_NORM.GetComponent<Image>().sprite = SELECT_OFF_BUTTON;
			WATER_HIGH.GetComponent<Image>().sprite = SELECT_OFF_BUTTON;
			WATER_MAX.GetComponent<Image>().sprite = SELECT_OFF_BUTTON;
		}
		if (ES2.Load<int>("WATER_QUALITY") == 1)
		{
			WATER_LOW.GetComponent<Button>().interactable = true;
			WATER_NORM.GetComponent<Button>().interactable = false;
			WATER_HIGH.GetComponent<Button>().interactable = true;
			WATER_MAX.GetComponent<Button>().interactable = true;
			WATER_LOW.GetComponent<Image>().sprite = SELECT_OFF_BUTTON;
			WATER_NORM.GetComponent<Image>().sprite = SELECT_ON_BUTTON;
			WATER_HIGH.GetComponent<Image>().sprite = SELECT_OFF_BUTTON;
			WATER_MAX.GetComponent<Image>().sprite = SELECT_OFF_BUTTON;
		}
		if (ES2.Load<int>("WATER_QUALITY") == 2)
		{
			WATER_LOW.GetComponent<Button>().interactable = true;
			WATER_NORM.GetComponent<Button>().interactable = true;
			WATER_HIGH.GetComponent<Button>().interactable = false;
			WATER_MAX.GetComponent<Button>().interactable = true;
			WATER_LOW.GetComponent<Image>().sprite = SELECT_OFF_BUTTON;
			WATER_NORM.GetComponent<Image>().sprite = SELECT_OFF_BUTTON;
			WATER_HIGH.GetComponent<Image>().sprite = SELECT_ON_BUTTON;
			WATER_MAX.GetComponent<Image>().sprite = SELECT_OFF_BUTTON;
		}
		if (ES2.Load<int>("WATER_QUALITY") == 3)
		{
			WATER_LOW.GetComponent<Button>().interactable = true;
			WATER_NORM.GetComponent<Button>().interactable = true;
			WATER_HIGH.GetComponent<Button>().interactable = true;
			WATER_MAX.GetComponent<Button>().interactable = false;
			WATER_LOW.GetComponent<Image>().sprite = SELECT_OFF_BUTTON;
			WATER_NORM.GetComponent<Image>().sprite = SELECT_OFF_BUTTON;
			WATER_HIGH.GetComponent<Image>().sprite = SELECT_OFF_BUTTON;
			WATER_MAX.GetComponent<Image>().sprite = SELECT_ON_BUTTON;
		}
		if (ES2.Load<int>("TERRAIN") == 0)
		{
			LANDSCAPE_LOW.GetComponent<Button>().interactable = false;
			LANDSCAPE_NORM.GetComponent<Button>().interactable = true;
			LANDSCAPE_HIGH.GetComponent<Button>().interactable = true;
			LANDSCAPE_MAX.GetComponent<Button>().interactable = true;
			LANDSCAPE_LOW.GetComponent<Image>().sprite = SELECT_ON_BUTTON;
			LANDSCAPE_NORM.GetComponent<Image>().sprite = SELECT_OFF_BUTTON;
			LANDSCAPE_HIGH.GetComponent<Image>().sprite = SELECT_OFF_BUTTON;
			LANDSCAPE_MAX.GetComponent<Image>().sprite = SELECT_OFF_BUTTON;
		}
		if (ES2.Load<int>("TERRAIN") == 1)
		{
			LANDSCAPE_LOW.GetComponent<Button>().interactable = true;
			LANDSCAPE_NORM.GetComponent<Button>().interactable = false;
			LANDSCAPE_HIGH.GetComponent<Button>().interactable = true;
			LANDSCAPE_MAX.GetComponent<Button>().interactable = true;
			LANDSCAPE_LOW.GetComponent<Image>().sprite = SELECT_OFF_BUTTON;
			LANDSCAPE_NORM.GetComponent<Image>().sprite = SELECT_ON_BUTTON;
			LANDSCAPE_HIGH.GetComponent<Image>().sprite = SELECT_OFF_BUTTON;
			LANDSCAPE_MAX.GetComponent<Image>().sprite = SELECT_OFF_BUTTON;
		}
		if (ES2.Load<int>("TERRAIN") == 2)
		{
			LANDSCAPE_LOW.GetComponent<Button>().interactable = true;
			LANDSCAPE_NORM.GetComponent<Button>().interactable = true;
			LANDSCAPE_HIGH.GetComponent<Button>().interactable = false;
			LANDSCAPE_MAX.GetComponent<Button>().interactable = true;
			LANDSCAPE_LOW.GetComponent<Image>().sprite = SELECT_OFF_BUTTON;
			LANDSCAPE_NORM.GetComponent<Image>().sprite = SELECT_OFF_BUTTON;
			LANDSCAPE_HIGH.GetComponent<Image>().sprite = SELECT_ON_BUTTON;
			LANDSCAPE_MAX.GetComponent<Image>().sprite = SELECT_OFF_BUTTON;
		}
		if (ES2.Load<int>("TERRAIN") == 3)
		{
			LANDSCAPE_LOW.GetComponent<Button>().interactable = true;
			LANDSCAPE_NORM.GetComponent<Button>().interactable = true;
			LANDSCAPE_HIGH.GetComponent<Button>().interactable = true;
			LANDSCAPE_MAX.GetComponent<Button>().interactable = false;
			LANDSCAPE_LOW.GetComponent<Image>().sprite = SELECT_OFF_BUTTON;
			LANDSCAPE_NORM.GetComponent<Image>().sprite = SELECT_OFF_BUTTON;
			LANDSCAPE_HIGH.GetComponent<Image>().sprite = SELECT_OFF_BUTTON;
			LANDSCAPE_MAX.GetComponent<Image>().sprite = SELECT_ON_BUTTON;
		}
		if (ES2.Load<int>("FILTER") == 0)
		{
			FILTER_OFF.GetComponent<Button>().interactable = false;
			FILTER_ON.GetComponent<Button>().interactable = true;
			FILTER_OFF.GetComponent<Image>().sprite = SELECT_ON_BUTTON;
			FILTER_ON.GetComponent<Image>().sprite = SELECT_OFF_BUTTON;
		}
		if (ES2.Load<int>("FILTER") == 1)
		{
			FILTER_OFF.GetComponent<Button>().interactable = true;
			FILTER_ON.GetComponent<Button>().interactable = false;
			FILTER_OFF.GetComponent<Image>().sprite = SELECT_OFF_BUTTON;
			FILTER_ON.GetComponent<Image>().sprite = SELECT_ON_BUTTON;
		}
		if (ES2.Load<int>("SHADOW") == 0)
		{
			SHADOW_OFF.GetComponent<Button>().interactable = false;
			SHADOW_ON.GetComponent<Button>().interactable = true;
			SHADOW_OFF.GetComponent<Image>().sprite = SELECT_ON_BUTTON;
			SHADOW_ON.GetComponent<Image>().sprite = SELECT_OFF_BUTTON;
		}
		if (ES2.Load<int>("SHADOW") == 1)
		{
			SHADOW_OFF.GetComponent<Button>().interactable = true;
			SHADOW_ON.GetComponent<Button>().interactable = false;
			SHADOW_OFF.GetComponent<Image>().sprite = SELECT_OFF_BUTTON;
			SHADOW_ON.GetComponent<Image>().sprite = SELECT_ON_BUTTON;
		}
		if (ES2.Load<int>("BLOOMFX") == 0)
		{
			BLOOMFX_OFF.GetComponent<Button>().interactable = false;
			BLOOMFX_ON.GetComponent<Button>().interactable = true;
			BLOOMFX_OFF.GetComponent<Image>().sprite = SELECT_ON_BUTTON;
			BLOOMFX_ON.GetComponent<Image>().sprite = SELECT_OFF_BUTTON;
		}
		if (ES2.Load<int>("BLOOMFX") == 1)
		{
			BLOOMFX_OFF.GetComponent<Button>().interactable = true;
			BLOOMFX_ON.GetComponent<Button>().interactable = false;
			BLOOMFX_OFF.GetComponent<Image>().sprite = SELECT_OFF_BUTTON;
			BLOOMFX_ON.GetComponent<Image>().sprite = SELECT_ON_BUTTON;
		}
		if (ES2.Load<int>("SKIDMARK") == 0)
		{
			SKIDMARKS_OFF.GetComponent<Button>().interactable = false;
			SKIDMARKS_ON.GetComponent<Button>().interactable = true;
			SKIDMARKS_OFF.GetComponent<Image>().sprite = SELECT_ON_BUTTON;
			SKIDMARKS_ON.GetComponent<Image>().sprite = SELECT_OFF_BUTTON;
		}
		if (ES2.Load<int>("SKIDMARK") == 1)
		{
			SKIDMARKS_OFF.GetComponent<Button>().interactable = true;
			SKIDMARKS_ON.GetComponent<Button>().interactable = false;
			SKIDMARKS_OFF.GetComponent<Image>().sprite = SELECT_OFF_BUTTON;
			SKIDMARKS_ON.GetComponent<Image>().sprite = SELECT_ON_BUTTON;
		}
		if (ES2.Load<int>("VSYNC") == 0)
		{
			VSYNC_OFF.GetComponent<Button>().interactable = false;
			VSYNC_ON.GetComponent<Button>().interactable = true;
			VSYNC_OFF.GetComponent<Image>().sprite = SELECT_ON_BUTTON;
			VSYNC_ON.GetComponent<Image>().sprite = SELECT_OFF_BUTTON;
		}
		if (ES2.Load<int>("VSYNC") == 1)
		{
			VSYNC_OFF.GetComponent<Button>().interactable = true;
			VSYNC_ON.GetComponent<Button>().interactable = false;
			VSYNC_OFF.GetComponent<Image>().sprite = SELECT_OFF_BUTTON;
			VSYNC_ON.GetComponent<Image>().sprite = SELECT_ON_BUTTON;
		}
		if (ES2.Load<int>("CONTROL") == 0)
		{
			SET_ARROW.SetActive(value: false);
			SET_RUL.SetActive(value: true);
			SET_TILT.SetActive(value: false);
		}
		if (ES2.Load<int>("CONTROL") == 1)
		{
			SET_ARROW.SetActive(value: true);
			SET_RUL.SetActive(value: false);
			SET_TILT.SetActive(value: false);
		}
		if (ES2.Load<int>("CONTROL") == 2)
		{
			SET_ARROW.SetActive(value: false);
			SET_RUL.SetActive(value: false);
			SET_TILT.SetActive(value: true);
		}
		CONTROL_SENS.value = ES2.Load<float>("SPEED_CONTROL") / 2f;
		TILT_SENS.value = ES2.Load<float>("SPEED_TILT") / 2f;
		RUL_SIZE.value = ES2.Load<float>("WHEEL_SIZE") / 2f;
	}

	public void SET_VSYNC_OFF()
	{
		ES2.Save(0, "VSYNC");
		QualitySettings.vSyncCount = 0;
		CHECK_ALL();
	}

	public void SET_VSYNC_ON()
	{
		ES2.Save(1, "VSYNC");
		QualitySettings.vSyncCount = 1;
		CHECK_ALL();
	}

	public void SET_ENGLISH()
	{
		ES2.Save(0, "LANGUAGE");
		Application.LoadLevel(0);
	}

	public void SET_RUSSIAN()
	{
		ES2.Save(1, "LANGUAGE");
		Application.LoadLevel(0);
	}

	public void SET_TRAFFIC_LOW()
	{
		ES2.Save(0, "TRAFFIC");
		CHECK_ALL();
	}

	public void SET_TRAFFIC_NORM()
	{
		ES2.Save(1, "TRAFFIC");
		CHECK_ALL();
	}

	public void SET_TRAFFIC_HIGH()
	{
		ES2.Save(2, "TRAFFIC");
		CHECK_ALL();
	}

	public void SET_DIST_LOW()
	{
		ES2.Save(0, "VIEW");
		CHECK_ALL();
	}

	public void SET_DIST_NORM()
	{
		ES2.Save(1, "VIEW");
		CHECK_ALL();
	}

	public void SET_DIST_FAR()
	{
		ES2.Save(2, "VIEW");
		CHECK_ALL();
	}

	public void SET_VIBRO_OFF()
	{
		ES2.Save(0, "VIBRO");
		CHECK_ALL();
	}

	public void SET_VIBRO_ON()
	{
		ES2.Save(1, "VIBRO");
		CHECK_ALL();
	}

	public void SET_RAIN_OFF()
	{
		ES2.Save(0, "RAIN");
		CHECK_ALL();
	}

	public void SET_RAIN_ON()
	{
		ES2.Save(1, "RAIN");
		CHECK_ALL();
	}

	public void SET_CONTROL_SENS()
	{
		ES2.Save(CONTROL_SENS.value * 2f, "SPEED_CONTROL");
		CONTROL_SENS.value = ES2.Load<float>("SPEED_CONTROL") / 2f;
	}

	public void SET_TILT_SENS()
	{
		ES2.Save(TILT_SENS.value * 2f, "SPEED_TILT");
		TILT_SENS.value = ES2.Load<float>("SPEED_TILT") / 2f;
	}

	public void SET_WHEEL_SENS()
	{
		ES2.Save(RUL_SIZE.value * 2f, "WHEEL_SIZE");
		RUL_SIZE.value = ES2.Load<float>("WHEEL_SIZE") / 2f;
	}

	public void CHANGE_MAIN_VOLUME()
	{
		ES2.Save(MAIN_VOLUME.value, "MAIN_VOLUME");
		MAIN_VOLUME.value = ES2.Load<float>("MAIN_VOLUME");
	}

	public void CHANGE_RADIO_VOLUME()
	{
		ES2.Save(RADIO_VOLUME.value, "RADIO_VOLUME");
		MUSIC_VOLUME.value = ES2.Load<float>("MUSIC_VOLUME");
	}

	public void CHANGE_MUSIC_VOLUME()
	{
		ES2.Save(MUSIC_VOLUME.value, "MUSIC_VOLUME");
		RADIO_VOLUME.value = ES2.Load<float>("RADIO_VOLUME");
	}

	public void SET_MUSIC_TRACK_OFF()
	{
		ES2.Save(0, "MUSIC_TRACK");
		CHECK_ALL();
	}

	public void SET_MUSIC_TRACK_ON()
	{
		ES2.Save(1, "MUSIC_TRACK");
		CHECK_ALL();
	}

	public void SET_RUSSIAN_OFF()
	{
		ES2.Save(0, "RUS_VOICE");
		CHECK_ALL();
	}

	public void SET_RUSSIAN_ON()
	{
		ES2.Save(1, "RUS_VOICE");
		CHECK_ALL();
	}

	private void OnEnable()
	{
		DISPLAY_CATEGORY.SetActive(value: true);
		CONTROL_CATEGORY.SetActive(value: false);
		AUDIO_CATEGORY.SetActive(value: false);
		GAME_CATEGORY.SetActive(value: false);
		DISPLAY_BUTTON.GetComponent<Button>().interactable = false;
		CONTROL_BUTTON.GetComponent<Button>().interactable = true;
		GAME_BUTTON.GetComponent<Button>().interactable = true;
		AUDIO_BUTTON.GetComponent<Button>().interactable = true;
		DISPLAY_BUTTON.GetComponent<Image>().sprite = ON_BUTTON;
		CONTROL_BUTTON.GetComponent<Image>().sprite = OFF_BUTTON;
		AUDIO_BUTTON.GetComponent<Image>().sprite = OFF_BUTTON;
		GAME_BUTTON.GetComponent<Image>().sprite = OFF_BUTTON;
		CHECK_ALL();
	}

	public void OPEN_DISPLAY()
	{
		AudioSource.PlayClipAtPoint(CLICK, Camera.main.transform.position);
		DISPLAY_CATEGORY.SetActive(value: true);
		CONTROL_CATEGORY.SetActive(value: false);
		AUDIO_CATEGORY.SetActive(value: false);
		GAME_CATEGORY.SetActive(value: false);
		DISPLAY_BUTTON.GetComponent<Image>().sprite = ON_BUTTON;
		CONTROL_BUTTON.GetComponent<Image>().sprite = OFF_BUTTON;
		AUDIO_BUTTON.GetComponent<Image>().sprite = OFF_BUTTON;
		GAME_BUTTON.GetComponent<Image>().sprite = OFF_BUTTON;
		DISPLAY_BUTTON.GetComponent<Button>().interactable = false;
		CONTROL_BUTTON.GetComponent<Button>().interactable = true;
		GAME_BUTTON.GetComponent<Button>().interactable = true;
		AUDIO_BUTTON.GetComponent<Button>().interactable = true;
	}

	public void OPEN_CONTROL()
	{
		AudioSource.PlayClipAtPoint(CLICK, Camera.main.transform.position);
		DISPLAY_CATEGORY.SetActive(value: false);
		CONTROL_CATEGORY.SetActive(value: true);
		AUDIO_CATEGORY.SetActive(value: false);
		GAME_CATEGORY.SetActive(value: false);
		DISPLAY_BUTTON.GetComponent<Image>().sprite = OFF_BUTTON;
		CONTROL_BUTTON.GetComponent<Image>().sprite = ON_BUTTON;
		AUDIO_BUTTON.GetComponent<Image>().sprite = OFF_BUTTON;
		GAME_BUTTON.GetComponent<Image>().sprite = OFF_BUTTON;
		DISPLAY_BUTTON.GetComponent<Button>().interactable = true;
		CONTROL_BUTTON.GetComponent<Button>().interactable = false;
		GAME_BUTTON.GetComponent<Button>().interactable = true;
		AUDIO_BUTTON.GetComponent<Button>().interactable = true;
	}

	public void OPEN_AUDIO()
	{
		AudioSource.PlayClipAtPoint(CLICK, Camera.main.transform.position);
		DISPLAY_CATEGORY.SetActive(value: false);
		CONTROL_CATEGORY.SetActive(value: false);
		AUDIO_CATEGORY.SetActive(value: true);
		GAME_CATEGORY.SetActive(value: false);
		DISPLAY_BUTTON.GetComponent<Image>().sprite = OFF_BUTTON;
		CONTROL_BUTTON.GetComponent<Image>().sprite = OFF_BUTTON;
		AUDIO_BUTTON.GetComponent<Image>().sprite = ON_BUTTON;
		GAME_BUTTON.GetComponent<Image>().sprite = OFF_BUTTON;
		DISPLAY_BUTTON.GetComponent<Button>().interactable = true;
		CONTROL_BUTTON.GetComponent<Button>().interactable = true;
		GAME_BUTTON.GetComponent<Button>().interactable = true;
		AUDIO_BUTTON.GetComponent<Button>().interactable = false;
	}

	public void OPEN_GAME()
	{
		AudioSource.PlayClipAtPoint(CLICK, Camera.main.transform.position);
		DISPLAY_CATEGORY.SetActive(value: false);
		CONTROL_CATEGORY.SetActive(value: false);
		AUDIO_CATEGORY.SetActive(value: false);
		GAME_CATEGORY.SetActive(value: true);
		DISPLAY_BUTTON.GetComponent<Image>().sprite = OFF_BUTTON;
		CONTROL_BUTTON.GetComponent<Image>().sprite = OFF_BUTTON;
		AUDIO_BUTTON.GetComponent<Image>().sprite = OFF_BUTTON;
		GAME_BUTTON.GetComponent<Image>().sprite = ON_BUTTON;
		DISPLAY_BUTTON.GetComponent<Button>().interactable = true;
		CONTROL_BUTTON.GetComponent<Button>().interactable = true;
		GAME_BUTTON.GetComponent<Button>().interactable = false;
		AUDIO_BUTTON.GetComponent<Button>().interactable = true;
	}

	public void SET_CONTROL_1()
	{
		AudioSource.PlayClipAtPoint(APPLY, Camera.main.transform.position);
		ES2.Save(1, "CONTROL");
		CHECK_ALL();
	}

	public void SET_CONTROL_2()
	{
		AudioSource.PlayClipAtPoint(APPLY, Camera.main.transform.position);
		ES2.Save(0, "CONTROL");
		CHECK_ALL();
	}

	public void SET_CONTROL_3()
	{
		AudioSource.PlayClipAtPoint(APPLY, Camera.main.transform.position);
		ES2.Save(2, "CONTROL");
		CHECK_ALL();
	}

	public void SET_TEXTURE_LOW()
	{
		ES2.Save(0, "TEXTURES");
		CHECK_ALL();
	}

	public void SET_TEXTURE_NORM()
	{
		ES2.Save(1, "TEXTURES");
		CHECK_ALL();
	}

	public void SET_TEXTURE_HIGH()
	{
		ES2.Save(2, "TEXTURES");
		CHECK_ALL();
	}

	public void SET_TEXTURE_MAX()
	{
		ES2.Save(3, "TEXTURES");
		CHECK_ALL();
	}

	public void SET_RENDER_LOW()
	{
		ES2.Save(0.5f, "RESOLUTION");
		DISPLAY_RESOLUTION = ES2.Load<float>("RESOLUTION");
		SCR_X = ES2.Load<int>("DISPLAY_X");
		SCR_Y = ES2.Load<int>("DISPLAY_Y");
		float num = DISPLAY_RESOLUTION * 100f - 10f;
		Screen.SetResolution(SCR_X * (int)num / 100, SCR_Y * (int)num / 100, fullscreen: true);
		CHECK_ALL();
	}

	public void SET_RENDER_NORM()
	{
		ES2.Save(0.6f, "RESOLUTION");
		DISPLAY_RESOLUTION = ES2.Load<float>("RESOLUTION");
		SCR_X = ES2.Load<int>("DISPLAY_X");
		SCR_Y = ES2.Load<int>("DISPLAY_Y");
		float num = DISPLAY_RESOLUTION * 100f - 10f;
		Screen.SetResolution(SCR_X * (int)num / 100, SCR_Y * (int)num / 100, fullscreen: true);
		CHECK_ALL();
	}

	public void SET_RENDER_HIGH()
	{
		ES2.Save(0.8f, "RESOLUTION");
		DISPLAY_RESOLUTION = ES2.Load<float>("RESOLUTION");
		SCR_X = ES2.Load<int>("DISPLAY_X");
		SCR_Y = ES2.Load<int>("DISPLAY_Y");
		float num = DISPLAY_RESOLUTION * 100f - 10f;
		Screen.SetResolution(SCR_X * (int)num / 100, SCR_Y * (int)num / 100, fullscreen: true);
		CHECK_ALL();
	}

	public void SET_RENDER_MAX()
	{
		ES2.Save(1f, "RESOLUTION");
		DISPLAY_RESOLUTION = ES2.Load<float>("RESOLUTION");
		SCR_X = ES2.Load<int>("DISPLAY_X");
		SCR_Y = ES2.Load<int>("DISPLAY_Y");
		float num = DISPLAY_RESOLUTION * 100f - 10f;
		Screen.SetResolution(SCR_X * (int)num / 100, SCR_Y * (int)num / 100, fullscreen: true);
		CHECK_ALL();
	}

	public void SET_VIEW_LOW()
	{
		ES2.Save(0, "VIEW_DISTANCE");
		CHECK_ALL();
	}

	public void SET_VIEW_NORM()
	{
		ES2.Save(1, "VIEW_DISTANCE");
		CHECK_ALL();
	}

	public void SET_VIEW_HIGH()
	{
		ES2.Save(2, "VIEW_DISTANCE");
		CHECK_ALL();
	}

	public void SET_VIEW_MAX()
	{
		ES2.Save(3, "VIEW_DISTANCE");
		CHECK_ALL();
	}

	public void SET_WATER_LOW()
	{
		ES2.Save(0, "WATER_QUALITY");
		CHECK_ALL();
	}

	public void SET_WATER_NORM()
	{
		ES2.Save(1, "WATER_QUALITY");
		CHECK_ALL();
	}

	public void SET_WATER_HIGH()
	{
		ES2.Save(2, "WATER_QUALITY");
		CHECK_ALL();
	}

	public void SET_WATER_MAX()
	{
		ES2.Save(3, "WATER_QUALITY");
		CHECK_ALL();
	}

	public void SET_TERRAIN_LOW()
	{
		ES2.Save(0, "TERRAIN");
		CHECK_ALL();
	}

	public void SET_TERRAIN_NORM()
	{
		ES2.Save(1, "TERRAIN");
		CHECK_ALL();
	}

	public void SET_TERRAIN_HIGH()
	{
		ES2.Save(2, "TERRAIN");
		CHECK_ALL();
	}

	public void SET_TERRAIN_MAX()
	{
		ES2.Save(3, "TERRAIN");
		CHECK_ALL();
	}

	public void SET_FILTER_OFF()
	{
		ES2.Save(0, "FILTER");
		QualitySettings.anisotropicFiltering = AnisotropicFiltering.Disable;
		CHECK_ALL();
	}

	public void SET_FILTER_ON()
	{
		ES2.Save(1, "FILTER");
		QualitySettings.anisotropicFiltering = AnisotropicFiltering.Enable;
		CHECK_ALL();
	}

	public void SET_SHADOW_OFF()
	{
		ES2.Save(0, "SHADOW");
		CHECK_ALL();
	}

	public void SET_SHADOW_ON()
	{
		ES2.Save(1, "SHADOW");
		CHECK_ALL();
	}

	public void SET_BLOOM_OFF()
	{
		ES2.Save(0, "BLOOMFX");
		for (int i = 0; i < ALL_CAM.Length; i++)
		{
			ALL_CAM[i].GetComponent<FxPro>().enabled = false;
		}
		CHECK_ALL();
	}

	public void SET_BLOOM_ON()
	{
		ES2.Save(1, "BLOOMFX");
		for (int i = 0; i < ALL_CAM.Length; i++)
		{
			ALL_CAM[i].GetComponent<FxPro>().enabled = true;
		}
		CHECK_ALL();
	}

	public void SET_SKIDMARK_OFF()
	{
		ES2.Save(0, "SKIDMARK");
		CHECK_ALL();
	}

	public void SET_SKIDMARK_ON()
	{
		ES2.Save(1, "SKIDMARK");
		CHECK_ALL();
	}
}
