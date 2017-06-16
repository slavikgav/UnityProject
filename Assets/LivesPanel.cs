using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesPanel : MonoBehaviour {
    public static LivesPanel current = null;
    public List<UI2DSprite> hearts;

    public Sprite fullLive;
    public Sprite noLive;

    void Awake()
    {
        current = this;
    }

    public void setLivesQuantity(int lives)
    {
        for (int i = 0; i < 3; i++)
        {
            if (i < lives)
            {
                hearts[i].sprite2D = this.fullLive;
            }
            else
            {
                hearts[i].sprite2D = this.noLive;
            }
        }
    }
}
