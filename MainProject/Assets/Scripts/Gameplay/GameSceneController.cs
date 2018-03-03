using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameSceneController : MonoBehaviour
{
	[SerializeField]
	private GameSceneResourceController _gameSceneResourceController = null;

	private bool _gameReadyToPlay = false;

	protected void Update()
	{
		if (_gameReadyToPlay)
		{
			_gameSceneResourceController.Player.OnUpdate();
		}
	}

	public void Init(string item, Action onReadyToPlay)
	{
		StartCoroutine(Process(item, onReadyToPlay));
	}

	private IEnumerator Process(string item, Action onReadyToPlay)
	{
		yield return _gameSceneResourceController.Processing(item, new List<string>());
		TrackManager.Instance.Load(_gameSceneResourceController.Chapter.TrackContainer);
		_gameSceneResourceController.Player.transform.SetParent(_gameSceneResourceController.Chapter.CharacterInitialPosition.transform, false);
		_gameSceneResourceController.Player.transform.localPosition = Vector3.zero;

		yield return null;
		CustomCamera.CameraManager.Instance.MainCameraController.OnPlayerMoved(Vector3.zero, _gameSceneResourceController.Player.transform.position, true);

		yield return null;
		_gameSceneResourceController.Player.Init();

		_gameReadyToPlay = true;
		onReadyToPlay.SafeInvoke();
	}
}
