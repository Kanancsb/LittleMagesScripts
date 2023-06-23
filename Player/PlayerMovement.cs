using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller; // Reference to the CharacterController2D component

    public Animator Walk;

    public float runSpeed = 40f; // Speed at which the player moves horizontally

    float horizontalMove = 0f; // Input value for horizontal movement

    public bool jump = false; // Flag for initiating a jump

    public float Isjumping = -4f; 

    void Update()
    {

        Walk.SetFloat("Speed", Mathf.Abs(horizontalMove));

        // Get the horizontal input for movement
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        // Check if the jump button is pressed
        if (Input.GetButtonDown("Jump"))
        {
            jump = true; // Set the jump flag to true
        }

        if (transform.position.y > Isjumping){
            Walk.SetBool("IsJumping", true);
        }else{
            Walk.SetBool("IsJumping", false);
        }
    }

    void FixedUpdate()
    {
        // Move the character using the CharacterController2D
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);

        // Reset the jump input after it has been used
        jump = false;
    }
}
