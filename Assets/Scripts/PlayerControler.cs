using System.Collections;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    [SerializeField] protected PlayerSettings playerSettings;
    
    [SerializeField] protected Rigidbody2D rb2D;
    
    [SerializeField] protected bool isGrounded;
    [SerializeField] protected bool jumpRequested;
    [SerializeField] protected bool canMove = true;
    [SerializeField] protected bool actionRequested;
    [SerializeField] protected bool isJumping;
    [SerializeField] protected LayerMask groundLayer;
    [SerializeField] protected Transform groundCheck;
    
    [SerializeField] protected PowerUpBase currentPowerUp;
    
    protected Vector2 movementVectorLeftRight;
    protected float currentHorizontalSpeed;
    protected float currentVerticalSpeed;
    protected float timeInAirAfterUngrounded;


    protected void HandleOnMoveLeftRight(Vector2 value)
    {
        if (!canMove) return;
        //Debug.Log(value);
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

    public Rigidbody2D GetRigidBody2d()
    {
        return rb2D;
    }

    public void SetCurrentPowerUp(PowerUpBase powerUp)
    {
        currentPowerUp = powerUp;
    }

    public void RemoveCurrentPowerUp()
    {
        Destroy(currentPowerUp.gameObject);
        currentPowerUp = null;
    }

    public bool HasPowerUp()
    {
        if (currentPowerUp == null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void SetCanMove(bool value)
    {
        canMove = value;
    }

    public void StartCanMoveCouroutine(float time)
    {
        StartCoroutine(CanMoveCouroutine(time));
    }

    IEnumerator CanMoveCouroutine(float time)
    {
        movementVectorLeftRight = Vector2.zero;
        SetCanMove(false);
        yield return new WaitForSeconds(time);
        SetCanMove(true);
        yield return null;
    }
}
