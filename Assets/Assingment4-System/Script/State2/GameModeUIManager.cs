using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameModeUIManager : MonoBehaviour
{
    //ref the game state manager
    public GameStateManager gameStateManager;

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

    //var for timer
    public Slider timerSlider;
    public float gameTime;

    //var and ref for healthbar
    public Image[] healthBar1;
    public Image[] healthBar2;
    public Sprite grayHeart;
    private int p1CurrentHealth = 4 ;
    private int p2CurrentHealth = 4;
    public Sprite hitFood1;
    public Sprite hitFood2;

    //var for end game trigger
    public bool timeEnd = false;
    public bool p1Win = false;
    public bool p2Win = false;


    private void Start()
    {
        gameTime = timerSlider.maxValue;
    }


    private void Update()
    {
        ChangePlayerPortrait();
        //start timer when game state = 2
        if(gameStateManager.gameState == 2)
        {
            Timer();
        }


        if(gameTime <= 0)
        {
            gameTime = 0;
            gameStateManager.gameState = 3;
            timeEnd = true;
        }
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

    public void TakeDamage1()
    {
        p1Script.getHit = false;

        //if got hit by egg or bread, -1 health, milk or cheese -2,  otherwise -3 health
        if (hitFood1.name == "egg" || hitFood1.name == "bread")
        {
            p1CurrentHealth--;
        } else if (hitFood1.name == "milk" || hitFood1.name == "cheese")
        {
            p1CurrentHealth -= 2;
        } else if (hitFood1.name == "broccoli")
        {
            p1CurrentHealth -= 3;
        }

        //change the heart sprite based on current health
        if (p1CurrentHealth > 0)
        {
            if (p1CurrentHealth == 1)
            {
                healthBar1[1].sprite = grayHeart;
                healthBar1[2].sprite = grayHeart;
                healthBar1[3].sprite = grayHeart;
            } else if (p1CurrentHealth == 2)
            {
                healthBar1[2].sprite = grayHeart;
                healthBar1[3].sprite = grayHeart;
            } else if (p1CurrentHealth == 3)
            {
                healthBar1[3].sprite = grayHeart;
            }
        }
        if(p1CurrentHealth == 0)
        {
            p2Win = true;
            gameStateManager.gameState = 3;
        }
    }   
    
    public void TakeDamage2()
    {
        p2Script.getHit = false;
        Debug.Log("hit by" + hitFood2);
        //if got hit by egg or bread, -1 health, milk or cheese -2,  otherwise -3 health
        if (hitFood2.name == "egg" || hitFood2.name == "bread")
        {
            p2CurrentHealth--;
        }else if(hitFood2.name == "milk" || hitFood2.name == "cheese")
        {
            p2CurrentHealth -= 2;
        }else if(hitFood2.name == "broccoli" )
        {
            p2CurrentHealth -= 3;
        }
        
        //change the heart sprite based on current health
        if(p2CurrentHealth > 0)
        {
            if(p2CurrentHealth == 1)
            {
                healthBar2[1].sprite = grayHeart;
                healthBar2[2].sprite = grayHeart;
                healthBar2[3].sprite = grayHeart;
            }
            else if(p2CurrentHealth == 2)
            {
                healthBar2[2].sprite = grayHeart;
                healthBar2[3].sprite = grayHeart;
            }
            else if(p2CurrentHealth == 3)
            {
                healthBar2[3].sprite = grayHeart;
            }
        }
        if(p2CurrentHealth == 0)
        {
            p1Win = true;
            gameStateManager.gameState = 3;
        }
    }

    private void Timer()
    {
        gameTime -= Time.deltaTime;
        timerSlider.value = gameTime;
    }


}
