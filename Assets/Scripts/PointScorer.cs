using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointScorer : MonoBehaviour
{
    private Dictionary<char,AsteroidSpawner> mapOfAsteroidSpawersByBeat = new Dictionary<char, AsteroidSpawner>();
    private Dictionary<string, float> mapOfBeatToScore = new Dictionary<string, float>();

    private Dictionary<char, float> mapOfGeneratorScore = new Dictionary<char, float>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void registerAsteroidSpawnerForScoring(char c, AsteroidSpawner ast ) {
        mapOfAsteroidSpawersByBeat.Add(c,ast);
        mapOfGeneratorScore.Add(c,0); // initialize the score to zero
    }

    public void addToGeneratorScore(char c, float amount) {
        float value;
        mapOfGeneratorScore.TryGetValue(c, out value);
        mapOfGeneratorScore[c] = value + amount;
    }

    public void addToBeatScore(Asteroid ast, float amount) {
        float value;
        if (mapOfBeatToScore.TryGetValue(ast.name, out value)) {
            mapOfBeatToScore[ast.name] = value + amount;
        } else {
            mapOfBeatToScore.Add(ast.name, amount);
        }
    }

    public float getScoreForGenerator(char c) {
        float value;
        mapOfGeneratorScore.TryGetValue(c, out value);
        return value;
    }

    public float getScoreForBeat(Asteroid ast) {
        float value;
        if (mapOfBeatToScore.TryGetValue(ast.name, out value)) {
            return value;
        }
        return float.NaN;
    }

    public float getTotalScore() {
        float total = 0;
        foreach (float f in mapOfGeneratorScore.Keys) {
            total += f;
        }
        return total;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
