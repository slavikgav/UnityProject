using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroOrc : MonoBehaviour {

    Rigidbody2D orcBody;
    public float speed = 2;


    public Vector3 pointA;
    public Vector3 pointB;

    float patrolDistance = 5;

    public enum Mode {
        goToA,
        goToB,
        Attack,
        Die
    }

    Mode mode = Mode.goToB;

    // Use this for initialization
    void Start() {
        pointA = this.transform.position;
        pointB = pointA;

        if (patrolDistance < 0)
        {
            pointA.x += patrolDistance;
        }
        else {
            pointB.x += patrolDistance;
        }
        orcBody = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate() {
        float value = this.getDirection();

        if (Mathf.Abs(value) > 0)
        {
            Vector2 vel = orcBody.velocity;
            vel.x = value * speed;
            orcBody.velocity = vel;
        }
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (value < 0)
        {
            sr.flipX = false;
        }
        else if (value > 0)
        {
            sr.flipX = true;
        }
        if (Mathf.Abs(value) > 0)
        {
            GetComponent<Animator>().SetBool("Run", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("Run", false);
        }
    }

    float getDirection() {
        if (mode == Mode.Die) {
            return 0; //Die
        }

        Vector3 my_pos = this.transform.position;
        Vector3 rabit_pos = HeroRabit.lastRabit.transform.position;

        if (mode == Mode.goToB)
        {
            if (my_pos.x >= pointB.x)
            {
                if (isRabitInPatrolZone())
                    mode = Mode.Attack;
                Debug.Log("move left");
                mode = Mode.goToA;
                return -1; //Move left
            }
            return 1;
        }
        else if (mode == Mode.goToA)
        {
            if (my_pos.x <= pointA.x)
            {
                if (isRabitInPatrolZone())
                    mode = Mode.Attack;
                Debug.Log("move right " + isRabitInPatrolZone());
                mode = Mode.goToB;
                return 1;//Move right
            }
            return -1;
        }
        else if (mode == Mode.Attack) {
            Debug.Log("Attack mode");
            if (my_pos.x > HeroRabit.lastRabit.transform.position.x)
                return -1;
            else if (my_pos.x < HeroRabit.lastRabit.transform.position.x)
                return 1;
            else if (!isRabitInPatrolZone())
                mode = Mode.goToB;
        }
        return 0; //No movement
    }

    bool isRabitInPatrolZone() {
        Debug.Log("Here" + mode);
        return ((HeroRabit.lastRabit.transform.position.x >= pointA.x)&&(HeroRabit.lastRabit.transform.position.x <= pointB.x));
    }
}
