using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTracker : MonoBehaviour
{
    public TextMesh scoreLabel;
    float score;

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

        Debug.Log("SCORE: " + score);
    }
}
