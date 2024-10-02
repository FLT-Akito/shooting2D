
using UnityEngine;
using UnityEngine.Events;


public abstract class WeaponBase : MonoBehaviour
{
    public GameObject BulletPrefab;
    public bool requestShot;
    [Range(0.05f, 5f)]
    public float interval;
    public float speed;
    public Vector2 direction;
    private float time;

    private void Start()
    {
        Init();
    }

    void Update()
    {
        time += Time.deltaTime;

        if (requestShot)
        {
            if (time >= interval)
            {
                Shot();
                SoundManager.instance.audio.PlayOneShot(SoundManager.instance.shotSE);
                time = 0;
            }
        }
    }

    public void SetShotRequest(bool request)
    {
        requestShot = request;
    }

    public abstract void Shot();

    public virtual void Fire() { }

    public virtual void Init() { }
}
