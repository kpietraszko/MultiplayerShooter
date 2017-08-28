using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LiteNetLib;
using LiteNetLib.Utils;
using System.Text;

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
		byte[] receivedBytes = new byte[8];
		reader.GetBytes(receivedBytes, receivedBytes.Length);
		StringBuilder testString = new StringBuilder();
		foreach (var @byte in receivedBytes)
			testString.Append(@byte);
		Debug.Log("receivedBytes  = " + testString);
	}

	public void OnNetworkReceiveUnconnected(NetEndPoint remoteEndPoint, NetDataReader reader, UnconnectedMessageType messageType)
	{
	}
	public void OnPeerDisconnected(NetPeer peer, DisconnectInfo disconnectInfo)
	{
		Debug.Log($"Peer {peer} disconnected: {disconnectInfo}");
	}
}
