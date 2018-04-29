using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ServerConfig", menuName = "Configs/ServerConfig", order = 1)]
public class ServerConfig : ScriptableObject
{
	[System.Serializable]
	private class ServerInformation
	{
		[SerializeField]
		private ServerLocation _location;
		[SerializeField]
		private string _address;

		public ServerLocation Location { get { return _location; } }
		public string Address { get { return _address; } }
	}

	[SerializeField]
	private ServerInformation[] _serverInformation = new ServerInformation[0];
}

public enum ServerLocation
{
	Dev,
	Live
}