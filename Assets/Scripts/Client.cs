using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LiteNetLib;
using LiteNetLib.Utils;
using System;

public class Client :IFixedUpdatable, INetEventListener
{
	NetManager _netClient;
	public static event Action<NetPeer> ClientConnectedToServer;
	public static event Action<NetDataReader> ClientReceived;

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


	public void OnNetworkReceive(NetPeer peer, NetDataReader reader)
	{
		ClientReceived?.Invoke(reader);
	}


	public void OnPeerConnected(NetPeer peer)
	{
		Debug.Log("Connected to server");
		ClientConnectedToServer?.Invoke(peer);
		//ExamplePacketStruct packet = new ExamplePacketStruct{id=11, position=new Vector3(24, 7, 18)};
		//peer.Send(packet.Pack(), SendOptions.ReliableUnordered);
	}
	#region unimplemented
	public void OnNetworkReceiveUnconnected(NetEndPoint remoteEndPoint, NetDataReader reader, UnconnectedMessageType messageType)
	{
	}
	public void OnNetworkLatencyUpdate(NetPeer peer, int latency)
	{
	}

	public void OnPeerDisconnected(NetPeer peer, DisconnectInfo disconnectInfo)
	{
	}
#endregion
}
