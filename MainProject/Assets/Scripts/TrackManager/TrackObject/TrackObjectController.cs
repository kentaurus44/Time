using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackObjectController : MonoBehaviour
{
	[SerializeField]
	private TrackObject[] _trackObjects = new TrackObject[0];

	public void OnTrackEnterScreen()
	{
		for (int i = 0, count = _trackObjects.Length; i < count; ++i)
		{
			_trackObjects[i].Load();
		}
	}

	public void OnTrackExitScreen()
	{
		for (int i = 0, count = _trackObjects.Length; i < count; ++i)
		{
			_trackObjects[i].Unload();
		}
	}

#if UNITY_EDITOR
	public void LoadObjects()
	{
		_trackObjects = GetComponentsInChildren<TrackObject>();
	}
#endif
}
