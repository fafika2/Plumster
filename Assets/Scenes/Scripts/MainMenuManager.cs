using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private string SceneToLoad;

    [SerializeField] private SO_Score score;
    [SerializeField] private Animator _fadeInAnimator;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            _fadeInAnimator.SetBool("FadeIn", true);
            Invoke("LoadGame", 1f);
        }
    }

    private void LoadGame()
    {
        score.ResetScore();
        SceneManager.LoadScene(SceneToLoad);
    }
}
