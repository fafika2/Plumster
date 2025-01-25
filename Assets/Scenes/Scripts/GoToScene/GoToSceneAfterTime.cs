using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToSceneAfterTime : MonoBehaviour
{
    [SerializeField] private string _sceneName;
    [SerializeField] private bool _multipleScenes = false;
    [SerializeField] private string[] _scenesName;
    [SerializeField] private float _time;
    [SerializeField] private Animator _fadeInAnimator;

    private void Start()
    {
        Invoke("FadeIn", _time - 0.5f);
        Invoke("GoToScene", _time);
    }

    private void GoToScene()
    {
        if (_multipleScenes)
        {
            var RandomNumber = Random.Range(0, _scenesName.Length);
            SceneManager.LoadScene(_scenesName[RandomNumber]);
        }
        else
        {
            SceneManager.LoadScene(_sceneName);
        }
    }

    private void FadeIn()
    {
        _fadeInAnimator.SetBool("FadeIn", true);
    }
}
