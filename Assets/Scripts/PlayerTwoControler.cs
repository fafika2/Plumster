
using UnityEngine;

public class PlayerTwoControler : PlayerControler
{
    [SerializeField] protected PlayerTwoInputReader inputReader;
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
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, playerSettings.GrounderCheckCollider,groundLayer );
        MovementHorizontal();
        Jump();
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
    private void MovementHorizontal()
    {
        rb2D.AddForce(new Vector2(movementVectorLeftRight.x *playerSettings.movementAcceleration, 0), ForceMode2D.Impulse);
        rb2D.linearVelocity = new Vector2(Mathf.Clamp(rb2D.linearVelocity.x, -playerSettings.maxMovementSpeed, playerSettings.maxMovementSpeed), rb2D.linearVelocity.y);
    }
    
    private void HandleOnMoveLeftRight(Vector2 value)
    {
        Debug.Log(value);
        movementVectorLeftRight = value;
    }

    private void HandleJump(bool value)
    {
        isJumping = value;
    }
    
    private void HandleAction(bool value)
    {
        actionRequested = value;
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
