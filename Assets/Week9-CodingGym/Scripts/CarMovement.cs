using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public float speed = 1.0f;

    private void Update()
    {
        MoveCar();
    }

    private void MoveCar()
    {
        Vector2 carPos = transform.position;
        carPos.x += speed * Time.deltaTime;

        Vector2 carPosInScreen = Camera.main.WorldToScreenPoint(carPos);
        if(carPosInScreen.x > Screen.width)
        {
            Vector2 fixedPos = new Vector2(Screen.width,Screen.height);
            carPos.x = Camera.main.ScreenToWorldPoint(fixedPos).x;
            speed *= -1;
        }
        if(carPosInScreen.x < 0)
        {
                Vector2 fixedPos = new Vector2(0,0);
                carPos.x = Camera.main.ScreenToWorldPoint(fixedPos).x;
                speed *= -1;
        }

        transform.position = carPos;    
    }
}
