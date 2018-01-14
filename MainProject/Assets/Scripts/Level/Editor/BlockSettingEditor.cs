using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(BlockSetting))]
public class BlockSettingEditor : Editor
{
    BlockSetting _settings = null;
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        _settings = (BlockSetting)target;

        if (GUILayout.Button("Resize"))
        {
            _settings.Resize();
        }
    }
}
