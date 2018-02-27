using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneView : View
{
	public const string kChapterKey = "ChapterKey";

	[SerializeField]
	protected GameSceneController _gameSceneController;

	private Dictionary<string, object> _param;

	public override void OnViewLoaded(Dictionary<string, object> param)
	{
		_param = param;
		string chapterKey = param[kChapterKey].ToString();
		_gameSceneController.Init(chapterKey, OnLoadComplete);
	}

	public override void OnViewOpened()
	{
		base.OnViewOpened();
	}

	private void OnLoadComplete()
	{
		base.OnViewLoaded(_param);
	}
}
