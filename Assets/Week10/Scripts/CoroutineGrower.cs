using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineGrower : MonoBehaviour
{
    public AnimationCurve curve;
    public float minSize = 0f;
    public float maxSize = 1f;
    public float t;
    
    public Transform apple;
    public Transform cookie;

    //public void StartGrowing()
    //{
    //    StartCoroutine(Grow());
    //}

    public IEnumerator Grow()
    {
        //make sure both start from zero
        apple.localScale = Vector3.zero;
        cookie.localScale = Vector3.zero;
        transform.localScale = Vector3.zero;

        //grow the tree
        t = 0;
        while (t < 1)
        {
            t += Time.deltaTime;
            transform.localScale = Vector3.one * maxSize * curve.Evaluate(t);
            yield return null;
        }

        //grow the apple
        t = 0;
        while (t < 1)
        {
            t += Time.deltaTime;
            apple.localScale = Vector3.one * maxSize * curve.Evaluate(t);
            yield return null;
        }

        yield return new WaitForSeconds(Random.Range(0.01f,1.5f));
        
        //grow the cookie
        t = 0;
        while (t < 1)
        {
            t += Time.deltaTime;
            cookie.localScale = Vector3.one * maxSize * curve.Evaluate(t);
            yield return null;
        }
    }
}
