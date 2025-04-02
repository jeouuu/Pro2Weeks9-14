using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManagerScriupt : MonoBehaviour
{
    public Button buttonSoda;
    public Button buttonMS;

    public PlayerAction script;

    private void Start()
    {
        buttonSoda.interactable = false;
        buttonMS.interactable = false;
    }

    //private IEnumerator CanAttack()
    //{
    //    buttonSoda.interactable = true;

    //  //  yield return StartCoroutine
        
    //}
}
