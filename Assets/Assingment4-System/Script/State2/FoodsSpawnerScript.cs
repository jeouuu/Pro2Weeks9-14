using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodsSpawnerScript : MonoBehaviour
{
    //ref the gameStateManager
    public GameStateManager gameStateManager;

    //ref the food
    public float foodSpawnT;
    private float t;
    public GameObject foodPrefab;
    public Sprite[] foodSprites;

    public List<GameObject> foodList;
    private bool hadSpawn = false;
    private Vector2 randomPos;
    public Vector2 randomPosOffsetUp;
    public Vector2 randomPosOffsetDown;

    //ref the players and ui manager
    public GameObject p1;
    public GameObject p2;
    public GameModeUIManager gameModeUIManager;

    private void Start()
    {
    }

    private void Update()
    {
        if(gameStateManager.gameState == 2 && !hadSpawn)
        {
            hadSpawn = true;
            StartCoroutine(Spawn());     
        }

    }

    private IEnumerator Spawn()
    {
        //choose a random food sprite, then spawn a food in every couple seconds
        while(true)
        {
            //make sure the food stays on screen
            //get the screen bounderies from screen to world
            Vector2 minRandomPos = Camera.main.ScreenToWorldPoint(Vector2.zero);
            Vector2 maxRandomPos = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width,Screen.height));
            //set the random position, with the offset that makes the boundry smaller
            randomPos = new Vector2(Random.Range(minRandomPos.x + randomPosOffsetDown.x,maxRandomPos.x - randomPosOffsetUp.x),Random.Range(minRandomPos.y + randomPosOffsetDown.y, maxRandomPos.y - randomPosOffsetUp.y));

            GameObject newFood = Instantiate(foodPrefab, randomPos,Quaternion.identity);
            newFood.GetComponent<SpriteRenderer>().sprite = foodSprites[Random.Range(0, foodSprites.Length)];
            newFood.GetComponent<FoodItem>().p1 = p1;
            newFood.GetComponent<FoodItem>().p2 = p2;
            newFood.GetComponent<FoodItem>().gameModeUIManager = gameModeUIManager;

            foodList.Add(newFood);

            yield return new WaitForSeconds(foodSpawnT);
        }

    }
}
