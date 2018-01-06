using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectingChapterElement : MonoBehaviour
{
    [SerializeField]
    protected ButtonWidget _buttonWidget;

    public void UpdateElement(string chapter)
    {
        _buttonWidget.UpdateWidget(chapter, LevelSelectingPanel.Instance.OnChapterSelected);
    }
}
