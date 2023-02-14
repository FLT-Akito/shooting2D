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

    public UIController uiController;
    private FlashController flashController;

    public AreaBoss boss;
    public GameObject player;

    private bool gameOverFlag = false;
    private bool gameClearFlag = false;

    private void Start()
    {
        flashController = GameObject.Find("FlashImage").GetComponent<FlashController>();
    }

    private void Update()
    {
        if (gameOverFlag)
        {
            Invoke("GameOver", 2f);
        }

        if (gameClearFlag)
        {
            Invoke("GameClear", 2f);
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

    private void GameOver()
    {
        SceneManager.LoadScene("TitleScene");
    }

    private void GameClear()
    {
        SceneManager.LoadScene("TitleScene");
    }

    public void RetryText()
    {
        flashController.gameObject.SetActive(false);
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
