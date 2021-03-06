﻿using UnityEngine;
using System.Collections.Generic;
using LiteNetLib;
using System;
using LiteNetLib.Utils;

public class PlayerStateCoordinator : MonoBehaviour
{
	IInput _input;
	FirstPersonController _controller;
	Transform _trans;
	Rigidbody _rigidbody;
#if !SERVER
	Queue<State> StatesFromServer;
	NetPeer Server;
	bool ConnectedToServer = false;
#else
	Queue<StateAndInput> StatesFromClient;
#endif

	void OnEnable()
	{
#if !SERVER
		Client.ClientConnectedToServer += OnClientConnectedToServer;
		Client.ClientReceived += OnClientReceivedData;
#else
		Server.ServerReceived += OnServerReceivedData;
#endif
	}

	void OnDisable()
	{
#if !SERVER
		Client.ClientConnectedToServer -= OnClientConnectedToServer;
#else
		Server.ServerReceived -= OnServerReceivedData;
#endif
	}

	void Start()
	{
#if !SERVER
		StatesFromServer = new Queue<State>();
#else
		StatesFromClient = new Queue<StateAndInput>();
#endif
		_controller = GetComponent<FirstPersonController>();
		_rigidbody = GetComponent<Rigidbody>();
		_input = _controller.Input;
		_trans = transform;
	}

#if !SERVER
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
			var packed = stateAndInput.Pack();
			Server.Send(packed, SendOptions.ReliableOrdered);
			UnityEngine.Debug.Log($"Sent {stateAndInput.state}");
		}
	}
#else
	void FixedUpdate()
	{
		if (StatesFromClient.Count > 0)
		{
			var client0state = StatesFromClient.Dequeue();
			_trans.position = client0state.state.position;
			_trans.rotation = client0state.state.rotation;
			_rigidbody.velocity = client0state.state.velocity;
		}
	}
#endif

#if SERVER
	private void OnServerReceivedData(NetDataReader reader)
	{
		var stateAndInput = new StateAndInput();
		stateAndInput.Unpack(reader);
		StatesFromClient.Enqueue(stateAndInput);
		//Debug.Log($"Received {stateAndInput.state}");
	}
#endif

	State ConstructState()
	{
		State state = new State
		{
			index = 0,
			position = _trans.position,
			rotation = _trans.rotation,
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