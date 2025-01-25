using System.Collections;
using System.Collections.Generic;
using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;

public class MatchManager : MonoBehaviour
{
    [SerializeField] private GameObject[] players;
    [SerializeField] private List<GameObject> spawnedPlayers;
    [SerializeField] private GameObject[] playerSpawns;
    [SerializeField] private CinemachineTargetGroup TargetGroup;
    [SerializeField] private SO_Score score;
    [SerializeField] private UpdateScore updateScore;
    [SerializeField] private DoSomethingWhenTimerCount _timer;


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
        score.ResetScore();
    }

    public void RestartGame()
    {
        _timer.CanCount = false;
        _timer.ResetTime();
        StartCoroutine(RestartGameCoroutine());
    }

    public void PreparePlayers()
    {
        for (int i = 0; i < players.Length; i++)
        {
            GameObject spawnedPlayer = Instantiate(players[i], playerSpawns[i].transform.position, Quaternion.identity);
            
            spawnedPlayers.Add(spawnedPlayer);
            TargetGroup.AddMember(spawnedPlayers[i].transform, 1, 4);
            spawnedPlayer.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            spawnedPlayer.GetComponent<PlayerControler>().enabled = false;
        }
    }
    
    IEnumerator StartGameCoroutine()
    {
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
    
}
