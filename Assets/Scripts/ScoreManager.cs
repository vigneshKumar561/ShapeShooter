using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI mainScoreText;
    [SerializeField] Animator mainScoreFadeIn;
    [SerializeField] TextMeshProUGUI highScoreText;
    int highScoreValue;
    public int score;

    // Start is called before the first frame update
    void Start()
    {
        mainScoreText.text = "0";  
    }

    public void DisplayScore()
    {
        mainScoreFadeIn.SetTrigger("GameStarted");
    }

    public void HideScore()
    {
        mainScoreFadeIn.SetTrigger("GameOver");
    }

    public void ResetScore()
    {
        mainScoreText.text = "0";
    }

    // Update is called once per frame
    public void AddToScore(int scoreValue)
    {
        score += scoreValue;
        score += highScoreValue;
        mainScoreText.text = score.ToString();
        UpdateHighScore();
    }

    void UpdateHighScore()
    {
        highScoreText.text = score.ToString();
    }
}
