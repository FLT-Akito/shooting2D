using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScene : MonoBehaviour
{
    private void Start()
    {
        ScoreManager.score = 0;
        LifeCountManager.lifeCount = 2;
    }
    public void Change()
    {
        SceneManager.LoadScene("Stage1");
    }
}
