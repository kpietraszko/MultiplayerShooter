using System;
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
	[SerializeField]
	float DragConstant = 0.1f;
	[SerializeField]
	Transform FPPCamera;
	[SerializeField]
	float MouseSensitivity = 2f;

	IInput _input;
	Rigidbody _rigidbody;
	Vector3 Velocity; //debug
	int StopTime; //debug
	Vector3 Force; //debug
	Vector3 Drag; //debug

	System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

	void Start()
	{
		_input = new PlayerInput(); //pass _controls here in the future
		_rigidbody = GetComponent<Rigidbody>();
		Cursor.lockState = CursorLockMode.Locked;
	}

	void Update()
	{
		_input.UpdateInput();
		Rotate();
	}

	void FixedUpdate()
	{
		Move();
	}

	void Move()
	{
		#region timeToStop
		if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
		{
			sw.Start();
		}
		#endregion
		var movement = _input.GetAxes(AxisType.Movement).normalized;
		Velocity = _rigidbody.velocity;
		Force = new Vector3(movement.x, 0f, movement.y) * ForceMultiplier;
		Drag = DragConstant * SignedVectorSquare(Velocity);
		var netForce = Force - Drag;
		var netForceRelCam = FPPCamera.TransformDirection(netForce);
		if (_rigidbody.velocity.magnitude < MaxSpeed)
			_rigidbody.AddForce(netForceRelCam * Time.fixedDeltaTime, ForceMode.Force);
		#region timeToStop
		if (Mathf.Approximately(Velocity.x, 0f))
		{
			sw.Stop();
			var time = (int)sw.ElapsedMilliseconds;
			StopTime = time > 0 ? time : StopTime; //assign only if greater than 0
			sw.Reset();
		}
		#endregion
	}

	private void Rotate()
	{
		var mouseMovement = _input.GetAxes(AxisType.Look);

		var verticalRotation = Quaternion.AngleAxis(-mouseMovement.y * MouseSensitivity, transform.right); //variable rotation axis
		FPPCamera.rotation = verticalRotation * FPPCamera.rotation;

		var horizontalRotation = Quaternion.AngleAxis(mouseMovement.x * MouseSensitivity * 1f, Vector3.up); //rotation axis is constant here
		transform.rotation = horizontalRotation * transform.rotation;
	}

	Vector3 SignedVectorSquare(Vector3 vector)
	{
		return Vector3.Scale(vector, new Vector3(Mathf.Abs(vector.x), Mathf.Abs(vector.y), Mathf.Abs(vector.z)));
	}
}
