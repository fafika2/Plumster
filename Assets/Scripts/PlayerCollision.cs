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

            Debug.Log($"CALLED BY {playerName}: Player velocity equals {sumUpVelocityPlayer}, enemy velocity equals {sumUpVelocityEnemy}");
            if (sumUpVelocityPlayer >  sumUpVelocityEnemy)
            {
                Debug.Log("Player Velocity is higher then enemy Velocity");

                Vector2 cachedVelocity = playerVelocity.normalized;

                other.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
                other.GetComponent<Rigidbody2D>().AddForce(cachedVelocity.normalized * 500, ForceMode2D.Impulse);
                other.GetComponent<Rigidbody2D>().AddForce(Vector2.up  * 500, ForceMode2D.Impulse);

                player.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
                player.GetComponent<Rigidbody2D>().AddForce(cachedVelocity.normalized * -1 * 500, ForceMode2D.Impulse);
                player.GetComponent<Rigidbody2D>().AddForce(Vector2.up  * 500, ForceMode2D.Impulse);
                
            }
            
        }
        
    }
}
