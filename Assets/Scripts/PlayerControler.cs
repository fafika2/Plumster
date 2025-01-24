using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    [SerializeField] protected PlayerSettings playerSettings;
    
    [SerializeField] protected Rigidbody2D rb2D;
    
    [SerializeField] protected bool isGrounded;
    [SerializeField] protected bool jumpRequested;
    [SerializeField] protected bool actionRequested;
    [SerializeField] protected bool isJumping;
    [SerializeField] protected LayerMask groundLayer;
    [SerializeField] protected Transform groundCheck;
    
    protected Vector2 movementVectorLeftRight;
    protected float currentHorizontalSpeed;
    protected float currentVerticalSpeed;
    protected float timeInAirAfterUngrounded;


    protected void HandleOnMoveLeftRight(Vector2 value)
    {
        Debug.Log(value);
        movementVectorLeftRight = value;
    }

    protected void HandleJump(bool value)
    {
        isJumping = value;
    }

    protected void HandleAction(bool value)
    {
        actionRequested = value;
    }
}
