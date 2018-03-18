using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class View : ViewComponent
{
	public override void OnViewLoaded(Dictionary<string, object> param)
	{
		base.OnViewLoaded(param);
		StartOpeningSequence();
	}

	public override void StartOpeningSequence()
	{
		base.StartOpeningSequence();
		OnStartOpeningSequenceComplete();
	}

	public override void OnStartOpeningSequenceComplete()
	{
		base.OnStartOpeningSequenceComplete();
		OnViewOpened();
	}

	public override void OnViewOpened()
	{
		base.OnViewOpened();
	}

	public override void StartClosingSequence()
	{
		base.StartClosingSequence();
		OnClosingSequenceCOmplete();
	}

	public override void OnClosingSequenceCOmplete()
	{
		base.OnClosingSequenceCOmplete();
	}
}