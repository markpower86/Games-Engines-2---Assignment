using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Follow : MonoBehaviour {

	public Vector3 arriveTarget;
	
	public Vector3 velocity;
	public Vector3 acceleration;
	public Vector3 force;
	public float mass;
	public float maxSpeed;

	public GameObject offsetPursueTarget;
	public Vector3 offset;
	
	void Start () {

			if (offsetPursueTarget != null)
			{
				offset = offsetPursueTarget.transform.position - transform.position;
			}
	}

	Vector3 OffsetPursue(GameObject offsetPursueTarget)
	{
		Vector3 targetPos = offsetPursueTarget.transform.TransformPoint(offset);
		
		Vector3 toTarget = targetPos - transform.position;
		float distance = toTarget.magnitude;
		float time = distance / maxSpeed;
		Vector3 target = targetPos
			+ offsetPursueTarget.GetComponent<PathFollow>().velocity * time;
		
		return Arrive(target);
	}

	Vector3 Arrive(Vector3 arriveTarget)
	{
		Vector3 toTarget = arriveTarget - transform.position;
		
		float distance = toTarget.magnitude;
		
		float slowingDistance = 10;

		float ramped = (distance / slowingDistance) * maxSpeed;
		float clamped = Mathf.Min(ramped, maxSpeed);
		Vector3 desired = (toTarget / distance) * clamped;
		return desired - velocity;
	}

	void Update(){

		force += OffsetPursue(offsetPursueTarget);
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
