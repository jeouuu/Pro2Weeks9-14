using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : MonoBehaviour
{
    public float speed;
    SpriteRenderer sr;
    public Animator animator;

    public bool canRun = false;
    public AudioSource audioSource;

    Vector2 currentPos;
    Vector2 newPos;
    bool moving = false;
    public LineRenderer lr;
    public Vector2[] listOfPoints = new Vector2[2];

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        lr.positionCount = 0;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            animator.SetTrigger("Attack1");
            canRun = false;
        }


        currentPos = transform.position;
        if (Input.GetMouseButtonDown(0))
        {
            newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            moving = true;
        } else
        {
            moving = false;
        }

        if (canRun)
        {
            Move(currentPos, newPos);
        }

        listOfPoints[0] = sr.transform.position;
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            listOfPoints[1] = newPos;
            lr.positionCount++;
            lr.SetPosition(lr.positionCount - 1, newPos);
        }

        if ((Vector2)transform.position == newPos)
        {
            listOfPoints[0] = transform.position;
            lr.positionCount = 0;
        }

    }

    private void Move(Vector2 currentPos, Vector2 newPos)
    {

        Vector2 direction = newPos - currentPos;
        direction.Normalize();

        currentPos += direction * speed * Time.deltaTime;
        transform.position = currentPos;

        if (moving)
        {
            animator.SetBool("isRunning", true);
        } else
        {
            animator.SetBool("isRunning", false);
        }




        //use input to move the player

        //transform.Translate(Input.GetAxis("Horizontal") * speed * Time.deltaTime ,0,0);
        //if(Input.GetAxis("Horizontal") < 0)
        //{
        //    sr.flipX = true;
        //}
        //else if(Input.GetAxis("Horizontal") > 0)
        //{
        //    sr.flipX = false;
        //}

        //if(Input.GetAxis("Horizontal") != 0)
        //{
        //    animator.SetBool("isRunning",true);
        //} else
        //{
        //    animator.SetBool("isRunning", false);
        //}
    }


    public void AttackHasFinished()
    {
        canRun = true;
    }

    public void FootStep()
    {
        audioSource.Play();

    }


}
