using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
	[SerializeField]
	float ForceMultiplier = 1f;
	[SerializeField]
	ControlsSO _controls;
	IInput _input;
	Rigidbody _rigidbody;
	void Start()
	{
		_input = new PlayerInput(); //pass _controls here in the future
		_rigidbody = GetComponent<Rigidbody>();
	}

	void Update()
	{
		_input.UpdateInput();
	}

	void FixedUpdate()
	{
		var movement = _input.GetAxes(AxisType.Movement).normalized * ForceMultiplier;
		_rigidbody.AddForce(movement.x, 0, movement.y, ForceMode.Force);
	}
}
