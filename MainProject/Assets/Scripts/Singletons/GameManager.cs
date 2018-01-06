using System;

public class GameManager : SingletonComponent<GameManager>
{
    private GameEventManager _eventManager = new GameEventManager();
    private DialogManager _dialogManager = new DialogManager();
    private ChapterManager _chapterManager = new ChapterManager();

    public GameEventManager EventManager
    {
        get { return _eventManager; }
    }

    public DialogManager DialogManager
    {
        get { return _dialogManager; }
    }

    public ChapterManager ChapterManager
    {
        get { return _chapterManager; }
    }

    public void Load(string eventJson, string dialogJson, string chapterJson)
    {
        _eventManager.Load(eventJson);
        _dialogManager.Load(dialogJson);
        _chapterManager.Load(chapterJson);
    }

    public void CompleteEvent(string eventName)
    {
        _eventManager.UpdateEvent(eventName, true);
    }

    public void CompleteEvent(Events eventName)
    {
        _eventManager.UpdateEvent(eventName.ToString(), true);
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
