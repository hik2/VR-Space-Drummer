using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLight : MonoBehaviour
{

    public GameObject lightObject;

    Material mat;

    public Color32 color;

    // Start is called before the first frame update
    void Start()
    {
     mat=   lightObject.GetComponent<Material>();

        mat.EnableKeyword("_EMISSION");

    }

  
    private void OnGUI()
    {
        if (GUI.Button(new Rect(10, 10, 50, 250), "play anim"))
        {

            mat.SetColor("_EmissionColor", color);
            //mat.color.


        }


    }



}
