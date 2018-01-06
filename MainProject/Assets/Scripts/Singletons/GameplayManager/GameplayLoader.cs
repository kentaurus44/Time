using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayLoader : MonoBehaviour
{
    [SerializeField]
    protected Chapter[] _chapters;

    protected Chapter _currentChapter;

    public IEnumerator LoadChapter(string chapter)
    {
        for (int i = 0, count = _chapters.Length; i < count; ++i)
        {
            if (_chapters[i].ChapterKey.CompareTo(chapter) == 0)
            {
                yield return _currentChapter = Instantiate(_chapters[i], transform, false);
            }
        }

        yield return _currentChapter.Load();
    }
}
