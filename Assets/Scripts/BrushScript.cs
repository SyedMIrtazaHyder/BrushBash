using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrushScript : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private JoystickController controller;
    private GameObject brush;
    private void Start()
    {
        brush = gameObject;
    }
    void Update()
    {
        // Get the input from the player
        /*float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate the movement direction
        Vector3 movementDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        // Move the GameObject along the X and Z axis
        transform.Translate(movementDirection * movementSpeed * Time.deltaTime);*/
        brush.transform.position = new Vector3(brush.transform.position.x + controller.GetInputDirection().x * movementSpeed,
            brush.transform.position.y,
            brush.transform.position.z + controller.GetInputDirection().y * movementSpeed);
        Debug.Log(controller.GetInputDirection());
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

