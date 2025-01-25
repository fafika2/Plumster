using UnityEngine;

public class PlayerSpriteAndBubbleController : MonoBehaviour
{
    [SerializeField] private Transform _spriteBallRotation;
    [SerializeField] private Rigidbody2D _characterRigidbody;
    [SerializeField] private float _rotationSpeed = 2f;
    [SerializeField] private SpriteRenderer _hamsterSpriteRenderer;
    [SerializeField] private Animator _hamsterAnimator;
    [SerializeField] private PlayerSettings _playerSettings;

    void Update()
    {
        var Velocity = _characterRigidbody.linearVelocityX;
        RoatateBallByVelocity(Velocity);
        FlipSpriteByVelocity(Velocity);
        SetAnimationBySpeed(Velocity);
    }

    private void RoatateBallByVelocity(float Velocity)
    {
        _spriteBallRotation.Rotate(Vector3.forward, Velocity * -_rotationSpeed);
    }

    private void FlipSpriteByVelocity(float Velocity)
    {
        if (Velocity < 0)
        {
            _hamsterSpriteRenderer.flipX = true;
        }
        else if (Velocity > 0)
        {
            _hamsterSpriteRenderer.flipX = false;
        }
    }

    private void SetAnimationBySpeed(float Velocity)
    {
        var NormalizedVelocity = Mathf.Abs(Velocity) / _playerSettings.maxMovementSpeed;
        _hamsterAnimator.speed = NormalizedVelocity;
    }
}
