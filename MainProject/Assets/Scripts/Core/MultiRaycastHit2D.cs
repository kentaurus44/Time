using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiRaycastHit2D
{
    public const float kWallOffset = 0.1f;

    public enum Direction
    {
        Vertical,
        Horizontal
    }

    private Transform _transform;

    private RaycastHit2D _hit;
    private float _distance;

    private Direction _direction;

    private Vector3 Center
    {
        get { return _transform.position; }
    }

    public bool IsColliding
    {
        get { return _hit.collider != null && _hit.distance <= _distance; }
    }

    public Vector3 Point
    {
        get { return _hit.point; }
    }

    public void SetTransform(Transform transform, Vector3 offeset)
    {
        _transform = transform;
    }

    public MultiRaycastHit2D(Direction direction)
    {
        _direction = direction;
    }

    public void Raycast(float direction, float measurement, float distance, int layerMask, int raycastCount = 2)
    {
        _distance = distance + kWallOffset;

        if (!HitMiddle(direction, layerMask))
        {
            for (int i = 0; i < Mathf.FloorToInt(raycastCount / 2); ++i)
            {
                _hit = Raycast(direction, layerMask, Mathf.FloorToInt(measurement / (i + 2)) - kWallOffset * 5);

                if (IsColliding)
                {
                    return;
                }
            }

            for (int i = 0; i < Mathf.FloorToInt(raycastCount / 2); ++i)
            {
                _hit = Raycast(direction, layerMask, Mathf.FloorToInt(-measurement / (i + 2)) + kWallOffset * 5);

                if (IsColliding)
                {
                    return;
                }
            }
        }
    }

    private RaycastHit2D Raycast(float direction, int layerMask, float measurement = 0)
    {
        Vector3 center = Center;
        Vector3 directionVector = Vector3.zero;

        switch (_direction)
        {
            case Direction.Vertical:
                center.x += measurement;
                directionVector = Vector3.up;
                break;
            case Direction.Horizontal:
                center.y += measurement;
                directionVector = Vector3.right;
                break;
        }

        return Physics2D.Raycast(center, directionVector * direction, _distance, layerMask);
    }

    private bool HitMiddle(float direction, int layerMask)
    {
        _hit = Raycast(direction, layerMask);
        return IsColliding;
    }
}