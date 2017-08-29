using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientUI : MonoBehaviour
{
	[SerializeField]
	GameObject CanvasObject;
#if SERVER
	void Start()
	{
		Destroy(CanvasObject);
	}
#endif
}
