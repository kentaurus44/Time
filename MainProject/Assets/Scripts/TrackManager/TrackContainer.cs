using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackContainer : MonoBehaviour
{
    [SerializeField]
    protected Track[] _tracks;

    public Track this[int index]
    {
        get
        {
            return _tracks[index];
        }
    }

    public int Count
    {
        get { return _tracks.Length; }
    }

    public Track GetLandingTrack(Vector3 position)
    {
        Track closest = null;
        float xPosition = position.x;
        float yPosition = position.y;
        float smallesDistance = Mathf.Infinity;
        for (int i = 0, count = Count; i < count; ++i)
        {
            if (_tracks[i].IsOnTrack(position))
            {
                float difference = yPosition - _tracks[i].GetFloor(xPosition);
                if (difference >= 0 && difference < smallesDistance)
                {
                    smallesDistance = difference;
                    closest = _tracks[i];
                }
            }
        }

        return closest;
    }

#if UNITY_EDITOR
    public void LoadTracks()
    {
        _tracks = GetComponentsInChildren<Track>();
    }
#endif
}
