using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBG : MonoBehaviour
{
    public Renderer r;
    public float speed;

    private void Update()
    {
        r.material.mainTextureOffset += new Vector2(Time.deltaTime * speed, 0);
    }
}
