using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {
	public static LevelController current;
	Vector3 startingPosition;

    public UILabel coinsLabel;
    public UILabel applesLabel;
    
    int coins = 0;
    int apples = 0;
    public int applesInLevel = 0;


	void Awake() {
		current = this;
        coinsLabel.text = "0000";
        applesLabel.text = "0/" + applesInLevel;
	}

	public void setStartPosition(Vector3 pos) {
		this.startingPosition = pos;
	}
	public void onRabitDeath(HeroRabit rabit) {
		//При смерті кролика повертаємо на початкову позицію
		rabit.transform.position = this.startingPosition;
	}

    public void addCoins(int n) {
        coins = coins + n;
        string temp = coins.ToString();
        string label = "0000";
        if (temp.Length < 4)
        {
            label = label.Substring(0, label.Length - temp.Length) + temp;
        }
        else {
            coinsLabel.text = coins.ToString();
        }
        coinsLabel.text = label;
    }

    public void addApples(int n) {
        apples = apples + n;
        applesLabel.text = apples.ToString() + "/" + applesInLevel.ToString();
    }
}