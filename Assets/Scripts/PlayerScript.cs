using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float moveSpeed = 5f; // The speed at which the player moves
    private Rigidbody2D rb; // The player's Rigidbody2D component

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component on start
    }

    void FixedUpdate()
    {
        // Get the horizontal and vertical input axes (i.e. left/right and up/down)
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        // Create a movement vector based on the input axes and speed
        Vector2 movement = new Vector2(moveHorizontal, moveVertical) * moveSpeed;

        // Move the player's Rigidbody2D component
        rb.MovePosition(rb.position + movement * Time.fixedDeltaTime);
//        rb.velocity = movement;
    }
}