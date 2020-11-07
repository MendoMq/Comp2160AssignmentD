﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPivot : MonoBehaviour
{
	public Transform target;
	Rigidbody targetRigidbody;

	public float smoothTime = 0.3f;
	Vector3 velocity = Vector3.zero;

	public float distanceScale;

	void Start ()
	{
		targetRigidbody = target.GetComponent<Rigidbody>();
	}

	void Update ()
	{
		Vector3 positionOffset = -targetRigidbody.velocity * distanceScale;
		Vector3 lerpedPosition = Vector3.Lerp(transform.position, target.position + positionOffset, 0.9f);
		Vector3 newPosition = Vector3.SmoothDamp(transform.position, lerpedPosition, ref velocity, smoothTime);

		transform.position = newPosition;
		transform.eulerAngles = new Vector3(0,target.eulerAngles.y,0);
	}
}
