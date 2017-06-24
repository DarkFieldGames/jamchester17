using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Grabbing : MonoBehaviour
{

	public Int32 GrabRadius = 1;
	public Transform GrabbedObject;
	public ContactFilter2D Filter = new ContactFilter2D();

	public Transform HoldPoint;
	public Transform DropPoint;

	private void Awake()
	{
		//HoldPoint = gameObject.transform.Find("HoldPoint");
		//DropPoint = gameObject.transform.Find("DropPoint");
	}

	void Grab()
	{
		if (GrabbedObject != null)
		{
			Drop();
			return;
		}

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
			var grabObject = match.gameObject.transform;
			Hold(grabObject);
		}
	}

	private void Hold(Transform grabObject)
	{
		GrabbedObject = grabObject.transform;
		GrabbedObject.SetParent(HoldPoint, false);
		GrabbedObject.localPosition = Vector3.zero;

		SetGrabObjectPhysics(RigidbodyType2D.Kinematic);
	}

	private void SetGrabObjectPhysics(RigidbodyType2D type)
	{
		if (GrabbedObject == null)
			return;

		var body = GrabbedObject.GetComponent<Rigidbody2D>();
		if (body != null)
			body.bodyType = type;
	}

	void Drop()
	{
		GrabbedObject.SetParent(null);
		GrabbedObject.position = DropPoint.position;

		var collider = GrabbedObject.GetComponent<Collider2D>();

		Collider2D[] array = new Collider2D[1];

		Int32 collision = Physics2D.OverlapCollider(collider, Filter, array);

		if (collision != 0)
		{
			Hold(GrabbedObject);
		}
		else
		{
			SetGrabObjectPhysics(RigidbodyType2D.Dynamic);
			GrabbedObject = null;
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

		UnityEditor.Handles.color = Color.cyan;
		UnityEditor.Handles.DrawWireCube(HoldPoint.position, new Vector3(1, 1));
		UnityEditor.Handles.DrawWireCube(DropPoint.position, new Vector3(1, 1));
	}
}
