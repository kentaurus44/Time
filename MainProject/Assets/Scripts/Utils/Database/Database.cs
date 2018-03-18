using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class Database<T> : ScriptableObject where T : ScriptableObject
{
#if UNITY_EDITOR
	private const string kPathToDatabase = "Assets/Resources/Database/{0}.asset";

    public static T GetEditorInstance()
    {
        return AssetDatabase.LoadAssetAtPath<T>(string.Format(kPathToDatabase, typeof(T).Name)) as T;
    }
#endif
}
