using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Grabbing : MonoBehaviour
{

	public Int32 GrabRadius = 1;
	public Transform GrabbedObject;

	private Transform HoldPoint;

	private void Awake()
	{
		HoldPoint = gameObject.transform.Find("HoldPoint");
	}

	void Grab()
	{
		if (GrabbedObject != null)
			return;

		var colliders = Physics2D.OverlapCircleAll(this.transform.position, GrabRadius);

		Collider2D match = null;

		foreach (var c in colliders)
		{
			if (c.gameObject.CompareTag("Block"))
			{
				match = c;
				break;
			}
		}

		if (match != null)
		{
			GrabbedObject = match.gameObject.transform;
			GrabbedObject.SetParent(HoldPoint, false);
			GrabbedObject.localPosition = Vector3.zero;
		}
	}

	private void FixedUpdate()
	{
		if (CrossPlatformInputManager.GetButtonDown("Grab"))
			Grab();
	}

	private void OnDrawGizmosSelected()
	{
		UnityEditor.Handles.color = Color.blue;
		UnityEditor.Handles.DrawWireDisc(transform.position, Vector3.forward, GrabRadius);
	}
}
