using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSpecificTrack : Track
{
	[Header("Game Specific Track")]
	[SerializeField]
	private TrackObjectController _trackObjectController;

	protected void Start()
	{
		OnTrackEnterScreen += _trackObjectController.OnTrackEnterScreen;
		OnTrackExitScreen += _trackObjectController.OnTrackExitScreen;
	}

	protected void OnDestroy()
	{
		OnTrackEnterScreen -= _trackObjectController.OnTrackEnterScreen;
		OnTrackExitScreen -= _trackObjectController.OnTrackExitScreen;
	}
}
