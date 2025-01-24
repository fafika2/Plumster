
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
