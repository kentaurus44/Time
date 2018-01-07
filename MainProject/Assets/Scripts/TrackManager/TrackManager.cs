using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackManager : SingletonComponent<TrackManager>
{
    [SerializeField]
    protected TrackContainer _currentTrackContainer;

    public Track GetLandingTrack(Transform position)
    {
        return _currentTrackContainer.GetLandingTrack(position.position);
    }
}