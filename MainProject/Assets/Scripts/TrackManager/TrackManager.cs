using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackManager : SingletonComponent<TrackManager>
{
    [System.Serializable]
    public class VisibleSettings
    {
        [SerializeField]
        private float _width;

        [SerializeField]
        private float _height;

        [SerializeField]
        private Vector3 _center = Vector3.zero;

        public VisibleSettings()
        {
            _width = 0f;
            _height = 0f;
        }

        public float Width
        {
            get { return _width; }
            set { _width = value; }
        }

        public float Height
        {
            get { return _height; }
            set { _height = value; }
        }

        public Vector3 Center
        {
            get { return _center; }
            set { _center = value; }
        }
    }

    [SerializeField]
    protected TrackContainer _currentTrackContainer;

    private VisibleSettings _visibleSettings = new VisibleSettings();

    public void UpdateVisibleSettings(float width, float height)
    {
        _visibleSettings.Width = width;
        _visibleSettings.Height = height;
    }

    public void Load(TrackContainer trackContainer)
    {
        _currentTrackContainer = trackContainer;
    }

    public Track GetLandingTrack(Transform position)
    {
        return _currentTrackContainer.GetLandingTrack(position.position);
    }
}