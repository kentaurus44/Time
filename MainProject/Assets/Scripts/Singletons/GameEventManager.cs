using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class GameEvents
{
    public enum States
    {
        Available,
        Locked,
        Completed
    }

    [System.Serializable]
    public class GameEvent
    {
        public string EventName;
        public string[] Requirements;
        public States State = States.Locked;
        public bool Updated = false;
    }

    [SerializeField]
    private GameEvent[] Events;

    public GameEvent this[int index]
    {
        get
        {
            if (index < 0 || index > Events.Length)
            {
                return null;
            }
            else
            {
                return Events[index];
            }
        }
    }

    public void UpdateStates()
    {
        for (int i = 0, count = Count; i < count; ++i)
        {
            Events[i].Updated = false;
        }

        for (int i = Count - 1; i >= 0; --i)
        {
            if (!Events[i].Updated)
            {
                switch (Events[i].State)
                {
                    case States.Available:
                        if (IsTurningCompleted(Events[i], true))
                        {
                            Events[i].State = States.Completed;
                        }
                        break;
                    case States.Locked:
                        if (Events[i].Requirements == null || Events[i].Requirements.Length == 0 || IsTurningAvailable(Events[i], true))
                        {
                            Events[i].State = States.Available;
                        }
                        break;
                }
                Events[i].Updated = true;
            }
        }
    }

    public bool Contains(string eventName)
    {
        return Get(eventName) != null;
    }

    public GameEvent Get(string eventName)
    {
        for (int i = 0; i < Count; ++i)
        {
            if (Events[i].EventName.CompareTo(eventName) == 0)
            {
                return Events[i];
            }
        }

        return null;
    }


    public int Count
    {
        get { return Events.Length; }
    }

    public bool Any
    {
        get { return Events[0] != null; }
    }

    private bool IsTurningAvailable(GameEvent gameEvent, bool setAsUpdated = false)
    {
        for (int i = 0; i < gameEvent.Requirements.Length; ++i)
        {
            if (!IsCompleted(gameEvent.Requirements[i]))
            {
                return false;
            }
        }
        gameEvent.Updated = setAsUpdated;
        return true;
    }

    private bool IsAvailable(string eventName, bool setAsUpdated = false)
    {
        GameEvent evt = Get(eventName);

        return IsTurningAvailable(evt, setAsUpdated);
    }

    private bool IsCompleted(string eventName, bool setAsUpdated = false)
    {
        return IsTurningCompleted( Get(eventName), setAsUpdated);
    }

    private bool IsTurningCompleted(GameEvent gameEvent, bool setAsUpdated = false)
    {
        gameEvent.Updated = setAsUpdated;
        return gameEvent.State == States.Completed;
    }
}

public class GameEventManager
{
    public Action<string> OnStatesUpdated;

    protected GameEvents _events;

    private string Chapter;

    public GameEvents Events
    {
        get { return _events; }
    }

    public GameEvents.GameEvent GetEvent(string eventName)
    {
        return _events.Get(eventName);
    }

    public void Load(string file)
    {
        _events = JsonUtility.FromJson<GameEvents>(file);
        _events.UpdateStates();
    }

    public void UpdateEvent(string eventName, bool completed)
    {
        GameEvents.GameEvent evt = _events.Get(eventName);

        switch (evt.State)
        {
            case GameEvents.States.Available:
                    evt.State = GameEvents.States.Completed;
                break;
            default:
                eventName = string.Empty;
                break;
        }

        _events.UpdateStates();

        OnStatesUpdated.SafeInvoke(eventName);
    }

    public bool IsEventComplete(string eventName)
    {
        GameEvents.GameEvent evt = _events.Get(eventName);
        return evt.State == GameEvents.States.Completed;
    }
}
