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
   

    /*�@��肽������
     *�@//1.jewelry���o�������Ƃ����������グ(X������)�ɓ������B
     *�@//2.Player�̒e��3�񓖂�������F��ς���B
     *�@//3.jewelry�̐F���ƂɌ��ʂ�ς���B
     *�@
     *�@
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