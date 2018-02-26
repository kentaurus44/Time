﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FlowDatabase", menuName = "Database/FlowManager/FlowDatabase", order = 1)]
public class FlowDatabase : Database<FlowDatabase>
{
	public static readonly string[] kFlowActions = new string[]
	{
		"OPEN",
		"CLOSE"
	};

	[System.Serializable]
	public class View
	{
		[SerializeField]
		private string _id;
		[SerializeField]
		private bool _isPopup = false;

		public string Id { get { return _id; } }
		public bool IsPopup { get { return _isPopup; } }
	}

	[SerializeField]
	private View[] _views = new View[0];

	public View[] Views { get { return _views; } }
	
	public View Get(string id)
	{
		View view = null;
		View tempView = null;
		for (int i = 0, count = _views.Length; i < count; ++i)
		{
			tempView = _views[i];
			if (tempView.Id == id)
			{
				view = tempView;
				break;
			}
		}
		return view;
	}
}
