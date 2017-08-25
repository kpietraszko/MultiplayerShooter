using UnityEngine;
using UnityEngine.Networking;

public class Client : MonoBehaviour
{
	private const int serverPort = 8888;
	private int ClientSocketId;
	private int ConnectionId;
	private byte Error;
	private int ReliableChannelId;
	private int SocketId;
	private void Connect()
	{
		NetworkTransport.Init();
		var config = new ConnectionConfig();
		ReliableChannelId = config.AddChannel(QosType.Reliable);
		var topology = new HostTopology(config, 8);
		SocketId = NetworkTransport.AddHost(topology, 0);
		ConnectionId = NetworkTransport.Connect(SocketId, "127.0.0.1", serverPort, 0, out Error);
	}

	private void Start()
	{
		Connect();
	}

	private void Update()
	{
		PollConnection();
	}
	void PollConnection()
	{
		byte[] recBuffer = new byte[1024];
		int hostId;
		int connectionId;
		int channelId;
		int receivedSize;
		byte error;
		var networkEvent = NetworkTransport.Receive(out hostId, out connectionId, out channelId, recBuffer, recBuffer.Length * sizeof(byte), out receivedSize, out error);
		switch (networkEvent)
		{
		case NetworkEventType.DataEvent:
			break;
		case NetworkEventType.ConnectEvent:
			Debug.Log($"Connect event at frame {Time.frameCount}");
			break;
		case NetworkEventType.DisconnectEvent:
			break;
		case NetworkEventType.Nothing:
			break;
		case NetworkEventType.BroadcastEvent:
			break;
		default:
			break;
		}
	}
}