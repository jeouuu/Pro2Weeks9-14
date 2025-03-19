using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FoodSpawner : MonoBehaviour
{
    public GameObject foodPrefab;
    public Transform UICanvas;


    public void Spawn()
    {
        GameObject newFood = Instantiate(foodPrefab, UICanvas);
        Vector2 newPos = newFood.transform.position;
        newPos.x = Random.Range(0, Screen.width);
        newPos.y = Random.Range(0, Screen.height);
        newFood.transform.position = newPos;
    }
}
