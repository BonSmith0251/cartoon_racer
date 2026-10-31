using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class TrafficLight : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024Pos_1_002411 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal TrafficLight _0024self__002412;

			public _0024(TrafficLight self_)
			{
				_0024self__002412 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__002412.Red.SetActive(value: false);
					_0024self__002412.Yellow.SetActive(value: false);
					_0024self__002412.Green.SetActive(value: true);
					result = (Yield(2, new WaitForSeconds(5f)) ? 1 : 0);
					break;
				case 2:
					_0024self__002412.Green.SetActive(value: false);
					result = (Yield(3, new WaitForSeconds(1f)) ? 1 : 0);
					break;
				case 3:
					_0024self__002412.Green.SetActive(value: true);
					result = (Yield(4, new WaitForSeconds(1f)) ? 1 : 0);
					break;
				case 4:
					_0024self__002412.Green.SetActive(value: false);
					result = (Yield(5, new WaitForSeconds(1f)) ? 1 : 0);
					break;
				case 5:
					_0024self__002412.Green.SetActive(value: true);
					result = (Yield(6, new WaitForSeconds(1f)) ? 1 : 0);
					break;
				case 6:
					_0024self__002412.Yellow.SetActive(value: true);
					result = (Yield(7, new WaitForSeconds(1f)) ? 1 : 0);
					break;
				case 7:
					_0024self__002412.Red.SetActive(value: true);
					_0024self__002412.Yellow.SetActive(value: true);
					_0024self__002412.Green.SetActive(value: false);
					_0024self__002412.Red.SetActive(value: true);
					_0024self__002412.Yellow.SetActive(value: false);
					_0024self__002412.Green.SetActive(value: false);
					result = (Yield(8, new WaitForSeconds(25f)) ? 1 : 0);
					break;
				case 8:
					_0024self__002412.Start();
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal TrafficLight _0024self__002413;

		public _0024Pos_1_002411(TrafficLight self_)
		{
			_0024self__002413 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__002413);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024Pos_2_002414 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal TrafficLight _0024self__002415;

			public _0024(TrafficLight self_)
			{
				_0024self__002415 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__002415.Red.SetActive(value: false);
					_0024self__002415.Yellow.SetActive(value: false);
					_0024self__002415.Green.SetActive(value: true);
					result = (Yield(2, new WaitForSeconds(_0024self__002415.GreenTime - 3f)) ? 1 : 0);
					break;
				case 2:
					_0024self__002415.Green.SetActive(value: false);
					result = (Yield(3, new WaitForSeconds(1f)) ? 1 : 0);
					break;
				case 3:
					_0024self__002415.Green.SetActive(value: true);
					result = (Yield(4, new WaitForSeconds(1f)) ? 1 : 0);
					break;
				case 4:
					_0024self__002415.Green.SetActive(value: false);
					result = (Yield(5, new WaitForSeconds(1f)) ? 1 : 0);
					break;
				case 5:
					_0024self__002415.Green.SetActive(value: true);
					result = (Yield(6, new WaitForSeconds(1f)) ? 1 : 0);
					break;
				case 6:
					_0024self__002415.Yellow.SetActive(value: true);
					result = (Yield(7, new WaitForSeconds(1f)) ? 1 : 0);
					break;
				case 7:
					_0024self__002415.Red.SetActive(value: true);
					_0024self__002415.Yellow.SetActive(value: true);
					_0024self__002415.Green.SetActive(value: false);
					_0024self__002415.Red.SetActive(value: true);
					_0024self__002415.Yellow.SetActive(value: false);
					_0024self__002415.Green.SetActive(value: false);
					result = (Yield(8, new WaitForSeconds(7f)) ? 1 : 0);
					break;
				case 8:
					_0024self__002415.Red.SetActive(value: false);
					result = (Yield(9, new WaitForSeconds(1f)) ? 1 : 0);
					break;
				case 9:
					_0024self__002415.Red.SetActive(value: true);
					result = (Yield(10, new WaitForSeconds(1f)) ? 1 : 0);
					break;
				case 10:
					_0024self__002415.Red.SetActive(value: false);
					result = (Yield(11, new WaitForSeconds(1f)) ? 1 : 0);
					break;
				case 11:
					_0024self__002415.Red.SetActive(value: true);
					result = (Yield(12, new WaitForSeconds(1f)) ? 1 : 0);
					break;
				case 12:
					_0024self__002415.Yellow.SetActive(value: true);
					result = (Yield(13, new WaitForSeconds(1f)) ? 1 : 0);
					break;
				case 13:
					_0024self__002415.Start();
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal TrafficLight _0024self__002416;

		public _0024Pos_2_002414(TrafficLight self_)
		{
			_0024self__002416 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__002416);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024Pos_3_002417 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal TrafficLight _0024self__002418;

			public _0024(TrafficLight self_)
			{
				_0024self__002418 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__002418.Red.SetActive(value: true);
					_0024self__002418.Yellow.SetActive(value: false);
					_0024self__002418.Green.SetActive(value: false);
					result = (Yield(2, new WaitForSeconds(30f)) ? 1 : 0);
					break;
				case 2:
					_0024self__002418.Red.SetActive(value: true);
					_0024self__002418.Yellow.SetActive(value: true);
					_0024self__002418.Green.SetActive(value: false);
					_0024self__002418.Red.SetActive(value: false);
					_0024self__002418.Yellow.SetActive(value: false);
					_0024self__002418.Green.SetActive(value: true);
					result = (Yield(3, new WaitForSeconds(_0024self__002418.GreenTime)) ? 1 : 0);
					break;
				case 3:
					_0024self__002418.Green.SetActive(value: false);
					result = (Yield(4, new WaitForSeconds(1f)) ? 1 : 0);
					break;
				case 4:
					_0024self__002418.Green.SetActive(value: true);
					result = (Yield(5, new WaitForSeconds(1f)) ? 1 : 0);
					break;
				case 5:
					_0024self__002418.Green.SetActive(value: false);
					result = (Yield(6, new WaitForSeconds(1f)) ? 1 : 0);
					break;
				case 6:
					_0024self__002418.Green.SetActive(value: true);
					result = (Yield(7, new WaitForSeconds(1f)) ? 1 : 0);
					break;
				case 7:
					_0024self__002418.Yellow.SetActive(value: true);
					result = (Yield(8, new WaitForSeconds(1f)) ? 1 : 0);
					break;
				case 8:
					_0024self__002418.Red.SetActive(value: true);
					_0024self__002418.Yellow.SetActive(value: false);
					_0024self__002418.Green.SetActive(value: false);
					result = (Yield(9, new WaitForSeconds(30f)) ? 1 : 0);
					break;
				case 9:
					_0024self__002418.Start();
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal TrafficLight _0024self__002419;

		public _0024Pos_3_002417(TrafficLight self_)
		{
			_0024self__002419 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__002419);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024Pos_4_002420 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal TrafficLight _0024self__002421;

			public _0024(TrafficLight self_)
			{
				_0024self__002421 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__002421.Red.SetActive(value: true);
					_0024self__002421.Yellow.SetActive(value: false);
					_0024self__002421.Green.SetActive(value: false);
					result = (Yield(2, new WaitForSeconds(45f)) ? 1 : 0);
					break;
				case 2:
					_0024self__002421.Red.SetActive(value: true);
					_0024self__002421.Yellow.SetActive(value: true);
					_0024self__002421.Green.SetActive(value: false);
					_0024self__002421.Red.SetActive(value: false);
					_0024self__002421.Yellow.SetActive(value: false);
					_0024self__002421.Green.SetActive(value: true);
					result = (Yield(3, new WaitForSeconds(_0024self__002421.GreenTime)) ? 1 : 0);
					break;
				case 3:
					_0024self__002421.Green.SetActive(value: false);
					result = (Yield(4, new WaitForSeconds(1f)) ? 1 : 0);
					break;
				case 4:
					_0024self__002421.Green.SetActive(value: true);
					result = (Yield(5, new WaitForSeconds(1f)) ? 1 : 0);
					break;
				case 5:
					_0024self__002421.Green.SetActive(value: false);
					result = (Yield(6, new WaitForSeconds(1f)) ? 1 : 0);
					break;
				case 6:
					_0024self__002421.Green.SetActive(value: true);
					result = (Yield(7, new WaitForSeconds(1f)) ? 1 : 0);
					break;
				case 7:
					_0024self__002421.Yellow.SetActive(value: true);
					result = (Yield(8, new WaitForSeconds(1f)) ? 1 : 0);
					break;
				case 8:
					_0024self__002421.Red.SetActive(value: true);
					_0024self__002421.Yellow.SetActive(value: false);
					_0024self__002421.Green.SetActive(value: false);
					result = (Yield(9, new WaitForSeconds(15f)) ? 1 : 0);
					break;
				case 9:
					_0024self__002421.Start();
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal TrafficLight _0024self__002422;

		public _0024Pos_4_002420(TrafficLight self_)
		{
			_0024self__002422 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__002422);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024Pos_5_NIGHT_002423 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal TrafficLight _0024self__002424;

			public _0024(TrafficLight self_)
			{
				_0024self__002424 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__002424.Red.SetActive(value: false);
					_0024self__002424.Green.SetActive(value: false);
					_0024self__002424.Yellow.SetActive(value: true);
					result = (Yield(2, new WaitForSeconds(1f)) ? 1 : 0);
					break;
				case 2:
					_0024self__002424.Red.SetActive(value: false);
					_0024self__002424.Green.SetActive(value: false);
					_0024self__002424.Yellow.SetActive(value: false);
					result = (Yield(3, new WaitForSeconds(1f)) ? 1 : 0);
					break;
				case 3:
					_0024self__002424.Start();
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal TrafficLight _0024self__002425;

		public _0024Pos_5_NIGHT_002423(TrafficLight self_)
		{
			_0024self__002425 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__002425);
		}
	}

	public GameObject N;

	public GameObject Red;

	public GameObject Green;

	public GameObject Yellow;

	private float GreenTime;

	private float RedTime;

	public bool Pos1;

	public bool Pos2;

	public bool Pos3;

	public bool Pos4;

	public bool Pos5_NIGHT;

	public TrafficLight()
	{
		GreenTime = 20f;
		RedTime = 10f;
		Pos1 = true;
	}

	public virtual void Awake()
	{
		N = GameObject.Find("/GAME_MANAGMENT/TLL");
	}

	public virtual void Start()
	{
		if (N != null)
		{
			if (!N.gameObject.activeInHierarchy)
			{
				StartCoroutine(Pos_2());
			}
			else
			{
				StartCoroutine(Pos_5_NIGHT());
			}
		}
		else
		{
			StartCoroutine(Pos_2());
		}
	}

	public virtual IEnumerator Pos_1()
	{
		return new _0024Pos_1_002411(this).GetEnumerator();
	}

	public virtual IEnumerator Pos_2()
	{
		return new _0024Pos_2_002414(this).GetEnumerator();
	}

	public virtual IEnumerator Pos_3()
	{
		return new _0024Pos_3_002417(this).GetEnumerator();
	}

	public virtual IEnumerator Pos_4()
	{
		return new _0024Pos_4_002420(this).GetEnumerator();
	}

	public virtual IEnumerator Pos_5_NIGHT()
	{
		return new _0024Pos_5_NIGHT_002423(this).GetEnumerator();
	}

	public virtual void Main()
	{
	}
}
