using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : Collectable
{
    public CrystalColor crystalColor;
    protected override void OnRabitHit(HeroRabit rabit)
    {
        //Rabbit must die
        CrystalsPanel.current.addCrystal(crystalColor);
        this.CollectedHide();
    }
}
