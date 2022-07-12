using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    // Start is called before the first frame update

    public int score = 0;
    public Text scoreText;

    // Update is called once per frame

    private void Update()
    {
       
    }
    public void AddScore(int points)
    {
        this.score += points;
        scoreText.text = score.ToString();

    }
}
