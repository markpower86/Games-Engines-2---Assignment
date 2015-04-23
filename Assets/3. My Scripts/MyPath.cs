using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class MyPath : MonoBehaviour {

	
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
		if (Application.loadedLevelName == "Scene 2") 
		{
			AddWaypoint (new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z + 200));
		}
		if (Application.loadedLevelName == "Scene 3") 
		{
			AddWaypoint (new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z + 130));
			AddWaypoint (new Vector3 (this.transform.position.x, this.transform.position.y-100, this.transform.position.z + 240));
			AddWaypoint (new Vector3 (this.transform.position.x, this.transform.position.y-30, this.transform.position.z +280));



		}

    }
}


