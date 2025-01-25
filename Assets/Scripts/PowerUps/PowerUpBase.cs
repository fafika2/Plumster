using UnityEngine;

public class PowerUpBase : MonoBehaviour
{
    [SerializeField] private int Uses;
    [SerializeField] float workingTime;
    [SerializeField] protected PlayerControler playerControler;
    
    public void UsePowerUp()
    {
        Uses--;
        PowerUpEffect();
        if (Uses <= 0)
        {
            RemovePowerUp();
        }
    }

    public void RemovePowerUp()
    {
        playerControler.RemoveCurrentPowerUp();
    }

    public virtual void PowerUpEffect()
    {
        Debug.Log("PowerUpEffect used");
    }

    public void SetPlayerControler(PlayerControler playerControler)
    {
        this.playerControler = playerControler;
    }
}
