using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSpawner : MonoBehaviour
{
    public GameObject treePrefab;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Spawn();
        }
    }

    private void Spawn()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        GameObject newTree = Instantiate(treePrefab, mousePos, Quaternion.identity);
    }


}
