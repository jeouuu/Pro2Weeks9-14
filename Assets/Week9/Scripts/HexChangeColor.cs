using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HexChangeColor : MonoBehaviour
{
    public SpriteRenderer hexSR;

    public UnityEvent onClick;

    public void ChangeColor()
    {
        hexSR.color = Random.ColorHSV();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (hexSR.bounds.Contains(mousePos))
            {
                onClick.Invoke();
            }
        }
    }

    public void ChangeSize()
    {
        transform.localScale += Vector3.one * 0.1f;
    }

}
