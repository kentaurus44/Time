using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class CharacterControl : Character
{
    public Action<Vector3, Vector3, bool> OnPlayerMoved;

    public override void Init()
    {
        base.Init();
        _trackVehicle.LoadSettings(DatabaseManager.Instance.PlayerConfigs.VehicleSettings);
        CameraConfigs _cameraConfigs = DatabaseManager.Instance.CameraConfigs;
        CustomCamera.CameraManager.Instance.MainCameraController.Init(_cameraConfigs.X, _cameraConfigs.Y);
        OnPlayerMoved += CustomCamera.CameraManager.Instance.MainCameraController.OnPlayerMoved;

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

        OnPlayerMoved.SafeInvoke(_trackVehicle.Velocity, transform.position, _trackVehicle.IsInAir);
    }
}