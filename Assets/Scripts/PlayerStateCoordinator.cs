using UnityEngine;
using System.Collections;

public class PlayerStateCoordinator :MonoBehaviour
{
	[SerializeField]
	ControlsSO _controls;
	IInput _input;
	FirstPersonController _controller;

	void Start()
	{
		_controller = GetComponent<FirstPersonController>();
		_input = _controller.Input;
	}

	void FixedUpdate()
	{

	}

}
