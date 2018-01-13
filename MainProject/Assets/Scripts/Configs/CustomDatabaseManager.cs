using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class DatabaseManager
{
    [SerializeField]
    protected PlayerConfigs _playerConfigs;

    public PlayerConfigs PlayerConfigs
    {
        get { return _playerConfigs; }
    }
}
