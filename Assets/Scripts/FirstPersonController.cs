using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
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
		//float xForce = _input.GetAxis(AxisType.Movement, AxisDir.Horizontal);
		//_rigidbody.AddForce()
	}
}
