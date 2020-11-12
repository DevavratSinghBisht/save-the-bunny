using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    bool gameOver = false;
    int score = 0;
    public Text scoreText;
    public Text gameOverScoreText;
    public GameObject gameOverPanel;

    private void Awake()
    {
        if(instance == null) // instance has no referance
        {
            instance = this; // then referance to the gamemanager
        }
    }

    public void GameOver()
    {
        gameOver = true;
        // Find EnemySpawner game object go to its script and go to class EnemySpawner and execute it fuction StopSpawning
        GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>().StopSpawning();

        // setting the score text for game over pannel
        gameOverScoreText.text = "Score: " + score.ToString();

        // showing the game over pannel
        gameOverPanel.SetActive(true);
    }

    public void IncrementScore()
    {   
        // if game is not over
        if(!gameOver)
        {
            // increment score
            score++;

            // reflect the changes in the UI
            scoreText.text = score.ToString();
        }
    }

    public void MainMenu()
    {
        // laoding the menu scene
        SceneManager.LoadScene("Menu");
    }

    public void Restart()
    {
        // loading the game scene again
        SceneManager.LoadScene("Game");
    }

}
