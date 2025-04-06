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

    //ref of the UI elements
    public Image cookingImage1;
    public Image foodImage1;
    public TextMeshProUGUI numOfFood1; 
    public Image cookingImage2;
    public Image foodImage2;
    public TextMeshProUGUI numOfFood2;
    public Image cookingImage3;
    public Image foodImage3;
    public TextMeshProUGUI numOfFood3;

    //ref of the sprites
    public Sprite[] cookingSprites;
    public Sprite[] foodSprites;

    private bool canChooseCooking = true;
    private bool canChooseFood = true;
    private bool canChooseNumOfFood = true;



    private void Update()
    {
        if(gameStateManager.gameState == 1 && recipeCanvas.activeSelf)
        {
            if (canChooseCooking && canChooseFood && canChooseNumOfFood)
            {
                GenerateRecipeCooking();
                GenerateRecipeFood();
                GenerateRecipeNumOfFood();
            }                    
        }
    }

    private void GenerateRecipeCooking()
    {
        cookingImage1.sprite = cookingSprites[Random.Range(0, cookingSprites.Length)];
        cookingImage2.sprite = cookingSprites[Random.Range(0, cookingSprites.Length)];
        cookingImage3.sprite = cookingSprites[Random.Range(0, cookingSprites.Length)];
        canChooseCooking = false;
    }

    private void GenerateRecipeFood()
    {
        foodImage1.sprite = foodSprites[Random.Range(0, foodSprites.Length)];
        foodImage2.sprite = foodSprites[Random.Range(0, foodSprites.Length)];
        foodImage3.sprite = foodSprites[Random.Range(0, foodSprites.Length)];
        canChooseFood = false;
    }

    private void GenerateRecipeNumOfFood()
    {
        numOfFood1.text = Random.Range(1, 5).ToString();
        numOfFood2.text = Random.Range(1, 5).ToString();
        numOfFood3.text = Random.Range(1, 5).ToString();
        canChooseNumOfFood = false;
    }




}
