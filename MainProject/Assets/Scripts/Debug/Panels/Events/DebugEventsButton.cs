using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugEventsButton : MonoBehaviour
{
    [SerializeField]
    protected Button _button;

    [SerializeField]
    protected Text _buttonTextField;

    private GameEvents.GameEvent _event;

    protected void Awake()
    {
        GameManager.Instance.EventManager.OnStatesUpdated += OnStateCallback;
    }

    public void UpdateButtonElement(GameEvents.GameEvent evt)
    {
        _event = evt;
        _buttonTextField.text = evt.EventName;

        switch (evt.State)
        {
            case GameEvents.States.Available:
                _buttonTextField.color = Color.black;
                break;
            case GameEvents.States.Locked:
                _buttonTextField.color = Color.red;
                break;
            case GameEvents.States.Completed:
                _buttonTextField.color = Color.green;
                break;
            default:
                break;
        }
        _button.onClick.RemoveAllListeners();
        _button.onClick.AddListener(OnPressedCB);
    }

    protected void OnPressedCB()
    {
        GameManager.Instance.CompleteEvent(_event.EventName);
    }

    protected void OnStateCallback()
    {
        GameEvents.GameEvent evt = GameManager.Instance.EventManager.GetEvent(_event.EventName);
        UpdateButtonElement(evt);
    }
}
