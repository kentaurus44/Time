using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class LevelSelectingPanel : BasePanel<LevelSelectingPanel>
{


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

    private void OnChapterSelectedCB(string chapter)
    {
        GameplayManager.Instance.Load(chapter);
        Hide();
        GameplayPanel.Load(chapter);
    }
}
