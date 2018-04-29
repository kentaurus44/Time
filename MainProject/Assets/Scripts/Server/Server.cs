using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class Server : MonoBehaviour 
{
	private void Start()
	{
		StartCoroutine(Upload());
	}

	IEnumerator Upload()
	{
		using (UnityWebRequest www = UnityWebRequest.Put("http://127.0.0.1:8080", ""))
		{
			yield return www.SendWebRequest();

			if (www.isNetworkError || www.isHttpError)
			{
				Debug.Log(www.error);
			}
			else
			{
				Debug.Log("Upload complete!");
			}
		}
	}

	IEnumerator Get()
	{
		using (UnityWebRequest www = UnityWebRequest.Get("http://127.0.0.1:8080"))
		{
			yield return www.SendWebRequest();

			if (www.isNetworkError || www.isHttpError)
			{
				Debug.Log(www.error);
			}
			else
			{
				// Show results as text
				Debug.Log(www.downloadHandler.text);

				// Or retrieve results as binary data
				byte[] results = www.downloadHandler.data;
			}
		}
	}
}
