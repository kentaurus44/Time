﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roomba : Character
{
    private enum States
    {
        Patrol,
        Falling,
        PrefightRitual,
        Chase
    }

    private States _currentState = States.Falling;
    private float _direction = 1f;

    public override void OnUpdate()
    {
        if (_trackVehicule.IsInAir)
        {
            _currentState = States.Falling;
        }
        else if (_currentState == States.Falling)
        {
            _currentState = States.Patrol;
        }

        switch (_currentState)
        {
            case States.Falling:
                _trackVehicule.Move(0f);
                break;
            case States.Patrol:
                if (_trackVehicule.IsAtEnd)
                {
                    _direction *= -1f;
                }
                _trackVehicule.Move(_direction);
                break;
            case States.PrefightRitual:
                break;
            case States.Chase:
                break;
            default:
                break;
        }

        base.OnUpdate();
    }
}