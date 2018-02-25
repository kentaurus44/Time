using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonDebug
{
#if UNITY_EDITOR
	public static void DrawBox(Vector3 center, float extendWidth, float extendHeight)
	{
		Gizmos.DrawLine(center + new Vector3(extendWidth, extendHeight), center + new Vector3(extendWidth, -extendHeight));
		Gizmos.DrawLine(center + new Vector3(-extendWidth, extendHeight), center + new Vector3(-extendWidth, -extendHeight));
		Gizmos.DrawLine(center + new Vector3(-extendWidth, -extendHeight), center + new Vector3(extendWidth, -extendHeight));
		Gizmos.DrawLine(center + new Vector3(-extendWidth, extendHeight), center + new Vector3(extendWidth, extendHeight));
	}
#endif
}
