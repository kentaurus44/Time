using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonWidget : MonoBehaviour
{
    [SerializeField]
    protected Button _button;

    [SerializeField]
    protected Text _text;

    public void UpdateWidget(string name)
    {
        _text.text = name;
    }
}
