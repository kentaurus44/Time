using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(FlowDatabase))]
public class FlowDatabaseEditor : Editor
{
	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();

		if (GUILayout.Button("Refresh"))
		{
			Debug.LogError("This nothing yet.");
		}
	}
}
