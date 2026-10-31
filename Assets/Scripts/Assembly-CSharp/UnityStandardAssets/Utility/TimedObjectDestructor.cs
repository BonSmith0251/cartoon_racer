using UnityEngine;

namespace UnityStandardAssets.Utility
{
	public class TimedObjectDestructor : MonoBehaviour
	{
		[SerializeField]
		private float m_TimeOut2 = 1f;

		[SerializeField]
		private float m_TimeOut = 1f;

		[SerializeField]
		private bool m_DetachChildren;

		private void Awake()
		{
			Invoke("DestroyNow", m_TimeOut);
			if (m_TimeOut2 > 0f)
			{
				Invoke("DestroyNow2", m_TimeOut2);
			}
		}

		private void DestroyNow2()
		{
			if (base.gameObject.GetComponent<AudioSource>() != null)
			{
				base.gameObject.GetComponent<AudioSource>().enabled = false;
			}
			if (base.gameObject.GetComponent<ParticleSystem>() != null)
			{
				base.gameObject.GetComponent<ParticleSystem>().Stop();
			}
		}

		private void DestroyNow()
		{
			if (m_DetachChildren)
			{
				base.transform.DetachChildren();
			}
			Object.DestroyObject(base.gameObject);
		}
	}
}
