using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class VehicleSettings
{
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

    [Header("Movement")]
    [SerializeField]
    protected float _move = 100f;
    [SerializeField]
    protected bool _switchTrackAtEdge = true;
	
	public float Gravity
    {
        get { return _gravity; }
    }

    public float FallMultiplier
    {
        get { return _fallMultiplier; }
    }

    public float LowToJumpMultiplier
    {
        get { return _lowToJumpMultiplier; }
    }

    public float JumpVelocity
    {
        get { return _jumpVelocity; }
    }

    public float Move
    {
        get { return _move; }
    }

    public bool SwitchTrackAtEdge
    {
        get { return _switchTrackAtEdge; }
    }
}

public class TrackVehicle : MonoBehaviour
{
	public Action<float> OnLanded;
	public Action OnJump;

    [SerializeField]
    protected BoxCollider2D _collider;

    [Header("Tracks")]
    [SerializeField]
    protected Track _previousTrack;
    [SerializeField]
    protected Track _currentTrack;

    
    [SerializeField]
    protected bool _isInAir = false;

	protected float _direction;

	protected Vector3 _velocity;
    protected Vector3 _predictedPosition;
    protected Track _tempTrack;

    protected MultiRaycastHit2D _horizontalRaycast = new MultiRaycastHit2D(MultiRaycastHit2D.Direction.Horizontal);
    private VehicleSettings _settings;

    public virtual VehicleSettings Settings
    {
        get { return _settings; }
    }

    public bool IsInAir
    {
        get { return _isInAir; }
    }

	public float Direction
	{
		get { return _direction; }
	}


	public float Ratio
    {
        get
        {
            return _currentTrack.GetRatio(transform.position.x);
        }
    }

    public Vector3 Velocity
    {
        get
        {
            return _velocity;
        }
    }

    protected virtual void Start()
    {
        _horizontalRaycast.SetTransform(transform, _collider.offset);
    }

    public virtual void LoadSettings(VehicleSettings settings)
    {
        _settings = settings;
    }

    public virtual void Move(float direction)
    {
		_direction = direction;

		if (direction != 0f)
        {
            _velocity.x = Settings.Move * direction;
        }
        else
        {
            _velocity.x = 0f;
        }
    }

    public virtual void Jump()
    {
		if (!_isInAir)
		{
			_velocity.y = Settings.JumpVelocity;
			_isInAir = true;
			OnJump.SafeInvoke();
		}
	}

    public virtual void OnUpdate()
    {
        if (_isInAir)
        {
            _tempTrack = TrackManager.Instance.GetLandingTrack(transform);
            if (_currentTrack == null || _tempTrack != null && _tempTrack != _currentTrack)
            {
                _previousTrack = _currentTrack;
                _currentTrack = _tempTrack;
            }

            ApplyGravity();
        }

        transform.Translate(_velocity * CustomTime.fixedDeltaTime);
        _predictedPosition = transform.position;

        if (_previousTrack != _currentTrack)
        {
            _isInAir = true;
            _previousTrack = _currentTrack;
        }

        if (_velocity.x != 0)
        {
            float sign = Mathf.Sign(_velocity.x);
            _horizontalRaycast.Raycast(sign, _collider.size.y, (_collider.size.x / 2f), 1 << LayerMask.NameToLayer("Wall"), 0);

            if (_horizontalRaycast.IsColliding)
            {
                if (sign > 0)
                {
                    _predictedPosition.x = _horizontalRaycast.Point.x - (_collider.size.x / 2f) - MultiRaycastHit2D.kWallOffset;
                }
                else if (sign < 0)
                {
                    _predictedPosition.x = _horizontalRaycast.Point.x + (_collider.size.x / 2f) + MultiRaycastHit2D.kWallOffset;
                }

                _velocity.x = 0f;
            }
        }

        if (_currentTrack != null)
        {
            if (_isInAir)
            {
                CheckAirCollision();
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

    protected virtual void CheckAirCollision()
    {
        float floor = _currentTrack.GetFloor(_predictedPosition.x);

        if (Mathf.Abs(floor - _predictedPosition.y) < 1f || _predictedPosition.y < floor)
        {
            _predictedPosition.y = GetHeight();
            _velocity.y = 0;
			_isInAir = false;
			OnLanded.SafeInvoke(floor);
		}
	}

    protected virtual void ApplyGravity()
    {
        _velocity.y -= Mathf.Abs(Settings.Gravity) * Settings.FallMultiplier;
    }

    protected virtual void SwitchTracks()
    {
        if (Settings.SwitchTrackAtEdge)
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
}