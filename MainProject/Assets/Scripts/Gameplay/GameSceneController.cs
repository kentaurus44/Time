using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameSceneController : MonoBehaviour
{
	[SerializeField]
	private GameSceneResourceController _gameSceneResourceController;

	private Action OnReadyToPlayCB;

	public void Init(string item, Action onReadyToPlay)
	{
		OnReadyToPlayCB = onReadyToPlay;
		_gameSceneResourceController.Init(item, OnResourceLoaded);
	}

	private void OnResourceLoaded()
	{
	}

	private void ReadyToPlay()
	{
		OnReadyToPlayCB.SafeInvoke();
	}
}
