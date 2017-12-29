﻿using System;

public class GameManager : SingletonComponent<GameManager>
{
    private GameEventManager _eventManager = new GameEventManager();
    private DialogManager _dialogManager = new DialogManager();

#if UNITY_EDITOR // Used only to debugs and testing
    public GameEventManager Events
    {
        get { return _eventManager; }
    }

    public DialogManager Dialog
    {
        get { return _dialogManager; }
    }
#endif

    public void Load(string eventJson, string dialogJson)
    {
        _eventManager.Load(eventJson);
        _dialogManager.Load(dialogJson);
    }

    public void CompleteEvent(string eventName)
    {
        _eventManager.UpdateEvent(eventName, true);
    }

    public string GetDialogKey(string objectName, TypeSafeEnum[] storyEvents)
    {
        string dialogKey = string.Empty;

        string eventName = string.Empty;
        for (int i = 0, count = storyEvents.Length; i < count; ++i)
        {
            eventName = storyEvents[i].ToString();
            if (!_eventManager.IsEventComplete(eventName))
            {
                dialogKey = _dialogManager.GetKey(objectName, eventName);
            }
        }

        return dialogKey;
    }
}
