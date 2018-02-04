using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class DatabaseManager
{
    [SerializeField]
    protected PlayerConfigs _playerConfigs;

    [SerializeField]
    protected CameraConfigs _cameraConfigs;

    public PlayerConfigs PlayerConfigs { get { return _playerConfigs; } }
    public CameraConfigs CameraConfigs { get { return _cameraConfigs; } }

    // Database
    [SerializeField]
    protected JSONDatabase _jsonDatabase;

    public JSONDatabase JsonDatabase { get { return _jsonDatabase; } }
}