using UnityEngine;

public class PlayerBumper : MonoBehaviour
{
    [SerializeField] private float _bumperStrength = 5f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            BumpPlayer(collision.gameObject);
        }
    }

    private void BumpPlayer(GameObject Player)
    {
        var PlayerRigidbody2D = Player.GetComponent<Rigidbody2D>();
        var Direction = Player.transform.position - transform.position;
        PlayerRigidbody2D.linearVelocity = Vector2.zero;
        PlayerRigidbody2D.AddForce(Direction.normalized * _bumperStrength, ForceMode2D.Impulse);
    }
}
