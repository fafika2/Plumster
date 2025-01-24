using UnityEngine;

public class PlayerBooster : MonoBehaviour
{
    [SerializeField] private float _boosterStrength = 5f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            BoostPlayer(collision.gameObject);
        }
    }

    private void BoostPlayer(GameObject Player)
    {
        var PlayerRigidbody2D = Player.GetComponent<Rigidbody2D>();
        PlayerRigidbody2D.linearVelocity = Vector2.zero;
        PlayerRigidbody2D.AddForce(transform.up * _boosterStrength, ForceMode2D.Impulse);
    }
}
