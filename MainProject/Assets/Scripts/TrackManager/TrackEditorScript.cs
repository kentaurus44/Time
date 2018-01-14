#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[ExecuteInEditMode]
public class TrackEditorScript : MonoBehaviour
{
    private Track _track;

    private void OnEnable()
    {
        if (_track == null)
        {
            _track = GetComponent<Track>();
        }
    }

    public void SnapToLeft()
    {
        if (_track.LeftConnector != null)
        {
            transform.position = transform.position - _track.BeginPoint.position + _track.LeftConnector.EndPoint.position;
            _track.LeftConnector.RightConnector = _track;
        }
    }

    public void SnapToRight()
    {
        if (_track.RightConnector != null)
        {
            transform.position = transform.position - _track.EndPoint.position + _track.RightConnector.BeginPoint.position;
            _track.RightConnector.LeftConnector = _track;
        }
    }
}
#endif