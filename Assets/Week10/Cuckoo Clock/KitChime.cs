using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitChime : MonoBehaviour
{
    public KitClock clock;

    public GameObject bird;
    public AnimationCurve birdCurve;
    [Range(0,1)]
    public float birdTime;

    public AudioSource source;  
    public AudioClip clip;

    private void Start()
    {
        clock.OnTheHour.AddListener(ChimeTheHour);
    }

    private void Update()
    {
        Debug.Log(birdCurve.Evaluate(birdTime));
    }

    public void Chime()
    {
        Debug.Log("Chiming !");
    }

    public void ChimeTheHour(int hour)
    {
        Debug.Log("chime" + hour);
        StartCoroutine(PlayTheChimeOnHour(hour));
        StartCoroutine(PlayTheBird());
    }

    private void PlayTheChimeOnce()
    {
        source.PlayOneShot(clip);
    }

    private IEnumerator PlayTheBird()
    {
        Vector3 startScale = bird.transform.localScale;
        Vector3 maxScale = startScale * 2f;

        birdTime = 0;

        while (birdTime < 1)
        {
            birdTime += Time.deltaTime;
            bird.transform.localScale = Vector3.Lerp(startScale, maxScale, birdCurve.Evaluate(birdTime));
            yield return null;
        }

        birdTime = 0;

        while (birdTime < 1)
        {
            birdTime += Time.deltaTime;
            bird.transform.localScale = Vector3.Lerp(maxScale, startScale, birdCurve.Evaluate(birdTime));
            yield return null;
        }

        bird.transform.localScale = startScale; 
    }

    private IEnumerator PlayTheChimeOnHour(int hour)
    {
        while(hour > 0)
        {
            PlayTheChimeOnce();
            
            yield return new WaitForSeconds(clip.length);
            hour--;
        }
    }
}
