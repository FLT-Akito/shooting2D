using UnityEngine;


public enum JEWELRYCOLORTYPE
{
    TOPAZ,
    AMETHYST,
    DIAMOND,
    EMERALD,
    GARMET,
    RUBY
}

public class Item : MonoBehaviour
{
    private GameObject deadLine;
    
    protected virtual void Init()
    {

    }

    void Start()
    {
        Init();
        deadLine = GameObject.Find("WallLeft");    
    }

    protected virtual void Tick()
    {
    }

    private void Update()
    {
        Tick();
        if (this.gameObject.transform.position.x < deadLine.transform.position.x)
        {
            Destroy(this.gameObject);
        }
    }
}