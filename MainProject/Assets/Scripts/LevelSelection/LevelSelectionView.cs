using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectionView : View
{
	[SerializeField]
	LevelSelectionController _controller;

	public override void OnViewLoaded(Dictionary<string, object> param)
	{
		base.OnViewLoaded(param);
		_controller.Init();
	}
}
