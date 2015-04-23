using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CameraPath : MonoBehaviour {
	
	
	public List<Vector3> waypoints = new List<Vector3>();
	
	public bool Looped;
	int next; 

	
	public Vector3 NextWaypoint()
	{
		if (next < waypoints.Count)
		{
			return waypoints[next];
		}
		else
		{
			return Vector3.zero;
		}
	}
	
	public void AddWaypoint(Vector3 waypoint)
	{
		waypoints.Add(waypoint);
	}
	
	
	public Vector3 Advance()
	{
		if (Looped)
		{
			next = (next + 1) % waypoints.Count;
		}
		else
		{
			if (next < (waypoints.Count - 1))
			{
				next++;
			}
		}
		
		return NextWaypoint();
	}
	
	public bool IsLast()
	{
		return ((! Looped) && (next == waypoints.Count - 1));
	}
	
	void Start()
	{
		AddWaypoint (new Vector3 (this.transform.position.x+100, this.transform.position.y+80, this.transform.position.z));
		AddWaypoint (new Vector3 (this.transform.position.x+100, this.transform.position.y+80, this.transform.position.z));
		AddWaypoint (new Vector3 (this.transform.position.x+100, this.transform.position.y+80, this.transform.position.z));

	}
	void Update()
	{

	}
}


