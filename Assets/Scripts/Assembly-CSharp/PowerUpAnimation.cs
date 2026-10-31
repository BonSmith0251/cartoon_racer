using System;
using UnityEngine;

public class PowerUpAnimation : MonoBehaviour
{
	public enum RotationType
	{
		SelfAxis,
		WorldAxis
	}

	private bool _animateRotation = true;

	public Vector3 rotationSpeedsInDegreePerSecond;

	public RotationType rotationType;

	private bool _animateScale = true;

	public float scaleMin = 0.5f;

	public float scaleMax = 1.5f;

	public float scaleCycleDuration = 5f;

	private bool _animateYOffset = true;

	public float yOffsetAmplitude = 1f;

	public float yOffsetCycleDuration = 5f;

	private Vector3 _startLocalPosition;

	private Quaternion _startLocalRotation;

	private Vector3 _startLocalScale;

	private bool VIS;

	private Transform _transform;

	private Vector3 posCam;

	private Quaternion lastPos;

	public float turnSpeed = 20f;

	private float distance;

	private void Awake()
	{
		_transform = GetComponent<Transform>();
		_startLocalPosition = _transform.localPosition;
		_startLocalRotation = _transform.localRotation;
		_startLocalScale = _transform.localScale;
	}

	private void OnBecameVisible()
	{
		VIS = true;
	}

	private void OnBecameInvisible()
	{
		VIS = false;
	}

	private void Update()
	{
		if (VIS)
		{
			posCam = Camera.main.transform.position - base.transform.position;
			posCam.y = 0f;
			lastPos = Quaternion.LookRotation(-posCam);
			base.transform.rotation = Quaternion.Slerp(base.transform.rotation, lastPos, Time.deltaTime * 70f);
		}
		if (_animateYOffset & VIS)
		{
			float y = ((yOffsetCycleDuration == 0f) ? 0f : (Mathf.Sin(Time.time / yOffsetCycleDuration * (float)Math.PI * 2f) * yOffsetAmplitude));
			base.transform.localPosition = _startLocalPosition + new Vector3(0f, y, 0f);
		}
		if (_animateScale & VIS)
		{
			float num;
			if (scaleCycleDuration != 0f)
			{
				float t = Mathf.InverseLerp(-1f, 1f, Mathf.Sin(Time.time / scaleCycleDuration * (float)Math.PI * 2f));
				num = Mathf.Lerp(scaleMin, scaleMax, t);
			}
			else
			{
				num = 1f;
			}
			base.transform.localScale = num * _startLocalScale;
		}
	}

	public bool GetAnimateScale()
	{
		return _animateScale;
	}

	public void SetAnimateScale(bool newAnimateScale)
	{
		_animateScale = newAnimateScale;
		if (!_animateScale && Application.isPlaying)
		{
			base.transform.localScale = _startLocalScale;
		}
	}

	public bool GetAnimateYOffset()
	{
		return _animateYOffset;
	}

	public void SetAnimateYOffset(bool newAnimateYOffset)
	{
		_animateYOffset = newAnimateYOffset;
		if (!_animateYOffset && Application.isPlaying)
		{
			base.transform.localPosition = _startLocalPosition;
		}
	}

	public bool GetAnimateRotation()
	{
		return _animateRotation;
	}

	public void SetAnimateRotation(bool newAnimateRotation)
	{
		_animateRotation = newAnimateRotation;
		if (!_animateRotation && Application.isPlaying)
		{
			base.transform.localRotation = _startLocalRotation;
		}
	}
}
