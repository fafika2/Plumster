using System.Collections;
using UnityEngine;

public class Pickable : MonoBehaviour
{
    public float CooldownValue;
    public bool isActive;
    public SpriteRenderer SpriteRenderer;

    public Color ActiveColor;
    public Color InActiveColor;
    
    public PowerUpBase PowerUp;

    private void Awake()
    {
        ActiveColor = SpriteRenderer.color;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isActive)
        {
            PlayerControler playerController = other.GetComponent<PlayerControler>();
            if (!playerController.HasPowerUp()) return;
            SetOnCoolDown();
            OnPickup(other.gameObject);
        }
    }

    public void OnPickup(GameObject other)
    {
        if (other.CompareTag("Player") && isActive)
        {
            Debug.Log("Player controller found");
            Debug.Log("Picked up");
            
            PowerUpBase createdPowerUp = Instantiate(PowerUp, other.transform.position, Quaternion.identity, other.transform);
            other.GetComponent<PlayerControler>().SetCurrentPowerUp(createdPowerUp);
            createdPowerUp.SetPlayerControler(other.GetComponent<PlayerControler>());
        }
        
    }

    private void SetOnCoolDown()
    {
        StartCoroutine(Cooldown());
    }

    IEnumerator Cooldown()
    {
        isActive = true;
        SpriteRenderer.color = InActiveColor;
        yield return new WaitForSeconds(CooldownValue);
        SpriteRenderer.color = ActiveColor;
        isActive = false;
    }
}

