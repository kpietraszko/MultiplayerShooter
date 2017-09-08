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

	public IInput Input { get; private set; }
	Rigidbody _rigidbody;
	Vector3 Velocity; //debug
	float VelocityMagn; //debug
	int StopTime; //debug
	Vector3 Force; //debug
	Vector3 Drag; //debug
	bool Grounded;
	float verticalAngle = 0f;

	System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

	void Awake()
	{
#if !SERVER
		Input = new PlayerInput(_controls);
#else
		Input = new ServerInput();
#endif
	}

	void Start()
	{
		_rigidbody = GetComponent<Rigidbody>();
		//Cursor.lockState = CursorLockMode.Locked;
	}

	void Update()
	{
		Input.UpdateInput();
		Rotate();
	}

	void FixedUpdate()
	{
		Move();

		if (Input.WasKeyJustPressed(PlayerAction.Jump) && Grounded)
			Jump();
	}


	void Move()
	{
#region timeToStop
		if (UnityEngine.Input.GetKeyUp(KeyCode.A) || UnityEngine.Input.GetKeyUp(KeyCode.D))
		{
			sw.Start();
		}
#endregion
		var movementInput = Input.GetAxes(AxisType.Movement);
		var cameraForwardFlattened = Vector3.ProjectOnPlane(FPPCamera.forward, Vector3.up).normalized;
		var cameraRightFlattened = Vector3.ProjectOnPlane(FPPCamera.right, Vector3.up).normalized;
		var movement = cameraForwardFlattened * movementInput.y + cameraRightFlattened * movementInput.x;
		Velocity = _rigidbody.velocity;
		VelocityMagn = Velocity.magnitude;
		Force = movement * ForceMultiplier;
		Drag = DragConstant * SignedVectorSquare(Velocity);
		var netForce = Force - Drag;
		if (_rigidbody.velocity.magnitude < MaxSpeed)
			_rigidbody.AddForce(netForce * Time.fixedDeltaTime, ForceMode.Force);
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
		var mouseMovement = Input.GetAxes(AxisType.Look);

		var verticalAngleToAdd = -mouseMovement.y * MouseSensitivity;
		if (verticalAngleToAdd + verticalAngle > 90f || verticalAngleToAdd + verticalAngle < -90f)
			verticalAngleToAdd = 0f;
		else
		{
			verticalAngle += verticalAngleToAdd;
		}
		var verticalRotation = Quaternion.AngleAxis(verticalAngleToAdd, transform.right); //variable rotation axis
		FPPCamera.rotation = verticalRotation * FPPCamera.rotation;

		var horizontalRotation = Quaternion.AngleAxis(mouseMovement.x * MouseSensitivity * 1f, Vector3.up); //rotation axis is constant here
		transform.rotation = horizontalRotation * transform.rotation;
	}

	private void Jump()
	{
		_rigidbody.AddForce(0f, 20f, 0f, ForceMode.Impulse);
	}

	void OnCollisionEnter(Collision collision)
	{
		if (collision.transform.CompareTag("Ground"))
			Grounded = true;
	}

	void OnCollisionExit(Collision collision)
	{
		if (collision.transform.CompareTag("Ground"))
			Grounded = false;
	}


	Vector3 SignedVectorSquare(Vector3 vector)
	{
		return Vector3.Scale(vector, new Vector3(Mathf.Abs(vector.x), Mathf.Abs(vector.y), Mathf.Abs(vector.z)));
	}
}
