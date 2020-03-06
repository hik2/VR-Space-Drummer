using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip drumClip1, drumClip2, drumClip3, drumClip4,
        cannonClip1, cannonClip2, cannonClip3, cannonClip4,
        explosionClip;
    public AudioSource drumSource1, drumSource2, drumSource3, drumSource4,
        cannonSource1, cannonSource2, cannonSource3, cannonSource4,
        explosionSource;
    public float volume;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Explosion sounds test
//         else if (Input.GetKeyDown(KeyCode.P))
//         {
//             explosionSource.PlayOneShot(explosionClip, volume);
//         }
    }

    public void FireDrums(string codeName)
    {
        if(codeName == "RL")
        {
            FireDrumRL();
        }
        else if (codeName == "FL")
        {
            FireDrumFL();
        }
        else if (codeName == "FR")
        {
            FireDrumFR();
        }
        else if (codeName == "RR")
        {
            FireDrumRR();
        }
    }
    void FireDrumRL()
    {
        drumSource1.PlayOneShot(drumClip1, volume);
        cannonSource1.PlayOneShot(cannonClip1, volume);
    }

    void FireDrumFL()
    {
        drumSource2.PlayOneShot(drumClip2, volume);
        cannonSource2.PlayOneShot(cannonClip2, volume);
    }

    void FireDrumFR()
    {
        drumSource3.PlayOneShot(drumClip3, volume);
        cannonSource3.PlayOneShot(cannonClip3, volume);
    }

    void FireDrumRR()
    {
        drumSource4.PlayOneShot(drumClip4, volume);
        cannonSource4.PlayOneShot(cannonClip4, volume);
    }
}
