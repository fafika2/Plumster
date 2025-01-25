using UnityEngine;

public class SuddenDeath : MonoBehaviour
{
    [SerializeField] PlayerHealth _player1Health;
    [SerializeField] PlayerHealth _player2Health;
    public void SuddenDeathInvoke()
    {
        if( _player1Health.currentHealth > _player2Health.currentHealth)
        {
            _player2Health.KillInstant();
        }else if(_player2Health.currentHealth > _player1Health.currentHealth)
        {
            _player1Health.KillInstant();
        }
        else
        {
            int RandomNumber = Random.Range(0, 2);
            if (RandomNumber == 0)
            {
                _player1Health.KillInstant();
            }
            else
            {
                _player2Health.KillInstant();
            }
        }
    }
}
