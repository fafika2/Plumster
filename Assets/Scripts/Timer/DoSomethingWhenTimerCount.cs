using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class DoSomethingWhenTimerCount : MonoBehaviour
{
    [SerializeField] private float _timeRemaining = 45;
    [SerializeField] private UnityEvent _unityEvent;
    [SerializeField] private TextMeshProUGUI _textMeshProUGUI;
    public bool CanCount = true;

    private void Start()
    {
        _textMeshProUGUI.text = Mathf.Round(_timeRemaining).ToString();
    }

    void Update()
    {
        if (_timeRemaining > 0 && CanCount)
        {
            _timeRemaining -= Time.deltaTime;
            _textMeshProUGUI.text = Mathf.Round(_timeRemaining).ToString();
        }
        else if (_timeRemaining <= 0 && CanCount)
        {
            _unityEvent.Invoke();
        }
    }
}
