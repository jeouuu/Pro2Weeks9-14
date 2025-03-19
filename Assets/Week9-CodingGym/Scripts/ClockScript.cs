using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ClockScript : MonoBehaviour
{
    public GameObject hourHand;
    public GameObject minuteHand;

    public float hourSpeed = 50f;
    public float minuteSpeed = 10;

    public AudioSource chimeSound;
    public UnityEvent onHour;
    bool passHour = false;

    private void Update()
    {
        RotateHour();
        RotateMinute();

        if (minuteHand.transform.eulerAngles.z > -1  && minuteHand.transform.eulerAngles.z < 1f)
        { 
            passHour = true;
        }
        if (passHour)
        {
            onHour.Invoke();
            passHour = false;
        }
        Debug.Log(passHour);

        
    }

    private void RotateHour()
    {
        hourHand.transform.Rotate(0, 0, -hourSpeed * Time.deltaTime);
    }

    private void RotateMinute()
    {
        minuteHand.transform.Rotate(0, 0, -minuteSpeed * Time.deltaTime);
    }

    public void Chime()
    {
        chimeSound.Play();
    }

}
