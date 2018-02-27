using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class FlowAction : MonoBehaviour
{
	[SerializeField]
	protected Button _button;
	[SerializeField, FlowActionAttribute]
	protected string _action;
	[SerializeField, FlowAttribute]
	protected string _view;

	protected void Start()
	{
		_button.onClick.AddListener(OnButtonCB);
	}

	protected virtual void OnButtonCB()
	{
		FlowManager.Instance.TriggerAction(_action, _view);
	}
}
