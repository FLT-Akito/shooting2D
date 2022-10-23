using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/GameData")]
public class GameData : ScriptableObject
{
    public static int score;
    public static int lifeUpCount = 2;

    public void InitData()
    {
        score = 0;
        lifeUpCount = 2;
       
    }
}
