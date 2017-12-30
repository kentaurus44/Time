using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomManagersManager : ManagersManager
{
    [SerializeField]
    protected TextAsset _eventsJSON;

    [SerializeField]
    protected TextAsset _dialogsJSON;

    public override IEnumerator Load()
    {
        yield return base.Load();

        GameManager.Instance.Load(_eventsJSON.ToString(), _dialogsJSON.ToString());
    }
}
