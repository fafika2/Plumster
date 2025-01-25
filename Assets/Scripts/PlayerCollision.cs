using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private PlayerControler player;
    [SerializeField] private PlayerSettings playerSettings;
    [SerializeField] private Rigidbody2D _player1RigidBody2D, _player2RigidBody2D;
    
    private Vector2 _player1Velocity, _player2Velocity;

    private void Update()
    {
            _player1Velocity = _player1RigidBody2D.linearVelocity;
            _player2Velocity = _player2RigidBody2D.linearVelocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
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

                _player1RigidBody2D.linearVelocity = Vector2.zero;
                _player1RigidBody2D.AddForce(Player1Direction.normalized * playerSettings.CollisionPower * Difference, ForceMode2D.Impulse);

                _player2RigidBody2D.linearVelocity = Vector2.zero;
                _player2RigidBody2D.AddForce(Player2Direction.normalized * playerSettings.CollisionPower, ForceMode2D.Impulse);
            }
            else
            {
                var Difference = Player1VelocitySum / Player2VelocitySum;

                _player1RigidBody2D.linearVelocity = Vector2.zero;
                _player1RigidBody2D.AddForce(Player1Direction.normalized * playerSettings.CollisionPower, ForceMode2D.Impulse);

                _player2RigidBody2D.linearVelocity = Vector2.zero;
                _player2RigidBody2D.AddForce(Player2Direction.normalized * playerSettings.CollisionPower * Difference, ForceMode2D.Impulse);
            }

        }
    }
}
