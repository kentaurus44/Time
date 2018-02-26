﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class View : ViewComponent
{
	public override void OnViewLoaded()
	{
		base.OnViewLoaded();
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