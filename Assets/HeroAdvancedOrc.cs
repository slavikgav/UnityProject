using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroAdvancedOrc : MonoBehaviour
{
    public GameObject prefabCarrot;
    Rigidbody2D orcBody;
    public float speed = 2;

    public Vector3 pointA;
    public Vector3 pointB;

    float patrolDistance = 6;
    int health = 1;

    float carrotDelay = 3;
    float startedCarrot = 0;

    public enum Mode
    {
        goToA,
        goToB,
        Attack,
        Die
    }

    Mode mode = Mode.goToB;

    // Use this for initialization
    void Start()
    {
        pointA = this.transform.position;
        pointB = pointA;

        if (patrolDistance < 0)
        {
            pointA.x += patrolDistance;
        }
        else
        {
            pointB.x += patrolDistance;
        }
        orcBody = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log("Mode : " + mode);
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

    float DirectionToRabbit()
    {
        if (transform.position.x < HeroRabit.lastRabit.transform.position.x && transform.position.x <= pointB.x)
        {
            return 1;
        }
        else if (transform.position.x > HeroRabit.lastRabit.transform.position.x && transform.position.x >= pointA.x)
        {
            return -1;
        }
        return 0;
    }


    float getDirection()
    {
        if (mode == Mode.Die)
        {
            return 0; //Die
        }

        Vector3 my_pos = this.transform.position;
        Vector3 rabit_pos = HeroRabit.lastRabit.transform.position;

        if (mode == Mode.Attack)
            launchCarrot();

        if (isRabitInPatrolZone())
        {
            mode = Mode.Attack;
            GetComponent<SpriteRenderer>().flipX = DirectionToRabbit() < 0 ? false : true;
            return 0;
        }
        if (mode == Mode.goToB)
        {
            if (Mathf.Abs(my_pos.x - rabit_pos.x) > patrolDistance)
                GetComponent<Animator>().SetBool("Attack", false);
            //  Debug.Log("go to B");
            if (my_pos.x >= pointB.x)
            {
                mode = Mode.goToA;
                return -1; //Move left
            }
            return 1;
        }
        else if (mode == Mode.goToA)
        {
            if (Mathf.Abs(my_pos.x - rabit_pos.x) > patrolDistance)
                GetComponent<Animator>().SetBool("Attack", false);
            //   Debug.Log("go to A");
            if (my_pos.x <= pointA.x)
            {
                mode = Mode.goToB;
                return 1;//Move right
            }
            return -1;
        }
        else if (mode == Mode.Attack)
        {
            //  Debug.Log("Attack mode");
            if (!isRabitInPatrolZone())
                mode = Mode.goToB;
            else
                launchCarrot();

        }
        return 0; //No movement
    }

    bool isRabitInPatrolZone()
    {
        return ((HeroRabit.lastRabit.transform.position.x >= pointA.x) && (HeroRabit.lastRabit.transform.position.x <= pointB.x));
    }

    public void attack()
    {
        GetComponent<Animator>().SetBool("Run", false);
        GetComponent<Animator>().SetBool("Attack", true);
    }

    void launchCarrot() {
        if (Mathf.Abs(this.transform.position.x - HeroRabit.lastRabit.transform.position.x) < patrolDistance)
        {
            if (Time.time - startedCarrot > carrotDelay)
            {
                GameObject obj = GameObject.Instantiate(this.prefabCarrot);
                obj.transform.position = this.transform.position + Vector3.up * 0.5f;
                Carrot carrot = obj.GetComponent<Carrot>();
                if (HeroRabit.lastRabit.transform.position.x < this.transform.position.x)
                {
                    carrot.launch(-1);
                } else if (HeroRabit.lastRabit.transform.position.x > this.transform.position.x){
                    carrot.launch(1);
                }
                
                startedCarrot = Time.time;
            }
        }
        
    }

    public void removeHealth(int number)
    {
        this.health -= number;
        if (this.health < 0)
            this.health = 0;
        this.onHealthChange();
    }

    void onHealthChange()
    {
        if (this.health == 0)
        {
            int childCount = this.transform.childCount;
            for (int i = 0; i < childCount; i++)
                Destroy(this.transform.GetChild(i).gameObject);
            StartCoroutine(die(1f));
        }
    }

    IEnumerator die(float duration)
    {
        Debug.Log("die triggered");
        mode = Mode.Die;
        GetComponent<Animator>().SetBool("Run", false);
        GetComponent<Animator>().SetBool("Die", true);
        //isDead = true;
        yield return new WaitForSeconds(duration);
        Debug.Log("orc dies now");
        Destroy(this.gameObject);
    }

    public bool isDead()
    {
        return health == 0;
    }
}
