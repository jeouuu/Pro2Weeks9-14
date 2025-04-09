using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowFoods : MonoBehaviour
{
    public GameObject food1;
    public GameObject food2;
    public GameObject food3;
    Vector2 currentScale1;
    Vector2 currentScale2;
    Vector2 currentScale3;

    public AnimationCurve curve;
    [Range(0,1)] public float t;

    private void Start()
    {
        currentScale1 = food1.transform.localScale;
        currentScale2 = food2.transform.localScale;
        currentScale3 = food3.transform.localScale;
        StartCoroutine(GrowFood());
    }

    private IEnumerator GrowFood()
    {
        food1.transform.localScale = Vector3.zero;
        food2.transform.localScale = Vector3.zero;
        food3.transform.localScale = Vector3.zero;

        t = 0;
        while (t < 1)
        {
            t += Time.deltaTime;
            food1.transform.localScale = currentScale1 * curve.Evaluate(t) ;  
            yield return null;
        }

        t = 0;
        while (t < 1)
        {
            t += Time.deltaTime;
            food2.transform.localScale = currentScale2 * curve.Evaluate(t);
            yield return null;
        }

        t = 0;
        while (t < 1)
        {
            t += Time.deltaTime;
            food3.transform.localScale = currentScale3 * curve.Evaluate(t);
            yield return null;
        }

    }
}
