using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackControlVehicle : TrackVehicle
{
    protected override void ApplyGravity()
    {
        if (_isInAir)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                _velocity.y -= Mathf.Abs(_gravity) * _lowToJumpMultiplier;
            }
            else
            {
                base.ApplyGravity();
            }
        }
    }
}
