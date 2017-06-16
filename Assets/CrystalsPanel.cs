using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalsPanel : MonoBehaviour {
    public static CrystalsPanel current = null;
    public List<UI2DSprite> crystalPlace;

    public Sprite crystalNotGet;
    public List<Sprite> crystalColors;
    Dictionary<CrystalColor,bool> obtainedCrystals = new Dictionary<CrystalColor, bool>();
    
    // Use this for initialization
    void Start () {
        current = this;
	}

    void updateCrystalColor(CrystalColor color)
    {
        int crystal_id = (int)color;
        if (obtainedCrystals.ContainsKey(color))
        {
            crystalPlace[crystal_id].sprite2D = crystalColors[crystal_id];
        }
        else
        {
            crystalPlace[crystal_id].sprite2D = crystalNotGet;
        }
    }

    public void addCrystal(CrystalColor color)
    {
        Debug.Log("add crystal");
        obtainedCrystals[color] = true;
        this.updateCrystalColor(color);
    }
}
