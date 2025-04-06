using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StartUIManager : MonoBehaviour
{
    //ref from player selection
    public Image p1Image;
    public Image p2Image;
    public TMP_Dropdown p1ChefOptions;
    public TMP_Dropdown p2ChefOptions;

    //ref from the chef animations
    public Animator chefAnimator1; 
    public Animator chefAnimator2; 

    //ref the gameStateManager
    public GameStateManager gameStateManager;

    private void Start()
    {
        //set the default image to the first option from dropdown
        p1Image.sprite = p1ChefOptions.options[0].image;
        p1Image.sprite = p2ChefOptions.options[0].image;
    }

    public void P1ChooseChef(int index)
    {
        //change the player image based on the player's selection
        p1Image.sprite = p1ChefOptions.options[index].image;
        chefAnimator1.SetInteger("chooseChefNum",index);
    }

    public void P2ChooseChef(int index)
    {
        //change the player image based on the player's selection
        p2Image.sprite = p2ChefOptions.options[index].image;
        chefAnimator2.SetInteger("chooseChefNum", index);
    }


    public void PlayButton()
    {
        //when this button is pressed start the game by:
        //change the gameState = 1
        //tell the gameStateManager 
        gameStateManager.gameState = 1;
    }
}
