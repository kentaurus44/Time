using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using WebSocketSharp;
using WebSocketSharp.Net;

public class ServerTest : MonoBehaviour
{
	private void Start()
	{
		var s = new WebSocket("http://127.0.0.1:8080");
	}
}
