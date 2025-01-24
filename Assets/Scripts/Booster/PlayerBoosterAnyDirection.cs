using UnityEngine;

public class PlayerBoosterAnyDirection : MonoBehaviour
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
        var Direction = transform.position - Player.transform.position;
        PlayerRigidbody2D.AddForce(Direction.normalized * _boosterStrength, ForceMode2D.Impulse);
    }
}
