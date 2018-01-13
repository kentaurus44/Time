using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCharacter : CharacterControl
{
    [SerializeField]
    PlayerConfigs _playerConfigs;

    private void Update ()
    {
        _trackVehicle.LoadSettings(_playerConfigs.VehicleSettings);
        OnUpdate();
	}
}