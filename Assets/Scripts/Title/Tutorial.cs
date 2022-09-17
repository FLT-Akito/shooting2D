using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject tutorialBoard;

    public void SetTutorialBoard()
    {
        tutorialBoard.SetActive(true);
    }
}
