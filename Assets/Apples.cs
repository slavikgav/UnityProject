using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apples : Collectable
{
    protected override void OnRabitHit(HeroRabit rabit)
    {
        LevelController.current.addApples(1);
        this.CollectedHide();
    }
}