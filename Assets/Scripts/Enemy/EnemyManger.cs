using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyManger : MonoBehaviour
{
    public GameObject enemyShip;
    public GameObject enemyShip2;
    public GameObject enemyShip3;

    int prefabs_MaxCount = 4;

    void Start()
    {

        StartCoroutine("EnemyCount");

    }

    private void Update()
    {


    }


    IEnumerator EnemyCount()
    {
        EnemyGroup groupA = new GameObject().AddComponent<EnemyGroup>();
        EnemyGroup groupB = new GameObject().AddComponent<EnemyGroup>();
        EnemyGroup groupC = new GameObject().AddComponent<EnemyGroup>();
        EnemyGroup groupD = new GameObject().AddComponent<EnemyGroup>();
        EnemyGroup groupE = new GameObject().AddComponent<EnemyGroup>();
        EnemyGroup groupF = new GameObject().AddComponent<EnemyGroup>();
        EnemyGroup groupG = new GameObject().AddComponent<EnemyGroup>();
        EnemyGroup groupH = new GameObject().AddComponent<EnemyGroup>();
        EnemyGroup groupI = new GameObject().AddComponent<EnemyGroup>();
        EnemyGroup groupJ = new GameObject().AddComponent<EnemyGroup>();
        EnemyGroup groupK = new GameObject().AddComponent<EnemyGroup>();
        EnemyGroup groupL = new GameObject().AddComponent<EnemyGroup>();
        //EnemyGroup groupM = new GameObject().AddComponent<EnemyGroup>();

        groupA.gameObject.name = "EnemyGroupA";
        for (int count = 0; count < prefabs_MaxCount; count++)
        {
            yield return new WaitForSeconds(0.6f);
            GameObject goenemyA = Instantiate(enemyShip, new Vector3(30, 3, 0), Quaternion.identity);
            GameObject goenemyB = Instantiate(enemyShip, new Vector3(50, -3, 0), Quaternion.identity);
            groupA.Entry(goenemyA.GetComponent<EnemyController>());
            groupB.Entry(goenemyB.GetComponent<EnemyController>());

        }

        yield return new WaitForSeconds(1.5f);


        for (int count = 0; count < prefabs_MaxCount - 1; count++)
        {
            float offsetY = -2f;
            float intervalY = -1.0f;
            GameObject goenemyC = Instantiate(enemyShip2, new Vector3(43, count * intervalY + offsetY, 0), Quaternion.identity);
            groupC.Entry(goenemyC.GetComponent<EnemyController>());
            // Instantiate(enemyShip2, new Vector3(43, -1, 0), Quaternion.identity);
            // Instantiate(enemyShip2, new Vector3(43, -2, 0), Quaternion.identity);

        }
        yield return new WaitForSeconds(7f);

        for (int count = 0; count < prefabs_MaxCount; count++)
        {
            yield return new WaitForSeconds(0.6f);
            GameObject goenemyD = Instantiate(enemyShip, new Vector3(35, 3, 0), Quaternion.identity);
            GameObject goenemyE = Instantiate(enemyShip, new Vector3(55, -3, 0), Quaternion.identity);
            groupD.Entry(goenemyD.GetComponent<EnemyController>());
            groupE.Entry(goenemyE.GetComponent<EnemyController>());

        }

        yield return new WaitForSeconds(7f);

        for (int count = 0; count < prefabs_MaxCount; count++)
        {
            yield return new WaitForSeconds(0.6f);
            GameObject goenemyF = Instantiate(enemyShip, new Vector3(40, 3, 0), Quaternion.identity);
            GameObject goenemyG = Instantiate(enemyShip, new Vector3(60, -3, 0), Quaternion.identity);
            groupF.Entry(goenemyF.GetComponent<EnemyController>());
            groupG.Entry(goenemyG.GetComponent<EnemyController>());

        }


        yield return new WaitForSeconds(5f);

        for(int count = 0; count < prefabs_MaxCount - 1; count++)
        {
            
            float intervalY = -1.0f;
            GameObject goenemyH = Instantiate(enemyShip2, new Vector3(55,count * intervalY, 0), Quaternion.identity);    
            groupH.Entry(goenemyH.GetComponent<EnemyController>());
        }
        

        yield return new WaitForSeconds(5f);

        for (int count = 0; count < prefabs_MaxCount; count++)
        {
            yield return new WaitForSeconds(0.6f);
           GameObject goenemyI = Instantiate(enemyShip2, new Vector3(65, 2, 0), Quaternion.identity);
           GameObject goenemyJ = Instantiate(enemyShip2, new Vector3(75, -2, 0), Quaternion.identity);
            groupI.Entry(goenemyI.GetComponent<EnemyController>());
            groupJ.Entry(goenemyJ.GetComponent<EnemyController>());
        }

        yield return new WaitForSeconds(6f);

        for (int count = 0; count < prefabs_MaxCount; count++)
        {
            yield return new WaitForSeconds(0.6f);
            GameObject goenemyK = Instantiate(enemyShip, new Vector3(75, 3, 0), Quaternion.identity);
            GameObject goenemyL = Instantiate(enemyShip, new Vector3(80, -3, 0), Quaternion.identity);
            groupK.Entry(goenemyK.GetComponent<EnemyController>());
            groupL.Entry(goenemyL.GetComponent<EnemyController>());

        }
    }



}

