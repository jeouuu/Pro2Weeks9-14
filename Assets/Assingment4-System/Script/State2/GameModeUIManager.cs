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

    //ref from the foodslot ui
    public Image p1FoodSlot;
    public Image p2FoodSlot;
    public Sprite p1PickedFoodSprite = null;
    public Sprite p2PickedFoodSprite = null;

    //ref the players
    public Player p1Script;
    public Player2 p2Script;


    private void Update()
    {
        ChangePlayerPortrait();
    }

    private void ChangePlayerPortrait()
    {
       p1Portrait.sprite = chefPortraits[startUIManager.p1ChefNum];
       p2Portrait.sprite = chefPortraits[startUIManager.p2ChefNum];

    }

    public void ChangeFoodSlotFood1()
    {
        p1FoodSlot.sprite = p1PickedFoodSprite;
    }   
    public void ChangeFoodSlotFood2()
    {
        p2FoodSlot.sprite= p2PickedFoodSprite;
    }

    public void EmptyFoodSlot1()
    {
        p1FoodSlot.sprite = null;
    }
    public void EmptyFoodSlot2()
    {
        p2FoodSlot.sprite = null;
    }


}
