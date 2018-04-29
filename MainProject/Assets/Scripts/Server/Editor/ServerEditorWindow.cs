using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ServerEditorWindow : EditorWindow
{
	[MenuItem("Kentaurus/Server/Open")]
	private static void Init()
	{
		ServerEditorWindow window = (ServerEditorWindow)EditorWindow.GetWindow(typeof(ServerEditorWindow));
		window.Show();
	}

	private void OnGUI()
	{

	}
}