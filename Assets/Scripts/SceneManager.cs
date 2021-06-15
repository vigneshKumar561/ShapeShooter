using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    [SerializeField] Animator canvasAnimator;
    public bool gameStarted;
    public bool playerDied;
    [SerializeField] Player player;
    [SerializeField] ScoreManager scoreManager;
    // Start is called before the first frame update
    public void StartGame()
    {
        StartCoroutine(LaunchGame());    
    }

    IEnumerator LaunchGame()
    {        
        canvasAnimator.SetTrigger("StartGame");
        yield return new WaitForSeconds(0.6f);
        gameStarted = true;
        scoreManager.DisplayScore();
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
        scoreManager.DisplayScore();
    }

    public void QuitGame()
    {
        gameStarted = false;
        Application.Quit();
    }
}
