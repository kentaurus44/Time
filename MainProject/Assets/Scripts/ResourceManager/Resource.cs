using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour
{
	[SerializeField]
	private ResourceData[] _resources = new ResourceData[0];

	public ResourceData[] Data { get { return _resources; } }
}
