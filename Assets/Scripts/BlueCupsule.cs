using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueCupsule : MonoBehaviour
{

    private void TestDisplay()
    {
        GameObject[] gameObjects = FindObjectsOfType(typeof(GameObject)) as GameObject[];
        //Debug.Log("BlueCupsuleDestroy");
        Debug.Log(gameObjects);
        foreach (GameObject obj in gameObjects)
        {
          
         
            
        }
    }
    private void OnDestroy()
    {
        //TestDisplay();
        GameObject[] gameObjects = FindObjectsOfType(typeof(GameObject)) as GameObject[];
        //Debug.Log("BlueCupsuleDestroy");
        //Debug.Log(gameObjects);
        foreach (GameObject obj in gameObjects)
        {
            EnemyController enemy = obj.GetComponent<EnemyController>();
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
