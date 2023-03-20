
using System.IO;
using TMPro;
using UnityEngine;

public class HighScore : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI scoreText;
    int score;
    const string ScorePrefix = "High Score: ";

    private void Start()
    {
        LoadHighScore();
        scoreText.text = ScorePrefix + score.ToString();
    }

    private void LoadHighScore()
    {
        string text = File.ReadAllText(Application.dataPath + "/Scripts/Menu/High-Score.txt");
        score = int.Parse(text);
    }
}
