using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public int gameState;

    //ref from state 0 
    public GameObject startMenu;

    //ref from state 1
    public GameObject recipeUI;

    //ref from state 2
    public GameObject gameModeUI;
    public GameObject gameMode;

    private void Start()
    {
        gameState = 2;
    }

    private void Update()
    {
        if(gameState == 0)
        {
            startMenu.SetActive(true);
            recipeUI.SetActive(false);
            gameModeUI.SetActive(false);
            gameMode.SetActive(false);
        }
        if(gameState == 1)
        {
            startMenu.SetActive(false);
            recipeUI.SetActive(true);
            gameModeUI.SetActive(false);
            gameMode.SetActive(false);
        }
        if (gameState == 2)
        {
            startMenu.SetActive(false);
            recipeUI.SetActive(false);
            gameModeUI.SetActive(true);
            gameMode.SetActive(true);
        }
    }

}
