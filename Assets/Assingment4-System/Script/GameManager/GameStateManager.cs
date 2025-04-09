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

    //ref from state 3
    public GameObject timeEndUI;
    public GameObject p1WinUI;
    public GameObject p2WinUI;

    private void Start()
    {
        gameState = 0;
    }

    private void Update()
    {
        //based on the game state, enable the ui and game object accordingly
        if(gameState == 0)
        {
            startMenu.SetActive(true);
            recipeUI.SetActive(false);
            gameModeUI.SetActive(false);
            gameMode.SetActive(false);
            timeEndUI.SetActive(false);
            p1WinUI.SetActive(false);
            p2WinUI.SetActive(false);
        }
        if(gameState == 1)
        {
            startMenu.SetActive(false);
            recipeUI.SetActive(true);
            gameModeUI.SetActive(false);
            gameMode.SetActive(false);
            timeEndUI.SetActive(false);
            p1WinUI.SetActive(false);
            p2WinUI.SetActive(false);
        }
        if (gameState == 2)
        {
            startMenu.SetActive(false);
            recipeUI.SetActive(false);
            gameModeUI.SetActive(true);
            gameMode.SetActive(true);
            timeEndUI.SetActive(false);
            p1WinUI.SetActive(false);
            p2WinUI.SetActive(false);
        }
        if( gameState == 3)
        {
            startMenu.SetActive(false);
            recipeUI.SetActive(false);
            gameModeUI.SetActive(false);
            gameMode.SetActive(false);
            //work this part in end game manager
        }
    }

}
