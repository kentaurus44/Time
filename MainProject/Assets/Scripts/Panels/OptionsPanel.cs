using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsPanel : BasePanel<OptionsPanel>
{
    [SerializeField]
    protected Button _closeButton;

    protected override void Awake()
    {
        base.Awake();
        _closeButton.onClick.AddListener(CloseButtonCB);
    }

    protected void CloseButtonCB()
    {
        Hide();
    }
}
