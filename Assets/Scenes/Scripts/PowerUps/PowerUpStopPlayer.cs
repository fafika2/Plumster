using UnityEngine;

public class PowerUpStopPlayer : PowerUpBase
{
    private bool tmpAbilityInUse;
    public override void PowerUpEffect()
    {
        tmpAbilityInUse = true;
        
        Rigidbody2D[] rigidbodies = FindObjectsByType<Rigidbody2D>(FindObjectsSortMode.None);
        foreach (var rigidbody in rigidbodies)
        {
            if (rigidbody.gameObject != transform.parent.gameObject)
            {
                rigidbody.linearVelocity = Vector2.zero;
                rigidbody.totalForce = Vector2.zero;
                rigidbody.transform.GetComponent<PlayerControler>().StartCanMoveCouroutine(duration);
            }
        }
        base.PowerUpEffect();
    }
}
