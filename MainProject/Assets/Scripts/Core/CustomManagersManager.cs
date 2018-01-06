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

    [SerializeField]
    protected TextAsset _chaptersJSON;

    public override IEnumerator Load()
    {
        yield return base.Load();

        GameManager.Instance.Load(_eventsJSON.ToString(), _dialogsJSON.ToString(), _chaptersJSON.ToString());
    }
}
