using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackVehicle : MonoBehaviour
{
    [SerializeField]
    protected Track _previousTrack;
    [SerializeField]
    protected Track _currentTrack;

    [SerializeField]
    protected float _gravity;

    [Header("Jump")]
    [SerializeField]
    protected float _jumpVelocity;
    [SerializeField]
    protected float _fallMultiplier = 1.5f;
    [SerializeField]
    protected float _lowToJumpMultiplier = 1f;
    [SerializeField]
    private bool _isInAir = false;

    [Header("Movement")]
    [SerializeField]
    protected float _move = 100f;

    private Vector3 _velocity;
    private Vector3 _predictedPosition;
    private Track _tempTrack;

    public void OnUpdate()
    {
        if (Input.GetKey(KeyCode.D))
        {
            _velocity.x = _move;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            _velocity.x = -_move;
        }
        else
        {
            _velocity.x = 0f;
        }

        _tempTrack = TrackManager.Instance.GetLandingTrack(transform);
        if (_currentTrack == null || _tempTrack != null && _tempTrack != _currentTrack)
        {
            _previousTrack = _currentTrack;
            _currentTrack = _tempTrack;
        }

        if (!_isInAir && Input.GetKeyDown(KeyCode.Space))
        {
            _velocity.y = _jumpVelocity;
            _isInAir = true;
        }

        if (_isInAir)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                _velocity.y -= Mathf.Abs(_gravity) * _lowToJumpMultiplier;
            }
            else
            {
                _velocity.y -= Mathf.Abs(_gravity) * _fallMultiplier;
            }

        }

        _predictedPosition = transform.position + _velocity * Time.deltaTime;

        transform.Translate(_velocity);

        if (_previousTrack != _currentTrack)
        {
            _isInAir = true;
            _previousTrack = _currentTrack;
        }

        if (_currentTrack != null)
        {
            if (_isInAir)
            {
                float floor = _currentTrack.GetFloor(_predictedPosition.x);

                if (Mathf.Abs(floor - _predictedPosition.y) < 1f || _predictedPosition.y < floor)
                {
                    _predictedPosition.y = _currentTrack.GetFloor(_predictedPosition.x) + 0.01f;
                    _velocity.y = 0;
                    _isInAir = false;
                }
            }
            else if (!_currentTrack.IsOnTrack(_predictedPosition))
            {
                _previousTrack = _currentTrack;
                _currentTrack = _currentTrack.GetNewTrack(_predictedPosition);

                if (_currentTrack != null)
                {
                    _predictedPosition.y = _currentTrack.GetFloor(_predictedPosition.x) + 0.01f;
                }
            }
            else
            {
                _predictedPosition.y = _currentTrack.GetFloor(_predictedPosition.x) + 0.01f;
            }
        }

        transform.position = _predictedPosition;
    }
}