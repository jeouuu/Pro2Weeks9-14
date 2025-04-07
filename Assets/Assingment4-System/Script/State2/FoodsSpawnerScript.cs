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
    public Vector2 randomPosOffset;

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
            randomPos = new Vector2(Random.Range(minRandomPos.x + randomPosOffset.x,maxRandomPos.x - randomPosOffset.x),Random.Range(minRandomPos.y + randomPosOffset.y, maxRandomPos.y - randomPosOffset.y));

            GameObject newFood = Instantiate(foodPrefab, randomPos,Quaternion.identity);
            newFood.GetComponent<SpriteRenderer>().sprite = foodSprites[Random.Range(0, foodSprites.Length)];

            foodList.Add(newFood);

            yield return new WaitForSeconds(foodSpawnT);
        }

    }
}
