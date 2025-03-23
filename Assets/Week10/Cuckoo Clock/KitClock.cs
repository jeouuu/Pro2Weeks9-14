using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KitClock : MonoBehaviour
{
    public Transform hourHand;
    public Transform minuteHand;

    public float timeAnHourTakes = 5;
    public float t;
    public int hour = 0;

    public UnityEvent<int> OnTheHour;

    private Coroutine clockIsRunning;
    private IEnumerator handsAreMoving;

    private void Start()
    {
        clockIsRunning = StartCoroutine(MakeTheClockRun());
    }

    IEnumerator MakeTheClockRun()
    {
        hour = 0;
        while (true)
        {
            handsAreMoving = MoveTheHandForAnHour();
            yield return StartCoroutine(handsAreMoving);
        }
 
    }
    IEnumerator MoveTheHandForAnHour()
    {
        t = 0;
        while(t< timeAnHourTakes)
        {
            t += Time.deltaTime;
            minuteHand.transform.Rotate(0,0,-(360/timeAnHourTakes)*Time.deltaTime);
            hourHand.transform.Rotate(0,0,-(30/timeAnHourTakes)*Time.deltaTime);
            yield return null;
        }
        hour++;
        if(hour == 13)
        {
            hour = 1;
        } 
        OnTheHour.Invoke (hour);
    }

    public void StopTheClock()
    {
        if(clockIsRunning != null)
        {
            StopCoroutine(clockIsRunning);
        }  
        if(handsAreMoving != null)
        {
            StopCoroutine(handsAreMoving);
        }      
    }

}
