using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpGrower : MonoBehaviour
{
    public AnimationCurve curve;
    public float minSize = 0f;
    public float maxSize = 1f;
    public float t;
    public bool startGrow;

    private void Update()
    {

        if(startGrow)
        { 
            Grow();
        }
    }
    public  void StartGrow()
    {
        startGrow = true;
        t = 0;
    }

    private void Grow()
    {
        if (t < 1)
        {
            t += Time.deltaTime;
        } else
        {
            startGrow = false;
        }


        transform.localScale = Vector3.one * maxSize * curve.Evaluate(t);
    }

}
