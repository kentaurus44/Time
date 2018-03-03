using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameSceneResourceController : MonoBehaviour
{
	private const string kChapters = "Chapters";
	private const string kLevel = "Level";

	private const string kCharacters = "Characters";
	private const string kPlayerResource = "Player";

	public const string kPlayerData = "Player";

	private PlayerController _player;
	private Chapter _chapter;

	public PlayerController Player
	{
		get { return _player; }
	}

	public Chapter Chapter
	{
		get { return _chapter; }
	}

	public IEnumerator Processing(string chapterName, List<string> enemyList)
	{
		yield return null;

		ResourceManager.Instance.LoadResource(chapterName, OnAssetsLoaded, kChapters);
		ResourceManager.Instance.LoadResource(kPlayerData, OnAssetsLoaded, kCharacters);

		for (int i = 0, count = enemyList.Count; i < count; ++i)
		{
			ResourceManager.Instance.LoadResource(enemyList[i], OnAssetsLoaded, kCharacters);
		}

		while (ResourceManager.Instance.IsLoadingAsset)
		{
			yield return null;
		}

		_chapter = ResourceManager.Instance.Get<Chapter>(kLevel);
		_player = ResourceManager.Instance.Get<PlayerResourceData>(kPlayerData).Player;
		yield return null;
	}

	private void OnAssetsLoaded(string asset)
	{

	}
}