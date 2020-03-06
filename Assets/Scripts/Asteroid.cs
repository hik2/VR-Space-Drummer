using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Asteroid : MonoBehaviour
{
    public string myColor = "";


    // Start is called before the first frame update
    public float speed = 10F;
    public float minimumHitAge = 1F; // 

    public float maximumHitAge = 30F; // 

    public float lockedTime = 1F;
    private float startTime;
    private bool isHit = false;
    private AsteroidSpawner spawner;

    public float destructWait = 0.5f;

    private GameObject explosion;
    private Transform explosion_trans;
    private Rigidbody rigidBody;

    private Vector3 movingDirection;
    private AudioPlayer player;

    private bool colourActive = false;
    private bool targetRingActive = false;
    private float timeUntilIdentified = 1F;
    private bool expired = false;
    void Start()
    {
        startTime = Time.time;  
        player = GameObject.FindWithTag("AudioPlayer").GetComponent<AudioPlayer>();
        explosion_trans = transform.Find("Explosion");
        if(explosion_trans != null)
        {
            explosion = explosion_trans.gameObject;
        }

        //explosion.SetActive(false);

        movingDirection = new Vector3(0, 0, -1F);

        rigidBody = GetComponent<Rigidbody>();
        rigidBody.velocity = movingDirection * speed;
    }

    public void setSpawner(AsteroidSpawner spn) {
        this.spawner = spn;
    }

    // Update is called once per frame
    void Update()
    {   
        //Debug.Log(Time.time - startTime);
        if ((Time.time - startTime) > maximumHitAge) {
            // trigger the destruction of the object and deduct a point
            Debug.Log("Destroy old asteroid");
            //this.SelfDestruct();
            Destroy(gameObject);
            // create destroyed asteroid effect object indicating player was hit.
        }
        // if 
        if ((Time.time - startTime) > (player.getAudioStartDelay() - timeUntilIdentified) && !colourActive && !expired) {
            // turn on the identification ring.
            gameObject.layer = 10;
            toggleColourRing();
        }
        if ((Time.time - startTime) > player.getAudioStartDelay() && !targetRingActive && !expired ) {
            toggleLockingRing();
        }

        if (player.getAudioStartDelay() + lockedTime < (Time.time - startTime) && !expired) {
            gameObject.layer = 0;
            expired = true;
            toggleColourRing();
            toggleLockingRing();
        }
    }

    public bool isLocked() {
        return targetRingActive;
    }

    private void toggleColourRing() {
        Transform warpgate_transform = transform.Find("SM_Veh_WarpGate_Glow_01");
        GameObject warpgate;
        if(warpgate_transform != null)
        {
            warpgate = warpgate_transform.gameObject;
            warpgate.SetActive(!colourActive);
        }
        colourActive = true;
    }

    private void toggleLockingRing() {
        Transform lock_transform = transform.Find("TargetRing");
        GameObject lockingRing;
        if(lock_transform != null)
        {
            lockingRing = lock_transform.gameObject;
            lockingRing.SetActive(!targetRingActive);
        }
        targetRingActive = !targetRingActive;
    }

    public bool isHittableAge() {
        float currentAge = Time.time - startTime;
        if (currentAge >= minimumHitAge && currentAge <= maximumHitAge) {
            Debug.Log("Asteroid was a hittable age");
            return true;
        }
        Debug.Log("Asteroid was not a hittable age");
        return false;
    }

    public bool triggerImpactIfHittable() {
        Debug.Log("Attempt to trigger impact if hittable");
        if (isHittableAge()) {
            this.spawner.hitAsteroid(this);
            Debug.Log("set explosion active"+this.name);
            explosion.SetActive(true);
            Destroy(gameObject, destructWait);
            Debug.Log("Asteroid was hit");
            //this.SelfDestruct();
            return true;
        }
        Debug.Log("No impact was triggered");
        return false;
    }

    public void SelfDestruct ()
    {
        triggerImpactIfHittable();
    }
}
