using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSettings", menuName = "Scriptable Objects/PlayerSettings")]
public class PlayerSettings : ScriptableObject
{
    [Header("Layers")] [Tooltip("Set this to the layer your player is on")]
    public LayerMask playerLayerMask;

    [Header("SnapInput")]
    [Tooltip("Makes All input a int. Prevents different movement speed values for joystick inputs.")]
    public bool SnapInput = true;

    [Header("DeadZones")]
    [Tooltip("Vertical deadzone of vertical movement for joysticks: Climbing ladder or edge"), Range(0.01f, 0.99f)]
    public float VerticalDeadZoneThreshold = 0.3f;

    [Tooltip("Horizontal deadzone of horizontal movement for joysticks: Running left right"), Range(0.01f, 0.99f)]
    public float HorizontalDeadZoneThreshold = 0.3f;

    [Header("Movement")] [Tooltip("Max horizontal movement speed for player movement")]
    public float maxMovementSpeed = 14;

    [Tooltip("Acceleration for player movement")]
    public float movementAcceleration = 120;

    [Tooltip("Value of ground movement deceleration")]
    public float movementGroundDeceleration = 60;

    [Tooltip("Value of mid-air movement deceleration. Only after stopping input")]
    public float AirDeceleration = 30;

    [Tooltip("A constant downward force applied while grounded. Helps on slopes"), Range(0f, -10f)]
    public float GroundingForce = -1.5f;

    [Tooltip("The detection distance for grounding and roof detection")]
    public float GrounderCheckCollider = 1f;

    [Header("JUMP")] [Tooltip("The immediate velocity applied when jumping")]
    public float JumpPower = 36;

    [Tooltip("The maximum vertical movement speed")]
    public float MaxFallSpeed = 40;

    [Tooltip("The player's capacity to gain fall speed. a.k.a. In Air Gravity")]
    public float FallAcceleration = 110;

    [Tooltip("The gravity multiplier added when jump is released early")]
    public float JumpEndEarlyGravityModifier = 3;

    [Tooltip(
        "The time before coyote jump becomes unusable. Coyote jump allows jump to execute even after leaving a ledge")]
    public float CoyoteTime = .15f;

    [Tooltip("The amount of time we buffer a jump. This allows jump input before actually hitting the ground")]
    public float JumpBuffer = .2f;
}