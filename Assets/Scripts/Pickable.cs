using System.Collections;
using UnityEngine;

public class Pickable : MonoBehaviour
{
    public float CooldownValue;
    public bool isActive;
    public SpriteRenderer SpriteRenderer;

    public Color ActiveColor;
    public Color InActiveColor;

    private void Awake()
    {
        ActiveColor = SpriteRenderer.color;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isActive)
        {
            SetOnCoolDown();
        }
    }

    protected virtual void OnPickup()
    {
        
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

