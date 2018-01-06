using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractingObjectManager : MonoBehaviour
{
    [SerializeField]
    protected InteractingObjectBase[] _interactingObjects;

    public IEnumerator Load()
    {
        for (int i = 0, count = _interactingObjects.Length; i < count; ++i)
        {
            _interactingObjects[i].Init();
            yield return null;
        }
    }
}
