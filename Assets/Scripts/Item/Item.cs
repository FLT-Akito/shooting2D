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
   
    //public GameObject createItem;
    //public GameObject powerUp;
    private GameObject deadLine;
    //private GameManager gameManager;
    // private Rigidbody2D rd;
   
   // float magniRate = 1.2f;
   

    /*　やりたいこと
     *　//1.jewelryが出現したとき鉛直投げ上げ(X軸方向)に動かす。
     *　//2.Playerの弾が3回当たったら色を変える。
     *　//3.jewelryの色ごとに効果を変える。
     *　
     *　
     */

    // Start is called before the first frame update
    protected virtual void Init()
    {

    }
    void Start()
    {
        Init();
        deadLine = GameObject.Find("WallLeft");
        
       // position = transform.position;
     
        //gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
       
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