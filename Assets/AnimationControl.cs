using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControl : MonoBehaviour
{
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnGUI()
    {
        if(GUI.Button (new Rect(10,10,50,50), "play anim"))
        {
            animator.Play("DrumMotion",0,0);

        }


    }


}
