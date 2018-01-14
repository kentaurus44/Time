using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(TrackContainer))]
public class TrackContainerEditor : Editor
{
    TrackContainer _container = null;
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        _container = (TrackContainer)target;

        if (GUILayout.Button("Load Tracks"))
        {
            _container.LoadTracks();
        }
    }
}
