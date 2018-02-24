using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
[RequireComponent(typeof(TrackEditorScript))]
#endif
public class Track : MonoBehaviour
{
    [SerializeField]
    protected Track _leftConnector;

    [SerializeField]
    protected Track _rightConnector;

    [SerializeField]
    protected Transform _begin;

    [SerializeField]
    protected Transform _end;

    [SerializeField]
    protected TrackManager.VisibleSettings _visibleSettings = new TrackManager.VisibleSettings();

    public Transform BeginPoint
    {
        get { return _begin; }
    }

    public Transform EndPoint
    {
        get { return _end; }
    }

    public TrackManager.VisibleSettings VisibleSettings
    {
        get { return _visibleSettings; }
    }

#if UNITY_EDITOR
    public Track LeftConnector
    {
        get { return _leftConnector; }
        set { _leftConnector = value; }
    }

    public Track RightConnector
    {
        get { return _rightConnector; }
        set { _rightConnector = value; }
    }
#endif

    public bool AreNeighbors(Track track)
    {
        return track == _leftConnector || track == _rightConnector;
    }

    public bool IsOnTrack(Vector3 position)
    {
        float ratio = GetRatio(position.x);

        return ratio >= 0f && ratio <= 1f;
    }

    public Track GetNewTrack(Vector3 position)
    {
        float ratio = GetRatio(position.x);

        if (ratio < 0f)
        {
            return _leftConnector;
        }
        else if (ratio > 1f)
        {
            return _rightConnector;
        }

        return this;
    }

    public float GetFloor(float x)
    {
        return Mathf.Lerp(_begin.position.y, _end.position.y, GetRatio(x));
    }

    public float GetRatio(float x)
    {
        return (x - _begin.position.x) / (_end.position.x - _begin.position.x);
    }
}
