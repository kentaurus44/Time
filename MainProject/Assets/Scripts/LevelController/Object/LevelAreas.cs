using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Level.Area
{
	public class LevelAreas : MonoBehaviour, iSerializable
	{
		[SerializeField]
		protected LevelArea[] _levelAreas;

		public LevelArea[] Areas { get { return _levelAreas; } }

		public Hashtable Serialize()
		{
			_levelAreas = GetComponentsInChildren<LevelArea>();
			ArrayList areaList = new ArrayList();
			foreach (var area in _levelAreas)
			{
				areaList.Add(area.Serialize());
			}

			Hashtable hash = new Hashtable()
			{
				{ LevelConstants.kAreaKey, areaList }
			};
			
			return hash;
		}
	}
}
