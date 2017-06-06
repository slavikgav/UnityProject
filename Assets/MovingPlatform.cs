using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {
	public Vector3 MoveBy;
	Vector3 pointA;
	Vector3 pointB;

	public float speed;
	public float pause;

	Vector3 my_pos;
	Vector3 target;

	private bool going_to_a = false;
	private float time_to_wait;
	public float delay;

	// Use this for initialization
	void Start () {
		this.pointA = this.transform.position;
		this.pointB = this.pointA + MoveBy;
	}
	
	// Update is called once per frame
	void Update () {
		platformsMove();
	}

	bool isArrived(Vector3 pos, Vector3 target) {
		pos.z = 0;
		target.z = 0;
		return Vector3.Distance(pos, target) < 0.02f;
	}

	void platformsMove(){
		time_to_wait -= Time.deltaTime;
		if(time_to_wait > 0){
			return;
		}
		if(going_to_a){
			target = pointA;
		}else{
			target = pointB;
		}
		my_pos = transform.position;
		Vector3 direction = target - my_pos;
		transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * speed);
		if (isArrived(transform.position, target)){
			going_to_a = !going_to_a;
			time_to_wait = delay;
		}
		transform.Translate(direction.normalized * Time.deltaTime * speed);
	}
}
