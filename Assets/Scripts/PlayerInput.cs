using UnityEngine;
using System.Collections.Generic;

public class PlayerInput : IInput
{
	//private readonly Dictionary<Action, KeyCode> _keys; //for later, get from Controls SO
	private readonly Dictionary<AxisType, Vector2> _axes = new Dictionary<AxisType, Vector2>()
	{
		{ AxisType.Movement, Vector2.zero},
		{ AxisType.Look, Vector2.zero }
	};

	public Vector2 GetAxes(AxisType axisType)
	{
		return _axes[axisType];
	}

	public float GetAxis(AxisType axisType, AxisDir dir)
	{
		var axisVector = _axes[axisType];
		var value = dir == AxisDir.Horizontal ? axisVector.x : axisVector.y;
		return value;
	}

	public void UpdateInput()
	{
		_axes[AxisType.Movement] = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
		_axes[AxisType.Look] = new Vector2(Input.GetAxisRaw("MouseX"), Input.GetAxisRaw("MouseY"));
	}

}
