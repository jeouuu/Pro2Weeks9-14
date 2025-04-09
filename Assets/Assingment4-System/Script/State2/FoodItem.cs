using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
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

    //var for the throwing
    public float moveSpeed = 5f;
    private bool isFlying = false;
    public Vector2 moveDirection;

    //var for hit mechanic
    public float hitOffset = 1f;
    public GameObject throwBy;

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
        } 
        else
        {
            sr.color = Color.white;
        }

        if(isFlying)
        {
            //DON"T FORGET TO SET THE SCALE BACK TO ITS ORIGINAL SCALE, then move the food in the corresponding direction
            transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            transform.position += (Vector3)moveDirection * moveSpeed * Time.deltaTime;
            //check if the food is close to the pllayer
            CheckForHit();
        }
    }

    private void CheckForHit()
    {  
        //if it is overlaping(close enought with offset) then it is hit
        if (throwBy == p1)
        {
            float distance2 = Vector2.Distance(transform.position, p2.transform.position);
            if (distance2 < hitOffset)
            {
                p2.GetComponent<Player2>().getHit = true;
                gameModeUIManager.hitFood2 = sr.sprite;
                OnHit(p2);
            }
        }
        else if(throwBy == p2)
        {
            float distance1 = Vector2.Distance(transform.position, p1.transform.position);

            if (distance1 < hitOffset)
            {
                p1.GetComponent<Player>().getHit = true;
                gameModeUIManager.hitFood1 = sr.sprite;
                OnHit(p1);
            }
        }         
    }

    private void OnHit(GameObject player)
    {
        Debug.Log("food hit" +  player);
        transform.localScale = Vector3.zero;
        Destroy(gameObject,1);
    }

    public void StartThrow(Vector2 throwDir)
    {
        //unparent it from the player
        moveDirection = throwDir;
        isFlying = true;
    }

    private bool Player1InRangeDetection()
    {
        float distance = Vector2.Distance(transform.position, p1.transform.position);

        if (distance < pickUpRange)
        {
            p1Script.canPick = true;
            gameModeUIManager.p1PickedFoodSprite = sr.sprite;
            p1Script.heldFood = this.gameObject;
            return true;
        } else 
        {
            if (p1Script.heldFood == this.gameObject)
            {
                p1Script.heldFood = null;
            }
                
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
            p2Script.heldFood = this.gameObject;
            return true;
        } else
        {
            if (p2Script.heldFood == this.gameObject)
            {
                p2Script.heldFood = null;
            }
            p2Script.canPick = false;
            return false;
        }
    }
}
