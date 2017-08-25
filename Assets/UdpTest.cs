using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.Networking;

public class UdpTest : MonoBehaviour
{
	private int ReliableChannelId;
	private int ServerSocketId;
	private int ClientSocketId;
	private int ConnectionId;

	private void Start()
	{
		NetworkTransport.Init();
		var config = new ConnectionConfig();
		ReliableChannelId = config.AddChannel(QosType.Reliable);
		var topology = new HostTopology(config, 8);
		ServerSocketId = NetworkTransport.AddHost(topology, 8888);
		Debug.Log("HostId = " + ServerSocketId);
		ClientSocketId = NetworkTransport.AddHost(topology, 8887);
		byte connectionError;
		ConnectionId = NetworkTransport.Connect(ClientSocketId, "127.0.0.1", 8888, 0, out connectionError);
	}

	private void Update()
	{
		MyMessage();
	}

	private void MyMessage()
	{
		byte[] buffer = new byte[1000];
		var stream = new MemoryStream(buffer);
		var formatter = new BinaryFormatter();
		formatter.Serialize(stream, "Message through reliable channel");

		byte error;
		NetworkTransport.Send(ClientSocketId, ConnectionId, ReliableChannelId, buffer, buffer.Length * sizeof(byte), out error);
	}
}