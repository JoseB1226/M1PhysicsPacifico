using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int score = 0; 
    public int lives = 3; 
    public TextMesh scoreTextMesh; 
    public TextMesh livesTextMesh; 

   
    private void Start()
    {
        
        UpdateScoreText();
        UpdateLivesText();
    }

    
    public void AddScore(int points)
    {
        score += points;
        UpdateScoreText();
    }

   
    public void LoseLife()
    {
        lives--;

        if (lives > 0)
        {
            UpdateLivesText();
        }
        else
        {
            GameOver();
        }
    }

   
    private void GameOver()
    {
        livesTextMesh.text = "Game Over!";
        scoreTextMesh.text = ""; 
    }

   
    private void UpdateScoreText()
    {
        if (score > 0)
        {
            scoreTextMesh.text = "Score: " + score;
        }
        else
        {
            scoreTextMesh.text = ""; 
        }
    }

   
    private void UpdateLivesText()
    {
        if (lives > 0)
        {
            livesTextMesh.text = "Lives: " + lives;
        }
        else
        {
            livesTextMesh.text = ""; 
        }
    }
}
