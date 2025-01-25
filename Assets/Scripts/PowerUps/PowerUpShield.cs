using UnityEngine;

public class PowerUpShield : PowerUpBase
{
    PlayerHealth playerHealth;

    public override void PowerUpEffect()
    {
        playerHealth = playerControler.GetComponent<PlayerHealth>();
        playerHealth.MakePlayerInvicible(duration);
        base.PowerUpEffect();
    }
}
