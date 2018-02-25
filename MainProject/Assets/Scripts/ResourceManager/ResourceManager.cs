using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class ResourceManager : SingletonComponent<ResourceManager>
{
	private const string kResourcePath = "Resource/";
	private Dictionary<string, ResourceData> _resource = new Dictionary<string, ResourceData>();
	private Queue<ResourceRequest> _queue = new Queue<ResourceRequest>();
	private Coroutine _coroutine;

	public bool IsLoadingAsset { get { return _queue.Count > 0; } }

	public T Get<T>(string item) where T : UnityEngine.Object
	{
		return _resource[item].Get() as T;
	}

	public T Get<T>(string item, out int index) where T : UnityEngine.Object
	{
		return _resource[item].Get(out index) as T;
	}

	public T Get<T>(string item, int index) where T : UnityEngine.Object
	{
		ResourceData data = null;

		if (_resource.TryGetValue(item, out data))
		{
			return data.Get(index) as T;
		}
		else
		{
			Debug.LogErrorFormat("Item {0} was not found.", item);
		}

		return null;
	}

	public void LoadResource(string resource, Action<string> onResourceLoaded, string path = "")
	{
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

			ResourceData data;
			for (int i = 0, count = resource.Data.Length; i < count; ++i)
			{
				data = resource.Data[i];
				_resource.Add(data.Id, data);
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

