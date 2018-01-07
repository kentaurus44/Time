using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chapter : MonoBehaviour
{
    [SerializeField]
    protected Chapters _chapter;

    [SerializeField]
    protected InteractingObjectManager _interactingObjectManager;

    [SerializeField]
    protected Transform _characterInitialPosition;

    public string ChapterKey
    {
        get { return _chapter.ToString(); }
    }

    public Transform CharacterPosition
    {
        get { return _characterInitialPosition; }
    }

    public IEnumerator Load()
    {
        yield return _interactingObjectManager.Load();
    }
}
