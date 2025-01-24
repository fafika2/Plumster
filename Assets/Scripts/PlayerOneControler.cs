
using UnityEngine;

public class PlayerOneControler : MonoBehaviour
{
    [SerializeField] private PlayerOneInputReader inputReader;
    [SerializeField] private PlayerSettings playerSettings;
    
    [SerializeField] private Rigidbody2D rb2D;
    
    [SerializeField] private bool isGrounded;
    [SerializeField] private bool jumpRequested;
    [SerializeField] private bool actionRequested;
    [SerializeField] private bool isJumping;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] private Transform groundCheck;
    
    private Vector2 movementVectorLeftRight;
    private float currentHorizontalSpeed;
    private float currentVerticalSpeed;
    private float timeInAirAfterUngrounded;
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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void Update()
    {
        
    }

   

    // Update is called once per frame
    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, playerSettings.GrounderCheckCollider,groundLayer);
        MovementHorizontal();
        Jump();
        
        
        
        // Apply the updated velocity
        rb2D.linearVelocity = new Vector2(currentHorizontalSpeed, currentVerticalSpeed);
    }
    
    private void Jump()
    {
        if (isJumping && isGrounded)
        {
            currentVerticalSpeed = playerSettings.JumpPower;
            isJumping = false; // Reset jump request after applying the jump
        }
        else if (!isGrounded)
        {
            // Gradually increase fall speed toward maxFallSpeed
            currentVerticalSpeed = Mathf.MoveTowards(currentVerticalSpeed, playerSettings.MaxFallSpeed, -playerSettings.FallAcceleration * Time.fixedDeltaTime);
        }
        else
        {
            // When grounded and not jumping, ensure the vertical velocity stays consistent
            currentVerticalSpeed = Mathf.Clamp(currentVerticalSpeed, -Mathf.Epsilon, Mathf.Epsilon);
        }
    }
    private void MovementHorizontal()
    {
        if (movementVectorLeftRight.x != 0)
        {
            // Accelerate towards the target speed
            currentHorizontalSpeed = Mathf.MoveTowards(currentHorizontalSpeed, movementVectorLeftRight.x * playerSettings.maxMovementSpeed, playerSettings.movementAcceleration * Time.deltaTime);
        }
        else
        {
            // Decelerate towards 0 when no input is given
            currentHorizontalSpeed = Mathf.MoveTowards(currentHorizontalSpeed, 0, playerSettings.movementGroundDeceleration * Time.deltaTime);
        }
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
