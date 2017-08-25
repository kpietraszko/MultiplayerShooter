using UnityEngine;
using UnityEngine.Networking;

public class Server : MonoBehaviour
{
	private int ReliableChannelId;
	private int SocketId;
	private int ClientSocketId;
	private byte Error;

	private void Start()
	{
		Client.OnConnectedToServer += OnClientConnected;
		NetworkTransport.Init();
		var config = new ConnectionConfig();
		ReliableChannelId = config.AddChannel(QosType.Reliable);
		var topology = new HostTopology(config, 8);
		SocketId = NetworkTransport.AddHost(topology, 8888);
	}

	private void OnClientConnected(object sender, System.EventArgs e)
	{
		Debug.Log("Imma connection event handler :)");
		NetworkTransport.Send(SocketId, )

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