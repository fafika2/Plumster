using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pickable : MonoBehaviour
{
    
    [SerializeField] private List<GameObject> pickups;
    [SerializeField] private float timeBetweenPickups;
    public bool isActive;
    public SpriteRenderer SpriteRenderer;
    
    
    public PowerUpBase[] PowerUp;

    private int randomIndex;

    private void Awake()
    {
        StartCoroutine(RespawnPickup());
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && isActive)
        {
            PlayerControler playerController = other.GetComponent<PlayerControler>();
            if (!playerController.HasPowerUp()) return;
            OnPickup(other.gameObject);
        }
    }

    public void OnPickup(GameObject other)
    {
        if (other.CompareTag("Player") && isActive)
        {
            isActive = false;
            PowerUpBase createdPowerUp = Instantiate(PowerUp[randomIndex], other.transform.position, Quaternion.identity, other.transform);
            SpriteRenderer.sprite = null;
            other.GetComponent<PlayerControler>().SetCurrentPowerUp(createdPowerUp);
            createdPowerUp.SetPlayerControler(other.GetComponent<PlayerControler>());
            StartCoroutine(RespawnPickup());
        }
        
    }
    
    private void ChooseRandomPickup()
    {
        randomIndex = Random.Range(0, PowerUp.Length);
        SpriteRenderer.sprite = PowerUp[randomIndex].GetPowerUpSprite();
    }

    IEnumerator RespawnPickup()
    {
        yield return new WaitForSeconds(timeBetweenPickups);
        ChooseRandomPickup();
        isActive = true;
    }
}

