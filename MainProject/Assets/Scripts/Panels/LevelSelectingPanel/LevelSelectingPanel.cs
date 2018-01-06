using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class LevelSelectingPanel : BasePanel<LevelSelectingPanel>
{
    public Action<string> OnChapterSelected;

    [SerializeField]
    protected Button _backButton;

    [SerializeField]
    protected LevelSelectingChapterElement _defaultChapterElement;

    [SerializeField]
    protected Transform _container;

    private ObjectPool<LevelSelectingChapterElement> _chapterPool;

    public override void Init()
    {
        base.Init();
        OnChapterSelected += OnChapterSelectedCB;
        _backButton.onClick.AddListener(BackButtonCB);

        if (_chapterPool == null)
        {
            _chapterPool = new ObjectPool<LevelSelectingChapterElement>(_defaultChapterElement, _container, 5);
        }

        string[] chapters = GameManager.Instance.ChapterManager.GetChapters();

        LevelSelectingChapterElement item;
        for (int i = 0, count = chapters.Length; i < count ; ++i)
        {
            item = _chapterPool.GetItem();
            item.UpdateElement(chapters[i]);
        }
    }

    protected override void OnActivated()
    {
        base.OnActivated();
    }

    protected override void OnDeactivated()
    {
        base.OnDeactivated();
    }

    private void BackButtonCB()
    {
        MainPanel.Show();
        Hide();
    }

    private void OnChapterSelectedCB(string chapter)
    {
        GameplayManager.Instance.Load(chapter);
        Hide();
        GameplayPanel.Load(chapter);
    }
}
