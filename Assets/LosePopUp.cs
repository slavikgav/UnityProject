using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class LosePopUp : MonoBehaviour
{
    public MyButton backgroundButton;
    public MyButton closeButton;
    public MyButton restartButton;
    public MyButton mainMenuButton;

    public List<UI2DSprite> crystalPlace;

    public Sprite crystalNotGet;
    public List<Sprite> crystalColors;
   
    public AudioClip loseMusic = null;
    public static AudioSource loseSource = null;

    // Use this for initialization
    void Start()
    {
        closeButton.signalOnClick.AddListener(this.closePopUp);
        backgroundButton.signalOnClick.AddListener(this.closePopUp);
        restartButton.signalOnClick.AddListener(this.restartLevel);
        mainMenuButton.signalOnClick.AddListener(this.loadMainMenuScene);
        showObtainedCrystals();

        loseSource = gameObject.AddComponent<AudioSource>();
        loseSource.clip = loseMusic;
        loseSource.Play();

    }

    // Update is called once per frame
    void Update()
    {

    }


    void closePopUp()
    {
        Destroy(this.gameObject);
    }

    void restartLevel()
    {
        Debug.Log("RESTART BUTTON");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void loadMainMenuScene()
    {
        Debug.Log("NEXT BUTTON");
        SceneManager.LoadScene("MainMenu");
    }


    public void showObtainedCrystals()
    {
        int crystal_id = 0;
        for (int i = 0; i < CrystalsPanel.obtainedCrystals.Count; i++)
        {
            crystal_id = i;
            Debug.Log(CrystalsPanel.obtainedCrystals.Count);
            if (CrystalsPanel.obtainedCrystals[CrystalsPanel.obtainedCrystals.Keys.ToList()[i]])
            {
                crystalPlace[crystal_id].sprite2D = crystalColors[crystal_id];
            }
            else
            {
                crystalPlace[crystal_id].sprite2D = crystalNotGet;
            }
        }

        Debug.Log("FINISHED CRYSTALS");
    }
}
