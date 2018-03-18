using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(fileName = "FlowDatabase", menuName = "Database/FlowManager/FlowDatabase", order = 1)]
public class FlowDatabase : Database<FlowDatabase>
{
	public const string kOpen = "Open";
	public const string kClose = "Close";

	public static readonly string[] kFlowActions = new string[]
	{
		kOpen,
		kClose
	};

	[SerializeField]
	private FlowView[] _views = new FlowView[0];

	public FlowView[] Views { get { return _views; } }
	
	public string[] ViewNames
	{
		get
		{
			List<string> display = new List<string>();

			display.AddRange(_views.Select(x => x.Id));

			return display.ToArray();
		}
	}

	public FlowView Get(string id)
	{
		FlowView view = null;
		FlowView tempView = null;
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
