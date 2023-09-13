using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller; // Reference to the CharacterController2D component

    public Animator Walk;

    public float runSpeed = 40f; // Speed at which the player moves horizontally
    public float originalrunSpeed;

    float horizontalMove = 0f; // Input value for horizontal movement

    public bool jump = false; // Flag for initiating a jump

    public float Isjumping = -4f;

    public float dashForce = 10f;
    public bool firedash = false;
    public LayerMask brickLayer;

    public GameObject impacEffect;

    void Start(){
        originalrunSpeed = runSpeed;
    }

    void Update()
    {

        Walk.SetFloat("Speed", Mathf.Abs(horizontalMove));

        // Get the horizontal input for movement
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        // Check if the jump button is pressed
        if (Input.GetButtonDown("Jump"))
        {
            if(firedash && transform.position.y > Isjumping){
                Dash();
            }else{
                jump = true; // Set the jump flag to true
            }
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

    void Dash(){
        AnimationEffect();
        Vector2 dashDirection = new Vector2(horizontalMove, 0f);
        dashDirection.Normalize();

        Vector2 dashForceVector = dashDirection * dashForce;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, dashDirection, dashForce, brickLayer);

        if (hit.collider == null){
            controller.transform.position += (Vector3)dashForceVector;
        }
    }

    void AnimationEffect(){
        if(impacEffect != null){
                GameObject impactInstance = Instantiate(impacEffect, transform.position, transform.rotation);
                Animator animator = impactInstance.GetComponent<Animator>();

                if (animator != null){
                    AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
                    float animationDuration = stateInfo.length;
                    
                    Destroy(impactInstance, animationDuration);
                }
            }
    }
}
