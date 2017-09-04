using UnityEngine;
using UdpKit;

public struct State 
{
	public int index;
	public Vector3 position;
	public Quaternion rotation;
	public Vector3 velocity;

	public override string ToString()
	{
		return $"index: {index}, position: {position}, rotation: {rotation}, velocity: {velocity}";
	}
}
