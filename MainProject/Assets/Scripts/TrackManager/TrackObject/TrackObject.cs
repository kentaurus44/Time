using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public abstract class TrackObject : MonoBehaviour
{
	protected enum RequestObjectType
	{
		Specific,
		Random,
		RandomRemember
	}

	[SerializeField]
	protected RequestObjectType _objectRequest = RequestObjectType.Specific;
	[SerializeField]
	protected string _id;

	public string ID { get { return _id; } }

	public abstract void Load();
	public abstract void Unload();
}

[System.Serializable]
public abstract class TrackObject<T> : TrackObject where T : Object
{
	private int _index = -1;

	protected T GetAsset()
	{
		switch (_objectRequest)
		{
			case RequestObjectType.Specific:
				return GetSpecific();
			case RequestObjectType.Random:
				return GetRandom();
			case RequestObjectType.RandomRemember:
				return GetRandomSpecific();
		}

		return null;
	}

	private T GetSpecific()
	{
		return ResourceManager.Instance.Get<T>(_id, 0);
	}

	private T GetRandom()
	{
		return ResourceManager.Instance.Get<T>(_id);
	}

	private T GetRandomSpecific()
	{
		if (_index == -1)
		{
			return ResourceManager.Instance.Get<T>(_id, out _index);
		}
		else
		{
			return ResourceManager.Instance.Get<T>(_id, _index);
		}
	}
}
