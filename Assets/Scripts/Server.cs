using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LiteNetLib;
using LiteNetLib.Utils;
using System.Text;
using System;

public class Server :IFixedUpdatable, INetEventListener
{
	NetManager _netServer;
	NetSerializer _serializer;
	public Server(string connectionKey, int port)
	{
		_serializer = new NetSerializer();
		_serializer.Subscribe()
		_netServer = new NetManager(this, connectionKey);
		_netServer.Start(port);
	}

	public void FixedUpdate()
	{
		_netServer.PollEvents(); //calls delegates of INetEventListener implemented below
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
		Debug.Log("Server received something");
		_serializer.ReadAllPackets(reader);
	}

	public void OnNetworkReceiveUnconnected(NetEndPoint remoteEndPoint, NetDataReader reader, UnconnectedMessageType messageType)
	{
	}
	public void OnPeerDisconnected(NetPeer peer, DisconnectInfo disconnectInfo)
	{
		Debug.Log($"Peer {peer} disconnected: {disconnectInfo}");
	}
}
