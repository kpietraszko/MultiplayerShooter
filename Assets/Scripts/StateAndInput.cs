using UnityEngine;
using System.Collections;
using UdpKit;

public struct StateAndInput
{
	public State state;
	public Vector2 movementInput;
	public Vector2 lookInput;
	public bool jumpInput;
	public bool shootInput;

	public byte[] Pack()
	{
		var data = new byte[61];
		var stream = new UdpBitStream(data, data.Length);
		stream.WriteInt(state.index, 32);
		stream.WriteVector3(state.position);
		stream.WriteQuaternion(state.rotation);
		stream.WriteVector3(state.velocity);
		stream.WriteVector2(movementInput);
		stream.WriteVector2(lookInput);
		stream.WriteBool(jumpInput);
		stream.WriteBool(shootInput);
		return data;
	}

	public void Unpack(byte[] data) //should this be reversed (read end to beginning)?
	{
		var stream = new UdpBitStream(data, data.Length);
		state = new State();
		state.index = stream.ReadInt(32);
		state.position = stream.ReadVector3();
		state.rotation = stream.ReadQuaternion();
		state.velocity = stream.ReadVector3();
		movementInput = stream.ReadVector2();
		lookInput = stream.ReadVector2();
		jumpInput = stream.ReadBool();
		shootInput = stream.ReadBool();
	}
}
