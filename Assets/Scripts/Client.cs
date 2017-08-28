using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LiteNetLib;
using LiteNetLib.Utils;

public class Client :IFixedUpdatable, INetEventListener
{
	NetManager _netClient;
	public Client(string connectionKey, string serverIp, int serverPort)
	{
		_netClient = new NetManager(this, connectionKey);
		_netClient.Start(); //gets available port
		_netClient.Connect(serverIp, serverPort);
	}
	public void FixedUpdate()
	{
		_netClient.PollEvents(); //calls delegates of INetEventListener implemented below
		if (_netClient.GetFirstPeer()?.ConnectionState == ConnectionState.Connected)
		{
			Debug.Log("Sending...");
			_netClient.GetFirstPeer().Send(new byte[] { 0, 1, 0, 1, 0, 1, 0, 1 }, SendOptions.ReliableUnordered);
		}
	}
	public void OnNetworkError(NetEndPoint endPoint, int socketErrorCode)
	{
		Debug.Log("Network error: " + socketErrorCode);
	}

	public void OnNetworkLatencyUpdate(NetPeer peer, int latency)
	{
	}

	public void OnNetworkReceive(NetPeer peer, NetDataReader reader)
	{
	}

	public void OnNetworkReceiveUnconnected(NetEndPoint remoteEndPoint, NetDataReader reader, UnconnectedMessageType messageType)
	{
	}

	public void OnPeerConnected(NetPeer peer)
	{
	}

	public void OnPeerDisconnected(NetPeer peer, DisconnectInfo disconnectInfo)
	{
	}
}
