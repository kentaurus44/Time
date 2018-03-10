using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FlowDatabase", menuName = "Database/FlowManager/FlowView", order = 1)]
public class FlowView : ScriptableObject
{
	[SerializeField]
	private string _id;
	[SerializeField]
	private bool _isPopup = false;

	[Header("Loading Screen")]
	[SerializeField]
	private bool _onExit = false;
	[SerializeField]
	private bool _onEnter = false;

	public string Id { get { return _id; } }
	public bool IsPopup { get { return _isPopup; } }
	public bool UseLoadingEnter { get { return _onEnter; } }
	public bool UseLoadingExit { get { return _onExit; } }
}
