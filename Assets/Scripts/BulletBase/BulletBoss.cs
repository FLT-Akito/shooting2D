using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBoss : MonoBehaviour
{
    private float bulletSpeed = 10f;

    private void Update()
    {
        transform.Translate(Vector2.down * bulletSpeed * Time.deltaTime);
    }

}
