using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Axis { Movement, Look}
public enum AxisDir { Horizontal, Vertical }
public interface IInput
{
	float GetAxis(Axis axis, AxisDir dir);
	void UpdateInput();
}
