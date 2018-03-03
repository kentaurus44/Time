using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class ResourceData : MonoBehaviour
{
	[SerializeField]
	private string _id = string.Empty;

	public string Id { get { return _id; } }
}

[System.Serializable]
public class ResourceData<T> : ResourceData where T : Object
{
}
