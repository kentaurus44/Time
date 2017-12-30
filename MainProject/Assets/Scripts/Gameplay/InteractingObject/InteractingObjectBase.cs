using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractingObjectBase : MonoBehaviour
{
    [SerializeField]
    protected InteractingObject _objID;

    [SerializeField]
    protected Events[] _events;

    public Events[] ObjectEvents
    {
        set { _events = value; }
        get { return _events; }
    }

    public string ObjID
    {
        get { return _objID.ToString(); }
    }

    private int _currentEventIndex = 0;

    protected virtual void Start()
    {
        GameManager.Instance.EventManager.OnStatesUpdated += OnStateCallback;
        _events = GameManager.Instance.DialogManager.GetEvents(_objID.ToString());
    }

    protected virtual void OnDestroy()
    {
        if (!GameManager.IsInstanceNull)
        {
            GameManager.Instance.EventManager.OnStatesUpdated -= OnStateCallback;
        }
    }

    protected virtual void OnStateCallback(string completedEvent)
    {
        if (_events[_currentEventIndex].ToString().CompareTo(completedEvent) == 0)
        {
            _currentEventIndex++;
        }
    }
}