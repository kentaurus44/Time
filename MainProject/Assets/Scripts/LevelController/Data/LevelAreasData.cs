using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Level.Area.Data
{
	public class LevelAreasData
	{
		private LevelAreaData[] _levelAreaData;

		public LevelAreasData(Hashtable hash)
		{
			Deserialize(hash);
		}

		public void GetVisible()
		{

		}

		private void Deserialize(Hashtable hash)
		{
			if (hash.ContainsKey(LevelConstants.kAreaKey))
			{
				ArrayList areaList = new ArrayList(hash[LevelConstants.kAreaKey] as Hashtable);
				_levelAreaData = new LevelAreaData[areaList.Count];

				for (int i = 0, count = areaList.Count; i < count; ++i)
				{
					_levelAreaData[i] = new LevelAreaData(areaList[i] as Hashtable);
				}
			}
		}

		public LevelAreaData[] GetAreas(Camera camera)
		{
			return null;
		}
	}
}