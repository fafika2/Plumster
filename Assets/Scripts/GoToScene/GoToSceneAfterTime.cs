using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToSceneAfterTime : MonoBehaviour
{
    [SerializeField] private string _sceneName;
    [SerializeField] private float _time;
    [SerializeField] private Animator _fadeInAnimator;

    private void Start()
    {
        Invoke("FadeIn", _time - 0.5f);
        Invoke("GoToScene", _time);
    }

    private void GoToScene()
    {
        SceneManager.LoadScene(_sceneName);
    }

    private void FadeIn()
    {
        _fadeInAnimator.SetBool("FadeIn", true);
    }
}
