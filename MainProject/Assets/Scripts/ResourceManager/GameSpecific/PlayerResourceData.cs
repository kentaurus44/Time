using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerResourceData : ResourceData<PlayerResourceData>
{
	[SerializeField]
	protected PlayerController _player;

	public PlayerController Player { get { return _player; } }
}