using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Vector3 initialPos; // Ball's initial position
    public float returnSpeed = 10f; // Speed at which the ball returns to the initial position

    private Rigidbody rb; // Rigidbody for physics
    private GameManager gameManager; // Reference to GameManager for managing lives and score

    private void Start()
    {
        // Store the initial position of the ball
        initialPos = transform.position;

        // Get the Rigidbody component
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody not found on the Ball object.");
        }

        // Find the GameManager in the scene
        gameManager = FindObjectOfType<GameManager>();
        if (gameManager == null)
        {
            Debug.LogError("GameManager not found in the scene.");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Wall")) // When the ball hits the wall
        {
            // Deduct a life via the GameManager
            if (gameManager != null)
            {
                gameManager.LoseLife();
            }

            // Reset the ball's position
            ResetBall();
        }
        else if (collision.transform.CompareTag("Wall")) // When the ball hits a scoring zone
        {
            if (gameManager != null)
            {
                gameManager.AddScore(10); // Add 10 points to the score
            }
        }
    }

    private void ResetBall()
    {
        // Stop the ball's motion
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        // Smoothly return the ball to its initial position
        transform.position = initialPos;
    }
}
