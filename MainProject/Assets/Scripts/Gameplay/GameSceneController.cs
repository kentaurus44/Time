﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameSceneController : MonoBehaviour
{
	[SerializeField]
	private GameSceneResourceController _gameSceneResourceController = null;

	private bool _gameReadyToPlay = false;
	private PlayerController _player;

	protected virtual void Update()
	{
		if (_gameReadyToPlay)
		{
			_player.OnUpdate();

			// CustomCamera.CameraManager.Instance.MainCameraController.SetTargetPosition(_player.transform.position, _player.Vehicle.Direction);
		}
	}

	public void Init(string item, Action onReadyToPlay)
	{
		StartCoroutine(Process(item, onReadyToPlay));
	}

	protected IEnumerator Process(string item, Action onReadyToPlay)
	{
		yield return _gameSceneResourceController.Processing(item, new List<string>());
		yield return InitGame();
		yield return Complete(onReadyToPlay);
	}

	protected virtual IEnumerator InitGame()
	{
		TrackManager.Instance.Load(_gameSceneResourceController.Chapter.TrackContainer);
		_player = _gameSceneResourceController.Player;
		_player.transform.SetParent(_gameSceneResourceController.Chapter.CharacterInitialPosition.transform, false);
		_player.transform.localPosition = Vector3.zero;
		_player.Vehicle.LoadSettings(DatabaseManager.Instance.PlayerConfigs.VehicleSettings);
		yield return null;

		CameraConfigs _cameraConfigs = DatabaseManager.Instance.CameraConfigs;
		// CustomCamera.CameraManager.Instance.MainCameraController.Init(DatabaseManager.Instance.CameraConfigs);
		// CustomCamera.CameraManager.Instance.MainCameraController.SetAtPosition(_player.transform.position);
		// _player.Vehicle.OnLanded += CustomCamera.CameraManager.Instance.MainCameraController.SetFloor;
		// _player.Vehicle.OnJump += CustomCamera.CameraManager.Instance.MainCameraController.OnJump;
		yield return null;


		PlayerControlManager.OnMove += _player.Vehicle.Move;
		PlayerControlManager.OnJump += _player.Vehicle.Jump;
		yield return null;

		_gameSceneResourceController.Player.Init();
		yield return null;
	}

	protected IEnumerator Complete(Action onReadyToPlay)
	{
		_gameReadyToPlay = true;
		onReadyToPlay.SafeInvoke();
		yield return null;
	}
}
