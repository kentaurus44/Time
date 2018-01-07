using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : GameplayItem
{
    [SerializeField]
    protected TrackVehicle _trackVehicule;

    public override void OnUpdate()
    {
        base.OnUpdate();
        _trackVehicule.OnUpdate();
    }
}
