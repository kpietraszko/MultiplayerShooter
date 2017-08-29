using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="ScriptableObject/Controls")]
public class ControlsSO : ScriptableObject
{
	[SerializeField]
	public KeyCode JumpKey;
	[SerializeField]
	public KeyCode ShootKey;
}
