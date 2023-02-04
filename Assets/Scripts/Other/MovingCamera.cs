using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MovingCamera : MonoBehaviour
{
    public UnityEvent isCameraStop = new UnityEvent();

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(1f, 0, 0) * Time.deltaTime;

        if (transform.position.x >= 186f)
        {
            transform.position = new Vector3(186f, 0, -10);
            isCameraStop.Invoke();
        }
    }
}
