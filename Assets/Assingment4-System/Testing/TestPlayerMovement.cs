using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerMovement : MonoBehaviour
{
    public Transform player1;
    public Transform player2;

    float speed = 5f; 
     float friction = 5f;
    private float velocityP1 = 0f;


    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            velocityP1 = -speed;
        } else if (Input.GetKey(KeyCode.D))
        {
            velocityP1 = speed;
        } else
        {
            velocityP1 = Mathf.Lerp(velocityP1, 0, friction * Time.deltaTime);

        }

        player1.Translate(new Vector3(velocityP1, 0, 0) * Time.deltaTime);
        player2.Translate(Input.GetAxis("Horizontal2") * Time.deltaTime * 5, 0, 0);
    }
}
