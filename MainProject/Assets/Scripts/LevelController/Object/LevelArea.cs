using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Level.Area
{
	public class LevelArea : MonoBehaviour, iSerializable
	{
		[SerializeField]
		protected LevelTrack[] _tracks;

		public LevelTrack[] Tracks { get { return _tracks; } }

		public Hashtable Serialize()
		{
			_tracks = GetComponentsInChildren<LevelTrack>();
			Hashtable hash = new Hashtable();
			ArrayList trackList = new ArrayList();
			foreach (var track in _tracks)
			{
				trackList.Add(track.Serialize());
			}
			hash.Add(LevelConstants.kTrackKey, trackList);
			return hash;
		}
	}
}