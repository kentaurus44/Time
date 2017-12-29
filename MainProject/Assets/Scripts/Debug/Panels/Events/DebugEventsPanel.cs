using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugEventsPanel : MonoBehaviour
{
    [SerializeField]
    protected DebugEventsButton _defaultButtonElement;

    [SerializeField]
    protected Transform _container;

    private List<DebugEventsButton> _buttons = new List<DebugEventsButton>();

    protected void Start()
    {
        InitButtons();
    }

    protected void OnDisable()
    {
        gameObject.SetActive(false);
    }

    protected void InitButtons()
    {
        DebugEventsButton button;
        int count = GameManager.Instance.EventManager.Events.Count;
        for (int i = 0; i < count; ++i)
        {
            button = Instantiate<DebugEventsButton>(_defaultButtonElement, _container, true);
            button.UpdateButtonElement(GameManager.Instance.EventManager.Events[i]);
            button.gameObject.SetActive(true);
            _buttons.Add(button);
        }
    }
}