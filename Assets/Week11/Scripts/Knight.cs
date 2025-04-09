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

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            animator.SetTrigger("Attack1");
            canRun = false;
        }

        if (canRun)
        {
            Move();
        } 

    }

    private void Move()
    {
        transform.Translate(Input.GetAxis("Horizontal") * speed * Time.deltaTime ,0,0);
        if(Input.GetAxis("Horizontal") < 0)
        {
            sr.flipX = true;
        }
        else if(Input.GetAxis("Horizontal") > 0)
        {
            sr.flipX = false;
        }

        if(Input.GetAxis("Horizontal") != 0)
        {
            animator.SetBool("isRunning",true);
        } else
        {
            animator.SetBool("isRunning", false);
        }
    }

    private void Attack()
    {
       
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
