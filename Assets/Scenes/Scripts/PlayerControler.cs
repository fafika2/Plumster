using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class PlayerControler : MonoBehaviour
{
    [Header("References")]
    [SerializeField] protected PlayerSettings playerSettings;
    [SerializeField] protected Rigidbody2D rb2D;
    [SerializeField] protected PlayerSpriteAndBubbleController playerSpriteAndBubbleController;
    
    [SerializeField] protected bool isGrounded;
    [SerializeField] protected bool canMove = true;
    [SerializeField] protected bool actionRequested;
    [SerializeField] protected bool isJumping;
    [SerializeField] protected LayerMask groundLayer;
    [SerializeField] protected Transform groundCheck;
    
    [SerializeField] protected PowerUpBase currentPowerUp;
    [SerializeField] public GameObject powerUpImage;
    [SerializeField] protected Sprite stopPlayerPowerSprite;
    [SerializeField] protected AudioSource audioSource;
    
    protected Vector2 movementVectorLeftRight;
    protected float currentHorizontalSpeed;
    protected float currentVerticalSpeed;

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
        Debug.Log("Activating powerUpImage");
        powerUpImage.gameObject.SetActive(true);
        powerUpImage.GetComponent<Image>().sprite = currentPowerUp.GetPowerUpSprite();
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
        playerSpriteAndBubbleController.ChangeSprite(stopPlayerPowerSprite);
        yield return new WaitForSeconds(time);
        SetCanMove(true);
        playerSpriteAndBubbleController.SetBaseSprite();
        yield return null;
    }
    
}
