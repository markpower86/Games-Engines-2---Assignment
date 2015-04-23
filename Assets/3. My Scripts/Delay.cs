using UnityEngine;
using System.Collections;

public class Delay : MonoBehaviour {
	float timer = 0;
	float delay = 18;
	// Use this for initialization
	void Start () {
		this.gameObject.GetComponent<ParticleSystem>().enableEmission = false;
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer > delay) 
		{
			this.gameObject.GetComponent<ParticleSystem>().enableEmission = true;
		}
	}
}
