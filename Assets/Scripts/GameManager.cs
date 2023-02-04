using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class GameManager : MonoBehaviour
{

    public GameObject gameOverText;
    public GameObject returyText;
    public GameObject gameClearText;

   // public GameObject retryButton;

    public UIController uiController;

    public AreaBoss boss;
    public GameObject player;

    private bool gameOverFlag = false;
    private bool gameClearFlag = false;

    private void Update()
    {
        if (gameOverFlag)
        {
            StartCoroutine("GameOver");
        }

        if (gameClearFlag)
        {
            StartCoroutine("GameClear");
        }
    }

    public void GameOverText()
    {
        gameOverFlag = true;
        gameOverText.SetActive(true);
        uiController.ShowLife(LifeCountManager.lifeCount);
    }

    public void GameClearText()
    {
        if (player != null)
        {
            gameClearFlag = true;
            gameClearText.SetActive(true);
        }
    }

    private IEnumerator GameOver()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("TitleScene");
    }

    private IEnumerator GameClear()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("TitleScene");
    }

    public void RetryText()
    {
        returyText.SetActive(true);
        uiController.ShowLife(LifeCountManager.lifeCount);
    }

    public void OnPressRetryButton()
    {
        SceneManager.LoadScene("Stage1");
    }

    private void OnDisable()
    {
      
        boss.destroyed.RemoveAllListeners();
    }

     
    private void OnEnable()
    {
        boss.destroyed.AddListener(() =>
        {
            GameClearText();
        });

    }


}
