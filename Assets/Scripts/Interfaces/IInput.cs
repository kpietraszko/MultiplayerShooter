using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum AxisType { Movement, Look}
public enum AxisDir { Horizontal, Vertical }
public enum Action { Jump, Shoot}
public interface IInput
{
	float GetAxis(AxisType axisType, AxisDir dir);
	Vector2 GetAxes(AxisType axisType);
	void UpdateInput();
}
