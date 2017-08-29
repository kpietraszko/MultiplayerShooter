using UdpKit;
using UnityEngine;
public struct ExamplePacketStruct
{
	public int id;
	public Vector3 position;
	public byte[] Pack()
	{
		byte[] data = new byte[16];
		var stream = new UdpBitStream(data, data.Length);
		stream.WriteInt(id);
		stream.WriteVector3Half(position);
		return data;
	}
	public void Unpack(byte[] data)
	{
		var stream = new UdpBitStream(data, data.Length);
		id = stream.ReadInt();
		position = stream.ReadVector3Half();
	}
	public override string ToString()
	{
		return $"id:{id}, position: ({position.x},{position.y},{position.z})";
	}
}
