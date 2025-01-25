using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSettings", menuName = "Scriptable Objects/PlayerSettings")]
public class PlayerSettings : ScriptableObject
{
   [Header("Movement")] [Tooltip("Max horizontal movement speed for player movement")]
    public float maxMovementSpeed = 14;

    [Tooltip("Acceleration for player movement")]
    public float movementAcceleration = 120;

    [Tooltip("The detection distance for grounding and roof detection")]
    public float GrounderCheckCollider = 1f;

    [Header("JUMP")] [Tooltip("The immediate velocity applied when jumping")]
    public float JumpPower = 36;

    [Tooltip("The maximum vertical movement speed")]
    public float CollisionPower = 500;
}