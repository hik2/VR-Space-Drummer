using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public float delay = 0F;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource>().PlayDelayed(delay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float getAudioStartDelay() {
        return delay;
    }
}
