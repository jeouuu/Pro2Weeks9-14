using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameModeUIManager : MonoBehaviour
{
    //ref from the players ui
    public Image p1Portrait;
    public Image p2Portrait;
    public StartUIManager startUIManager;
    public Sprite[] chefPortraits;


    private void Update()
    {
        ChangePlayerPortrait();
    }

    private void ChangePlayerPortrait()
    {
       p1Portrait.sprite = chefPortraits[startUIManager.p1ChefNum];
       p2Portrait.sprite = chefPortraits[startUIManager.p2ChefNum];

    }


}
