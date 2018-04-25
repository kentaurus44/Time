using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Level.Area.Data
{
	public class LevelAreaData
	{
		private LevelTrackData[] _tracks;

		public LevelAreaData(Hashtable hash)
		{
			Deserialize(hash);
		}

		private void Deserialize(Hashtable hash)
		{
			if (hash.ContainsKey(LevelConstants.kAreaKey))
			{
				ArrayList trackList = new ArrayList(hash[LevelConstants.kTrackKey] as Hashtable);
				_tracks = new LevelTrackData[trackList.Count];

				for (int i = 0, count = trackList.Count; i < count; ++i)
				{
					_tracks[i] = new LevelTrackData(trackList[i] as Hashtable);
				}
			}
		}
	}
}