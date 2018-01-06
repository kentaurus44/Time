using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : SingletonComponent<GameplayManager>
{
    [SerializeField]
    protected GameplayLoader _loader;

    private string _chapter;

    public string Chapter
    {
        get { return _chapter; }
    }

    protected IEnumerator LoadChapter()
    {
        LoadingPanel.Instance.Show();
        yield return _loader.LoadChapter(_chapter);
        LoadingPanel.Instance.Hide();
    }

    public void Load(string chapter)
    {
        _chapter = chapter;
        StartCoroutine(LoadChapter());
    }
}
