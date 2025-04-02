using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAction : MonoBehaviour
{
    public float speed;
    public GameObject player2;
    public Vector2 targetPos;
    public Vector2 originalPos;

    public AnimationCurve curve;
    public AnimationCurve growCurve;
    [Range(0, 1)] public float t;

    public Button attackButton1;
    public Button attackButton2;

    private void Start()
    {
        originalPos = transform.position;
        targetPos = player2.transform.position;
    }

    public void StartAttack()
    {
        StartCoroutine(Attack());
    }

    private IEnumerator Attack()
    {
        attackButton1.interactable = false;
        attackButton2.interactable = false;

        //movement 1
        t = 0;
        while(t < 1)
        {
            t += Time.deltaTime;
            transform.position = Vector2.Lerp(transform.position, targetPos, curve.Evaluate(t) * speed);
            yield return null;
        }

        //movement 2
        t = 0;
        while (t < 1)
        {
            t += Time.deltaTime;
            transform.localScale = Vector2.one * growCurve.Evaluate(t);
            yield return null;
        }

        //movement 3
        t = 0;
        while (t < 1)
        {
            t += Time.deltaTime;
            transform.position = Vector2.Lerp(transform.position, originalPos, curve.Evaluate(t) * speed);
            yield return null;
        }

        attackButton1.interactable = true;   
        attackButton2.interactable = true;   
    }
}
