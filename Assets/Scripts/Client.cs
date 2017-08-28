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

	}
	public void OnNetworkError(NetEndPoint endPoint, int socketErrorCode)
	{
		throw new System.NotImplementedException();
	}

	public void OnNetworkLatencyUpdate(NetPeer peer, int latency)
	{
		throw new System.NotImplementedException();
	}

	public void OnNetworkReceive(NetPeer peer, NetDataReader reader)
	{
		throw new System.NotImplementedException();
	}

	public void OnNetworkReceiveUnconnected(NetEndPoint remoteEndPoint, NetDataReader reader, UnconnectedMessageType messageType)
	{
		throw new System.NotImplementedException();
	}

	public void OnPeerConnected(NetPeer peer)
	{
		throw new System.NotImplementedException();
	}

	public void OnPeerDisconnected(NetPeer peer, DisconnectInfo disconnectInfo)
	{
		throw new System.NotImplementedException();
	}
}
