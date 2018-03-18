#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(FlowActionAttribute))]
public class FlowActionAttributeDrawer : PropertyDrawer
{
	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
	{
		EditorGUI.BeginProperty(position, label, property);

		List<string> display = new List<string>();
		display.AddRange(FlowDatabase.kFlowActions);

		int index = 0;
		for (int i = 0, count = display.Count; i < count; ++i)
		{
			if (property.stringValue == display[i])
			{
				index = i;
				break;
			}
		}

		EditorGUI.LabelField(position, label);
		EditorGUI.indentLevel = 5;
		index = EditorGUI.Popup(position, index, display.ToArray());
		property.stringValue = display[index];

		EditorGUI.EndProperty();

	}
}
#endif