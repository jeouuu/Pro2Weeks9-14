using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TrafficLightController : MonoBehaviour
{
    public UnityEvent onMouseClickGo;
    public UnityEvent onMouseClickStop;

    public SpriteRenderer greenLight;
    public SpriteRenderer redLight;

    public GameObject car;
    float lastSpeed = 5;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            onMouseClickGo.Invoke();
        }
        if(Input.GetMouseButtonDown(1))
        {
            onMouseClickStop.Invoke();
        }
        Debug.Log(lastSpeed);
    }

    public void Go()
    {
        //turn green light && go the car
        greenLight.color = Color.green;
        redLight.color = Color.gray;
        CarMovement movementScript = car.GetComponent<CarMovement>();
        if (movementScript != null)
        {
            movementScript.speed = lastSpeed;
            
        }
    }

    public void Stop()
    {
        //turn red light && stop the car
        redLight.color = Color.red;
        greenLight.color = Color.gray;
        CarMovement movementScript = car.GetComponent<CarMovement>();
        if (movementScript != null)
        {
            lastSpeed = movementScript.speed;
            movementScript.speed = 0;
        }
    }
}
