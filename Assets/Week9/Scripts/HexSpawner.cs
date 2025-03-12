using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HexSpawner : MonoBehaviour
{
    public GameObject hexPrefab;
    public Button colorButton;
    public TextMeshProUGUI numText;
    int clicked = 0;


    public void Spawn()
    {
        GameObject newHex = Instantiate(hexPrefab, Random.insideUnitCircle * 4, Quaternion.identity);
        HexChangeColor changeColorScript = newHex.GetComponent<HexChangeColor>();

        colorButton.onClick.AddListener(changeColorScript.ChangeColor );

        changeColorScript.onClick.AddListener(AddToClick);
    }

    public void StopListening()
    {
        colorButton.onClick.RemoveAllListeners();
    }

    public void AddToClick()
    {
        clicked++;
        numText.text = clicked.ToString();
    }

}
