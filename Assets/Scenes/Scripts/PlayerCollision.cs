using System;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private PlayerControler player;
    [SerializeField] private PlayerSettings playerSettings;
    [SerializeField] private Rigidbody2D _player1RigidBody2D, _player2RigidBody2D;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioClip;
    private SoundMenager SoundMenager;
    
    private Vector2 _player1Velocity, _player2Velocity;

    private void Start()
    {
        _player2RigidBody2D = FindFirstObjectByType<PlayerControler>().GetComponent<Rigidbody2D>();
        SoundMenager = new SoundMenager();
    }
    private void Update()
    {
            _player1Velocity = _player1RigidBody2D.linearVelocity;
            _player2Velocity = _player2RigidBody2D.linearVelocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SoundMenager.PlaySound(audioSource, new Vector2(0.9f, 1.1f), new Vector2(0.8f, 1f) );
            var Player1VelocitySum = Mathf.Abs(_player1Velocity.x) + Mathf.Abs(_player1Velocity.y);
            var Player2VelocitySum = Mathf.Abs(_player2Velocity.x) + Mathf.Abs(_player2Velocity.y);

            var Player1Position = transform;
            var Player2Position = collision.gameObject.transform;

            var Player1Direction = Player1Position.position - Player2Position.position + Player1Position.transform.up;
            var Player2Direction = Player2Position.position - Player1Position.position + Player2Position.transform.up;

            if (Player1VelocitySum == Player2VelocitySum)
            {
                _player1RigidBody2D.linearVelocity = Vector2.zero;
                _player1RigidBody2D.AddForce(Player1Direction.normalized * playerSettings.CollisionPower, ForceMode2D.Impulse);

                _player2RigidBody2D.linearVelocity = Vector2.zero;
                _player2RigidBody2D.AddForce(Player2Direction.normalized * playerSettings.CollisionPower, ForceMode2D.Impulse);
            }
            else if (Player1VelocitySum > Player2VelocitySum)
            {
                var Difference = Player2VelocitySum / Player1VelocitySum;
                var VelocityDif = Player1VelocitySum - Player2VelocitySum;
                DoDamage(Player2Position.gameObject, VelocityDif);

                _player1RigidBody2D.linearVelocity = Vector2.zero;
                _player1RigidBody2D.AddForce(Player1Direction.normalized * playerSettings.CollisionPower * Difference, ForceMode2D.Impulse);

                _player2RigidBody2D.linearVelocity = Vector2.zero;
                _player2RigidBody2D.AddForce(Player2Direction.normalized * playerSettings.CollisionPower, ForceMode2D.Impulse);
            }
            else
            {
                var Difference = Player1VelocitySum / Player2VelocitySum;
                var VelocityDif = Player2VelocitySum - Player1VelocitySum;
                DoDamage(Player1Position.gameObject, VelocityDif);

                _player1RigidBody2D.linearVelocity = Vector2.zero;
                _player1RigidBody2D.AddForce(Player1Direction.normalized * playerSettings.CollisionPower, ForceMode2D.Impulse);

                _player2RigidBody2D.linearVelocity = Vector2.zero;
                _player2RigidBody2D.AddForce(Player2Direction.normalized * playerSettings.CollisionPower * Difference, ForceMode2D.Impulse);
            }
        }
    }

    private void DoDamage(GameObject Object, float DamageCount)
    {
        var DamageSettings = Object.GetComponent<PlayerHealth>();
        DamageSettings.TakeDamage(DamageCount);
    }
}
