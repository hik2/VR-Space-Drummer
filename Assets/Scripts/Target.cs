using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float destructWait = 0.5f;

    public float speed;

    private GameObject explosion;
    private Transform explosion_trans;

    private Rigidbody rigidBody;

    private Vector3 movingDirection;



    // Start is called before the first frame update
    void Start()
    {
        explosion_trans = transform.Find("Explosion");
        if(explosion_trans != null)
        {
            explosion = explosion_trans.gameObject;
        }
        explosion.SetActive(false);

        movingDirection = new Vector3(0, 0, -1);

        rigidBody = GetComponent<Rigidbody>();
        rigidBody.velocity = movingDirection * speed;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelfDestruct ()
    {
        explosion.SetActive(true);
        Destroy(gameObject, destructWait);
    }
}
