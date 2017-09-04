#if !SERVER
using UnityEngine;
using System.Collections.Generic;
using LiteNetLib;
using System;
using LiteNetLib.Utils;

public class PlayerStateCoordinator : MonoBehaviour
{
	IInput _input;
	FirstPersonController _controller;
	Transform trans;
	Rigidbody _rigidbody;
	Queue<State> StatesFromServer;
	NetPeer Server;
	bool ConnectedToServer = false;

	void OnEnable()
	{
		Client.ClientConnectedToServer += OnClientConnectedToServer;
		Client.ClientReceived += OnClientReceivedData;
	}


	void OnDisable()
	{
		Client.ClientConnectedToServer -= OnClientConnectedToServer;
	}

	void Start()
	{
		StatesFromServer = new Queue<State>();
		_controller = GetComponent<FirstPersonController>();
		_rigidbody = GetComponent<Rigidbody>();
		_input = _controller.Input;
		trans = transform;
	}

	private void OnClientConnectedToServer(NetPeer peer)
	{
		Server = peer;
		ConnectedToServer = true;
	}

	private void OnClientReceivedData(NetDataReader reader)
	{
	}

	void FixedUpdate()
	{
		if (ConnectedToServer)
		{
			var stateAndInput = ConstructStateAndInput(ConstructState());
			Server.Send(stateAndInput.Pack(), SendOptions.Unreliable);
			Debug.Log($"Sent position: {stateAndInput.state.position}, moveInput: {stateAndInput.movementInput}");
		}
	}

	State ConstructState()
	{
		State state = new State
		{
			index = 0,
			position = trans.position,
			rotation = trans.rotation,
			velocity = _rigidbody.velocity
		};
		return state;
	}

	StateAndInput ConstructStateAndInput(State state)
	{
		var stateAndInput = new StateAndInput
		{
			state = state,
			movementInput = _input.GetAxes(AxisType.Movement),
			lookInput = _input.GetAxes(AxisType.Look),
			jumpInput = _input.WasKeyJustPressed(PlayerAction.Jump),
			shootInput = _input.WasKeyJustPressed(PlayerAction.Shoot)
		};
		return stateAndInput;
	}

}
#endif