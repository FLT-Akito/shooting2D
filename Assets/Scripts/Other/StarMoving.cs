using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarMoving : MonoBehaviour
{
    GameObject wallLeft;
    
    

    private void Start()
    {
        wallLeft = GameObject.Find("WallLeft");
    }
    void Update()
    {
        transform.position -= new Vector3(1f, 0, 0) * Time.deltaTime;
       
        if(transform.position.x < wallLeft.transform.position.x)
        {
            Destroy(gameObject);
        }
        
    }
}
