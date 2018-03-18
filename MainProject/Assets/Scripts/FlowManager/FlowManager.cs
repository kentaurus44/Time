using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class FlowManager : SingletonComponent<FlowManager>
{
	[SerializeField]
	private FlowDatabase _database;
	[SerializeField]
	private FlowLoadingScreen _loadingScreen;
	[SerializeField]
	private Canvas _canvas;
	private Stack<View> _views = new Stack<View>();
	private Coroutine _coroutine;
	private View _currentView;
	private string _loadingView;
	private FlowView _currentViewSettings;

	private Dictionary<string, object> _parameters = null;

	public bool IsLoading { get { return _coroutine != null; } }
	public View CurrentView { get { return _currentView; } }
	public FlowDatabase Database { get { return _database; } }

	private void Open(string scene)
	{
		FlowView view = _database.Get(scene);
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

	public void TriggerAction(string action, string view = "", Dictionary<string, object> param = null)
	{
		_parameters = param;
		switch (action)
		{
			case FlowDatabase.kClose:
				Close();
				break;
			case FlowDatabase.kOpen:
				Open(view);
				break;
		}
	}

	private IEnumerator SceneLoading(FlowView scene)
	{
		string id = scene.Id;

		_loadingScreen.transform.SetAsLastSibling();

		if (!scene.IsPopup && scene.UseLoadingEnter || (_currentViewSettings != null && _currentViewSettings.UseLoadingExit))
		{
			_loadingScreen.gameObject.SetActive(true);
			_loadingScreen.Begin();
		}

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
				_currentViewSettings = scene;
				break;
			}
		}

		_currentView.transform.SetParent(_canvas.transform, false);
		_currentView.transform.SetSiblingIndex(_loadingScreen.transform.GetSiblingIndex() - 1);

		yield return SceneManager.UnloadSceneAsync(id);

		if (!scene.IsPopup)
		{
			View view;
			while (_views.Count > 0)
			{
				view = _views.Pop();
				view.StartClosingSequence();
				yield return null;
				Destroy(view.gameObject);
			}
		}

		_currentView.OnViewLoaded(_parameters);

		if (_loadingScreen.isActiveAndEnabled)
		{
			while (!_currentView.LoadingComplete || _loadingScreen.IsTransitioning)
			{
				yield return null;
			}

			_loadingScreen.End();

			while (_loadingScreen.IsLoadingScreeenOpen)
			{
				yield return null;
			}

			_loadingScreen.gameObject.SetActive(false);
		}

		_currentView.OnFocusGain();

		yield return null;

		_loadingView = string.Empty;
		_coroutine = null;
		_parameters = null;
	}

	private void Close()
	{
		Destroy(_currentView.gameObject);
		_currentView = _views.Pop();
	}
}