using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int score = 0; // Current score
    public int lives = 3; // Starting number of lives
    public TextMesh scoreTextMesh; // Reference to the TextMesh for score
    public TextMesh livesTextMesh; // Reference to the TextMesh for lives

    // Called when the game starts
    private void Start()
    {
        // Initialize the TextMesh components with starting values
        UpdateScoreText();
        UpdateLivesText();
    }

    // Called when the player scores
    public void AddScore(int points)
    {
        score += points;
        UpdateScoreText();
    }

    // Called when the player loses a life
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

    // Triggered when lives run out
    private void GameOver()
    {
        livesTextMesh.text = "Game Over!";
        scoreTextMesh.text = ""; // Hide score text on game over
    }

    // Updates the score text
    private void UpdateScoreText()
    {
        if (score > 0)
        {
            scoreTextMesh.text = "Score: " + score;
        }
        else
        {
            scoreTextMesh.text = ""; // Hide the score when it's 0
        }
    }

    // Updates the lives text
    private void UpdateLivesText()
    {
        if (lives > 0)
        {
            livesTextMesh.text = "Lives: " + lives;
        }
        else
        {
            livesTextMesh.text = ""; // Hide the lives when they're 0
        }
    }
}
