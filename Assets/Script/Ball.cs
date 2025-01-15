using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Vector3 initialPos; 
    public float returnSpeed = 10f; 

    private Rigidbody rb; 
    private GameManager gameManager; 

    private void Start()
    {
        
        initialPos = transform.position;

        
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody not found on the Ball object.");
        }

       
        gameManager = FindObjectOfType<GameManager>();
        if (gameManager == null)
        {
            Debug.LogError("GameManager not found in the scene.");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Wall")) 
        {
            
            if (gameManager != null)
            {
                gameManager.LoseLife();
            }

            
            ResetBall();
        }
        else if (collision.transform.CompareTag("Wall")) 
        {
            if (gameManager != null)
            {
                gameManager.AddScore(10); 
            }
        }
    }

    private void ResetBall()
    {
       
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        
        transform.position = initialPos;
    }
}
