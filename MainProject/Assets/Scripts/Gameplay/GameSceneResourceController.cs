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

	private static readonly List<string> kResources = new List<string>()
	{
		kLevel,
		kPlayerData
	};

	private List<string> _enemyList;

	public IEnumerator Processing(string chapterName, List<string> enemyList)
	{
		yield return null;

		_enemyList = enemyList;

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

		Chapter chapterResource = ResourceManager.Instance.Get<Chapter>(kLevel);
		PlayerResourceData playerResource = ResourceManager.Instance.Get<PlayerResourceData>(kPlayerData);
		playerResource.Player.transform.SetParent(chapterResource.CharacterInitialPosition.transform, false);
		playerResource.Player.transform.localPosition = Vector3.zero;
		yield return null;
	}

	private void OnAssetsLoaded(string asset)
	{
	}
}