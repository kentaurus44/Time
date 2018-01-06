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

    public int Count
    {
        get { return Chapters.Length; }
    }

    public List<string> GetChapters()
    {
        return new List<string>();
    }

}

public class ChapterManager
{
    private GameChapters _chapters;

    public void Load(string file)
    {
        _chapters = JsonUtility.FromJson<GameChapters>(file);
    }
}
