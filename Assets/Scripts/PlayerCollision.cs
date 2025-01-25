using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private PlayerControler player;
    [SerializeField] private PlayerSettings playerSettings;
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
            Debug.Log(positivePlayerVelocityX);
            
            Vector2 enemyVelocity = other.gameObject.GetComponent<Rigidbody2D>().linearVelocity;
            float enemyVelocityX = enemyVelocity.x;
            float positiveEnemyVelocityX = Mathf.Abs(enemyVelocityX);
            float enemyVelocityY = enemyVelocity.y;
            float positiveEnemyVelocityY = Mathf.Abs(enemyVelocityY);
            
            
            float sumUpVelocityEnemy = Mathf.Clamp(positiveEnemyVelocityX + positiveEnemyVelocityY, 1 ,playerSettings.maxMovementSpeed/4);
            Debug.Log($"sumUpVelocityEnemy {sumUpVelocityEnemy}");
            float sumUpVelocityPlayer = Mathf.Clamp(positivePlayerVelocityX + positivePlayerVelocityY , 1 ,playerSettings.maxMovementSpeed/4);
            Debug.Log($"sumUpVelocityEnemy {sumUpVelocityPlayer}");
            
            Debug.Log($"CALLED BY {playerName}: Player velocity equals {sumUpVelocityPlayer}, enemy velocity equals {sumUpVelocityEnemy}");
            if (sumUpVelocityPlayer >  sumUpVelocityEnemy)
            {
                Debug.Log($" {playerName} Velocity is higher then enemy Velocity");

                Vector2 cachedVelocityPlayer1 = playerVelocity.normalized;
                float differenceInVelocity = sumUpVelocityEnemy / sumUpVelocityPlayer;
                float roundedFloat = Mathf.Round(differenceInVelocity * 100f) * 0.1f;
                Debug.Log($"Player has higher velocity {differenceInVelocity}");
                
                other.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
                other.GetComponent<Rigidbody2D>().AddForce(cachedVelocityPlayer1 * Mathf.Sign(sumUpVelocityPlayer) * playerSettings.CollisionPower  , ForceMode2D.Impulse);
                other.GetComponent<Rigidbody2D>().AddForce(Vector2.up  * 100, ForceMode2D.Impulse);

                player.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
                player.GetComponent<Rigidbody2D>().AddForce(cachedVelocityPlayer1 * -1 * playerSettings.CollisionPower * roundedFloat, ForceMode2D.Impulse);
                player.GetComponent<Rigidbody2D>().AddForce(Vector2.up  * 100, ForceMode2D.Impulse);
                
            }
            
            else if (sumUpVelocityPlayer <  sumUpVelocityEnemy)
            {
                Vector2 cachedVelocityPlayer1 = new Vector2 (Mathf.Sign(playerVelocityX), Mathf.Sign(playerVelocityY));
                float differenceInVelocity = sumUpVelocityEnemy / sumUpVelocityPlayer;
                float roundedFloat = Mathf.Round(differenceInVelocity * 10f) * 0.1f;
                Debug.Log($"Enemy has higher velocity {differenceInVelocity}");

                player.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
                player.GetComponent<Rigidbody2D>().AddForce(cachedVelocityPlayer1 * playerSettings.CollisionPower  , ForceMode2D.Impulse);
                player.GetComponent<Rigidbody2D>().AddForce(Vector2.up  * 500, ForceMode2D.Impulse);

                other.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
                other.GetComponent<Rigidbody2D>().AddForce(cachedVelocityPlayer1 * -1 * playerSettings.CollisionPower * roundedFloat, ForceMode2D.Impulse);
                other.GetComponent<Rigidbody2D>().AddForce(Vector2.up  * 500, ForceMode2D.Impulse);
            }
            else
            {
                Vector2 cachedVelocityPlayer1 = new Vector2 (Mathf.Sign(playerVelocityX), Mathf.Sign(playerVelocityY));
                float differenceInVelocity = sumUpVelocityEnemy / sumUpVelocityPlayer;
                float roundedFloat = Mathf.Round(differenceInVelocity * 10f) * 0.1f;
                Debug.Log($"Enemy has higher velocity {differenceInVelocity}");

                player.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
                player.GetComponent<Rigidbody2D>().AddForce(cachedVelocityPlayer1 * playerSettings.CollisionPower, ForceMode2D.Impulse);
                player.GetComponent<Rigidbody2D>().AddForce(Vector2.up  * 500, ForceMode2D.Impulse);

                other.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
                other.GetComponent<Rigidbody2D>().AddForce(cachedVelocityPlayer1 * -1 * playerSettings.CollisionPower, ForceMode2D.Impulse);
                other.GetComponent<Rigidbody2D>().AddForce(Vector2.up  * 500, ForceMode2D.Impulse);
            }
            
        }
        
    }
}
