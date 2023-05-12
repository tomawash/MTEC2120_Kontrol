using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTracker : MonoBehaviour
{
    public TextMesh scoreLabel;
    float score;

    public ParticleSystem partsys = new ParticleSystem();

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore()
    {
        score += 1;
        scoreLabel.text = score.ToString();

        //particles activate here
        partsys.Play();

        Debug.Log("SCORE: " + score);
    }
}
