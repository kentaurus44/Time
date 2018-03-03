using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackTexture2D : TrackObject<Texture2D>
{
	[SerializeField]
	protected Renderer _renderer;

	public override void Load()
	{
		//_renderer.material.mainTexture = GetAsset();
	}

	public override void Unload()
	{
		_renderer.material.mainTexture = null;
	}
}
