using System;
using UnityEngine;

namespace RavingBots.Water2D
{
	[RequireComponent(typeof(BuoyancyEffector2D))]
	public class Water2DEffects : MonoBehaviour
	{
		public Water2DSplashFX SplashFXPrefab;

		public int SplashFXPrecache = 30;

		public float SplashFXPowerScale = 0.1f;

		public float SplashFXPowerThreshold = 0.1f;

		public float SplashFXOffset = 0.2f;

		public AudioClip[] SplashFXSounds;

		public float SplashFXPowerToVolume = 1f;

		public float SplashFXPowerToPitch = 1f;

		public float FloatingSpeed = 1f;

		public float FloatingRange = 1f;

		private BuoyancyEffector2D _buoyancyEffector2D;

		private float _surfaceLevel;

		private Water2DSplashFX[] _splashCache;

		private int _splash;

		private void Awake()
		{
			_buoyancyEffector2D = GetComponent<BuoyancyEffector2D>();
			_surfaceLevel = _buoyancyEffector2D.surfaceLevel;
			_splashCache = new Water2DSplashFX[SplashFXPrecache];
			Transform parent = new GameObject("Splash Container").transform;
			for (int i = 0; i < _splashCache.Length; i++)
			{
				Water2DSplashFX water2DSplashFX = UnityEngine.Object.Instantiate(SplashFXPrefab);
				water2DSplashFX.transform.parent = parent;
				_splashCache[i] = water2DSplashFX;
			}
		}

		private void FixedUpdate()
		{
			_buoyancyEffector2D.surfaceLevel = _surfaceLevel - FloatingRange * 0.5f * (Mathf.Sin((float)Math.PI * 2f * FloatingSpeed * Time.fixedTime) + 1f);
		}

		public void OnTriggerEnter2D(Collider2D other)
		{
			Rigidbody2D component = other.transform.parent.GetComponent<Rigidbody2D>();
			float num = SplashFXPowerScale * Vector2.Dot(component.velocity, Vector2.down) * component.mass;
			if (!(num < SplashFXPowerThreshold))
			{
				Water2DSplashFX water2DSplashFX = _splashCache[_splash];
				water2DSplashFX.transform.position = new Vector2(other.bounds.center.x, other.bounds.min.y - SplashFXOffset);
				water2DSplashFX.Play(num, SplashFXSounds[UnityEngine.Random.Range(0, SplashFXSounds.Length)], num * SplashFXPowerToVolume, SplashFXPowerToPitch / num);
				_splash = (_splash + 1) % _splashCache.Length;
			}
		}
	}
}
