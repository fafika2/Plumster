using UnityEngine;

[CreateAssetMenu(fileName = "SO_Score", menuName = "Scriptable Objects/SO_Score")]
public class SO_Score : ScriptableObject
{
    public void ResetScore()
    {
        ScorePlayer1 = 0;
        ScorePlayer2 = 0;
    }
    public int ScorePlayer1;
    public int ScorePlayer2;
}
