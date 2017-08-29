using UnityEngine;
using System.Collections.Generic;

public class PlayerInput : IInput
{
	private readonly Dictionary<Axis, Vector2> _axes = new Dictionary<Axis, Vector2>()
	{
		{ Axis.Movement, Vector2.zero},
		{ Axis.Look, Vector2.zero }
	};

	public float GetAxis(Axis axis, AxisDir dir)
	{
		var axisVector = _axes[axis];
		var value = dir == AxisDir.Horizontal ? axisVector.x : axisVector.y;
		return value;
	}

	public void UpdateInput()
	{
		_axes[Axis.Movement] = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
		_axes[Axis.Look] = new Vector2(Input.GetAxisRaw("MouseX"), Input.GetAxisRaw("MouseY"));
	}

}
