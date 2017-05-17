using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroFollow : MonoBehaviour {
	public HeroRabit rabit;
	
	
	// Update is called once per frame
	void Update () {
		//Get access to component Transform
		//GetComponent<Transform>
		Transform rabit_transform = rabit.transform;
		//Get access to component Transform camera
		Transform camera_transform = this.transform;
		//Get access to rabbit's coordinates
		Vector3 rabit_position = rabit_transform.position;
		Vector3 camera_position = camera_transform.position;
		//Move camera only by X,Y
		camera_position.x = rabit_position.x;
		camera_position.y = rabit_position.y;
		//Set coordinates of camera
		camera_transform.position = camera_position;
	}
}
