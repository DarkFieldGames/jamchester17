using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabbing : MonoBehaviour {

	public Int32 GrabRadius = 1;
	public Transform GrabbedObject;

	// Use this for initialization
	void Grab()
	{
		if (GrabbedObject != null)
			return;
	}
}
