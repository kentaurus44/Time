using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlowManager : SingletonComponent<FlowManager>
{
	[SerializeField]
	private FlowDatabase _database;
	private Stack<View> _views = new Stack<View>();
	private Coroutine _coroutine;
	private View _currentView;
	private string _loadingView;

	[SerializeField]
	private Canvas _canvas;

	public bool IsLoading { get { return _coroutine != null; } }
	public View CurrentView { get { return _currentView; } }

	public void Open(string scene)
	{
		FlowDatabase.View view = _database.Get(scene);
		if (view == null)
		{
			Debug.LogErrorFormat("{0} has no settings.", scene);
			return;
		}

		if (_coroutine == null)
		{
			_loadingView = scene;
			_coroutine = StartCoroutine("SceneLoading", view);
		}
		else
		{
			Debug.LogWarningFormat("Cannot load {0} because FlowManager is loading {1}", scene, _loadingView);
		}
	}

	public void TriggerAction(string action, string view = "")
	{
		switch (action.ToUpper())
		{
			case "CLOSE":
				CloseCurrent();
				break;
			case "OPEN":
				Open(view);
				break;
		}
	}

	private IEnumerator SceneLoading(FlowDatabase.View scene)
	{
		string id = scene.Id;
		yield return SceneManager.LoadSceneAsync(id, LoadSceneMode.Additive);
		View[] views;
		yield return views = FindObjectsOfType<View>();

		if (_currentView != null)
		{
			_views.Push(_currentView);
		}

		for (int i = 0, count = views.Length; i < count; ++i)
		{
			View view = views[i];

			if (id == view.name && view != _currentView && !_views.Contains(view))
			{
				_currentView = view;
				break;
			}
		}

		_currentView.transform.parent = _canvas.transform;
		_currentView.transform.SetAsLastSibling();

		yield return SceneManager.UnloadSceneAsync(id);

		if (!scene.IsPopup)
		{
			View view;
			while (_views.Count > 0)
			{
				view = _views.Pop();
				yield return null;
				Destroy(view.gameObject);
			}
		}

		_loadingView = string.Empty;
		_coroutine = null;
	}

	private void CloseCurrent()
	{
		Destroy(_currentView.gameObject);
		_currentView = _views.Pop();
	}

	[ContextMenu("Open")]
	private void TestOpen()
	{
		Open("MainPanel");
	}

	[ContextMenu("Close Current")]
	private void TestClose()
	{
		TriggerAction("CLOSE");
	}
}