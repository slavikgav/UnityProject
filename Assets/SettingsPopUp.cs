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

    bool _musicOn = true;
    bool _soundOn = true;
    



	// Use this for initialization
	void Start () {
        closeButton.signalOnClick.AddListener(this.closePopUp);
        backgroundButton.signalOnClick.AddListener(this.closePopUp);
        musicButton.signalOnClick.AddListener(this.musicManager);
        soundButton.signalOnClick.AddListener(this.soundManager);

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void closePopUp() {
        Destroy(this.gameObject);
    }

    void musicManager() {
        if (_musicOn)
        {
            Debug.Log("HERRE MUSiC OFF");
            musicButton.GetComponent<UI2DSprite>().sprite2D = musicOff;
            musicButton.GetComponent<UIButton>().normalSprite2D = musicOff;
            LevelController.musicSource.Pause();
            _musicOn = false;
        }
        else
        {
            Debug.Log("HERE MUSIC ON");
            musicButton.GetComponent<UI2DSprite>().sprite2D = musicOn;
            musicButton.GetComponent<UIButton>().normalSprite2D = musicOn;
            LevelController.musicSource.UnPause();
            _musicOn = true;
        }
    }

    void soundManager() {
        if (_soundOn)
        {
            Debug.Log("HERRE MUSiC OFF");
            soundButton.GetComponent<UI2DSprite>().sprite2D = soundOff;
            soundButton.GetComponent<UIButton>().normalSprite2D = soundOff;
            HeroRabit.soundOff = true;
            HeroOrc.soundOff = true;
            HeroAdvancedOrc.soundOff = true;
            _soundOn = false;
        }
        else
        {
            Debug.Log("HERE MUSIC ON");
            soundButton.GetComponent<UI2DSprite>().sprite2D = soundOn;
            soundButton.GetComponent<UIButton>().normalSprite2D = soundOn;
            HeroRabit.soundOff = false;
            HeroOrc.soundOff = false;
            HeroAdvancedOrc.soundOff = false;
            _soundOn = true;
        }
    }
}
