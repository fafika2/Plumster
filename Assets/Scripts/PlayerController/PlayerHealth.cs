using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 100;
    [SerializeField] private float _currentHealth = 100;
    [Header("Player Death")]
    [SerializeField] private GameObject[] _objectsToDisable;
    [SerializeField] private GameObject _vfxObject;
    [SerializeField] private PlayerControler _playerControler;
    [SerializeField] private Collider2D _collider2D;
    [SerializeField] private Rigidbody2D _playerRigidbody;
    [Header("Heatlh Bar")]
    [SerializeField] private Slider _playerSlider;

    private void KillPlayer()
    {
        if (_currentHealth <= 0)
        {
            _playerControler.enabled = false;
            _collider2D.enabled = false;
            _playerRigidbody.bodyType = RigidbodyType2D.Static;
            for (int i = _objectsToDisable.Length - 1; i >= 0; i--)
            {
                _objectsToDisable[i].SetActive(false);
            }
            _vfxObject.SetActive(true);
        }
    }



    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        var SliderValue = _currentHealth / _maxHealth;
        _playerSlider.value = SliderValue;
        KillPlayer();
    }



}
