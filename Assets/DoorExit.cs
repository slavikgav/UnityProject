using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorExit : MonoBehaviour
{
    public GameObject winPopUpPrefab;

    void OnTriggerEnter2D(Collider2D collider)
    {
        //if(!this.hideAnimation) {
        HeroRabit rabit = collider.GetComponent<HeroRabit>();
        Debug.Log("Here DOOR LEVEL 1");
        if (rabit != null)
        {
            showWinPopUp();
        }
    }

    void showWinPopUp()
    {
        //Do something
        GameObject parent = UICamera.first.transform.parent.gameObject;
        Debug.Log("PARENT NAME: " + parent.name);
        //Prefab
        GameObject obj = NGUITools.AddChild(parent, winPopUpPrefab);
        WinPopUp popup = obj.GetComponent<WinPopUp>();
        Debug.Log("END OF SHOW " + parent.name);
    }
}
