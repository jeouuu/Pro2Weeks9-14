using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitChime : MonoBehaviour
{
    public KitClock clock;

    public AudioSource source;  
    public AudioClip clip;

    private void Start()
    {
        clock.OnTheHour.AddListener(ChimeTheHour);
    }

    public void Chime()
    {
        Debug.Log("Chiming !");
    }

    public void ChimeTheHour(int hour)
    {
        Debug.Log("chime" + hour);
        StartCoroutine(PlayTheChimeOnHour(hour));
    }

    private void PlayTheChimeOnce()
    {
        source.PlayOneShot(clip);
    }

    IEnumerator PlayTheChimeOnHour(int hour)
    {
        while(hour > 0)
        {
            PlayTheChimeOnce();
            yield return new WaitForSeconds(clip.length);
            hour--;
        }
    }
}
