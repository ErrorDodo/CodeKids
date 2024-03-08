using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicManager : MonoBehaviour
{
    [SerializeField]
    private Text scoreText;

    [SerializeField]
    private int score;

    [SerializeField] 
    private GameObject GameOverScreen;
    
    public void IncrementScore()
    {
        score += 1;
        scoreText.text = score.ToString();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver()
    {
        GameOverScreen.SetActive(true);
    }
}
