using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RecipeManager : MonoBehaviour
{
    //ref of the gameStateManager and uiCanvas
    public GameStateManager gameStateManager;
    public GameObject recipeCanvas;

    //var for the countdown timer
    public float waitTime = 1;

    private void Update()
    {
        //double check if gameState is at 1 and if the recipe canvas is on. If yes then continue on. 
        if(gameStateManager.gameState == 1 && recipeCanvas.activeSelf)
        {            
            StartCoroutine(RecipeCountDown());
        }
    }
    private IEnumerator RecipeCountDown()
    {
        //count down timer for showing the reecipe. 
        //when it reach the wait time tell gameStateManager switfch to state2
        float t = 0;

        while (t < waitTime)
        {
            t += Time.deltaTime;
            yield return null;
        }

        gameStateManager.gameState = 2;
    }
}
