using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : Collectable {
	protected override void OnRabitHit (HeroRabit rabit){
		//Level.current.addFruit (1);
		CollectedHide ();
	}
}