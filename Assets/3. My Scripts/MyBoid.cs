using UnityEngine;
using System.Collections;

public class MyBoid : MonoBehaviour {

    [Header("Arrive")]
    public Vector3 arriveTarget;

    public Vector3 velocity;
    public Vector3 acceleration;
    public Vector3 force;
    public float mass;
    public float maxSpeed;

	// Update is called once per frame
	void Update () 
    {
        force += Arrive(arriveTarget);

        acceleration = force / mass;
        velocity += acceleration * Time.deltaTime;
        Vector3.ClampMagnitude(velocity, maxSpeed);

		transform.position += velocity * Time.deltaTime;

        if (velocity.magnitude > float.Epsilon)
        {
            velocity *= 0.99f;
        }

        force = Vector3.zero;
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

}
