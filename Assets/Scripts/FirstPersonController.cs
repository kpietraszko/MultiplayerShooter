using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
	[SerializeField]
	ControlsSO _controls;
	IInput _input;
	void Start()
	{
		_input = new PlayerInput();
	}

	void Update()
	{
		_input.UpdateInput();
	}

	void FixedUpdate()
	{

	}
}
