using System.Collections;
using UnityEngine;

namespace Level.Area.Data
{
	public class LevelTrackData
	{
		private Vector3 _begin;
		private Vector3 _end;

		public Vector3 Begin { get { return _begin; } }
		public Vector3 End { get { return _end; } }

		public LevelTrackData(Hashtable hash)
		{
			_begin = hash[LevelConstants.kTrackBeginKey].ToString().ToVector();
			_end = hash[LevelConstants.kTrackEndKey].ToString().ToVector();
		}
	}
}