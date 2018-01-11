using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackVehicle : MonoBehaviour
{
    private const float kWallOffset = 0.1f;

    [SerializeField]
    protected BoxCollider2D _collider;

    [Header("Tracks")]
    [SerializeField]
    protected Track _previousTrack;
    [SerializeField]
    protected Track _currentTrack;

    [Header("Gravity")]
    [SerializeField]
    protected float _gravity = 9.62f;
    [SerializeField]
    protected float _fallMultiplier = 1.5f;
    [SerializeField]
    protected float _lowToJumpMultiplier = 1f;

    [Header("Jump")]
    [SerializeField]
    protected float _jumpVelocity = 650f;

    [SerializeField]
    protected bool _isInAir = false;

    [Header("Movement")]
    [SerializeField]
    protected float _move = 100f;
    [SerializeField]
    protected bool _switchTrackAtEnd = true;

    protected Vector3 _velocity;
    protected Vector3 _predictedPosition;
    protected Track _tempTrack;

    public bool IsInAir
    {
        get { return _isInAir; }
    }

    public bool IsAtEnd
    {
        get
        {
            float ratio = _currentTrack.GetRatio(transform.position.x);
            return ratio <= 0.05f || ratio >= 0.95f;
        }
    }

    public virtual void Move(float direction)
    {
        if (direction != 0f && !IsColliding(direction))
        {
            _velocity.x = _move * direction;
        }
        else
        {
            _velocity.x = 0f;
        }
    }

    public virtual void Jump()
    {
        _velocity.y = _jumpVelocity;
        _isInAir = true;
    }

    public virtual void OnUpdate()
    {
        _tempTrack = TrackManager.Instance.GetLandingTrack(transform);
        if (_currentTrack == null || _tempTrack != null && _tempTrack != _currentTrack)
        {
            _previousTrack = _currentTrack;
            _currentTrack = _tempTrack;
        }

        ApplyGravity();

        transform.Translate(_velocity * CustomTime.fixedDeltaTime);
        _predictedPosition = transform.position;

        if (_previousTrack != _currentTrack)
        {
            _isInAir = true;
            _previousTrack = _currentTrack;
        }

        if (_currentTrack != null)
        {
            if (_velocity.x != 0)
            {
                float sign = Mathf.Sign(_velocity.x);
                if (IsColliding(sign))
                {
                    if (sign > 0)
                    {
                        _predictedPosition.x = CollisionPoint(sign).x - (_collider.size.x / 2f) - kWallOffset;
                    }
                    else if (sign < 0)
                    {
                        _predictedPosition.x = (_collider.size.x / 2f) - CollisionPoint(sign).x - kWallOffset;
                    }
                    _velocity.x = 0f;
                }
            }

            if (_isInAir)
            {
                float floor = _currentTrack.GetFloor(_predictedPosition.x);

                if (Mathf.Abs(floor - _predictedPosition.y) < 1f || _predictedPosition.y < floor)
                {
                    _predictedPosition.y = GetHeight();
                    _velocity.y = 0;
                    _isInAir = false;
                }
            }
            else if (!_currentTrack.IsOnTrack(_predictedPosition))
            {
                SwitchTracks();
            }
            else
            {
                _predictedPosition.y = GetHeight();
            }
        }

        transform.position = _predictedPosition;
    }

    protected virtual void ApplyGravity()
    {
        _velocity.y -= Mathf.Abs(_gravity) * _fallMultiplier;
    }

    protected virtual void SwitchTracks()
    {
        if (_switchTrackAtEnd)
        {
            _previousTrack = _currentTrack;
            _currentTrack = _currentTrack.GetNewTrack(_predictedPosition);

            if (_currentTrack != null)
            {
                _predictedPosition.y = GetHeight();
            }
        }
    }

    protected float GetHeight()
    {
        return _currentTrack.GetFloor(_predictedPosition.x) + 0.01f;
    }

    private Vector2 CollisionPoint(float direction)
    {
        RaycastHit2D hit = CheckCollision(direction);
        return hit.point;
    }

    private bool IsColliding(float direction)
    {
        RaycastHit2D hit = CheckCollision(direction);
        return hit.collider != null && hit.distance <= kWallOffset + (_collider.size.x /2f * direction);
    }

    private RaycastHit2D CheckCollision(float direction)
    {
        return Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y) + _collider.offset, Vector2.right * direction, kWallOffset + (_collider.size.x / 2f * direction), 1 << LayerMask.NameToLayer("Wall"));
    }
}