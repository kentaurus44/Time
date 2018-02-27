using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class GameSceneResourceController : MonoBehaviour
{
	private const string kLevel = "Level";

	private static readonly List<string> kResources = new List<string>()
	{
		kLevel
	};

	[SerializeField]
	protected string _resourcePath;

	private int _itemsLoaded = 0;
	private Action OnAssetseLoadedComplete;

	public void Init(string chapter, Action onAssetsLoaded)
	{
		_itemsLoaded = 0;
		OnAssetseLoadedComplete = onAssetsLoaded;
		foreach (var item in kResources)
		{
			ResourceManager.Instance.LoadResource(chapter, OnAssetsLoaded, _resourcePath);
		}
	}

	private void OnAssetsLoaded(string asset)
	{
		if (kResources.Contains(asset))
		{
			_itemsLoaded++;
			if (_itemsLoaded >= kResources.Count)
			{ 
				OnAssetseLoadedComplete.SafeInvoke();
			}
		}
	}
}
