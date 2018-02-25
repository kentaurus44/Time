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

    public void CalculateCollider()
    {
		Vector2 size = _track.BoxCollider.size;
		size.x = _track.EndPoint.localPosition.x - _track.BeginPoint.localPosition.x;
		size.y = 1f;
		_track.BoxCollider.size = size;
    }
#endif
}