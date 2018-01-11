using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : Character
{
    public override void OnUpdate()
    {
        if (Input.GetKey(KeyCode.D))
        {
            _trackVehicule.Move(1f);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            _trackVehicule.Move(-1f);
        }
        else
        {
            _trackVehicule.Move(0f);
        }

        if (!_trackVehicule.IsInAir && Input.GetKeyDown(KeyCode.Space))
        {
            _trackVehicule.Jump();
        }

        base.OnUpdate();
    }
}