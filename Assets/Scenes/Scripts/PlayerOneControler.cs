
using System;
using UnityEngine;

public class PlayerOneControler : PlayerControler
{ 
    [SerializeField] protected PlayerOneInputReader inputReader;
    

    void OnEnable()
    {
        inputReader.OnMoveLeftRightEvent += HandleOnMoveLeftRight;
        inputReader.OnJumpEvent += HandleJump;
        inputReader.OnActionEvent += HandleAction;
    }

    private void OnDisable()
    {
        inputReader.OnMoveLeftRightEvent -= HandleOnMoveLeftRight;
        inputReader.OnJumpEvent -= HandleJump;
        inputReader.OnActionEvent -= HandleAction;
    }

    
    // Update is called once per frame
    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, playerSettings.GrounderCheckCollider,groundLayer);
        MovementHorizontal();
        Jump();
        UsePowerUp();
    }
    
    private void Jump()
    {
        if (isJumping && isGrounded)
        {
            rb2D.AddForce(Vector2.up * playerSettings.JumpPower, ForceMode2D.Impulse );
            Debug.Log("Jump");
            isJumping = false;
        }
    }

    private void UsePowerUp()
    {
        if (currentPowerUp != null && actionRequested)
        {
            powerUpImage.SetActive(false);
            audioSource.PlayOneShot(currentPowerUp.GetPowerUpAudioClip());
            currentPowerUp.UsePowerUp();
            actionRequested = false;
        }
    }
    private void MovementHorizontal()
    {
        if (-playerSettings.maxMovementSpeed/2 < rb2D.linearVelocity.x &&  rb2D.linearVelocity.x < playerSettings.maxMovementSpeed/2)
        {
            rb2D.AddForce(new Vector2(movementVectorLeftRight.x *playerSettings.movementAcceleration, 0), ForceMode2D.Impulse);
        }
        rb2D.linearVelocity = new Vector2(Mathf.Clamp(rb2D.linearVelocity.x, -playerSettings.maxMovementSpeed, playerSettings.maxMovementSpeed), Mathf.Clamp(rb2D.linearVelocity.y, -playerSettings.maxMovementSpeed, playerSettings.maxMovementSpeed));
    }
    void OnDrawGizmosSelected()
    {
        // Visualize the ground check radius in the Scene view
        if (groundCheck != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(groundCheck.position, playerSettings.GrounderCheckCollider);
        }
    }
}
