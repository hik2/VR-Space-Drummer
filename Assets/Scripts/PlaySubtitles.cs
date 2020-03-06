using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlaySubtitles : MonoBehaviour
{
    private AudioSource audioSource;
    //private AudioClip audioClip;
    private ScriptManager scriptManager;
    private SubtitleGuiManager guiManager;
    public bool subtitleOn = true;

    private void Awake()
    {
        scriptManager = FindObjectOfType<ScriptManager>();
        guiManager = FindObjectOfType<SubtitleGuiManager>();
        audioSource = GetComponent<AudioSource>();
        //audioClip = GetComponent<AudioClip>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("PlaySubtitles: value of subtitle on is: " + subtitleOn);
        //if (subtitleOn)
        //{
            StartCoroutine(DoSubtitle());
        //}
    }

    private IEnumerator DoSubtitle()
    {
        var script = scriptManager.GetText(audioSource.clip.name);
        guiManager.SetText(script);

        yield return new WaitForSeconds(audioSource.clip.length);
        guiManager.SetText(string.Empty);
        subtitleOn = false;
    }
}
