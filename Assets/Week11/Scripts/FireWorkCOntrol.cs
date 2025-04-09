using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWorkCOntrol : MonoBehaviour
{
    public ParticleSystem firework;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            firework.gameObject.SetActive(!firework.gameObject.activeInHierarchy);
        }

        if(Input.GetMouseButtonDown(0))
        {
            if (firework.isPlaying)
            {
                firework.Stop();
            } else
            {
                firework.Play();
            }
        }
        if(Input.GetMouseButtonDown (1))
        {
            firework.Emit(10);
        }

    }
}
