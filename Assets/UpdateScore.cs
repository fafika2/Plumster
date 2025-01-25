using TMPro;
using UnityEngine;

public class UpdateScore : MonoBehaviour
{
    [SerializeField] private SO_Score score;
    [SerializeField] private TextMeshProUGUI scoreTextLeft;
    [SerializeField] private TextMeshProUGUI scoreTextRight;

    public void UpdateScoreText()
    {
        scoreTextLeft.text = "";
        scoreTextRight.text = "";
        for (int i = 0; i < score.ScorePlayer1; i++)
        {
            scoreTextLeft.text += "X";
        }
        for (int i = 0; i < score.ScorePlayer2; i++)
        {
            scoreTextRight.text += "X";
        }
    }
}
