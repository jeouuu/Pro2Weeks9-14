using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LightSwitchController : MonoBehaviour
{
    public UnityEvent onSwitch;
    public bool isOn = false;

    public Image switchOn;
    public Image switchOff;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            onSwitch.Invoke();
        }

        if (isOn)
        {
            switchOn.color = Color.green;
            switchOff.color = Color.gray;
        } else
        {
            switchOn.color = Color.gray;
            switchOff.color = Color.red;
        }
    }

    public void ToggleSwitch()
    {
        isOn = !isOn;
    }
}
