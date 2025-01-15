using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform aimTarget;
    public Transform ball;
    float speed = 3f; 


    bool hitting; 

    Vector3 aimTargetInitialPosition; 

    ShotManager shotManager; 
    Shot currentShot; 

    private void Start()
    {
        aimTargetInitialPosition = aimTarget.position; 
        shotManager = GetComponent<ShotManager>(); 
        currentShot = shotManager.topSpin; 
    }

    private void Update()
    {
        float h = Input.GetAxisRaw("Horizontal"); 
        float v = Input.GetAxisRaw("Vertical"); 

        if (Input.GetKeyDown(KeyCode.F))
        {
            hitting = true; 
            currentShot = shotManager.topSpin; 
        }
        else if (Input.GetKeyUp(KeyCode.F))
        {
            hitting = false; 
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            hitting = true; 
            currentShot = shotManager.flat; 
        }
        else if (Input.GetKeyUp(KeyCode.E))
        {
            hitting = false;
        }

        if (hitting)
        {
            aimTarget.Translate(new Vector3(h, 0, 0) * speed * 2 * Time.deltaTime); 
        }

        if ((h != 0 || v != 0) && !hitting)
        {
            transform.Translate(new Vector3(h, 0, v) * speed * Time.deltaTime); 
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            Rigidbody ballRigidbody = other.GetComponent<Rigidbody>();
            if (ballRigidbody != null)
            {
               
                Vector3 direction = (aimTarget.position - transform.position).normalized;

                
                Vector3 forceVector = direction * currentShot.hitForce;

                
                forceVector += Vector3.up * currentShot.upForce;

                
                ballRigidbody.velocity = forceVector;

                aimTarget.position = aimTargetInitialPosition; 
            }
        }
    }
}
