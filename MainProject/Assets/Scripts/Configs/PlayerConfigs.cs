using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerConfigs", menuName = "Configs/PlayerConfigs", order = 1)]
public class PlayerConfigs : ScriptableObject
{
    [SerializeField]
    protected VehicleSettings _vehicleSettings;

    public VehicleSettings VehicleSettings
    {
        get { return _vehicleSettings; }
    }
}
