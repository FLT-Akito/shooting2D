using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGroup : MonoBehaviour
{
    public int deadCount = 0;
    public int totalNum = 0;     //enemy‚Ì”

    public void Entry(EnemyBase enemy)
    {
        totalNum++;
        enemy.SetEnemyGroup(this);
    }

    public bool Dead(EnemyBase enemy)
    {
        deadCount++;
        if(deadCount >= totalNum)
        {
            return true;
        }
        else
        {
            return false;
        }
      //  return deadCount >= totalNum;
    }
}
