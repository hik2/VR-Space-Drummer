using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    List<float> beatTimes = new List<float>();
    //List<Asteroid> generatedAsteroids = new List<Asteroid>();
    public List<Asteroid> asteroids;

    public PointScorer scorer;
    public char labelCharacter = 'B';
    public Vector3 colour = new Vector3(1.0F,0,0);
    public float scoreValue = 10F;
    public Vector3 positionSpread = new Vector3(2.0F,2.0F,0.0F);
    float startTime;

    public TextAsset asteroidsText;

    public Vector3 getColour () {
        return colour;
    }

    void Start()
    {
        //string assetFileLocation = "Assets/BeatsForAudio/Beats.txt";
        string text = asteroidsText.text;
        using (StringReader sr = new StringReader(text))
            {
                string line;
                while((line = sr.ReadLine()) != null ) {
                Debug.Log(line);
                    String[] strings = line.Split(new Char[]{ });
                if (strings.Length != 0)
                {
                    Debug.Log("OK length");
                    string beatTime = strings[0].Trim();
                    float beat = float.Parse(beatTime);
                    // add the times that match this particular beat.
                    if (labelCharacter.Equals(Char.Parse(strings[strings.Length - 1].Trim())))
                    {
                        beatTimes.Add(beat);
                        Debug.Log("Added Beat: " + labelCharacter);
                    }
                }
                }
            Debug.Log("Sorting");
                beatTimes.Sort();
            }

        foreach (float f in beatTimes) {
            Debug.Log("Time: "+ f);
        }
        if (scorer != null) {
            scorer.registerAsteroidSpawnerForScoring(labelCharacter,this);
        }
        startTime = Time.time;
    }

    /*
     Instruct the asteroid spawner to update the score.
    */
    public void  hitAsteroid(Asteroid ast) {
        //generatedAsteroids.Remove(ast);
        scorer.addToGeneratorScore(labelCharacter, scoreValue);
        scorer.addToBeatScore(ast, scoreValue);
    }

    // Update is called once per frame
    void Update()
    {
        if(beatTimes.Count != 0 && beatTimes[0] < Time.time) {
            // spawn an asteroid.
            
            int asteroidNumber = UnityEngine.Random.Range(0, asteroids.Count);
            Asteroid prefabAsteroid = asteroids[asteroidNumber];
            float spreadX = UnityEngine.Random.Range(0.0F, positionSpread[0]);
            float spreadY = UnityEngine.Random.Range(0.0F, positionSpread[1]);
            float spreadZ = UnityEngine.Random.Range(0.0F, positionSpread[2]);
            Vector3 positionOffset = new Vector3(spreadX, spreadY, spreadZ);

            Asteroid spawnedAsteroid = Instantiate(prefabAsteroid, transform.position + positionOffset, Quaternion.identity);
            spawnedAsteroid.setSpawner(this);
            //Debug.Log("Removing: "+beatTimes[0]);
            beatTimes.RemoveAt(0);
            //generatedAsteroids.Add(spawnedAsteroid);
        }
    }
}
