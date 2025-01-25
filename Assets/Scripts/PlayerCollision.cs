using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private PlayerControler player;
    [SerializeField] private string playerName;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.gameObject != this.gameObject)
        {
            Vector2 playerVelocity = player.GetRigidBody2d().linearVelocity;
            float playerVelocityX = playerVelocity.x;
            float positivePlayerVelocityX = Mathf.Abs(playerVelocityX);
            float playerVelocityY = playerVelocity.y;
            float positivePlayerVelocityY = Mathf.Abs(playerVelocityY);
            Vector2 enemyVelocity = other.gameObject.GetComponent<Rigidbody2D>().linearVelocity;
            float enemyVelocityX = enemyVelocity.x;
            float positiveEnemyVelocityX = Mathf.Abs(enemyVelocityX);
            float enemyVelocityY = enemyVelocity.y;
            float positiveEnemyVelocityY = Mathf.Abs(enemyVelocityY);

            float sumUpVelocityEnemy = positiveEnemyVelocityX + positiveEnemyVelocityY;
            float sumUpVelocityPlayer = positivePlayerVelocityX + positivePlayerVelocityY;

            Debug.Log($"Player velocity equals {sumUpVelocityPlayer}, enemy velocity equals {sumUpVelocityEnemy}");
            if (sumUpVelocityEnemy < sumUpVelocityPlayer)
            {
                Debug.Log("Player Velocity is higher then enemy Velocity");
                player.GetRigidBody2d().AddForce(Vector2.up * 100, ForceMode2D.Impulse);
            }
            
        }
        
    }
}
