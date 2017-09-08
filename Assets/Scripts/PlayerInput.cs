using UnityEngine;
using System.Collections.Generic;


public class PlayerInput : IInput
{
	private readonly Dictionary<PlayerAction, KeyCode> _keys = new Dictionary<PlayerAction, KeyCode>();//for later, get from Controls SO
	private readonly Dictionary<AxisType, Vector2> _axes = new Dictionary<AxisType, Vector2>()
	{
		{ AxisType.Movement, Vector2.zero},
		{ AxisType.Look, Vector2.zero }
	};
	public PlayerInput(ControlsSO controls)
	{
		AssignControls(controls);
	}

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

	public bool WasKeyJustPressed(PlayerAction action)
	{
		KeyCode keyCode;
		if (_keys.TryGetValue(action, out keyCode)){
			return Input.GetKeyDown(keyCode);
		}
		return false;
		//else throw new KeyNotFoundException("PlayerInput doesn't have a key assigned to " + action.ToString());
	}

	public void UpdateInput()
	{
		_axes[AxisType.Movement] = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
		_axes[AxisType.Look] = new Vector2(Input.GetAxisRaw("MouseX"), Input.GetAxisRaw("MouseY"));
	}

	void AssignControls(ControlsSO controls)
	{
		_keys.Add(PlayerAction.Jump, controls.JumpKey); //TODO: make a dictionary<PlayerAction, KeyCode> in ControlsSO instead
		_keys.Add(PlayerAction.Shoot, controls.JumpKey);
	}

}
