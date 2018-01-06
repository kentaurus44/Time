using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class GameChapters
{
    [System.Serializable]
    public class GameChapter
    {
        public string Chapter;
        public string[] Events;
    }

    [SerializeField]
    private GameChapter[] Chapters;

    public GameChapter this[int index]
    {
        get
        {
            if (index < 0 || index > Chapters.Length)
            {
                return null;
            }
            else
            {
                return Chapters[index];
            }
        }
    }

    public string[] this[string id]
    {
        get
        {
            for (int i = 0, count = Count; i < count; ++i)
            {
                if (Chapters[i].Chapter.CompareTo(id) == 0)
                {
                    return Chapters[i].Events;
                }
            }
            return null;
        }
    }


    public int Count
    {
        get { return Chapters.Length; }
    }

    public string[] GetChapters()
    {
        string[] list = new string[Count];

        for (int i = 0, count = Count; i < count; ++i)
        {
            list[i] = Chapters[i].Chapter;
        }

        return list;
    }

}

public class ChapterManager
{
    private GameChapters _chapters;

    public void Load(string file)
    {
        _chapters = JsonUtility.FromJson<GameChapters>(file);
    }

    public string[] GetChapters()
    {
        return _chapters.GetChapters();
    }

    public string[] GetEvents(string chapter)
    {
        return _chapters[chapter];
    }
}
