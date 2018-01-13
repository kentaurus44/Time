using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RoombaConfigs", menuName = "Configs/RoombasConfigs", order = 1)]
public class RoombaConfigs : ScriptableObject
{
    [SerializeField]
    protected VehicleSettings _vehicleSettings;

    public VehicleSettings VehicleSettings
    {
        get { return _vehicleSettings; }
    }
}
