using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelSelectingChapterElement : MonoBehaviour
{
    [SerializeField]
    protected ButtonWidget _buttonWidget;

    public void UpdateElement(string chapter, Action<string> callback)
    {
        _buttonWidget.UpdateWidget(chapter, callback);
    }
}
