using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class CharacterControl : Character
{
    public Action<Vector3, Vector3> OnPlayerMoved;

    public override void Init()
    {
        base.Init();
        _trackVehicle.LoadSettings(DatabaseManager.Instance.PlayerConfigs.VehicleSettings);
    }

    public override void OnUpdate()
    {
        if (Input.GetKey(KeyCode.D))
        {
            _trackVehicle.Move(1f);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            _trackVehicle.Move(-1f);
        }
        else
        {
            _trackVehicle.Move(0f);
        }

        if (!_trackVehicle.IsInAir && Input.GetKeyDown(KeyCode.Space))
        {
            _trackVehicle.Jump();
        }

        base.OnUpdate();

        OnPlayerMoved.SafeInvoke(_trackVehicle.Velocity, transform.position);
    }
}