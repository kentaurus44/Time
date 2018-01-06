using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ButtonWidget : MonoBehaviour
{
    [SerializeField]
    protected Button _button;

    [SerializeField]
    protected Text _text;

    private Action<string> OnButtonPressed;

    public void UpdateWidget(string name, Action<string> callback = null)
    {
        OnButtonPressed -= callback;
        OnButtonPressed += callback;
        _button.onClick.RemoveAllListeners();
        _button.onClick.AddListener(OnButtonCB);
        _text.text = name;
    }

    private void OnButtonCB()
    {
        OnButtonPressed.SafeInvoke(_text.text);
    }
}
