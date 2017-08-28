﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LiteNetLib;
using LiteNetLib.Utils;

public class Server :IFixedUpdatable, INetEventListener
{
	NetManager _netServer;
	public Server(string connectionKey, int port)
	{
		_netServer = new NetManager(this, connectionKey);
		_netServer.Start(port);
	}
	public void FixedUpdate()
	{
		_netServer.PollEvents(); //calls delegates of INetEventListener implemented below
		Debug.Log("_netServer.PeersCount = " + _netServer.PeersCount);
	}
	//New remote peer connected to host, or client connected to remote host
	public void OnPeerConnected(NetPeer peer)
	{
		Debug.Log($"Peer {peer} connected to server");
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
		throw new System.NotImplementedException();
	}

	public void OnNetworkReceiveUnconnected(NetEndPoint remoteEndPoint, NetDataReader reader, UnconnectedMessageType messageType)
	{
	}
	public void OnPeerDisconnected(NetPeer peer, DisconnectInfo disconnectInfo)
	{
		Debug.Log($"Peer {peer} disconnected: {disconnectInfo}");
	}
}
