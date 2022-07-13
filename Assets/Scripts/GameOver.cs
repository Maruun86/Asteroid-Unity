using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public GameObject scoreBoard;
    ScoreManager scoreManager;
    TextMeshProUGUI scoreText;
   
    public void GameOverMenu()
    {
        Transform childButtonRestart = transform.Find("ButtonRestart");
        Transform childButtonExit = transform.Find("ButtonExit");
        Transform childScore = transform.Find("Scores");
       

        childScore.gameObject.SetActive(true);
        scoreText = childScore.Find("ScoreText").GetComponent<TextMeshProUGUI>();
        childButtonRestart.gameObject.SetActive(true);
        childButtonExit.gameObject.SetActive(true);
        scoreManager = scoreBoard.transform.Find("ScoreManager").GetComponent<ScoreManager>();

        Debug.Log(scoreText);
        scoreText.text = "Score: " + scoreManager.score.ToString();


    }
    public void ButtonRestart()
    {
        SceneManager.LoadScene(1);
    }

    public void ButtonExit()
    {
        Application.Quit();
    }

}

