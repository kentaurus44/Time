using System.Collections;
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

    private bool IsAtEnd
    {
        get
        {
            float ratio = _trackVehicle.Ratio;
            return ratio <= 0.05f || ratio >= 0.95f;
        }
    }

    public override void OnUpdate()
    {
        if (_trackVehicle.IsInAir)
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
                _trackVehicle.Move(0f);
                break;
            case States.Patrol:
                if (IsAtEnd)
                {
                    _direction *= -1f;
                }
                _trackVehicle.Move(_direction);
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
