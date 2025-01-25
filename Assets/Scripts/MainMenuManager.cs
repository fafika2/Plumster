using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private string SceneToLoad;

    [SerializeField] private SO_Score score;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            SceneManager.LoadScene(SceneToLoad);
            score.ResetScore();
        }
        
    }
}
