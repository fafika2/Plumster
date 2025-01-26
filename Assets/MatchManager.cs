using System.Collections;
using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MatchManager : MonoBehaviour
{
    [SerializeField] private GameObject[] players;
    [SerializeField] private List<GameObject> spawnedPlayers;
    [SerializeField] private GameObject[] playerSpawns;
    [SerializeField] private CinemachineTargetGroup TargetGroup;
    [SerializeField] private SO_Score score;
    [SerializeField] private UpdateScore updateScore;
    [SerializeField] private DoSomethingWhenTimerCount _timer;
    [SerializeField] private Animator _fadeInOutAnimator;
    [SerializeField] private GameObject _canvasCounting;
    [SerializeField] private GameObject[] PowerUpImages;


    public void Awake()
    {
        StartCoroutine(StartGameCoroutine());
    }
    public void StartGame()
    {
        _timer.CanCount = true;
        foreach (GameObject player in spawnedPlayers)
        {   
            player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            player.GetComponent<PlayerControler>().enabled = true;
        }
    }

    public void EndGame()
    {
        Invoke("FadeIn", 1f);
        if(score.ScorePlayer1 >= 3)
        {
            Invoke("LoadPlayer1WinScene", 2f);
        }
        else if(score.ScorePlayer2 >= 3)
        {
            Invoke("LoadPlayer2WinScene", 2f);
        }
        _canvasCounting.SetActive(false);
        _timer.CanCount = false;
    }

    public void RestartGame()
    {
        if(score.ScorePlayer1 >= 3 || score.ScorePlayer2 >= 3)
        {
            EndGame();
        }
        else
        {
            _canvasCounting.SetActive(false);
            Invoke("FadeIn", 1f);
            _timer.CanCount = false;
            _timer.ResetTime();
            StartCoroutine(RestartGameCoroutine());
        }
    }

    public void PreparePlayers()
    {
        for (int i = 0; i < players.Length; i++)
        {
            GameObject spawnedPlayer = Instantiate(players[i], playerSpawns[i].transform.position, Quaternion.identity);
            
            spawnedPlayers.Add(spawnedPlayer);
            TargetGroup.AddMember(spawnedPlayers[i].transform, 1, 4);
            spawnedPlayer.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            PlayerControler spawnedPlayerControler = spawnedPlayer.GetComponent<PlayerControler>();
            spawnedPlayerControler.powerUpImage = PowerUpImages[i];
            spawnedPlayerControler.powerUpImage.SetActive(false);
            spawnedPlayerControler.enabled = false;
        }
    }
    
    IEnumerator StartGameCoroutine()
    {
        _fadeInOutAnimator.SetBool("FadeIn", false);
        _canvasCounting.SetActive(true);
        PreparePlayers();
        yield return new WaitForSeconds(3f);
        StartGame();
    }

    IEnumerator RestartGameCoroutine()
    {
        yield return new WaitForSeconds(3f);
        
        for (int i = 0; i < spawnedPlayers.Count; i++)
        {
            TargetGroup.RemoveMember(spawnedPlayers[i].transform);
            Destroy(spawnedPlayers[i]);
        }
        spawnedPlayers.Clear();
        StartCoroutine(StartGameCoroutine());
    }
    
    private void FadeIn()
    {
        _fadeInOutAnimator.SetBool("FadeIn", true);
    }

    private void LoadPlayer1WinScene()
    {
        SceneManager.LoadScene("Player1Win");
    }

    private void LoadPlayer2WinScene()
    {
        SceneManager.LoadScene("Player2Win");
    }
}
