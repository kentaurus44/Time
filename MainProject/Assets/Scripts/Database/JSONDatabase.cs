using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "JSONDatabase", menuName = "Database/JSONDatabase", order = 2)]
public class JSONDatabase : Database<JSONDatabase>
{
    [SerializeField]
    protected TextAsset _eventsJSON;

    [SerializeField]
    protected TextAsset _dialogsJSON;

    [SerializeField]
    protected TextAsset _chaptersJSON;

    public TextAsset Events { get { return _eventsJSON; } }
    public TextAsset Dialogs { get { return _dialogsJSON; } }
    public TextAsset Chapters { get { return _chaptersJSON; } }
}
