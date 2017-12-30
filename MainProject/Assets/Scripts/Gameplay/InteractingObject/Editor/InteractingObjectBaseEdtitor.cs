using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(InteractingObjectBase))]
public class InteractingObjectBaseEdtitor : Editor
{
    //private InteractingObjectBase _base;

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        //_base = (InteractingObjectBase)target;

        //if (GUILayout.Button("Update information"))
        //{
        //    List<string> list = GameManager.Instance.DialogManager.GetEvents(_base.ObjID);
        //    List<Events> eventList = new List<Events>();
        //    GameManager.Instance.DialogManager.Load();

        //    for (int i = 0; i < list.Count; ++i)
        //    {
        //        eventList.Add(EnumExtensions.ParseEnum<Events>(list[i]));
        //    }
        //    _base.ObjectEvents = eventList.ToArray();
        //}
    }
}
