using System;
using System.Collections.Generic;
using UnityEngine;

namespace LPWAsset
{
	public class LPWNormalSolver
	{
		private struct LPWPointDataEntry
		{
			public int triIdx;

			public int vertIdx;

			public LPWPointDataEntry(int triIdx, int vertIdx)
			{
				this.triIdx = triIdx;
				this.vertIdx = vertIdx;
			}
		}

		private struct LPWPoint
		{
			public int idx;

			public int count;

			public LPWPoint(int idx, int count)
			{
				this.idx = idx;
				this.count = count;
			}
		}

		private struct LPWPair : IEquatable<LPWPair>
		{
			public int x;

			public int y;

			public LPWPair(int i, int j)
			{
				x = i;
				y = j;
			}

			public override int GetHashCode()
			{
				return x.GetHashCode() + y.GetHashCode();
			}

			public bool Equals(LPWPair p)
			{
				return (x == p.x && y == p.y) || (x == p.y && y == p.x);
			}
		}

		private struct LPWPosition : IEquatable<LPWPosition>
		{
			private readonly long _x;

			private readonly long _y;

			private readonly long _z;

			private const int Tolerance = 100000;

			public LPWPosition(Vector3 position)
			{
				_x = (long)Mathf.Round(position.x * 100000f);
				_y = (long)Mathf.Round(position.y * 100000f);
				_z = (long)Mathf.Round(position.z * 100000f);
			}

			public override int GetHashCode()
			{
				return ((_x * 7) ^ (_y * 13) ^ (_z * 27)).GetHashCode();
			}

			public bool Equals(LPWPosition key)
			{
				return _x == key._x && _y == key._y && _z == key._z;
			}
		}

		private List<Vector3> triNormals;

		private List<LPWPointDataEntry> pointData;

		private List<LPWPoint> points;

		private Dictionary<LPWPosition, int> pointsDict;

		private Dictionary<int, int> toMerge;

		private Dictionary<int, int> idxDict;

		private List<Vector3> newVerts;

		private List<Vector3> newNormals;

		private List<Color32> newColors;

		private List<int> newTris;

		public LPWNormalSolver()
		{
			triNormals = new List<Vector3>();
			pointData = new List<LPWPointDataEntry>();
			points = new List<LPWPoint>();
			pointsDict = new Dictionary<LPWPosition, int>();
		}

		private bool EqualApprox(Vector3 a, Vector3 b)
		{
			return Mathf.Approximately(a.x, b.x) && Mathf.Approximately(a.y, b.y) && Mathf.Approximately(a.z, b.z);
		}

		private void AddData(Vector3 v, int triIdx, int vertIdx)
		{
			int index = pointsDict[new LPWPosition(v)];
			LPWPoint value = points[index];
			pointData[value.idx + value.count] = new LPWPointDataEntry(triIdx, vertIdx);
			value.count++;
			points[index] = value;
		}

		private void AddPoint(Vector3 v)
		{
			LPWPosition key = new LPWPosition(v);
			if (!pointsDict.TryGetValue(key, out var value))
			{
				LPWPoint item = new LPWPoint(0, 1);
				pointsDict.Add(key, points.Count);
				points.Add(item);
			}
			else
			{
				LPWPoint item = points[value];
				item.count++;
				points[value] = item;
			}
		}
	}
}
