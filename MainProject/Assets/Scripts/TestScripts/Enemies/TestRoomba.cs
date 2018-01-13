using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRoomba : Roomba
{
    [SerializeField]
    protected RoombaConfigs _roombasConfigs;
    protected void Update()
    {
        _trackVehicle.LoadSettings(_roombasConfigs.VehicleSettings);
        OnUpdate();
    }
}
