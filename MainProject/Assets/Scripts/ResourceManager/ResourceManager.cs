using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class ResourceManager : SingletonComponent<ResourceManager>
{
	private const string kResourcePath = "Resource";
	private Dictionary<string, ResourceData> _resourceData = new Dictionary<string, ResourceData>();
	private Dictionary<string, Resource> _resource = new Dictionary<string, Resource>();
	private Queue<ResourceRequest> _queue = new Queue<ResourceRequest>();
	private Queue<string> _unloadQueue = new Queue<string>();
	private Coroutine _coroutine;
	private Coroutine _deleteCoroutine;

	public bool IsLoadingAsset { get { return _queue.Count > 0 || _coroutine != null; } }

	public T Get<T>(string item) where T : UnityEngine.Object
	{
		return _resourceData[item] as T;
	}

	public void UnloadResource(string resource)
	{
		_unloadQueue.Enqueue(resource);

		if (isActiveAndEnabled && _deleteCoroutine == null)
		{
			_deleteCoroutine = StartCoroutine("ResourceUnloading");
		}
	}

	public void LoadResource(string resource, Action<string> onResourceLoaded, string path = "")
	{
		if (_resourceData.ContainsKey(resource))
		{
			onResourceLoaded.SafeInvoke(resource);
			return;
		}

		ResourceRequest request;
		request.Path = Path.Combine(kResourcePath, path);
		request.Resource = resource;
		request.OnResourceLoaded = onResourceLoaded;
		_queue.Enqueue(request);

		if (_coroutine == null)
		{
			_coroutine = StartCoroutine("ResourceLoading");
		}
	}

	private IEnumerator ResourceUnloading()
	{
		yield return null;

		string item = string.Empty;

		while (_unloadQueue.Count > 0)
		{
			item = _unloadQueue.Dequeue();

			Resource resource = _resource[item];
			foreach (var data in resource.Data)
			{
				_resourceData.Remove(data.Id);
			}
			Destroy(resource.gameObject);
			yield return null;
			_resource.Remove(item);
		}

		_deleteCoroutine = null;
	}

	private IEnumerator ResourceLoading()
	{
		yield return null;

		ResourceRequest resourceRequest;
		Resource resource;

		while (_queue.Count > 0)
		{
			resourceRequest = _queue.Dequeue();
			yield return resource = Resources.Load<Resource>(Path.Combine(resourceRequest.Path, resourceRequest.Resource));
			yield return resource = Instantiate(resource, transform);

			_resource.Add(resourceRequest.Resource, resource);

			ResourceData data;
			for (int i = 0, count = resource.Data.Length; i < count; ++i)
			{
				data = resource.Data[i];
				_resourceData.Add(data.Id, data);
			}

			resourceRequest.OnResourceLoaded.SafeInvoke(resourceRequest.Resource);
		}

		_coroutine = null;
	}
}

public struct ResourceRequest
{
	public string Path;
	public string Resource;
	public Action<string> OnResourceLoaded;
}

