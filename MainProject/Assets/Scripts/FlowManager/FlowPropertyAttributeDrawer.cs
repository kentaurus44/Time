#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;

[CustomPropertyDrawer(typeof(FlowAttribute))]
public class FlowAttributeDrawer : PropertyDrawer
{
	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
	{
		EditorGUI.BeginProperty(position, label, property);

		FlowDatabase db = FlowDatabase.GetEditorInstance();
		FlowView[] views = db.Views;

		List<string> display = new List<string>() { "None" };
		display.AddRange(views.Select(x => x.Id));

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