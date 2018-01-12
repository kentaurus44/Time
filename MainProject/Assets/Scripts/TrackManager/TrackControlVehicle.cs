using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackControlVehicle : TrackVehicle
{
    private MultiRaycastHit2D _verticalRaycast = new MultiRaycastHit2D(MultiRaycastHit2D.Direction.Vertical);

    protected override void Start()
    {
        base.Start();
        _verticalRaycast.SetTransform(transform, _collider.offset);
    }

    protected override void ApplyGravity()
    {
        if (_isInAir)
        {
            if (_velocity.y > 0 && Input.GetKey(KeyCode.Space))
            {
                _velocity.y -= Mathf.Abs(_gravity) * _lowToJumpMultiplier;
            }
            else
            {
                base.ApplyGravity();
            }
        }
    }

    protected override void CheckAirCollision()
    {
        _verticalRaycast.Raycast(1f, _collider.size.x, (_collider.size.y), 1 << LayerMask.NameToLayer("Ceiling"));

        if (_verticalRaycast.IsColliding)
        {
            _predictedPosition.y = _verticalRaycast.Point.y - (_collider.size.y) - MultiRaycastHit2D.kWallOffset;
            _velocity.y = 0;
        }

        base.CheckAirCollision();
    }
}
