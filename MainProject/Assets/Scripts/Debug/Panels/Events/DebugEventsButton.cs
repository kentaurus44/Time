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

    public void UpdateButtonElement(string eventName)
    {
        _buttonTextField.text = eventName;
        _event = GameManager.Instance.EventManager.GetEvent(eventName);
        UpdateButtonElement();
    }

    public void UpdateButtonElement()
    {
        if (_event == null)
        {
            return;
        }

        switch (_event.State)
        {
            case GameEvents.States.Available:
                _button.interactable = true;
                _buttonTextField.color = Color.black;
                break;
            case GameEvents.States.Locked:
                _button.interactable = false;
                _buttonTextField.color = Color.red;
                break;
            case GameEvents.States.Completed:
                _button.interactable = false;
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

    protected void OnStateCallback(string compeltedEvent)
    {
        _event = GameManager.Instance.EventManager.GetEvent(_event.EventName);
        UpdateButtonElement();
    }
}
