using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Transform target;
    private ScoreHealthManager myScoreHealthManager;

    public float speed = 10f;
    public float damage = 5f;

    private void Start()
    {
        //myScoreHealthManager = GameObject.Find("[SpaceShips]/[HeathDisplay]").GetComponent<ScoreHealthManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        else
        {
            Destroy(gameObject);
        }


    }

    void OnTriggerEnter(Collider other)
    {
        GameObject obj = other.gameObject;
        if (obj.tag == "Enemy")
        {
            obj.SendMessage("SelfDestruct");
            Debug.Log("Self Destruct Sent!!!");
//             if (myScoreHealthManager != null)
//             {
//                 myScoreHealthManager.AddBasicScore();
//             }
            Destroy(gameObject);
        }
        else if (obj.tag == "Ground")
        {
            Destroy(gameObject);
        }
    }
}
