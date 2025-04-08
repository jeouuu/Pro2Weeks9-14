using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodItem : MonoBehaviour
{
    private SpriteRenderer sr;
    public bool playerInRange = false;
    public float pickUpRange = 1f;

    //ref player
    public  GameObject p1;
    private Player p1Script;
    public  GameObject p2;
    private Player2 p2Script;

    //ref the game mode ui
    public GameModeUIManager gameModeUIManager;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        p1Script = p1.GetComponent<Player>();
        p2Script = p2.GetComponent<Player2>();
    }

    private void Update()
    {
        if(Player1InRangeDetection() || Player2InRangeDetection())
        {
            sr.color = Color.gray;
        } else
        {
            sr.color = Color.white;
        }
    }

    private bool Player1InRangeDetection()
    {
        float distance = Vector2.Distance(transform.position, p1.transform.position);

        if (distance < pickUpRange)
        {
            p1Script.canPick = true;
            gameModeUIManager.p1PickedFoodSprite = sr.sprite;
            return true;
        } else
        {
            p1Script.canPick = false;
            return false;
        }
    }

    private bool Player2InRangeDetection()
    {
        float distance = Vector2.Distance(transform.position, p2.transform.position);

        if (distance < pickUpRange)
        {
            p2Script.canPick = true;
            gameModeUIManager.p2PickedFoodSprite = sr.sprite;
            return true;
        } else
        {
            p2Script.canPick = false;
            return false;
        }
    }

    public void assingPickedFoodSprite()
    {

    }
}
