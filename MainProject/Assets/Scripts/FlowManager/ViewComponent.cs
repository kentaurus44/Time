using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewComponent : MonoBehaviour
{
	private bool _loadingComplete = false;

	public bool LoadingComplete { get { return _loadingComplete; } }

	public virtual void OnViewLoaded(Dictionary<string, object> param)
	{

	}

	public virtual void StartOpeningSequence()
	{
		
	}

	public virtual void OnStartOpeningSequenceComplete()
	{
		
	}

	public virtual void OnViewOpened()
	{
		_loadingComplete = true;
	}

	public virtual void OnFocusGain()
	{

	}

	public virtual void StartClosingSequence()
	{
		
	}

	public virtual void OnClosingSequenceCOmplete()
	{
		
	}
}
