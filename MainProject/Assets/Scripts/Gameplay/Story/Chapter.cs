using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chapter : ResourceData<Chapter>
{
    [SerializeField]
    protected Chapters _chapter;

    [SerializeField]
    protected InteractingObjectManager _interactingObjectManager;

    [SerializeField]
    protected TrackContainer _trackContainer;

    [SerializeField]
    protected Transform _characterInitialPosition;

    public Transform CharacterInitialPosition
    {
        get { return _characterInitialPosition; }
    }

    public TrackContainer TrackContainer
    {
        get { return _trackContainer; }
    }

    public IEnumerator Load()
    {
        yield return _interactingObjectManager.Load();
    }
}
