using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCamera : MonoBehaviour
{
  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { 
        
            transform.position += new Vector3(1f, 0, 0) * Time.deltaTime; 
        // int[] wh = { Screen.width, Screen.height };
        // foreach (int n in wh) Debug.Log(n);
       
    }
}
