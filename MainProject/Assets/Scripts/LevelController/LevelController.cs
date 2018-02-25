using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
	[SerializeField]
	protected string _item;

	public void Start()
	{
		ResourceManager.Instance.LoadResource(_item, OnItemLoaded);
	}

	public void OnItemLoaded(string item)
	{
		Debug.LogError(item);
	}
}
