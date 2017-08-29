using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LiteNetLib;
using LiteNetLib.Utils;
using UnityEngine; //TODO: remove

public class Client :IFixedUpdatable, INetEventListener
{
	NetManager _netClient;
	public Client(string connectionKey)
	{
		_netClient = new NetManager(this, connectionKey);
		_netClient.Start(); //gets available port
	}
	public void ConnectToServer(string serverIp, int serverPort)
	{
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
		ExamplePacketStruct packet = new ExamplePacketStruct{id=11, position=new Vector3(24, 7, 18)};
		peer.Send(packet.Pack(), SendOptions.ReliableUnordered);
	}

	public void OnPeerDisconnected(NetPeer peer, DisconnectInfo disconnectInfo)
	{
	}
}
