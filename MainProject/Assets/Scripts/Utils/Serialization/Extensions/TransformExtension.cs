using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TransformExtension
{
	public const string kLocalPositionKey = "LocalPosition";
	
	public static Hashtable Serialize(this Transform transform)
	{
		Hashtable hash = new Hashtable();
		hash.Add(kLocalPositionKey, transform.position.ToSerializeString());
		return hash;
	}

	public static Transform Deserilize(this Transform transform, Hashtable hash)
	{
		transform.position = hash[kLocalPositionKey].ToString().ToVector();
		return transform;
	}
}
