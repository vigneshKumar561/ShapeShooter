using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI mainScoreText;
    [SerializeField] Animator mainScoreFadeIn;
    [SerializeField] TextMeshProUGUI GameOverhighScoreText;
    [SerializeField] TextMeshProUGUI mainMenuHighScore;
    int highScoreValue;
    public int score;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        highScoreValue = SaveSystem.LoadGame().score;
        GameOverhighScoreText.text = highScoreValue.ToString();
        mainMenuHighScore.text = highScoreValue.ToString();
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
        score = 0;
    }

    // Update is called once per frame
    public void AddToScore(int scoreValue)
    {
        score += scoreValue;       
        mainScoreText.text = score.ToString();
        if(score > highScoreValue)
        {
            GameOverhighScoreText.text = score.ToString();
            mainMenuHighScore.text = score.ToString();
        }
    }

    public void SaveScore()
    {
        if(score > highScoreValue)
        {
            SaveSystem.SaveGame(this);
        }           
    }
}
