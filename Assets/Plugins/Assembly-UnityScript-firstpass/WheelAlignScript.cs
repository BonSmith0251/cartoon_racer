using System;
using UnityEngine;

[Serializable]
public class WheelAlignScript : MonoBehaviour
{
	public WheelCollider CorrespondingCollider;

	public GameObject SlipPrefab;

	public float RotationValue;

	public float RotationValue_NEED;

	public virtual void Update()
	{
		RaycastHit hitInfo = default(RaycastHit);
		Vector3 vector = CorrespondingCollider.transform.TransformPoint(CorrespondingCollider.center);
		if (Physics.Raycast(vector, -CorrespondingCollider.transform.up, out hitInfo, CorrespondingCollider.suspensionDistance + CorrespondingCollider.radius))
		{
			transform.position = hitInfo.point + CorrespondingCollider.transform.up * CorrespondingCollider.radius;
		}
		else
		{
			transform.position = vector - CorrespondingCollider.transform.up * CorrespondingCollider.suspensionDistance;
		}
		transform.rotation = CorrespondingCollider.transform.rotation * Quaternion.Euler(RotationValue, CorrespondingCollider.steerAngle, RotationValue_NEED);
		RotationValue += CorrespondingCollider.rpm * 6f * Time.deltaTime;
		WheelHit hit = default(WheelHit);
		CorrespondingCollider.GetGroundHit(out hit);
	}

	public virtual void Main()
	{
	}
}
