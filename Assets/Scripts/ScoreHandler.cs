using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreHandler : MonoBehaviour
{

    public int score = 0;

    public Text Scoreboard;

    // Start is called before the first frame update
    void Start()
    {
        Scoreboard.text = "" + score;
    }

    public void AddScore(int value)
    {
        score += value;
        Scoreboard.text = "" + score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
