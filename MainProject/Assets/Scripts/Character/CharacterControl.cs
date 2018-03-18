using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class CharacterControl : Character
{
	private float _direction;

	public float Direction { get { return _direction; } }

    public override void OnUpdate()
    {
        if (Input.GetKey(KeyCode.D))
        {
			_direction = 1f;
        }
        else if (Input.GetKey(KeyCode.A))
        {
			_direction = -1f;
        }
		else
		{
			_direction = 0f;
		}

		_trackVehicle.Move(_direction);


		if (!_trackVehicle.IsInAir && Input.GetKeyDown(KeyCode.Space))
        {
            _trackVehicle.Jump();
        }

        base.OnUpdate();
    }
}