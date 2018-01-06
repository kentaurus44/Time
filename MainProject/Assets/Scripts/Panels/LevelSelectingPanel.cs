using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectingPanel : BasePanel<LevelSelectingPanel>
{
    [SerializeField]
    protected Button _backButton;

    protected override void Awake()
    {
        base.Awake();
        _backButton.onClick.AddListener(BackButtonCB);
    }

    protected override void OnActivated()
    {
        base.OnActivated();
    }

    protected override void OnDeactivated()
    {
        base.OnDeactivated();
    }

    private void BackButtonCB()
    {
        MainPanel.Show();
        Hide();
    }
}
