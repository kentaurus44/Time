using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public abstract class TrackObject : MonoBehaviour
{
	[SerializeField]
	protected string _id;

	public string ID { get { return _id; } }

	public abstract void Load();
	public abstract void Unload();
}

[System.Serializable]
public abstract class TrackObject<T> : TrackObject where T : Object
{
	protected T GetAsset()
	{
		return ResourceManager.Instance.Get<T>(_id);
	}
}