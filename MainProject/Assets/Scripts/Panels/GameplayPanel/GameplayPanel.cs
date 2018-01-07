using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameplayPanel : BasePanel<GameplayPanel>
{
    [SerializeField]
    protected Button _inventoryButton;

    [SerializeField]
    protected Button _optionsButton;

    private string _chapter;

    public override void Init()
    {
        base.Init();
        _inventoryButton.onClick.AddListener(OnInventoryPressedCB);
        _optionsButton.onClick.AddListener(OnOptionsPressedCB);
    }

    private void OnOptionsPressedCB()
    {
        OptionsPanel.Show();
    }

    private void OnInventoryPressedCB()
    {

    }

    public static void Load(string chapter)
    {
        Instance._chapter = chapter;
        Show();
    }
}
