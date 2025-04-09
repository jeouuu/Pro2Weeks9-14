using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGameManager : MonoBehaviour
{
    //ref the gamestatemanager
    public GameStateManager gameStateManager;

    //ref the canvas ui
    public GameObject timeEndUI;
    public GameObject p1WinUI;
    public GameObject p2WinUI;

    //ref the game mode ui manager
    public GameModeUIManager gameModeUIManager;

    //ref the start menu
    public Image chosenChef1;
    public Image chosenChef2;
    public Image p1Winp1;
    public Image p1Winp2;
    public Image p2Winp1;
    public Image p2Winp2;

    private void Update()
    {
        ChangePlayersSprite();

        if(gameStateManager.gameState == 3)
        {
            if (gameModeUIManager.timeEnd)
            {
                timeEndUI.SetActive(true);
            }else if (gameModeUIManager.p1Win)
            {
                p1WinUI.SetActive(true);
            } else if (gameModeUIManager.p2Win)
            {
                p2WinUI.SetActive(true);
            }
        }
    }

    private void ChangePlayersSprite()
    {
        p1Winp1.sprite = chosenChef1.sprite;
        p2Winp1.sprite = chosenChef1.sprite;
        p1Winp2.sprite = chosenChef2.sprite;
        p2Winp2.sprite = chosenChef2.sprite;
    }


}
