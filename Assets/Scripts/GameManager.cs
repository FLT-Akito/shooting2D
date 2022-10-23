using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class GameManager : MonoBehaviour
{

    public GameObject gameOverText;
    public GameObject returyText;
    public GameObject retryButton;
    public UIController uiController;
    private bool changeTitleScene = false;

    private void Update()
    {
        if (changeTitleScene)
        {
            StartCoroutine("GameOver");
        }
    }

    public void GameOverText()
    {
        changeTitleScene = true;
        gameOverText.SetActive(true);
        uiController.ShowLife(LifeCountManager.lifeCount);
    }

    private IEnumerator GameOver()
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
}
