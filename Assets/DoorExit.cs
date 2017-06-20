using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorExit : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D collider)
    {
        //if(!this.hideAnimation) {
        HeroRabit rabit = collider.GetComponent<HeroRabit>();
        Debug.Log("Here DOOR Exit");
        if (rabit != null)
        {
            SceneManager.LoadScene("ChooseLevelScene");
        }
    }
}
