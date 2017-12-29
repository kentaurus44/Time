using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Diagnostics;

public class Test : MonoBehaviour
{
    [SerializeField]
    protected TextAsset _jsonFile;

    [SerializeField]
    protected TextAsset _dialogJsonFile;

    protected void Start()
    {
        GameManager.Instance.Load(_jsonFile.ToString(), _dialogJsonFile.ToString());
    }
}
