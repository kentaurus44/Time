using System.Collections;
using UnityEngine;

namespace Level.Area
{
	public class LevelTrack : MonoBehaviour, iSerializable
	{
		[SerializeField]
		protected Transform _begin;
		[SerializeField]
		protected Transform _end;

		public Hashtable Serialize()
		{
			Hashtable hash = new Hashtable
			{
				{ LevelConstants.kTrackBeginKey, _begin.Serialize() },
				{ LevelConstants.kTrackEndKey, _end.Serialize() }
			};
			return hash;
		}
	}
}