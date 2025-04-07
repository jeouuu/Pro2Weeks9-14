using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Player : MonoBehaviour
{
    //ref the sprite renderer and animator
    public StartUIManager startUIManager;
    private SpriteRenderer sr;
    public Image chosenChef;
    private Animator chefAnimator;

    //var for player's movement
    public float speed = 5f;
    public float friction = 5f;
    private Vector2 velocity = Vector2.zero;


    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        chefAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        ChangeSprite();
        Move();
    }

    private void Move()
    {
        //check which key is being pressed, then change the velocity(direction) corresspondingly so it is moving in different dirction
        //use else if to check each of them in a order, to prevent diagonal movement.
        //left & right
        if(Input.GetKey(KeyCode.A))
        {
            velocity.x = -speed;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            velocity.x = speed;
        }
        //up & down
        else if (Input.GetKey(KeyCode.S))
        {
            velocity.y = -speed;
        }
        else if (Input.GetKey(KeyCode.W))
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
        chefAnimator.SetInteger("chooseChefNum", startUIManager.p1ChefNum);    
    }
}
