using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class DebugGameEventButton : MonoBehaviour
{
    public Action<GameEvents.GameEvent> onPressed;

    [SerializeField]
    protected Button _button;

    [SerializeField]
    protected Text _eventName;

    [SerializeField]
    protected Color _available;

    [SerializeField]
    protected Color _locked;

    [SerializeField]
    protected Color _completed;

    private GameEvents.GameEvent _event;

    protected void Awake()
    {
        _button.onClick.AddListener(OnPressedCB);
    }

    public void UpdateState(GameEvents.GameEvent evt)
    {
        _event = evt;
        _eventName.text = evt.EventName;

        switch (evt.State)
        {
            case GameEvents.States.Available:
                _eventName.color = _available;
                break;
            case GameEvents.States.Locked:
                _eventName.color = _locked;
                break;
            case GameEvents.States.Completed:
                _eventName.color = _completed;
                break;
            default:
                break;
        }
    }

    protected void OnPressedCB()
    {
        onPressed(_event);
    }
}
