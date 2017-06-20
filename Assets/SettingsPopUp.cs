using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsPopUp : MonoBehaviour {
    public MyButton backgroundButton;
    public MyButton closeButton;
    public MyButton musicButton;
    public MyButton soundButton;

    public Sprite soundOn;
    public Sprite soundOff;
    public Sprite musicOn;
    public Sprite musicOff;

	// Use this for initialization
	void Start () {
        closeButton.signalOnClick.AddListener(this.closePopUp);
        backgroundButton.signalOnClick.AddListener(this.closePopUp);

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void closePopUp() {
        Destroy(this.gameObject);
    }
}
