using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class ResourceData : MonoBehaviour
{
	[SerializeField]
	private string _id = string.Empty;

	public string Id { get { return _id; } }

	public abstract object Get();
	public abstract object Get(out int index);
	public abstract object Get(int index);
}

[System.Serializable]
public class ResourceData<T> : ResourceData where T : Object
{
	[SerializeField]
	private T[] _object;

	public override object Get()
	{
		return _object[Random.Range(0, _object.Length)];
	}

	public override object Get(out int index)
	{
		index = Random.Range(0, _object.Length);
		return _object[index];
	}

	public override object Get(int index)
	{
		return _object[index];
	}
}
