using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCamera : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(1f, 0, 0) * Time.deltaTime;

        if (transform.position.x >= 223f)
        {
            transform.position = new Vector3(223f, 0, -10);
        }
    }
}
