﻿using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float handlingSpeed = 500f;
    public float wantedSpeed = 800f;
    public float startingBoost = 800f;

    private void Start()
    {
        rb.AddForce(0, 0, startingBoost);
    }

    // Fixed Update prefered for unity physics.
    void FixedUpdate()
    {
        if (rb.velocity.z < wantedSpeed) {
            Debug.Log($"Velocity z: {rb.velocity.z}");
            rb.AddForce(0, 0, (wantedSpeed - rb.velocity.z) * Time.deltaTime);
        }

        if ( Input.GetKey("d")) {
            rb.AddForce(handlingSpeed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey("a"))  {
            rb.AddForce(-handlingSpeed * Time.deltaTime, 0, 0);
        }

        if (rb.position.y <= -1) {
            FindObjectOfType<GameManager>().gameOver();
        }
    }
}
