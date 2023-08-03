using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrushScript : MonoBehaviour
{
    [SerializeField] private float movementSpeed;

    void Update()
    {
        // Get the input from the player
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate the movement direction
        Vector3 movementDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        // Move the GameObject along the X and Z axis
        transform.Translate(movementDirection * movementSpeed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with an object tagged as "Enemy"
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Destroy the enemy GameObject
            Destroy(collision.gameObject);
        }
    }


}

