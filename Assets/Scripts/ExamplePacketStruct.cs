using UdpKit;
public struct ExamplePacketStruct
{
	public int id;
	public float x;
	public float y;
	public float z;
	public byte[] Pack()
	{
		byte[] data = new byte[16];
		var stream = new UdpBitStream(data, data.Length);
		stream.WriteInt(id);
		stream.WriteFloat(x);
		stream.WriteFloat(y);
		stream.WriteFloat(z);
		return stream.Data;
	}
	public void Unpack(byte[] data)
	{
		var stream = new UdpBitStream(data, data.Length);
		id = stream.ReadInt();
		x = stream.ReadFloat();
		y = stream.ReadFloat();
		z = stream.ReadFloat();
	}
	public override string ToString()
	{
		return $"id:{id}, x:{x}, y:{y}, z:{z}";
	}
}
