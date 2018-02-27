using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Database<T> : ScriptableObject where T : ScriptableObject
{
    private const string kPathToDatabase = "Assets/Resources/Database/{0}.asset";

    public static T GetEditorInstance()
    {
        return AssetDatabase.LoadAssetAtPath<T>(string.Format(kPathToDatabase, typeof(T).Name)) as T;
    }
}
