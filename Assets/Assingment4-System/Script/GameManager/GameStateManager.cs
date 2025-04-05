using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public int gameState;

    //ref from state 0 
    public GameObject StartMenu;

    private void Start()
    {
        gameState = 0;
    }

    private void Update()
    {
        if(gameState == 0)
        {
            StartMenu.SetActive(true);
        }
        if(gameState == 1)
        {
            StartMenu.SetActive(false);
        }
    }

}
