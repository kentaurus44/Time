using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(TrackObjectController))]
public class TrackObjectControllerEditor : Editor
{
	TrackObjectController _target;
	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();
		_target = (TrackObjectController)target;

		if (GUILayout.Button("Load Objects"))
		{
			_target.LoadObjects();
		}
	}
}