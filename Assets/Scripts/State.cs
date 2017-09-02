using UnityEngine;
using UdpKit;

public struct State 
{
	public int index;
	public Vector3 position;
	public Quaternion rotation;
	public Vector3 velocity;

	//public byte[] Pack()
	//{
	//	var data = new byte[44];
	//	var stream = new UdpBitStream(data, data.Length);
	//	stream.WriteInt(index, 32);
	//	stream.WriteVector3(position);
	//	stream.WriteQuaternion(rotation);
	//	stream.WriteVector3(velocity);
	//	return data;
	//}

	//public void Unpack(byte[] data)
	//{
	//	var stream = new UdpBitStream(data, data.Length);
	//	index = stream.ReadInt(32);
	//	position = stream.ReadVector3();
	//	rotation = stream.ReadQuaternion();
	//	velocity = stream.ReadVector3();
	//}
}
