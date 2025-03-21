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

    public UnityEvent OnTheHour;

    private Coroutine clockIsRunning;
    private Coroutine doAnHour;

    private void Start()
    {
        clockIsRunning = StartCoroutine(MoveTheClock());
    }

    void Update()
    {
        //t += Time.deltaTime;

        //if (t > timeAnHourTakes)
        //{
        //    t = 0;
        //    OnTheHour.Invoke();

        //    hour++;
        //    if (hour == 12)
        //    {
        //        hour = 0;
        //    }
        //}
    }

    private IEnumerator MoveTheClock()
    {  
        while (true)
        {
          //  doAnHour = 
          //  yield return StartCoroutine(forTheClockHour());
        }
    }


    private IEnumerator forTheClockHour()
    {
        t = 0;
        while(t < timeAnHourTakes)
        {
            t += Time.deltaTime;
            minuteHand.Rotate(0, 0, -(360 / timeAnHourTakes) * Time.deltaTime);
            hourHand.Rotate(0, 0, -(36 / timeAnHourTakes) * Time.deltaTime);
            yield return null;
        }

        OnTheHour.Invoke();
    }

    public void StopTheClock()
    {
        StopCoroutine(clockIsRunning);
    }

}
