using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueCupsule : MonoBehaviour,IWipedOut
{

    public void WipedOut()
    {
        GameObject[] gameObjects = FindObjectsOfType(typeof(GameObject)) as GameObject[];
        foreach (GameObject obj in gameObjects)
        {
            EnemyBase enemy = obj.GetComponent<EnemyBase>();
            if (enemy != null)
            {
                if (enemy.IsCameraVeiw())
                {
                    enemy.Eliminated();
                }
            }
        }
    }

    
}
