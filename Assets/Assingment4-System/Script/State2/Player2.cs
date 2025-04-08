using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class Player2 : MonoBehaviour
{
    //same player script as player 1, with different player's input

    //ref the sprite renderer and animator
    public StartUIManager startUIManager;
    private SpriteRenderer sr;
    public Image chosenChef;
    public Animator chefAnimator;

    //var for player's movement
    public float speed = 5f;
    public float friction = 5f;
    private Vector2 velocity = Vector2.zero;

    //var for pick up 
    public bool canPick = false;
    public bool hadPicked = false;
    public GameObject heldFood;
    public UnityEvent onPick;

    //ref and var for the throw direction
    public GameObject arrowRotator;
    public float rotateSpeed;
    private float originalSpeed;
    private Vector2 throwDir;
    public UnityEvent onThrow;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        chefAnimator = GetComponent<Animator>();
        originalSpeed = speed;
    }

    private void Update()
    {
        ChangeSprite();
        Move();
        Pick();
        Throw();      
    }

    private void Throw()
    {
        if (hadPicked)
        {
            if (Input.GetKey(KeyCode.Return))
            {
                //freeze palyer movement
                speed = 0;
                arrowRotator.SetActive(true);
                if (Input.GetKey(KeyCode.H))
                {
                    //rotate the arrow upward                 
                    arrowRotator.transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);

                } else if (Input.GetKey(KeyCode.N))
                {
                    //rotate the arrow downward
                    arrowRotator.transform.Rotate(0, 0, -rotateSpeed * Time.deltaTime);
                } else if (Input.GetKey(KeyCode.B) || Input.GetKey(KeyCode.M))
                {
                    //throw the food
                    onThrow.Invoke();
                }
            } else
            {
                //if we are not holding space key hide arrow and restore speed
                arrowRotator.SetActive(false);
                speed = originalSpeed;
            }
        } else
        {
            //if we are not holding food do the following as a default state
            arrowRotator.SetActive(false);
            speed = originalSpeed;
        }
    }
    public void ThrowFood()
    {
        if (heldFood != null)
        {
            // Unparent the food so it's no longer attached to the player
            heldFood.transform.parent = null;

            // Start the throwing action on the food item
            throwDir = arrowRotator.transform.right;
            throwDir.Normalize();
            heldFood.GetComponent<FoodItem>().StartThrow(throwDir);

            // After throwing, reset the held food state
            hadPicked = false;
            heldFood = null;
        }
    }

    public void HoldFood(GameObject food)
    {
        food.transform.SetParent(transform);
        food.transform.localScale = Vector3.zero;
    }

    private void Pick()
    {
        if (canPick && Input.GetKeyDown(KeyCode.Return) && !hadPicked)
        {
            hadPicked = true;
            canPick = false;
            onPick.Invoke();

            if (heldFood != null)
            {
                HoldFood(heldFood);
            }
        }
    }

    private void Move()
    {
        //check which key is being pressed, then change the velocity(direction) corresspondingly so it is moving in different dirction
        //use else if to check each of them in a order, to prevent diagonal movement.
        //left & right
        if (Input.GetKey(KeyCode.B))
        {
            velocity.x = -speed;
        } else if (Input.GetKey(KeyCode.M))
        {
            velocity.x = speed;
        }
          //up & down
          else if (Input.GetKey(KeyCode.N))
        {
            velocity.y = -speed;
        } else if (Input.GetKey(KeyCode.H))
        {
            velocity.y = speed;
        } else
        {
            //use larp to lerp velocity slowly down to 0 with friction
            velocity.y = Mathf.Lerp(velocity.y, 0, friction * Time.deltaTime);
            velocity.x = Mathf.Lerp(velocity.x, 0, friction * Time.deltaTime);
        }

        gameObject.transform.Translate(velocity * Time.deltaTime);
    }

    private void ChangeSprite()
    {
        //change the sprite based on player selection at the main menu
        sr.sprite = chosenChef.sprite;
        //then play the corresponding animation
        chefAnimator.SetInteger("chooseChefNum", startUIManager.p2ChefNum);
    }

}
