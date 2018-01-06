using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chapter : MonoBehaviour
{
    [SerializeField]
    protected Chapters _chapter;

    [SerializeField]
    protected InteractingObjectManager _interactingObjectManager;

    public string ChapterKey
    {
        get { return _chapter.ToString(); }
    }

    public IEnumerator Load()
    {
        yield return _interactingObjectManager.Load();
    }
}
