using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform aimTarget;
    public Transform ball;
    float speed = 3f; // Player's move speed


    bool hitting; // Whether the player is hitting the ball

    Vector3 aimTargetInitialPosition; // Initial position of the aiming target

    ShotManager shotManager; // Reference to ShotManager
    Shot currentShot; // Current shot being executed

    private void Start()
    {
        aimTargetInitialPosition = aimTarget.position; // Store aim target's initial position
        shotManager = GetComponent<ShotManager>(); // Access the ShotManager component
        currentShot = shotManager.topSpin; // Default shot
    }

    private void Update()
    {
        float h = Input.GetAxisRaw("Horizontal"); // Horizontal input
        float v = Input.GetAxisRaw("Vertical"); // Vertical input

        if (Input.GetKeyDown(KeyCode.F))
        {
            hitting = true; // Start hitting
            currentShot = shotManager.topSpin; // Set topspin shot
        }
        else if (Input.GetKeyUp(KeyCode.F))
        {
            hitting = false; // Stop hitting
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            hitting = true; // Start hitting
            currentShot = shotManager.flat; // Set flat shot
        }
        else if (Input.GetKeyUp(KeyCode.E))
        {
            hitting = false;
        }

        if (hitting)
        {
            aimTarget.Translate(new Vector3(h, 0, 0) * speed * 2 * Time.deltaTime); // Move aim target
        }

        if ((h != 0 || v != 0) && !hitting)
        {
            transform.Translate(new Vector3(h, 0, v) * speed * Time.deltaTime); // Move player
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            Rigidbody ballRigidbody = other.GetComponent<Rigidbody>();
            if (ballRigidbody != null)
            {
                // Calculate direction vector
                Vector3 direction = (aimTarget.position - transform.position).normalized;

                // Apply Newton's second law: F = ma (assuming unit mass, F = a)
                Vector3 forceVector = direction * currentShot.hitForce;

                // Add vertical force for lift
                forceVector += Vector3.up * currentShot.upForce;

                // Apply the velocity to the ball's rigidbody
                ballRigidbody.velocity = forceVector;

                aimTarget.position = aimTargetInitialPosition; // Reset aim target
            }
        }
    }
}
