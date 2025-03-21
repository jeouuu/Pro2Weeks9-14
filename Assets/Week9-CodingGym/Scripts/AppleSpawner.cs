using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AppleSpawner : MonoBehaviour
{
    public GameObject applePrefab;
    public  float t = 0;

    public LightSwitchController controller;

    private void Update()
    {
        t += Time.deltaTime;
        if (t > 1)
        {
            Spawn();
            t = 0;
        }

    }

    private void Spawn()
    {
        GameObject newApple = Instantiate(applePrefab, Random.insideUnitCircle*4,Quaternion.identity);
        Apple appleScript = newApple.GetComponent<Apple>();

        if (controller != null && appleScript != null)
        {
            controller.onSwitch.AddListener(appleScript.ChangeColor);
            controller.onSwitch.AddListener(appleScript.AppleGrow);
        }
        
    }

}
