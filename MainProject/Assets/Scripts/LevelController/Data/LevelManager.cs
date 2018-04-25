using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Singleton;
using System;
using Level.Area.Data;

namespace Level
{
	public class LevelManager : StaticSingleton<LevelManager>
	{
		public static event Action ParsingCmplete;
		public static event Action<Action> UpdateVisibility;
		public static event Action LevelReady;

		private LevelAreasData _levelAreasData;

		public void Load(Hashtable hash)
		{
			_levelAreasData = new LevelAreasData(hash);
			ParsingCmplete.SafeInvoke();
		}

		public void UpdateLevel(Camera camera)
		{
			_levelAreasData.GetVisible();
			UpdateVisibility.SafeInvoke(
			()=>
			{
				LevelReady.SafeInvoke();
			}
			);
		}
	}
}