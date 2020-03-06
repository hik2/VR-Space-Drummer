using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrumCollider : MonoBehaviour
{
    public GameObject pointLight;
    // public GameObject particleSystem;
    public GameObject TurretObj;
    public SoundManager myFiringSDManager;

    public string firingPosition = "";

    public GameObject drumGroup;

    private Animator animator;

    public string animatorName;


    OVRHapticsClip clip = new OVRHapticsClip();


void Start()
    {
        animator = drumGroup.GetComponent<Animator>();

        for (int i = 0; i < 100; i++)
        {
            clip.WriteSample((byte)255);
        }

    }
    //If your GameObject starts to collide with another GameObject with a Collider
    void OnCollisionEnter(Collision collision)
    {

        TurretObj.GetComponent<Turret_Controller>().Shoot();
        myFiringSDManager.FireDrums(firingPosition);



        // activeLight = true;
        blinkingTimes = 20;

        //Output the Collider's GameObject's name
        //  Debug.Log(collision.collider.name);

        //   this.GetComponent<MeshRenderer>().material.color = new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f));

        animator.Play(animatorName, 0, 0);


        //        OVRInput.SetControllerVibration(0.1f, 0.05f, OVRInput.Controller.LTouch, 0.3f);


        if(collision.collider.name== "CylinderRight")
        OVRHaptics.RightChannel.Preempt(clip);

        if (collision.collider.name == "CylinderLeft")
            OVRHaptics.LeftChannel.Preempt(clip);



    }


    int blinkingTimes = 0;
    bool activeLight = false;

    private void Update()
    {


        if (Input.GetKeyDown("space"))
        {
            TurretObj.GetComponent<Turret_Controller>().Shoot();
            myFiringSDManager.FireDrums(firingPosition);

        }



        if (blinkingTimes>0)
        {

            activeLight = !activeLight;
            pointLight.SetActive(activeLight);

            blinkingTimes--;

        }
        else
        {
            pointLight.SetActive(false);
        }
        


    }






}