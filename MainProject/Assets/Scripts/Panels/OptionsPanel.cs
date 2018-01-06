using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsPanel : BasePanel<OptionsPanel>
{
    [SerializeField]
    protected Button _closeButton;

    public override void Init()
    {
        base.Init();
        _closeButton.onClick.AddListener(CloseButtonCB);
    }

    protected void CloseButtonCB()
    {
        Hide();
    }
}
