using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkInitializer : MonoBehaviour
{
	[SerializeField]
	string GameVersion;
	[SerializeField]
	string ServerIpAddress;
	[SerializeField]
	int ServerPort = 8888;


	IFixedUpdatable serverOrclient;
	void Awake()
	{
#if SERVER
		Debug.Log("Creating server");
		serverOrclient = new Server(GameVersion, ServerPort);
#else
		Debug.Log("Creating client");
		serverOrclient = new Client(GameVersion);
#endif
	}
	public void ConnectClientToServer()
	{
		Debug.Log("Button pressed, connecting");
		((Client)serverOrclient).ConnectToServer(ServerIpAddress, ServerPort);
	}
	void FixedUpdate()
	{
		serverOrclient.FixedUpdate();
	}
}
