using UnityEngine;
using UdpKit;
using LiteNetLib.Utils;

public struct StateAndInput
{
	public State state;
	public Vector2 movementInput;
	public Vector2 lookInput;
	public bool jumpInput;
	public bool shootInput;

	public byte[] Pack()
	{
		var data = new byte[1200];
		var stream = new UdpBitStream(data, data.Length);
		//stream.WriteInt(state.index, 32);
		UdpBitStreamExt.WriteVector3(ref stream, state.position);
		UdpBitStreamExt.WriteQuaternion(ref stream, state.rotation);
		UdpBitStreamExt.WriteVector3(ref stream, state.velocity);
		UdpBitStreamExt.WriteVector2(ref stream, movementInput);
		UdpBitStreamExt.WriteVector2(ref stream, lookInput);
		stream.WriteBool(jumpInput);
		stream.WriteBool(shootInput);
		return data;
	}

	public void Unpack(NetDataReader reader)
	{
		byte[] data = reader.Data;
		var stream = new UdpBitStream(data, data.Length);
		state = new State
		{
			//index = stream.ReadInt(32),
			position = UdpBitStreamExt.ReadVector3(ref stream),
			rotation = UdpBitStreamExt.ReadQuaternion(ref stream),
			velocity = UdpBitStreamExt.ReadVector3(ref stream)
		};
		movementInput = UdpBitStreamExt.ReadVector2(ref stream);
		lookInput = UdpBitStreamExt.ReadVector2(ref stream);
		jumpInput = stream.ReadBool();
		shootInput = stream.ReadBool();
	}

	public override string ToString()
	{
		return $"lookInput: {lookInput}, jumpInput: {jumpInput}";
	}
}
