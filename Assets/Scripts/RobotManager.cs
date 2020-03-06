using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotManager : MonoBehaviour
{
    public AudioClip r1, r2, r3, r4, r5, r6, r7, r8, r9, r10, r11;
    public AudioSource rSource;
    public float volume;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            rSource.PlayOneShot(r1, volume);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            rSource.PlayOneShot(r2, volume);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            rSource.PlayOneShot(r3, volume);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            rSource.PlayOneShot(r4, volume);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            rSource.PlayOneShot(r5, volume);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            rSource.PlayOneShot(r6, volume);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            rSource.PlayOneShot(r7, volume);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            rSource.PlayOneShot(r8, volume);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            rSource.PlayOneShot(r9, volume);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            rSource.PlayOneShot(r10, volume);
        }
        else if (Input.GetKeyDown(KeyCode.Minus))
        {
            rSource.PlayOneShot(r11, volume);
        }
    }
}
