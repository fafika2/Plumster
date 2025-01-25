using UnityEngine;
public class PowerUpBoost : PowerUpBase
{
    [SerializeField] private float powerValue;
    public override void PowerUpEffect()
    {
        Rigidbody2D rb2d = playerControler.GetComponent<Rigidbody2D>();
        rb2d.AddForce(rb2d.linearVelocity * powerValue, ForceMode2D.Impulse);
        
        base.PowerUpEffect();
    }
}
