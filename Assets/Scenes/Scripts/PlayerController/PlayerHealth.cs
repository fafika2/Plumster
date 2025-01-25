using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 100;
    public float currentHealth = 100;
    [Header("Player Death")]
    [SerializeField] private GameObject[] _objectsToDisable;
    [SerializeField] private GameObject _vfxObject;
    [SerializeField] private PlayerControler _playerControler;
    [SerializeField] private Collider2D _collider2D;
    [SerializeField] private Rigidbody2D _playerRigidbody;
    [Header("Score")]
    [SerializeField] private SO_Score score;
    [SerializeField] private bool Player1;
    [SerializeField] private bool Player2;
    [SerializeField] private UpdateScore _updateScore;
    [Header("Heatlh Bar")]
    [SerializeField] private Slider _playerSlider;

    private MatchManager matchManager;
    private bool canTakeDamage = true;


    private void Start()
    {
        matchManager = FindFirstObjectByType<MatchManager>();
        _updateScore = FindFirstObjectByType<UpdateScore>();
        if (Player1)
        {
            FindFirstObjectByType<SuddenDeath>()._player1Health = this.gameObject.GetComponent<PlayerHealth>();
        }
        else
        {
            FindFirstObjectByType<SuddenDeath>()._player2Health = this.gameObject.GetComponent<PlayerHealth>();
        }
        
    }
    private void KillPlayer()
    {
        if (currentHealth <= 0)
        {
            _playerControler.enabled = false;
            _collider2D.enabled = false;
            _playerRigidbody.bodyType = RigidbodyType2D.Static;
            for (int i = _objectsToDisable.Length - 1; i >= 0; i--)
            {
                _objectsToDisable[i].SetActive(false);
            }
            _vfxObject.SetActive(true);
            if (Player1)
            {
                score.ScorePlayer2++;
                _updateScore.UpdateScoreText();
            }
            else if (Player2)
            {
                score.ScorePlayer1++;
                _updateScore.UpdateScoreText();
            }
            
            matchManager.RestartGame();
        }
    }



    public void TakeDamage(float damage)
    {
        if (!canTakeDamage) return;
        currentHealth -= damage;
        var SliderValue = currentHealth / _maxHealth;
        _playerSlider.value = SliderValue;
        KillPlayer();
    }

    public void KillInstant()
    {
        TakeDamage(100);
    }

    public void MakePlayerInvicible(float seconds)
    {
        StartCoroutine(Invicibility(seconds));
    }
    IEnumerator Invicibility(float seconds)
    {
        canTakeDamage = false;
        yield return new WaitForSeconds(seconds);
        canTakeDamage = true;
    }
}
