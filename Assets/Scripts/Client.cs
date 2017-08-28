using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LiteNetLib;
using LiteNetLib.Utils;

public class Client :IFixedUpdatable, INetEventListener
{
	NetManager _netClient;
	NetSerializer _serializer;
	public Client(string connectionKey, string serverIp, int serverPort)
	{
		_serializer = new NetSerializer();
		_netClient = new NetManager(this, connectionKey);
		_netClient.Start(); //gets available port
		_netClient.Connect(serverIp, serverPort);
	}
	public void FixedUpdate()
	{
		_netClient.PollEvents(); //calls delegates of INetEventListener implemented below
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
		Debug.Log("Connected to server");
		ExamplePacketClass packet = new ExamplePacketClass{id=1, x=24, y=7, z=18};
		peer.Send(_serializer.Serialize(packet), SendOptions.ReliableUnordered);
	}

	public void OnPeerDisconnected(NetPeer peer, DisconnectInfo disconnectInfo)
	{
	}
}
