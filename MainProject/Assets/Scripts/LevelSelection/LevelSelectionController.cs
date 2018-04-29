using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using Core.Flow;

public class LevelSelectionController : MonoBehaviour
{
	public Action<string> OnChapterSelected;

	[SerializeField]
	protected LevelSelectingChapterElement _defaultChapterElement;

	[SerializeField]
	protected Transform _container;

	private ObjectPool<LevelSelectingChapterElement> _chapterPool;

	public void Init()
	{
		OnChapterSelected += OnChapterSelectedCB;

		if (_chapterPool == null)
		{
			_chapterPool = new ObjectPool<LevelSelectingChapterElement>(_defaultChapterElement, _container, 5);
		}

		string[] chapters = GameManager.Instance.ChapterManager.GetChapters();

		LevelSelectingChapterElement item;
		for (int i = 0, count = chapters.Length; i < count; ++i)
		{
			item = _chapterPool.GetItem();
			item.UpdateElement(chapters[i], OnChapterSelectedCB);
		}
	}

	private void OnChapterSelectedCB(string chapter)
	{
		Dictionary<string, object> param = new Dictionary<string, object>();
		param.Add(GameSceneView.kChapterKey, chapter);

		FlowManager.Instance.TriggerAction(FlowDatabase.kOpen, FlowConstants.kGameScene, param);
	}
}