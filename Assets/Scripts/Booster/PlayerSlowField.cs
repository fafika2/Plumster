using UnityEngine;

public class PlayerSlowField : MonoBehaviour
{
    [Range(0,100)]
    [SerializeField] private float _slownessPercentage = 75f;
    [SerializeField] private float _maxSlowness = 3f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SlowPlayer(collision.gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            MaxSlowPlayer(collision.gameObject);
        }
    }

    private void MaxSlowPlayer(GameObject Player)
    {
        var PlayerRigidbody2D = Player.GetComponent<Rigidbody2D>();
        if (Mathf.Abs(PlayerRigidbody2D.linearVelocityX) > _maxSlowness)
        {
            PlayerRigidbody2D.linearVelocityX = Mathf.Clamp(PlayerRigidbody2D.linearVelocityX,-_maxSlowness,_maxSlowness);
            
        }
    }

    private void SlowPlayer(GameObject Player)
    {
        var Slowness = (100f - _slownessPercentage)/100;
        var PlayerRigidbody2D = Player.GetComponent<Rigidbody2D>();
        PlayerRigidbody2D.linearVelocity *= Slowness;
    }
}
