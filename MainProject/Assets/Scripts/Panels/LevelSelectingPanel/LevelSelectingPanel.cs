using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectingPanel : BasePanel<LevelSelectingPanel>
{
    [SerializeField]
    protected Button _backButton;

    [SerializeField]
    protected LevelSelectingChapterElement _defaultChapterElement;

    [SerializeField]
    protected Transform _container;

    private ObjectPool<LevelSelectingChapterElement> _chapterPool;

    protected override void Awake()
    {
        base.Awake();
        if (_chapterPool == null)
        {
            _chapterPool = new ObjectPool<LevelSelectingChapterElement>(_defaultChapterElement, _container, 5);
        }

        _backButton.onClick.AddListener(BackButtonCB);

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
}
