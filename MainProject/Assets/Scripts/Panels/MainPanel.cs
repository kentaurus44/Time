using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainPanel : BasePanel<MainPanel>
{
    [SerializeField]
    protected Button _playButton;

    [SerializeField]
    protected Button _optionButton;

    protected override void Awake()
    {
        base.Awake();
        _playButton.onClick.AddListener(OnPlayButtonCB);
        _optionButton.onClick.AddListener(OnOptionButtonCB);
    }

    protected void OnPlayButtonCB()
    {
        LevelSelectingPanel.Show();
        Hide();
    }

    protected void OnOptionButtonCB()
    {
        OptionsPanel.Show();
    }
}
