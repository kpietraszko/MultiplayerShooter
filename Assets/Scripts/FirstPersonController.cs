using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
	[SerializeField]
	float ForceMultiplier = 1f;
	[SerializeField]
	ControlsSO _controls;
	[SerializeField]
	float MaxSpeed = Mathf.Infinity;
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
		if(_rigidbody.velocity.magnitude < MaxSpeed)
			_rigidbody.AddForce(movement.x, 0, movement.y, ForceMode.Force);
	}
}
