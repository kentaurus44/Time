#if UNITY_EDITOR
using UnityEngine;
#endif

[ExecuteInEditMode]
public class TrackEditorScript : MonoBehaviour
{
#if UNITY_EDITOR
	private Track _track;

    protected virtual void OnDrawGizmos()
    {
        if (_track.BeginPoint && _track.EndPoint)
        {
            Gizmos.color = Color.white;
            Gizmos.DrawLine(_track.BeginPoint.position, _track.EndPoint.position);
        }

        if (_track.VisibleSettings != null)
        {
            if (_track.VisibleSettings.Width == 0)
            {
				CalculateCenter();
            }

            Gizmos.color = Color.blue;
            Vector3 center = _track.VisibleSettings.Center;
            float extendWidth = _track.VisibleSettings.Width / 2f;
            float extendHeight = _track.VisibleSettings.Height / 2f;
            Gizmos.DrawLine(center + new Vector3(extendWidth, extendHeight), center + new Vector3(extendWidth, -extendHeight));
            Gizmos.DrawLine(center + new Vector3(-extendWidth, extendHeight), center + new Vector3(-extendWidth, -extendHeight));
            Gizmos.DrawLine(center + new Vector3(-extendWidth, -extendHeight), center + new Vector3(extendWidth, -extendHeight));
            Gizmos.DrawLine(center + new Vector3(-extendWidth, extendHeight), center + new Vector3(extendWidth, extendHeight));
        }
    }

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

    public void CalculateCenter()
    {
        _track.VisibleSettings.Width = _track.EndPoint.localPosition.x - _track.BeginPoint.localPosition.x;
        Vector3 position = _track.VisibleSettings.Center;
        position.x = _track.EndPoint.position.x - (_track.VisibleSettings.Width / 2f);
        position.y = (_track.EndPoint.position.y - _track.BeginPoint.position.y) / 2f + _track.BeginPoint.position.y;
        _track.VisibleSettings.Center = position;
    }
#endif
}