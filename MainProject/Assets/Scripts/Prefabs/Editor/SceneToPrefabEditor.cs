using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SceneToPrefab))]
public class SceneToPrefabEditor : Editor
{
	SceneToPrefab _container = null;
	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();
		_container = (SceneToPrefab)target;

		if (GUILayout.Button("Update"))
		{
			PrefabUtility.ReplacePrefab(_container._targetObject, _container._targetPrefab);
			DestroyImmediate(_container._targetPrefab.GetComponent<SceneToPrefab>());
		}
	}
}