using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;


public class SceneManager : MonoBehaviour
{
    [SerializeField] Animator canvasAnimator;
    public bool gameStarted;
    public bool playerDied;
    [SerializeField] Player player;
    [SerializeField] ScoreManager scoreManager;
    [SerializeField] GameObject pauseMenu;
    InGameUI inGameUI;


    // Start is called before the first frame update

    private void Start()
    {
        inGameUI = FindObjectOfType<InGameUI>();
    }

    public void StartGame()
    {
        StartCoroutine(LaunchGame());
    }

    IEnumerator LaunchGame()
    {
        canvasAnimator.SetTrigger("StartGame");
        yield return new WaitForSeconds(0.6f);
        gameStarted = true;
        inGameUI.FadeINScore();
    }

    public void PlayAgain()
    {
        StartCoroutine(playagain());
    }

    IEnumerator playagain()
    {
        canvasAnimator.SetTrigger("StartGame");
        player.RevivePlayer();
        yield return new WaitForSeconds(1f);
        playerDied = false;
        gameStarted = true;
        scoreManager.ResetScore();
        inGameUI.FadeINScore();
    }

    public void PauseGame()
    {
        
        if (Time.timeScale == 1)
        {
            pauseMenu.SetActive(true);
            pauseMenu.GetComponent<CanvasGroup>().DOFade(1, 1);
            inGameUI.FadeOutScore();
            Time.timeScale = 0;               
        }
         else
        {
            pauseMenu.GetComponent<CanvasGroup>().DOFade(0, 1);
            pauseMenu.SetActive(false);
            Time.timeScale = 1;           
        }
                
    }

    public void ResumeGame()
    {
        pauseMenu.GetComponent<CanvasGroup>().DOFade(0, 1);
        pauseMenu.SetActive(false);
        inGameUI.FadeINScore();
        Time.timeScale = 1;
    }

    

    public void QuitGame()
    {
        gameStarted = false;
        Application.Quit();
    }
}
