using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreHealthManager : MonoBehaviour
{
    // Score variables
    private Text scoreText;
    private int scoreInt = 0;
    private int points = 7;

    // Health variables
    private float health = 100;
    private float currentHealth;
    public GameObject shipHealth100, shipHealth80, shipHealth60, shipHealth40, shipHealth20_1, shipHealth20_2, shipHealth20_3;
    public GameObject directionalLightObject;
    private Light directionalLight;
    private float timer = 0;

    // Audio variables
    public AudioClip clip80, clip60, clip40, clip20, clip0, r9, r10;
    private bool playedClip80, playedClip60, playedClip40, playedClip20, playedClip0 = false;
    public AudioSource source;
    public float volume;

    // Start is called before the first frame update
    void Start()
    {
        //scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        currentHealth = health;
        directionalLight = directionalLightObject.GetComponent<Light>();
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
    }

    // If taken damage, update health status and play sound effect
    private void UpdateHealth()
    {
        if (currentHealth == 80)
        {
            shipHealth100.GetComponent<Renderer>().material.SetColor("_TintColor", Color.black);
            if (playedClip80 == false)
            {
                source.PlayOneShot(clip80, volume);
                playedClip80 = true;
            }
        }
        else if (currentHealth == 60)
        {
            shipHealth80.GetComponent<Renderer>().material.SetColor("_TintColor", Color.black);
            if (playedClip60 == false)
            {
                source.PlayOneShot(clip60, volume);
                playedClip60 = true;
            }
        }
        else if (currentHealth == 40)
        {
            shipHealth60.GetComponent<Renderer>().material.SetColor("_TintColor", Color.black);
            if (playedClip40 == false)
            {
                source.PlayOneShot(clip40, volume);
                playedClip40 = true;
            }
        }
        else if (currentHealth == 20)
        {
            shipHealth40.GetComponent<Renderer>().material.SetColor("_TintColor", Color.black);
            shipHealth20_1.GetComponent<Renderer>().material.SetColor("_TintColor", Color.red);
            shipHealth20_2.GetComponent<Renderer>().material.SetColor("_TintColor", Color.red);
            shipHealth20_3.GetComponent<Renderer>().material.SetColor("_TintColor", Color.red);
            if (playedClip20 == false)
            {
                source.PlayOneShot(clip20, volume);
                playedClip20 = true;
                source.PlayOneShot(r9, (float)0.9);
            }
            // Change directional light to red to signify emergency
            directionalLight.color = Color.red;
        }
        else if (currentHealth == 0)
        {
            // Ends and resets Game
            shipHealth20_1.GetComponent<Renderer>().material.SetColor("_TintColor", Color.black);
            shipHealth20_2.GetComponent<Renderer>().material.SetColor("_TintColor", Color.black);
            shipHealth20_3.GetComponent<Renderer>().material.SetColor("_TintColor", Color.black);
            if (playedClip0 == false)
            {
                source.PlayOneShot(clip0, volume);
                playedClip0 = true;
                source.PlayOneShot(r10, 1);
            }
            // Countdown timer 5 seconds, then game reloads
            timer += Time.deltaTime;
            if (timer >= 5)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    // Add basic points to total score
    public void AddBasicScore()
    {
        scoreInt += points;
        scoreText.text = scoreInt.ToString();
    }

    // Add combo points to total score
    private void AddComboScore()
    {
        scoreInt += points * 4;
        scoreText.text = scoreInt.ToString();
    }

    // Update total score when destroying asteriod successfully [T0-DO]
    private void UpdateScore()
    {
        //If one asteriod destroyed
        if (Input.GetKeyDown(KeyCode.A))
        {
            AddBasicScore();
        }
        //If combo completed successfully
        if (Input.GetKeyDown(KeyCode.S))
        {
            AddComboScore();
        }
        //If hit by asteriod, take damage
        if (Input.GetKeyDown(KeyCode.D))
        {
            TakeDamage(10);
        }
    }

    // Update is called once per frame
    void Update()
    {   
        //Check if asteriod destroyed or player hit to update total score
        UpdateScore();
        UpdateHealth();
    }
}
