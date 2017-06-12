using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrot : Collectable {
    public float speed = 0.000001f;
    float direction = 0;

    void Update()
    {
        Vector3 pos = this.transform.position;
        pos.x += Time.deltaTime + direction * 0.1f;
        this.transform.position = pos;
    }

    public void launch(float direction) {
        this.direction = direction;
        if(direction == -1)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        StartCoroutine(destroyLater());
    }

    IEnumerator destroyLater()
    {
        yield return new WaitForSeconds(2f);
        Destroy(this.gameObject);
    }

    protected override void OnRabitHit(HeroRabit rabit)
    {
        //Rabbit must die
        rabit.catchOrksHit();
        this.CollectedHide();
    }
}
