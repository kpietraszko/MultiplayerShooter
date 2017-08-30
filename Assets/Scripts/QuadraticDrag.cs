using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadraticDrag : MonoBehaviour
{
	[Header("Keep linear drag in Rigidbody at 0")]
	[SerializeField]
	float DragConstant = 1;
	Rigidbody rb;
	Vector3 drag;
	void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	void FixedUpdate()
	{
		var velocity = rb.velocity;
		var dragAlong = DragConstant * Vector3.Scale(velocity,velocity); //constant * velocity^2
		drag = dragAlong * -1;
		rb.AddForce(drag, ForceMode.Force);
	}

}
