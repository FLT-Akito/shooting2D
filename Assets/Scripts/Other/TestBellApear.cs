using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBellApear : MonoBehaviour
{
    public GameObject bell;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F1))
        {
            float offsetX = 1.0f;
            float offsetY = 1.5f;
            
            Instantiate(bell,transform.position, Quaternion.identity);
            
            for (int i = 1; i < 3; i++)
            {
                Vector3 targetposUp = new Vector3(transform.position.x + (offsetX * i),
                    transform.position.y + (offsetY * i));
                Vector3 targetposDown = new Vector3(transform.position.x + (offsetX * i),
                    transform.position.y + (-offsetY * i));
                Instantiate(bell, targetposUp, Quaternion.identity);
                Instantiate(bell, targetposDown, Quaternion.identity);
            }

        }
    }
}
