using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class SceneChanger : MonoBehaviour {

	float timer = 0;
	float delay = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;

		if (Application.loadedLevelName == "Scene 1") {
			delay = 8.0f;
			if(timer>delay)
			{
				ChangeToScene("Scene 2");
				timer = 0;
			}
		}
		if (Application.loadedLevelName == "Scene 2") {
			delay = 20.0f;
			if(timer>delay)
			{
				ChangeToScene("Scene 3");
				timer = 0;
			}
		}

	
	}
	public void ChangeToScene(string scene) //Function to allow the main menu buttons to pass in a value
	{
		Application.LoadLevel(scene); //Load scene according to name passed in
		
		
	}
}
