using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorLevel1 : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D collider)
    {
        //if(!this.hideAnimation) {
        HeroRabit rabit = collider.GetComponent<HeroRabit>();
        Debug.Log("Here DOOR LEVEL 1");
        if (rabit != null)
        {
            SceneManager.LoadScene("Level1");
        }
        //}
    }
}
