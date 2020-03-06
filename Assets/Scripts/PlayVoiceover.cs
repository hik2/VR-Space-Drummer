using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayVoiceover : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip r1, r2;
    public float volume;
    private float timer = 0;
    private bool r1Played = false;
    //PlaySubtitles pSubtitles;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        //audioSource.Play();
        // Play ship code audio on game start
        audioSource.PlayOneShot(r1, volume);
        r1Played = true;

        //GameObject g = GameObject.FindGameObjectWithTag("Subtitle");
    }

    private void Start()
    {
        //pSubtitles = g.GetComponent<PlaySubtitles>();
    }

    // Update is called once per frame
    void Update()
    {
        if( r1Played )
        {
            timer += Time.deltaTime;
            if (timer >= 6)
            {
                //pSubtitles.subtitleOn = true;
                audioSource.PlayOneShot(r2, volume);
                r1Played = false;
            }
        }
    }
}
