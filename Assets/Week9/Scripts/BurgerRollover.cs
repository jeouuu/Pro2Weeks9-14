using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BurgerRollover : MonoBehaviour
{
    public Sprite highlight;
    public Sprite normal;

    public Image foodImages;

    public TextMeshProUGUI theText;

    public void MouseIsOver()
    {
        foodImages.sprite = highlight;
        theText.text = "no it's an Egg!!";
    }

    public void MouseNotOver()
    {
        foodImages.sprite = normal;
        theText.text = "is it a Burger?";
    }

}
