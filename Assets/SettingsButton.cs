using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsButton : MonoBehaviour {

    public MyButton settingsButton;
    public GameObject settingsPrefab;

    void Start()
    {
        settingsButton.signalOnClick.AddListener(this.showSettings);
    }
    void showSettings()
    {
        //Do something
        GameObject parent = UICamera.first.transform.parent.gameObject;
        Debug.Log("PARENT NAME: "+ parent.name);
        //Prefab
        GameObject obj = NGUITools.AddChild(parent, settingsPrefab);
        SettingsPopUp popup = obj.GetComponent<SettingsPopUp>();
    }
}
