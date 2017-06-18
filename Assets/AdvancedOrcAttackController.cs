using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvancedOrcAttackController : MonoBehaviour
{

    public HeroAdvancedOrc orc;
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (!HeroRabit.lastRabit.isDead() && HeroRabit.lastRabit != null
            && HeroRabit.lastRabit.transform.position.y > orc.transform.position.y + 0.5
            && Mathf.Abs(HeroRabit.lastRabit.transform.position.y - orc.transform.position.y) <= 0.2)
        {
            Debug.Log("Die");
            orc.removeHealth(1);
        }
    }
}
