using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Evade : MonoBehaviour {

	public Vector3 velocity;
	public Vector3 acceleration;
	public Vector3 force;
	public float mass;
	public float maxSpeed;


	public float fleeWeight;
	public Transform fleeTarget;
	public float fleeRange;
	[HideInInspector]
	public Vector3 fleeForce;
	
	Vector3 Flee(Vector3 targetPos)
	{
		Vector3 desiredVelocity;
		desiredVelocity = transform.position - targetPos;
		if (desiredVelocity.magnitude > fleeRange)
		{
			return Vector3.zero;
		}
		desiredVelocity.Normalize();
		desiredVelocity *= maxSpeed;
		return (desiredVelocity - velocity);
	}

	void Update()
	{
		force += Flee(fleeTarget.transform.position) * fleeWeight;
		acceleration =  force / mass;
		velocity += acceleration * Time.deltaTime;
		Vector3.ClampMagnitude(velocity, maxSpeed);
		
		
		
		transform.position += velocity * Time.deltaTime;
		
		if (velocity.magnitude > float.Epsilon)
		{
			transform.forward = velocity.normalized;
			velocity *= 0.99f;
		}
		
		force = Vector3.zero;
	}
}
