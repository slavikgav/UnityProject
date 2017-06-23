using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorLevel2 : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D collider)
    {
        //if(!this.hideAnimation) {
        HeroRabit rabit = collider.GetComponent<HeroRabit>();
        Debug.Log("Here DOOR LEVEL 2");
        if (rabit != null)
        {
            Debug.Log("LOAD SECOND SCENE, success");
            SceneManager.LoadScene("Level2");
        }
    }
}
