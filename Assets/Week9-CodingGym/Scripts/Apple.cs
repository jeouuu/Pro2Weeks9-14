using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    SpriteRenderer sr;
    public AnimationCurve curve;
    public float t = 0f;
    public float growSpeed = 5f;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public void ChangeColor()
    {
        sr.color = Random.ColorHSV();
    }
    public void AppleGrow()
    {
        t += Time.deltaTime * growSpeed;
        if(t > 1)
        {
            t = 0;
        }

        transform.localScale += Vector3.one * curve.Evaluate(t);
    }
}
