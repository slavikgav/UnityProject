using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroRabit : MonoBehaviour {

	public float MaxJumpTime = 2f;
    public float JumpSpeed = 2f;
	public float speed = 1;
	Rigidbody2D myBody = null;

	private bool _isGrounded = false;
    private bool _jumpActive = false;
    private float _jumpTime = 0f;

    Transform heroParent = null;
	// Use this for initialization
	void Start () {
	     myBody = this.GetComponent<Rigidbody2D> ();
	     LevelController.current.setStartPosition (transform.position);	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Update is called once per frame
	void FixedUpdate () {
	//[-1, 1]
		float value = Input.GetAxis ("Horizontal");
		if (Mathf.Abs (value) > 0) {
			Vector2 vel = myBody.velocity;
			vel.x = value * speed;				
			myBody.velocity = vel;			
		}
		SpriteRenderer sr = GetComponent<SpriteRenderer>();
		if(value < 0) {
			sr.flipX = true;
		} else if(value > 0) {
			sr.flipX = false;
		}
		if (Mathf.Abs(value) > 0){
            GetComponent<Animator>().SetBool("Run", true);
       	}else{
            GetComponent<Animator>().SetBool("Run", false);
        }

		

		Vector3 from = transform.position + Vector3.up * 0.3f;
        Vector3 to = transform.position + Vector3.down * 0.1f;
        int layer_id = 1 << LayerMask.NameToLayer("Ground");
        //Перевіряємо чи проходить лінія через Collider з шаром Ground
        RaycastHit2D hit = Physics2D.Linecast(from, to, layer_id);
        MovingPlatform movingPlatform = hit.transform.GetComponent<MovingPlatform > ();
        if (hit)
        {

        	if(hit.transform != null && hit.transform.GetComponent<MovingPlatform>() != null){
				//Приліпаємо до платформи
				Debug.Log("I am here");
				SetNewParent(this.transform, hit.transform);

			} else {
				//Ми в повітрі відліпаємо під платформи
				Debug.Log("Tyt" + hit.transform.GetComponent<MovingPlatform>() + " wow");
				SetNewParent(this.transform, this.heroParent);
			}
            _isGrounded = true;
        }
        else
        {
            _isGrounded = false;
        }
        //Намалювати лінію (для розробника)
        Debug.DrawLine(from, to, Color.red);

        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            this._jumpActive = true;
        }
        if (this._jumpActive)
        {
            //Якщо кнопку ще тримають
            if (Input.GetButton("Jump"))
            {
                this._jumpTime += Time.deltaTime;
                if (this._jumpTime < this.MaxJumpTime)
                {
                    Vector2 vel = myBody.velocity;
                    vel.y = JumpSpeed * (1.0f - _jumpTime / MaxJumpTime);
                    myBody.velocity = vel;
                }
            }
            else
            {
                this._jumpActive = false;
                this._jumpTime = 0;
            }
        }

        if (this._isGrounded)
        {
            GetComponent<Animator>().SetBool("Jump", false);
        }
        else
        {
            GetComponent<Animator>().SetBool("Jump", true);
        }
    }



    static void SetNewParent(Transform obj, Transform new_parent) {
		if(obj.transform.parent != new_parent) {
		//Засікаємо позицію у Глобальних координатах
			Vector3 pos = obj.transform.position;
			//Встановлюємо нового батька
			obj.transform.parent = new_parent;
			//Після зміни батька координати кролика зміняться
			//Оскільки вони тепер відносно іншого об’єкта
			//повертаємо кролика в ті самі глобальні координати
			obj.transform.position = pos;
		}
	}

}



