using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointerEventsFood : MonoBehaviour
{
    Image foodSR;
    public Sprite[] foodSprites;
    public Sprite normal;

    private void Start()
    {
        foodSR = GetComponent<Image>();
    }

    public void ChangeSprite()
    {
        foodSR.sprite = foodSprites[Random.Range(0, foodSprites.Length)];
    }

    public void NormalSprite()
    {
        foodSR.sprite = normal;
    }
}
