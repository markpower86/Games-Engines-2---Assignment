using UnityEngine;
using System.Collections;

public class CamFollow : MonoBehaviour {
	
	public Vector3 velocity;
	public Vector3 acceleration;
	public Vector3 force;
	public float mass;
	public float maxSpeed;
	public CameraPath path;
	public Transform focus;
	
	public bool Looped;
	
	Vector3 FollowPath()
	{
		Vector3 next = path.NextWaypoint ();
		
		float dist = (transform.position - next).magnitude;
		float waypointDistance = 5;
		if (dist < waypointDistance)
		{
			next = path.Advance();
		}
		if (!path.Looped && path.IsLast())
		{
			return Arrive(next);
		}
		else
		{
			return Seek(next);
		}
	}
	
	Vector3 Seek(Vector3 seekTarget)
	{
		Vector3 desired = seekTarget - transform.position;
		desired.Normalize();
		desired *= maxSpeed;
		return desired - velocity;
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
	// Use this for initialization
	void Start () 
	{
		path = GetComponent<CameraPath>();
		path.Looped = Looped;
	}
	
	// Update is called once per frame
	void Update () 
	{
		force += FollowPath();
		
		acceleration = force / mass;
		velocity += acceleration * Time.deltaTime;
		Vector3.ClampMagnitude(velocity, maxSpeed);
		
		
		
		transform.position += velocity * Time.deltaTime;
		
		if (velocity.magnitude > float.Epsilon)
		{
			transform.LookAt(focus);
			velocity *= 0.99f;
		}
		
		force = Vector3.zero;
	}
}
