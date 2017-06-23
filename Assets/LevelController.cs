﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {
	public static LevelController current;
	Vector3 startingPosition;
    

    public UILabel coinsLabel;
    public UILabel applesLabel;

    
    public static int coins = 0;
    public static int apples = 0;
    public static int applesInLevel = 1;

    public LivesPanel livesPanel;
    public AudioClip backgroundMusic = null;
    public static AudioSource musicSource = null;

    void Awake() {
		current = this;
        if (coinsLabel != null && applesLabel != null)
        {
            coinsLabel.text = "0000";
            applesLabel.text = "0/" + applesInLevel;
        }
        musicSource = gameObject.AddComponent<AudioSource>();
        musicSource.clip = backgroundMusic;
        musicSource.Play();
	}

	public void setStartPosition(Vector3 pos) {
		this.startingPosition = pos;
	}
	public void onRabitDeath(HeroRabit rabit) {
        //After death return rabit on start position
        Debug.Log("STRT POS : " + startingPosition);
        HeroRabit.lastRabit.removeHealth(1);
		rabit.transform.position = this.startingPosition;
	}

    public void addCoins(int n) {
        coins = coins + n;
        string temp = coins.ToString();
        Debug.Log("INTO ADD COINS :"+temp);
        string label = "0000";
        if (temp.Length < 4)
        {
            coinsLabel.text = label.Substring(0, label.Length - temp.Length) + temp;
        }
        else {
            coinsLabel.text = coins.ToString();
        }
        
    }

    public void addApples(int n) {
        apples = apples + n;
        applesLabel.text = apples.ToString() + "/" + applesInLevel.ToString();
    }
}