using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugEventChapter : MonoBehaviour
{
    [SerializeField]
    protected Text _chapter;

    public void UpdateInformation(string chapter)
    {
        _chapter.text = chapter;
    }
}
