using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameDialog
{
    private Dictionary<string, List<Dialog>> _dialogs = new Dictionary<string, List<Dialog>>();
    private bool _hasSorted = false;

    [System.Serializable]
    public class Dialog
    {
        public string EventName;
        public string InteractingObject;
        public string First;
        public string Repeat;
    }

    [SerializeField]
    public Dialog[] Dialogs;

    public string this[string objectName, string eventName]
    {
        get
        {
            if (!_dialogs.ContainsKey(objectName))
            {
                Debug.LogErrorFormat("Could not find {0} for a dialogue", objectName);
                return string.Empty;
            }

            for (int i = 0, count = _dialogs[objectName].Count; i < count; ++i)
            {
                if (_dialogs[objectName][i].EventName.CompareTo(eventName) == 0)
                {
                    return _dialogs[objectName][i].First; // TODO SaveManager
                }
            }

            Debug.LogErrorFormat("Could not find event {0} for a dialogue", eventName);

            return string.Empty;
        }
    }

    public void Sort()
    {
        if (!_hasSorted)
        {
            for (int i = 0; i < Dialogs.Length; ++i)
            {
                if (!_dialogs.ContainsKey(Dialogs[i].InteractingObject))
                {
                    _dialogs.Add(Dialogs[i].InteractingObject, new List<Dialog>());
                }

                _dialogs[Dialogs[i].InteractingObject].Add(Dialogs[i]);
            }
            Dialogs = null;
            _hasSorted = true;
        }
    }
}

public class DialogManager
{
    protected GameDialog _dialog;

    public void Load(string file)
    {
        _dialog = JsonUtility.FromJson<GameDialog>(file);
        _dialog.Sort();
    }

    public string GetKey(string objectName, string eventName)
    {
        return _dialog[objectName, eventName];
    }
}