using UnityEngine;
using System.Collections;

public class ServerInput : IInput //TODO: implement it
{
	public Vector2 GetAxes(AxisType axisType)
	{
		return new Vector2(0, 0);
	}

	public float GetAxis(AxisType axisType, AxisDir dir)
	{
		return 0f;
	}

	public void UpdateInput()
	{

	}

	public bool WasKeyJustPressed(PlayerAction action)
	{
		return false;
	}
}
