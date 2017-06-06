using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour {
	protected virtual void OnRabitHit(HeroRabit rabit) {}

	void OnTriggerEnter2D(Collider2D collider) {
		//if(!this.hideAnimation) {
			HeroRabit rabit = collider.GetComponent<HeroRabit>();
			Debug.Log("Yooo rabit");
			if(rabit != null) {
				Debug.Log("Yooo");
				this.OnRabitHit (rabit);
			}
		//}
	}

	public void CollectedHide() {
		Destroy(this.gameObject);
	}
}