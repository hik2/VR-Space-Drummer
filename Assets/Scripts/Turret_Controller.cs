using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret_Controller : MonoBehaviour
{
    public string colorName = "";

    public GameObject bulletPrefab;
    public Transform muzzleExit;

    public float range = 40f;
    private float rotate_speed = 0.005f;

    Transform targetTrans;

    //fire control
    private float fireRate = 0.3f;
    float fireCounter = 0;

    // Update is called once per frame
    void Update()
    {
        FindNextTarget();

        if (targetTrans != null)
        {
            AimAtTheTarget();



        }

    }

    void FindNextTarget()
    {
        int layerMask = 1 << 10;
        Collider[] enemies = Physics.OverlapSphere(transform.position, range, layerMask);

        if (enemies.Length > 0)
        {
            targetTrans = enemies[0].gameObject.transform;
            //Assuming the first contact of enemy is closest

            foreach (Collider enemy in enemies)
            {
                float distance = Vector3.Distance(transform.position, enemy.transform.position);

                if (distance < Vector3.Distance(transform.position, targetTrans.position))
                {
                    targetTrans = enemy.gameObject.transform;
                }
                //target is a transform
                //enemy is a collider in the collider[] array
                //enemy.gameobject.transform gets its transform
                //distance is calculated with transform.position
            }
        }
        else
        {
            targetTrans = null;
        }
    }

    void AimAtTheTarget()
    {
        Vector3 lookPos = targetTrans.position - transform.position;
        //lookPos.y = 0;

        Quaternion rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.time * rotate_speed);
        //transform.rotation = rotation;

    }

    public void Shoot()
    {
        // Debug.LogError(targetTrans.gameObject.name);
        //  Debug.LogWarning(targetTrans.gameObject.GetComponent<Asteroid>().isLocked());

        if (targetTrans != null)
        {

            if (targetTrans.gameObject.name == colorName && targetTrans.gameObject.GetComponent<Asteroid>().isLocked())
            {
                Vector3 targetPos = targetTrans.position - transform.position;
                Quaternion shootRotation = Quaternion.LookRotation(targetPos);

                GameObject newBullet = Instantiate(bulletPrefab, muzzleExit.position, shootRotation);
                newBullet.GetComponent<Bullet>().target = targetTrans;
                fireCounter = fireRate;

//                 if (fireCounter <= 0)
//                 {
//                     Vector3 targetPos = targetTrans.position - transform.position;
//                     Quaternion shootRotation = Quaternion.LookRotation(targetPos);
// 
//                     GameObject newBullet = Instantiate(bulletPrefab, muzzleExit.position, shootRotation);
//                     newBullet.GetComponent<Bullet>().target = targetTrans;
//                     fireCounter = fireRate;
//                 }
//                 else
//                 {
//                     fireCounter -= Time.deltaTime;
//                 }
            }
        }
    }
}
