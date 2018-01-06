using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingPanel : SingletonComponent<LoadingPanel>
{
    [SerializeField]
    protected Canvas _canvas;

    public void Show()
    {
        _canvas.gameObject.SetActive(true);
    }

    public void Hide()
    {
        _canvas.gameObject.SetActive(false);
    }
}