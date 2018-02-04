using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : GameplayItem
{
    [SerializeField]
    protected TrackVehicle _trackVehicle;

    public TrackVehicle Vehicle
    {
        get { return _trackVehicle; }
    }


    public virtual void Init()
    {
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        _trackVehicle.OnUpdate();
    }
}