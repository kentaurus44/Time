using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(TrackEditorScript))]
public class TrackEditorScriptEditor : Editor
{
    TrackEditorScript _container = null;
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        _container = (TrackEditorScript)target;

        if (GUILayout.Button("Snap to Left"))
        {
            _container.SnapToLeft();
        }

        if (GUILayout.Button("Snap to Right"))
        {
            _container.SnapToRight();
        }

		if (GUILayout.Button("Calculate Center"))
		{
			_container.CalculateCenter();
		}
    }
}
