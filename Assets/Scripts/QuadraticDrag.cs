using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadraticDrag : MonoBehaviour
{
	[Header("Keep linear drag in Rigidbody at 0")]
	[SerializeField]
	float DragConstant = 1;
	Rigidbody rb;
	void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	void FixedUpdate()
	{
		var velocity = rb.velocity;
		var drag = DragConstant * Vector3.Scale(velocity,velocity); //constant * velocity^2
		rb.AddForce(drag, ForceMode.Force);
	}

}
