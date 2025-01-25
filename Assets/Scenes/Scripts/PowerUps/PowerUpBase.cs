using UnityEngine;
using UnityEngine.Serialization;

public class PowerUpBase : MonoBehaviour
{
    [SerializeField] private int Uses;
    [SerializeField] protected float duration;
    [SerializeField] protected PlayerControler playerControler;
    [SerializeField] protected Sprite powerUpSprite;
    
    public void UsePowerUp()
    {
        Uses--;
        PowerUpEffect();
    }

    public void RemovePowerUp()
    {
        playerControler.RemoveCurrentPowerUp();
    }

    public virtual void PowerUpEffect()
    {
        if (Uses <= 0)
        {
            RemovePowerUp();
        }
    }

    public void SetPlayerControler(PlayerControler playerControler)
    {
        this.playerControler = playerControler;
    }

    public Sprite GetPowerUpSprite()
    {
        return powerUpSprite;
    }
}
