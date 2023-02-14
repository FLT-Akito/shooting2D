using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MovingCamera : MonoBehaviour
{
    public UnityEvent cameraEvent = new UnityEvent();
    public GameObject player;

    private Vector3 cameraVelocity = new Vector3(1f, 0f, 0f);

    void Update()
    {
        transform.position += cameraVelocity * Time.deltaTime;

        if (transform.position.x >= 186f)
        {
            transform.position = new Vector3(186f, 0, -10);
            cameraEvent.Invoke();
        }

        if(player.gameObject == null)
        {
            cameraVelocity.x = 0f;
        }
    }

    
}
