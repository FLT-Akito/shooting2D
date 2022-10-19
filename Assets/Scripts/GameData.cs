using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/GameData")]
public class GameData : ScriptableObject
{
    public int score = 0;
    public int lifeUpIndex = 0;

    public void InitData()
    {
        score = 0;
        lifeUpIndex = 0;
    }
}
