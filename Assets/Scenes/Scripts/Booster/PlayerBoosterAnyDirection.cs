using UnityEngine;

public class PlayerBoosterAnyDirection : MonoBehaviour
{
    [SerializeField] private float _boosterStrength = 5f;
    [SerializeField] private AudioSource _audioSource;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            BoostPlayer(collision.gameObject);
        }
    }

    private void BoostPlayer(GameObject Player)
    {
        SoundMenager Audio = new SoundMenager();
        Audio.PlaySound(_audioSource, new Vector2(0.9f, 1.1f), new Vector2(0.8f, 1f));
        var PlayerRigidbody2D = Player.GetComponent<Rigidbody2D>();
        var Direction = PlayerRigidbody2D.linearVelocity;
        PlayerRigidbody2D.AddForce(Direction.normalized * _boosterStrength, ForceMode2D.Impulse);
    }
}
