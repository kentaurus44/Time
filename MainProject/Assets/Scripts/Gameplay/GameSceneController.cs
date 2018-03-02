using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameSceneController : MonoBehaviour
{
	[SerializeField]
	private GameSceneResourceController _gameSceneResourceController;

	public void Init(string item, Action onReadyToPlay)
	{
		StartCoroutine(Process(item, onReadyToPlay));
	}

	private IEnumerator Process(string item, Action onReadyToPlay)
	{
		yield return _gameSceneResourceController.Processing(item, new List<string>());
		onReadyToPlay.SafeInvoke();
	}
}
