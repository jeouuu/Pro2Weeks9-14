using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDrawing : MonoBehaviour
{
    public LineRenderer lr;
    public List<Vector2> listOfPoints;

    private void Start()
    {
        listOfPoints = new List<Vector2>();
        lr.positionCount = 0;
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector2 newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            listOfPoints.Add(newPos);

            lr.positionCount++;
            lr.SetPosition(lr.positionCount-1, newPos);
        }

        if(Input.GetMouseButtonDown(1))
        {
            listOfPoints = new List<Vector2>();
            lr.positionCount = 0;
        }

    }
}
